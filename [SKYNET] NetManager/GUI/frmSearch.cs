using SKYNET.NetUtils;
using SKYNET.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SKYNET.Helpers;

namespace SKYNET
{
    public partial class frmSearch : frmBase
    {
        private IPScanner _scanner;
        private ImageList _ilQuality;


        private class HostSorterByIP : IComparer
        {
            public int Compare(object x, object y)
            {
                byte[] addressBytes = ((IPScanHostState)((ListViewItem)x).Tag).Address.GetAddressBytes();
                byte[] addressBytes2 = ((IPScanHostState)((ListViewItem)y).Tag).Address.GetAddressBytes();
                int num = addressBytes.Length - 1;
                while (num > 0 && addressBytes[num] == addressBytes2[num])
                {
                    num--;
                }
                return addressBytes[num] - addressBytes2[num];
            }
        }

        public frmSearch()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  

            _scanner = new IPScanner(64, 2, false, 1000, 32, false, 32);
            _scanner.OnAliveHostFound += _scanner_OnAliveHostFound;
            _scanner.OnStartScan += _scanner_OnStartScan;
            _scanner.OnStopScan += _scanner_OnStopScan;
            _scanner.OnRestartScan += _scanner_OnRestartScan;
            _scanner.OnScanProgressUpdate += _scanner_OnScanProgressUpdate;

            _lvAliveHosts.ListViewItemSorter = new HostSorterByIP();
            //_cmbRangeType.SelectedIndex = 0;

            _ilQuality = new System.Windows.Forms.ImageList(components);
            _ilQuality.TransparentColor = System.Drawing.Color.Transparent;
            //_ilQuality.Images.SetKeyName(0, "0");
            //_ilQuality.Images.SetKeyName(1, "1");
            //_ilQuality.Images.SetKeyName(2, "2");
            //_ilQuality.Images.SetKeyName(3, "3");
            //_ilQuality.Images.SetKeyName(4, "4");
            //_ilQuality.Images.SetKeyName(5, "5");
            //_ilQuality.Images.SetKeyName(6, "6");
            //_lvAliveHosts.SmallImageList = _ilQuality;

            ToolStripMenuItem Monitorear = new ToolStripMenuItem() { Text = "Monitorear equipo" };
            Monitorear.Click += Monitorear_Click;

            ToolStripMenuItem BuscarPort = new ToolStripMenuItem() { Text = "Buscar puertos abiertos" };
            BuscarPort.Click += BuscarPort_Click;

            ContextMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            ContextMenu.ForeColor = System.Drawing.Color.White;

            ContextMenu.Items.Add(Monitorear);
            ContextMenu.Items.Add(BuscarPort);

        }

        private void _scanner_OnRestartScan(IPScanner scanner)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnRestartScan), scanner);
            }
            else
            {
                _prgScanProgress.Value = 0;
            }
        }

        private void _scanner_OnScanProgressUpdate(IPScanner scanner, IPAddress currentAddress, ulong progress, ulong total)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanProgressUpdateDelegate(_scanner_OnScanProgressUpdate), scanner, currentAddress, progress, total);
            }
            else
            {
                int value = (int)(100 * progress / total);
                _prgScanProgress.Value = value;
                _prgScanProgress.Text = value.ToString() + "% [" + currentAddress.ToString() + "]";
            }
        }

        private void _scanner_OnStartScan(IPScanner scanner)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnStartScan), scanner);
            }
            else
            {
                foreach (ListViewItem item in _lvAliveHosts.Items)
                {
                    ((IPScanHostState)item.Tag).OnStateChange -= Host_OnStateChange;
                    ((IPScanHostState)item.Tag).OnHostNameAvailable -= Host_OnHostNameAvailable;
                }
                _lvAliveHosts.Items.Clear();
                _prgScanProgress.Visible = true;
                _prgScanProgress.Value = 0;
                btnSearch.Text = "Stop";
            }
        }

        private void _scanner_OnStopScan(IPScanner scanner)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnStopScan), scanner);
            }
            else
            {
                _prgScanProgress.Value = 0;
                btnSearch.Text = "Search";
                _prgScanProgress.Visible = false;
            }
        }

        private async void _scanner_OnAliveHostFound(IPScanner scanner, IPScanHostState host)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanner.AliveHostFoundDelegate(_scanner_OnAliveHostFound), scanner, host);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = host;
                //listViewItem.BackColor = Color.GreenYellow;
                listViewItem.SubItems.Add(host.Address.ToString());
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add("");
                _lvAliveHosts.Items.Add(listViewItem);
                _lvAliveHosts.Sort();
                host.OnHostNameAvailable += Host_OnHostNameAvailable;
                host.OnStateChange += Host_OnStateChange;
                if (!host.IsTesting())
                {
                    listViewItem.ImageIndex = (int)host.QualityCategory;
                    listViewItem.SubItems[2].Text = host.AvgResponseTime.ToString("F02") + " ms";
                    listViewItem.SubItems[3].Text = ((float)host.LossCount / (float)host.PingsCount).ToString("P");
                    listViewItem.SubItems[4].Text = host.HostName;
                    listViewItem.SubItems[5].Text = await NetHelper.GetMACAddress(host.RemoteAddress);
                }
                Timer timer = new Timer();
                timer.Tag = listViewItem;
                timer.Interval = 2000;
                timer.Tick += NewTimer_Tick;
                timer.Enabled = true;
            }
        }

        private void Host_OnStateChange(IPScanHostState host, IPScanHostState.State oldState)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanHostState.StateChangeDelegate(Host_OnStateChange), host, oldState);
            }
            else if (!host.IsTesting())
            {
                ListViewItem listViewItem = FindListViewItem(host);
                if (listViewItem != null)
                {
                    if (host.IsAlive())
                    {
                        listViewItem.ImageIndex = (int)host.QualityCategory;
                        listViewItem.SubItems[2].Text = host.AvgResponseTime.ToString("F02") + " ms";
                        listViewItem.SubItems[3].Text = ((float)host.LossCount / (float)host.PingsCount).ToString("P");
                    }
                    else
                    {
                        host.OnStateChange -= Host_OnStateChange;
                        host.OnHostNameAvailable -= Host_OnHostNameAvailable;
                        //listViewItem.BackColor = Color.IndianRed;
                        Timer timer = new Timer();
                        timer.Tag = listViewItem;
                        timer.Interval = 2000;
                        timer.Tick += RemoveTimer_Tick;
                        timer.Enabled = true;
                    }
                }
            }
        }

        private void RemoveTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            timer.Tick -= NewTimer_Tick;
            ListViewItem item = (ListViewItem)timer.Tag;
            _lvAliveHosts.Items.Remove(item);
        }

        private void NewTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            timer.Tick -= NewTimer_Tick;
            ListViewItem listViewItem = (ListViewItem)timer.Tag;
            //listViewItem.BackColor = Color.White;
        }

        private void Host_OnHostNameAvailable(IPScanHostState host)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new IPScanHostState.HostNameAvailableDelegate(Host_OnHostNameAvailable), host);
            }
            else
            {
                ListViewItem listViewItem = FindListViewItem(host);
                if (listViewItem != null)
                {
                    listViewItem.SubItems[4].Text = host.HostName;
                }
            }
        }

        private ListViewItem FindListViewItem(IPScanHostState host)
        {
            foreach (ListViewItem item in _lvAliveHosts.Items)
            {
                if (item.Tag == host)
                {
                    return item;
                }
            }
            return null;
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            foreach (var ip in GetAllIp())
            {
                IP_Ranges.Items.Add(ip);
            }
            if (IP_Ranges.Items.Count > 0)
            {
                IP_Ranges.SelectedIndex = IP_Ranges.Items.Count - 1;
            }
            IPbox.Text = GetIp();
            btnSearch.Focus(); 
        }

        public static string GetIp()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            IPAddress ipaddress = null;
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddress = item;
                }
            }
            return ipaddress.ToString();
        }

        public static IEnumerable<string> GetAllIp()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    yield return item.ToString();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IPAddress.TryParse(IPbox.Text, out var address))
                {
                    Common.Show($"The IP Address {IPbox.Text} is not valid.");
                    return;
                }

                var FirstIPAddress = NetHelper.GetFirstIPAddress(address);
                var LastIPAddress = NetHelper.GetLastIPAddress(FirstIPAddress);

                _scanner.Start(new IPScanRange(FirstIPAddress, LastIPAddress));
            }
            catch (FormatException)
            {
                MessageBox.Show(this, "Cannot parse IP range or subnetmask!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void _lvAliveHosts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string IP = _lvAliveHosts.SelectedItems[0].SubItems[1].Text;
                string Host = _lvAliveHosts.SelectedItems[0].SubItems[4].Text;
                string mac = _lvAliveHosts.SelectedItems[0].SubItems[5].Text;

                frmDeviceManager Manager = new frmDeviceManager(new Host() { HostName = Host, IPAddress = IPAddress.Parse(IP), MAC = mac });
                Manager.Show();
            }
            catch {}
        }

        private void _lvAliveHosts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Rectangle cellDisplayRectangle = ((ListView)sender).ClientRectangle;
                ContextMenu.Show(((ListView)sender), cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
            }
        }

        private void BuscarPort_Click(object sender, EventArgs e)
        {
            string IP = _lvAliveHosts.SelectedItems[0].SubItems[1].Text;

            if (IPAddress.TryParse(IP, out var Address))
            {
                new frmPortScan(Address).ShowDialog();
            }
        }

        private void Monitorear_Click(object sender, EventArgs e)
        {
            string IP = _lvAliveHosts.SelectedItems[0].SubItems[1].Text;
            string Host = _lvAliveHosts.SelectedItems[0].SubItems[4].Text;
            string mac = _lvAliveHosts.SelectedItems[0].SubItems[5].Text;

            frmDeviceManager Manager = new frmDeviceManager(new Host() { HostName = Host, IPAddress = IPAddress.Parse(IP), MAC = mac, Interval = 1 });
            Manager.Show();

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

        private void IP_Ranges_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPbox.Text = IP_Ranges.Text;
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
