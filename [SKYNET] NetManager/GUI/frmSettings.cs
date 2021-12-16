using System;
using System.Drawing;
using System.Windows.Forms;


namespace SKYNET
{
    public partial class frmSettings : Form
    {
        public static frmSettings frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public bool Ready = false;
        public DeviceBox menuBOX;


        public frmSettings()
        {
            InitializeComponent();

            TopMost = true;
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (frmMain.FirstLaunch)
            {
                minimizeBox.Checked = false;
                launchWindowsBox.Checked = false;
                TB_KeyLabel.Text = frmMain.Key;
                ShowInLeft.Checked = false;
                CustomSound.Checked = false;
                ShowTopPanel.Checked = true;

                CustomSoundPatch.Visible = CustomSound.Checked;
                SearhSound.Visible = CustomSound.Checked;
            }
            else
            {
                minimizeBox.Checked = frmMain.MinimizeWhenClose;
                launchWindowsBox.Checked = frmMain.LaunchWindowsStart;
                TB_KeyLabel.Text = frmMain.Key;
                ShowInLeft.Checked = frmMain.ShowInLeft;
                TimeOut.Text = frmMain.Timeout.ToString();
                TTL.Text = frmMain.TTL.ToString();
                BufferSize.Text = frmMain.BufferSize.ToString();
                CustomSound.Checked = frmMain.CustomSound;
                CustomSoundPatch.Text = frmMain.CustomSoundPatch;

                CustomSoundPatch.Visible = CustomSound.Checked;
                SearhSound.Visible = CustomSound.Checked;

                ShowTopPanel.Checked = frmMain.ShowTopPanel;
            }

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

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
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
            frmMain.MinimizeWhenClose = minimizeBox.Checked;
            frmMain.LaunchWindowsStart = launchWindowsBox.Checked;

            frmMain.Timeout = Convert.ToInt32(TimeOut.Text);
            frmMain.TTL = Convert.ToInt32(TTL.Text);
            frmMain.BufferSize = Convert.ToInt32(BufferSize.Text);

            frmMain.CustomSoundPatch = CustomSoundPatch.Text;
            frmMain.CustomSound = CustomSound.Checked;
            frmMain.ShowTopPanel = ShowTopPanel.Checked;


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
            TB_KeyLabel.Text = frmMain.Key;
        }
        private void OpacityBar_Scroll(object sender, EventArgs e)
        {
            double value = OpacityBar.Value;

            if (value < 100)
            {
                value = value / 100;
            }

            frmBack.frm.Opacity = value;
            frmMain.OpacityForm = value;
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
            modCommon.ShowBars(ShowTopPanel.Checked);
        }
        private void CustomSound_MouseClick(object sender, MouseEventArgs e)
        {
            CustomSoundPatch.Visible = CustomSound.Checked;
            SearhSound.Visible = CustomSound.Checked;
        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                base.Location = new Point((base.Location.X - lastLocation.X) + e.X, (base.Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void Event_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void ShowInLeft_MouseClick(object sender, MouseEventArgs e)
        {
            frmMain.ShowInLeft = ShowInLeft.Checked;
            frmMain.frm.Maximize(ShowInLeft.Checked);
        }
    }
}
