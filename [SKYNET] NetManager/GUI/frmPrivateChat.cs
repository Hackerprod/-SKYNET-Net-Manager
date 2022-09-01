using SKYNET.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmPrivateChat : frmBase
    {
        private DeviceBox box;
        private IPAddress IPAddress;

        public frmPrivateChat(DeviceBox box)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            this.box = box;

            if (box == null)
            {
                Close();
            }

            if (IPAddress.TryParse(box.IpName, out var iPAddress))
            {
                this.IPAddress = iPAddress;
            }

            label2.Text = "Message to " + box.BoxName;
            TB_Message.Focus();
        }

        public frmPrivateChat(IPAddress iPAddress)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            this.IPAddress = iPAddress;
            label2.Text = "Message to " + iPAddress.ToString();

            TopMost = true;
            Common.MoveToTopMost(base.Handle);
        }

        internal void PrintMessage(MessageProcessor.MessageReceived e)
        {
            try
            {
                string msg = "";

                if (e.Device == null)
                {
                    msg += e.Address + ": " + e.Message;
                }
                else
                {
                    msg += e.Device.Name + ": " + e.Message;
                }

                WriteChat(msg);

                ChatManager.RegisterMessage(e.Address, msg);
            }
            catch 
            {
            }
            TopMost = true;
            Common.MoveToTopMost(base.Handle);
        }

        private void WriteChat(string msg)
        {
            TB_Chat.SelectionStart = TB_Chat.TextLength;
            TB_Chat.SelectionLength = 0;

            string time = " " + DateTime.Now.ToShortTimeString() + " ";

            Common.InvokeAction(TB_Chat, delegate { TB_Chat.Text += msg + Environment.NewLine; });
            Common.ScrollToBottom(TB_Chat);
        }

        public void FillHistory(List<string> messages)
        {
            foreach (var message in messages)
            {
                TB_Chat.Text += message + Environment.NewLine;
            }
        }

        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    int attrValue = 2;
        //    DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 4);
        //    DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
        //    mARGINS.cyBottomHeight = 1;
        //    mARGINS.cxLeftWidth = 0;
        //    mARGINS.cxRightWidth = 0;
        //    mARGINS.cyTopHeight = 0;
        //    DwmApi.MARGINS marInset = mARGINS;
        //    DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);

        //    TopMost = false;
        //}

        private void TB_Message_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Return)
            {
                SendMessage(TB_Message.Text);
                TB_Message.Text = "";
            }
        }

        private void SendMessage(string msg)
        {
            Task.Run(() =>
            {
                try
                {
                    byte[] bytes = Encoding.Default.GetBytes(msg);
                    string IP = box != null ? box.IpName : IPAddress.ToString();
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://{IP}:28082/onMessage");
                    httpWebRequest.Method = "POST";
                    using (Stream newStream = httpWebRequest.GetRequestStream())
                    {
                        newStream.Write(bytes, 0, bytes.Length);
                    }
                    var sd = httpWebRequest.GetResponse().GetResponseStream();
                    Info.Text = "Done";
                    Info.ForeColor = Color.Green;

                    msg = Environment.UserName + ": " + msg;

                    TB_Chat.Text += msg + Environment.NewLine;

                    ChatManager.RegisterMessage(IPAddress, msg);
                }
                catch (Exception ex)
                {
                    Info.Text = "Error sending";
                    Info.ForeColor = Color.Red;
                }
            });

        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            ChatManager.RemoveChat(IPAddress);
            Close();
        }


    }
}
