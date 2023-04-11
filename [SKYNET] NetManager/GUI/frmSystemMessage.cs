using SKYNET.GUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmSystemMessage : frmBase
    {
        private DeviceBox Box;
        private string server = "/SERVER:" + System.Net.Dns.GetHostEntry(Environment.MachineName).HostName;
        private string user = "*";
        private string msg = @"C:\Windows\System32\msg.exe";

        public frmSystemMessage(DeviceBox box)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;

            Box = box;

            TB_Message.Focus();
            TB_DelayTime.Text = "0";
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

            int delay = 0;
            int.TryParse(TB_DelayTime.Text, out delay);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = msg;
            startInfo.Arguments = $" /SERVER:{Box.Device.IPAddress} / TIME:{delay} {user} \"{TB_Message.Text}\"";
            startInfo.UseShellExecute = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(startInfo);

            Close();
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

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void TB_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (TB_Message.Text.Length >= 240)
            {
                e.SuppressKeyPress = true;
            }

            LB_Lenght.Text = $"{TB_Message.Text.Length} / 240";
        }
    }
}
