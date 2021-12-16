using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class FlatComboBox : ComboBox
{
    private int W;

    private int H;
    private Color _BackColorMouseOver { get; set; }


    public Color BackColorMouseOver
    {
        get
        {
            return _BackColorMouseOver;
        }
        set
        {
            _BackColorMouseOver = value;
        }
    }
    private int StartIndex
    {
        set
        {
            try
            {
                SelectedIndex = value;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            Invalidate();
        }
    }


    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Invalidate();
        if (e.X < checked(base.Width - 41))
        {
            Cursor = Cursors.Default;
        }
        else
        {
            Cursor = Cursors.Hand;
        }
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        base.OnDrawItem(e);
        Invalidate();
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        {
            Invalidate();
        }
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        Invalidate();
    }

    public void AddFromString(string StringItemArray, string Splitter)
    {
        base.Items.AddRange(Strings.Split(StringItemArray, Splitter));
    }

    public void DrawItem_(object sender, DrawItemEventArgs e)
    {
        if (e.Index >= 0)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, 71, 85)), e.Bounds.X + 9, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height + 10);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, 71, 85)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }
            e.Graphics.DrawString(GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), Font, Brushes.White, checked(new Rectangle(e.Bounds.X + 9, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height + 10)));
            e.Graphics.Dispose();
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
    }

    public FlatComboBox()
    {
        base.DrawItem += DrawItem_;
        SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        DoubleBuffered = true;
        base.DrawMode = DrawMode.OwnerDrawFixed;
        base.DropDownStyle = ComboBoxStyle.DropDownList;
        Cursor = Cursors.Hand;
        StartIndex = 0;
        base.ItemHeight = 28;
        Font = Font;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap B = new Bitmap(base.Width, 28);
        Graphics G = Graphics.FromImage(B);
        W = base.Width;
        H = 28;
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
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 61, 75)), rect2); // Color del cuadro a la derecha
            G.ResetClip();
            G.DrawLine(Pens.White, W - 10, 6, W - 30, 6);
            G.DrawLine(Pens.White, W - 10, 12, W - 30, 12);
            G.DrawLine(Pens.White, W - 10, 18, W - 30, 18);
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(9, 3), NearSF);
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }


    }
    internal static StringFormat NearSF = new StringFormat
    {
        Alignment = StringAlignment.Near,
        LineAlignment = StringAlignment.Near
    };
    private int X;

    public Point[] Triangle(Point Location, Size Size)
    {
        Point[] ReturnPoints = new Point[4];
        ReturnPoints[0] = Location;
        ReturnPoints[1] = new Point(Location.X + Size.Width, Location.Y);
        ReturnPoints[2] = new Point(Location.X + Size.Width / 2, Location.Y + 28);
        ReturnPoints[3] = Location;

        return ReturnPoints;
    }
}

