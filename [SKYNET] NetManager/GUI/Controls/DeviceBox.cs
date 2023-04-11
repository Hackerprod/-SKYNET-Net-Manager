using SKYNET.Helpers;
using SKYNET.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class DeviceBox : UserControl
    {
        public event EventHandler OnInfoUpdated;
        public DeviceStats DeviceStats;
        public PingHelper  PingHelper;
        public List<int> PingHistory;
        public string MAC;
        public string Ping;
        public string OpcionalLocation;
        public bool AlertOnConnect;
        public bool AlertOnDisconnect;

        private Device _Device;
        private bool _circularAvatar;
        private bool _ExternalImage;
        private bool _AvatarRequested;


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

                PingHelper.Initialize(value, this);

                OpcionalLocation = _Device.OpcionalLocation;
                CircularImage = _Device.CircularImage;

                LB_Name.Text = _Device.Name;
                LB_IPAddress.Text = _Device.IPAddress == null ? "" : _Device.IPAddress;

                if (DeviceManager.GetDeviceImage(_Device, out var image))
                {
                    SetImage(image);
                    _ExternalImage = true;
                }
            }
        }

        private async Task RequestAvatar()
        {
            if (_Device.IPAddress == null) return;

            var ImageDownloaded = await Common.GetDeviceImage($"http://{_Device.IPAddress}:28082/Avatar");
            if (ImageDownloaded != null)
            {
                _ExternalImage = false;
                SetImage(ImageDownloaded);
                _ExternalImage = true;
                return;
            }
        }

        public DeviceBox()
        {
            InitializeComponent();

            PingHelper = new PingHelper();
            PingHelper.OnPingSuccess += PingHelper_OnPingSuccess;
            PingHelper.OnPingFailed += PingHelper_OnPingFailed;

            _ExternalImage = false;

            PingHistory = new List<int>();
        }

        private void PingHelper_OnPingFailed(object sender, long RoundtripTime)
        {
            Status = ConnectionStatus.Offline;

            DeviceStats?.PingLost();

            PingHistory.Add(200);
            if (PingHistory.Count > 30)
            {
                PingHistory.RemoveAt(30);
            }

            if (AlertOnDisconnect)
            {
                new Thread(() =>
                {
                    frmAlert alerta = new frmAlert(this);
                    alerta.ShowDialog();
                }
                ).Start();
            }

            OnInfoUpdated?.Invoke(null, null);
        }

        private async void PingHelper_OnPingSuccess(object sender, long RoundtripTime)
        {
            Ping = RoundtripTime + " ms";
            Status = ConnectionStatus.Online;

            DeviceStats?.PingSuccess(RoundtripTime);

            PingHistory.Add((int)RoundtripTime);
            if (PingHistory.Count > 30)
            {
                PingHistory.RemoveAt(30);
            }

            if (AlertOnConnect)
            {
                new Thread(() =>
                {
                    frmAlert alerta = new frmAlert(this);
                    alerta.ShowDialog();
                }).Start();
            }

            OnInfoUpdated?.Invoke(null, null);

            if (!_AvatarRequested)
            {
                await RequestAvatar();
                _AvatarRequested = true;
            }

            if (string.IsNullOrEmpty(MAC))
            {
                MAC = await NetHelper.GetMACAddress(Device.IPAddress.ToIPAddress());
            }
        }

        public ConnectionStatus Status
        {
            get
            {
                return DeviceStats.CurrentStatus;
            }
            set
            {
                if (DeviceStats != null)
                {
                    if (DeviceStats.CurrentStatus != value)
                    {
                        DeviceStats.StatusChanged(value);
                    }
                    DeviceStats.CurrentStatus = value;
                }

                if (value == ConnectionStatus.Online)
                {
                    try
                    {
                        this.StatusICON.Image = Properties.Resources.online;
                        StatusPNL.BackColor = Color.FromArgb(7, 164, 245);
                        SetImage(Properties.Resources.OnlinePC);
                        status.Text = value.ToString() + " " + Ping;
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

        public bool CircularImage
        {
            get
            {
                return _circularAvatar;
            }
            set
            {
                _circularAvatar = value;

                try
                {
                    if (_circularAvatar)
                    {
                        PB_Image.Image = ImageHelper.CropToCircle(Image);
                    }
                    else
                    {
                        PB_Image.Image = Image;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void SetImage(Image image)
        {
            if (_ExternalImage) return;

            Image = image;

            if (CircularImage)
            {
                InvokeAction(PB_Image, delegate { PB_Image.Image = ImageHelper.CropToCircle(image); });
            }
            else
            {
                InvokeAction(PB_Image, delegate { PB_Image.Image = image; });
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

        public static void InvokeAction(Control control, Action Action)
        {
            control.Invoke(Action);
        }
    }
}
