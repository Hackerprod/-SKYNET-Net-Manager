using SKYNET.GUI;
using SKYNET.Network;
using SKYNET.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmPublicChat : frmBase
    {
        private UDPBroadcaster broadcaster;

        public frmPublicChat()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            TopMost = true;
            Common.MoveToTopMost(base.Handle);
            TB_Message.Focus();

            broadcaster = new UDPBroadcaster();
            broadcaster.OnMessageReceived = OnMessageReceived;
        }

        private void OnMessageReceived(object sender, MessageProcessor.MessageReceived message)
        {
            PrintMessage(message);
            Common.Show(message);
        }

        internal void PrintMessage(MessageProcessor.MessageReceived e)
        {
            //try
            //{
            //    ChatMessage message = new ChatMessage();
            //    string sender = "";

            //    if (e.Device == null)
            //    {
            //        message.Sender = e.Address.ToString();
            //    }
            //    else
            //    {
            //        message.Sender = e.Device.Name;
            //    }

            //    message.Message = e.Message;

            //    WriteChat(message);

            //    ChatManager.RegisterMessage(e.Address, message);
            //}
            //catch 
            //{
            //}
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
                broadcaster.Send(msg);
            });

        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            //ChatManager.RemoveChat(IPAddress);
            Close();
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
    }
}
