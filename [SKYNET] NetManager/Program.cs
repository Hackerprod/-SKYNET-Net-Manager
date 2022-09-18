using Microsoft.VisualBasic;
using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SKYNET
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);

        public static bool Launched { get; set; }


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.ThreadException += UIThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            if (!IsAdmin())
            {
                RestartAsAdmin();
            }

            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (processes.Length > 1)
            {
                PrevApplication();
            }
            else
            {
                Common.InitialiceApplication();
            }
        }

        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
            }
            catch { }
            Process.GetCurrentProcess().Kill();
        }

        public static void PrevApplication()
        {
            try
            {
                RegistrySettings settings = new RegistrySettings(@"SOFTWARE\SKYNET\[SKYNET] NetManager\");
                var handle = settings.Get<long>("Handle", 0);
                IntPtr Handle = new IntPtr(handle);
                if (Handle != IntPtr.Zero && IsWindow(Handle))
                {
                    ShowWindow(Handle, (int)AppWinStyle.MaximizedFocus);
                    ShowWindow(Handle, (int)AppWinStyle.NormalFocus);
                    SetForegroundWindow(Handle);
                }
            }
            catch
            {
            }
        }

        #region Log system

        private static object file_lock = new object();
        private static List<string> buffered = new List<string>();

        public static void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs t)
        {
            WriteException(t.Exception);
        }

        public static void UnhandledExceptionHandler(object sender, System.UnhandledExceptionEventArgs t)
        {
            WriteException(t.ExceptionObject);
        }

        public static void WriteException(object msg)
        {
            if (msg is Exception)
            {
                Exception ex = (Exception)msg;

                string filePath = Path.Combine(Common.GetPath(), "Data", "[SKYNET] NetManager.log");

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(msg);
                string formatted = string.Format(string.Format("{0}:", stringBuilder.ToString()));
                var taken = false;

                Monitor.TryEnter(file_lock, ref taken);

                if (taken)
                {
                    buffered.Add(formatted);
                    File.AppendAllLines(filePath, buffered);
                    buffered.Clear();

                    Monitor.Exit(file_lock);
                }
            }
        }

        #endregion

    }
}
