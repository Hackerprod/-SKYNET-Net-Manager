using SKYNET.GUI;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmMessage : frmBase
    {
        public TypeMessage typeMessage;
        private IPAddress IPAddress;

        public frmMessage(string message, TypeMessage type, string header = "", IPAddress ipaddress = null)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

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
            //if (!string.IsNullOrEmpty(header))
            //{
            //    Header.Text = header;
            //}
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _Cancel.PerformClick();
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (typeMessage == TypeMessage.UserMessage)
            {
                var box = DeviceManager.GetBoxFromIP(IPAddress);
                if (box != null)
                {
                    frmPrivateChat send = new frmPrivateChat(box);
                    send.ShowDialog();
                }
                else
                {
                    frmPrivateChat send = new frmPrivateChat(IPAddress);
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
