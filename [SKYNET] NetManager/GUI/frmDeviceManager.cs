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
    public partial class frmDeviceManager : frmBase
    {
        private DeviceBox DeviceBox;
        private string Guid;

        public frmDeviceManager(DeviceBox box = null)
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

                TB_Name.Text = DeviceBox.Device.Name;
                TB_IPAddress.Text = DeviceBox.Device.IPAddress?.ToString();
                CB_TCP.Checked = DeviceBox.Device.TCP;
                PB_Image.Image = DeviceBox.PB_Image.Image;
                TB_MAC.Text = DeviceBox.MAC;
                TB_Port.Visible = CB_TCP.Checked;
                TB_Port.Text = DeviceBox.Device.Port.ToString();
                TB_Interval.Text = DeviceBox.Device.Interval.ToString();
                TB_OpcionalLocation.Text = DeviceBox.OpcionalLocation;
                CB_CircularImage.Checked = DeviceBox.CircularImage;
            }
            else
            {
                /*sectionNumber = modCommon.GetNextSection();
                SectionName = frmMain.CurrentSection + sectionNumber;*/
            }
            Check(CB_TCP.Checked);
        }

        public frmDeviceManager(Host host)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  

            if (host != null)
            {
                TB_Name.Text = host.HostName;
                TB_IPAddress.Text = host.IPAddress.ToString();
                TB_MAC.Text = host.MAC;
                TB_Interval.Text = host.Interval.ToString();
                TB_Port.Text = host.Port.ToString(); 
                CB_TCP.Checked = true;
                TB_Port.Visible = true;
                Guid = System.Guid.NewGuid().ToString();
            }
            else
            {
                Close();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!NetHelper.IsValidIp(TB_IPAddress.Text))
            {
                Common.Show("El número IP no es válido... por favor verifíquelo");
                return;
            }

            if (TB_Interval.Text == "0")
            {
                Common.Show("El intervalo debe ser al menos cada 1 segundo");
                return;
            }

            if (TB_Interval.Text.Length == 0)
            {
                Common.Show("Introduzca el intervalo de monitoreo");
                return;
            }

            if (TB_Name.Text.Length == 0)
            {
                Common.Show("Introduzca el nombre para identificar el equipo");
                return;
            }

            if (DeviceBox != null)
            {
                var Device = new Device()
                {
                    Guid = Guid
                };

                if (string.IsNullOrEmpty(DeviceBox.Device?.Guid))
                {
                    DeviceBox.Device.Guid = Guid;
                }

                Device.Name = TB_Name.Text;

                if (IPAddress.TryParse(TB_IPAddress.Text, out _))
                {
                    Device.IPAddress = TB_IPAddress.Text;
                }

                Device.TCP = CB_TCP.Checked;

                if (int.TryParse(TB_Interval.Text, out int interval))
                {
                    Device.Interval = interval;
                }
                else
                {
                    Device.Interval = 1;
                }

                if (int.TryParse(TB_Port.Text, out int port))
                {
                    Device.Port = port;
                }

                Device.OpcionalLocation = TB_OpcionalLocation.Text;
                Device.OpcionalLocation = TB_OpcionalLocation.Text;
                Device.CircularImage = CB_CircularImage.Checked;

                DeviceBox.Device = Device;

                frmMain.frm.SaveDevices();
            }
            else
            {
                Device device = new Device();
                device.Guid = Guid;
                device.Name = TB_Name.Text;
                if (IPAddress.TryParse(TB_IPAddress.Text, out var Address))
                {
                    device.IPAddress = Address.ToString();
                }

                device.TCP = CB_TCP.Checked;

                if (int.TryParse(TB_Interval.Text, out int interval))
                {
                    device.Interval = interval;
                }
                else
                {
                    device.Interval = 1;
                }

                if (int.TryParse(TB_Port.Text, out int port))
                {
                    device.Port = port;
                }
                else
                {
                    device.Port = 0;
                }

                device.OpcionalLocation = TB_OpcionalLocation.Text;

                frmMain.frm.AddBox(device);
                frmMain.frm.SaveDevices();
            }

            frmMain.frm.SaveDevices();
            Close();
        }

        private void Check(bool _checked)
        {
            TB_Port.Visible = CB_TCP.Checked;
        }

        private void MAC_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SearchPorts_Click(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(TB_IPAddress.Text, out var Address))
            {
                new frmPortScan(Address).ShowDialog();

            }
        }

        private void DeviceIp_TextChanged(object sender, EventArgs e)
        {
            if (NetHelper.IsValidIp(TB_IPAddress.Text))
            {
                PanelDeviceIp.BackColor = TB_IPAddress.BackColor;
            }
            else
            {
                PanelDeviceIp.BackColor = Color.Red;
            }

            try
            {
                IPAddress address = IPAddress.Parse(TB_IPAddress.Text);
            }
            catch (Exception)
            {
                PanelDeviceIp.BackColor = Color.Red;
            }
        }

        private void Interval_TextChanged(object sender, EventArgs e)
        {
            string interval = TB_Interval.Text;
            TB_Interval.Text = string.Join("", interval.ToCharArray().Where(Char.IsDigit));
            if (TB_Interval.Text == "0")
            {
                PanelInterval.BackColor = Color.Red;
            }
            else
            {
                PanelInterval.BackColor = TB_Interval.BackColor;
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
                TB_OpcionalLocation.Text = ofdPhoto.FileName;
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
                PB_Image.Image = Common.CropToCircle(DeviceBox.Image);
            }
            else
                PB_Image.Image = DeviceBox.Image;
        }

        private void DeviceWeb_Click(object sender, MouseEventArgs e)
        {
            Check(CB_TCP.Checked);
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
