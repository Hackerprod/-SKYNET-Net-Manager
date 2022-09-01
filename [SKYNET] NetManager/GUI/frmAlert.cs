using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;                    
using System.Runtime.InteropServices;
using SKYNET.Properties;
using System.Media;
using SKYNET.GUI;

namespace SKYNET
{
    public partial class frmAlert : frmBase
    {
        public static frmAlert frm;

        public static string Win32;
        public bool Ready = false;
        public frmAlert(DeviceBox BOX)
        {
            InitializeComponent();
            base.SetMouseMove(this);
            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  
            frm = this;


            if (BOX.AlertOnConnect)
            {
                if (BOX.isWeb)
                {
                    label1.Text = "EL EQUIPO ESTA ONLINE";
                    Avatar.Image = Resources.glob_v2;
                }
                else
                {
                    label1.Text = BOX.BoxName.ToUpper() + " ESTA ONLINE";
                    Avatar.Image = Resources.My_Computer_lime_copia;
                }

                Time.Text = DateTime.Now.ToShortTimeString();

                message.Text = "El programa ha realizado ping con el" + Environment.NewLine + "ip " + BOX.IpName;

                if (frmMain.CustomSound)
                {
                    if (File.Exists(frmMain.CustomSoundPatch))
                    {
                        try
                        {
                            SoundPlayer beep = new SoundPlayer(frmMain.CustomSoundPatch);
                            beep.Play();
                        }
                        catch
                        {
                            SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                            beep.Play();
                        }
                    }
                    else
                    {
                        SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                        beep.Play();
                    }
                }
                else
                {
                    SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                    beep.Play();
                }
            }
            else if (BOX.AlertOnDisconnect)
            {
                if (BOX.isWeb)
                {
                    label1.Text = "EL EQUIPO ESTA OFFLINE";
                    Avatar.Image = Resources.glob_v2;
                }
                else
                {
                    label1.Text = BOX.BoxName.ToUpper() + " ESTA OFFLINE";
                    Avatar.Image = Resources.My_Computer_lime_copia;
                }

                Time.Text = DateTime.Now.ToShortTimeString();

                message.Text = "El programa ha dejado de dar ping" + Environment.NewLine + " con el ip " + BOX.IpName;

                if (frmMain.CustomSound)
                {
                    if (File.Exists(frmMain.CustomSoundPatch))
                    {
                        try
                        {
                            SoundPlayer beep = new SoundPlayer(frmMain.CustomSoundPatch);
                            beep.Play();
                        }
                        catch
                        {
                            SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                            beep.Play();
                        }
                    }
                    else
                    {
                        SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                        beep.Play();
                    }
                }
                else
                {
                    SoundPlayer beep = new SoundPlayer(Resources.sound_start_record);
                    beep.Play();
                }
            }

            BOX.ClearAlerts();

            if (BOX.CustomAvatar)
            {
                Avatar.Image = BOX.Avatar.Image;
            }

            Common.MoveToTopMost(base.Handle);
            base.TopMost = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void panelClose_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(57, 62, 63);
        }

        private void panelClose_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(43, 47, 48);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

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
