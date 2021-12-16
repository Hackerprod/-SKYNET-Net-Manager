using SkynetManager.Properties;
using System.Drawing;

namespace SkynetManager
{
    partial class Device
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));

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
            this.name.Font = new System.Drawing.Font("Segoe UI Symbol", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.name.Location = new System.Drawing.Point(37, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(34, 12);
            this.name.TabIndex = 1;
            this.name.Text = "Name";
            this.name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.name.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Segoe UI Symbol", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.ip.Location = new System.Drawing.Point(37, 13);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(41, 12);
            this.ip.TabIndex = 2;
            this.ip.Text = "127.0.0.1";
            this.ip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.ip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.ip.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.ip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI Symbol", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.status.Location = new System.Drawing.Point(48, 24);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(29, 11);
            this.status.TabIndex = 3;
            this.status.Text = "Online";
            this.status.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.status.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.status.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.status.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // StatusPNL
            // 
            this.StatusPNL.Location = new System.Drawing.Point(124, -4);
            this.StatusPNL.Name = "StatusPNL";
            this.StatusPNL.Size = new System.Drawing.Size(10, 60);
            this.StatusPNL.TabIndex = 5;
            this.StatusPNL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusPNL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            // 
            // StatusICON
            // 
            this.StatusICON.Location = new System.Drawing.Point(41, 27);
            this.StatusICON.Name = "StatusICON";
            this.StatusICON.Size = new System.Drawing.Size(7, 7);
            this.StatusICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StatusICON.TabIndex = 4;
            this.StatusICON.TabStop = false;
            this.StatusICON.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.StatusICON.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.StatusICON.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            // 
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(5, 5);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(28, 28);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            this.Avatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseClick);
            this.Avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDoubleClick);
            this.Avatar.MouseCaptureChanged += new System.EventHandler(this.Avatar_MouseCaptureChanged);
            this.Avatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.Avatar.MouseLeave += new System.EventHandler(this.Box_MouseLeave);
            this.Avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.Avatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // BoxTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.StatusPNL);
            this.Controls.Add(this.StatusICON);
            this.Controls.Add(this.status);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Avatar);
            this.Name = "BoxTool";
            this.Size = new System.Drawing.Size(129, 39);
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