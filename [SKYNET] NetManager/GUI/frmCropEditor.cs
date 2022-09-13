﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using SKYNET.GUI;
using SKYNET.Helpers;

namespace SKYNET
{
    [ComVisibleAttribute(true)]
    public partial class frmCropEditor : frmBase
    {
        public static frmCropEditor frm;
        public byte[] ImageBytes;
        public Button DialogResult;

        private Rectangle rScreen;
        private Bitmap bitmap;
        private float AspectRatio;
        private string Guid;

        public frmCropEditor(string filepatch, string guid)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            frm = this;
            CheckForIllegalCrossThreadCalls = false;

            LoadLanguage();

            DialogResult = new Button();
            Controls.Add(DialogResult);
            DialogResult.DialogResult = System.Windows.Forms.DialogResult.OK;

            bitmap = (Bitmap)Image.FromFile(filepatch);

            Guid = guid;

            ImageCrop.Bitmap = bitmap;

            Rectangle rect = new Rectangle(Point.Empty, bitmap.Size);
            rect = EnforceAspectRatio(rect, 10);

            ImageCrop.CropRectangle = rect;

            AspectRatio = 1;
            ImageCrop.AspectRatio = AspectRatio;

            this.rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
            ChangeWindowTop();

        }

        private void LoadLanguage()
        {
            CenterLabel(l_Preview);
        }
        public static void CenterLabel(Label label)
        {
            //Width
            Control parent = label.Parent;
            int W_Control = parent.Width / 2;
            int AnchoTexto = Convert.ToInt32(Common.GetTextSize(label.Text.ToString(), label.Font).Width) / 2;
            int WidthText = W_Control - AnchoTexto;

            //Heigth
            int HeigthText = label.Location.Y;

            label.Location = new Point(WidthText, HeigthText);
        }
        public void ChangeWindowTop()
        {
            try
            {
                SetWindowPos(this.Handle, -1, checked(this.rScreen.Width - this.Width), checked(this.rScreen.Height - this.Height), this.Width, this.Height, 16U);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //Initialize class


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

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if (control is PictureBox)
                {
                    Control parent = control.Parent;
                    parent.BackColor = Color.FromArgb(50, 61, 75);
                }
                if (control is Panel)
                {
                    control.BackColor = Color.FromArgb(50, 61, 75);
                }
            }
            catch { }
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            CloseBox.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void ImageCrop_CropRectangleChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Up:
                case Keys.Control | Keys.Down:
                case Keys.Control | Keys.Left:
                case Keys.Control | Keys.Right:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Right:
                    if (ImageCrop.ProcessCommandKey(ref msg, keyData))
                    {
                        ImageCrop.Select();
                        return true;
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdatePreview()
        {
            Image img = ImageCrop.PreviewBitmap();

            if (Redondear.Checked)
            {
                panel1.BackColor = BackColor;
                p_Preview.Image = CropToCircle(img);
            }
            else
            {
                panel1.BackColor = Color.FromArgb(45, 56, 70);
                p_Preview.Image = img;
            }
        }

        private void ShowLine_MouseClick(object sender, MouseEventArgs e)
        {
            ImageCrop.GridLines = ShowLine.Checked;
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.Combine(Common.GetPath(), "Data", "Images")))
            {
                Directory.CreateDirectory(Path.Combine(Common.GetPath(), "Data", "Images"));
            }

            Image img = ImageCrop.PreviewBitmap();
            Bitmap image = ImageHelper.ImageResizer.ResizeBitmap((Bitmap)img, 1000, 1000, ImageFormat.Png);

            string destPath = Path.Combine(Common.GetPath(), "Data", "Images", Guid + ".jpg");
            Common.Resize((Bitmap)image, 1000, 1000, destPath);
            Close();


            //{
                

            //    try
            //    {
            //        FileManager.EnsureDirectoryExists(Paths.ProfileBackgroundImage, true);
            //        File.WriteAllBytes(Paths.ProfileBackgroundImage, Common.ImageHelper.GetBitmapBytes(image));
            //    }
            //    catch { }
            //}
            //DialogResult.PerformClick();
            //Close();
        }

        private void Redondear_MouseClick(object sender, MouseEventArgs e)
        {
            Image img = ImageCrop.PreviewBitmap();

            if (Redondear.Checked)
            {
                panel1.BackColor = BackColor;
                p_Preview.Image = CropToCircle(img);
            }
            else
            {
                panel1.BackColor = Color.FromArgb(45, 56, 70);
                p_Preview.Image = img;
            }
        }
        public static Image CropToCircle(Image image)
        {
            if (image == null)
                return (Image)default;

            if (image.Width < 1000)
            {
                image = ResizeImage((Bitmap)image, 1000, 1000);
            }

            Bitmap bm = (Bitmap)image;
            Bitmap bt = new Bitmap(bm.Width, bm.Height);
            Graphics g = Graphics.FromImage(bt);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(10, 10, bm.Width - 20, bm.Height - 20);
            g.Clear(Color.Magenta);
            g.SetClip(gp);
            g.DrawImage(bm, new Rectangle(0, 0, bm.Width, bm.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);
            g.Dispose();
            bt.MakeTransparent(Color.Magenta);
            return bt;
        }
        public static Bitmap ResizeImage(Bitmap image, int maxWidth, int maxHeight)
        {
            Bitmap result = (Bitmap)default;
            try
            {
                int width = image.Width;
                int height = image.Height;
                float val = (float)maxWidth / (float)width;
                float val2 = (float)maxHeight / (float)height;
                float num = Math.Min(val, val2);
                checked
                {
                    int width2 = (int)Math.Round((double)unchecked((float)width * num));
                    int height2 = (int)Math.Round((double)unchecked((float)height * num));
                    result = new Bitmap(width2, height2, PixelFormat.Format24bppRgb);
                    using (Graphics graphics = Graphics.FromImage(result))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, width2, height2);
                    }
                    ImageCodecInfo encoderInfo = GetEncoderInfo(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(quality, 75L);
                    encoderParameters.Param[0] = encoderParameter;
                    return result;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault((ImageCodecInfo c) => c.FormatID == format.Guid);
        }

        private void FlatButton1_Click(object sender, EventArgs e)
        {

        }

        int r_l = 0;
        private void Rotate_L_Click(object sender, EventArgs e)
        {
            r_l += 90;
            Bitmap bit = ImageHelper.RotateBitmap_NoPadding(bitmap, r_l, Color.Transparent);
            ImageCrop.Bitmap = bit;

            Rectangle rect = new Rectangle(Point.Empty, bit.Size);
            rect = EnforceAspectRatio(rect, 10);

            ImageCrop.CropRectangle = rect;
            ImageCrop.AspectRatio = AspectRatio;


        }
        public static Rectangle EnforceAspectRatio(Rectangle bounds, float aspectRatio)
        {
            Size originalSize = bounds.Size;

            float portalAspectRatio = aspectRatio;
            float imageAspectRatio = originalSize.Width / (float)originalSize.Height;

            Rectangle srcRect = new Rectangle(Point.Empty, originalSize);
            if (imageAspectRatio < portalAspectRatio)
            {
                srcRect.Height = System.Convert.ToInt32(originalSize.Width / portalAspectRatio);
                srcRect.Y = Math.Max(0, (originalSize.Height - srcRect.Height) / 2);
                srcRect.Height = Math.Min(srcRect.Height, originalSize.Height - srcRect.Y);
            }
            else
            {
                srcRect.Width = System.Convert.ToInt32(originalSize.Height * portalAspectRatio);
                srcRect.X = Math.Max(0, (originalSize.Width - srcRect.Width) / 2);
                srcRect.Width = Math.Min(srcRect.Width, originalSize.Width - srcRect.X);
            }

            srcRect.Offset(bounds.Location);
            return srcRect;
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
