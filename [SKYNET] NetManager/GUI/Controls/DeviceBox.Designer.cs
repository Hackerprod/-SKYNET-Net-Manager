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
            this.name = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.StatusPNL = new System.Windows.Forms.Panel();
            this.StatusICON = new System.Windows.Forms.PictureBox();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial", 7.75F, System.Drawing.FontStyle.Bold);
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.name.Location = new System.Drawing.Point(39, 4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 14);
            this.name.TabIndex = 1;
            this.name.Text = "Name";
            this.name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.name.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Segoe UI Symbol", 7F);
            this.ip.ForeColor = System.Drawing.Color.Silver;
            this.ip.Location = new System.Drawing.Point(39, 16);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(41, 12);
            this.ip.TabIndex = 2;
            this.ip.Text = "127.0.0.1";
            this.ip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.ip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.ip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.ip.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.ip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.ip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
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
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(4, 6);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(32, 32);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            this.Avatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.Avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.Avatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseDown);
            this.Avatar.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.Avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.Avatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusICON_MouseUp);
            // 
            // DeviceBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.StatusPNL);
            this.Controls.Add(this.StatusICON);
            this.Controls.Add(this.status);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Avatar);
            this.Name = "DeviceBox";
            this.Size = new System.Drawing.Size(151, 44);
            this.Load += new System.EventHandler(this.Device_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox StatusICON;
        private System.Windows.Forms.Label ip;
        private System.Windows.Forms.Panel StatusPNL;

        private string _BoxName { get; set; }
        public string BoxName
        {
            get
            {
                return _BoxName;
            }
            set
            {
                _BoxName = value;
                name.Text = value;
            }
        }
        private Image _BoxImage { get; set; }
        public Image BoxImage
        {
            get
            {
                return _BoxImage;
            }
            set
            {
                _BoxImage = value;
            }
        }
        private int _Orden { get; set; }
        public int Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }
        public string Ping { get; set; }
        private bool _isWeb { get; set; }
        public bool isWeb
        {
            get
            {
                return _isWeb;
            }
            set
            {
                _isWeb = value;
                if (value == true)
                {
                    SetAvatar(Resources.glob_v2);
                }
                else
                {
                    SetAvatar(Resources.NeutralPC);
                }
            }
        }
        private string _IpName { get; set; }
        public string IpName
        {
            get
            {
                return _IpName;
            }
            set
            {
                _IpName = value;
                ip.Text = value;
            }
        }

    }
}