
using SKYNET.Controls;
using SKYNET.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SKYNET
{
    partial class frmMain
    {
        private void explorarPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBOX == null)
                return;

            if (!menuBOX.isWeb)
                Process.Start(@"\\" + menuBOX.IpName);
            else
                Process.Start("https://" + menuBOX.IpName);
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

        private void CloseBoxMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage message = new frmMessage("Estas seguro que deseas eliminar al dispositivo " + menuBOX.BoxName + "?", frmMessage.TypeMessage.YesNo);
            DialogResult result = message.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + menuBOX.Name + ".png"))
                    {
                        File.Delete(Common.CurrentDirectory + "/Data/Images/" + Settings.CurrentSection + "_" + menuBOX.Name + ".png");
                    }
                }
                catch { }

                RemoveDevice(menuBOX);
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
            frmPortScan manage = new frmPortScan(menuBOX.IpName);
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
            ChatManager.RegisterChat(menuBOX.RemoteAddress, chat);
            if (ChatManager.GetChatHistory(menuBOX.RemoteAddress, out var chatHistory))
            {
                chat.FillHistory(chatHistory);
            }
            chat.TopMost = true;
            chat.Show();
        }
    }
}
