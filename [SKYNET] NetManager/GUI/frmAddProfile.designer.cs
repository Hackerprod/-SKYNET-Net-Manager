
using SKYNET.Controls;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmAddProfile
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
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch { }

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProfile));
            this.panelClose = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.status = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewProfile = new SKYNET.Controls.SKYNET_TextBox();
            this.BT_Create = new SKYNET.Controls.SKYNET_Button();
            this.panelClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelClose
            // 
            this.panelClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panelClose.Controls.Add(this.closeBtn);
            this.panelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClose.Location = new System.Drawing.Point(295, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(38, 28);
            this.panelClose.TabIndex = 5;
            this.panelClose.Click += new System.EventHandler(this.closeBtn_Click);
            this.panelClose.MouseLeave += new System.EventHandler(this.panelClose_MouseLeave);
            this.panelClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelClose_MouseMove);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::SKYNET.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(11, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBtn.TabIndex = 4;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseLeave += new System.EventHandler(this.panelClose_MouseLeave);
            this.closeBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelClose_MouseMove);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.status.Location = new System.Drawing.Point(14, 271);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 15);
            this.status.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(378, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(17, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(361, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 250;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 251;
            this.label10.Text = "Profile name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.panelClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 28);
            this.panel1.TabIndex = 253;
            // 
            // NewProfile
            // 
            this.NewProfile.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NewProfile.IsPassword = false;
            this.NewProfile.Location = new System.Drawing.Point(15, 56);
            this.NewProfile.Logo = null;
            this.NewProfile.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.NewProfile.Name = "NewProfile";
            this.NewProfile.OnlyNumber = false;
            this.NewProfile.ShowLogo = true;
            this.NewProfile.Size = new System.Drawing.Size(196, 35);
            this.NewProfile.TabIndex = 252;
            this.NewProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeviceName_KeyDown);
            // 
            // BT_Create
            // 
            this.BT_Create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.BT_Create.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.BT_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Create.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Create.ForeColor = System.Drawing.Color.White;
            this.BT_Create.ForeColorMouseOver = System.Drawing.Color.White;
            this.BT_Create.ImageAlignment = SKYNET.Controls.SKYNET_Button._ImgAlign.Left;
            this.BT_Create.ImageIcon = null;
            this.BT_Create.Location = new System.Drawing.Point(217, 56);
            this.BT_Create.MenuMode = false;
            this.BT_Create.Name = "BT_Create";
            this.BT_Create.Rounded = false;
            this.BT_Create.Size = new System.Drawing.Size(100, 34);
            this.BT_Create.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Create.TabIndex = 249;
            this.BT_Create.Text = "Create";
            this.BT_Create.Click += new System.EventHandler(this.AceptarBtn_Click);
            this.BT_Create.MouseLeave += new System.EventHandler(this.AceptarBtn_MouseLeave);
            this.BT_Create.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AceptarBtn_MouseMove);
            // 
            // frmAddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(333, 109);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NewProfile);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BT_Create);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyNet Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            this.panelClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelClose;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox textBox1;
        private SKYNET_Button BT_Create;
        private System.Windows.Forms.Button button1;
        private SKYNET_TextBox NewProfile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
    }
}