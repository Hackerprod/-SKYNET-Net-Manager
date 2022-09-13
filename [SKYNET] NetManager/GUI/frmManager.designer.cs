using SKYNET.Controls;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.PN_Top = new System.Windows.Forms.Panel();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Container = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CircularAvatar = new SKYNET.Controls.SKYNET_Check();
            this.PanelInterval = new System.Windows.Forms.Panel();
            this.Interval = new SKYNET.Controls.SKYNET_TextBox();
            this.PanelDeviceIp = new System.Windows.Forms.Panel();
            this.DeviceIp = new SKYNET.Controls.SKYNET_TextBox();
            this.Save = new SKYNET.SKYNET_Button();
            this.OpcionalLocation = new SKYNET.Controls.SKYNET_TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchPorts = new SKYNET.SKYNET_Button();
            this.DeviceName = new SKYNET.Controls.SKYNET_TextBox();
            this.MAC = new SKYNET.Controls.SKYNET_TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new SKYNET.Controls.SKYNET_TextBox();
            this.DeleteAvatar = new System.Windows.Forms.PictureBox();
            this.DeviceWeb = new SKYNET.Controls.SKYNET_Check();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.PN_Top.SuspendLayout();
            this.Container.SuspendLayout();
            this.PanelInterval.SuspendLayout();
            this.PanelDeviceIp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(470, 26);
            this.PN_Top.TabIndex = 5;
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(485, 375);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 16;
            this.acceptBtn.Text = "button1";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(181, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Machine name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(181, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "IP direction";
            // 
            // Container
            // 
            this.Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.Container.Controls.Add(this.label6);
            this.Container.Controls.Add(this.label5);
            this.Container.Controls.Add(this.CircularAvatar);
            this.Container.Controls.Add(this.PanelInterval);
            this.Container.Controls.Add(this.PanelDeviceIp);
            this.Container.Controls.Add(this.Save);
            this.Container.Controls.Add(this.OpcionalLocation);
            this.Container.Controls.Add(this.label4);
            this.Container.Controls.Add(this.label2);
            this.Container.Controls.Add(this.SearchPorts);
            this.Container.Controls.Add(this.DeviceName);
            this.Container.Controls.Add(this.MAC);
            this.Container.Controls.Add(this.label1);
            this.Container.Controls.Add(this.Port);
            this.Container.Controls.Add(this.DeleteAvatar);
            this.Container.Controls.Add(this.DeviceWeb);
            this.Container.Controls.Add(this.Avatar);
            this.Container.Controls.Add(this.label8);
            this.Container.Controls.Add(this.label10);
            this.Container.Dock = System.Windows.Forms.DockStyle.Top;
            this.Container.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.Container.Location = new System.Drawing.Point(0, 26);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(470, 296);
            this.Container.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 268;
            this.label6.Text = "Ping to port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 267;
            this.label5.Text = "Rounded avatar";
            // 
            // CircularAvatar
            // 
            this.CircularAvatar.BackColor = System.Drawing.Color.Transparent;
            this.CircularAvatar.Checked = false;
            this.CircularAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CircularAvatar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CircularAvatar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CircularAvatar.Location = new System.Drawing.Point(123, 166);
            this.CircularAvatar.Name = "CircularAvatar";
            this.CircularAvatar.Size = new System.Drawing.Size(39, 22);
            this.CircularAvatar.TabIndex = 266;
            this.CircularAvatar.CheckedChanged += new System.EventHandler<bool>(this.CircularAvatar_CheckedChanged);
            // 
            // PanelInterval
            // 
            this.PanelInterval.Controls.Add(this.Interval);
            this.PanelInterval.Location = new System.Drawing.Point(297, 128);
            this.PanelInterval.Name = "PanelInterval";
            this.PanelInterval.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.PanelInterval.Size = new System.Drawing.Size(153, 27);
            this.PanelInterval.TabIndex = 265;
            // 
            // Interval
            // 
            this.Interval.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Interval.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Interval.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Interval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Interval.ForeColor = System.Drawing.Color.White;
            this.Interval.IsPassword = false;
            this.Interval.Location = new System.Drawing.Point(0, 0);
            this.Interval.Logo = null;
            this.Interval.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.Interval.Multiline = false;
            this.Interval.Name = "Interval";
            this.Interval.OnlyNumbers = false;
            this.Interval.ShowLogo = false;
            this.Interval.Size = new System.Drawing.Size(153, 26);
            this.Interval.TabIndex = 261;
            this.Interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Interval.TextChanged += new System.EventHandler(this.Interval_TextChanged);
            // 
            // PanelDeviceIp
            // 
            this.PanelDeviceIp.Controls.Add(this.DeviceIp);
            this.PanelDeviceIp.Location = new System.Drawing.Point(297, 53);
            this.PanelDeviceIp.Name = "PanelDeviceIp";
            this.PanelDeviceIp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.PanelDeviceIp.Size = new System.Drawing.Size(153, 27);
            this.PanelDeviceIp.TabIndex = 264;
            // 
            // DeviceIp
            // 
            this.DeviceIp.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceIp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceIp.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceIp.ForeColor = System.Drawing.Color.White;
            this.DeviceIp.IsPassword = false;
            this.DeviceIp.Location = new System.Drawing.Point(0, 0);
            this.DeviceIp.Logo = null;
            this.DeviceIp.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.DeviceIp.Multiline = false;
            this.DeviceIp.Name = "DeviceIp";
            this.DeviceIp.OnlyNumbers = false;
            this.DeviceIp.ShowLogo = false;
            this.DeviceIp.Size = new System.Drawing.Size(153, 26);
            this.DeviceIp.TabIndex = 259;
            this.DeviceIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DeviceIp.TextChanged += new System.EventHandler(this.DeviceIp_TextChanged);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Save.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.Save.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.Save.ImageIcon = null;
            this.Save.Location = new System.Drawing.Point(338, 256);
            this.Save.MenuMode = false;
            this.Save.Name = "Save";
            this.Save.Rounded = false;
            this.Save.Size = new System.Drawing.Size(112, 29);
            this.Save.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.Save.TabIndex = 21;
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // OpcionalLocation
            // 
            this.OpcionalLocation.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.OpcionalLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.OpcionalLocation.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.OpcionalLocation.ForeColor = System.Drawing.Color.White;
            this.OpcionalLocation.IsPassword = false;
            this.OpcionalLocation.Location = new System.Drawing.Point(297, 166);
            this.OpcionalLocation.Logo = null;
            this.OpcionalLocation.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.OpcionalLocation.Multiline = false;
            this.OpcionalLocation.Name = "OpcionalLocation";
            this.OpcionalLocation.OnlyNumbers = false;
            this.OpcionalLocation.ShowLogo = false;
            this.OpcionalLocation.Size = new System.Drawing.Size(153, 26);
            this.OpcionalLocation.TabIndex = 263;
            this.OpcionalLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OpcionalLocation.DoubleClick += new System.EventHandler(this.OpcionalLocation_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(181, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 262;
            this.label4.Text = "Execute file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(181, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 260;
            this.label2.Text = "Interval";
            // 
            // SearchPorts
            // 
            this.SearchPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SearchPorts.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.SearchPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchPorts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchPorts.ForeColor = System.Drawing.Color.White;
            this.SearchPorts.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.SearchPorts.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.SearchPorts.ImageIcon = null;
            this.SearchPorts.Location = new System.Drawing.Point(12, 256);
            this.SearchPorts.MenuMode = false;
            this.SearchPorts.Name = "SearchPorts";
            this.SearchPorts.Rounded = false;
            this.SearchPorts.Size = new System.Drawing.Size(148, 29);
            this.SearchPorts.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.SearchPorts.TabIndex = 254;
            this.SearchPorts.Text = "Search ports";
            this.SearchPorts.Click += new System.EventHandler(this.SearchPorts_Click);
            // 
            // DeviceName
            // 
            this.DeviceName.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceName.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeviceName.ForeColor = System.Drawing.Color.White;
            this.DeviceName.IsPassword = false;
            this.DeviceName.Location = new System.Drawing.Point(297, 15);
            this.DeviceName.Logo = null;
            this.DeviceName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.DeviceName.Multiline = false;
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.OnlyNumbers = false;
            this.DeviceName.ShowLogo = false;
            this.DeviceName.Size = new System.Drawing.Size(153, 26);
            this.DeviceName.TabIndex = 258;
            this.DeviceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // MAC
            // 
            this.MAC.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.MAC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.MAC.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.MAC.ForeColor = System.Drawing.Color.White;
            this.MAC.IsPassword = false;
            this.MAC.Location = new System.Drawing.Point(297, 91);
            this.MAC.Logo = null;
            this.MAC.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.MAC.Multiline = false;
            this.MAC.Name = "MAC";
            this.MAC.OnlyNumbers = false;
            this.MAC.ShowLogo = false;
            this.MAC.Size = new System.Drawing.Size(153, 26);
            this.MAC.TabIndex = 257;
            this.MAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MAC_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(181, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 256;
            this.label1.Text = "MAC Address";
            // 
            // Port
            // 
            this.Port.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Port.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Port.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Port.ForeColor = System.Drawing.Color.White;
            this.Port.IsPassword = false;
            this.Port.Location = new System.Drawing.Point(12, 222);
            this.Port.Logo = null;
            this.Port.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.Port.Multiline = false;
            this.Port.Name = "Port";
            this.Port.OnlyNumbers = false;
            this.Port.ShowLogo = false;
            this.Port.Size = new System.Drawing.Size(148, 26);
            this.Port.TabIndex = 24;
            this.Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Port.Visible = false;
            // 
            // DeleteAvatar
            // 
            this.DeleteAvatar.BackColor = System.Drawing.Color.Transparent;
            this.DeleteAvatar.Image = global::SKYNET.Properties.Resources._1__154_;
            this.DeleteAvatar.Location = new System.Drawing.Point(105, 105);
            this.DeleteAvatar.Name = "DeleteAvatar";
            this.DeleteAvatar.Size = new System.Drawing.Size(26, 28);
            this.DeleteAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeleteAvatar.TabIndex = 253;
            this.DeleteAvatar.TabStop = false;
            this.DeleteAvatar.Click += new System.EventHandler(this.DeleteAvatar_Click);
            // 
            // DeviceWeb
            // 
            this.DeviceWeb.BackColor = System.Drawing.Color.Transparent;
            this.DeviceWeb.Checked = false;
            this.DeviceWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeviceWeb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DeviceWeb.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DeviceWeb.Location = new System.Drawing.Point(123, 194);
            this.DeviceWeb.Name = "DeviceWeb";
            this.DeviceWeb.Size = new System.Drawing.Size(37, 22);
            this.DeviceWeb.TabIndex = 252;
            this.DeviceWeb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeviceWeb_Click);
            // 
            // Avatar
            // 
            this.Avatar.Image = global::SKYNET.Properties.Resources.NeutralPC;
            this.Avatar.Location = new System.Drawing.Point(29, 14);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(133, 133);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 29;
            this.Avatar.TabStop = false;
            this.Avatar.Click += new System.EventHandler(this.Avatar_Click);
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(0, 348);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(31, 41);
            this.Browser.TabIndex = 19;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(436, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 0;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(470, 334);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.PN_Top);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.Load += new System.EventHandler(this.FrmManager_Load);
            this.PN_Top.ResumeLayout(false);
            this.Container.ResumeLayout(false);
            this.Container.PerformLayout();
            this.PanelInterval.ResumeLayout(false);
            this.PanelDeviceIp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.WebBrowser Browser;
        private SKYNET_Button Save;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private new System.Windows.Forms.Panel Container;
        private System.Windows.Forms.PictureBox Avatar;
        private SKYNET_Check DeviceWeb;
        private System.Windows.Forms.PictureBox DeleteAvatar;
        public SKYNET_TextBox Port;
        private SKYNET_TextBox MAC;
        private System.Windows.Forms.Label label1;
        private SKYNET_TextBox DeviceName;
        private SKYNET_TextBox DeviceIp;
        private SKYNET_Button SearchPorts;
        private SKYNET_TextBox Interval;
        private System.Windows.Forms.Label label2;
        private SKYNET_TextBox OpcionalLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelDeviceIp;
        private System.Windows.Forms.Panel PanelInterval;
        private SKYNET_Check CircularAvatar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private SKYNET_Box CloseBox;
    }
}