using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.Controls
{
    public partial class SKYNET_Box : UserControl
    {
        private Color color;
        private Color focusedColor;

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
    }
}
