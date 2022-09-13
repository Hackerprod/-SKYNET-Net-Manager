
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlert));
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.Time = new System.Windows.Forms.Label();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.label1.Location = new System.Drawing.Point(131, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 248;
            this.label1.Text = "PING REALIZADO";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.message.Location = new System.Drawing.Point(133, 64);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(191, 17);
            this.message.TabIndex = 249;
            this.message.Text = "El programa ha realizado ping ";
            // 
            // Avatar
            // 
            this.Avatar.Image = global::SKYNET.Properties.Resources.OnlinePC;
            this.Avatar.Location = new System.Drawing.Point(14, 24);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(109, 109);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 246;
            this.Avatar.TabStop = false;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.Time.Location = new System.Drawing.Point(330, 126);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(37, 15);
            this.Time.TabIndex = 250;
            this.Time.Text = "10: 52";
            // 
            // skyneT_Box1
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(342, 1);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "skyneT_Box1";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 251;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(373, 150);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label Time;
        private Controls.SKYNET_Box CloseBox;
    }
}