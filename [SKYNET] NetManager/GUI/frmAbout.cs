using System;
using System.Drawing;
using System.Windows.Forms;

namespace XNova_Utils
{
    public partial class frmAbout : Form
    {
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public TypeMessage typeMessage;
        public frmAbout()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            textBox1.Focus();

            VersionInfo.Text = "v1.5";
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


        public enum TypeMessage
        {
            Alert,
            Normal,
            YesNo
        }

        private void frmMessage_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void frmMessage_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }


        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
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
    }
}
