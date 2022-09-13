
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyContainer = new System.Windows.Forms.Panel();
            this.TB_KeyLabel = new System.Windows.Forms.Label();
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
            this.CustomSoundPatch = new SKYNET.Controls.SKYNET_TextBox();
            this.TTL = new SKYNET.Controls.SKYNET_TextBox();
            this.BufferSize = new SKYNET.Controls.SKYNET_TextBox();
            this.TimeOut = new SKYNET.Controls.SKYNET_TextBox();
            this.AceptarBtn = new SKYNET.SKYNET_Button();
            this.launchWindowsBox = new SKYNET.Controls.SKYNET_Check();
            this.label9 = new System.Windows.Forms.Label();
            this.CustomSound = new SKYNET.Controls.SKYNET_Check();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.minimizeBox = new SKYNET.Controls.SKYNET_Check();
            this.ShowTopPanel = new SKYNET.Controls.SKYNET_Check();
            this.ShowInLeft = new SKYNET.Controls.SKYNET_Check();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.KeyContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.status.Location = new System.Drawing.Point(20, 316);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(18, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 19);
            this.label2.TabIndex = 254;
            this.label2.Text = "Tecla para Mostrar/Ocultar el programa";
            // 
            // KeyContainer
            // 
            this.KeyContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.KeyContainer.Controls.Add(this.TB_KeyLabel);
            this.KeyContainer.Location = new System.Drawing.Point(274, 173);
            this.KeyContainer.Name = "KeyContainer";
            this.KeyContainer.Size = new System.Drawing.Size(54, 25);
            this.KeyContainer.TabIndex = 255;
            this.KeyContainer.Click += new System.EventHandler(this.KeyClick);
            // 
            // TB_KeyLabel
            // 
            this.TB_KeyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TB_KeyLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TB_KeyLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TB_KeyLabel.Location = new System.Drawing.Point(3, 3);
            this.TB_KeyLabel.Name = "TB_KeyLabel";
            this.TB_KeyLabel.Size = new System.Drawing.Size(48, 19);
            this.TB_KeyLabel.TabIndex = 256;
            this.TB_KeyLabel.Text = "F8";
            this.TB_KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TB_KeyLabel.Click += new System.EventHandler(this.KeyClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(19, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 258;
            this.label3.Text = "Opacidad";
            // 
            // OpacityBar
            // 
            this.OpacityBar.Location = new System.Drawing.Point(16, 225);
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
            this.PN_Top.Size = new System.Drawing.Size(351, 26);
            this.PN_Top.TabIndex = 260;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(317, 0);
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
            this.label4.Location = new System.Drawing.Point(20, 267);
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
            this.label5.Location = new System.Drawing.Point(18, 288);
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
            this.label6.Location = new System.Drawing.Point(147, 288);
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
            this.label8.Location = new System.Drawing.Point(278, 288);
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
            this.label7.Location = new System.Drawing.Point(20, 349);
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
            this.SearhSound.Location = new System.Drawing.Point(235, 404);
            this.SearhSound.MenuMode = false;
            this.SearhSound.Name = "SearhSound";
            this.SearhSound.Rounded = false;
            this.SearhSound.Size = new System.Drawing.Size(93, 28);
            this.SearhSound.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.SearhSound.TabIndex = 272;
            this.SearhSound.Text = "Buscar Sonido";
            this.SearhSound.Click += new System.EventHandler(this.SearhSound_Click);
            // 
            // CustomSoundPatch
            // 
            this.CustomSoundPatch.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.CustomSoundPatch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.CustomSoundPatch.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.CustomSoundPatch.IsPassword = false;
            this.CustomSoundPatch.Location = new System.Drawing.Point(23, 404);
            this.CustomSoundPatch.Logo = null;
            this.CustomSoundPatch.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.CustomSoundPatch.Multiline = false;
            this.CustomSoundPatch.Name = "CustomSoundPatch";
            this.CustomSoundPatch.OnlyNumbers = false;
            this.CustomSoundPatch.ShowLogo = false;
            this.CustomSoundPatch.Size = new System.Drawing.Size(206, 28);
            this.CustomSoundPatch.TabIndex = 271;
            this.CustomSoundPatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TTL
            // 
            this.TTL.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TTL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TTL.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TTL.IsPassword = false;
            this.TTL.Location = new System.Drawing.Point(282, 310);
            this.TTL.Logo = null;
            this.TTL.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TTL.Multiline = false;
            this.TTL.Name = "TTL";
            this.TTL.OnlyNumbers = false;
            this.TTL.ShowLogo = false;
            this.TTL.Size = new System.Drawing.Size(46, 28);
            this.TTL.TabIndex = 266;
            this.TTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // BufferSize
            // 
            this.BufferSize.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.BufferSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.BufferSize.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.BufferSize.IsPassword = false;
            this.BufferSize.Location = new System.Drawing.Point(151, 310);
            this.BufferSize.Logo = null;
            this.BufferSize.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.BufferSize.Multiline = false;
            this.BufferSize.Name = "BufferSize";
            this.BufferSize.OnlyNumbers = false;
            this.BufferSize.ShowLogo = false;
            this.BufferSize.Size = new System.Drawing.Size(113, 28);
            this.BufferSize.TabIndex = 264;
            this.BufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TimeOut
            // 
            this.TimeOut.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TimeOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TimeOut.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.TimeOut.IsPassword = false;
            this.TimeOut.Location = new System.Drawing.Point(19, 310);
            this.TimeOut.Logo = null;
            this.TimeOut.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TimeOut.Multiline = false;
            this.TimeOut.Name = "TimeOut";
            this.TimeOut.OnlyNumbers = false;
            this.TimeOut.ShowLogo = false;
            this.TimeOut.Size = new System.Drawing.Size(113, 28);
            this.TimeOut.TabIndex = 262;
            this.TimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.AceptarBtn.Location = new System.Drawing.Point(235, 449);
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
            // launchWindowsBox
            // 
            this.launchWindowsBox.BackColor = System.Drawing.Color.Transparent;
            this.launchWindowsBox.Checked = false;
            this.launchWindowsBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.launchWindowsBox.Location = new System.Drawing.Point(294, 35);
            this.launchWindowsBox.Name = "launchWindowsBox";
            this.launchWindowsBox.Size = new System.Drawing.Size(34, 25);
            this.launchWindowsBox.TabIndex = 274;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(19, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 19);
            this.label9.TabIndex = 275;
            this.label9.Text = "Usar sonido elegido por mi";
            // 
            // CustomSound
            // 
            this.CustomSound.BackColor = System.Drawing.Color.Transparent;
            this.CustomSound.Checked = false;
            this.CustomSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomSound.Location = new System.Drawing.Point(294, 375);
            this.CustomSound.Name = "CustomSound";
            this.CustomSound.Size = new System.Drawing.Size(34, 25);
            this.CustomSound.TabIndex = 276;
            this.CustomSound.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomSound_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(19, 39);
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
            this.label11.Location = new System.Drawing.Point(19, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 19);
            this.label11.TabIndex = 278;
            this.label11.Text = "Minimizar al cerrar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(19, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 19);
            this.label12.TabIndex = 279;
            this.label12.Text = "Mostrar programa a la izquierda";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(19, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 19);
            this.label13.TabIndex = 280;
            this.label13.Text = "Mostrar barra superior e inferior";
            // 
            // minimizeBox
            // 
            this.minimizeBox.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBox.Checked = false;
            this.minimizeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBox.Location = new System.Drawing.Point(294, 69);
            this.minimizeBox.Name = "minimizeBox";
            this.minimizeBox.Size = new System.Drawing.Size(34, 25);
            this.minimizeBox.TabIndex = 281;
            // 
            // ShowTopPanel
            // 
            this.ShowTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.ShowTopPanel.Checked = false;
            this.ShowTopPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowTopPanel.Location = new System.Drawing.Point(294, 136);
            this.ShowTopPanel.Name = "ShowTopPanel";
            this.ShowTopPanel.Size = new System.Drawing.Size(34, 25);
            this.ShowTopPanel.TabIndex = 282;
            // 
            // ShowInLeft
            // 
            this.ShowInLeft.BackColor = System.Drawing.Color.Transparent;
            this.ShowInLeft.Checked = false;
            this.ShowInLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowInLeft.Location = new System.Drawing.Point(294, 102);
            this.ShowInLeft.Name = "ShowInLeft";
            this.ShowInLeft.Size = new System.Drawing.Size(34, 25);
            this.ShowInLeft.TabIndex = 283;
            this.ShowInLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowInLeft_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel2.Location = new System.Drawing.Point(23, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 2);
            this.panel2.TabIndex = 284;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel3.Location = new System.Drawing.Point(23, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 2);
            this.panel3.TabIndex = 285;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel4.Location = new System.Drawing.Point(23, 131);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 2);
            this.panel4.TabIndex = 286;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel5.Location = new System.Drawing.Point(23, 165);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(305, 2);
            this.panel5.TabIndex = 287;
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(351, 493);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ShowInLeft);
            this.Controls.Add(this.ShowTopPanel);
            this.Controls.Add(this.minimizeBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CustomSound);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.launchWindowsBox);
            this.Controls.Add(this.SearhSound);
            this.Controls.Add(this.CustomSoundPatch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TTL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BufferSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TimeOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PN_Top);
            this.Controls.Add(this.OpacityBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeyContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AceptarBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.status);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private SKYNET_Button AceptarBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel KeyContainer;
        private System.Windows.Forms.Label TB_KeyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Label label4;
        private SKYNET_TextBox TimeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private SKYNET_TextBox BufferSize;
        private System.Windows.Forms.Label label8;
        private SKYNET_TextBox TTL;
        private System.Windows.Forms.Label label7;
        private SKYNET_TextBox CustomSoundPatch;
        private SKYNET_Button SearhSound;
        private SKYNET_Check launchWindowsBox;
        private System.Windows.Forms.Label label9;
        private SKYNET_Check CustomSound;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private SKYNET_Check minimizeBox;
        private SKYNET_Check ShowTopPanel;
        private SKYNET_Check ShowInLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private SKYNET_Box CloseBox;
    }
}