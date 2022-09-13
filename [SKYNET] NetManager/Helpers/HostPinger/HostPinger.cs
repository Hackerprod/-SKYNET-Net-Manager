using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Xml;
using System.Net.Sockets;
using SKYNET.Helpers;

namespace SKYNET.NetUtils
{
    public class HostPinger
    {
        DeviceBox device;

        private class OnHostStatusChangeParams
        {
            public ConnectionStatus _oldState;

            public ConnectionStatus _newState;

            public OnHostStatusChangeParams(ConnectionStatus oldStatus, ConnectionStatus newStatus)
            {
                _oldState = oldStatus;
                _newState = newStatus;
            }
        }

        public delegate void AdditionalSettingsSave(XmlWriter writer);

        public const int NUMBER_OF_STATUSES = 4;

        private int _id;

        private static object _idLock = new object();

        private static int _nextID;

        private string _hostDescription = string.Empty;

        private ConnectionStatus _status { get; set; }

        private int _continousPacketLost;

        private int _sentPackets { get; set; }

        private int _receivedPackets { get; set; }

        private int _lostPackets { get; set; }

        private bool _lastPacketLost { get; set; }

        private int _consecutivePacketsLost { get; set; }

        private int _maxConsecutivePacketsLost { get; set; }

        private long _currentResponseTime { get; set; }

        private long _totalResponseTime { get; set; }

        private long _minResponseTime { get; set; }  = 9223372036854775807L;

        private long _maxResponseTime { get; set; }

        private DateTime _statusReachedAt = DateTime.Now;

        private TimeSpan[] _statusDurations = new TimeSpan[4];

        private DateTime _startTime = DateTime.Now;

        private TimeSpan _totalTestDuration;

        public static readonly int DEFAULT_TTL = 32;

        private int _ttl = DEFAULT_TTL;

        public static readonly bool DEFALUT_FRAGMENT = false;

        private bool _dontFragment;


        public static int BUFFER_SIZE = 32;

        public static readonly int DEFAULT_TIMEOUT = 2000;

        private int _timeout = DEFAULT_TIMEOUT;

        public static readonly int DEFAULT_DNS_QUERY_INTERVAL = 60000;

        private int _dnsQueryInterval = DEFAULT_DNS_QUERY_INTERVAL;

        private byte[] _buffer = new byte[BUFFER_SIZE];

        private System.Timers.Timer _timer = new System.Timers.Timer();

        private Ping _pinger = new Ping();

        private PingOptions _pingerOptions = new PingOptions(DEFAULT_TTL, DEFALUT_FRAGMENT);

        private PingResultsBuffer _recentHistory = new PingResultsBuffer();

        private IPingLogger _logger;

        private bool _isRunning;

        private bool _pingScheduled;

        public int ID => _id;

        public IPAddress HostIP { get; set; }

        public string HostName { get; set; }

        public string HostDescription
        {
            get
            {
                return _hostDescription;
            }
            set
            {
                _hostDescription = value;
            }
        }

        public ConnectionStatus Status
        {
            get
            {
                return _isRunning ? _status : ConnectionStatus.Offline;
            }
            private set
            {
                if (_status != value)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan timeSpan = now - _statusReachedAt;
                    if (_isRunning)
                    {
                        _statusDurations[(int)_status] += timeSpan;
                    }
                    _statusReachedAt = now;
                    ConnectionStatus status = _status;
                    _status = value;
                    ThreadPool.QueueUserWorkItem(RaiseOnStatusChange, new OnHostStatusChangeParams(status, _status));
                }
            }
        }

        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case ConnectionStatus.Offline:
                        return "Dead";
                    case ConnectionStatus.Online:
                        return "Alive";
                    default:
                        return "Unknown";
                }
            }
        }

        public int SentPackets
        {
            get
            {
                return _sentPackets;
            }
        }

        public int ReceivedPackets
        {
            get
            {
                return _receivedPackets;
            }
        }

        public float ReceivedPacketsPercent
        {
            get
            {
                return (float)_receivedPackets / (float)_sentPackets * 100f;
            }
        }

        public int LostPackets
        {
            get
            {
                return _lostPackets;
            }
        }

        public float LostPacketsPercent
        {
            get
            {
                return (float)_lostPackets / (float)_sentPackets * 100f;
            }
        }

        public bool LastPacketLost
        {
            get
            {
                return _lastPacketLost;
            }
        }

        public int ConsecutivePacketsLost
        {
            get
            {
                return _consecutivePacketsLost;
            }
        }

        public int MaxConsecutivePacketsLost
        {
            get
            {
                return _maxConsecutivePacketsLost;
            }
        }

        public int RecentlyReceivedPackets
        {
            get
            {
                return _recentHistory.ReceivedCount;
            }
        }

        public float RecentlyReceivedPacketsPercent
        {
            get
            {
                return _recentHistory.ReceivedCountPercent;
            }
        }

        public int RecentlyLostPackets
        {
            get
            {
                return _recentHistory.LostCount;
            }
        }

        public float RecentlyLostPacketsPercent
        {
            get
            {
                return _recentHistory.LostCountPercent;
            }
        }

        public long CurrentResponseTime
        {
            get
            {
                return _currentResponseTime;
            }
        }

        public float AverageResponseTime
        {
            get
            {
                return (_receivedPackets != 0) ? ((float)_totalResponseTime / (float)_receivedPackets) : 0f;
            }
        }

        public long MinResponseTime
        {
            get
            {
                return _minResponseTime;
            }
        }

        public long MaxResponseTime
        {
            get
            {
                return _maxResponseTime;
            }
        }

        public TimeSpan CurrentStatusDuration
        {
            get
            {
                return DateTime.Now.Subtract(_statusReachedAt);
            }
        }

        public float HostAvailability
        {
            get
            {
                long num = _totalTestDuration.Ticks;
                long num2 = _statusDurations[1].Ticks;
                if (_isRunning)
                {
                    DateTime now = DateTime.Now;
                    num += now.Subtract(_startTime).Ticks;
                    if (_status == ConnectionStatus.Online)
                    {
                        num2 += (now - _statusReachedAt).Ticks;
                    }
                }
                return (float)((double)num2 / (double)num * 100.0);
            }
        }

        public TimeSpan CurrentTestDuration
        {
            get
            {
                return _isRunning ? DateTime.Now.Subtract(_startTime) : new TimeSpan(0L);
            }
        }

        public TimeSpan TotalTestDuration
        {
            get
            {
                return _isRunning ? (_totalTestDuration + DateTime.Now.Subtract(_startTime)) : _totalTestDuration;
            }
        }

        public int TTL
        {
            get
            {
                {
                    return _ttl;
                }
            }
            set
            {

                {
                    if (value > 0 && value != _ttl)
                    {
                        _ttl = value;
                        _pingerOptions.Ttl = value;
                    }
                }
            }
        }

        public bool DontFragment
        {
            get
            {
                return _dontFragment;
            }
            set
            {
                if (value != _dontFragment)
                {
                    _dontFragment = value;
                    _pingerOptions.DontFragment = value;
                }
            }
        }

        public int BufferSize
        {
            get
            {

                return BUFFER_SIZE;
            }
            set
            {

                if (value > 0)
                {
                    BUFFER_SIZE = value;
                    _buffer = new byte[value];
                }
            }
        }

        public int Timeout
        {
            get
            {

                {
                    return _timeout;
                }
            }
            set
            {

                {
                    _timeout = value;
                }
            }
        }

        public int DnsQueryInterval
        {
            get
            {

                {
                    return _dnsQueryInterval;
                }
            }
            set
            {

                {
                    _dnsQueryInterval = value;
                }
            }
        }

        public int RecentHisoryDepth
        {
            get
            {

                {
                    return _recentHistory.BufferSize;
                }
            }
            set
            {

                {
                    _recentHistory.BufferSize = value;
                }
            }
        }

        public IPingLogger Logger
        {
            get
            {

                {
                    return _logger;
                }
            }
            set
            {

                {
                    _logger = value;
                }
            }
        }

        public IPAddress RemoteAddress { get; set; }
        public bool IsRunning
        {
            get
            {

                {
                    return _isRunning;
                }
            }
            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }

        public long RoundtripTime { get; private set; }

        public event OnPingDelegate OnPing;

        public event OnHostPingerCommandDelegate OnStartPinging;

        public event OnHostPingerCommandDelegate OnStopPinging;

        public event OnHostNameChangedDelegate OnHostNameChanged;

        private void AssignID()
        {
            lock (_idLock)
            {
                _id = _nextID++;
            }
        }

        private static void UpdateIDTrack(int id)
        {
            lock (_idLock)
            {
                if (_nextID <= id)
                {
                    _nextID = id + 1;
                }
            }
        }

        public TimeSpan GetStatusDuration(ConnectionStatus status)
        {
            TimeSpan timeSpan = _statusDurations[(int)status];
            if (_status == status && _isRunning)
            {
                timeSpan += DateTime.Now - _statusReachedAt;
            }
            return timeSpan;
        }

        private void IncluyeLost()
        {
            _sentPackets++;
            _lostPackets++;
            _consecutivePacketsLost++;
            _lastPacketLost = true;
            if (_consecutivePacketsLost > _maxConsecutivePacketsLost)
            {
                _maxConsecutivePacketsLost = _consecutivePacketsLost;
            }
            _recentHistory.AddPingResult(received: false);

            Status = ConnectionStatus.Offline;
        }

        private void IncluyeReceived(long time)
        {
            RoundtripTime = time;

            _sentPackets++;
            _receivedPackets++;
            _consecutivePacketsLost = 0;
            _lastPacketLost = false;
            _recentHistory.AddPingResult(received: true);
            _totalResponseTime += time;
            _currentResponseTime = time;
            if (time > _maxResponseTime)
            {
                _maxResponseTime = time;
            }
            if (time < _minResponseTime)
            {
                _minResponseTime = time;
            }
            _continousPacketLost = 0;
            if (_status != ConnectionStatus.Online)
            {
                Status = ConnectionStatus.Online;
            }
        }

        public void ClearStatistics(bool clearTimes)
        {

            {
                _sentPackets = 0;
                _receivedPackets = 0;
                _lostPackets = 0;
                _currentResponseTime = 0L;
                _totalResponseTime = 0L;
                _minResponseTime = 9223372036854775807L;
                _maxResponseTime = 0L;
                _continousPacketLost = 0;
                _consecutivePacketsLost = 0;
                _maxConsecutivePacketsLost = 0;
                _lastPacketLost = false;
                _recentHistory.Clear();
                if (clearTimes)
                {
                    _statusReachedAt = DateTime.Now;
                    _startTime = DateTime.Now;
                    for (int num = _statusDurations.Length - 1; num >= 0; num--)
                    {
                        _statusDurations[num] = new TimeSpan(0L);
                    }
                }
            }
        }

        private void RaiseOnPing()
        {
            if (this.OnPing != null)
            {
                this.OnPing(this);
            }
        }

        private void RaiseOnStatusChange(object param)
        {
            OnHostStatusChangeParams onHostStatusChangeParams = (OnHostStatusChangeParams)param;
        }

        private void RaiseOnStartPinging()
        {
            if (_logger != null)
            {
                _logger.LogStart(this);
            }
            if (this.OnStartPinging != null)
            {
                this.OnStartPinging(this);
            }
        }

        private void RaiseOnStopPinging()
        {
            if (_logger != null)
            {
                _logger.LogStop(this);
            }
            if (this.OnStopPinging != null)
            {
                this.OnStopPinging(this);
            }
        }

        private void RaiseOnHostNameChanged()
        {
            if (this.OnHostNameChanged != null)
            {
                this.OnHostNameChanged(this);
            }
        }

        public HostPinger(DeviceBox boxTool)
        {
            AssignID();

            device = boxTool;

            HostName = device.Device.IPAddress.ToString();

            if (!NetHelper.IsValidIp(HostName))
            {
                return;
            }

            HostIP = IPAddress.Parse(HostName);
            HostDescription = device.Device.Name;
            Timeout = 2000;
            DnsQueryInterval = 60000;
            BufferSize = 32;
            RecentHisoryDepth = 100;
            TTL = 32;
            DontFragment = false;

            InitTimer();
        }

        public HostPinger(IPAddress address)
        {
            AssignID();
            HostIP = address;
            InitTimer();
        }

        public HostPinger(string hostName, IPAddress address)
        {
            AssignID();
            HostIP = address;
            InitTimer();
        }

        private IPAddress GetHostIpByName(string name)
        {
            IPHostEntry hostEntry;
            try
            {
                hostEntry = Dns.GetHostEntry(HostName);
            }
            catch (Exception innerException)
            {
                throw new Exception("Error connecting DNS for " + HostName + " host", innerException);
            }
            if (hostEntry != null)
            {
                return hostEntry.AddressList[0];
            }
            throw new Exception("Cannot resolve host \"" + HostName + "\" IP by its name.");
        }

        private void InitTimer()
        {
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Pinger();
        }

        public void Start()
        {
            bool flag = false;
            if (!_isRunning)
            {
                _startTime = DateTime.Now;

                Status = ConnectionStatus.Offline;

                flag = (_isRunning = true);
                if (!_pingScheduled)
                {
                    _pingScheduled = true;
                    _timer.Interval = (double)1000;
                    _timer.Start();
                }
            }
            if (flag)
            {
                RaiseOnStartPinging();
            }
        }

        public void Stop()
        {
            bool flag = false;

            {
                if (_isRunning)
                {
                    _continousPacketLost = 0;

                    _totalTestDuration += DateTime.Now - _startTime;
                    _isRunning = false;
                    flag = true;
                }
            }
            if (flag)
            {
                RaiseOnStopPinging();
            }
        }

        private void Pinger()
        {
            HostIP = device.Device.IPAddress.ToIPAddress();

            if (Common.IsCableConnected())
            {
                if (device.Device.TCP && device.Device.Port != 80)
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        DateTime SentDateTime = DateTime.Now;

                        socket.Connect(HostIP, device.Device.Port);

                        TimeSpan span = DateTime.Now - SentDateTime;
                        long RoundtripTime = span.Milliseconds;
                        //RemoteAddress = (socket.).AddressFamily;
                        IncluyeReceived(RoundtripTime);
                    }
                    catch
                    {
                        IncluyeLost();
                    }
                }
                else
                {
                    PingReply pingReply = _pinger.Send(HostIP, _timeout, _buffer, _pingerOptions);
                    {
                        if (_isRunning)
                        {
                            switch (pingReply.Status)
                            {
                                case IPStatus.Success:
                                    IncluyeReceived(pingReply.RoundtripTime);
                                    RemoteAddress = pingReply.Address;
                                    break;
                                default:
                                    IncluyeLost();
                                    break;
                            }
                            _pingScheduled = true;
                        }
                        _pingScheduled = false;
                    }
                }
            }
            else
            {
                IncluyeLost();
            }
            RaiseOnPing();

            _timer.Interval = (double)1000;
            _timer.Start();

        }
    }
}