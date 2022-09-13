using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;                    
using System.Media;
using SKYNET.GUI;
using SKYNET.Helpers;

namespace SKYNET
{
    public partial class frmAlert : frmBase
    {
        public static string Win32;
        public bool Ready = false;
        public frmAlert(DeviceBox BOX)
        {
            InitializeComponent();
            base.SetMouseMove(this);
            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  

            if (BOX.AlertOnConnect)
            {
                if (BOX.isWeb)
                {
                    label1.Text = "EL EQUIPO ESTA ONLINE";
                    Avatar.Image = Properties.Resources.glob_v2;
                }
                else
                {
                    label1.Text = BOX.BoxName.ToUpper() + " ESTA ONLINE";
                    Avatar.Image = Properties.Resources.My_Computer_lime_copia;
                }

                Time.Text = DateTime.Now.ToShortTimeString();

                message.Text = "El programa ha realizado ping con el" + Environment.NewLine + "ip " + BOX.IpName;

                if (Settings.CustomSound)
                {
                    if (File.Exists(Settings.CustomSoundPatch))
                    {
                        try
                        {
                            SoundPlayer beep = new SoundPlayer(Settings.CustomSoundPatch);
                            beep.Play();
                        }
                        catch
                        {
                            SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
                            beep.Play();
                        }
                    }
                    else
                    {
                        SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
                        beep.Play();
                    }
                }
                else
                {
                    SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
                    beep.Play();
                }
            }
            else if (BOX.AlertOnDisconnect)
            {
                if (BOX.isWeb)
                {
                    label1.Text = "EL EQUIPO ESTA OFFLINE";
                    Avatar.Image = Properties.Resources.glob_v2;
                }
                else
                {
                    label1.Text = BOX.BoxName.ToUpper() + " ESTA OFFLINE";
                    Avatar.Image = Properties.Resources.My_Computer_lime_copia;
                }

                Time.Text = DateTime.Now.ToShortTimeString();

                message.Text = "El programa ha dejado de dar ping" + Environment.NewLine + " con el ip " + BOX.IpName;

                if (Settings.CustomSound)
                {
                    if (File.Exists(Settings.CustomSoundPatch))
                    {
                        try
                        {
                            SoundPlayer beep = new SoundPlayer(Settings.CustomSoundPatch);
                            beep.Play();
                        }
                        catch
                        {
                            SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
                            beep.Play();
                        }
                    }
                    else
                    {
                        SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
                        beep.Play();
                    }
                }
                else
                {
                    SoundPlayer beep = new SoundPlayer(Properties.Resources.sound_start_record);
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
