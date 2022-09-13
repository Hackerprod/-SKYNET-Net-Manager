using SKYNET.Properties;
using System.Drawing;

namespace SKYNET
{
    partial class DeviceBox
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
            this.components = new System.ComponentModel.Container();
            this.LB_Name = new System.Windows.Forms.Label();
            this.LB_IPAddress = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.StatusPNL = new System.Windows.Forms.Panel();
            this.StatusICON = new System.Windows.Forms.PictureBox();
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_Name
            // 
            this.LB_Name.AutoSize = true;
            this.LB_Name.Font = new System.Drawing.Font("Arial", 7.75F, System.Drawing.FontStyle.Bold);
            this.LB_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LB_Name.Location = new System.Drawing.Point(39, 4);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(38, 14);
            this.LB_Name.TabIndex = 1;
            this.LB_Name.Text = "Name";
            this.LB_Name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.LB_Name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.LB_Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.LB_Name.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.LB_Name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.LB_Name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // LB_IPAddress
            // 
            this.LB_IPAddress.AutoSize = true;
            this.LB_IPAddress.Font = new System.Drawing.Font("Segoe UI Symbol", 7F);
            this.LB_IPAddress.ForeColor = System.Drawing.Color.Silver;
            this.LB_IPAddress.Location = new System.Drawing.Point(39, 16);
            this.LB_IPAddress.Name = "LB_IPAddress";
            this.LB_IPAddress.Size = new System.Drawing.Size(41, 12);
            this.LB_IPAddress.TabIndex = 2;
            this.LB_IPAddress.Text = "127.0.0.1";
            this.LB_IPAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.LB_IPAddress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.LB_IPAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.LB_IPAddress.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.LB_IPAddress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.LB_IPAddress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI Symbol", 7F);
            this.status.ForeColor = System.Drawing.Color.Silver;
            this.status.Location = new System.Drawing.Point(50, 27);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(34, 12);
            this.status.TabIndex = 3;
            this.status.Text = "Online";
            this.status.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.status.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.status.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.status.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.status.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.status.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // StatusPNL
            // 
            this.StatusPNL.Location = new System.Drawing.Point(145, -4);
            this.StatusPNL.Name = "StatusPNL";
            this.StatusPNL.Size = new System.Drawing.Size(10, 60);
            this.StatusPNL.TabIndex = 5;
            this.StatusPNL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusPNL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            // 
            // StatusICON
            // 
            this.StatusICON.Location = new System.Drawing.Point(43, 30);
            this.StatusICON.Name = "StatusICON";
            this.StatusICON.Size = new System.Drawing.Size(7, 7);
            this.StatusICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StatusICON.TabIndex = 4;
            this.StatusICON.TabStop = false;
            this.StatusICON.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusICON.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.StatusICON.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.StatusICON.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.StatusICON.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // PB_Image
            // 
            this.PB_Image.Image = global::SKYNET.Properties.Resources.OfflinePC;
            this.PB_Image.Location = new System.Drawing.Point(4, 6);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(32, 32);
            this.PB_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Image.TabIndex = 0;
            this.PB_Image.TabStop = false;
            this.PB_Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.PB_Image.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.PB_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.PB_Image.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.PB_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.PB_Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // DeviceBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.StatusPNL);
            this.Controls.Add(this.StatusICON);
            this.Controls.Add(this.status);
            this.Controls.Add(this.LB_IPAddress);
            this.Controls.Add(this.LB_Name);
            this.Controls.Add(this.PB_Image);
            this.Name = "DeviceBox";
            this.Size = new System.Drawing.Size(151, 44);
            this.Load += new System.EventHandler(this.Device_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.Label LB_Name;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox StatusICON;
        private System.Windows.Forms.Label LB_IPAddress;
        private System.Windows.Forms.Panel StatusPNL;

    }
}