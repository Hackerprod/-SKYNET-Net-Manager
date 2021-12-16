using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.DragHelper
{
    public static class DragableControl
    {
        private static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();

        private static Size mouseOffset;

        public static void Draggable(this Control control, bool enable)
        {
            if (enable)
            {
                if (!draggables.ContainsKey(control))
                {
                    draggables.Add(control, value: false);
                    control.MouseDown += control_MouseDown;
                    control.MouseUp += control_MouseUp;
                    control.MouseMove += control_MouseMove;
                }
            }
            else if (draggables.ContainsKey(control))
            {
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                draggables.Remove(control);
            }
        }

        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            draggables[(Control)sender] = true;
        }

        private static void control_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
        }

        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if (draggables[(Control)sender])
                {
                    Point point = e.Location - mouseOffset;
                    ((Control)sender).Left += point.X;
                    ((Control)sender).Top += point.Y;
                }
            }
        }

    }
}
