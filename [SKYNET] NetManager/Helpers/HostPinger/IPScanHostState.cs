using System;
using System.Net;

namespace SKYNET.NetUtils
{
    public class IPScanHostState
    {
        public enum State
        {
            Testing = 1,
            Alive = 2,
            Dead = 4
        }

        public enum QCategory
        {
            VeryPoor,
            Poor,
            Fair,
            Good,
            VeryGood,
            Excellent,
            Perfect
        }

        public delegate void StateChangeDelegate(IPScanHostState host, State oldState);

        public delegate void HostNameAvailableDelegate(IPScanHostState host);

        private object _lock = new object();

        private IPAddress _address;

        private long[] _responsTimes;

        private int _pingsCount;

        private int _lossCount;

        private float _avgResponseTime = -1f;

        private int _timeout;

        private float _quality = -1f;

        private bool _alive;

        private State _currentState = (State)5;

        private AsyncHostNameResolver _nameResolver = new AsyncHostNameResolver();

        private string _hostName = string.Empty;

        public IPAddress Address => _address;

        public long[] ResponseTimes => _responsTimes;

        public int PingsCount => _pingsCount;

        public int LossCount => _lossCount;

        public float AvgResponseTime
        {
            get
            {
                lock (_lock)
                {
                    if (_avgResponseTime < 0f)
                    {
                        _avgResponseTime = 0f;
                        for (int num = _pingsCount - 1; num >= 0; num--)
                        {
                            _avgResponseTime += (float)_responsTimes[num];
                        }
                        _avgResponseTime /= (float)_pingsCount;
                    }
                    return _avgResponseTime;
                }
            }
        }

        public float Quality
        {
            get
            {
                lock (_lock)
                {
                    if (_quality < 0f)
                    {
                        _quality = 0f;
                        float num = 1f / (float)_pingsCount;
                        for (int num2 = _pingsCount - 1; num2 >= 0; num2--)
                        {
                            if (_responsTimes[num2] > 5)
                            {
                                _quality += num * (1f - (float)Math.Log((double)(_responsTimes[num2] / 5), (double)(5 * _timeout)));
                            }
                            else if (_responsTimes[num2] >= 0)
                            {
                                _quality += num;
                            }
                        }
                    }
                    return _quality;
                }
            }
        }

        public QCategory QualityCategory => (QCategory)(6f * Quality);

        public State CurrentState => _currentState;

        public string HostName => _hostName;

        public IPAddress RemoteAddress { get; set; }

        public event StateChangeDelegate OnStateChange;

        public event HostNameAvailableDelegate OnHostNameAvailable;

        private void ClearCachedValues()
        {
            _quality = (_avgResponseTime = -1f);
        }

        private bool SetState(State state)
        {
            bool result = (!IsAlive() && IsAlive(state)) || (IsAlive() && IsDead(state)) || IsTesting() != IsTesting(state);
            _currentState = state;
            return result;
        }

        private bool IsAlive(State state)
        {
            return (state & State.Alive) == State.Alive;
        }

        public bool IsAlive()
        {
            return IsAlive(_currentState);
        }

        private bool IsDead(State state)
        {
            return (state & State.Dead) == State.Dead;
        }

        public bool IsDead()
        {
            return IsDead(_currentState);
        }

        private bool IsTesting(State state)
        {
            return (state & State.Testing) == State.Testing;
        }

        public bool IsTesting()
        {
            return IsTesting(_currentState);
        }

        private void RaiseOnStateChange(State oldState)
        {
            if (this.OnStateChange != null)
            {
                this.OnStateChange(this, oldState);
            }
        }

        public void StoreHostName(string name)
        {
            lock (_lock)
            {
                _hostName = name;
            }
            if (this.OnHostNameAvailable != null)
            {
                this.OnHostNameAvailable(this);
            }
        }

        public IPScanHostState(IPAddress address, int pingsRequired, int timeout)
        {
            _address = address;
            _timeout = timeout;
            _responsTimes = new long[pingsRequired];
        }

        public void Prepare()
        {
            lock (_lock)
            {
                ClearCachedValues();
                _hostName = string.Empty;
                _pingsCount = (_lossCount = 0);
                _alive = false;
                _currentState |= State.Testing;
            }
        }

        public void StorePingResult()
        {
            StorePingResult(-1L);
        }

        public void StorePingResult(long responseTime, IPAddress address = (IPAddress)default)
        {
            bool flag = false;
            State oldState = State.Testing;
            lock (_lock)
            {
                if (responseTime >= 0)
                {
                    _alive = true;
                    oldState = _currentState;
                    flag = SetState((State)3);
                    if (flag)
                    {
                        _nameResolver.ResolveHostName(_address, StoreHostName);
                    }
                }
                else
                {
                    _lossCount++;
                }
                ClearCachedValues();
                _responsTimes[_pingsCount++] = responseTime;
                if (_pingsCount == _responsTimes.Length)
                {
                    oldState = _currentState;
                    flag = SetState(_alive ? State.Alive : State.Dead);
                }
            }
            if (flag)
            {
                RaiseOnStateChange(oldState);
            }
            if (address != null)
            {
                RemoteAddress = address;
            }
        }
    }

}