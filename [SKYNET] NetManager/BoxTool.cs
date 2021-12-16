using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using NetUtils;
using SkynetManager;
using SkynetManager.Properties;
using Timer = System.Windows.Forms.Timer;

namespace SkynetManager
{
    public partial class BoxTool_Old : UserControl
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        private IContainer components;
        public PictureBox Avatar;
        private Label name;
        private Label status;
        private PictureBox StatusICON;
        private Panel StatusPNL;
        private Label ip;
        public string HostName { get; set; }
        public bool AlertOnConnect { get; set; }
        public bool AlertOnDisconnect { get; set; }
        public bool CustomAvatar { get; set; }
        public string Port { get; set; }
        public string MAC { get; internal set; }

        private int timeout;
        PingOptions pingOption;
        byte[] buffer;
        private Timer timer1;

        //TcpClient client;
        TCPClient.Client client;
        public bool Running { get; private set; }
        public PingHistory PingHistory { get; set; }

        public BoxTool_Old()
        {
            this.InitializeComponent();

            timeout = 2000;
            pingOption = new PingOptions(32, true);
            buffer = new byte[4];
            PingHistory = new PingHistory();
            client = new TCPClient.Client();

        }
        public void SetAvatar(Image image, bool Custom = false)
        {
            if (Custom == true)
            {
                if (frmMain.CircularAvatars)
                    Avatar.Image = modCommon.CropToCircle(image);
                else
                    Avatar.Image = image;
                CustomAvatar = true;
            }
            else
            {
                if (CustomAvatar == false)
                {
                    Avatar.Image = image;
                }
            }
            BoxImage = image;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));

            this.components = new System.ComponentModel.Container();
            this.name = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.StatusPNL = new System.Windows.Forms.Panel();
            this.StatusICON = new System.Windows.Forms.PictureBox();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI Symbol", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.name.Location = new System.Drawing.Point(37, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(34, 12);
            this.name.TabIndex = 1;
            this.name.Text = "Name";
            this.name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.name.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Segoe UI Symbol", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.ip.Location = new System.Drawing.Point(37, 13);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(41, 12);
            this.ip.TabIndex = 2;
            this.ip.Text = "127.0.0.1";
            this.ip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.ip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.ip.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.ip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI Symbol", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.status.Location = new System.Drawing.Point(48, 24);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(29, 11);
            this.status.TabIndex = 3;
            this.status.Text = "Online";
            this.status.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.status.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.status.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.status.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // StatusPNL
            // 
            this.StatusPNL.Location = new System.Drawing.Point(124, -4);
            this.StatusPNL.Name = "StatusPNL";
            this.StatusPNL.Size = new System.Drawing.Size(10, 60);
            this.StatusPNL.TabIndex = 5;
            this.StatusPNL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusPNL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            // 
            // StatusICON
            // 
            this.StatusICON.Location = new System.Drawing.Point(41, 27);
            this.StatusICON.Name = "StatusICON";
            this.StatusICON.Size = new System.Drawing.Size(7, 7);
            this.StatusICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StatusICON.TabIndex = 4;
            this.StatusICON.TabStop = false;
            this.StatusICON.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusICON.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.StatusICON.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(5, 5);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(28, 28);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            this.Avatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.Avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.Avatar.MouseCaptureChanged += new System.EventHandler(this.Avatar_MouseCaptureChanged);
            this.Avatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.Avatar.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.Avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.Avatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // BoxTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.StatusPNL);
            this.Controls.Add(this.StatusICON);
            this.Controls.Add(this.status);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Avatar);
            this.Name = "BoxTool";
            this.Size = new System.Drawing.Size(129, 39);
            this.Load += new System.EventHandler(this.BoxTool_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        private string _BoxName { get; set; }
        public string BoxName
        {
            get
            {
                return _BoxName;
            }
            set
            {
                _BoxName = value;
                name.Text = value;
            }
        }
       

        private bool _isWeb { get; set; }
        public bool isWeb
        {
            get
            {
                return _isWeb;
            }
            set
            {
                _isWeb = value;
                if (value == true)
                {
                    SetAvatar(Resources.glob_v2);
                }
                else
                {
                    SetAvatar(Resources.NeutralPC);
                }
            }
        }
        private string _IpName { get; set; }
        public string IpName
        {
            get
            {
                return _IpName;
            }
            set
            {
                _IpName = value;
                ip.Text = value;
            }
        }
        public string Ping { get; set; }
        private ConnectionStatus _Status { get; set; }
        public ConnectionStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
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

        public void Reload()
        {
            
        }

        private Image _BoxImage { get; set; }
        public Image BoxImage
        {
            get
            {
                return _BoxImage;
            }
            set
            {
                _BoxImage = value;
            }
        }

        private int _Orden { get; set; }
        public int Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }





        private void Box_MouseLeave(object sender, EventArgs e)
        {
            name.ForeColor = Color.FromArgb(147, 157, 160);
            ip.ForeColor = Color.FromArgb(147, 157, 160);
            this.BackColor = Color.FromArgb(43, 47, 48);
        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            name.ForeColor = Color.FromArgb(255, 255, 255);
            ip.ForeColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(57, 62, 63);

//            frmMain.frm.menuBOX = this;

            return;
            //Mover Control
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                VerifyPosition();
            }
        }



        private void Box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
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
            catch { }

        }


        private void BoxTool_Load(object sender, EventArgs e)
        {
            if (File.Exists(modCommon.CurrectDirectory + "/Data/Images/" + Name + ".png"))
            {
                SetAvatar(modCommon.ImageFromFile(modCommon.CurrectDirectory + "/Data/Images/" + Name + ".png"), true);
            }
            
            if (modCommon.IsCableConnected())
            {
                string address = IpName;
                try
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        if (!modCommon.IsValidIp(address))
                            return;

                        if (isWeb && !string.IsNullOrEmpty(Port) && Port != "80")
                        {
                            try
                            {
                                client.Connect(IPAddress.Parse(address), Convert.ToInt32(Port), out IPEndPoint ipEndPoint);
                                Status = ConnectionStatus.Online;

                                try { Ping = client.RoundtripTime + " ms";      } catch { }
                                try { MAC = GetMacAddress(ipEndPoint.Address);  } catch { }
                            }
                            catch (Exception)
                            {
                                Status = ConnectionStatus.Offline;
                            }

                        }
                        else
                        {
                            PingReply reply = new Ping().Send(address, timeout, buffer, pingOption);
                            if (reply.Status == IPStatus.Success)
                            {
                                Ping = reply.RoundtripTime + " ms";
                                Status = ConnectionStatus.Online;
                                MAC = GetMacAddress(reply.Address);
                            }
                            else
                            {
                                Status = ConnectionStatus.Offline;
                            }
                        }
                    }).Start();
                }
                catch { }
            }

//            HostPinger hostPinger = new HostPinger(this);
//            hostPinger.OnPing += OnHostPing;
//            hostPinger.Start();

        }

        private void hp_OnStopPinging(HostPinger host)
        {
            //modCommon.Show(host.StatusName);
        }

        private void OnHostPing(HostPinger host)
        {
            switch (host.Status)
            {
                case HostStatus.Offline:
                    Status = ConnectionStatus.Offline;

                    if (AlertOnDisconnect)
                    {
                        new Thread(() =>
                        {
//                            frmAlert alerta = new frmAlert(this);
//                            alerta.ShowDialog();
                        }
                        ).Start();
                    }
                    break;
                case HostStatus.Online:
                    MAC = GetMacAddress(host.RemoteAddress);
                    Ping = host.RoundtripTime + " ms";
                    Status = ConnectionStatus.Online;

                    if (AlertOnConnect)
                    {
                        new Thread(() =>
                        {
//                            frmAlert alerta = new frmAlert(this);
//                            alerta.ShowDialog();
                        }).Start();
                    }
                    break;
                default:
                    break;
            }
            UpdatePingHistory(host);
        }


        private string PercentToString(float percent)
        {
            return $"{percent / 100f:P}";
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
        private void UpdatePingHistory(HostPinger host)
        {
            PingHistory.IP = host.HostIP.ToString();
            PingHistory.HostName = host.HostName;
            PingHistory.HostDescription = host.HostDescription;
            PingHistory.Status = host.StatusName;
            PingHistory.SentPackets = host.SentPackets.ToString();
            PingHistory.ReceivedPackets = host.ReceivedPackets.ToString();
            PingHistory.ReceivedPacketsPercent = PercentToString(host.ReceivedPacketsPercent);
            PingHistory.LostPackets = host.LostPackets.ToString();
            PingHistory.LostPacketsPercent = PercentToString(host.LostPacketsPercent);
            PingHistory.LastPacketLost = (host.LastPacketLost ? "Yes" : "No");
            PingHistory.ConsecutivePacketsLost = host.ConsecutivePacketsLost.ToString();
            PingHistory.MaxConsecutivePacketsLost = host.MaxConsecutivePacketsLost.ToString();
            PingHistory.RecentlyReceivedPackets = host.RecentlyReceivedPackets.ToString();
            PingHistory.RecentlyReceivedPacketsPercent = PercentToString(host.RecentlyReceivedPacketsPercent);
            PingHistory.RecentlyLostPackets = host.RecentlyLostPackets.ToString();
            PingHistory.RecentlyLostPacketsPercent = PercentToString(host.RecentlyLostPacketsPercent);
            PingHistory.CurrentResponseTime = host.CurrentResponseTime.ToString();
            PingHistory.AverageResponseTime = host.AverageResponseTime.ToString("F");
            PingHistory.MinResponseTime = host.MinResponseTime.ToString();
            PingHistory.MaxResponseTime = host.MaxResponseTime.ToString();
            PingHistory.CurrentStatusDuration = DurationToString(host.CurrentStatusDuration);
            PingHistory.GetAliveDuration = DurationToString(host.GetStatusDuration(HostStatus.Online));
            PingHistory.GetDeadDuration = DurationToString(host.GetStatusDuration(HostStatus.Offline));
            PingHistory.HostAvailability = PercentToString(host.HostAvailability);
            PingHistory.TotalTestDuration = DurationToString(host.TotalTestDuration);
            PingHistory.CurrentTestDuration = DurationToString(host.CurrentTestDuration);

        }

        public void ClearAlerts()
        {
            AlertOnDisconnect = false;
            AlertOnConnect = false;
        }

        private string GetMacAddress(IPAddress address)
        {
            try
            {
                var destAddr = BitConverter.ToInt32(address.GetAddressBytes(), 0);
                var srcAddr = BitConverter.ToInt32(System.Net.IPAddress.Any.GetAddressBytes(), 0);
                var macAddress = new byte[6];
                var macAddrLen = macAddress.Length;
                var ret = SendArp(destAddr, srcAddr, macAddress, ref macAddrLen);
                if (ret != 0)
                {
                    return "";
                }
                var mac = new PhysicalAddress(macAddress);
                return BitConverter.ToString(macAddress).Replace('-', ':');
            }
            catch (Exception)
            {
                return "";
            }

        }
        [System.Runtime.InteropServices.DllImport("Iphlpapi.dll", EntryPoint = "SendARP")]
        private extern static Int32 SendArp(Int32 destIpAddress, Int32 srcIpAddress, byte[] macAddress, ref Int32 macAddressLength);

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            //Opacity = 100;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void VerifyPosition()
        {
        }
        private void Box_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
//                    frmMain.ShowMenuInBox(this, e.X, e.Y);
                }
            }
            catch { }
            //modCommon.Show(Location.X + " " + Location.Y);
        }
        private void Avatar_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (Location.X > 3 && Location.X < 140)
            {
                Location = new Point(3, Location.Y);
            }
            else if (Location.X < 3)
            {
                Location = new Point(3, Location.Y);
            }
            else if (Location.X > 141)
            {
                Location = new Point(162, Location.Y);
            }


            //this.SetTopLevel(true);
            //Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

        }





    }
}
