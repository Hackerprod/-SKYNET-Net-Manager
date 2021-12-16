using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKYNET
{
    public class RegistrySettings
    {
        public RegistryKey Registry { get; private set; }
        public object WriteLog { get; private set; }
        string SubKey = @"SOFTWARE\SKYNET\[SKYNET] NetManager\";
        public RegistrySettings()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);
            if (Registry == null)
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(SubKey);
                frmMain.MinimizeWhenClose = false;
                frmMain.LaunchWindowsStart = false;
                frmMain.FirstLaunch = true;
                frmMain.CurrentSection = "Device";
                frmMain.Key = "F8";
                frmMain.ShowInLeft = false;
                frmMain.OpacityForm = 100;
                frmMain.Timeout = 2000;
                frmMain.BufferSize = 32;
                frmMain.TTL = 32;
                frmMain.CustomSound = false;
                frmMain.CustomSoundPatch = "";
                frmMain.ShowTopPanel = true;

            }
        }
        public void SaveSettings()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);

            try { Registry.SetValue("MinimizeWhenClose", frmMain.MinimizeWhenClose.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("LaunchWindowsStart", frmMain.LaunchWindowsStart.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("CurrentSection", frmMain.CurrentSection.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("Key", frmMain.Key.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("ShowInLeft", frmMain.ShowInLeft.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("OpacityForm", frmMain.OpacityForm.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("Timeout", frmMain.Timeout.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("BufferSize", frmMain.BufferSize.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("TTL", frmMain.TTL.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("CustomSound", frmMain.CustomSound.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("CustomSoundPatch", frmMain.CustomSoundPatch.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { Registry.SetValue("ShowTopPanel", frmMain.ShowTopPanel.ToString()); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void LoadSettings()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);
            if (Registry.GetValue("LaunchWindowsStart", RegistryValueKind.String).ToString() == "String")
            {
                frmMain.MinimizeWhenClose = false;
                frmMain.LaunchWindowsStart = false;
                frmMain.CurrentSection = "Device";
                frmMain.Key = "F8";
                frmMain.ShowInLeft = false;
                frmMain.OpacityForm = 100;
                frmMain.Timeout = 2000;
                frmMain.BufferSize = 32;
                frmMain.TTL = 32;
                frmMain.CustomSound = false;
                frmMain.CustomSoundPatch = "";
                frmMain.ShowTopPanel = true;
                return;
            }

            try
            {
                frmMain.LaunchWindowsStart = Convert.ToBoolean(Registry.GetValue("LaunchWindowsStart", RegistryValueKind.String));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.MinimizeWhenClose = Convert.ToBoolean(Registry.GetValue("MinimizeWhenClose", RegistryValueKind.String));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.CurrentSection = Registry.GetValue("CurrentSection", RegistryValueKind.String).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.Key = Registry.GetValue("Key", RegistryValueKind.String).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.ShowInLeft = Convert.ToBoolean(Registry.GetValue("ShowInLeft", RegistryValueKind.String));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.OpacityForm = Convert.ToDouble(Registry.GetValue("OpacityForm", RegistryValueKind.String));
                //frmMain.frm.frmBack.Opacity = frmMain.OpacityForm;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.Timeout = Convert.ToInt32(Registry.GetValue("Timeout", RegistryValueKind.String));
                //frmMain.frm.frmBack.Opacity = frmMain.OpacityForm;
            }
            catch (Exception ex) { frmMain.Timeout = 2000; MessageBox.Show(ex.Message); }

            try
            {
                frmMain.BufferSize = Convert.ToInt32(Registry.GetValue("BufferSize", RegistryValueKind.String));
                //frmMain.frm.frmBack.Opacity = frmMain.OpacityForm;
            }
            catch (Exception ex) { frmMain.BufferSize = 32; MessageBox.Show(ex.Message); }

            try
            {
                frmMain.TTL = Convert.ToInt32(Registry.GetValue("TTL", RegistryValueKind.String));
                //frmMain.frm.frmBack.Opacity = frmMain.OpacityForm;
            }
            catch (Exception ex) { frmMain.TTL = 32; MessageBox.Show(ex.Message); }

            try
            {
                frmMain.CustomSound = Convert.ToBoolean(Registry.GetValue("CustomSound", RegistryValueKind.String));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.CustomSoundPatch = Registry.GetValue("CustomSoundPatch", RegistryValueKind.String).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                frmMain.ShowTopPanel = Convert.ToBoolean(Registry.GetValue("ShowTopPanel", RegistryValueKind.String));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        public void GuardarID(object ID)
        {
            RegistryKey handle = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SKYNET\[SKYNET] NetManager\", true);
            if (handle == null)
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SKYNET\[SKYNET] NetManager\");
                handle = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SKYNET\[SKYNET] NetManager\", true);
            }
            handle.SetValue("Handle", ID);

        }
        public void ResetId()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);
            try { Registry.SetValue("Handle", "0"); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
