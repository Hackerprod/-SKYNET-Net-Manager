using Microsoft.VisualBasic;
using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
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
            //RunTest(); return;

            //var addr = Dns.GetHostAddresses("https://www.portal.nauta.cu/user/login/es-es");
            //Common.Show(addr[0]);

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

        public static string RunExeCommand(string commandText)
        {
            Process p = new Process();                      //Create and instantiate a class that operates a process: Process
            p.StartInfo.FileName = "cmd.exe";               //Set the application to start
            p.StartInfo.UseShellExecute = false;            //Set whether to use the operating system shell to start the process
            p.StartInfo.RedirectStandardInput = true;       //Indicates whether the application reads from the StandardInput stream
            p.StartInfo.RedirectStandardOutput = true;      //Write the application's input to the StandardOutput stream
            p.StartInfo.RedirectStandardError = true;       //Write the error output of the application to the StandardError stream
            //p.StartInfo.CreateNoWindow = true;              //Whether to start the process in a new window
            string strOutput;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);     //Write the CMD command into the StandardInput stream
                p.StandardInput.WriteLine("");              //Write the CMD command into the StandardInput stream
                p.StandardInput.WriteLine("exit");          //Write the exit command into the StandardInput stream
                strOutput = p.StandardOutput.ReadToEnd();   //Read all characters of all output streams
                p.WaitForExit();                            //Wait indefinitely until the process exits
                //p.Close();                                  //Release the process, close the process
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }

            return strOutput;
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
