using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SKYNET.Controls
{
    public partial class SKYNET_Box : UserControl
    {
        private Color color;
        private Color focusedColor;
        private bool _menuMode;
        private int _separator;

        [Category("SKYNET")]
        public bool MenuMode
        {
            get { return _menuMode; }
            set { _menuMode = value; }
        }

        [Category("SKYNET")]
        public int MenuSeparation
        {
            get { return _separator; }
            set { _separator = value; }
        }

        [Category("SKYNET")]
        public event EventHandler BoxClicked;

        [Category("SKYNET")]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                BackColor = value;

                int R = value.R < 245 ? value.R + 10 : 255;
                int G = value.G < 245 ? value.G + 10 : 255;
                int B = value.B < 245 ? value.B + 10 : 255;

                FocusedColor = Color.FromArgb(R, G, B);
            }
        }

        [Category("SKYNET")]
        public Color FocusedColor
        {
            get
            {
                return focusedColor;
            }
            set
            {
                focusedColor = value;
            }
        }

        [Category("SKYNET")]
        public Image Image
        {
            get
            {
                return PB_Image.Image;
            }
            set
            {
                PB_Image.Image = value;
            }
        }

        public SKYNET_Box()
        {
            InitializeComponent();

            _separator = 8;
        }

        private void OnClicked(object sender, MouseEventArgs e)
        {
            BoxClicked?.Invoke(this, new EventArgs());
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            BackColor = focusedColor;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            BackColor = color;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_menuMode)
            {
                MenuPaint(e);
                return;
            }

            base.OnPaint(e);
        }

        private void MenuPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(base.Width, base.Height);
            Graphics G = Graphics.FromImage(B);
            var W = base.Width;
            var H = base.Height;
            Rectangle rect = new Rectangle(0, 0, W, H);
            checked
            {
                Rectangle rect2 = new Rectangle(W - 40, 0, W, H);
                GraphicsPath graphicsPath = new GraphicsPath();
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.FillRectangle(new SolidBrush(BackColor), rect);
                graphicsPath.Reset();
                graphicsPath.AddRectangle(rect2);
                G.SetClip(graphicsPath);

                G.FillRectangle(new SolidBrush(BackColor), rect2); 
                G.ResetClip();

                int mSeparator = (H - (_separator * 2)) + _separator / 2 + 1;
                G.DrawLine(new Pen(Color.White), W - _separator, _separator, _separator, _separator);
                G.DrawLine(new Pen(Color.White), W - _separator, mSeparator, _separator, mSeparator);
                G.DrawLine(new Pen(Color.White), W - _separator, H - _separator, _separator, H - _separator);

                G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
                B.Dispose();
            }
        }
    }
}
