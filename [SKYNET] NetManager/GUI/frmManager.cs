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
        private DeviceBox DeviceBox;
        private string Guid;

        public frmManager(DeviceBox box = null)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(PN_Top);

            if (box != null)
            {
                DeviceBox = box;

                if (DeviceBox.Device?.Guid != null)
                {
                    Guid = DeviceBox.Device?.Guid;
                }
                else
                {
                    Guid = System.Guid.NewGuid().ToString();
                }

                if (DeviceBox.Device.TCP && DeviceBox.Device.Port == 0)
                    DeviceBox.Device.Port = 80;

                DeviceName.Text = DeviceBox.Device.Name;
                DeviceIp.Text = DeviceBox.Device.IPAddress.ToString();
                DeviceWeb.Checked = DeviceBox.Device.TCP;
                Avatar.Image = DeviceBox.PB_Image.Image;
                MAC.Text = DeviceBox.MAC;
                Port.Visible = DeviceWeb.Checked;
                Port.Text = DeviceBox.Device.Port.ToString();
                Interval.Text = DeviceBox.Interval.ToString();
                OpcionalLocation.Text = DeviceBox.OpcionalLocation;
                CircularAvatar.Checked = DeviceBox.CircularImage;
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
                DeviceIp.Text = host.IPAddress.ToString();
                MAC.Text = host.MAC;
                Interval.Text = host.Interval.ToString();
                Port.Text = host.Port.ToString(); 
                DeviceWeb.Checked = true;
                Port.Visible = true;
            }
            else
            {
                Close();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!NetHelper.IsValidIp(DeviceIp.Text))
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

            if (DeviceBox != null)
            {
                if (DeviceBox.Device == null)
                {
                    DeviceBox.Device = new Device()
                    {
                        Guid = Guid
                    };
                }

                if (string.IsNullOrEmpty(DeviceBox.Device.Guid))
                {
                    DeviceBox.Device.Guid = Guid;
                }

                DeviceBox.Device.Name = DeviceName.Text;

                if (IPAddress.TryParse(DeviceName.Text, out _))
                {
                    DeviceBox.Device.IPAddress = DeviceName.Text;
                }

                DeviceBox.Device.TCP = DeviceWeb.Checked;
                DeviceBox.SetImage(Avatar.Image);

                if (int.TryParse(Interval.Text, out int interval))
                {
                    DeviceBox.Interval = interval;
                    DeviceBox.Device.Interval = interval;
                }
                else
                {
                    DeviceBox.Interval = 1;
                    DeviceBox.Device.Interval = 1;
                }

                if (int.TryParse(Port.Text, out int port))
                {
                    DeviceBox.Device.Port = port;
                }

                DeviceBox.OpcionalLocation = OpcionalLocation.Text;
                DeviceBox.Device.OpcionalLocation = OpcionalLocation.Text;

                DeviceBox.Device = DeviceBox.Device;

                frmMain.frm.UpdateAndSave();
            }
            else
            {
                Device device = new Device();
                device.Guid = Guid;
                device.Name = DeviceName.Text;
                if (IPAddress.TryParse(DeviceIp.Text, out var Address))
                {
                    device.IPAddress = Address.ToString();
                }

                device.TCP = DeviceWeb.Checked;

                if (int.TryParse(Interval.Text, out int interval))
                {
                    device.Interval = interval;
                }
                else
                {
                    device.Interval = 1;
                }

                if (int.TryParse(Port.Text, out int port))
                {
                    device.Port = port;
                }
                else
                {
                    device.Port = 0;
                }

                device.OpcionalLocation = OpcionalLocation.Text;
                device.Order = DeviceManager.GetDeviceCount() + 1;

                frmMain.frm.AddBox(device);
                frmMain.frm.UpdateAndSave();
            }


            frmMain.frm.SaveDevices();
            Close();
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
            ofdPhoto.Filter = "Picture files|*.jpg;*.bmp;*.jpg;*.gif;*.ico|All Files|*.*";
            ofdPhoto.Title = "Select Photo";
            ofdPhoto.RestoreDirectory = true;
            DialogResult dialogResult = ofdPhoto.ShowDialog();
            this.Visible = false;
            WindowState = FormWindowState.Minimized;
            if (dialogResult == DialogResult.OK)
            {
                string FileName = Path.Combine(Common.GetPath(), "Data", "Images", Guid + ".jpg");
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
                        frmCropEditor FrmPhoto2 = new frmCropEditor(ofdPhoto.FileName, Guid);
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
            string filePath = Path.Combine(Common.GetPath(), "Data", "Images" + Guid + ".jpg");

            if (File.Exists(filePath))
            {
                Avatar.Image = Common.ImageFromFile(filePath);
                if (DeviceBox != null)
                {
                    DeviceBox.SetImage(Avatar.Image);
                }
            }
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            DeleteAvatar.Parent = Avatar;
        }

        private void DeleteAvatar_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Common.GetPath(), "Data", "Images" + Guid + ".jpg");
            Avatar.Image = Common.ImageFromFile(filePath);

            if (DeviceBox != null)
            {
                if (File.Exists(filePath))
                {
                    try { File.Delete(filePath); } catch { }

                    if (DeviceBox.Status == ConnectionStatus.Online)
                    {
                        Avatar.Image = Properties.Resources.OnlinePC;
                        DeviceBox.SetImage(Properties.Resources.OnlinePC);
                    }
                    else
                    {
                        Avatar.Image = Properties.Resources.OfflinePC;
                        DeviceBox.SetImage(Properties.Resources.OfflinePC);
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
            if (IPAddress.TryParse(DeviceIp.Text, out var Address))
            {
                new frmPortScan(Address).ShowDialog();

            }
        }

        private void DeviceIp_TextChanged(object sender, EventArgs e)
        {
            if (NetHelper.IsValidIp(DeviceIp.Text))
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
            DeviceBox.CircularImage = e;
            if (e)
            {
                Avatar.Image = Common.CropToCircle(DeviceBox.Image);
            }
            else
                Avatar.Image = DeviceBox.Image;
        }

        private void DeviceWeb_Click(object sender, MouseEventArgs e)
        {
            Check(DeviceWeb.Checked);
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
