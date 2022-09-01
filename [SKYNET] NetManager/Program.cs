using Microsoft.Win32;
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
        public static bool Launched { get; private set; }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            if (!IsAdmin())
            {
                ReiniciarComoAdmin();
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
        public static void ReiniciarComoAdmin()
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
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);
        public static void PrevApplication()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SKYNET\\[SKYNET] NetManager", writable: true);
                registryKey.GetValue("Handle", RegistryValueKind.String);
                string value = (string)registryKey.GetValue("Handle");

                if (string.IsNullOrEmpty(value))
                    value = "0";
                else if (value == "")
                    value = "0";

                int num = Convert.ToInt32(value);
                if (num > 0 && IsWindow((IntPtr)num))
                {
                    //ShowWindow((IntPtr)num, 1);
                    //SetForegroundWindow((IntPtr)num);
                }
            }
            catch
            {

            }
        }

    }
}
