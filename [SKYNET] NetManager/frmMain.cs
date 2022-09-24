using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;
using System.IO;                   
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Timers;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Net;
using SKYNET.GUI;
using SKYNET.Helpers;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public static frmMain frm;
        public static bool ReceiveMessages;


        public bool Ready = false;
        public DeviceBox menuBOX;

        private KeyboardHook keyboardHook;
        private bool EmptyProfile = false;

        private long BytesSent = 0;
        private long BytesReceived = 0;
        private long SentxSecond = 0;
        private long ReceivedxSecond = 0;

        public frmMain()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;  
            frm = this;
            ReceiveMessages = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Settings.Load();
            Settings.SetHandle(Handle.ToInt64());

            if (EmptyProfile)
            {
                Settings.CurrentSection = "Device";
            }

            ChatManager.Initialize();

            LoadProfile(Settings.CurrentSection);

            PrepareButtomPanel();

            Common.EnsureDirectoryExists(Path.Combine(Common.GetPath(), "Data"));
            Common.EnsureDirectoryExists(Path.Combine(Common.GetPath(), "Data", "Images"));
            Common.EnsureDirectoryExists(Path.Combine(Common.GetPath(), "Data", "Devices"));

            string DataDirectory = Path.Combine(Common.GetPath(), "Data");

            if (!File.Exists(Path.Combine(DataDirectory, "Device.json")))
            {
                using (FileStream fileStream = new FileStream(Path.Combine(DataDirectory, "Device.json"), FileMode.OpenOrCreate)) { }
                EmptyProfile = true;
            }

            if (!File.Exists(Path.Combine(DataDirectory, "Images", "Default.jpg")))
            {
                Properties.Resources.Default.Save(Path.Combine(DataDirectory, "Images", "Default.jpg"));
            }

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();

            DeviceContainer.AutoScroll = true;
            DeviceContainer.VerticalScrollbar = true;

            TransparencyKey = this.BackColor;
            Maximize(false);
        }

        public void Maximize(bool inLeft)
        {
            Rectangle workingArea = Screen.FromHandle(base.Handle).WorkingArea;
            try
            {
                base.Location = new Point(workingArea.Width - Width, 0);
                Height = workingArea.Height;
            }
            catch
            {
            }
        }

        public void LoadProfile(string currentSection)
        {
            Settings.CurrentSection = currentSection;
            frm.CleanBoxControls();

            string json = "";

            string DataDirectory = Path.Combine(Common.GetPath(), "Data");

            if (File.Exists(Path.Combine(DataDirectory, currentSection + ".json")))
            {
                json = File.ReadAllText(Path.Combine(DataDirectory, currentSection + ".json"));
            }
            else
            {
                if (File.Exists(Path.Combine(DataDirectory, "Device.json")))
                {
                    json = File.ReadAllText(Path.Combine(DataDirectory, "Device.json"));
                }
            }

            List<Device> Devices = null;

            try
            {
                Devices = new JavaScriptSerializer().Deserialize<List<Device>>(json);
            }
            catch 
            {
                  
            }

            if (Devices == null)
            {
                Opacity = 100;
                Common.CloseSplash = true;
                return;
            }

            foreach (Device device in Devices)
            {
                AddBox(device);
            }

            ProfileSelected.Text = "Current profile: " + currentSection;
            Opacity = 100;
            Common.CloseSplash = true;
        }

        public void AddBox(Device device)
        {
            GetNextBoxLocation(out var X, out var Y);

            var deviceBox = new DeviceBox()
            {
                Location = new Point(X, Y),
                Device = device,
                DeviceStats = new Types.DeviceStats(device.IPAddress)
            };

            DeviceContainer.Controls.Add(deviceBox);

            TEST(deviceBox);
        }

        private void GetNextBoxLocation(out int X, out int Y)
        {
            X = 5;
            Y = 5;

            if (DeviceContainer.Controls.Count > 0)
            {
                var Control = DeviceContainer.Controls[DeviceContainer.Controls.Count - 1];
                if (Control is DeviceBox)
                {
                    if (Control.Location.X == 5)
                    {
                        X += 160;
                        Y = Control.Location.Y;
                    }
                    else
                    {
                        X = 5;
                        Y = Control.Location.Y + 49;
                    }
                }
            }
        }

        public void Write(object obj)
        {
            ProfileSelected.Text = obj.ToString();
        }
       
        public void SaveDevices()
        {
            List<Device> Devices = new List<Device>(); 
            for (int i = 0; i < DeviceContainer.Controls.Count; i++)
            {
                if (DeviceContainer.Controls[i] is DeviceBox)
                {
                    DeviceBox deviceBox = (DeviceBox)DeviceContainer.Controls[i];
                    Devices.Add(deviceBox.Device);
                }
            }

            string json = new JavaScriptSerializer().Serialize(Devices);           
            File.WriteAllText(Path.Combine(Common.GetPath(), "Data",  Settings.CurrentSection + ".json"), json);
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (key.ToString() == Settings.Key)
            {
                if (WindowState == FormWindowState.Maximized && WinMod.IsActiveMainWindow())
                {
                    SetVisible(false);
                    WindowState = FormWindowState.Minimized;
                    keyboardHook.Uninstall();
                    keyboardHook.Install();
                    return;
                }
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                    Activate();
                    SetVisible(true);
                }
                if (WindowState == FormWindowState.Normal && !WinMod.IsActiveMainWindow())
                {
                    Activate();
                    SetVisible(true);
                }
                keyboardHook.Uninstall();
                keyboardHook.Install();
            }
        }

        private void SetVisible(bool value)
        {
            Visible = value;
            Activate();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized || WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Normal;
                    SetVisible(true);
                }
                else
                {
                    SetVisible(false);
                    WindowState = FormWindowState.Minimized;
                }
            }
            
        }

        public static void ShowMenuInBox(DeviceBox box, int xx, int yy)
        {
            if (box.Status == ConnectionStatus.Online)
            {
                frm.explorarPCMenuItem.Visible = true;
                frm.hacerPingPorCMDMenuItem.Visible = true;
                frm.OnlineAlertMenuItem.Visible = false;
                frm.OfflineAlertMenuItem.Visible = true;
                frm.PuertosMenuItem.Visible = true;
                frm.enviarMensajeMenuItem.Visible = false;

                Rectangle cellDisplayRectangle = box.DisplayRectangle;
                frm.HerramientasMenuItem.Text = "Tools (" + box.Device.Name + ")";
                if (box.Device.TCP)
                    frm.explorarPCMenuItem.Text = "Explore web";
                else
                {
                    frm.explorarPCMenuItem.Text = "Explore PC";

                    VerifySocket(box);
                    //frm.enviarMensajeMenuItem.Visible = true;
                }
                frm.menuBOX = box;
                frm.BoxMenu.Show(box, cellDisplayRectangle.Left + xx, cellDisplayRectangle.Top + yy);
            }
            else
            {
                frm.explorarPCMenuItem.Visible = false;
                frm.hacerPingPorCMDMenuItem.Visible = true;
                frm.OnlineAlertMenuItem.Visible = true;
                frm.OfflineAlertMenuItem.Visible = false;
                frm.PuertosMenuItem.Visible = false;
                frm.enviarMensajeMenuItem.Visible = false;

                Rectangle cellDisplayRectangle = box.DisplayRectangle;
                frm.HerramientasMenuItem.Text = "Tools (" + box.Device.Name + ")";
                if (box.Device.TCP)
                    frm.explorarPCMenuItem.Text = "Explore web";
                else
                    frm.explorarPCMenuItem.Text = "Explore PC";
                frm.menuBOX = box;
                frm.BoxMenu.Show(box, cellDisplayRectangle.Left + xx, cellDisplayRectangle.Top + yy);
            }
        }

        private static void VerifySocket(DeviceBox box)
        {
            Task.Run(() =>
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://{box.Device.IPAddress}:28082/onPing");
                    httpWebRequest.Timeout = 500;
                    httpWebRequest.Method = "GET";
                    var Response = httpWebRequest.GetResponse();
                    frm.enviarMensajeMenuItem.Visible = true;
                }
                catch 
                {
                    frm.enviarMensajeMenuItem.Visible = false;
                }
            });
        }

        private void PingConstante_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            frmConsole console = new frmConsole(menuBOX, true);
            console.Show();
        }

        public void ShowManager(DeviceBox menuBOX = null)
        {
            frmDeviceManager manage = new frmDeviceManager(menuBOX);
            manage.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        public void ShowSettings()
        {
            frmSettings fSettings = new frmSettings();
            DialogResult result = fSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
                    try
                    {
                        if (Settings.LaunchWindowsStart)
                        {
                            registryKey.SetValue("[SKYNET] NetManager", Application.ExecutablePath.ToString());
                        }
                        else
                        {
                            registryKey.DeleteValue("[SKYNET] NetManager");
                        }
                    }
                    catch { }
                }
                catch { }

                Settings.Save();
            }
        }

        private void ByHackerprod_MouseLeave(object sender, EventArgs e)
        {
            byHackerprod.ForeColor = Color.FromArgb(147, 157, 160);
            //147; 157; 160
        }

        private void ByHackerprod_Click(object sender, EventArgs e)
        {
            new frmAbout().Show();
        }

        public void CleanBoxControls()
        {
            DeviceContainer.Invoke(new Action(() =>
            {
                DeviceContainer.Controls.Clear();
                DeviceContainer.Controls.Add(WelcomeBox);
            }));
        }

        private void PanelBottom_MouseMove(object sender, EventArgs e)
        {
            while (PanelBottom.Height < 50)
            {
                PanelBottom.Height++;
                ProfileSelected.Visible = false;
                byHackerprod.Visible = false;
            }

            if (PanelBottom.Height == 50)
            {
                panelSent.Visible = true;
                panelReceived.Visible = true;
                Sent.Visible = true;
                Received.Visible = true;
                SentPerSecond.Visible = true;
                ReceivedPerSecond.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
            }
        }

        private void PrepareButtomPanel()
        {
            PanelBottom.Height = 17;
            byHackerprod.Location = new Point(248, 0);
            ProfileSelected.Location = new Point(0, 0);
            PanelBottom.Controls.Add(PanelTransfer);
            PanelTransfer.Dock = DockStyle.Fill;
            PanelTransfer.MouseHover += PanelBottom_MouseMove;

            panelSent.Visible = false;
            panelReceived.Visible = false;
            Sent.Visible = false;
            Received.Visible = false;
            SentPerSecond.Visible = false;
            ReceivedPerSecond.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

        }

        private void TimerTransfer_Tick(object sender, EventArgs e)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return;

            NetworkInterface interfaces = NetworkInterface.GetAllNetworkInterfaces()[0];

            Sent.Text = Common.LongToMbytes(interfaces.GetIPv4Statistics().BytesSent);
            Received.Text = Common.LongToMbytes(interfaces.GetIPv4Statistics().BytesReceived);

            SentxSecond = interfaces.GetIPv4Statistics().BytesSent - BytesSent;
            ReceivedxSecond = interfaces.GetIPv4Statistics().BytesReceived - BytesReceived;

            SentPerSecond.Text = Common.LongToMbytes(SentxSecond) + "/Seconds";
            ReceivedPerSecond.Text = Common.LongToMbytes(ReceivedxSecond) + "/Seconds";

            BytesSent = interfaces.GetIPv4Statistics().BytesSent;
            BytesReceived = interfaces.GetIPv4Statistics().BytesReceived;
        }

        private void DeviceContainer_MouseLeave(object sender, EventArgs e)
        {
            while (PanelBottom.Height > 17)
            {
                PanelBottom.Height--;
            }

            if (PanelBottom.Height == 17)
            {
                ProfileSelected.Visible = true;
                byHackerprod.Visible = true;

                panelSent.Visible = false;
                panelReceived.Visible = false;
                Sent.Visible = false;
                Received.Visible = false;
                SentPerSecond.Visible = false;
                ReceivedPerSecond.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }

        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            int attrValue = 2;
            DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 4);
            DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
            mARGINS.cyBottomHeight = 1;
            mARGINS.cxLeftWidth = 0;
            mARGINS.cxRightWidth = 0;
            mARGINS.cyTopHeight = 0;
            DwmApi.MARGINS marInset = mARGINS;
            DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);

            Common.ShowShadow = false;
            shadow.Dock = DockStyle.None;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnActivated(e);

            if (Common.ShowShadow)
            {
                shadow.Dock = DockStyle.Fill;
            }
        }

        private void menu_AddDevice_Click(object sender, EventArgs e)
        {
            ShowManager();
        }

        private void menu_Profiles_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.ShowDialog();
        }

        private void menu_SearchDevice_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.Show();
        }

        private void menu_Settings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void MainMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            shadow.Dock = DockStyle.None;
        }

        private void cloneDevice_Click(object sender, EventArgs e)
        {
            if (menuBOX == null) return;

            frmDeviceManager Manager = new frmDeviceManager(new Host() { HostName = menuBOX.Device.Name, IPAddress = menuBOX.Device.IPAddress.ToIPAddress(), MAC = menuBOX.MAC, Port = menuBOX.Device.Port, Interval = menuBOX.Device.Interval });
            Manager.Show();
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            if (Settings.MinimizeWhenClose)
            {
                SetVisible(false);
                WindowState = FormWindowState.Minimized;
                return;
            }
            Settings.Save();
            Settings.SetHandle(0);
            SaveDevices();
            notifyIcon1.Visible = false;
            Process.GetCurrentProcess().Kill();
        }

        private void MinimizeBox_BoxClicked(object sender, EventArgs e)
        {
            SetVisible(false);
            WindowState = FormWindowState.Minimized;
        }

        private void SettingsBox_BoxClicked(object sender, EventArgs e)
        {
            shadow.Dock = DockStyle.Fill;
            MainMenu.Show(this, base.Width - MainMenu.Width - 12, TopPanel.Height + 5);
        }

        private void DeviceContainer_ControlModifiqued(object sender, ControlEventArgs e)
        {
            bool ContainsBox = false;
            for (int i = 0; i < DeviceContainer.Controls.Count; i++)
            {
                if (DeviceContainer.Controls[i] is DeviceBox) ContainsBox = true;
            }

            WelcomeBox.Visible = !ContainsBox;
        }

        private void TEST(DeviceBox deviceBox)
        {
            //if (deviceBox.Device.Name == "Hackerprod")
            //{
            //    new frmPrivateChat(deviceBox)
            //    {
            //        Location = new Point(0, 0)
            //    }.ShowDialog();
            //}
        }
    }
}
