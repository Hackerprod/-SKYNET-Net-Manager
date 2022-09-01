using System;
using System.Drawing;
using System.Windows.Forms;

namespace SKYNET.GUI
{
    public partial class frmAbout : frmBase
    {
        public TypeMessage typeMessage;
        public frmAbout()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(PN_Top);
            textBox1.Focus();

            VersionInfo.Text = "v1.5";
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
