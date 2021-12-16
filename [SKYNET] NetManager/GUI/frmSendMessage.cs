using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmSendMessage : Form
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        private DeviceBox box;
        private IPAddress iPAddress;

        public frmSendMessage(DeviceBox box)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            this.box = box;

            if (box == null)
            {
                Close();
            }
            label2.Text = "Message to " + box.BoxName;
        }

        public frmSendMessage(IPAddress iPAddress)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos

            this.iPAddress = iPAddress;
            label2.Text = "Message to " + iPAddress.ToString();

        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void Event_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendMsg_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    byte[] bytes = Encoding.Default.GetBytes(txtMessage.Text);
                    string IP = box != null ? box.IpName : iPAddress.ToString();
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://{IP}:28082/onMessage");
                    httpWebRequest.Method = "POST";
                    using (Stream newStream = httpWebRequest.GetRequestStream())
                    {
                        newStream.Write(bytes, 0, bytes.Length);
                    }
                    var sd = httpWebRequest.GetResponse().GetResponseStream();
                    Info.Text = "Done";
                    Info.ForeColor = Color.Green;
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    Info.Text = "Error sending";
                    Info.ForeColor = Color.Red;
                }
            });

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
    }
}
