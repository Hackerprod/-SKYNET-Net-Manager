using SKYNET.Controls;
namespace SKYNET
{
    partial class frmPortScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortScan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBox = new System.Windows.Forms.Panel();
            this.ClosePic = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timeOut = new SKYNET.Controls.SKYNET_TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RemoteHost = new SKYNET.Controls.SKYNET_TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.launchBtn = new SKYNET.Controls.SKYNET_Button();
            this.FBox = new SKYNET.Controls.SKYNET_TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SBox = new SKYNET.Controls.SKYNET_TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.PortWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarCheck = new SKYNET.Controls.SKYNET_ProgressBar();
            this.panel1.SuspendLayout();
            this.CloseBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePic)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.CloseBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 26);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Event_MouseUp);
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Controls.Add(this.ClosePic);
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.Location = new System.Drawing.Point(582, 0);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 12;
            this.CloseBox.Click += new System.EventHandler(this.CloseBox_Click);
            this.CloseBox.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.CloseBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // ClosePic
            // 
            this.ClosePic.Image = global::SKYNET.Properties.Resources.close;
            this.ClosePic.Location = new System.Drawing.Point(9, 5);
            this.ClosePic.Name = "ClosePic";
            this.ClosePic.Size = new System.Drawing.Size(16, 16);
            this.ClosePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClosePic.TabIndex = 4;
            this.ClosePic.TabStop = false;
            this.ClosePic.Click += new System.EventHandler(this.CloseBox_Click);
            this.ClosePic.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.ClosePic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Detectar puertos abiertos en el Host remoto";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Event_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(161, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Puerto de inicio [1 - ]";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel3.Controls.Add(this.timeOut);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.RemoteHost);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.launchBtn);
            this.panel3.Controls.Add(this.FBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.SBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 65);
            this.panel3.TabIndex = 8;
            // 
            // timeOut
            // 
            this.timeOut.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.timeOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.timeOut.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.timeOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.timeOut.IsPassword = false;
            this.timeOut.Location = new System.Drawing.Point(410, 23);
            this.timeOut.Logo = null;
            this.timeOut.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.timeOut.Name = "timeOut";
            this.timeOut.OnlyNumber = false;
            this.timeOut.ShowLogo = true;
            this.timeOut.Size = new System.Drawing.Size(99, 28);
            this.timeOut.TabIndex = 264;
            this.timeOut.TopSeparator = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(407, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 263;
            this.label7.Text = "Tiempo de espera";
            // 
            // RemoteHost
            // 
            this.RemoteHost.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.RemoteHost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.RemoteHost.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.RemoteHost.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.RemoteHost.IsPassword = false;
            this.RemoteHost.Location = new System.Drawing.Point(12, 23);
            this.RemoteHost.Logo = null;
            this.RemoteHost.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.RemoteHost.Name = "RemoteHost";
            this.RemoteHost.OnlyNumber = false;
            this.RemoteHost.ShowLogo = true;
            this.RemoteHost.Size = new System.Drawing.Size(146, 28);
            this.RemoteHost.TabIndex = 262;
            this.RemoteHost.TopSeparator = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(9, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 261;
            this.label6.Text = "Host remoto";
            // 
            // launchBtn
            // 
            this.launchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.launchBtn.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.launchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.launchBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.launchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.launchBtn.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.launchBtn.ImageAlignment = SKYNET.Controls.SKYNET_Button._ImgAlign.Left;
            this.launchBtn.ImageIcon = null;
            this.launchBtn.Location = new System.Drawing.Point(516, 22);
            this.launchBtn.MenuMode = false;
            this.launchBtn.Name = "launchBtn";
            this.launchBtn.Rounded = false;
            this.launchBtn.Size = new System.Drawing.Size(93, 29);
            this.launchBtn.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.launchBtn.TabIndex = 21;
            this.launchBtn.Text = "Buscar";
            this.launchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
            // 
            // FBox
            // 
            this.FBox.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.FBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.FBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.FBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FBox.IsPassword = false;
            this.FBox.Location = new System.Drawing.Point(286, 23);
            this.FBox.Logo = null;
            this.FBox.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.FBox.Name = "FBox";
            this.FBox.OnlyNumber = false;
            this.FBox.ShowLogo = true;
            this.FBox.Size = new System.Drawing.Size(118, 28);
            this.FBox.TabIndex = 260;
            this.FBox.TopSeparator = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(283, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 259;
            this.label1.Text = "Puerto final [ - 65535]";
            // 
            // SBox
            // 
            this.SBox.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SBox.IsPassword = false;
            this.SBox.Location = new System.Drawing.Point(164, 23);
            this.SBox.Logo = null;
            this.SBox.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.SBox.Name = "SBox";
            this.SBox.OnlyNumber = false;
            this.SBox.ShowLogo = true;
            this.SBox.Size = new System.Drawing.Size(116, 28);
            this.SBox.TabIndex = 258;
            this.SBox.TopSeparator = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.txtInfo);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(616, 272);
            this.panel2.TabIndex = 23;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtInfo.Location = new System.Drawing.Point(5, 27);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(606, 240);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInfo_KeyDown);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(606, 22);
            this.panel4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(61, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puerto";
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Info.Location = new System.Drawing.Point(8, 373);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(0, 16);
            this.Info.TabIndex = 24;
            // 
            // PortWorker
            // 
            this.PortWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PortWorker_DoWork);
            this.PortWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PortWorker_RunWorkerCompleted);
            // 
            // progressBarCheck
            // 
            this.progressBarCheck.BackColor = System.Drawing.Color.Transparent;
            this.progressBarCheck.DrawHatch = true;
            this.progressBarCheck.Location = new System.Drawing.Point(328, 369);
            this.progressBarCheck.Maximum = 100;
            this.progressBarCheck.Minimum = 0;
            this.progressBarCheck.MinimumSize = new System.Drawing.Size(58, 20);
            this.progressBarCheck.Name = "progressBarCheck";
            this.progressBarCheck.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.progressBarCheck.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.progressBarCheck.ShowPercentage = false;
            this.progressBarCheck.Size = new System.Drawing.Size(281, 20);
            this.progressBarCheck.TabIndex = 26;
            this.progressBarCheck.Text = "hackProgressBar1";
            this.progressBarCheck.Value = 0;
            this.progressBarCheck.ValueAlignment = SKYNET.Controls.SKYNET_ProgressBar.Alignment.Right;
            this.progressBarCheck.Visible = false;
            // 
            // frmPortScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(616, 401);
            this.Controls.Add(this.progressBarCheck);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPortScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyNet Manager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CloseBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClosePic)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private SKYNET_Button launchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel CloseBox;
        private System.Windows.Forms.PictureBox ClosePic;
        private SKYNET_TextBox SBox;
        private SKYNET_TextBox FBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private SKYNET_TextBox RemoteHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.TextBox txtInfo;
        private SKYNET_TextBox timeOut;
        private System.Windows.Forms.Label label7;
        private SKYNET_ProgressBar progressBarCheck;
        private System.ComponentModel.BackgroundWorker PortWorker;
    }
}