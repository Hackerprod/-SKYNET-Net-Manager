using System;
using SKYNET.GUI;

namespace SKYNET
{
    public partial class frmAddProfile : frmBase
    {
        public bool Ready = false;
        public DeviceBox menuBOX;

        public frmAddProfile()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);

            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  
        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewProfile.Text))
                return;

            frmProfile.NewProfile = NewProfile.Text;
            button1.PerformClick();
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
    }
}
