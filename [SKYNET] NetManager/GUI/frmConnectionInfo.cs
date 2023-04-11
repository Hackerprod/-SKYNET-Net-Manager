using SKYNET.GUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmConnectionInfo : frmBase
    {
        private List<Process> Proccesses;

        public frmConnectionInfo()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;

            Proccesses = Process.GetProcesses().ToList();
            Initialize();
        }

        private async Task Initialize()
        {
            var Ports = new List<PortClass>();

            try
            {
                using (Process p = new Process())
                {

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.Arguments = "-a -n -o";
                    ps.FileName = "netstat.exe";
                    ps.UseShellExecute = false;
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.RedirectStandardInput = true;
                    ps.RedirectStandardOutput = true;
                    ps.RedirectStandardError = true;

                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    StreamReader stdError = p.StandardError;

                    string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                    string exitStatus = p.ExitCode.ToString();

                    if (exitStatus != "0")
                    {
                        // Command Errored. Handle Here If Need Be
                    }

                    //Get The Rows
                    var Connections = Regex.Split(content, "\r\n").ToList();

                    Connections = Connections.FindAll(c => c.Contains("UDP") || c.Contains("TCP"));

                    foreach (string conn in Connections)
                    {
                        string[] tokens = Regex.Split(conn, "\\s+");

                        if (tokens.Length > 5)
                        {
                            var parts = tokens;
                            var Protocol = parts[1];
                            var LocalEndPoint = parts[2];
                            var RemoteEndPoint = parts[3];
                            var Status = parts[4];
                            var ProcessID = parts[5];
                            AddItem(Protocol, LocalEndPoint, RemoteEndPoint, Status, ProcessID);

                        }
                        else
                        {
                            var Protocol = tokens[1];
                            var LocalEndPoint = tokens[2];
                            var RemoteEndPoint = tokens[3];
                            var Status = "";
                            var ProcessID = tokens[4];

                            AddItem(Protocol, LocalEndPoint, RemoteEndPoint, Status, ProcessID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddItem(string Protocol, string LocalEndPoint, string RemoteEndPoint, string Status, string ProcessID)
        {
            var lvItem = new ListViewItem();
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

            var pName = Proccesses.Find(p => p.Id.ToString() == ProcessID);

            lvItem.SubItems[0].Text = Protocol;
            lvItem.SubItems[1].Text = LocalEndPoint;
            lvItem.SubItems[2].Text = RemoteEndPoint;
            lvItem.SubItems[3].Text = Status;
            lvItem.SubItems[4].Text = (pName == null) ? ProcessID : pName.ProcessName;

            LV_ARP.Items.Add(lvItem);
        }

        public static string LookupProcess(int pid)
        {
            string procName;
            try { procName = Process.GetProcessById(pid).ProcessName; }
            catch (Exception) { procName = "-"; }
            return procName;
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

        private void BT_Close_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }

        public class PortClass
        {
            public string name
            {
                get
                {
                    return string.Format("{0} ({1} port {2})", this.process_name, this.protocol, this.port_number);
                }
                set { }
            }
            public string port_number { get; set; }
            public string process_name { get; set; }
            public string protocol { get; set; }
        }
    }
}
