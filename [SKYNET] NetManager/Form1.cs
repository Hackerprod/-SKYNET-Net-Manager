using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            new frmMain(new frmBack());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skyneT_WebChat1.WriteChat(new Types.ChatMessage()
            {
                 Message = "Este es el mensaje",
                  Sender = "Hackerprod",
                   Time = DateTime.Now,
                    Addresses = NetHelper.GetAddresses()
            });
        }

        private void SkyneT_TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                skyneT_WebChat1.WriteChat(new Types.ChatMessage()
                {
                    Message = skyneT_TextBox1.Text,
                    Sender = "Hackerpod",
                    Time = DateTime.Now,
                    Addresses = NetHelper.GetAddresses()
                });
                skyneT_TextBox1.Clear();
            }
        }

        private void SkyneT_TextBox1_OnLogoClicked(object sender, EventArgs e)
        {

        }
    }
}
