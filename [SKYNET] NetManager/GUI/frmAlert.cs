using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.ComponentModel;
using Microsoft.Win32;
using System.Threading;
using System.Security.Principal;
using System.IO;                    // Para Stream
using System.Text;                  // Para Encoatagring
using System.Net;                   // Para Dns, IPAddress
using System.Net.Sockets;           // Para NetworkStream    []   |||   &&
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices;
using SKYNET.Properties;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Media;

namespace SKYNET
{
    public partial class frmAlert : Form
    {
        public static frmAlert frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        public static string Win32;
        public bool Ready = false;
        public frmAlert(DeviceBox BOX)
        {
            InitializeComponent();
            MoveToTopMost(this.Handle);
            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

        private void MoveToTopMost(IntPtr handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
        }
        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
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
