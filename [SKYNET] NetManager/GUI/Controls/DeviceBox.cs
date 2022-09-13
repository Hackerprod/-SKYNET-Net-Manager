using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class DeviceBox : UserControl
    {
        private int              _Interval;
        private Device           _Device;
        private DateTime         _StartTime;
        public TimeSpan[]        _statusDurations;
        public DateTime          _statusReachedAt;
        private int              _SentPackets;
        private int              _ReceivedPackets;
        private int              _LostPackets;
        private int              _ConsecutivePacketsLost;
        private bool             _LastPacketLost;
        private int              _ConsecutivePacketsLostReceived;
        private bool             _circularAvatar;
        private ConnectionStatus _Status;
        private int              _Orden;
        private int              _Timeout;
        private bool             _ImageFromFile;

        public string _Ping;

        public Image Image
        {
            get
            {
                return PB_Image.Image;
            }
            set
            {
                PB_Image.Image = value;
            }
        }

        public int Interval
        {
            get
            {
                if (_Interval == 0)
                    return 1;
                else
                    return _Interval;
            }
            set
            {
                _Interval = value;
            }
        }


        //Ping Manager
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private PingOptions _pingerOptions;
        private readonly Ping _pinger = new Ping();
        private readonly byte[] _buffer;

        //Ping History
        public int SentPackets { get { return _SentPackets; } set { _SentPackets = value; } }
        public int ReceivedPackets { get { return _ReceivedPackets; } set { _ReceivedPackets = value; } }
        public int LostPackets { get { return _LostPackets; } set { _LostPackets = value; } }
        public int ConsecutivePacketsLost { get { return _ConsecutivePacketsLost; } set { _ConsecutivePacketsLost = value; } }
        public bool LastPacketLost { get { return _LastPacketLost; } set { _LastPacketLost = value; } }

        //DeviceInfo
        public long CurrentResponseTime { get; set; }
        public long TotalResponseTime { get; set; }
        public long MinResponseTime { get; set; }
        public long MaxResponseTime { get; set; }

        public DateTime StartTime { get { return _StartTime; } set { _StartTime = value; } }

        public string OpcionalLocation { get; set; }
        public string HostName { get; set; }
        public bool AlertOnConnect { get; set; }
        public bool AlertOnDisconnect { get; set; }
        public string MAC { get; set; }
        PingOptions PingOption { get; set; }
        byte[] Buffer { get; set; }
        public bool Running { get; set; }

        public Dictionary<int, int> Values;

        public Device Device 
        { 
            get { return _Device; } 
            set 
            {
                _Device = value;

                if (_Device == null)
                {
                    return;
                }

                Interval = _Device.Interval;
                OpcionalLocation = _Device.OpcionalLocation;
                CircularImage = _Device.CircularImage;
                
                LB_Name.Text = _Device.Name;
                LB_IPAddress.Text = _Device.IPAddress;

                if (DeviceManager.GetDeviceImage(_Device, out var image))
                {
                    SetImage(image);
                    _ImageFromFile = true;
                }
            }
        }

        public DeviceBox()
        {
            InitializeComponent();

            SentPackets = 0;
            ReceivedPackets = 0;
            LostPackets = 0;
            CurrentResponseTime = 0L;
            MinResponseTime = 9223372036854775807L;
            MaxResponseTime = 0L;
            _ConsecutivePacketsLostReceived = 0;
            ConsecutivePacketsLost = 0;
            TotalResponseTime = 0L;
            _statusDurations = new TimeSpan[2];
            _statusReachedAt = DateTime.Now;

            _ImageFromFile = false;
            Values = new Dictionary<int, int>();
            for (int i = 1; i < 31; i++)
            {
                Values.Add(i, 0);
            }

            if (Settings.TTL == 0) Settings.TTL = 32;
            _pingerOptions = new PingOptions(Settings.TTL, false);
            _buffer = new byte[Settings.BufferSize];

            InitTimer();
        }

        private void Device_Load(object sender, EventArgs e)
        {
            _Timeout = 2000;
            PingOption = new PingOptions(32, true);
            Buffer = new byte[4];

            if (Common.IsCableConnected())
            {
                try
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        if (Device.IPAddress == null)
                            return;

                        if (Device.TCP && Device.Port != 80)
                        {
                            IPEndPoint EndPoint = new IPEndPoint(Device.IPAddress.ToIPAddress(), Device.Port);
                            Socket sockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            try
                            {
                                DateTime SentDateTime = DateTime.Now;

                                IAsyncResult asyncResult = sockets.BeginConnect(EndPoint, new AsyncCallback((IAsyncResult ar) => { try { ((Socket)ar.AsyncState).EndConnect(ar); } catch { } }), sockets);

                                if (asyncResult.AsyncWaitHandle.WaitOne(Settings.Timeout, false))
                                {
                                    TimeSpan span = DateTime.Now - SentDateTime;

                                    long RoundtripTime = span.Milliseconds;
                                    _Ping = RoundtripTime + " ms";

                                    MAC = NetHelper.GetMACAddress(((IPEndPoint)sockets.RemoteEndPoint).Address);

                                    Status = ConnectionStatus.Online;
                                    sockets.Close();
                                }
                                else
                                {
                                    sockets.Close();
                                    Status = ConnectionStatus.Offline;
                                }

                            }
                            catch
                            {
                                Status = ConnectionStatus.Offline;
                            }
                        }
                        else
                        {
                            try
                            {
                                PingReply reply = new Ping().Send(Device.IPAddress, _Timeout, Buffer, PingOption);
                                if (reply.Status == IPStatus.Success)
                                {
                                    _Ping = reply.RoundtripTime + " ms";
                                    Status = ConnectionStatus.Online;
                                    MAC = NetHelper.GetMACAddress(reply.Address);
                                }
                                else
                                {
                                    Status = ConnectionStatus.Offline;
                                }
                            }
                            catch (Exception)
                            {
                                Status = ConnectionStatus.Offline;
                            }
                        }
                    }).Start();
                }
                catch { }
            }

            StartTime = DateTime.Now;
            this.Refresh();
            _timer.Interval = (double)Interval * 1000;
            _timer.Start();
        }


        public ConnectionStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (_Status != value)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan timeSpan = now - _statusReachedAt;
                    _statusDurations[(int)_Status] += timeSpan;
                    _statusReachedAt = now;
                }
                _Status = value;


                if (value == ConnectionStatus.Online)
                {
                    try
                    {
                        this.StatusICON.Image = Properties.Resources.online;
                        StatusPNL.BackColor = Color.FromArgb(7, 164, 245);
                        SetImage(Properties.Resources.OnlinePC);
                        status.Text = value.ToString() + " " + _Ping;
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        this.StatusICON.Image = Properties.Resources.idlechat;
                        StatusPNL.BackColor = Color.FromArgb(245, 7, 41);
                        SetImage(Properties.Resources.OfflinePC);

                        status.Text = value.ToString();
                    }
                    catch { }
                }
            }
        }

        public string OnlineStatusDuration
        {
            get { return DurationToString(GetStatusDuration(ConnectionStatus.Online)); }
        }

        public string OfflineStatusDuration
        {
            get { return DurationToString(GetStatusDuration(ConnectionStatus.Offline)); }
        }

        private string DurationToString(TimeSpan duration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (duration.Days > 0)
            {
                stringBuilder.Append(duration.Days);
                stringBuilder.Append((duration.Days > 1) ? " days " : " day ");
            }
            stringBuilder.AppendFormat("{0:d2} : {1:d2} : {2:d2}", duration.Hours, duration.Minutes, duration.Seconds);
            return stringBuilder.ToString();
        }

        public TimeSpan GetStatusDuration(ConnectionStatus status)
        {
            TimeSpan timeSpan = _statusDurations[(int)status];
            if (_Status == status)
            {
                timeSpan += DateTime.Now - _statusReachedAt;
            }
            return timeSpan;
        }

        public bool CircularImage
        {
            get { return _circularAvatar; }
            set
            {
                _circularAvatar = value;
                if (_circularAvatar)
                {
                    PB_Image.Image = Common.CropToCircle(Image);
                }
                else
                {
                    PB_Image.Image = Image;
                }
            }
        }

        private void InitTimer()
        {
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DoPing();
        }

        private void DoPing()
        {
            try
            {

                if (/*modCommon.IsCableConnected() && */ IPAddress.TryParse(Device.IPAddress, out var Address))
                {
                    if (Device.TCP && Device.Port != 80)
                    {
                        IPEndPoint EndPoint = new IPEndPoint(Address, Device.Port);
                        Socket sockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            DateTime SentDateTime = DateTime.Now;

                            IAsyncResult asyncResult = sockets.BeginConnect(EndPoint, new AsyncCallback((IAsyncResult ar) => { try { ((Socket)ar.AsyncState).EndConnect(ar); } catch { } }), sockets);

                            if (asyncResult.AsyncWaitHandle.WaitOne(Settings.Timeout, false))
                            {
                                TimeSpan span = DateTime.Now - SentDateTime;
                                long RoundtripTime = span.Milliseconds;
                                IncluyeReceived(RoundtripTime);
                                sockets.Close();
                            }
                            else
                            {
                                sockets.Close();
                                IncluyeLost();
                            }
                        }
                        catch
                        {
                            IncluyeLost();
                        }
                        Running = true;
                    }
                    else
                    {

                        if (Settings.TTL == 0) Settings.TTL = 32;
                        _pingerOptions = new PingOptions(Settings.TTL, false);

                        try
                        {
                            PingReply pingReply = _pinger.Send(Device.IPAddress, Settings.Timeout, _buffer, _pingerOptions);
                            {
                                switch (pingReply.Status)
                                {
                                    case IPStatus.Success:
                                        IncluyeReceived(pingReply.RoundtripTime);
                                        break;
                                    default:
                                        IncluyeLost();
                                        break;
                                }
                            }
                        }
                        catch
                        {
                            IncluyeLost();

                        }
                        Running = true;
                    }
                }
                else
                {
                    IncluyeLost();
                    Running = true;
                }
            }
            catch (Exception)
            {
                IncluyeLost();
            }
            _timer.Interval = (double)Interval * 1000;
            _timer.Start();
        }

        private void IncluyeLost()
        {

            Status = ConnectionStatus.Offline;
            if (AlertOnDisconnect)
            {
                new Thread(() =>
                {
                    frmAlert alerta = new frmAlert(this);
                    alerta.ShowDialog();
                }
                ).Start();
            }

            _SentPackets++;
            _LostPackets++;
            _ConsecutivePacketsLost++;
            _LastPacketLost = true;

            AddValue(200);
        }

        private void AddValue(int val)
        {
            Values[1] = Values[2];
            Values[2] = Values[3];
            Values[3] = Values[4];
            Values[4] = Values[5];
            Values[5] = Values[6];
            Values[6] = Values[7];
            Values[7] = Values[8];
            Values[8] = Values[9];
            Values[9] = Values[10];
            Values[10] = Values[11];
            Values[11] = Values[12];
            Values[12] = Values[13];
            Values[13] = Values[14];
            Values[14] = Values[15];
            Values[15] = Values[16];
            Values[16] = Values[17];
            Values[17] = Values[18];
            Values[18] = Values[19];
            Values[19] = Values[20];
            Values[20] = Values[21];
            Values[21] = Values[22];
            Values[22] = Values[23];
            Values[23] = Values[24];
            Values[24] = Values[25];
            Values[25] = Values[26];
            Values[26] = Values[27];
            Values[27] = Values[28];
            Values[28] = Values[29];
            Values[29] = Values[30];
            Values[30] = val;

        }

        private void IncluyeReceived(long RoundtripTime)
        {

            MAC = NetHelper.GetMACAddress(Device.IPAddress.ToIPAddress());
            _Ping = RoundtripTime + " ms";
            Status = ConnectionStatus.Online;

            if (AlertOnConnect)
            {
                new Thread(() =>
                {
                    frmAlert alerta = new frmAlert(this);
                    alerta.ShowDialog();
                }).Start();
            }

            long time = RoundtripTime;
            _SentPackets++;
            _ReceivedPackets++;
            _ConsecutivePacketsLost = 0;
            _LastPacketLost = false;
            TotalResponseTime += time;
            CurrentResponseTime = time;
            if (time > MaxResponseTime)
            {
                MaxResponseTime = time;
            }
            if (time < MinResponseTime)
            {
                MinResponseTime = time;
            }
            AddValue((int)time);
        }

        public void SetImage(Image image)
        {
            if (_ImageFromFile) return;

            if (CircularImage)
            {
                PB_Image.Image = Common.CropToCircle(image);
            }
            else
            {
                PB_Image.Image = image;
            }
            Image = image;
        }

        private void Box_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    frmMain.ShowMenuInBox(this, e.X, e.Y);
                }
            }
            catch { }
        }

        private void Box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!string.IsNullOrEmpty(OpcionalLocation))
                    {
                        Process.Start(OpcionalLocation);

                    }
                    else
                    {
                        if (Status == ConnectionStatus.Online)
                        {

                            if (!Device.TCP)
                                Process.Start(@"\\" + Device.IPAddress);
                            else
                            {
                                if (Device.Port == 443)
                                    Process.Start($"https://{Device.IPAddress}:{Device.Port}");
                                else
                                    Process.Start($"http://{Device.IPAddress}:{Device.Port}");
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public void ClearAlerts()
        {
            AlertOnDisconnect = false;
            AlertOnConnect = false;
        }

        private void Box_MouseLeave(object sender, EventArgs e)
        {
            LB_Name.ForeColor = Color.FromArgb(224, 224, 224);
            LB_IPAddress.ForeColor = Color.Silver;
            this.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            LB_Name.ForeColor = Color.White;
            LB_IPAddress.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(63, 74, 88);
            Cursor = Cursors.Default;
            frmMain.frm.menuBOX = this;
        }

        private void StatusICON_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void StatusICON_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
    }
}
