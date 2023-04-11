using SKYNET.GUI;
using SKYNET.Models.Network;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmARPTable : frmBase
    {
        public frmARPTable()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;

            Initialize();
        }

        private async void Initialize()
        {
            var Table = await ARP.GetTableAsync();

            var WithMulticast = Table.FindAll(t => t.IsMulticast);
            var WithOutMulticast = Table.FindAll(t => !t.IsMulticast);

            WithOutMulticast.Sort((x, y) => x.IPAddressInt32.CompareTo(y.IPAddressInt32));

            foreach (var arp in WithOutMulticast)
            {
                AddTableItem(arp);
            }

            foreach (var arp in WithMulticast)
            {
                AddTableItem(arp);
            }

        }

        private void AddTableItem(ARPInfo arp)
        {
            var lvItem = new ListViewItem();
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

            lvItem.SubItems[0].Text = arp.IPAddress.ToString();
            lvItem.SubItems[1].Text = arp.MACAddressString;
            lvItem.SubItems[2].Text = arp.IsMulticast.ToString();

            LV_ARP.Items.Add(lvItem);

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
    }
}
