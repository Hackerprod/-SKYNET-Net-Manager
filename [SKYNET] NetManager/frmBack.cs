using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmBack : Form
    {
        public static frmBack frm;
        public frmBack()
        {
            InitializeComponent();
            frm = this;
            Opacity = 0;
        }

        public frmMain Main;

        private void FrmBack_Load(object sender, EventArgs e)
        {
            int maximum = 100;
            string opacity = frmBack.frm.Opacity.ToString();
            opacity = opacity.Replace("0,", "").Replace("0.", "");

            int value = Convert.ToInt32(opacity);
            if (value == 1) value = 100;

        }

        private void FrmBack_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Main = new frmMain(this);

            Main.TopLevel = false;
            Main.Dock = DockStyle.Fill;
            Main.Visible = true;
            this.Controls.Add(Main);

        }

        private void FrmBack_Activated(object sender, EventArgs e)
        {

        }

        internal void Maximize(bool inLeft)
        {
            Rectangle workingArea1 = Screen.FromHandle(Handle).WorkingArea;
            int height = workingArea1.Height;

            if (inLeft)
            {
                try
                {
                    MaximizedBounds = new Rectangle(0, 0, this.Width, height);
                    WindowState = FormWindowState.Normal;
                }
                catch { }

            }
            else
            {
                try
                {
                    MaximizedBounds = new Rectangle((workingArea1.Width - this.Width), 0, this.Width, height);
                    this.WindowState = FormWindowState.Normal;
                }
                catch { }
            }
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
