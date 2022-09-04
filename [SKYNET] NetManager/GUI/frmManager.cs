using SKYNET.GUI;
using SKYNET.Helpers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmManager : frmBase
    {
        public TypeMessage typeMessage;
        DeviceBox Box;
        string SectionName;

        public frmManager(DeviceBox tool = null)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(PN_Top);

            if (tool != null)
            {
                Box = tool;
                if (Box.isWeb && string.IsNullOrEmpty(Box.Port)) Box.Port = "80";

                DeviceName.Text = Box.BoxName;
                DeviceIp.Text = Box.IpName;
                DeviceWeb.Checked = Box.isWeb;
                Avatar.Image = Box.Avatar.Image;
                SectionName = Box.Name;
                MAC.Text = Box.MAC;
                Port.Visible = DeviceWeb.Checked;
                Port.Text = Box.Port;
                Interval.Text = Box.Interval.ToString();
                OpcionalLocation.Text = Box.OpcionalLocation;
                CircularAvatar.Checked = Box.CircularAvatar;
            }
            else
            {
                /*sectionNumber = modCommon.GetNextSection();
                SectionName = frmMain.CurrentSection + sectionNumber;*/
            }
            Check(DeviceWeb.Checked);
        }
        public frmManager(Host host)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  

            if (host != null)
            {
                DeviceName.Text = host.HostName;
                DeviceIp.Text = host.IP;
                MAC.Text = host.MAC;
                Interval.Text = host.Interval.ToString();
                if (int.TryParse(host.Port, out int port) && port != 0)
                {
                    Port.Text = host.Port;
                    DeviceWeb.Checked = true;
                    Port.Visible = true;
                }
            }
            else
            {
                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panelClose_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(53, 64, 78);
        }

        private void panelClose_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(43, 54, 68);
        }

        public enum TypeMessage
        {
            Alert,
            Normal,
            YesNo
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (!Common.IsValidIp(DeviceIp.Text))
            {
                Common.Show("El número IP no es válido... por favor verifíquelo");
                return;
            }
            if (Interval.Text == "0")
            {
                Common.Show("El intervalo debe ser al menos cada 1 segundo");
                return;
            }
            if (Interval.Text.Length == 0)
            {
                Common.Show("Introduzca el intervalo de monitoreo");
                return;
            }
            if (DeviceName.Text.Length == 0)
            {
                Common.Show("Introduzca el nombre para identificar el equipo");
                return;
            }
            if (Box != null)
            {
                if (Box.Device == null)
                {
                    Box.Device = new Device();
                }

                Box.BoxName = DeviceName.Text;
                Box.Device.Name = DeviceName.Text;

                Box.IpName = DeviceIp.Text;
                Box.Device.Ip = DeviceName.Text;

                Box.isWeb = DeviceWeb.Checked;
                Box.SetAvatar(Avatar.Image);

                if (int.TryParse(Interval.Text, out int interval))
                {
                    Box.Interval = interval;
                    Box.Device.Interval = interval;
                }
                else
                {
                    Box.Interval = 1;
                    Box.Device.Interval = 1;
                }
                Box.Port = Port.Text;
                if (int.TryParse(Port.Text, out int port))
                {
                    Box.Device.Port = port;
                }
                

                Box.OpcionalLocation = OpcionalLocation.Text;
                Box.Device.OpcionalLocation = OpcionalLocation.Text;

                frmMain.frm.UpdateAndSave();
            }
            else
            {
                Device device = new Device();
                device.Name = DeviceName.Text;
                device.Ip = DeviceIp.Text;
                device.TCP = DeviceWeb.Checked;

                if (int.TryParse(Interval.Text, out int interval))
                {
                    device.Interval = interval;
                }
                else
                    device.Interval = 1;

                if (int.TryParse(Port.Text, out int port))
                {
                    device.Port = port;
                }
                else
                    device.Port = 0;

                device.OpcionalLocation = OpcionalLocation.Text;
                device.Orden = DeviceManager.GetDeviceCount() + 1;


                frmMain.frm.AddBox(device);
                frmMain.frm.UpdateAndSave();
            }



            frmMain.frm.SaveDevices();
            Close();
        }

        private void DeviceWeb_Click(object sender, EventArgs e)
        {
        }

        private void Check(bool _checked)
        {
            Port.Visible = DeviceWeb.Checked;
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Devices"))
            {
                Directory.CreateDirectory("Devices");
            }

            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.FileName = string.Empty;
            ofdPhoto.Filter = "Picture files|*.jpg;*.bmp;*.png;*.gif;*.ico|All Files|*.*";
            ofdPhoto.Title = "Select Photo";
            ofdPhoto.RestoreDirectory = true;
            DialogResult dialogResult = ofdPhoto.ShowDialog();
            //pctPhoto.Tag = string.Empty;
            this.Visible = false;
            WindowState = FormWindowState.Minimized;
            if (dialogResult == DialogResult.OK)
            {
                string FileName = Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + SectionName + ".png";
                ImageType type = DeviceManager.GetImageType(ofdPhoto.FileName);

                if (type == ImageType.ICO)
                {
                    Bitmap bitmap = (Bitmap)default;
                    try
                    {
                        bitmap = new Icon(ofdPhoto.FileName, 1000, 1000).ToBitmap();
                    }
                    catch (Exception)
                    {
                        bitmap = Bitmap.FromHicon((new Icon(ofdPhoto.FileName, 1000, 1000).Handle));
                    }
                    bitmap = ImageHelper.CreateResizedBitmap(bitmap, 1000, 1000, ImageFormat.Png);
                    bitmap.Save(FileName, ImageFormat.Png);
                    LoadImage();
                }
                else
                {
                    //pctPhoto.Tag = "1";
                    Image image = Common.ImageFromFile(ofdPhoto.FileName);

                    if (image.Width < 250)
                    {
                        Bitmap bitmap = (Bitmap)default;
                        bitmap = ImageHelper.CreateResizedBitmap((Bitmap)image, 1000, 1000, ImageFormat.Png);
                        bitmap.Save(FileName, ImageFormat.Png);
                    }
                    else
                    {
                        frmCropEditor FrmPhoto2 = new frmCropEditor(ofdPhoto.FileName, SectionName);
                        FrmPhoto2.ShowDialog();
                    }

                    LoadImage();
                }
            }
            this.Visible = true;
            WindowState = FormWindowState.Normal;

        }

        private void LoadImage()
        {
            Avatar.Image = Common.ImageFromFile(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + SectionName + ".png");
            if (Box != null)
            {
                Box.SetAvatar(Avatar.Image, true);
            }
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            DeleteAvatar.Parent = Avatar;
        }

        private void DeleteAvatar_Click(object sender, EventArgs e)
        {
            Avatar.Image = Common.ImageFromFile(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + SectionName + ".png");

            if (Box != null)
            {
                if (File.Exists(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + Box.Name + ".png"))
                {
                    try { File.Delete(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + Box.Name + ".png"); } catch { }

                    Box.CustomAvatar = false;

                    if (Box.Status == ConnectionStatus.Online)
                    {
                        Avatar.Image = Properties.Resources.OnlinePC;
                        Box.SetAvatar(Properties.Resources.OnlinePC);
                    }
                    else
                    {
                        Avatar.Image = Properties.Resources.OfflinePC;
                        Box.SetAvatar(Properties.Resources.OfflinePC);
                    }

                }
            }

        }

        private void MAC_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SearchPorts_Click(object sender, EventArgs e)
        {
            new frmPortScan(DeviceIp.Text).ShowDialog();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            if (Environment.UserName == "Hackerprod")
            {
                DeviceName.Text = "Hackerprod";
                DeviceIp.Text = "10.31.0.2";
                DeviceWeb.Checked = false;
            }
        }

        private void DeviceIp_TextChanged(object sender, EventArgs e)
        {
            if (Common.IsValidIp(DeviceIp.Text))
            {
                PanelDeviceIp.BackColor = DeviceIp.BackColor;
            }
            else
            {
                PanelDeviceIp.BackColor = Color.Red;
            }

            try
            {
                IPAddress address = IPAddress.Parse(DeviceIp.Text);
            }
            catch (Exception)
            {
                PanelDeviceIp.BackColor = Color.Red;
            }
        }

        private void Interval_TextChanged(object sender, EventArgs e)
        {
            string interval = Interval.Text;
            Interval.Text = string.Join("", interval.ToCharArray().Where(Char.IsDigit));
            if (Interval.Text == "0")
            {
                PanelInterval.BackColor = Color.Red;
            }
            else
            {
                PanelInterval.BackColor = Interval.BackColor;
            }
        }


        private void OpcionalLocation_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.FileName = string.Empty;
            ofdPhoto.Filter = "All Files|*.*";
            ofdPhoto.Title = "Select File";
            ofdPhoto.RestoreDirectory = true;
            DialogResult dialogResult = ofdPhoto.ShowDialog();
            this.Visible = false;
            WindowState = FormWindowState.Minimized;
            if (dialogResult == DialogResult.OK)
            {
                OpcionalLocation.Text = ofdPhoto.FileName;
            }
            this.Visible = true;
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void CircularAvatar_Click(object sender, EventArgs e)
        {
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
        }

        private void CircularAvatar_CheckedChanged(object sender, bool e)
        {
            Box.CircularAvatar = e;

            if (Box.CustomAvatar)
            {
                if (e)
                {
                    Avatar.Image = Common.CropToCircle(Box.BoxImage);
                }
                else
                    Avatar.Image = Box.BoxImage;
            }

        }

        private void DeviceWeb_Click(object sender, MouseEventArgs e)
        {
            Check(DeviceWeb.Checked);
        }
    }
}
