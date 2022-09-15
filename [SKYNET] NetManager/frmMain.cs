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
        public static frmBack frmBack;
        public static frmMain frm;
        public static bool ReceiveMessages;


        public bool Ready = false;
        public DeviceBox menuBOX;

        private int x = 5;
        private int y = 5;
        private int last_x = 4;
        private int last_y = 5;
        private KeyboardHook keyboardHook;
        private System.Timers.Timer _timer;
        private bool EmptyProfile = false;

        public frmMain(frmBack back)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;  
            frm = this;
            ReceiveMessages = true;

            PrepareButtomPanel();

            frmBack = back;
            _timer = new System.Timers.Timer();

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

            Settings.Load();
            Settings.SetHandle(Handle.ToInt64());

            if (EmptyProfile)
            {
                Settings.CurrentSection = "Device";
            }

            InitTimer();
            _timer.Interval = 100;
            _timer.Start();

            ChatManager.Initialize();
        }

        private void SetTransparency()
        {
            TransparencyKey = this.BackColor;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Maximize(Settings.ShowInLeft);

            LoadProfile(Settings.CurrentSection);

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();

            DeviceContainer.AutoScroll = true;
            DeviceContainer.VerticalScrollbar = true;

            SetTransparency();
        }

        public void Maximize(bool inLeft)
        {
            frmBack.Maximize(inLeft);
            if (!inLeft)
               DeviceContainer.Height = this.Height - 250;
        }

        public void LoadProfile(string currentSection)
        {
            Settings.CurrentSection = currentSection;
            frm.CleanBoxControls();
            x = 5;
            y = 5;
            last_x = 5;
            last_y = 5;

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
                frmBack.Opacity = Settings.OpacityForm;
                Common.CloseSplash = true;
                return;
            }

            Devices.Sort((d1, d2) => d1.Order.CompareTo(d2.Order));
            foreach (Device device in Devices)
            {
                AddBox(device);
            }

            ProfileSelected.Text = "Current profile: " + currentSection;
            Opacity = 100;
            frmBack.Opacity = Settings.OpacityForm;
            Common.CloseSplash = true;
        }

        public void AddBox(Device device)
        {
            var deviceBox = new DeviceBox()
            {
                Location = new Point(x, y),
                Device = device,
            };

            deviceBox.Device.Order = DeviceManager.GetDeviceCount() + 1;

            DeviceContainer.Controls.Add(deviceBox);

            test(deviceBox);

            last_x = x;
            last_y = y;

            if (x == 5)
            {
                x += 160;
            }
            else
            {
                x = 5;
                y += 49;
            }
        }

        public void Write(object obj)
        {
            ProfileSelected.Text = obj.ToString();
        }

        public void UpdateAndSave()
        {
            SaveDevices();
        }
       
        public void SaveDevices()
        {
            List<Device> Devices = new List<Device>(); 
            for (int i = 0; i < DeviceContainer.Controls.Count; i++)
            {
                if (DeviceContainer.Controls[i] is DeviceBox)
                {
                    DeviceBox deviceBox = (DeviceBox)DeviceContainer.Controls[i];
                    Device device = DeviceManager.GetDevice(deviceBox);
                    Devices.Add(device);
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
                    WindowState = FormWindowState.Maximized;
                    Activate();
                    SetVisible(true);
                }
                if (WindowState == FormWindowState.Maximized && !WinMod.IsActiveMainWindow())
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
            frmBack.Visible = value;
            frmBack.Activate();
            Activate();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            SaveDevices();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized || WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
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
                    httpWebRequest.Method = "POST";
                    using (Stream newStream = httpWebRequest.GetRequestStream())
                    {
                        newStream.Write(new byte[0], 0, 0);
                    }
                    frm.enviarMensajeMenuItem.Visible = true;
                }
                catch (Exception ex)
                {
                    frm.enviarMensajeMenuItem.Visible = false;
                }
            });
        }

        private void RemoveDevice(DeviceBox menuBOX)
        {

            string DeviceName = menuBOX.Name;
            if (DeviceManager.GetDeviceCount() > menuBOX.Device.Order)
            {
                menuBOX.Device.Name = "No configurado";
                menuBOX.Device.TCP = false;

                UpdateAndSave();
            }
            else
            {
                RemoveControlInPanel(DeviceName);

                x = last_x;
                y = last_y;

            }
            SaveDevices();
        }

        private void RemoveControlInPanel(string name)
        {
            try
            {
                Control control = DeviceContainer.Controls.Find(name, searchAllChildren: true).FirstOrDefault();
                if (control != null)
                {
                    DeviceContainer.Controls.Remove(control);
                }
            }
            catch
            {

            }
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
            frmManager manage = new frmManager(menuBOX);
            manage.ShowDialog();
        }

        internal static DeviceBox GetBoxFromName(string device)
        {
            for (int i = 0; i < frmMain.frm.DeviceContainer.Controls.Count; i++)
            {
                if (frmMain.frm.DeviceContainer.Controls[i] is DeviceBox)
                {
                    DeviceBox box = (DeviceBox)frmMain.frm.DeviceContainer.Controls[i];
                    if (box.Name == device)
                        return box;
                }
            }
            return null;
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

        private void InitTimer()
        {
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            bool ContainDevice = false;
            foreach (Control item in DeviceContainer.Controls)
            {
                if (item is DeviceBox)
                {
                    ContainDevice = true;
                    break;
                }
            }
            if (ContainDevice)
                WelcomeBox.Visible = false;
            else
                WelcomeBox.Visible = true;
        }
        private void DeviceContainer_ControlModifiqued(object sender, ControlEventArgs e)
        {
            _timer.Interval = 100;
            _timer.Start();
        }

        private void PanelBottom_MouseMove(object sender, MouseEventArgs e)
        {
            if (PanelBottom.Height < 50)
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

        private void PanelBottom_MouseLeave(object sender, EventArgs e)
        {

        }
        private void PrepareButtomPanel()
        {
            PanelBottom.Height = 17;
            byHackerprod.Location = new Point(248, 0);
            ProfileSelected.Location = new Point(0, 0);
            PanelBottom.Controls.Add(PanelTransfer);
            PanelTransfer.Dock = DockStyle.Fill;
            PanelTransfer.MouseMove += PanelBottom_MouseMove;

            panelSent.Visible = false;
            panelReceived.Visible = false;
            Sent.Visible = false;
            Received.Visible = false;
            SentPerSecond.Visible = false;
            ReceivedPerSecond.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

        }
        long BytesSent = 0;
        long BytesReceived = 0;
        long SentxSecond = 0;
        long ReceivedxSecond = 0;


        private void TimerTransfer_Tick(object sender, EventArgs e)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return;

            bool First = false;

            if (BytesSent == 0)
                First = true;

            NetworkInterface interfaces = NetworkInterface.GetAllNetworkInterfaces()[0];

            Sent.Text = Common.LongToMbytes(interfaces.GetIPv4Statistics().BytesSent);
            Received.Text = Common.LongToMbytes(interfaces.GetIPv4Statistics().BytesReceived);

            SentxSecond = interfaces.GetIPv4Statistics().BytesSent - BytesSent;
            ReceivedxSecond = interfaces.GetIPv4Statistics().BytesReceived - BytesReceived;

            SentPerSecond.Text = Common.LongToMbytes(SentxSecond) + "/Segundos";
            ReceivedPerSecond.Text = Common.LongToMbytes(ReceivedxSecond) + "/Segundos";

            BytesSent = interfaces.GetIPv4Statistics().BytesSent;
            BytesReceived = interfaces.GetIPv4Statistics().BytesReceived;

        }

        private void ClearLabel_Tick(object sender, EventArgs e)
        {

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
            frmMain.frm.ShowManager();
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

            frmManager Manager = new frmManager(new Host() { HostName = menuBOX.Device.Name, IPAddress = menuBOX.Device.IPAddress.ToIPAddress(), MAC = menuBOX.MAC, Port = menuBOX.Device.Port, Interval = menuBOX.Interval });
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

        private void test(DeviceBox box)
        {
            if (box.Device.Name == "Hackerprod")
            {
                //new frmPrivateChat(box).Show();
            }
        }
    }
}
