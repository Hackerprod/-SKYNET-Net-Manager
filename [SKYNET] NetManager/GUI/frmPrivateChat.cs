using SKYNET.GUI;
using SKYNET.Types;
using System;
using System.Collections.Generic;
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
            TB_Message.TextBox.Focus();
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
            TB_Message.Focus();
        }

        internal void PrintMessage(MessageProcessor.MessageReceived e)
        {
            try
            {
                ChatMessage message = new ChatMessage();
                string sender = "";

                if (e.Device == null)
                {
                    message.Sender = e.Address.ToString();
                }
                else
                {
                    message.Sender = e.Device.Name;
                }

                message.Message = e.Message;

                WriteChat(message);

                ChatManager.RegisterMessage(e.Address, message);
            }
            catch 
            {
            }
            TopMost = true;
            Common.MoveToTopMost(base.Handle);
        }

        private void WriteChat(ChatMessage message)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());

            listViewItem.SubItems[0].Text = message.Sender;
            listViewItem.SubItems[1].Text = message.Message;

            LV_Chat.Items.Add(listViewItem);

            SetScrollPosition();
        }

        public void SetScrollPosition()
        {
            if (LV_Chat.Items.Count < 16) return;

            // 12 (altura del listview)
            SuspendLayout();
            EnsureVisible();
            ResumeLayout();
        }

        private void EnsureVisible()
        {
            int num = LV_Chat.Items.Count - 1;
            if (num >= 0)
            {
                LV_Chat.EnsureVisible(num);
            }
        }

        public void FillHistory(List<ChatMessage> messages)
        {
            foreach (var message in messages)
            {
                WriteChat(message);
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
        }

        private void TB_Message_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                SendMessage(TB_Message.TextBox.Lines[0]);
                TB_Message.Clear();
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

                    ChatMessage message = new ChatMessage()
                    {
                        Sender = Environment.UserName,
                        Message = msg
                    };

                    WriteChat(message);

                    ChatManager.RegisterMessage(IPAddress, message);
                }
                catch (Exception ex)
                {
                    //TB_Chat.Text += "Error sending: " + msg + Environment.NewLine;
                }
            });

        }

        private void FrmPrivateChat_Shown(object sender, EventArgs e)
        {
            TB_Message.Focus();
        }

        private void LV_Chat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text = this.LV_Chat.SelectedItems[0].SubItems[1].Text;
                Clipboard.SetText(text);
            }
            catch 
            {
            }
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            ChatManager.RemoveChat(IPAddress);
            Close();
        }
    }
}
