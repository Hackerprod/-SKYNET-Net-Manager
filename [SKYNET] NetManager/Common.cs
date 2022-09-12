using Microsoft.VisualBasic.CompilerServices;
using SKYNET;
using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Common
{
    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetForegroundWindow();


    public static bool IsActiveMainWindow()
    {
        return (IntPtr)GetForegroundwindowHandle() == frmMain.frm.Handle;
    }

    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
    public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

    public static void MoveToTopMost(IntPtr handle)
    {
        SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
    }

    public static long GetForegroundwindowHandle()
    {
        return (long)GetForegroundWindow();
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    private const int WM_VSCROLL = 277;
    private const int SB_PAGEBOTTOM = 7;

    public static void ScrollToBottom(RichTextBox MyRichTextBox)
    {
        SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
    }

    public static void InvokeAction(Control control, Action Action)
    {
        control.Invoke(Action);
    }

    public static List<MacIpPair> GetAllMacAddressesAndIppairs()
    {
        List<MacIpPair> mip = new List<MacIpPair>();
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = "arp";
        pProcess.StartInfo.Arguments = "-a ";
        pProcess.StartInfo.UseShellExecute = false;
        pProcess.StartInfo.RedirectStandardOutput = true;
        pProcess.StartInfo.CreateNoWindow = true;
        pProcess.Start();
        string cmdOutput = pProcess.StandardOutput.ReadToEnd();
        string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

        foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
        {
            mip.Add(new MacIpPair()
            {
                MacAddress = m.Groups["mac"].Value,
                IpAddress = m.Groups["ip"].Value
            });
        }

        return mip;
    }

    internal static string BoolToString(bool text)
    {
        switch (text)
        {
            case true:
                return "1";
            case false:
                return "0";
        }
        return "1";
    }

    public struct MacIpPair
    {
        public string MacAddress;
        public string IpAddress;
    }
    public static string GetHostName(string ipAddress)
    {
        try
        {
            IPHostEntry entry = Dns.GetHostEntry(ipAddress);
            if (entry != null)
            {
                return entry.HostName;
            }
        }
        catch
        {
            //unknown host or
            //not every IP has a name
            //log exception (manage it)
        }

        return null;
    }
    internal static string FirstUpper(string text)
    {
        string result = "";
        for (int i = 0; i < text.Count(); i++)
        {
            if (i == 0)
                result += text[i].ToString().ToUpper();
            else
                result += text[i].ToString().ToLower();
        }
        return result;
    }
    internal static bool GetBool(string boolean)
    {
        switch (boolean.ToLower())
        {
            case "1":
                return true;
            case "true":
                return true;
            case "0":
                return false;
            case "false":
                return false;
            default:
                return false;
        }
    }

    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReversedValue);
    internal static bool IsCableConnected()
    {
        return InternetGetConnectedState(out int Conn, 0);
    }

    internal static void Show(object v = null, frmMessage.TypeMessage type = frmMessage.TypeMessage.Normal, string header = "", IPAddress ipaddress = null)
    {
        //if (v == null)
        //    return;
        frmMessage frm = new frmMessage(v.ToString(), type, header, ipaddress);
        frm.ShowDialog();
    }

    internal static void Write(object ticks)
    {
        frmMain.frm.Write(ticks);
    }

    internal static void Save(string text)
    {
        File.WriteAllText("Saved.txt", text);
    }
    public static SizeF GetTextSize(string text, Font font)
    {
        using (Graphics graphics = Graphics.FromImage((Image)new Bitmap(1, 1)))
            return graphics.MeasureString(text, font);
    }
    internal static List<string> ReadAllLines(string FilePath)
    {
        List<string> result = new List<string>();
        var file = File.ReadAllBytes(FilePath);
        string text = Encoding.Default.GetString(file);
        TextBox structure = new TextBox
        {
            Text = text
        };
        for (int i = 0; i < structure.Lines.Count(); i++)
        {
            result.Add(structure.Lines[i]);
        }
        return result;
    }

    internal static void ShowBars(bool @checked)
    {
        Settings.ShowTopPanel = @checked;
        frmMain.frm.TopPanel.Visible = @checked;
        frmMain.frm.PanelBottom.Visible = @checked;

    }

    internal static void WriteAllLines(string FilePath, List<string> line)
    {
        string content = "";
        for (int i = 0; i < line.Count; i++)
        {
            if (i == line.Count - 1)
            {
                content += line[i];
            }
            else
                content += line[i] + Environment.NewLine;
        }
        var file = Encoding.Default.GetBytes(content);
        FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate);
        stream.Write(file, 0, file.Length);
        stream.Close();
    }

    private static Image image1;
    private static Bitmap bitmap;

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
            Exception ex2 = ex;
            return result;
        }
    }
    public static Image CropToCircle(Image image)
    {
        try
        {
            if (image == null)
            {
                image1 = (Image)null;
            }
            else
            {
                int num = checked(image.Width);
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
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
            }
        }
        catch
        {
        }
        return image1;
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

    public static void Resize(Bitmap image, int maxWidth, int maxHeight, string destPath)
    {
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
    public static string ConvertHtmlTotext(string source)
    {
        try
        {
            string result;

            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            result = source.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating spaces because browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                  @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*head([^>])*>", "<head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*head( )*>)", "</head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<head>).*(</head>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*script([^>])*>", "<script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*script( )*>)", "</script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result,
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty,
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<script>).*(</script>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*style([^>])*>", "<style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*style( )*>)", "</style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<style>).*(</style>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*td([^>])*>", "\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*br( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*li( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*div([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*tr([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*p([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything that's enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<[^>]*>", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @" ", " ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&bull;", " * ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&lsaquo;", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&rsaquo;", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&trade;", "(tm)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&frasl;", "/",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&lt;", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&gt;", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&copy;", "(c)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&reg;", "(r)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see
            // http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&(.{2,6});", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // for testing
            //System.Text.RegularExpressions.Regex.Replace(result,
            //       this.txtRegex.Text,string.Empty,
            //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4.
            // Prepare first to remove any whitespaces in between
            // the escaped characters and remove redundant tabs in between line breaks
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\t)", "\t\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\r)", "\t\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\t)", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove multiple tabs following a line break with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Initial replacement target string for line breaks
            string breaks = "\r\r\r";
            // Initial replacement target string for tabs
            string tabs = "\t\t\t\t\t";
            for (int index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // That's it.
            return result;
        }
        catch
        {
            MessageBox.Show("Error");
            return source;
        }

    }
    static Process currentProcess;
    public static string GetPatch()
    {
        try
        {
            currentProcess = Process.GetCurrentProcess();
            return new FileInfo(currentProcess.MainModule.FileName).Directory.FullName;
        }
        finally
        {
            currentProcess = null;
        }
    }

    public static string CurrentDirectory
    {
        get
        {
            Process currentProcess = Process.GetCurrentProcess();
            return new FileInfo(currentProcess.MainModule.FileName).Directory.FullName;
        }
    }

    public static frmSplashScreen SplashScreen { get; set; }
    public static bool Hackerprod { get { return Environment.UserName == "Hackerprod"; } }

    public static bool ShowShadow { get; internal set; }

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
            Exception ex2 = ex;
            return bitmap4;
        }
    }
    public static void ReleaseMemory()
    {
        try
        {
            SetProcessWorkingSetSize(GetCurrentProcess(), -1, -1);
        }
        catch (Exception exception1)
        {
            object obj1 = exception1;
            ProjectData.SetProjectError((Exception)obj1);
            Exception exception = (Exception)obj1;
            ProjectData.ClearProjectError();
        }
    }

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern IntPtr GetCurrentProcess();


    // Manejo del SplashScreen
    ///////////////////////////////////////////////////////////////////////////
    public static bool CloseSplash = false;
    public static bool ShowMain = false;
    static IDisposable splashScreen;
    static frmSplashScreen splashScreenForm;
    internal static void InitialiceApplication()
    {
        splashScreen = null;
        splashScreenForm = new frmSplashScreen();
        splashScreenForm.ShowSplashScreen();
        splashScreen = new FormSplashScreen(splashScreenForm);

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 100;
        timer.Tick += Timer_Tick;
        timer.Enabled = true;
        timer.Start();
        Application.Run(new frmBack());

    }

    private static void Timer_Tick(object sender, EventArgs e)
    {
        if (CloseSplash)
        {
            splashScreen.Dispose();
            ((System.Windows.Forms.Timer)sender).Enabled = false;
        }
    }

    public static string LongToMbytes(long lBytes)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string str1 = "Bytes";
        if (lBytes > 1024L)
        {
            string str2;
            float num;
            if (lBytes < 1048576L)
            {
                str2 = "KB";
                num = Convert.ToSingle(lBytes) / 1024f;
            }
            else
            {
                str2 = "MB";
                num = Convert.ToSingle(lBytes) / 1048576f;
            }
            stringBuilder.AppendFormat("{0:0.0} {1}", (object)num, (object)str2);
        }
        else
        {
            float num = Convert.ToSingle(lBytes);
            stringBuilder.AppendFormat("{0:0} {1}", (object)num, (object)str1);
        }
        return stringBuilder.ToString();
    }

    ///////////////////////////////////////////////////////////////////////////
}
