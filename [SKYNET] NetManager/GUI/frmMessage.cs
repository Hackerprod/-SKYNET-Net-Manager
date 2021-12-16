using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmMessage : Form
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public TypeMessage typeMessage;
        private IPAddress IPAddress;
        public frmMessage(string message, TypeMessage type, string header = "", IPAddress ipaddress = null)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos

            typeMessage = type;
            IPAddress = ipaddress;

            switch (typeMessage)
            {
                case TypeMessage.Normal:
                    btn_Accept.Visible = false;
                    btn_Cancel.Text = "Cerrar";
                    txtMessage.MouseClick += new MouseEventHandler(this.TxtMessage_MouseClick);
                    SetMouseMove(txtMessage);
                    break;
                case TypeMessage.UserMessage:
                    Device box = DeviceManager.GetDeviceFromIP(IPAddress);
                    if (box == null)
                    {
                        btn_Accept.Visible = false;
                    }
                    btn_Accept.Text = "Responder";
                    btn_Cancel.Text = "Cerrar";
                    txtMessage.Cursor = Cursors.IBeam;
                    break;
                default:
                    SetMouseMove(txtMessage);
                    txtMessage.MouseClick += new MouseEventHandler(this.TxtMessage_MouseClick);
                    break;
            }
            txtMessage.Text = message;
            if (!string.IsNullOrEmpty(header))
            {
                Header.Text = header;
            }
        }

        private void SetMouseMove(Control control)
        {
            control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_MouseDown);
            control.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            control.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Event_MouseUp);
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
            _Cancel.PerformClick();
            Close();
        }

        private void acepctBtn_Click(object sender, EventArgs e)
        {
            if (typeMessage == TypeMessage.UserMessage)
            {
                var box = DeviceManager.GetBoxFromIP(IPAddress);
                if (box != null)
                {
                    frmSendMessage send = new frmSendMessage(box);
                    send.ShowDialog();
                }
                else
                {
                    frmSendMessage send = new frmSendMessage(IPAddress);
                    send.ShowDialog();
                }
            }
            ok.PerformClick();
        }

        public enum TypeMessage
        {
            Alert,
            Normal,
            YesNo,
            UserMessage
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
        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TxtMessage_MouseClick(object sender, MouseEventArgs e)
        {
            btn_Accept.Focus();
        }
    }
}
