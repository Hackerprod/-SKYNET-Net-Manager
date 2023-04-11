using SKYNET.Controls;

namespace SKYNET
{
    partial class frmSystemMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemMessage));
            this.ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Accept = new SKYNET.SKYNET_Button();
            this.TB_Message = new System.Windows.Forms.TextBox();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.Header = new System.Windows.Forms.Label();
            this.TB_DelayTime = new SKYNET.Controls.SKYNET_TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Lenght = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(483, 145);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(18, 23);
            this.ok.TabIndex = 24;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.LB_Lenght);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TB_Message);
            this.panel1.Controls.Add(this.TB_DelayTime);
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Controls.Add(this.Header);
            this.panel1.Controls.Add(this.PN_Top);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 352);
            this.panel1.TabIndex = 25;
            // 
            // btn_Accept
            // 
            this.btn_Accept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.btn_Accept.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.btn_Accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Accept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Accept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Accept.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.btn_Accept.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.btn_Accept.ImageIcon = null;
            this.btn_Accept.Location = new System.Drawing.Point(372, 311);
            this.btn_Accept.MenuMode = false;
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Rounded = false;
            this.btn_Accept.Size = new System.Drawing.Size(93, 29);
            this.btn_Accept.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.btn_Accept.TabIndex = 27;
            this.btn_Accept.Text = "Send";
            this.btn_Accept.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // TB_Message
            // 
            this.TB_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Message.Cursor = System.Windows.Forms.Cursors.Default;
            this.TB_Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_Message.Location = new System.Drawing.Point(10, 108);
            this.TB_Message.Multiline = true;
            this.TB_Message.Name = "TB_Message";
            this.TB_Message.Size = new System.Drawing.Size(455, 197);
            this.TB_Message.TabIndex = 26;
            this.TB_Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Message_KeyDown);
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(477, 26);
            this.PN_Top.TabIndex = 24;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 10;
            this.CloseBox.Location = new System.Drawing.Point(443, 0);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 249;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(7, 35);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(144, 16);
            this.Header.TabIndex = 0;
            this.Header.Text = "Message delay in seconds";
            // 
            // TB_DelayTime
            // 
            this.TB_DelayTime.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_DelayTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_DelayTime.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_DelayTime.ForeColor = System.Drawing.Color.White;
            this.TB_DelayTime.IsPassword = false;
            this.TB_DelayTime.Location = new System.Drawing.Point(10, 54);
            this.TB_DelayTime.Logo = null;
            this.TB_DelayTime.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_DelayTime.Multiline = false;
            this.TB_DelayTime.Name = "TB_DelayTime";
            this.TB_DelayTime.OnlyNumbers = false;
            this.TB_DelayTime.ShowLogo = false;
            this.TB_DelayTime.Size = new System.Drawing.Size(455, 28);
            this.TB_DelayTime.TabIndex = 289;
            this.TB_DelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 290;
            this.label1.Text = "Message";
            // 
            // LB_Lenght
            // 
            this.LB_Lenght.AutoSize = true;
            this.LB_Lenght.ForeColor = System.Drawing.Color.White;
            this.LB_Lenght.Location = new System.Drawing.Point(7, 311);
            this.LB_Lenght.Name = "LB_Lenght";
            this.LB_Lenght.Size = new System.Drawing.Size(43, 16);
            this.LB_Lenght.TabIndex = 291;
            this.LB_Lenght.Text = "0 / 240";
            // 
            // frmSystemMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(477, 352);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmSystemMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PN_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Panel panel1;
        private SKYNET_Button btn_Accept;
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.TextBox TB_Message;
        private SKYNET_Box CloseBox;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Label label1;
        private SKYNET_TextBox TB_DelayTime;
        private System.Windows.Forms.Label LB_Lenght;
    }
}