using SKYNET.GUI;
using SKYNET.Helpers;
using SKYNET.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
            CheckForIllegalCrossThreadCalls = false;

            base.SetMouseMove(PN_Top);
            base.EnableShadows = true;

            this.box = box;

            if (box == null)
            {
                Close();
            }

            this.IPAddress = box.Device.IPAddress.ToIPAddress();


            TB_Message.TextBox.Focus();
        }

        public frmPrivateChat(IPAddress iPAddress)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            this.IPAddress = iPAddress;

            TopMost = true;
            Common.MoveToTopMost(base.Handle);
            TB_Message.Focus();

            WriteChat(new ChatMessage() { Sender = "Hackerprod", Message = "Este es un mensaje de prueba para el diseño de los bundles del chat", Time = DateTime.Now, Address = "10.0.0.1" }, true);
            WriteChat(new ChatMessage() { Sender = "Hackerprod", Message = "Este es un mensaje de prueba para el diseño de los bundles del chat", Time = DateTime.Now, Address = "10.0.0.1" }, true);
            WriteChat(new ChatMessage() { Sender = "Hackerprod", Message = "Este es un mensaje", Time = DateTime.Now, Address = "10.0.0.1" }, true);
            WriteChat(new ChatMessage() { Sender = "Dairon", Message = "Este es un mensaje de prueba para el diseño de los bundles del chat", Time = DateTime.Now, Address = "10.0.0.12" }, false);
            WriteChat(new ChatMessage() { Sender = "Dairon", Message = "Este es un mensaje de prueba para el diseño de los bundles del chat", Time = DateTime.Now, Address = "10.0.0.12" }, false);
            WriteChat(new ChatMessage() { Sender = "Dairon", Message = "Este es un mensaje", Time = DateTime.Now, Address = "10.0.0.12" }, false);

        }

        internal void PrintMessage(MessageProcessor.MessageReceived e)
        {
            try
            {
                ChatMessageHistory message = new ChatMessageHistory()
                {
                    Message = e.Message,
                    Me = false
                };

                WriteChat(message.Message, false);

                ChatManager.RegisterMessage(e.Address, message);
            }
            catch 
            {
            }

            TopMost = true;
            Common.MoveToTopMost(base.Handle);
        }

        private void WriteChat(ChatMessage message, bool Me, bool Done = true)
        {
            WebChat.WriteChat(message, Me, Done);
        }

        public void FillHistory(List<ChatMessageHistory> messages)
        {
            foreach (var message in messages)
            {
                WriteChat(message.Message, message.Me);
            }
        }

        private void TB_Message_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                if (TB_Message.TextBox.Lines.Length > 0)
                {
                    SendMessage(TB_Message.TextBox.Lines[0]);
                    TB_Message.Clear();
                    TB_Message.Text = "";
                }
            }
        }

        private async Task SendMessage(string msg)
        {
            var message = new ChatMessage()
            {
                Sender = Settings.Username,
                Message = msg,
                Time = DateTime.Now
            };

            try
            {

                string JSON = new JavaScriptSerializer().Serialize(message);
                byte[] bytes = Encoding.Default.GetBytes(JSON);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://{IPAddress}:28082/onMessage");
                httpWebRequest.Method = "POST";

                using (Stream newStream = httpWebRequest.GetRequestStream())
                {
                    newStream.Write(bytes, 0, bytes.Length);
                }


                var sd = httpWebRequest.GetResponse().GetResponseStream();

                //var RequestStream = await httpWebRequest.GetRequestStreamAsync();
                //RequestStream.Write(bytes, 0, bytes.Length);

                //var Response = await httpWebRequest.GetResponseAsync();
                //Response.GetResponseStream();

                WriteChat(message, true, true);

                ChatManager.RegisterMessage(IPAddress, new ChatMessageHistory() { Message = message, Me = true });
            }
            catch 
            {
                WriteChat(message, true, false);
            }

        }

        private void FrmPrivateChat_Shown(object sender, EventArgs e)
        {
            TB_Message.Focus();
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            ChatManager.RemoveChat(IPAddress);
            Close();
        }

        private void TB_Message_OnLogoClicked(object sender, EventArgs e)
        {
            if (TB_Message.TextBox.Lines.Length > 0)
            {
                SendMessage(TB_Message.TextBox.Lines[0]);
                TB_Message.Clear();
                TB_Message.Text = "";
            }
        }
    }
}
