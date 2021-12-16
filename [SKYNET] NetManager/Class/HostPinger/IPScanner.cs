using NetUtils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace NetUtils
{
    public class IPScanner
    {
        private class PingerEntry
        {
            public Ping _ping = new Ping();

            public IPScanHostState _results;
        }

        public delegate void AliveHostFoundDelegate(IPScanner scanner, IPScanHostState host);

        public delegate void ScanStateChangeDelegate(IPScanner scanner);

        public delegate void ScanProgressUpdateDelegate(IPScanner scanner, IPAddress currentAddress, ulong progress, ulong total);

        private object _runControlLock = new object();

        private object _resultsLock = new object();

        private PingerEntry[] _pingers;

        private int _timeout = 2000;

        private PingOptions _pingOptions = new PingOptions();

        private byte[] _pingBuffer = new byte[32];

        private int _concurrentPings = 1;

        private int _pingsPerScan = 1;

        private bool _continuousScan = true;

        private volatile bool _active;

        private ManualResetEvent _stopEvent = new ManualResetEvent(initialState: true);

        private IPScanRange _range;

        private IPAddress _nextToScan;

        private volatile int _activePings;

        private Dictionary<IPAddress, IPScanHostState> _aliveHosts = new Dictionary<IPAddress, IPScanHostState>();

        private ulong _lastUpdate;

        public int Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _timeout = value;
                }
            }
        }

        public int TTL
        {
            get
            {
                return _pingOptions.Ttl;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _pingOptions.Ttl = value;
                }
            }
        }

        public bool DontFragment
        {
            get
            {
                return _pingOptions.DontFragment;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _pingOptions.DontFragment = value;
                }
            }
        }

        public int PingBufferSize
        {
            get
            {
                return _pingBuffer.Length;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _pingBuffer = new byte[value];
                }
            }
        }

        public int ConcurrentPings
        {
            get
            {
                return _concurrentPings;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _concurrentPings = value;
                }
            }
        }

        public int PingsPerScan
        {
            get
            {
                return _pingsPerScan;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _pingsPerScan = value;
                }
            }
        }

        public bool ContinuousScan
        {
            get
            {
                return _continuousScan;
            }
            set
            {
                lock (_runControlLock)
                {
                    CheckRunning();
                    _continuousScan = value;
                }
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (value)
                {
                    throw new InvalidOperationException("Scanner can only be stopped using this property");
                }
                Stop(wait: false);
            }
        }

        public Dictionary<IPAddress, IPScanHostState>.ValueCollection AliveHosts => _aliveHosts.Values;

        public event AliveHostFoundDelegate OnAliveHostFound;

        public event ScanStateChangeDelegate OnStartScan;

        public event ScanStateChangeDelegate OnStopScan;

        public event ScanStateChangeDelegate OnRestartScan;

        public event ScanProgressUpdateDelegate OnScanProgressUpdate;

        private void RaiseOnAliveHostFound(IPScanHostState host)
        {
            if (this.OnAliveHostFound != null)
            {
                this.OnAliveHostFound(this, host);
            }
        }

        private void RaiseOnStartScan()
        {
            if (this.OnStartScan != null)
            {
                this.OnStartScan(this);
            }
        }

        private void RaiseOnStopScan()
        {
            if (this.OnStopScan != null)
            {
                this.OnStopScan(this);
            }
        }

        private void RaiseOnRestartScan()
        {
            if (this.OnRestartScan != null)
            {
                this.OnRestartScan(this);
            }
        }

        private void RaiseOnScanProgressUpdate(IPAddress currentAddress)
        {
            ulong distance = _range.GetDistance(currentAddress);
            if (distance > _lastUpdate)
            {
                _lastUpdate = distance;
                if (this.OnScanProgressUpdate != null)
                {
                    this.OnScanProgressUpdate(this, currentAddress, distance, _range.RangeSize);
                }
            }
        }

        public IPScanner()
        {
        }

        public IPScanner(int concurrentPings, int pingsPerScan, bool continuousScan)
        {
            _concurrentPings = concurrentPings;
            _pingsPerScan = pingsPerScan;
            _continuousScan = continuousScan;
        }

        public IPScanner(int concurrentPings, int pingsPerScan, bool continuousScan, int timeout)
            : this(concurrentPings, pingsPerScan, continuousScan)
        {
            _timeout = timeout;
        }

        public IPScanner(int concurrentPings, int pingsPerScan, bool continuousScan, int timeout, int ttl, bool dontFragment, int pingBufferSize)
            : this(concurrentPings, pingsPerScan, continuousScan, timeout)
        {
            TTL = ttl;
            DontFragment = dontFragment;
            PingBufferSize = pingBufferSize;
        }

        public void Start(IPScanRange range)
        {
            lock (_runControlLock)
            {
                CheckRunning();
                _aliveHosts.Clear();
                if (_pingers != null)
                {
                    PingerEntry[] pingers = _pingers;
                    foreach (PingerEntry pingerEntry in pingers)
                    {
                        pingerEntry._ping.PingCompleted -= pinger_PingCompleted;
                    }
                }
                _pingers = new PingerEntry[_concurrentPings];
                for (int num = _concurrentPings - 1; num >= 0; num--)
                {
                    _pingers[num] = new PingerEntry();
                    _pingers[num]._ping.PingCompleted += pinger_PingCompleted;
                }
                _range = range;
                _active = true;
                _stopEvent.Reset();
                RaiseOnStartScan();
                Thread thread = new Thread(Restart);
                thread.Start();
            }
        }

        public void Stop(bool wait)
        {
            lock (_runControlLock)
            {
                if (_active)
                {
                    _active = false;
                    if (wait)
                    {
                        _stopEvent.WaitOne();
                    }
                }
            }
        }

        public void Wait()
        {
            _stopEvent.WaitOne();
        }

        private void Restart()
        {
            lock (_resultsLock)
            {
                _lastUpdate = 0uL;
                _nextToScan = _range.Start;
                PingerEntry[] pingers = _pingers;
                foreach (PingerEntry pinger in pingers)
                {
                    if (!StartNext(pinger))
                    {
                        break;
                    }
                }
            }
        }

        private bool StartNext(PingerEntry pinger)
        {
            if (_nextToScan == null)
            {
                return false;
            }
            if (_aliveHosts.ContainsKey(_nextToScan))
            {
                IPScanHostState iPScanHostState = _aliveHosts[_nextToScan];
                iPScanHostState.Prepare();
                pinger._results = iPScanHostState;
            }
            else
            {
                pinger._results = new IPScanHostState(_nextToScan, _pingsPerScan, _timeout);
            }
            RaiseOnScanProgressUpdate(_nextToScan);
            _nextToScan = _range.GetNext(_nextToScan);
            _activePings++;
            pinger._ping.SendAsync(pinger._results.Address, _timeout, _pingBuffer, _pingOptions, pinger);
            return true;
        }

        private void CheckRunning()
        {
            if (_active)
            {
                Stop(false);
            }
        }

        private void pinger_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            PingerEntry pingerEntry = (PingerEntry)e.UserState;
            IPScanHostState results = pingerEntry._results;
            bool flag = false;
            results.StorePingResult((e.Reply.Status == IPStatus.Success) ? e.Reply.RoundtripTime : (-1), e.Reply.Address);
            lock (_resultsLock)
            {
                if (!results.IsTesting())
                {
                    if (results.IsAlive())
                    {
                        flag = !_aliveHosts.ContainsKey(results.Address);
                        if (flag)
                        {
                            _aliveHosts.Add(results.Address, results);
                        }
                    }
                    else
                    {
                        _aliveHosts.Remove(results.Address);
                    }
                    _activePings--;
                    if (!_active)
                    {
                        if (_activePings == 0)
                        {
                            _stopEvent.Set();
                            RaiseOnStopScan();
                        }
                    }
                    else if (_nextToScan == null)
                    {
                        if (_activePings == 0)
                        {
                            if (_continuousScan)
                            {
                                RaiseOnRestartScan();
                                Restart();
                            }
                            else
                            {
                                _active = false;
                                _stopEvent.Set();
                                RaiseOnStopScan();
                            }
                        }
                    }
                    else
                    {
                        StartNext(pingerEntry);
                    }
                }
                else
                {
                    pingerEntry._ping.SendAsync(pingerEntry._results.Address, _timeout, _pingBuffer, _pingOptions, pingerEntry);
                }
            }
            if (flag)
            {
                RaiseOnAliveHostFound(results);
            }
        }
    }
}
