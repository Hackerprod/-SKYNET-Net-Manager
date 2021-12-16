using NetUtils;
using SkynetManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkynetManager
{
    public partial class Device : UserControl
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public string HostName { get; set; }
        public bool AlertOnConnect { get; set; }
        public bool AlertOnDisconnect { get; set; }
        public bool CustomAvatar { get; set; }
        public string Port { get; set; }
        public string MAC { get; set; }
        private int timeout { get; set; }
        PingOptions pingOption { get; set; }
        byte[] buffer { get; set; }
        TCPClient.Client client { get; set; }
        public bool Running { get; set; }
        public PingHistory PingHistory { get; set; }

        public Device()
        {
            InitializeComponent();
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
            //modCommon.Show(Location.X + " " + Location.Y);
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
        private void Device_Load(object sender, EventArgs e)
        {
            timeout = 2000;
            pingOption = new PingOptions(32, true);
            buffer = new byte[4];
            PingHistory = new PingHistory();
            client = new TCPClient.Client();

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

                                try { Ping = client.RoundtripTime + " ms"; } catch { }
                                try { MAC = modCommon.GetMacAddress(ipEndPoint.Address); } catch { }
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
                                MAC = modCommon.GetMacAddress(reply.Address);
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

            HostPinger hostPinger = new HostPinger(this);
            hostPinger.OnPing += OnHostPing;
            hostPinger.Start();

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
                            frmAlert alerta = new frmAlert(this);
                            alerta.ShowDialog();
                        }
                        ).Start();
                    }
                    break;
                case HostStatus.Online:
                    MAC = modCommon.GetMacAddress(host.RemoteAddress);
                    Ping = host.RoundtripTime + " ms";
                    Status = ConnectionStatus.Online;

                    if (AlertOnConnect)
                    {
                        new Thread(() =>
                        {
                            frmAlert alerta = new frmAlert(this);
                            alerta.ShowDialog();
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

            frmMain.frm.menuBOX = this;

            return;
            //Mover Control
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                VerifyPosition();
            }
        }
        private void VerifyPosition()
        {
        }

        public void Reload()
        {

        }
    }
}
