using SKYNET.Properties;

namespace SKYNET
{
    partial class frmDeviceInfo
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
            try
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeviceInfo));
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.label3 = new System.Windows.Forms.Label();
            this.DeviceInfo = new System.Windows.Forms.Panel();
            this.deviceHistory1 = new SKYNET.GUI.DeviceHistory();
            this.D_Status = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusDevice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.MAC = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.Label();
            this.DeviceIp = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.CurrentResponseTime = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.AverageResponseTime = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.MinResponseTime = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.MaxResponseTime = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusICON = new System.Windows.Forms.PictureBox();
            this.CurrentStatusDuration = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.GetAliveDuration = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.GetDeadDuration = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.TotalTime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HostDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.ConsecutivePacketsLost = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.LastPacketLost = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.LostPacketsPercent = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LostPackets = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ReceivedPacketsPercent = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ReceivedPackets = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SentPackets = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.HostName = new System.Windows.Forms.Label();
            this.PN_Top.SuspendLayout();
            this.DeviceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Controls.Add(this.label3);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(520, 26);
            this.PN_Top.TabIndex = 5;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 10;
            this.CloseBox.Location = new System.Drawing.Point(486, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 8;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datos del monitoreo";
            // 
            // DeviceInfo
            // 
            this.DeviceInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.DeviceInfo.Controls.Add(this.deviceHistory1);
            this.DeviceInfo.Controls.Add(this.D_Status);
            this.DeviceInfo.Controls.Add(this.label4);
            this.DeviceInfo.Controls.Add(this.label2);
            this.DeviceInfo.Controls.Add(this.StatusDevice);
            this.DeviceInfo.Controls.Add(this.label8);
            this.DeviceInfo.Controls.Add(this.Avatar);
            this.DeviceInfo.Controls.Add(this.MAC);
            this.DeviceInfo.Controls.Add(this.DeviceName);
            this.DeviceInfo.Controls.Add(this.DeviceIp);
            this.DeviceInfo.Location = new System.Drawing.Point(11, 12);
            this.DeviceInfo.Name = "DeviceInfo";
            this.DeviceInfo.Size = new System.Drawing.Size(153, 425);
            this.DeviceInfo.TabIndex = 260;
            // 
            // deviceHistory1
            // 
            this.deviceHistory1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(94)))), ((int)(((byte)(108)))));
            this.deviceHistory1.Location = new System.Drawing.Point(11, 292);
            this.deviceHistory1.Name = "deviceHistory1";
            this.deviceHistory1.Padding = new System.Windows.Forms.Padding(2);
            this.deviceHistory1.Size = new System.Drawing.Size(130, 120);
            this.deviceHistory1.TabIndex = 265;
            // 
            // D_Status
            // 
            this.D_Status.BackColor = System.Drawing.Color.Transparent;
            this.D_Status.Image = global::SKYNET.Properties.Resources.D_Online;
            this.D_Status.Location = new System.Drawing.Point(90, 89);
            this.D_Status.Name = "D_Status";
            this.D_Status.Size = new System.Drawing.Size(20, 20);
            this.D_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.D_Status.TabIndex = 263;
            this.D_Status.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(20, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 262;
            this.label4.Text = "Dirección fisica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(20, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 261;
            this.label2.Text = "Estado de conexión";
            // 
            // StatusDevice
            // 
            this.StatusDevice.AutoSize = true;
            this.StatusDevice.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.StatusDevice.Location = new System.Drawing.Point(20, 175);
            this.StatusDevice.Name = "StatusDevice";
            this.StatusDevice.Size = new System.Drawing.Size(43, 16);
            this.StatusDevice.TabIndex = 260;
            this.StatusDevice.Text = "Online";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(20, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Dirección";
            // 
            // Avatar
            // 
            this.Avatar.Image = global::SKYNET.Properties.Resources.NeutralPC;
            this.Avatar.Location = new System.Drawing.Point(21, 38);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(110, 110);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 29;
            this.Avatar.TabStop = false;
            // 
            // MAC
            // 
            this.MAC.AutoSize = true;
            this.MAC.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.MAC.Location = new System.Drawing.Point(20, 263);
            this.MAC.Name = "MAC";
            this.MAC.Size = new System.Drawing.Size(88, 16);
            this.MAC.TabIndex = 259;
            this.MAC.Text = "Dirección fisica";
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSize = true;
            this.DeviceName.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.DeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.DeviceName.Location = new System.Drawing.Point(5, 12);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Size = new System.Drawing.Size(144, 19);
            this.DeviceName.TabIndex = 257;
            this.DeviceName.Text = "Nombre del equipo";
            // 
            // DeviceIp
            // 
            this.DeviceIp.AutoSize = true;
            this.DeviceIp.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.DeviceIp.Location = new System.Drawing.Point(20, 220);
            this.DeviceIp.Name = "DeviceIp";
            this.DeviceIp.Size = new System.Drawing.Size(58, 16);
            this.DeviceIp.TabIndex = 258;
            this.DeviceIp.Text = "Dirección";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel11.Controls.Add(this.CurrentResponseTime);
            this.panel11.Controls.Add(this.label27);
            this.panel11.Location = new System.Drawing.Point(178, 252);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(328, 18);
            this.panel11.TabIndex = 292;
            // 
            // CurrentResponseTime
            // 
            this.CurrentResponseTime.AutoSize = true;
            this.CurrentResponseTime.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentResponseTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentResponseTime.Location = new System.Drawing.Point(229, 1);
            this.CurrentResponseTime.Name = "CurrentResponseTime";
            this.CurrentResponseTime.Size = new System.Drawing.Size(84, 16);
            this.CurrentResponseTime.TabIndex = 10;
            this.CurrentResponseTime.Text = "Loading info...";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label27.Location = new System.Drawing.Point(3, 1);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 16);
            this.label27.TabIndex = 275;
            this.label27.Text = "Tiempo de respuesta actual";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel10.Controls.Add(this.AverageResponseTime);
            this.panel10.Controls.Add(this.label26);
            this.panel10.Location = new System.Drawing.Point(178, 276);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(328, 18);
            this.panel10.TabIndex = 293;
            // 
            // AverageResponseTime
            // 
            this.AverageResponseTime.AutoSize = true;
            this.AverageResponseTime.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageResponseTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AverageResponseTime.Location = new System.Drawing.Point(229, 1);
            this.AverageResponseTime.Name = "AverageResponseTime";
            this.AverageResponseTime.Size = new System.Drawing.Size(84, 16);
            this.AverageResponseTime.TabIndex = 10;
            this.AverageResponseTime.Text = "Loading info...";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label26.Location = new System.Drawing.Point(3, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(173, 16);
            this.label26.TabIndex = 276;
            this.label26.Text = "Tiempo de respuesta promedio";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel9.Controls.Add(this.MinResponseTime);
            this.panel9.Controls.Add(this.label25);
            this.panel9.Location = new System.Drawing.Point(178, 300);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(328, 18);
            this.panel9.TabIndex = 294;
            // 
            // MinResponseTime
            // 
            this.MinResponseTime.AutoSize = true;
            this.MinResponseTime.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinResponseTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MinResponseTime.Location = new System.Drawing.Point(229, 1);
            this.MinResponseTime.Name = "MinResponseTime";
            this.MinResponseTime.Size = new System.Drawing.Size(84, 16);
            this.MinResponseTime.TabIndex = 10;
            this.MinResponseTime.Text = "Loading info...";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label25.Location = new System.Drawing.Point(3, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(163, 16);
            this.label25.TabIndex = 277;
            this.label25.Text = "Tiempo mínimo de respuesta";
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel26.Controls.Add(this.MaxResponseTime);
            this.panel26.Controls.Add(this.label24);
            this.panel26.Location = new System.Drawing.Point(178, 324);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(328, 18);
            this.panel26.TabIndex = 295;
            // 
            // MaxResponseTime
            // 
            this.MaxResponseTime.AutoSize = true;
            this.MaxResponseTime.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxResponseTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MaxResponseTime.Location = new System.Drawing.Point(229, 1);
            this.MaxResponseTime.Name = "MaxResponseTime";
            this.MaxResponseTime.Size = new System.Drawing.Size(84, 16);
            this.MaxResponseTime.TabIndex = 10;
            this.MaxResponseTime.Text = "Loading info...";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label24.Location = new System.Drawing.Point(3, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(164, 16);
            this.label24.TabIndex = 278;
            this.label24.Text = "Tiempo máximo de respuesta";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel25.Controls.Add(this.StatusLabel);
            this.panel25.Controls.Add(this.StatusICON);
            this.panel25.Controls.Add(this.CurrentStatusDuration);
            this.panel25.Controls.Add(this.label23);
            this.panel25.Location = new System.Drawing.Point(178, 396);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(328, 18);
            this.panel25.TabIndex = 297;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 6F);
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.StatusLabel.Location = new System.Drawing.Point(161, 4);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(29, 11);
            this.StatusLabel.TabIndex = 282;
            this.StatusLabel.Text = "Online";
            // 
            // StatusICON
            // 
            this.StatusICON.Location = new System.Drawing.Point(153, 7);
            this.StatusICON.Name = "StatusICON";
            this.StatusICON.Size = new System.Drawing.Size(7, 7);
            this.StatusICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatusICON.TabIndex = 281;
            this.StatusICON.TabStop = false;
            // 
            // CurrentStatusDuration
            // 
            this.CurrentStatusDuration.AutoSize = true;
            this.CurrentStatusDuration.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatusDuration.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentStatusDuration.Location = new System.Drawing.Point(229, 1);
            this.CurrentStatusDuration.Name = "CurrentStatusDuration";
            this.CurrentStatusDuration.Size = new System.Drawing.Size(84, 16);
            this.CurrentStatusDuration.TabIndex = 10;
            this.CurrentStatusDuration.Text = "Loading info...";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label23.Location = new System.Drawing.Point(3, 1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(148, 16);
            this.label23.TabIndex = 279;
            this.label23.Text = "Duración del estado actual";
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel19.Controls.Add(this.GetAliveDuration);
            this.panel19.Controls.Add(this.label22);
            this.panel19.Location = new System.Drawing.Point(178, 348);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(328, 18);
            this.panel19.TabIndex = 303;
            // 
            // GetAliveDuration
            // 
            this.GetAliveDuration.AutoSize = true;
            this.GetAliveDuration.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetAliveDuration.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GetAliveDuration.Location = new System.Drawing.Point(229, 1);
            this.GetAliveDuration.Name = "GetAliveDuration";
            this.GetAliveDuration.Size = new System.Drawing.Size(84, 16);
            this.GetAliveDuration.TabIndex = 10;
            this.GetAliveDuration.Text = "Loading info...";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label22.Location = new System.Drawing.Point(3, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(167, 16);
            this.label22.TabIndex = 280;
            this.label22.Text = "Tiempo del equipo conectado";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel18.Controls.Add(this.GetDeadDuration);
            this.panel18.Controls.Add(this.label21);
            this.panel18.Location = new System.Drawing.Point(178, 372);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(328, 18);
            this.panel18.TabIndex = 302;
            // 
            // GetDeadDuration
            // 
            this.GetDeadDuration.AutoSize = true;
            this.GetDeadDuration.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDeadDuration.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GetDeadDuration.Location = new System.Drawing.Point(229, 1);
            this.GetDeadDuration.Name = "GetDeadDuration";
            this.GetDeadDuration.Size = new System.Drawing.Size(84, 16);
            this.GetDeadDuration.TabIndex = 10;
            this.GetDeadDuration.Text = "Loading info...";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label21.Location = new System.Drawing.Point(3, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(185, 16);
            this.label21.TabIndex = 281;
            this.label21.Text = "Tiempo del equipo desconectado";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel3.Controls.Add(this.panel15);
            this.panel3.Controls.Add(this.panel18);
            this.panel3.Controls.Add(this.panel19);
            this.panel3.Controls.Add(this.panel25);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel26);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel13);
            this.panel3.Controls.Add(this.panel14);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.DeviceInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 446);
            this.panel3.TabIndex = 8;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel15.Controls.Add(this.TotalTime);
            this.panel15.Controls.Add(this.label14);
            this.panel15.Location = new System.Drawing.Point(178, 420);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(328, 18);
            this.panel15.TabIndex = 304;
            // 
            // TotalTime
            // 
            this.TotalTime.AutoSize = true;
            this.TotalTime.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TotalTime.Location = new System.Drawing.Point(229, 1);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(84, 16);
            this.TotalTime.TabIndex = 10;
            this.TotalTime.Text = "Loading info...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label14.Location = new System.Drawing.Point(3, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(209, 16);
            this.label14.TabIndex = 281;
            this.label14.Text = "Tiempo desde que inició el monitoreo";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.HostDescription);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(178, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 18);
            this.panel2.TabIndex = 284;
            // 
            // HostDescription
            // 
            this.HostDescription.AutoSize = true;
            this.HostDescription.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostDescription.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HostDescription.Location = new System.Drawing.Point(229, 1);
            this.HostDescription.Name = "HostDescription";
            this.HostDescription.Size = new System.Drawing.Size(84, 16);
            this.HostDescription.TabIndex = 10;
            this.HostDescription.Text = "Loading info...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 261;
            this.label1.Text = "Device";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel12.Controls.Add(this.ConsecutivePacketsLost);
            this.panel12.Controls.Add(this.label19);
            this.panel12.Location = new System.Drawing.Point(178, 228);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(328, 18);
            this.panel12.TabIndex = 290;
            // 
            // ConsecutivePacketsLost
            // 
            this.ConsecutivePacketsLost.AutoSize = true;
            this.ConsecutivePacketsLost.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsecutivePacketsLost.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ConsecutivePacketsLost.Location = new System.Drawing.Point(229, 1);
            this.ConsecutivePacketsLost.Name = "ConsecutivePacketsLost";
            this.ConsecutivePacketsLost.Size = new System.Drawing.Size(84, 16);
            this.ConsecutivePacketsLost.TabIndex = 10;
            this.ConsecutivePacketsLost.Text = "Loading info...";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label19.Location = new System.Drawing.Point(3, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(187, 16);
            this.label19.TabIndex = 269;
            this.label19.Text = "Paquetes perdidos (Consecutivos)";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel13.Controls.Add(this.LastPacketLost);
            this.panel13.Controls.Add(this.label11);
            this.panel13.Location = new System.Drawing.Point(178, 204);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(328, 18);
            this.panel13.TabIndex = 291;
            // 
            // LastPacketLost
            // 
            this.LastPacketLost.AutoSize = true;
            this.LastPacketLost.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastPacketLost.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LastPacketLost.Location = new System.Drawing.Point(229, 1);
            this.LastPacketLost.Name = "LastPacketLost";
            this.LastPacketLost.Size = new System.Drawing.Size(84, 16);
            this.LastPacketLost.TabIndex = 10;
            this.LastPacketLost.Text = "Loading info...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label11.Location = new System.Drawing.Point(3, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 16);
            this.label11.TabIndex = 268;
            this.label11.Text = "Último paquete perdido";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel14.Controls.Add(this.LostPacketsPercent);
            this.panel14.Controls.Add(this.label12);
            this.panel14.Location = new System.Drawing.Point(178, 180);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(328, 18);
            this.panel14.TabIndex = 289;
            // 
            // LostPacketsPercent
            // 
            this.LostPacketsPercent.AutoSize = true;
            this.LostPacketsPercent.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LostPacketsPercent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LostPacketsPercent.Location = new System.Drawing.Point(229, 1);
            this.LostPacketsPercent.Name = "LostPacketsPercent";
            this.LostPacketsPercent.Size = new System.Drawing.Size(84, 16);
            this.LostPacketsPercent.TabIndex = 10;
            this.LostPacketsPercent.Text = "Loading info...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label12.Location = new System.Drawing.Point(3, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 16);
            this.label12.TabIndex = 267;
            this.label12.Text = "Porciento de paquetes perdidos";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel6.Controls.Add(this.LostPackets);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Location = new System.Drawing.Point(178, 156);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(328, 18);
            this.panel6.TabIndex = 288;
            // 
            // LostPackets
            // 
            this.LostPackets.AutoSize = true;
            this.LostPackets.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LostPackets.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LostPackets.Location = new System.Drawing.Point(229, 1);
            this.LostPackets.Name = "LostPackets";
            this.LostPackets.Size = new System.Drawing.Size(84, 16);
            this.LostPackets.TabIndex = 10;
            this.LostPackets.Text = "Loading info...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label13.Location = new System.Drawing.Point(3, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 266;
            this.label13.Text = "Paquetes perdidos";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel7.Controls.Add(this.ReceivedPacketsPercent);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(178, 132);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(328, 18);
            this.panel7.TabIndex = 287;
            // 
            // ReceivedPacketsPercent
            // 
            this.ReceivedPacketsPercent.AutoSize = true;
            this.ReceivedPacketsPercent.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceivedPacketsPercent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ReceivedPacketsPercent.Location = new System.Drawing.Point(229, 1);
            this.ReceivedPacketsPercent.Name = "ReceivedPacketsPercent";
            this.ReceivedPacketsPercent.Size = new System.Drawing.Size(84, 16);
            this.ReceivedPacketsPercent.TabIndex = 10;
            this.ReceivedPacketsPercent.Text = "Loading info...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label9.Location = new System.Drawing.Point(3, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 16);
            this.label9.TabIndex = 265;
            this.label9.Text = "Porciento de Packets Recibidos";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel8.Controls.Add(this.ReceivedPackets);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(178, 108);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(328, 18);
            this.panel8.TabIndex = 286;
            // 
            // ReceivedPackets
            // 
            this.ReceivedPackets.AutoSize = true;
            this.ReceivedPackets.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceivedPackets.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ReceivedPackets.Location = new System.Drawing.Point(229, 1);
            this.ReceivedPackets.Name = "ReceivedPackets";
            this.ReceivedPackets.Size = new System.Drawing.Size(84, 16);
            this.ReceivedPackets.TabIndex = 10;
            this.ReceivedPackets.Text = "Loading info...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label7.Location = new System.Drawing.Point(3, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 264;
            this.label7.Text = "Received Packets";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel5.Controls.Add(this.SentPackets);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(178, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 18);
            this.panel5.TabIndex = 285;
            // 
            // SentPackets
            // 
            this.SentPackets.AutoSize = true;
            this.SentPackets.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SentPackets.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SentPackets.Location = new System.Drawing.Point(229, 1);
            this.SentPackets.Name = "SentPackets";
            this.SentPackets.Size = new System.Drawing.Size(84, 16);
            this.SentPackets.TabIndex = 10;
            this.SentPackets.Text = "Loading info...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 263;
            this.label6.Text = "Sent Packets";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel4.Controls.Add(this.Status);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(178, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 18);
            this.panel4.TabIndex = 285;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Status.Location = new System.Drawing.Point(229, 1);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(84, 16);
            this.Status.TabIndex = 10;
            this.Status.Text = "Loading info...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 262;
            this.label5.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.HostName);
            this.panel1.Location = new System.Drawing.Point(178, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 18);
            this.panel1.TabIndex = 283;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label28.Location = new System.Drawing.Point(3, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 16);
            this.label28.TabIndex = 284;
            this.label28.Text = "IP Address";
            // 
            // HostName
            // 
            this.HostName.AutoSize = true;
            this.HostName.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HostName.Location = new System.Drawing.Point(229, 1);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(84, 16);
            this.HostName.TabIndex = 10;
            this.HostName.Text = "Loading info...";
            // 
            // frmDeviceInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(520, 478);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PN_Top);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmDeviceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.PN_Top.ResumeLayout(false);
            this.PN_Top.PerformLayout();
            this.DeviceInfo.ResumeLayout(false);
            this.DeviceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusICON)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel DeviceInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label StatusDevice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label MAC;
        private System.Windows.Forms.Label DeviceName;
        private System.Windows.Forms.Label DeviceIp;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Label CurrentResponseTime;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label AverageResponseTime;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label MinResponseTime;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label MaxResponseTime;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label CurrentStatusDuration;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label GetAliveDuration;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label GetDeadDuration;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label HostDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label ConsecutivePacketsLost;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label LastPacketLost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label LostPacketsPercent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LostPackets;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label ReceivedPacketsPercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label ReceivedPackets;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label SentPackets;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label HostName;
        private System.Windows.Forms.PictureBox D_Status;
        private System.Windows.Forms.PictureBox StatusICON;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label TotalTime;
        private System.Windows.Forms.Label label14;
        private SKYNET.GUI.DeviceHistory deviceHistory1;
        private Controls.SKYNET_Box CloseBox;
    }
}