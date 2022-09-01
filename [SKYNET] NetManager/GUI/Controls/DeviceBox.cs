using SKYNET.Properties;
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
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class DeviceBox : UserControl
    {
        public string HostName { get; set; }
        public bool AlertOnConnect { get; set; }
        public bool AlertOnDisconnect { get; set; }
        public bool CustomAvatar { get; set; }
        public string Port { get; set; }
        public string MAC { get; set; }
        private int Timeout { get; set; }
        PingOptions PingOption { get; set; }
        byte[] Buffer { get; set; }
        public bool Running { get; set; }

        public Dictionary<int, int> Values;

        private Device _Device;
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
                BoxName = _Device.Name;
                IpName = _Device.Ip;
                isWeb = _Device.TCP;
                Name = _Device.Orden.ToString();
                Port = _Device.Port.ToString();
                Interval = _Device.Interval;
                OpcionalLocation = _Device.OpcionalLocation;
                Status = ConnectionStatus.Offline;
                Orden = _Device.Orden;
                CircularAvatar = _Device.CircularAvatar;
            }
        }


        //Ping Manager
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private PingOptions _pingerOptions;
        private readonly Ping _pinger = new Ping();
        private readonly byte[] _buffer;

        //Ping History
        public int SentPackets { get { return _SentPackets; } set { _SentPackets = value; } }
        private int _SentPackets;
        public int ReceivedPackets { get { return _ReceivedPackets; } set { _ReceivedPackets = value; } }
        private int _ReceivedPackets;
        public int LostPackets { get { return _LostPackets; } set { _LostPackets = value; } }
        private int _LostPackets;
        public int ConsecutivePacketsLost { get { return _ConsecutivePacketsLost; } set { _ConsecutivePacketsLost = value; } }
        private int _ConsecutivePacketsLost;
        public bool LastPacketLost { get { return _LastPacketLost; } set { _LastPacketLost = value; } }
        private bool _LastPacketLost;


        public int ConsecutivePacketsLostReceived;
        public long CurrentResponseTime;
        public long MinResponseTime;
        public long MaxResponseTime;
        public long TotalResponseTime;
        public TimeSpan[] _statusDurations;
        public DateTime _statusReachedAt;

        public DateTime StartTime { get { return _startTime; } set { _startTime = value; } }
        private DateTime _startTime;

        public DeviceBox()
        {
            InitializeComponent();

            SentPackets = 0;
            ReceivedPackets = 0;
            LostPackets = 0;
            CurrentResponseTime = 0L;
            MinResponseTime = 9223372036854775807L;
            MaxResponseTime = 0L;
            ConsecutivePacketsLostReceived = 0;
            ConsecutivePacketsLost = 0;
            TotalResponseTime = 0L;
            _statusDurations = new TimeSpan[2];
            _statusReachedAt = DateTime.Now;

            Values = new Dictionary<int, int>();
            for (int i = 1; i < 31; i++)
            {
                Values.Add(i, 0);
            }

            if (frmMain.TTL == 0) frmMain.TTL = 32;
            _pingerOptions = new PingOptions(frmMain.TTL, false);
            _buffer = new byte[frmMain.BufferSize];

            InitTimer();
        }

        private ConnectionStatus _Status { get; set; }
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
                        this.StatusICON.Image = Resources.online;
                        StatusPNL.BackColor = Color.FromArgb(7, 164, 245);
                        if (!isWeb)
                            SetAvatar(Resources.OnlinePC);
                        status.Text = value.ToString() + " " + Ping;
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        this.StatusICON.Image = Resources.idlechat;
                        StatusPNL.BackColor = Color.FromArgb(245, 7, 41);
                        if (!isWeb)
                            SetAvatar(Resources.OfflinePC);

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
        public IPAddress RemoteAddress { get; set; }
        public int Interval { get { if (_interval == 0) return 1; else return _interval; } set { _interval = value; } }
        private int _interval;

        public string OpcionalLocation { get; set; }
        public bool CircularAvatar
        {
            get { return _circularAvatar; }
            set
            {
                _circularAvatar = value;
                if (_circularAvatar)
                {
                    if (CustomAvatar)
                    {
                        Avatar.Image = Common.CropToCircle(BoxImage);
                    }
                }
                else
                {
                    Avatar.Image = BoxImage;
                }
            }
        }
        bool _circularAvatar;

        private void InitTimer()
        {
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DoPing();
        }
        bool lol = false;
        private void DoPing()
        {
            IPAddress.TryParse(IpName, out IPAddress _HostIP);
            try
            {
                if (/*modCommon.IsCableConnected() && */Common.IsValidIp(IpName))
                {
                    int.TryParse(Port, out int PortPing);
                    lol = true;
                    if (isWeb && PortPing != 80)
                    {
                        IPEndPoint EndPoint = new IPEndPoint(_HostIP, PortPing);
                        Socket sockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            DateTime SentDateTime = DateTime.Now;

                            IAsyncResult asyncResult = sockets.BeginConnect(EndPoint, new AsyncCallback((IAsyncResult ar) => { try { ((Socket)ar.AsyncState).EndConnect(ar); } catch { } }), sockets);

                            if (asyncResult.AsyncWaitHandle.WaitOne(frmMain.Timeout, false))
                            {
                                TimeSpan span = DateTime.Now - SentDateTime;
                                long RoundtripTime = span.Milliseconds;
                                RemoteAddress = ((IPEndPoint)sockets.RemoteEndPoint).Address;
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

                        if (frmMain.TTL == 0) frmMain.TTL = 32;
                        _pingerOptions = new PingOptions(frmMain.TTL, false);

                        try
                        {
                            PingReply pingReply = _pinger.Send(IpName, frmMain.Timeout, _buffer, _pingerOptions);
                            {
                                switch (pingReply.Status)
                                {
                                    case IPStatus.Success:
                                        RemoteAddress = pingReply.Address;
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

            MAC = Common.GetMacAddress(RemoteAddress);
            Ping = RoundtripTime + " ms";
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

        public void SetAvatar(Image image, bool Custom = false)
        {
            if (Custom == true)
            {
                CustomAvatar = true;

                if (CircularAvatar)
                {
                    Avatar.Image = Common.CropToCircle(image);
                }
                else
                {
                    Avatar.Image = image;
                }
                BoxImage = image;
            }
            else
            {
                if (CustomAvatar == false)
                {
                    Avatar.Image = image;
                    BoxImage = image;
                }
            }
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

                            if (!isWeb)
                                Process.Start(@"\\" + IpName);
                            else
                            {
                                if (Port == "443")
                                    Process.Start("https://" + IpName + ":" + Port);

                                else
                                    Process.Start("http://" + IpName + ":" + Port);
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void Device_Load(object sender, EventArgs e)
        {
            Timeout = 2000;
            PingOption = new PingOptions(32, true);
            Buffer = new byte[4];

            string ImageFile = DeviceManager.GetAvatarFromOrden(Name);

            if (File.Exists(ImageFile))
            {
                BoxImage = DeviceManager.GetDeviceImage(this);
                SetAvatar(BoxImage, true);
            }

            if (Common.IsCableConnected())
            {
                string address = IpName;
                try
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        if (!Common.IsValidIp(address))
                            return;

                        IPAddress.TryParse(IpName, out IPAddress _HostIP);
                        int.TryParse(Port, out int PortPing);

                        if (isWeb && PortPing != 80)
                        {
                            IPEndPoint EndPoint = new IPEndPoint(_HostIP, PortPing);
                            Socket sockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            try
                            {
                                DateTime SentDateTime = DateTime.Now;

                                IAsyncResult asyncResult = sockets.BeginConnect(EndPoint, new AsyncCallback((IAsyncResult ar) => { try { ((Socket)ar.AsyncState).EndConnect(ar); } catch { } }), sockets);

                                if (asyncResult.AsyncWaitHandle.WaitOne(frmMain.Timeout, false))
                                {
                                    TimeSpan span = DateTime.Now - SentDateTime;

                                    long RoundtripTime = span.Milliseconds;
                                    Ping = RoundtripTime + " ms";

                                    RemoteAddress = ((IPEndPoint)sockets.RemoteEndPoint).Address;
                                    MAC = Common.GetMacAddress(RemoteAddress);

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
                                PingReply reply = new Ping().Send(address, Timeout, Buffer, PingOption);
                                if (reply.Status == IPStatus.Success)
                                {
                                    Ping = reply.RoundtripTime + " ms";
                                    Status = ConnectionStatus.Online;
                                    MAC = Common.GetMacAddress(reply.Address);
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

        public void ClearAlerts()
        {
            AlertOnDisconnect = false;
            AlertOnConnect = false;
        }

        private void Box_MouseLeave(object sender, EventArgs e)
        {
            name.ForeColor = Color.FromArgb(224, 224, 224);
            ip.ForeColor = Color.Silver;
            this.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            name.ForeColor = Color.White;
            ip.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(63, 74, 88);
            Cursor = Cursors.Default;
            frmMain.frm.menuBOX = this;

            //Mover Control
            /*if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
            }*/
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            if (Common.Hackerprod)
            {
                //modCommon.Show("Running: " + Running + " | status: " + Status);
            }
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
