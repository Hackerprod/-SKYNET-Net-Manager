
using MsgUI;
using SKYNET.Controls;
using SKYNET.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SKYNET
{
    partial class frmMain
    {
        private void explorarPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            if (!menuBOX.Device.TCP)
                Process.Start(@"\\" + menuBOX.Device.IPAddress);
            else
                Process.Start("https://" + menuBOX.Device.IPAddress);
        }

        private void hacerPingPorCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            frmConsole console = new frmConsole(menuBOX);
            console.Show();
        }

        private void MostrarMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Activate();
                SetVisible(true);
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                SetVisible(false);
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Save();
            Settings.SetHandle(0);
            SaveDevices();
            Process.GetCurrentProcess().Kill();
        }

        private void RemoveDeviceMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage message = new frmMessage("Are you sure you want to delete the device " + menuBOX.Device.Name + "?", frmMessage.TypeMessage.YesNo);
            DialogResult result = message.ShowDialog();
            if (result == DialogResult.OK)
            {
                for (int i = 0; i < DeviceContainer.Controls.Count; i++)
                {
                    var control = DeviceContainer.Controls[i];
                    if (control is DeviceBox && ((DeviceBox)control).Device.Guid == menuBOX.Device.Guid)
                    {
                        if (i == DeviceContainer.Controls.Count - 1)
                        {
                            DeviceContainer.Controls.Remove(control);
                        }
                        else
                        {
                            var device = menuBOX.Device;
                            device.Name = "Unknown";
                            device.IPAddress = "";

                            menuBOX.Device = device;
                        }
                    }
                }

                SaveDevices();
            }
        }

        private void EditarMenuItem_Click(object sender, EventArgs e)
        {
            ShowManager(menuBOX);
        }

        private void OnlineAlertMenuItem_Click(object sender, EventArgs e)
        {
            menuBOX.AlertOnConnect = true;
        }

        private void OfflineAlertMenuItem_Click(object sender, EventArgs e)
        {
            menuBOX.AlertOnDisconnect = true;
        }

        private void DevicePingInfoMenuItem_Click(object sender, EventArgs e)
        {
            frmDeviceInfo deviceInfo = new frmDeviceInfo(menuBOX);
            deviceInfo.Show();
        }

        private void PuertosMenuItem_Click(object sender, EventArgs e)
        {
            frmPortScan manage = new frmPortScan(menuBOX.Device.IPAddress.ToIPAddress());
            manage.Show();
        }

        private void AgregarEquipoMenuItem_Click(object sender, EventArgs e)
        {
            frmMain.frm.ShowManager();
        }

        private void BuscarEquiposMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.Show();
        }

        private void AdministrarPerfilesMenuItem_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.ShowDialog();
        }

        private void MinimizeMenuItem_Click(object sender, EventArgs e)
        {
            SetVisible(false);
            WindowState = FormWindowState.Minimized;
        }

        private void GlobalChatMenuItem_Click(object sender, EventArgs e)
        {
            new frmPublicChat().ShowDialog();
        }


        private void EnviarMensajeMenuItem_Click(object sender, EventArgs e)
        {
            var chat = new frmPrivateChat(menuBOX);
            ChatManager.RegisterChat(menuBOX.Device.IPAddress.ToIPAddress(), chat);

            if (ChatManager.GetChatHistory(menuBOX.Device.IPAddress.ToIPAddress(), out var chatHistory))
            {
                chat.FillHistory(chatHistory);
            }

            chat.TopMost = true;
            chat.Show();
        }

        private void SystemMessageMenuItem_Click(object sender, EventArgs e)
        {
            new frmSystemMessage(menuBOX).ShowDialog();
        }

        private void NetworkTableMenuItem_Click(object sender, EventArgs e)
        {
            new frmARPTable().ShowDialog();
        }

        private void ActiveConnectionsMenuItem_Click(object sender, EventArgs e)
        {
            new frmConnectionInfo().ShowDialog();
        }
    }
}
