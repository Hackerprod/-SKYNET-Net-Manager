using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    class ControlMover
    {
        public enum Direction
        {
            Any,
            Horizontal,
            Vertical
        }

        public static void Init(Control control)
        {
            Init(control, Direction.Any);
        }

        public static void Init(Control control, Direction direction)
        {
            Init(control, control, direction);
        }

        public static void Init(Control control, Control container, Direction direction)
        {
            bool Dragging = false;
            Point DragStart = Point.Empty;
            control.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Dragging = true;
                    DragStart = new Point(e.X, e.Y);
                    control.Capture = true;
                    control.BringToFront();
                }
            };
            control.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Dragging = false;
                    control.Capture = false;
                    control.BringToFront();
                }
            };
            control.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Dragging)
                    {
                        if (direction != Direction.Vertical)
                            container.Left = Math.Max(0, e.X + container.Left - DragStart.X);
                        if (direction != Direction.Horizontal)
                            container.Top = Math.Max(0, e.Y + container.Top - DragStart.Y);
                        control.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        control.Cursor = Cursors.Default;
                    }
                    control.BringToFront();
                }
            };
            control.ParentChanged += delegate (object sender, EventArgs e)
            {
                //modCommon.Show("Changed");
            };
        }
    }
}
