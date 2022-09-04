using SKYNET.GUI;
using SKYNET.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace SKYNET
{
    public partial class frmSettings : frmBase
    {
        public static frmSettings frm;
        public bool Ready = false;
        public DeviceBox menuBOX;


        public frmSettings()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);

            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  
            frm = this;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            minimizeBox.Checked = Settings.MinimizeWhenClose;
            launchWindowsBox.Checked = Settings.LaunchWindowsStart;
            TB_KeyLabel.Text = Settings.Key;
            ShowInLeft.Checked = Settings.ShowInLeft;
            TimeOut.Text = Settings.Timeout.ToString();
            TTL.Text = Settings.TTL.ToString();
            BufferSize.Text = Settings.BufferSize.ToString();
            CustomSound.Checked = Settings.CustomSound;
            CustomSoundPatch.Text = Settings.CustomSoundPatch;

            CustomSoundPatch.Visible = CustomSound.Checked;
            SearhSound.Visible = CustomSound.Checked;

            ShowTopPanel.Checked = Settings.ShowTopPanel;

            int maximum = 100;
            int minimum = 80;
            string opacity = frmBack.frm.Opacity.ToString();
            opacity = opacity.Replace("0,", "").Replace("0.", "");

            int value = Convert.ToInt32(opacity);
            if (value == 1) value = 100;

            OpacityBar.Minimum = minimum;
            OpacityBar.Maximum = maximum;
            OpacityBar.Value = value;
        }

        private void panelClose_MouseMove(object sender, MouseEventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(53, 64, 78);
        }

        private void panelClose_MouseLeave(object sender, EventArgs e)
        {
            panelClose.BackColor = Color.FromArgb(43, 54, 68);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Visible = false;
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            Settings.MinimizeWhenClose = minimizeBox.Checked;
            Settings.LaunchWindowsStart = launchWindowsBox.Checked;

            Settings.Timeout = Convert.ToInt32(TimeOut.Text);
            Settings.TTL = Convert.ToInt32(TTL.Text);
            Settings.BufferSize = Convert.ToInt32(BufferSize.Text);

            Settings.CustomSoundPatch = CustomSoundPatch.Text;
            Settings.CustomSound = CustomSound.Checked;
            Settings.ShowTopPanel = ShowTopPanel.Checked;


            button1.PerformClick();
        }

        private void AceptarBtn_MouseMove(object sender, MouseEventArgs e)
        {
            AceptarBtn.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void AceptarBtn_MouseLeave(object sender, EventArgs e)
        {
            AceptarBtn.ForeColor = Color.FromArgb(147, 157, 160);
        }

        private void KeyClick(object sender, EventArgs e)
        {
            frmKey key = new frmKey();
            key.ShowDialog();
            TB_KeyLabel.Text = Settings.Key;
        }
        private void OpacityBar_Scroll(object sender, EventArgs e)
        {
            double value = OpacityBar.Value;

            if (value < 100)
            {
                value = value / 100;
            }

            frmBack.frm.Opacity = value;
            Settings.OpacityForm = value;
        }

        private void SearhSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog Sound = new OpenFileDialog();
            Sound.FileName = string.Empty;
            Sound.Filter = "Audio files|*.wav";
            Sound.Title = "Select Photo";
            Sound.RestoreDirectory = true;
            DialogResult num = Sound.ShowDialog();
            if (num == DialogResult.OK)
            {
                CustomSoundPatch.Text = Sound.FileName;
            }

        }

        private void ShowTopPanel_Click(object sender, EventArgs e)
        {
            Common.ShowBars(ShowTopPanel.Checked);
        }
        private void CustomSound_MouseClick(object sender, MouseEventArgs e)
        {
            CustomSoundPatch.Visible = CustomSound.Checked;
            SearhSound.Visible = CustomSound.Checked;
        }

        private void ShowInLeft_MouseClick(object sender, MouseEventArgs e)
        {
            Settings.ShowInLeft = ShowInLeft.Checked;
            frmMain.frm.Maximize(ShowInLeft.Checked);
        }
    }
}
