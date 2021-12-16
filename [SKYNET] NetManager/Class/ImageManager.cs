using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.Common
{
    public class ImageManager 
    {
        public static Bitmap CaptureScreen()
        {
            Bitmap result = null;
            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    result = bitmap;
                }

                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }

        }
        public static Bitmap CreateLetterImage(string nickName = "")
        {
            Bitmap bitmap1 = (Bitmap)default;
            string Letter = "";

            try
            {
                foreach (char _letter in nickName)
                {
                    Letter = _letter.ToString();
                    break;
                }
                string letter = Letter.ToUpper();

                int witdh = 1000;
                int heigth = 1000;
                Bitmap bitmap2 = new Bitmap(witdh, heigth);
                Font Font = new Font("Arial", 600);

                StringFormat format = new StringFormat { Alignment = StringAlignment.Center };

                Graphics graphics = Graphics.FromImage((Image)bitmap2);

                Brush brush = (Brush)new SolidBrush(ColorTranslator.FromHtml(GetColorString(letter)));

                graphics.FillRectangle(brush, 0, 0, witdh, heigth);

                graphics.DrawString(letter, Font, new SolidBrush(Color.White), 500, 65, format);

                bitmap1 = bitmap2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return bitmap1;
        }
        private static string GetColorString(string letter)
        {
            if (letter == "Q" || letter == "D" || letter == "B")
                return "#5D4037";
            else if (letter == "W" || letter == "F" || letter == "N")
                return "#689F38";
            else if (letter == "E" || letter == "G" || letter == "M")
                return "#00897B";
            else if (letter == "R" || letter == "H" || letter == "1")
                return "#039BE5";
            else if (letter == "T" || letter == "J" || letter == "2")
                return "#F4511E";
            else if (letter == "Y" || letter == "K" || letter == "3")
                return "#78909C";
            else if (letter == "U" || letter == "L" || letter == "4")
                return "#E91E63";
            else if (letter == "I" || letter == "Ñ" || letter == "5")
                return "#EF6C00";
            else if (letter == "O" || letter == "Z" || letter == "6")
                return "#9C27B0";
            else if (letter == "P" || letter == "X" || letter == "7")
                return "#3F51B5";
            else if (letter == "A" || letter == "C" || letter == "8")
                return "#0097A7";
            else if (letter == "S" || letter == "V" || letter == "9" || letter == "0")
                return "#AB47BC";
            else
                return "#AB47BC";
        }

        public static Image CropToCircle(Image image)
        {
            if (image == null)
                return (Image)default;

            if (image.Width < 1000)
            {
                image = Resize((Bitmap)image, 1000, 1000);
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
        public static Image CropToCircleforChat(Image image, string Nick, string TEMP_PATH)
        {
            Image image1 = (Image)default;
            Bitmap bitmap = (Bitmap)default;

            try
            {
                if (image == null)
                {
                    image1 = (Image)null;
                }
                else
                {
                    int num = checked(21 * 2);
                    bitmap = new Bitmap(image.Width, image.Height);
                    using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    {
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        using (Brush brush = (Brush)new TextureBrush(image))
                        {
                            using (GraphicsPath path = new GraphicsPath())
                            {
                                path.AddArc(-1, -1, num, num, 180f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), -1, num, num, 270f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), checked(0 + bitmap.Height - num), num, num, 0.0f, 90f);
                                path.AddArc(-1, checked(0 + bitmap.Height - num), num, num, 90f, 90f);
                                graphics.FillPath(brush, path);
                            }
                        }
                        image1 = (Image)bitmap;
                    }
                    bitmap.Save(Path.Combine(TEMP_PATH, Nick + ".png"), ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return image1;
        }

        internal static byte[] ImageToBytes(Image image)
        {
            using (MemoryStream stream = new MemoryStream() )
            {
                image.Save(stream, image.RawFormat);
                return stream.ToArray();
            }
        }
        internal static Image ImageFromBytes(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            return Image.FromStream(stream);
        }

        public static Image IconFromFile(string filePath)
        {
            Image image;
            try
            {
                image = Icon.ExtractAssociatedIcon(filePath)?.ToBitmap();
            }
            catch
            {
                image = new Icon(SystemIcons.Application, 32, 32).ToBitmap();
            }
            return ResizeBitmap(image, 16, 16);
        }

        private static Bitmap ResizeBitmap(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                    return bitmap;
                }
            }
        }
        public static Image ImageFromFile(string filePath)
        {
            Image result = default(Image);
            try
            {
                Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(filePath)));
                result = new Bitmap(image, image.Size);
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bitmap4 = default(Bitmap);
            try
            {
                Bitmap bitmap = new Bitmap(img.Width, img.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                ColorMatrix newColorMatrix = new ColorMatrix
                {
                    Matrix33 = opacityvalue
                };
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                graphics.DrawImage(img, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
                graphics.Dispose();
                bitmap4 = bitmap;
                return bitmap4;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return bitmap4;
            }
        }
        public static void Resize(string sourcePath, int maxWidth, int maxHeight, string destPath)
        {
            try
            {
                Resize(new Bitmap(sourcePath), maxWidth, maxHeight, destPath);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        public static Bitmap Resize(Bitmap image, int maxWidth, int maxHeight)
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
        public static void Resize(Bitmap image, int maxWidth, int maxHeight, string destPath)
        {
            Bitmap bitmap = (Bitmap)default;

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
                    bitmap = new Bitmap(width2, height2, PixelFormat.Format24bppRgb);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
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
                    bitmap.Save(destPath, encoderInfo, encoderParameters);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }
        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault((ImageCodecInfo c) => c.FormatID == format.Guid);
        }
        public static Image ImageFromStream(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return Image.FromStream(new MemoryStream(File.ReadAllBytes(path)));
        }
        public static bool IsValidImageExtension(string filePath)
        {
            bool result = default(bool);
            try
            {
                if (!string.IsNullOrEmpty(filePath) && Path.HasExtension(filePath))
                {
                    result = new string[5]
                    {
                        "jpg",
                        "jpeg",
                        "gif",
                        "png",
                        "bmp"
                    }.Contains(Path.GetExtension(filePath).Substring(1).ToLower());
                    return result;
                }
                result = false;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }
    }
    internal class IconHelper
    {
        public enum IconSize
        {
            Large,
            Small
        }

        public enum FolderType
        {
            Open,
            Closed
        }

        public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            CustomShell32.SHFILEINFO psfi = default(CustomShell32.SHFILEINFO);
            uint num = 272u;
            checked
            {
                if (linkOverlay)
                {
                    num += 32768u;
                }
                CustomShell32.SHGetFileInfo(uFlags: (IconSize.Small != size) ? (num + 0u) : (num + 1u), pszPath: name, dwFileAttributes: 128u, psfi: ref psfi, cbFileInfo: (uint)Marshal.SizeOf(psfi));
            }
            Icon result = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            CustomUser32.DestroyIcon(psfi.hIcon);
            return result;
        }

        public static Icon GetFolderIcon(IconSize size, FolderType folderType__1)
        {
            uint num = 272u;
            CustomShell32.SHFILEINFO psfi;
            checked
            {
                if (folderType__1 == FolderType.Open)
                {
                    num += 2u;
                }
                num = ((IconSize.Small != size) ? (num + 0u) : (num + 1u));
                psfi = default(CustomShell32.SHFILEINFO);
                CustomShell32.SHGetFileInfo(null, 16u, ref psfi, (uint)Marshal.SizeOf(psfi), num);
                Icon.FromHandle(psfi.hIcon);
            }
            Icon result = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            CustomUser32.DestroyIcon(psfi.hIcon);
            return result;
        }

    }
    public class CustomShell32
    {
        public struct SHITEMID
        {
            public ushort cb;

            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;

            public IntPtr pidlRoot;

            public IntPtr pszDisplayName;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;

            public uint ulFlags;

            public IntPtr lpfn;

            public int lParam;

            public IntPtr iImage;
        }

        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;

            public IntPtr hIcon;

            public int iIcon;

            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public const int MAX_PATH = 256;

        public const uint BIF_RETURNONLYFSDIRS = 1u;

        public const uint BIF_DONTGOBELOWDOMAIN = 2u;

        public const uint BIF_STATUSTEXT = 4u;

        public const uint BIF_RETURNFSANCESTORS = 8u;

        public const uint BIF_EDITBOX = 16u;

        public const uint BIF_VALIDATE = 32u;

        public const uint BIF_NEWDIALOGSTYLE = 64u;

        public const uint BIF_USENEWUI = 80u;

        public const uint BIF_BROWSEINCLUDEURLS = 128u;

        public const uint BIF_BROWSEFORCOMPUTER = 4096u;

        public const uint BIF_BROWSEFORPRINTER = 8192u;

        public const uint BIF_BROWSEINCLUDEFILES = 16384u;

        public const uint BIF_SHAREABLE = 32768u;

        public const uint SHGFI_ICON = 256u;

        public const uint SHGFI_DISPLAYNAME = 512u;

        public const uint SHGFI_TYPENAME = 1024u;

        public const uint SHGFI_ATTRIBUTES = 2048u;

        public const uint SHGFI_ICONLOCATION = 4096u;

        public const uint SHGFI_EXETYPE = 8192u;

        public const uint SHGFI_SYSICONINDEX = 16384u;

        public const uint SHGFI_LINKOVERLAY = 32768u;

        public const uint SHGFI_SELECTED = 65536u;

        public const uint SHGFI_ATTR_SPECIFIED = 131072u;

        public const uint SHGFI_LARGEICON = 0u;

        public const uint SHGFI_SMALLICON = 1u;

        public const uint SHGFI_OPENICON = 2u;

        public const uint SHGFI_SHELLICONSIZE = 4u;

        public const uint SHGFI_PIDL = 8u;

        public const uint SHGFI_USEFILEATTRIBUTES = 16u;

        public const uint SHGFI_ADDOVERLAYS = 32u;

        public const uint SHGFI_OVERLAYINDEX = 64u;

        public const uint FILE_ATTRIBUTE_DIRECTORY = 16u;

        public const uint FILE_ATTRIBUTE_NORMAL = 128u;

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
    public class CustomUser32
    {
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }

}
