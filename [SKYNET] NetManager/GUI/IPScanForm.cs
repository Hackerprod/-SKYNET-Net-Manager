using NetUtils;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace NetPinger
{
	public class IPScanForm : Form
	{
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

		private IPScanner _scanner;

		private ListViewItem.ListViewSubItem _activeTooltipSubitem;

		private static string[] QualityCategoryNames = new string[7]
		{
			"Very Poor",
			"Poor",
			"Fair",
			"Good",
			"Very Good",
			"Excellent",
			"Perfect"
		};

		private IContainer components;

		private SplitContainer _splMaster;

		private ListBox _lbLog;

		private ListView _lvAliveHosts;

		private ColumnHeader _colQuality;

		private ColumnHeader _colIPAddress;

		private ColumnHeader _colAvgResponseTime;

		private Button _btnAddHost;

		private Button _btnTrace;

		private Button _btnStartStop;

		private Label _lRangeSep;

		private TextBox _tbRangeEnd;

		private TextBox _tbRangeStart;

		private ComboBox _cmbRangeType;

		private NumericUpDown _spnBufferSize;

		private NumericUpDown _spnTTL;

		private NumericUpDown _spnTimeout;

		private Label label3;

		private CheckBox _cbDontFragment;

		private Label label5;

		private Label label4;

		private Label label6;

		private NumericUpDown _spnPingsPerScan;

		private NumericUpDown _spnConcurrentPings;

		private Label label7;

		private CheckBox _cbContinuousScan;

		private Label _lRangeEnd;

		private Label label9;

		private Label label8;

		private ImageList _ilQuality;

		private ProgressBar _prgScanProgress;

		private ColumnHeader _colLosses;

		private ColumnHeader _colHostName;

		private ToolTip _ttQuality;

		public IPScanForm()
		{
			InitializeComponent();
			_scanner = new IPScanner((int)_spnConcurrentPings.Value, (int)_spnPingsPerScan.Value, _cbContinuousScan.Checked, (int)_spnTimeout.Value, (int)_spnTTL.Value, _cbDontFragment.Checked, (int)_spnBufferSize.Value);
			_scanner.OnAliveHostFound += _scanner_OnAliveHostFound;
			_scanner.OnStartScan += _scanner_OnStartScan;
			_scanner.OnStopScan += _scanner_OnStopScan;
			_scanner.OnRestartScan += _scanner_OnRestartScan;
			_scanner.OnScanProgressUpdate += _scanner_OnScanProgressUpdate;
			_lvAliveHosts.ListViewItemSorter = new HostSorterByIP();
			_cmbRangeType.SelectedIndex = 0;
		}

		private void _scanner_OnAliveHostFound(IPScanner scanner, IPScanHostState host)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new IPScanner.AliveHostFoundDelegate(_scanner_OnAliveHostFound), scanner, host);
			}
			else
			{
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Tag = host;
				listViewItem.BackColor = Color.GreenYellow;
				listViewItem.SubItems.Add(host.Address.ToString());
				listViewItem.SubItems.Add("");
				listViewItem.SubItems.Add("");
				listViewItem.SubItems.Add("");
				_lvAliveHosts.Items.Add(listViewItem);
				_lvAliveHosts.Sort();
				host.OnHostNameAvailable += host_OnHostNameAvailable;
				host.OnStateChange += host_OnStateChange;
				if (!host.IsTesting())
				{
					listViewItem.ImageIndex = (int)host.QualityCategory;
					listViewItem.SubItems[2].Text = host.AvgResponseTime.ToString("F02") + " ms";
					listViewItem.SubItems[3].Text = ((float)host.LossCount / (float)host.PingsCount).ToString("P");
					listViewItem.SubItems[4].Text = host.HostName;
				}
				AddLogEntry("Host [" + host.Address.ToString() + "] is alive.");
				Timer timer = new Timer();
				timer.Tag = listViewItem;
				timer.Interval = 2000;
				timer.Tick += newTimer_Tick;
				timer.Enabled = true;
			}
		}

		private void host_OnHostNameAvailable(IPScanHostState host)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new IPScanHostState.HostNameAvailableDelegate(host_OnHostNameAvailable), host);
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

		private void newTimer_Tick(object sender, EventArgs e)
		{
			Timer timer = (Timer)sender;
			timer.Stop();
			timer.Tick -= newTimer_Tick;
			ListViewItem listViewItem = (ListViewItem)timer.Tag;
			listViewItem.BackColor = Color.White;
		}

		private void host_OnStateChange(IPScanHostState host, IPScanHostState.State oldState)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new IPScanHostState.StateChangeDelegate(host_OnStateChange), host, oldState);
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
						AddLogEntry("Host [" + host.Address.ToString() + "] died.");
						host.OnStateChange -= host_OnStateChange;
						host.OnHostNameAvailable -= host_OnHostNameAvailable;
						listViewItem.BackColor = Color.IndianRed;
						Timer timer = new Timer();
						timer.Tag = listViewItem;
						timer.Interval = 2000;
						timer.Tick += removeTimer_Tick;
						timer.Enabled = true;
					}
				}
			}
		}

		private void removeTimer_Tick(object sender, EventArgs e)
		{
			Timer timer = (Timer)sender;
			timer.Stop();
			timer.Tick -= newTimer_Tick;
			ListViewItem item = (ListViewItem)timer.Tag;
			_lvAliveHosts.Items.Remove(item);
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

		private void EnableSettings(bool enable)
		{
			ComboBox cmbRangeType = _cmbRangeType;
			TextBox tbRangeStart = _tbRangeStart;
			TextBox tbRangeEnd = _tbRangeEnd;
			NumericUpDown spnTimeout = _spnTimeout;
			NumericUpDown spnTTL = _spnTTL;
			NumericUpDown spnBufferSize = _spnBufferSize;
			CheckBox cbDontFragment = _cbDontFragment;
			NumericUpDown spnConcurrentPings = _spnConcurrentPings;
			NumericUpDown spnPingsPerScan = _spnPingsPerScan;
			bool flag2 = _cbContinuousScan.Enabled = enable;
			bool flag4 = spnPingsPerScan.Enabled = flag2;
			bool flag6 = spnConcurrentPings.Enabled = flag4;
			bool flag8 = cbDontFragment.Enabled = flag6;
			bool flag10 = spnBufferSize.Enabled = flag8;
			bool flag12 = spnTTL.Enabled = flag10;
			bool flag14 = spnTimeout.Enabled = flag12;
			bool flag16 = tbRangeEnd.Enabled = flag14;
			bool enabled = tbRangeStart.Enabled = flag16;
			cmbRangeType.Enabled = enabled;
			_btnStartStop.Text = (enable ? "&Start" : "&Stop");
			if (enable)
			{
				_prgScanProgress.Text = "Scanner is not running!";
			}
		}

		private void AddLogEntry(string message)
		{
			_lbLog.Items.Add(DateTime.Now.ToString("[HH:mm:ss]: ") + message);
			_lbLog.TopIndex = _lbLog.Items.Count - _lbLog.Height / _lbLog.ItemHeight;
		}

		private void _scanner_OnStopScan(IPScanner scanner)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnStopScan), scanner);
			}
			else
			{
				EnableSettings(enable: true);
				AddLogEntry("Scanning has been stopped!");
				AddLogEntry("Hosts found: " + _scanner.AliveHosts.Count);
				_prgScanProgress.Value = 0;
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
					((IPScanHostState)item.Tag).OnStateChange -= host_OnStateChange;
					((IPScanHostState)item.Tag).OnHostNameAvailable -= host_OnHostNameAvailable;
				}
				_lvAliveHosts.Items.Clear();
				_lbLog.Items.Clear();
				Button btnAddHost = _btnAddHost;
				bool enabled = _btnTrace.Enabled = false;
				btnAddHost.Enabled = enabled;
				AddLogEntry("Scanning has been started!");
				_prgScanProgress.Value = 0;
				EnableSettings(enable: false);
			}
		}

		private void _scanner_OnRestartScan(IPScanner scanner)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnRestartScan), scanner);
			}
			else
			{
				AddLogEntry("Scan pass has been finished!");
				AddLogEntry("Hosts found: " + _scanner.AliveHosts.Count);
				AddLogEntry("Restarting Scan!");
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

		private void _cmbRangeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_cmbRangeType.SelectedIndex == 0)
			{
				_lRangeSep.Text = "-";
				_lRangeEnd.Text = "Range &End:";
				_tbRangeEnd.Size = new Size(130, _tbRangeEnd.Size.Height);
			}
			else
			{
				_lRangeSep.Text = "/";
				_lRangeEnd.Text = "Subnet &Mask:";
				_tbRangeEnd.Size = new Size(32, _tbRangeEnd.Size.Height);
			}
		}

		private void _spnTimeout_ValueChanged(object sender, EventArgs e)
		{
			_scanner.Timeout = (int)_spnTimeout.Value;
		}

		private void _spnTTL_ValueChanged(object sender, EventArgs e)
		{
			_scanner.TTL = (int)_spnTTL.Value;
		}

		private void _spnBufferSize_ValueChanged(object sender, EventArgs e)
		{
			_scanner.PingBufferSize = (int)_spnBufferSize.Value;
		}

		private void _cbDontFragment_CheckedChanged(object sender, EventArgs e)
		{
			_scanner.DontFragment = _cbDontFragment.Checked;
		}

		private void _spnConcurrentPings_ValueChanged(object sender, EventArgs e)
		{
			_scanner.ConcurrentPings = (int)_spnConcurrentPings.Value;
		}

		private void _spnPingsPerScan_ValueChanged(object sender, EventArgs e)
		{
			_scanner.PingsPerScan = (int)_spnPingsPerScan.Value;
		}

		private void _cbContinuousScan_CheckedChanged(object sender, EventArgs e)
		{
			_scanner.ContinuousScan = _cbContinuousScan.Checked;
		}

		private void _btnStartStop_Click(object sender, EventArgs e)
		{
			if (!_scanner.Active)
			{
				try
				{
					_scanner.Start((_cmbRangeType.SelectedIndex == 0) ? new IPScanRange(IPAddress.Parse(_tbRangeStart.Text), IPAddress.Parse(_tbRangeEnd.Text)) : new IPScanRange(IPAddress.Parse(_tbRangeStart.Text), int.Parse(_tbRangeEnd.Text)));
				}
				catch (FormatException)
				{
					MessageBox.Show(this, "Cannot parse IP range or subnetmask!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				_scanner.Stop(wait: false);
			}
		}

		private void _btnAddHost_Click(object sender, EventArgs e)
		{
			IPScanHostState iPScanHostState = (IPScanHostState)_lvAliveHosts.SelectedItems[0].Tag;
			HostPinger host = new HostPinger(iPScanHostState.HostName, iPScanHostState.Address);
			//((PingForm)base.Owner).AddNewHost(host);
		}

		private void _btnTrace_Click(object sender, EventArgs e)
		{
			IPScanHostState iPScanHostState = (IPScanHostState)_lvAliveHosts.SelectedItems[0].Tag;
			//IPTraceForm iPTraceForm = new IPTraceForm();
			//iPTraceForm.Target = iPScanHostState.Address.ToString();
			//iPTraceForm.ShowDialog(this);
		}

		private void _lvAliveHosts_SelectedIndexChanged(object sender, EventArgs e)
		{
			Button btnAddHost = _btnAddHost;
			bool enabled = _btnTrace.Enabled = !(_lvAliveHosts.SelectedItems.Count == 0);
			btnAddHost.Enabled = enabled;
		}

		private void _lvAliveHosts_DoubleClick(object sender, EventArgs e)
		{
			_btnAddHost_Click(sender, e);
		}

		private void IPScanForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_scanner.Stop(wait: true);
		}

		private void _lvAliveHosts_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem item = _lvAliveHosts.HitTest(e.Location).Item;
			if (item != null)
			{
				ListViewItem.ListViewSubItem subItem = _lvAliveHosts.HitTest(e.Location).SubItem;
				if (subItem != null && item.SubItems.IndexOf(subItem) == 0)
				{
					if (_activeTooltipSubitem != subItem)
					{
						_ttQuality.Show("Quality: " + QualityCategoryNames[item.ImageIndex], _lvAliveHosts, item.SubItems[1].Bounds.X, subItem.Bounds.Y);
						_activeTooltipSubitem = subItem;
					}
					return;
				}
			}
			_activeTooltipSubitem = null;
			_ttQuality.Hide(_lvAliveHosts);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(NetPinger.IPScanForm));
			_splMaster = new System.Windows.Forms.SplitContainer();
			_lRangeEnd = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			_cbContinuousScan = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			_spnPingsPerScan = new System.Windows.Forms.NumericUpDown();
			_spnConcurrentPings = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			_cbDontFragment = new System.Windows.Forms.CheckBox();
			_spnBufferSize = new System.Windows.Forms.NumericUpDown();
			_spnTTL = new System.Windows.Forms.NumericUpDown();
			_spnTimeout = new System.Windows.Forms.NumericUpDown();
			_lRangeSep = new System.Windows.Forms.Label();
			_tbRangeEnd = new System.Windows.Forms.TextBox();
			_tbRangeStart = new System.Windows.Forms.TextBox();
			_cmbRangeType = new System.Windows.Forms.ComboBox();
			_btnStartStop = new System.Windows.Forms.Button();
			_prgScanProgress = new ProgressBar();
			_btnAddHost = new System.Windows.Forms.Button();
			_btnTrace = new System.Windows.Forms.Button();
			_lbLog = new System.Windows.Forms.ListBox();
			_lvAliveHosts = new ListView();
			_colQuality = new System.Windows.Forms.ColumnHeader();
			_colIPAddress = new System.Windows.Forms.ColumnHeader();
			_colAvgResponseTime = new System.Windows.Forms.ColumnHeader();
			_colLosses = new System.Windows.Forms.ColumnHeader();
			_colHostName = new System.Windows.Forms.ColumnHeader();
			_ilQuality = new System.Windows.Forms.ImageList(components);
			_ttQuality = new System.Windows.Forms.ToolTip(components);
			_splMaster.Panel1.SuspendLayout();
			_splMaster.Panel2.SuspendLayout();
			_splMaster.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)_spnPingsPerScan).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spnConcurrentPings).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spnBufferSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spnTTL).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spnTimeout).BeginInit();
			SuspendLayout();
			_splMaster.Dock = System.Windows.Forms.DockStyle.Fill;
			_splMaster.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			_splMaster.IsSplitterFixed = true;
			_splMaster.Location = new System.Drawing.Point(0, 0);
			_splMaster.Name = "_splMaster";
			_splMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;
			_splMaster.Panel1.Controls.Add(_lRangeEnd);
			_splMaster.Panel1.Controls.Add(label9);
			_splMaster.Panel1.Controls.Add(label8);
			_splMaster.Panel1.Controls.Add(_cbContinuousScan);
			_splMaster.Panel1.Controls.Add(label7);
			_splMaster.Panel1.Controls.Add(label6);
			_splMaster.Panel1.Controls.Add(_spnPingsPerScan);
			_splMaster.Panel1.Controls.Add(_spnConcurrentPings);
			_splMaster.Panel1.Controls.Add(label5);
			_splMaster.Panel1.Controls.Add(label4);
			_splMaster.Panel1.Controls.Add(label3);
			_splMaster.Panel1.Controls.Add(_cbDontFragment);
			_splMaster.Panel1.Controls.Add(_spnBufferSize);
			_splMaster.Panel1.Controls.Add(_spnTTL);
			_splMaster.Panel1.Controls.Add(_spnTimeout);
			_splMaster.Panel1.Controls.Add(_lRangeSep);
			_splMaster.Panel1.Controls.Add(_tbRangeEnd);
			_splMaster.Panel1.Controls.Add(_tbRangeStart);
			_splMaster.Panel1.Controls.Add(_cmbRangeType);
			_splMaster.Panel1.Controls.Add(_btnStartStop);
			_splMaster.Panel2.Controls.Add(_prgScanProgress);
			_splMaster.Panel2.Controls.Add(_btnAddHost);
			_splMaster.Panel2.Controls.Add(_btnTrace);
			_splMaster.Panel2.Controls.Add(_lbLog);
			_splMaster.Panel2.Controls.Add(_lvAliveHosts);
			_splMaster.Size = new System.Drawing.Size(470, 462);
			_splMaster.SplitterDistance = 160;
			_splMaster.TabIndex = 0;
			_lRangeEnd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_lRangeEnd.AutoSize = true;
			_lRangeEnd.Location = new System.Drawing.Point(230, 13);
			_lRangeEnd.Name = "_lRangeEnd";
			_lRangeEnd.Size = new System.Drawing.Size(64, 13);
			_lRangeEnd.TabIndex = 4;
			_lRangeEnd.Text = "Range &End:";
			label9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(85, 13);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(67, 13);
			label9.TabIndex = 2;
			label9.Text = "&Range Start:";
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(9, 13);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(34, 13);
			label8.TabIndex = 0;
			label8.Text = "T&ype:";
			_cbContinuousScan.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_cbContinuousScan.AutoSize = true;
			_cbContinuousScan.Location = new System.Drawing.Point(299, 109);
			_cbContinuousScan.Name = "_cbContinuousScan";
			_cbContinuousScan.Size = new System.Drawing.Size(107, 17);
			_cbContinuousScan.TabIndex = 17;
			_cbContinuousScan.Text = "Co&ntinuous Scan";
			_cbContinuousScan.UseVisualStyleBackColor = true;
			_cbContinuousScan.CheckedChanged += new System.EventHandler(_cbContinuousScan_CheckedChanged);
			label7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(184, 85);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(109, 13);
			label7.TabIndex = 15;
			label7.Text = "&Pings Per Scan Pass:";
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(202, 59);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(91, 13);
			label6.TabIndex = 13;
			label6.Text = "&Concurrent Pings:";
			_spnPingsPerScan.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_spnPingsPerScan.Location = new System.Drawing.Point(299, 83);
			_spnPingsPerScan.Maximum = new decimal(new int[4]
			{
				32,
				0,
				0,
				0
			});
			_spnPingsPerScan.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			_spnPingsPerScan.Name = "_spnPingsPerScan";
			_spnPingsPerScan.Size = new System.Drawing.Size(64, 20);
			_spnPingsPerScan.TabIndex = 16;
			_spnPingsPerScan.Value = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			_spnPingsPerScan.ValueChanged += new System.EventHandler(_spnPingsPerScan_ValueChanged);
			_spnConcurrentPings.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_spnConcurrentPings.Location = new System.Drawing.Point(299, 57);
			_spnConcurrentPings.Maximum = new decimal(new int[4]
			{
				256,
				0,
				0,
				0
			});
			_spnConcurrentPings.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			_spnConcurrentPings.Name = "_spnConcurrentPings";
			_spnConcurrentPings.Size = new System.Drawing.Size(64, 20);
			_spnConcurrentPings.TabIndex = 14;
			_spnConcurrentPings.Value = new decimal(new int[4]
			{
				64,
				0,
				0,
				0
			});
			_spnConcurrentPings.ValueChanged += new System.EventHandler(_spnConcurrentPings_ValueChanged);
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(19, 109);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 13);
			label5.TabIndex = 10;
			label5.Text = "&Buffer Size:";
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(52, 85);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(30, 13);
			label4.TabIndex = 8;
			label4.Text = "TT&L:";
			label3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(34, 59);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(48, 13);
			label3.TabIndex = 6;
			label3.Text = "&Timeout:";
			_cbDontFragment.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_cbDontFragment.AutoSize = true;
			_cbDontFragment.Location = new System.Drawing.Point(88, 135);
			_cbDontFragment.Name = "_cbDontFragment";
			_cbDontFragment.Size = new System.Drawing.Size(98, 17);
			_cbDontFragment.TabIndex = 12;
			_cbDontFragment.Text = "&Don't Fragment";
			_cbDontFragment.UseVisualStyleBackColor = true;
			_cbDontFragment.CheckedChanged += new System.EventHandler(_cbDontFragment_CheckedChanged);
			_spnBufferSize.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_spnBufferSize.Location = new System.Drawing.Point(88, 109);
			_spnBufferSize.Maximum = new decimal(new int[4]
			{
				256,
				0,
				0,
				0
			});
			_spnBufferSize.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			_spnBufferSize.Name = "_spnBufferSize";
			_spnBufferSize.Size = new System.Drawing.Size(64, 20);
			_spnBufferSize.TabIndex = 11;
			_spnBufferSize.Value = new decimal(new int[4]
			{
				32,
				0,
				0,
				0
			});
			_spnBufferSize.ValueChanged += new System.EventHandler(_spnBufferSize_ValueChanged);
			_spnTTL.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_spnTTL.Location = new System.Drawing.Point(88, 83);
			_spnTTL.Maximum = new decimal(new int[4]
			{
				255,
				0,
				0,
				0
			});
			_spnTTL.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			_spnTTL.Name = "_spnTTL";
			_spnTTL.Size = new System.Drawing.Size(64, 20);
			_spnTTL.TabIndex = 9;
			_spnTTL.Value = new decimal(new int[4]
			{
				32,
				0,
				0,
				0
			});
			_spnTTL.ValueChanged += new System.EventHandler(_spnTTL_ValueChanged);
			_spnTimeout.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_spnTimeout.Location = new System.Drawing.Point(88, 57);
			_spnTimeout.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			_spnTimeout.Minimum = new decimal(new int[4]
			{
				10,
				0,
				0,
				0
			});
			_spnTimeout.Name = "_spnTimeout";
			_spnTimeout.Size = new System.Drawing.Size(64, 20);
			_spnTimeout.TabIndex = 7;
			_spnTimeout.Value = new decimal(new int[4]
			{
				1500,
				0,
				0,
				0
			});
			_spnTimeout.ValueChanged += new System.EventHandler(_spnTimeout_ValueChanged);
			_lRangeSep.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_lRangeSep.AutoSize = true;
			_lRangeSep.Location = new System.Drawing.Point(220, 33);
			_lRangeSep.Name = "_lRangeSep";
			_lRangeSep.Size = new System.Drawing.Size(10, 13);
			_lRangeSep.TabIndex = 19;
			_lRangeSep.Text = "-";
			_tbRangeEnd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_tbRangeEnd.Location = new System.Drawing.Point(233, 29);
			_tbRangeEnd.Name = "_tbRangeEnd";
			_tbRangeEnd.Size = new System.Drawing.Size(130, 20);
			_tbRangeEnd.TabIndex = 5;
			_tbRangeStart.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_tbRangeStart.Location = new System.Drawing.Point(87, 29);
			_tbRangeStart.Name = "_tbRangeStart";
			_tbRangeStart.Size = new System.Drawing.Size(130, 20);
			_tbRangeStart.TabIndex = 3;
			_cmbRangeType.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_cmbRangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cmbRangeType.FormattingEnabled = true;
			_cmbRangeType.Items.AddRange(new object[2]
			{
				"Range",
				"Subnet"
			});
			_cmbRangeType.Location = new System.Drawing.Point(12, 29);
			_cmbRangeType.Name = "_cmbRangeType";
			_cmbRangeType.Size = new System.Drawing.Size(69, 21);
			_cmbRangeType.TabIndex = 1;
			_cmbRangeType.SelectedIndexChanged += new System.EventHandler(_cmbRangeType_SelectedIndexChanged);
			_btnStartStop.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			_btnStartStop.Location = new System.Drawing.Point(369, 28);
			_btnStartStop.Name = "_btnStartStop";
			_btnStartStop.Size = new System.Drawing.Size(89, 23);
			_btnStartStop.TabIndex = 18;
			_btnStartStop.Text = "&Start";
			_btnStartStop.UseVisualStyleBackColor = true;
			_btnStartStop.Click += new System.EventHandler(_btnStartStop_Click);
			_prgScanProgress.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			_prgScanProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_prgScanProgress.Location = new System.Drawing.Point(12, 164);
			_prgScanProgress.Name = "_prgScanProgress";
			_prgScanProgress.Size = new System.Drawing.Size(215, 23);
			_prgScanProgress.TabIndex = 5;
			_prgScanProgress.Text = "Scanner is not running!";
			_btnAddHost.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			_btnAddHost.Enabled = false;
			_btnAddHost.Location = new System.Drawing.Point(233, 164);
			_btnAddHost.Name = "_btnAddHost";
			_btnAddHost.Size = new System.Drawing.Size(111, 23);
			_btnAddHost.TabIndex = 1;
			_btnAddHost.Text = "&Add To Host List...";
			_btnAddHost.UseVisualStyleBackColor = true;
			_btnAddHost.Click += new System.EventHandler(_btnAddHost_Click);
			_btnTrace.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			_btnTrace.Enabled = false;
			_btnTrace.Location = new System.Drawing.Point(350, 164);
			_btnTrace.Name = "_btnTrace";
			_btnTrace.Size = new System.Drawing.Size(108, 23);
			_btnTrace.TabIndex = 2;
			_btnTrace.Text = "Trace R&oute...";
			_btnTrace.UseVisualStyleBackColor = true;
			_btnTrace.Click += new System.EventHandler(_btnTrace_Click);
			_lbLog.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			_lbLog.FormattingEnabled = true;
			_lbLog.Location = new System.Drawing.Point(13, 193);
			_lbLog.Name = "_lbLog";
			_lbLog.Size = new System.Drawing.Size(445, 95);
			_lbLog.TabIndex = 3;
			_lvAliveHosts.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			_lvAliveHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[5]
			{
				_colQuality,
				_colIPAddress,
				_colAvgResponseTime,
				_colLosses,
				_colHostName
			});
			_lvAliveHosts.FullRowSelect = true;
			_lvAliveHosts.GridLines = true;
			_lvAliveHosts.Location = new System.Drawing.Point(12, 3);
			_lvAliveHosts.MultiSelect = false;
			_lvAliveHosts.Name = "_lvAliveHosts";
			_lvAliveHosts.Size = new System.Drawing.Size(446, 155);
			_lvAliveHosts.SmallImageList = _ilQuality;
			_lvAliveHosts.Sorting = System.Windows.Forms.SortOrder.Ascending;
			_lvAliveHosts.TabIndex = 0;
			_lvAliveHosts.UseCompatibleStateImageBehavior = false;
			_lvAliveHosts.View = System.Windows.Forms.View.Details;
			_lvAliveHosts.SelectedIndexChanged += new System.EventHandler(_lvAliveHosts_SelectedIndexChanged);
			_lvAliveHosts.DoubleClick += new System.EventHandler(_lvAliveHosts_DoubleClick);
			_lvAliveHosts.MouseMove += new System.Windows.Forms.MouseEventHandler(_lvAliveHosts_MouseMove);
			_colQuality.Text = "Q";
			_colQuality.Width = 20;
			_colIPAddress.Text = "IP Address";
			_colIPAddress.Width = 92;
			_colAvgResponseTime.Text = "Avg. Resp. Time";
			_colAvgResponseTime.Width = 91;
			_colLosses.Text = "Losses";
			_colLosses.Width = 56;
			_colHostName.Text = "Host Name";
			_colHostName.Width = 161;
			_ilQuality.ImageStream = (System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("_ilQuality.ImageStream");
			_ilQuality.TransparentColor = System.Drawing.Color.Transparent;
			_ilQuality.Images.SetKeyName(0, "0");
			_ilQuality.Images.SetKeyName(1, "1");
			_ilQuality.Images.SetKeyName(2, "2");
			_ilQuality.Images.SetKeyName(3, "3");
			_ilQuality.Images.SetKeyName(4, "4");
			_ilQuality.Images.SetKeyName(5, "5");
			_ilQuality.Images.SetKeyName(6, "6");
			base.AcceptButton = _btnStartStop;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(470, 462);
			base.Controls.Add(_splMaster);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "IPScanForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Scan IP Address Range";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(IPScanForm_FormClosing);
			_splMaster.Panel1.ResumeLayout(performLayout: false);
			_splMaster.Panel1.PerformLayout();
			_splMaster.Panel2.ResumeLayout(performLayout: false);
			_splMaster.ResumeLayout(performLayout: false);
			((System.ComponentModel.ISupportInitialize)_spnPingsPerScan).EndInit();
			((System.ComponentModel.ISupportInitialize)_spnConcurrentPings).EndInit();
			((System.ComponentModel.ISupportInitialize)_spnBufferSize).EndInit();
			((System.ComponentModel.ISupportInitialize)_spnTTL).EndInit();
			((System.ComponentModel.ISupportInitialize)_spnTimeout).EndInit();
			ResumeLayout(performLayout: false);
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
	}
}
