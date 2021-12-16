using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.ComponentModel;
using Microsoft.Win32;
using System.Threading;
using System.Security.Principal;
using System.IO;                   
using System.Net.NetworkInformation;
using System.Collections.Generic;
using XNova_Utils;
using GlobalLowLevelHooks;
using Microsoft.VisualBasic.CompilerServices;
using WakeOnLanAction;
using SKYNET.Properties;
using System.Timers;
using System.Web.Script.Serialization;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using SKYNET.DragHelper;

namespace SKYNET
{
    public partial class frmMain : Form
    {
        public static bool MinimizeWhenClose { get; set; } = false;
        public static bool LaunchWindowsStart { get; set; } = false;
        public static string CurrentSection { get; set; } = "Device";
        public static string Key { get; set; } = "F8";
        public static bool ShowInLeft { get; set; } = false;
        public static double OpacityForm { get; set; } = 100;
        public static bool CustomSound { get; set; }
        public static string CustomSoundPatch { get; set; }
        public static bool ShowTopPanel { get; set; }


        private readonly System.Timers.Timer _timer = new System.Timers.Timer();


        public frmBack frmBack;

        public static frmMain frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public bool Ready = false;
        public DeviceBox menuBOX { get; set; }

        public RegistrySettings settings;
        public static bool FirstLaunch = false;
        readonly PingOptions PingOption;
        readonly byte[] buffer;
        private int x = 5;
        private int y = 5;
        private int last_x = 4;
        private int last_y = 5;
        private KeyboardHook keyboardHook;
        //private Panel panel;
        private bool Empty = false;

        public static int BufferSize;
        public static int Timeout { get; set; }
        public static int TTL;

        public frmMain(frmBack back)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;

            PrepareButtomPanel();

            frmBack = back;

            if (!Directory.Exists(modCommon.CurrentDirectory + "/Data"))
            {
                Directory.CreateDirectory(modCommon.CurrentDirectory + "/Data");
                File.WriteAllText(modCommon.CurrentDirectory + "/Data/Device.json", "");

                if (!File.Exists(modCommon.CurrentDirectory + "/Data/Device.json"))
                {
                    using (FileStream fileStream = new FileStream(modCommon.CurrentDirectory + "/Data/Device.json", FileMode.OpenOrCreate)) { }
                }

                Empty = true;
            }
            else if (!File.Exists(modCommon.CurrentDirectory + "/Data/Device.json"))
            {
                using (FileStream fileStream = new FileStream(modCommon.CurrentDirectory + "/Data/Device.json", FileMode.OpenOrCreate)) { }
                Empty = true;

            }


            // 128 TTL and DontFragment
            PingOption = new PingOptions(128, true);
            buffer = new byte[4];

            settings = new RegistrySettings();
            settings.GuardarID((object)Handle.ToInt64());
            settings.LoadSettings();

            if (Empty)
            {
                CurrentSection = "Device";
            }
            //panel = WelcomeBox;

            InitTimer();
            _timer.Interval = 100;
            _timer.Start();

            MessageProcessor processor = new MessageProcessor();
            bool apiStarted = processor.Start();

            if (!apiStarted)
            {
                modCommon.Show("Ups");
            }

            shadow.EnableBlur();
        }
        
        private void SetTransparency()
        {
            TransparencyKey = this.BackColor;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Maximize(ShowInLeft);

            LoadProfile(CurrentSection);

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
            CurrentSection = currentSection;
            frm.CleanBoxControls();
            x = 5;
            y = 5;
            last_x = 5;
            last_y = 5;

            string json = "";

            if (!File.Exists(modCommon.CurrentDirectory + "/Data/" + currentSection + ".json"))
            {
                if (File.Exists(modCommon.CurrentDirectory + "/Data/Device.json"))
                {
                    json = File.ReadAllText(modCommon.CurrentDirectory + "/Data/Device.json");
                }
            }
            else
                json = File.ReadAllText(modCommon.CurrentDirectory + "/Data/" + currentSection + ".json");

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
                frmBack.Opacity = OpacityForm;
                modCommon.CloseSplash = true;
                return;
            }
            Devices.Sort((d1, d2) => d1.Orden.CompareTo(d2.Orden));
            foreach (Device device in Devices)
            {
                AddBox(device);
            }

            ProfileSelected.Text = "Perfil actual: " + currentSection;
            Opacity = 100;
            frmBack.Opacity = OpacityForm;
            modCommon.CloseSplash = true;
            //modCommon.SplashScreen.Opacity = 0;
        }
        public void AddBox(Device device)
        {
            var deviceBox = new DeviceBox()
            {
                Location = new Point(x, y),
                Device = device,
                Orden = DeviceManager.GetDeviceCount() + 1
            };

            DragTest(deviceBox);

            DeviceContainer.Controls.Add(deviceBox);

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

        private void DragTest(DeviceBox deviceBox)
        {
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
            File.WriteAllText(modCommon.CurrentDirectory + "/Data/" + CurrentSection + ".json", json);
        }
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (key.ToString() == Key)
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

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void panelMin_MouseMove(object sender, MouseEventArgs e)
        {
            panelMin.BackColor = Color.FromArgb(53, 64, 78);
        }

        private void panelMin_MouseLeave(object sender, EventArgs e)
        {
            panelMin.BackColor = Color.FromArgb(43, 54, 68);
        }
        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {
            PanelSettings.BackColor = Color.FromArgb(53, 64, 78);
            picSettings.Image = Resources.settings_sel;
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            PanelSettings.BackColor = Color.FromArgb(43, 54, 68);
            picSettings.Image = Resources.settings_unsel;

        }

        private void panelClose_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(53, 64, 78);
        }

        private void panelClose_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (MinimizeWhenClose)
            {
                SetVisible(false);
                WindowState = FormWindowState.Minimized;
                return;
            }
            settings.SaveSettings();
            settings.ResetId();
            SaveDevices();
            Process.GetCurrentProcess().Kill();
        }

        private void SetVisible(bool value)
        {
            Visible = value;
            frmBack.Visible = value;
            frmBack.Activate();
            Activate();
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            SetVisible(false);
            WindowState = FormWindowState.Minimized;
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //notifyIcon1.Visible = false;
            SaveDevices();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                frm.HerramientasMenuItem.Text = "Herramientas (" + box.BoxName + ")";
                if (box.isWeb)
                    frm.explorarPCMenuItem.Text = "Explorar web";
                else
                {
                    frm.explorarPCMenuItem.Text = "Explorar PC";

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
                frm.HerramientasMenuItem.Text = "Herramientas (" + box.BoxName + ")";
                if (box.isWeb)
                    frm.explorarPCMenuItem.Text = "Explorar web";
                else
                    frm.explorarPCMenuItem.Text = "Explorar PC";
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
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://{box.IpName}:28082/onPing");
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

        private void explorarPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            if (!menuBOX.isWeb)
                Process.Start(@"\\" + menuBOX.IpName);
            else
                Process.Start("https://" + menuBOX.IpName);
        }

        private void hacerPingPorCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            frmConsole console = new frmConsole(menuBOX);
            console.Show();
        }

        private void MostrarMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Activate();
                SetVisible(true);
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                SetVisible(false);
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            settings.SaveSettings();
            settings.ResetId();
            SaveDevices();
            Process.GetCurrentProcess().Kill();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Environment.UserName == "Hackerprod")
            {
                //label1.Location = new Point(label1.Location.X + 5, label1.Location.Y + 5);

                var list = new List<Control>();
                for (int i = 0; i < frm.DeviceContainer.Controls.Count; i++)
                {
                    if (DeviceContainer.Controls[i] is DeviceBox)
                    {
                        DeviceBox box = (DeviceBox)DeviceContainer.Controls[i];
                        list.Add(box);
                    }
                }
               
                list.Sort((d1, d2) => (d1.Location.X + d1.Location.Y).CompareTo((d2.Location.X + d2.Location.Y)));
                foreach (var item in list)
                {
                    //modCommon.Show(item.BoxName);
                }

                List<Control> sortedList = ControlSorter.SortControls(frm.DeviceContainer);
                CleanBoxControls();
                x = 5;
                y = 5;
                last_x = 5;
                last_y = 5;
                foreach (var item in sortedList)
                {
                    if (item is DeviceBox)
                    {
                        DeviceBox box = ((DeviceBox)item);
                        //modCommon.Show(((DeviceBox)item).BoxName);
                        AddBox(box.Device);
                    }
                }
            }
        }



        private void Box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Control control = sender as Control;
                DeviceBox box = (DeviceBox)control;
                if (box.Status == ConnectionStatus.Online)
                {
                    if (!box.isWeb)
                        Process.Start(@"\\" + box.IpName);
                    else
                        Process.Start("https://" + box.IpName);
                }
            }
            catch { }
        }

        private void CloseBoxMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage message = new frmMessage("Estas seguro que deseas eliminar al dispositivo " + menuBOX.BoxName + "?", frmMessage.TypeMessage.YesNo);
            DialogResult result = message.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(modCommon.CurrentDirectory + "/Data/Images/" + CurrentSection + "_" + menuBOX.Name + ".png"))
                    {
                        File.Delete(modCommon.CurrentDirectory + "/Data/Images/" + CurrentSection + "_" + menuBOX.Name + ".png");
                    }
                }
                catch { }

                RemoveDevice(menuBOX);
            }
        }

        private void RemoveDevice(DeviceBox menuBOX)
        {

            string DeviceName = menuBOX.Name;
            if (DeviceManager.GetDeviceCount() > menuBOX.Orden)
            {
                menuBOX.BoxName = "No configurado";
                menuBOX.IpName = "No configurado";
                menuBOX.isWeb = false;

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

        private void EditarMenuItem_Click(object sender, EventArgs e)
        {
            ShowManager(menuBOX);
        }

        public void ShowManager(DeviceBox menuBOX = null)
        {
            frmManager manage = new frmManager(menuBOX);
            manage.ShowDialog();
        }

        private void PicSettings_Click(object sender, EventArgs e)
        {
            shadow.Dock = DockStyle.Fill;
            MainMenu.Show(this, (Width - MainMenu.Width) - 12, TopPanel.Height + 5);
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
        private void OnlineAlertMenuItem_Click(object sender, EventArgs e)
        {
            menuBOX.AlertOnConnect = true;
        }

        private void OfflineAlertMenuItem_Click(object sender, EventArgs e)
        {
            menuBOX.AlertOnDisconnect = true;
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
                        if (LaunchWindowsStart)
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

                settings.SaveSettings();
            }
        }
        private void DevicePingInfoMenuItem_Click(object sender, EventArgs e)
        {
            frmDeviceInfo deviceInfo = new frmDeviceInfo(menuBOX);
            deviceInfo.Show();
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

        private void PuertosMenuItem_Click(object sender, EventArgs e)
        {
            frmPortScan manage = new frmPortScan(menuBOX.IpName);
            manage.Show();
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

            Sent.Text = modCommon.LongToMbytes(interfaces.GetIPv4Statistics().BytesSent);
            Received.Text = modCommon.LongToMbytes(interfaces.GetIPv4Statistics().BytesReceived);

            SentxSecond = interfaces.GetIPv4Statistics().BytesSent - BytesSent;
            ReceivedxSecond = interfaces.GetIPv4Statistics().BytesReceived - BytesReceived;

            SentPerSecond.Text = modCommon.LongToMbytes(SentxSecond) + "/Segundos";
            ReceivedPerSecond.Text = modCommon.LongToMbytes(ReceivedxSecond) + "/Segundos";

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

        private void AgregarEquipoMenuItem_Click(object sender, EventArgs e)
        {
            frmMain.frm.ShowManager();
        }

        private void BuscarEquiposMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.Show();
        }

        private void AdministrarPerfilesMenuItem_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.ShowDialog();
        }

        private void MinimizeMenuItem_Click(object sender, EventArgs e)
        {
            SetVisible(false);
            WindowState = FormWindowState.Minimized;
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

            modCommon.ShowShadow = false;
            shadow.Dock = DockStyle.None;
        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnActivated(e);

            if (modCommon.ShowShadow)
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

            frmManager Manager = new frmManager(new Host() { HostName = menuBOX.BoxName, IP = menuBOX.IpName, MAC = menuBOX.MAC, Port = menuBOX.Port, Interval = menuBOX.Interval });
            Manager.Show();
            
        }

        private void EnviarMensajeMenuItem_Click(object sender, EventArgs e)
        {
            new frmSendMessage(menuBOX).ShowDialog();
        }
    }
}
