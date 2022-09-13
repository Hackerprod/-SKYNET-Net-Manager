
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
            this.status = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.NewProfile = new SKYNET.Controls.SKYNET_TextBox();
            this.BT_Create = new SKYNET.SKYNET_Button();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
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
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(333, 28);
            this.PN_Top.TabIndex = 253;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(299, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 0;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // NewProfile
            // 
            this.NewProfile.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.NewProfile.IsPassword = false;
            this.NewProfile.Location = new System.Drawing.Point(15, 56);
            this.NewProfile.Logo = null;
            this.NewProfile.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.NewProfile.Multiline = false;
            this.NewProfile.Name = "NewProfile";
            this.NewProfile.OnlyNumbers = false;
            this.NewProfile.ShowLogo = true;
            this.NewProfile.Size = new System.Drawing.Size(196, 35);
            this.NewProfile.TabIndex = 252;
            this.NewProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // BT_Create
            // 
            this.BT_Create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.BT_Create.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.BT_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Create.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Create.ForeColor = System.Drawing.Color.White;
            this.BT_Create.ForeColorMouseOver = System.Drawing.Color.White;
            this.BT_Create.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.BT_Create.ImageIcon = null;
            this.BT_Create.Location = new System.Drawing.Point(217, 56);
            this.BT_Create.MenuMode = false;
            this.BT_Create.Name = "BT_Create";
            this.BT_Create.Rounded = false;
            this.BT_Create.Size = new System.Drawing.Size(100, 34);
            this.BT_Create.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.BT_Create.TabIndex = 249;
            this.BT_Create.Text = "Create";
            this.BT_Create.Click += new System.EventHandler(this.AceptarBtn_Click);
            // 
            // frmAddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(333, 109);
            this.Controls.Add(this.PN_Top);
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
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmAddProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.PN_Top.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox textBox1;
        private SKYNET_Button BT_Create;
        private System.Windows.Forms.Button button1;
        private SKYNET_TextBox NewProfile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel PN_Top;
        private SKYNET_Box CloseBox;
    }
}