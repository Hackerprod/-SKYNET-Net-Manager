using Microsoft.VisualBasic;
using Microsoft.Win32;
using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
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
    }
}
