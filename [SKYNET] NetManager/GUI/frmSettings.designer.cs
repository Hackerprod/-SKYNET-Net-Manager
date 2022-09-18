
using SKYNET.Controls;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyContainer = new System.Windows.Forms.Panel();
            this.TB_Key = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OpacityBar = new System.Windows.Forms.TrackBar();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SearhSound = new SKYNET.SKYNET_Button();
            this.TB_CustomSoundPath = new SKYNET.Controls.SKYNET_TextBox();
            this.TB_TTL = new SKYNET.Controls.SKYNET_TextBox();
            this.TB_BufferSize = new SKYNET.Controls.SKYNET_TextBox();
            this.TB_TimeOut = new SKYNET.Controls.SKYNET_TextBox();
            this.AceptarBtn = new SKYNET.SKYNET_Button();
            this.CB_LaunchWindowsStart = new SKYNET.Controls.SKYNET_Check();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_CustomSound = new SKYNET.Controls.SKYNET_Check();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CB_MinimizeWhenClose = new SKYNET.Controls.SKYNET_Check();
            this.CB_ShowTopPanel = new SKYNET.Controls.SKYNET_Check();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PB_Avatar = new System.Windows.Forms.PictureBox();
            this.TB_UserName = new SKYNET.Controls.SKYNET_TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.CB_ReceiveMessages = new SKYNET.Controls.SKYNET_Check();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.KeyContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            this.PN_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.status.Location = new System.Drawing.Point(359, 177);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 15);
            this.status.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 247;
            this.label1.Text = "Configuración";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(19, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 19);
            this.label2.TabIndex = 254;
            this.label2.Text = "Tecla para Mostrar/Ocultar el programa";
            // 
            // KeyContainer
            // 
            this.KeyContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.KeyContainer.Controls.Add(this.TB_Key);
            this.KeyContainer.Location = new System.Drawing.Point(275, 282);
            this.KeyContainer.Name = "KeyContainer";
            this.KeyContainer.Size = new System.Drawing.Size(54, 25);
            this.KeyContainer.TabIndex = 255;
            this.KeyContainer.Click += new System.EventHandler(this.KeyClick);
            // 
            // TB_Key
            // 
            this.TB_Key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TB_Key.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TB_Key.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TB_Key.Location = new System.Drawing.Point(3, 3);
            this.TB_Key.Name = "TB_Key";
            this.TB_Key.Size = new System.Drawing.Size(48, 19);
            this.TB_Key.TabIndex = 256;
            this.TB_Key.Text = "F8";
            this.TB_Key.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TB_Key.Click += new System.EventHandler(this.KeyClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(358, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 258;
            this.label3.Text = "Opacidad";
            // 
            // OpacityBar
            // 
            this.OpacityBar.Location = new System.Drawing.Point(358, 74);
            this.OpacityBar.Name = "OpacityBar";
            this.OpacityBar.Size = new System.Drawing.Size(322, 45);
            this.OpacityBar.TabIndex = 259;
            this.OpacityBar.Scroll += new System.EventHandler(this.OpacityBar_Scroll);
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Controls.Add(this.label1);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(689, 26);
            this.PN_Top.TabIndex = 260;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 10;
            this.CloseBox.Location = new System.Drawing.Point(655, 0);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 248;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(359, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 261;
            this.label4.Text = "Opciones del monitoreo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(357, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 19);
            this.label5.TabIndex = 263;
            this.label5.Text = "Tiempo de espera";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(486, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 265;
            this.label6.Text = "Tamaño del Buffer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(617, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 19);
            this.label8.TabIndex = 267;
            this.label8.Text = "TTL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(359, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 268;
            this.label7.Text = "Sonido de Alertas";
            // 
            // SearhSound
            // 
            this.SearhSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SearhSound.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.SearhSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearhSound.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearhSound.ForeColor = System.Drawing.Color.White;
            this.SearhSound.ForeColorMouseOver = System.Drawing.Color.White;
            this.SearhSound.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.SearhSound.ImageIcon = null;
            this.SearhSound.Location = new System.Drawing.Point(574, 277);
            this.SearhSound.MenuMode = false;
            this.SearhSound.Name = "SearhSound";
            this.SearhSound.Rounded = false;
            this.SearhSound.Size = new System.Drawing.Size(93, 28);
            this.SearhSound.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.SearhSound.TabIndex = 272;
            this.SearhSound.Text = "Buscar Sonido";
            this.SearhSound.Click += new System.EventHandler(this.SearhSound_Click);
            // 
            // TB_CustomSoundPath
            // 
            this.TB_CustomSoundPath.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_CustomSoundPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_CustomSoundPath.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_CustomSoundPath.IsPassword = false;
            this.TB_CustomSoundPath.Location = new System.Drawing.Point(362, 277);
            this.TB_CustomSoundPath.Logo = null;
            this.TB_CustomSoundPath.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_CustomSoundPath.Multiline = false;
            this.TB_CustomSoundPath.Name = "TB_CustomSoundPath";
            this.TB_CustomSoundPath.OnlyNumbers = false;
            this.TB_CustomSoundPath.ShowLogo = false;
            this.TB_CustomSoundPath.Size = new System.Drawing.Size(206, 28);
            this.TB_CustomSoundPath.TabIndex = 271;
            this.TB_CustomSoundPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TB_TTL
            // 
            this.TB_TTL.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TTL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TTL.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TTL.ForeColor = System.Drawing.Color.White;
            this.TB_TTL.IsPassword = false;
            this.TB_TTL.Location = new System.Drawing.Point(621, 173);
            this.TB_TTL.Logo = null;
            this.TB_TTL.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_TTL.Multiline = false;
            this.TB_TTL.Name = "TB_TTL";
            this.TB_TTL.OnlyNumbers = false;
            this.TB_TTL.ShowLogo = false;
            this.TB_TTL.Size = new System.Drawing.Size(46, 28);
            this.TB_TTL.TabIndex = 266;
            this.TB_TTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TB_BufferSize
            // 
            this.TB_BufferSize.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_BufferSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_BufferSize.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_BufferSize.ForeColor = System.Drawing.Color.White;
            this.TB_BufferSize.IsPassword = false;
            this.TB_BufferSize.Location = new System.Drawing.Point(490, 173);
            this.TB_BufferSize.Logo = null;
            this.TB_BufferSize.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_BufferSize.Multiline = false;
            this.TB_BufferSize.Name = "TB_BufferSize";
            this.TB_BufferSize.OnlyNumbers = false;
            this.TB_BufferSize.ShowLogo = false;
            this.TB_BufferSize.Size = new System.Drawing.Size(113, 28);
            this.TB_BufferSize.TabIndex = 264;
            this.TB_BufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TB_TimeOut
            // 
            this.TB_TimeOut.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TimeOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TimeOut.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_TimeOut.ForeColor = System.Drawing.Color.White;
            this.TB_TimeOut.IsPassword = false;
            this.TB_TimeOut.Location = new System.Drawing.Point(358, 173);
            this.TB_TimeOut.Logo = null;
            this.TB_TimeOut.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_TimeOut.Multiline = false;
            this.TB_TimeOut.Name = "TB_TimeOut";
            this.TB_TimeOut.OnlyNumbers = false;
            this.TB_TimeOut.ShowLogo = false;
            this.TB_TimeOut.Size = new System.Drawing.Size(113, 28);
            this.TB_TimeOut.TabIndex = 262;
            this.TB_TimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // AceptarBtn
            // 
            this.AceptarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.AceptarBtn.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.AceptarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AceptarBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AceptarBtn.ForeColor = System.Drawing.Color.White;
            this.AceptarBtn.ForeColorMouseOver = System.Drawing.Color.White;
            this.AceptarBtn.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.AceptarBtn.ImageIcon = null;
            this.AceptarBtn.Location = new System.Drawing.Point(584, 328);
            this.AceptarBtn.MenuMode = false;
            this.AceptarBtn.Name = "AceptarBtn";
            this.AceptarBtn.Rounded = false;
            this.AceptarBtn.Size = new System.Drawing.Size(93, 25);
            this.AceptarBtn.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.AceptarBtn.TabIndex = 249;
            this.AceptarBtn.Text = "Aceptar";
            this.AceptarBtn.Click += new System.EventHandler(this.AceptarBtn_Click);
            this.AceptarBtn.MouseLeave += new System.EventHandler(this.AceptarBtn_MouseLeave);
            this.AceptarBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AceptarBtn_MouseMove);
            // 
            // CB_LaunchWindowsStart
            // 
            this.CB_LaunchWindowsStart.BackColor = System.Drawing.Color.Transparent;
            this.CB_LaunchWindowsStart.Checked = false;
            this.CB_LaunchWindowsStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_LaunchWindowsStart.Location = new System.Drawing.Point(295, 159);
            this.CB_LaunchWindowsStart.Name = "CB_LaunchWindowsStart";
            this.CB_LaunchWindowsStart.Size = new System.Drawing.Size(34, 25);
            this.CB_LaunchWindowsStart.TabIndex = 274;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(358, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 19);
            this.label9.TabIndex = 275;
            this.label9.Text = "Usar sonido elegido por mi";
            // 
            // CB_CustomSound
            // 
            this.CB_CustomSound.BackColor = System.Drawing.Color.Transparent;
            this.CB_CustomSound.Checked = false;
            this.CB_CustomSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_CustomSound.Location = new System.Drawing.Point(633, 243);
            this.CB_CustomSound.Name = "CB_CustomSound";
            this.CB_CustomSound.Size = new System.Drawing.Size(34, 25);
            this.CB_CustomSound.TabIndex = 276;
            this.CB_CustomSound.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomSound_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(19, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 19);
            this.label10.TabIndex = 277;
            this.label10.Text = "Iniciar con Windows";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(19, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 19);
            this.label11.TabIndex = 278;
            this.label11.Text = "Minimizar al cerrar";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(19, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 19);
            this.label13.TabIndex = 280;
            this.label13.Text = "Mostrar barra superior e inferior";
            // 
            // CB_MinimizeWhenClose
            // 
            this.CB_MinimizeWhenClose.BackColor = System.Drawing.Color.Transparent;
            this.CB_MinimizeWhenClose.Checked = false;
            this.CB_MinimizeWhenClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_MinimizeWhenClose.Location = new System.Drawing.Point(294, 200);
            this.CB_MinimizeWhenClose.Name = "CB_MinimizeWhenClose";
            this.CB_MinimizeWhenClose.Size = new System.Drawing.Size(34, 25);
            this.CB_MinimizeWhenClose.TabIndex = 281;
            // 
            // CB_ShowTopPanel
            // 
            this.CB_ShowTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.CB_ShowTopPanel.Checked = false;
            this.CB_ShowTopPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_ShowTopPanel.Location = new System.Drawing.Point(294, 238);
            this.CB_ShowTopPanel.Name = "CB_ShowTopPanel";
            this.CB_ShowTopPanel.Size = new System.Drawing.Size(34, 25);
            this.CB_ShowTopPanel.TabIndex = 282;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel2.Location = new System.Drawing.Point(23, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 2);
            this.panel2.TabIndex = 284;
            // 
            // PB_Avatar
            // 
            this.PB_Avatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Avatar.Location = new System.Drawing.Point(23, 43);
            this.PB_Avatar.Name = "PB_Avatar";
            this.PB_Avatar.Size = new System.Drawing.Size(100, 98);
            this.PB_Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Avatar.TabIndex = 287;
            this.PB_Avatar.TabStop = false;
            this.PB_Avatar.Click += new System.EventHandler(this.PB_Avatar_Click);
            // 
            // TB_UserName
            // 
            this.TB_UserName.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_UserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_UserName.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TB_UserName.ForeColor = System.Drawing.Color.White;
            this.TB_UserName.IsPassword = false;
            this.TB_UserName.Location = new System.Drawing.Point(136, 74);
            this.TB_UserName.Logo = null;
            this.TB_UserName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_UserName.Multiline = false;
            this.TB_UserName.Name = "TB_UserName";
            this.TB_UserName.OnlyNumbers = false;
            this.TB_UserName.ShowLogo = false;
            this.TB_UserName.Size = new System.Drawing.Size(192, 28);
            this.TB_UserName.TabIndex = 288;
            this.TB_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(132, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 19);
            this.label14.TabIndex = 289;
            this.label14.Text = "Nombre de usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Location = new System.Drawing.Point(23, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 2);
            this.panel1.TabIndex = 290;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(132, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 19);
            this.label15.TabIndex = 291;
            this.label15.Text = "Receive messages";
            // 
            // CB_ReceiveMessages
            // 
            this.CB_ReceiveMessages.BackColor = System.Drawing.Color.Transparent;
            this.CB_ReceiveMessages.Checked = true;
            this.CB_ReceiveMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_ReceiveMessages.Location = new System.Drawing.Point(292, 111);
            this.CB_ReceiveMessages.Name = "CB_ReceiveMessages";
            this.CB_ReceiveMessages.Size = new System.Drawing.Size(34, 25);
            this.CB_ReceiveMessages.TabIndex = 292;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel3.Location = new System.Drawing.Point(23, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 2);
            this.panel3.TabIndex = 285;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel4.Location = new System.Drawing.Point(23, 230);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 2);
            this.panel4.TabIndex = 286;
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(689, 369);
            this.Controls.Add(this.CB_ReceiveMessages);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TB_UserName);
            this.Controls.Add(this.PB_Avatar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CB_ShowTopPanel);
            this.Controls.Add(this.CB_MinimizeWhenClose);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CB_CustomSound);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CB_LaunchWindowsStart);
            this.Controls.Add(this.SearhSound);
            this.Controls.Add(this.TB_CustomSoundPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_TTL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_BufferSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_TimeOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PN_Top);
            this.Controls.Add(this.OpacityBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeyContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AceptarBtn);
            this.Controls.Add(this.status);
            this.DragSize = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).EndInit();
            this.PN_Top.ResumeLayout(false);
            this.PN_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private SKYNET_Button AceptarBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel KeyContainer;
        private System.Windows.Forms.Label TB_Key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Label label4;
        private SKYNET_TextBox TB_TimeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private SKYNET_TextBox TB_BufferSize;
        private System.Windows.Forms.Label label8;
        private SKYNET_TextBox TB_TTL;
        private System.Windows.Forms.Label label7;
        private SKYNET_TextBox TB_CustomSoundPath;
        private SKYNET_Button SearhSound;
        private SKYNET_Check CB_LaunchWindowsStart;
        private System.Windows.Forms.Label label9;
        private SKYNET_Check CB_CustomSound;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private SKYNET_Check CB_MinimizeWhenClose;
        private SKYNET_Check CB_ShowTopPanel;
        private System.Windows.Forms.Panel panel2;
        private SKYNET_Box CloseBox;
        private System.Windows.Forms.PictureBox PB_Avatar;
        private SKYNET_TextBox TB_UserName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private SKYNET_Check CB_ReceiveMessages;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}