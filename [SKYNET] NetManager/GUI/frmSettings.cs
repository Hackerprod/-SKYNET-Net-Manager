using SKYNET.GUI;
using SKYNET.Helpers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            CB_MinimizeWhenClose.Checked = Settings.MinimizeWhenClose;
            CB_LaunchWindowsStart.Checked = Settings.LaunchWindowsStart;
            TB_Key.Text = Settings.Key;
            CB_ShowInLeft.Checked = Settings.ShowInLeft;
            TB_TimeOut.Text = Settings.Timeout.ToString();
            TB_TTL.Text = Settings.TTL.ToString();
            TB_BufferSize.Text = Settings.BufferSize.ToString();
            CB_CustomSound.Checked = Settings.CustomSound;
            TB_CustomSoundPath.Text = Settings.CustomSoundPath;
            TB_UserName.Text = Settings.Username;
            CB_ReceiveMessages.Checked = frmMain.ReceiveMessages;

            TB_CustomSoundPath.Visible = CB_CustomSound.Checked;
            SearhSound.Visible = CB_CustomSound.Checked;

            CB_ShowTopPanel.Checked = Settings.ShowTopPanel;

            int maximum = 100;
            int minimum = 80;
            string opacity = frmBack.frm.Opacity.ToString();
            opacity = opacity.Replace("0,", "").Replace("0.", "");

            string avatarPath = Path.Combine(Common.GetPath(), "Data", "Images", "Avatar.jpg");
            try
            {
                if (File.Exists(avatarPath))
                {
                    var Avatar = ImageHelper.FromFile(avatarPath);
                    PB_Avatar.Image = Avatar;
                }
                else
                {
                    var Avatar = ImageHelper.GetDesktopWallpaper(true);
                    Avatar.Save(avatarPath);
                    PB_Avatar.Image = Avatar;
                }
            }
            catch (Exception)
            {
            }

            int value = Convert.ToInt32(opacity);
            if (value == 1) value = 100;

            OpacityBar.Minimum = minimum;
            OpacityBar.Maximum = maximum;
            OpacityBar.Value = value;
        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            Settings.MinimizeWhenClose = CB_MinimizeWhenClose.Checked;
            Settings.LaunchWindowsStart = CB_LaunchWindowsStart.Checked;

            Settings.Timeout = Convert.ToInt32(TB_TimeOut.Text);
            Settings.TTL = Convert.ToInt32(TB_TTL.Text);
            Settings.BufferSize = Convert.ToInt32(TB_BufferSize.Text);

            Settings.CustomSoundPath = TB_CustomSoundPath.Text;
            Settings.CustomSound = CB_CustomSound.Checked;
            Settings.ShowTopPanel = CB_ShowTopPanel.Checked;

            Settings.Username = TB_UserName.Text;
            frmMain.ReceiveMessages = CB_ReceiveMessages.Checked;

            Close();
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
            TB_Key.Text = Settings.Key;
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
                TB_CustomSoundPath.Text = Sound.FileName;
            }

        }

        private void CustomSound_MouseClick(object sender, MouseEventArgs e)
        {
            TB_CustomSoundPath.Visible = CB_CustomSound.Checked;
            SearhSound.Visible = CB_CustomSound.Checked;
        }

        private void ShowInLeft_MouseClick(object sender, MouseEventArgs e)
        {
            Settings.ShowInLeft = CB_ShowInLeft.Checked;
            frmMain.frm.Maximize(CB_ShowInLeft.Checked);
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void PB_Avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.FileName = string.Empty;
            ofdPhoto.Filter = "Picture files|*.jpg;*.bmp;*.jpg;*.gif;*.ico|All Files|*.*";
            ofdPhoto.Title = "Select Photo";
            ofdPhoto.RestoreDirectory = true;
            DialogResult dialogResult = ofdPhoto.ShowDialog();
            this.Visible = false;
            WindowState = FormWindowState.Minimized;
            if (dialogResult == DialogResult.OK)
            {
                string FileName = Path.Combine(Common.GetPath(), "Data", "Images", "Avatar.jpg");
                ImageType type = DeviceManager.GetImageType(ofdPhoto.FileName);

                if (type == ImageType.ICO)
                {
                    Bitmap bitmap = (Bitmap)default;
                    try
                    {
                        bitmap = new Icon(ofdPhoto.FileName, 1000, 1000).ToBitmap();
                    }
                    catch (Exception)
                    {
                        bitmap = Bitmap.FromHicon((new Icon(ofdPhoto.FileName, 1000, 1000).Handle));
                    }
                    bitmap = ImageHelper.CreateResizedBitmap(bitmap, 1000, 1000, ImageFormat.Png);
                    bitmap.Save(FileName, ImageFormat.Png);
                    LoadImage();
                }
                else
                {
                    //pctPhoto.Tag = "1";
                    Image image = Common.ImageFromFile(ofdPhoto.FileName);

                    if (image.Width < 250)
                    {
                        Bitmap bitmap = (Bitmap)default;
                        bitmap = ImageHelper.CreateResizedBitmap((Bitmap)image, 1000, 1000, ImageFormat.Png);
                        bitmap.Save(FileName, ImageFormat.Png);
                    }
                    else
                    {
                        frmCropEditor FrmPhoto2 = new frmCropEditor(ofdPhoto.FileName, "Avatar");
                        FrmPhoto2.ShowDialog();
                    }

                    LoadImage();
                }
            }
            this.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void LoadImage()
        {
            var filePath = Path.Combine(Common.GetPath(), "Data", "Images", "Avatar.jpg");
            if (File.Exists(filePath))
            {
                PB_Avatar.Image = Common.ImageFromFile(filePath);
            }
        }
    }
}
