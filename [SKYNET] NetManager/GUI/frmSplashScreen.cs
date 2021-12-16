using SKYNET.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmSplashScreen : Form
    {
        private System.Windows.Forms.Timer timerAnimation;
        private Bitmap _logoBitmap;
        private Bitmap _fdnLogoBitmap;
        private int _ticks = 0;

        public frmSplashScreen()
        {
            InitializeComponent();
            modCommon.SplashScreen = this;
            //DisplayHelper.Scale(this);
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            LoadScaledImages();
            FixLayout();

            // Create the timer
            timerAnimation = new System.Windows.Forms.Timer();
            timerAnimation.Interval = 17; // 60 FPS rounded up
            timerAnimation.Tick += new EventHandler(AnimationTick);
            timerAnimation.Enabled = true;
            timerAnimation.Start();


        }
        private void LoadScaledImages()
        {
            const float scaleFactor = 2f; // Assume logos are already at 2x scaling
            var fdnLogoBmp = (Bitmap)Resources.Logo;
            var logoBmp = (Bitmap)Resources.SkynetManager;

            var fdnLogoSize = new Size(
                (int)Math.Ceiling(fdnLogoBmp.Width * (DisplayHelper.ScalingFactorX / scaleFactor)),
                (int)Math.Ceiling(fdnLogoBmp.Height * (DisplayHelper.ScalingFactorY / scaleFactor)));
            _fdnLogoBitmap = new Bitmap(fdnLogoBmp, fdnLogoSize);
            pictureBoxFdnLogo.Image = _fdnLogoBitmap;
            pictureBoxFdnLogo.Size = _fdnLogoBitmap.Size;

            var logoBmpSize = new Size(
                (int)Math.Ceiling(logoBmp.Width * (DisplayHelper.ScalingFactorX / scaleFactor)),
                (int)Math.Ceiling(logoBmp.Height * (DisplayHelper.ScalingFactorY / scaleFactor)));
            _logoBitmap = new Bitmap(logoBmp, logoBmpSize);
            pictureBoxLogo.Image = _logoBitmap;
            pictureBoxLogo.Size = _logoBitmap.Size;
        }
        private void FixLayout()
        {
            pictureBoxLogo.Top = Height / 2 - pictureBoxLogo.Height / 2;
        }
        private void AnimationTick(object sender, EventArgs e)
        {
            // .NET Foundation Logo linear slide animation
            const int fdnLogoAnimTicks = 10;
            const int fdnLogoAnimTarget = 20;
            pictureBoxFdnLogo.Left = (int)Math.Min(DisplayHelper.ScalingFactorX * _ticks * ((float)fdnLogoAnimTarget / fdnLogoAnimTicks), DisplayHelper.ScalingFactorX * fdnLogoAnimTarget);
            pictureBoxFdnLogo.Image = ChangeOpacity(_fdnLogoBitmap, (float)Math.Min((float)_ticks / fdnLogoAnimTicks, 1.0));
            pictureBoxFdnLogo.Visible = true;

            // Open Live Writer logo non-linear slide animation
            const int logoAnimStart = 4;
            const int logoAnimTicks = 16;
            int logoAnimTarget = Width / 2 - _logoBitmap.Width / 2;
            const int logoAnimSlideWidth = 30;

            if (_ticks >= logoAnimStart)
            {
                // Decimal animation curve from 0 to 1
                double x = 1 - Math.Pow(Math.Max(1 - ((double)(_ticks - logoAnimStart) / logoAnimTicks), 0), 2);
                pictureBoxLogo.Left =
                    (logoAnimTarget - (int)(logoAnimSlideWidth * DisplayHelper.ScalingFactorX)) + (int)Math.Ceiling(x * (logoAnimSlideWidth * DisplayHelper.ScalingFactorX));
                pictureBoxLogo.Image = ChangeOpacity(_logoBitmap, (float)Math.Min((float)(_ticks - logoAnimStart) / logoAnimTicks, 1.0));
                pictureBoxLogo.Visible = true;
            }

            Update();
            _ticks++;
            if (_ticks == 40)
            {
                timerAnimation.Enabled = false;
                modCommon.ShowMain = true;
            }
        }
        private static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            // Example from https://www.codeproject.com/Tips/201129/Change-Opacity-of-Image-in-C

            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }
        public void ShowSplashScreen()
        {
            Thread thread = new Thread(() =>
            {
                ShowDialog();
            });
            thread.Name = "Splash Screen Animation Thread";
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
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
    /// <summary>
    /// Implementation of a splash screen connected to a form
    /// </summary>
    public class FormSplashScreen : IDisposable
    {
        public FormSplashScreen(Form form)
        {
            this.form = form;
        }

        public Form Form
        {
            get { return form; }
        }

        /// <summary>
        /// Close the form (do it only once and defend against exceptions
        /// occurring during close/dispose)
        /// </summary>
        public void Dispose()
        {
            if (form != null)
            {
                if (form.InvokeRequired)
                {
                    form.BeginInvoke(new ThreadStart(Dispose));
                }
                else
                {
                    try
                    {
                        form.Close();
                        form.Dispose();
                    }
                    finally
                    {
                        form = null;
                    }
                }
            }
        }

        /// <summary>
        /// Form instance
        /// </summary>
        private Form form;


    }
    internal class DisplayHelper
    {
        const int DEFAULT_DPI = 96;
        const int TWIPS_PER_INCH = 1440;
        private static int? _pixelsPerLogicalInchX;
        public static float ScaleX(float x) => x * ScalingFactorX;
        public static float ScaleY(float y) => y * ScalingFactorY;
        public static int ScaleXCeil(float x) => (int)Math.Ceiling(x * ScalingFactorX);
        public static int ScaleYCeil(float y) => (int)Math.Ceiling(y * ScalingFactorY);
        public static int PixelsPerLogicalInchX
        {
            get
            {
                if (_pixelsPerLogicalInchX == null)
                {
                    IntPtr hWndDesktop = User32.GetDesktopWindow();
                    IntPtr hDCDesktop = User32.GetDC(hWndDesktop);
                    _pixelsPerLogicalInchX = Gdi32.GetDeviceCaps(hDCDesktop, DEVICECAPS.LOGPIXELSX);
                    User32.ReleaseDC(hWndDesktop, hDCDesktop);
                }
                return _pixelsPerLogicalInchX.Value;
            }
        }
        public static float ScalingFactorX
        {
            get
            {
                return (float)PixelsPerLogicalInchX / (float)DEFAULT_DPI;
            }
        }
        public static float ScalingFactorY
        {
            get
            {
                return (float)PixelsPerLogicalInchY / (float)DEFAULT_DPI;
            }
        }
        public static int? _pixelsPerLogicalInchY;
        public static int PixelsPerLogicalInchY
        {
            get
            {
                if (_pixelsPerLogicalInchY == null)
                {
                    IntPtr hWndDesktop = User32.GetDesktopWindow();
                    IntPtr hDCDesktop = User32.GetDC(hWndDesktop);
                    _pixelsPerLogicalInchY = Gdi32.GetDeviceCaps(hDCDesktop, DEVICECAPS.LOGPIXELSY);
                    User32.ReleaseDC(hWndDesktop, hDCDesktop);
                }
                return _pixelsPerLogicalInchY.Value;
            }
        }
        public static SizeF ScalingFactor
        {
            get
            {
                return new SizeF(ScalingFactorX, ScalingFactorY);
            }
        }

        /// <summary>
        /// Scales a control from 96dpi to the actual screen dpi.
        /// </summary>
        public static void Scale(Control c)
        {
            c.Scale(ScalingFactor);
        }
    }

    public class Gdi32
    {
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    }
    public struct DEVICECAPS
    {
        public const int LOGPIXELSX = 88;
        public const int LOGPIXELSY = 90;
    }

    public class User32
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr dc);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
    }

}
