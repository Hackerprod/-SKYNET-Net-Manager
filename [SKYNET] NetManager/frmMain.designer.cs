
using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.status = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ClearLabel = new System.Windows.Forms.Timer(this.components);
            this.LB_Tittle = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.SettingsBox = new SKYNET.Controls.SKYNET_Box();
            this.MinimizeBox = new SKYNET.Controls.SKYNET_Box();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.PanelTransfer = new System.Windows.Forms.Panel();
            this.panelReceived = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSent = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ReceivedPerSecond = new System.Windows.Forms.Label();
            this.SentPerSecond = new System.Windows.Forms.Label();
            this.Received = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Sent = new System.Windows.Forms.Label();
            this.byHackerprod = new System.Windows.Forms.Label();
            this.ProfileSelected = new System.Windows.Forms.Label();
            this.shadow = new SKYNET.Controls.SKYNET_ShadowBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DeviceContainer = new SKYNET.GUI.MetroPanel();
            this.WelcomeBox = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerTransfer = new System.Windows.Forms.Timer(this.components);
            this.BoxMenu = new SKYNET.SKYNET_ContextMenuStrip();
            this.HerramientasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevicePingInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PuertosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorarPCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacerPingPorCMDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PingConstante = new System.Windows.Forms.ToolStripMenuItem();
            this.OnlineAlertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OfflineAlertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarMensajeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseBoxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TryMenu = new SKYNET.SKYNET_ContextMenuStrip();
            this.MostrarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEquipoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarEquiposMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPerfilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new SKYNET.SKYNET_ContextMenuStrip();
            this.menu_AddDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Profiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SearchDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.globalChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelBottom.SuspendLayout();
            this.PanelTransfer.SuspendLayout();
            this.panelReceived.SuspendLayout();
            this.panelSent.SuspendLayout();
            this.panel2.SuspendLayout();
            this.DeviceContainer.SuspendLayout();
            this.WelcomeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.BoxMenu.SuspendLayout();
            this.TryMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
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
            // ClearLabel
            // 
            this.ClearLabel.Enabled = true;
            this.ClearLabel.Interval = 60000;
            // 
            // LB_Tittle
            // 
            this.LB_Tittle.AutoSize = true;
            this.LB_Tittle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.LB_Tittle.ForeColor = System.Drawing.Color.White;
            this.LB_Tittle.Location = new System.Drawing.Point(27, 6);
            this.LB_Tittle.Name = "LB_Tittle";
            this.LB_Tittle.Size = new System.Drawing.Size(85, 13);
            this.LB_Tittle.TabIndex = 247;
            this.LB_Tittle.Text = "Net Manager";
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TopPanel.Controls.Add(this.SettingsBox);
            this.TopPanel.Controls.Add(this.MinimizeBox);
            this.TopPanel.Controls.Add(this.CloseBox);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Controls.Add(this.LB_Tittle);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(329, 28);
            this.TopPanel.TabIndex = 248;
            // 
            // SettingsBox
            // 
            this.SettingsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.SettingsBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.SettingsBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingsBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.SettingsBox.Image = null;
            this.SettingsBox.ImageSize = 12;
            this.SettingsBox.Location = new System.Drawing.Point(227, 0);
            this.SettingsBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.SettingsBox.MenuMode = true;
            this.SettingsBox.MenuSeparation = 9;
            this.SettingsBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(34, 26);
            this.SettingsBox.TabIndex = 251;
            this.SettingsBox.BoxClicked += new System.EventHandler(this.SettingsBox_BoxClicked);
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.MinimizeBox.Image = global::SKYNET.Properties.Resources.minimise;
            this.MinimizeBox.ImageSize = 10;
            this.MinimizeBox.Location = new System.Drawing.Point(261, 0);
            this.MinimizeBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.MenuMode = false;
            this.MinimizeBox.MenuSeparation = 8;
            this.MinimizeBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(34, 26);
            this.MinimizeBox.TabIndex = 250;
            this.MinimizeBox.BoxClicked += new System.EventHandler(this.MinimizeBox_BoxClicked);
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 10;
            this.CloseBox.Location = new System.Drawing.Point(295, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 249;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SKYNET.Properties.Resources.OnlinePC;
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 246;
            this.pictureBox1.TabStop = false;
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PanelBottom.Controls.Add(this.PanelTransfer);
            this.PanelBottom.Controls.Add(this.byHackerprod);
            this.PanelBottom.Controls.Add(this.ProfileSelected);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottom.Location = new System.Drawing.Point(0, 639);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(329, 50);
            this.PanelBottom.TabIndex = 249;
            this.PanelBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelBottom_MouseMove);
            // 
            // PanelTransfer
            // 
            this.PanelTransfer.Controls.Add(this.panelReceived);
            this.PanelTransfer.Controls.Add(this.panelSent);
            this.PanelTransfer.Controls.Add(this.ReceivedPerSecond);
            this.PanelTransfer.Controls.Add(this.SentPerSecond);
            this.PanelTransfer.Controls.Add(this.Received);
            this.PanelTransfer.Controls.Add(this.label7);
            this.PanelTransfer.Controls.Add(this.label8);
            this.PanelTransfer.Controls.Add(this.Sent);
            this.PanelTransfer.Location = new System.Drawing.Point(86, 6);
            this.PanelTransfer.Name = "PanelTransfer";
            this.PanelTransfer.Size = new System.Drawing.Size(244, 55);
            this.PanelTransfer.TabIndex = 30;
            // 
            // panelReceived
            // 
            this.panelReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(141)))), ((int)(((byte)(230)))));
            this.panelReceived.Controls.Add(this.label5);
            this.panelReceived.Location = new System.Drawing.Point(4, 34);
            this.panelReceived.Name = "panelReceived";
            this.panelReceived.Size = new System.Drawing.Size(48, 12);
            this.panelReceived.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 7.5F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Receiced";
            // 
            // panelSent
            // 
            this.panelSent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(141)))), ((int)(((byte)(230)))));
            this.panelSent.Controls.Add(this.label6);
            this.panelSent.Location = new System.Drawing.Point(4, 19);
            this.panelSent.Name = "panelSent";
            this.panelSent.Size = new System.Drawing.Size(48, 12);
            this.panelSent.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 7.5F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sent";
            // 
            // ReceivedPerSecond
            // 
            this.ReceivedPerSecond.AutoSize = true;
            this.ReceivedPerSecond.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.ReceivedPerSecond.ForeColor = System.Drawing.Color.White;
            this.ReceivedPerSecond.Location = new System.Drawing.Point(158, 33);
            this.ReceivedPerSecond.Name = "ReceivedPerSecond";
            this.ReceivedPerSecond.Size = new System.Drawing.Size(10, 15);
            this.ReceivedPerSecond.TabIndex = 13;
            this.ReceivedPerSecond.Text = " ";
            // 
            // SentPerSecond
            // 
            this.SentPerSecond.AutoSize = true;
            this.SentPerSecond.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.SentPerSecond.ForeColor = System.Drawing.Color.White;
            this.SentPerSecond.Location = new System.Drawing.Point(158, 17);
            this.SentPerSecond.Name = "SentPerSecond";
            this.SentPerSecond.Size = new System.Drawing.Size(10, 15);
            this.SentPerSecond.TabIndex = 12;
            this.SentPerSecond.Text = " ";
            // 
            // Received
            // 
            this.Received.AutoSize = true;
            this.Received.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.Received.ForeColor = System.Drawing.Color.White;
            this.Received.Location = new System.Drawing.Point(84, 33);
            this.Received.Name = "Received";
            this.Received.Size = new System.Drawing.Size(10, 15);
            this.Received.TabIndex = 11;
            this.Received.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 7F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(157, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "ANCHO DE BANDA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(84, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "BYTES";
            // 
            // Sent
            // 
            this.Sent.AutoSize = true;
            this.Sent.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.Sent.ForeColor = System.Drawing.Color.White;
            this.Sent.Location = new System.Drawing.Point(84, 17);
            this.Sent.Name = "Sent";
            this.Sent.Size = new System.Drawing.Size(10, 15);
            this.Sent.TabIndex = 9;
            this.Sent.Text = " ";
            // 
            // byHackerprod
            // 
            this.byHackerprod.AutoSize = true;
            this.byHackerprod.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.byHackerprod.ForeColor = System.Drawing.Color.Silver;
            this.byHackerprod.Location = new System.Drawing.Point(248, 0);
            this.byHackerprod.Name = "byHackerprod";
            this.byHackerprod.Size = new System.Drawing.Size(82, 15);
            this.byHackerprod.TabIndex = 13;
            this.byHackerprod.Text = "by Hackerprod";
            this.byHackerprod.Click += new System.EventHandler(this.ByHackerprod_Click);
            this.byHackerprod.MouseLeave += new System.EventHandler(this.ByHackerprod_MouseLeave);
            // 
            // ProfileSelected
            // 
            this.ProfileSelected.AutoSize = true;
            this.ProfileSelected.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.ProfileSelected.ForeColor = System.Drawing.Color.Silver;
            this.ProfileSelected.Location = new System.Drawing.Point(0, 0);
            this.ProfileSelected.Name = "ProfileSelected";
            this.ProfileSelected.Size = new System.Drawing.Size(67, 15);
            this.ProfileSelected.TabIndex = 12;
            this.ProfileSelected.Text = "Perfil actual";
            // 
            // shadow
            // 
            this.shadow.BackColor = System.Drawing.Color.Transparent;
            this.shadow.Color = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.shadow.Location = new System.Drawing.Point(0, 0);
            this.shadow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.shadow.Name = "shadow";
            this.shadow.Opacity = 70;
            this.shadow.Size = new System.Drawing.Size(0, 0);
            this.shadow.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DeviceContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 611);
            this.panel2.TabIndex = 250;
            // 
            // DeviceContainer
            // 
            this.DeviceContainer.AutoScroll = true;
            this.DeviceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.DeviceContainer.Controls.Add(this.WelcomeBox);
            this.DeviceContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceContainer.HorizontalScrollbar = true;
            this.DeviceContainer.HorizontalScrollbarBarColor = false;
            this.DeviceContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.DeviceContainer.HorizontalScrollbarSize = 10;
            this.DeviceContainer.Location = new System.Drawing.Point(0, 0);
            this.DeviceContainer.Name = "DeviceContainer";
            this.DeviceContainer.Size = new System.Drawing.Size(329, 611);
            this.DeviceContainer.TabIndex = 25;
            this.DeviceContainer.UseSelectable = true;
            this.DeviceContainer.VerticalScrollbar = true;
            this.DeviceContainer.VerticalScrollbarBarColor = true;
            this.DeviceContainer.VerticalScrollbarHighlightOnWheel = false;
            this.DeviceContainer.VerticalScrollbarSize = 10;
            this.DeviceContainer.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.DeviceContainer_ControlModifiqued);
            this.DeviceContainer.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.DeviceContainer_ControlModifiqued);
            this.DeviceContainer.MouseLeave += new System.EventHandler(this.DeviceContainer_MouseLeave);
            // 
            // WelcomeBox
            // 
            this.WelcomeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.WelcomeBox.Controls.Add(this.label4);
            this.WelcomeBox.Controls.Add(this.label3);
            this.WelcomeBox.Controls.Add(this.label2);
            this.WelcomeBox.Controls.Add(this.pictureBox2);
            this.WelcomeBox.Location = new System.Drawing.Point(67, 143);
            this.WelcomeBox.Name = "WelcomeBox";
            this.WelcomeBox.Size = new System.Drawing.Size(200, 210);
            this.WelcomeBox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(187)))), ((int)(((byte)(190)))));
            this.label4.Location = new System.Drawing.Point(45, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "PARA CONTINUAR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(187)))), ((int)(((byte)(190)))));
            this.label3.Location = new System.Drawing.Point(32, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "O AGREGUE UN EQUIPO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(187)))), ((int)(((byte)(190)))));
            this.label2.Location = new System.Drawing.Point(34, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "SELECCIONE UN PERFIL";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SKYNET.Properties.Resources.OnlinePC;
            this.pictureBox2.Location = new System.Drawing.Point(51, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // timerTransfer
            // 
            this.timerTransfer.Enabled = true;
            this.timerTransfer.Interval = 1000;
            this.timerTransfer.Tick += new System.EventHandler(this.TimerTransfer_Tick);
            // 
            // BoxMenu
            // 
            this.BoxMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BoxMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.BoxMenu.ForeColor = System.Drawing.Color.White;
            this.BoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HerramientasMenuItem,
            this.DevicePingInfoMenuItem,
            this.EditarMenuItem,
            this.PuertosMenuItem,
            this.explorarPCMenuItem,
            this.hacerPingPorCMDMenuItem,
            this.PingConstante,
            this.OnlineAlertMenuItem,
            this.OfflineAlertMenuItem,
            this.cloneDevice,
            this.enviarMensajeMenuItem,
            this.CloseBoxMenuItem});
            this.BoxMenu.Name = "SKYNET_ContextMenuStrip1";
            this.BoxMenu.ShowImageMargin = false;
            this.BoxMenu.Size = new System.Drawing.Size(209, 268);
            // 
            // HerramientasMenuItem
            // 
            this.HerramientasMenuItem.Enabled = false;
            this.HerramientasMenuItem.Name = "HerramientasMenuItem";
            this.HerramientasMenuItem.Size = new System.Drawing.Size(208, 22);
            this.HerramientasMenuItem.Text = "Herramientas";
            // 
            // DevicePingInfoMenuItem
            // 
            this.DevicePingInfoMenuItem.Name = "DevicePingInfoMenuItem";
            this.DevicePingInfoMenuItem.Size = new System.Drawing.Size(208, 22);
            this.DevicePingInfoMenuItem.Text = "Información de ping";
            this.DevicePingInfoMenuItem.Click += new System.EventHandler(this.DevicePingInfoMenuItem_Click);
            // 
            // EditarMenuItem
            // 
            this.EditarMenuItem.Name = "EditarMenuItem";
            this.EditarMenuItem.Size = new System.Drawing.Size(208, 22);
            this.EditarMenuItem.Text = "Edit Device Info";
            this.EditarMenuItem.Click += new System.EventHandler(this.EditarMenuItem_Click);
            // 
            // PuertosMenuItem
            // 
            this.PuertosMenuItem.Name = "PuertosMenuItem";
            this.PuertosMenuItem.Size = new System.Drawing.Size(208, 22);
            this.PuertosMenuItem.Text = "Search opened ports";
            this.PuertosMenuItem.Click += new System.EventHandler(this.PuertosMenuItem_Click);
            // 
            // explorarPCMenuItem
            // 
            this.explorarPCMenuItem.Name = "explorarPCMenuItem";
            this.explorarPCMenuItem.Size = new System.Drawing.Size(208, 22);
            this.explorarPCMenuItem.Text = "Open PC in explorer";
            this.explorarPCMenuItem.Click += new System.EventHandler(this.explorarPCToolStripMenuItem_Click);
            // 
            // hacerPingPorCMDMenuItem
            // 
            this.hacerPingPorCMDMenuItem.Name = "hacerPingPorCMDMenuItem";
            this.hacerPingPorCMDMenuItem.Size = new System.Drawing.Size(208, 22);
            this.hacerPingPorCMDMenuItem.Text = "Hacer ping por CMD";
            this.hacerPingPorCMDMenuItem.Click += new System.EventHandler(this.hacerPingPorCMDToolStripMenuItem_Click);
            // 
            // PingConstante
            // 
            this.PingConstante.Name = "PingConstante";
            this.PingConstante.Size = new System.Drawing.Size(208, 22);
            this.PingConstante.Text = "Hacer ping constante por CMD";
            this.PingConstante.Click += new System.EventHandler(this.PingConstante_Click);
            // 
            // OnlineAlertMenuItem
            // 
            this.OnlineAlertMenuItem.Name = "OnlineAlertMenuItem";
            this.OnlineAlertMenuItem.Size = new System.Drawing.Size(208, 22);
            this.OnlineAlertMenuItem.Text = "Avisar cuando este Online";
            this.OnlineAlertMenuItem.Click += new System.EventHandler(this.OnlineAlertMenuItem_Click);
            // 
            // OfflineAlertMenuItem
            // 
            this.OfflineAlertMenuItem.Name = "OfflineAlertMenuItem";
            this.OfflineAlertMenuItem.Size = new System.Drawing.Size(208, 22);
            this.OfflineAlertMenuItem.Text = "Avisar cuando este Offline";
            this.OfflineAlertMenuItem.Click += new System.EventHandler(this.OfflineAlertMenuItem_Click);
            // 
            // cloneDevice
            // 
            this.cloneDevice.Name = "cloneDevice";
            this.cloneDevice.Size = new System.Drawing.Size(208, 22);
            this.cloneDevice.Text = "Clone Device";
            this.cloneDevice.Click += new System.EventHandler(this.cloneDevice_Click);
            // 
            // enviarMensajeMenuItem
            // 
            this.enviarMensajeMenuItem.Name = "enviarMensajeMenuItem";
            this.enviarMensajeMenuItem.Size = new System.Drawing.Size(208, 22);
            this.enviarMensajeMenuItem.Text = "Send message";
            this.enviarMensajeMenuItem.Click += new System.EventHandler(this.EnviarMensajeMenuItem_Click);
            // 
            // CloseBoxMenuItem
            // 
            this.CloseBoxMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBoxMenuItem.Name = "CloseBoxMenuItem";
            this.CloseBoxMenuItem.Size = new System.Drawing.Size(208, 22);
            this.CloseBoxMenuItem.Text = "Remove Device";
            this.CloseBoxMenuItem.Click += new System.EventHandler(this.RemoveDeviceMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.TryMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Net Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // TryMenu
            // 
            this.TryMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TryMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.TryMenu.ForeColor = System.Drawing.Color.White;
            this.TryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MostrarMenuItem,
            this.agregarEquipoMenuItem,
            this.buscarEquiposMenuItem,
            this.administrarPerfilesMenuItem,
            this.PingMenuItem,
            this.MinimizeMenuItem,
            this.CloseMenuItem});
            this.TryMenu.Name = "SKYNET_ContextMenuStrip1";
            this.TryMenu.ShowImageMargin = false;
            this.TryMenu.Size = new System.Drawing.Size(243, 158);
            // 
            // MostrarMenuItem
            // 
            this.MostrarMenuItem.Name = "MostrarMenuItem";
            this.MostrarMenuItem.Size = new System.Drawing.Size(242, 22);
            this.MostrarMenuItem.Text = "Mostrar";
            this.MostrarMenuItem.Click += new System.EventHandler(this.MostrarMenuItem_Click);
            // 
            // agregarEquipoMenuItem
            // 
            this.agregarEquipoMenuItem.Name = "agregarEquipoMenuItem";
            this.agregarEquipoMenuItem.Size = new System.Drawing.Size(242, 22);
            this.agregarEquipoMenuItem.Text = "Agregar equipo para monitorear";
            this.agregarEquipoMenuItem.Click += new System.EventHandler(this.AgregarEquipoMenuItem_Click);
            // 
            // buscarEquiposMenuItem
            // 
            this.buscarEquiposMenuItem.Name = "buscarEquiposMenuItem";
            this.buscarEquiposMenuItem.Size = new System.Drawing.Size(242, 22);
            this.buscarEquiposMenuItem.Text = "Buscar equipos en un segmento de IP";
            this.buscarEquiposMenuItem.Click += new System.EventHandler(this.BuscarEquiposMenuItem_Click);
            // 
            // administrarPerfilesMenuItem
            // 
            this.administrarPerfilesMenuItem.Name = "administrarPerfilesMenuItem";
            this.administrarPerfilesMenuItem.Size = new System.Drawing.Size(242, 22);
            this.administrarPerfilesMenuItem.Text = "Administrar perfiles";
            this.administrarPerfilesMenuItem.Click += new System.EventHandler(this.AdministrarPerfilesMenuItem_Click);
            // 
            // PingMenuItem
            // 
            this.PingMenuItem.Name = "PingMenuItem";
            this.PingMenuItem.Size = new System.Drawing.Size(242, 22);
            this.PingMenuItem.Text = "Configuración";
            this.PingMenuItem.Click += new System.EventHandler(this.Settings_Click);
            // 
            // MinimizeMenuItem
            // 
            this.MinimizeMenuItem.Name = "MinimizeMenuItem";
            this.MinimizeMenuItem.Size = new System.Drawing.Size(242, 22);
            this.MinimizeMenuItem.Text = "Minimizar";
            this.MinimizeMenuItem.Click += new System.EventHandler(this.MinimizeMenuItem_Click);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(242, 22);
            this.CloseMenuItem.Text = "Cerrar";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.MainMenu.ForeColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_AddDevice,
            this.menu_Profiles,
            this.menu_SearchDevice,
            this.menu_Settings,
            this.globalChatMenuItem});
            this.MainMenu.Name = "SKYNET_ContextMenuStrip1";
            this.MainMenu.ShowImageMargin = false;
            this.MainMenu.Size = new System.Drawing.Size(176, 114);
            this.MainMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.MainMenu_Closing);
            // 
            // menu_AddDevice
            // 
            this.menu_AddDevice.Name = "menu_AddDevice";
            this.menu_AddDevice.Size = new System.Drawing.Size(175, 22);
            this.menu_AddDevice.Text = "Añadir dispositivo";
            this.menu_AddDevice.Click += new System.EventHandler(this.menu_AddDevice_Click);
            // 
            // menu_Profiles
            // 
            this.menu_Profiles.Name = "menu_Profiles";
            this.menu_Profiles.Size = new System.Drawing.Size(175, 22);
            this.menu_Profiles.Text = "Perfiles";
            this.menu_Profiles.Click += new System.EventHandler(this.menu_Profiles_Click);
            // 
            // menu_SearchDevice
            // 
            this.menu_SearchDevice.Name = "menu_SearchDevice";
            this.menu_SearchDevice.Size = new System.Drawing.Size(175, 22);
            this.menu_SearchDevice.Text = "Buscar equipos en la red";
            this.menu_SearchDevice.Click += new System.EventHandler(this.menu_SearchDevice_Click);
            // 
            // menu_Settings
            // 
            this.menu_Settings.Name = "menu_Settings";
            this.menu_Settings.Size = new System.Drawing.Size(175, 22);
            this.menu_Settings.Text = "Configuración";
            this.menu_Settings.Click += new System.EventHandler(this.menu_Settings_Click);
            // 
            // globalChatMenuItem
            // 
            this.globalChatMenuItem.Name = "globalChatMenuItem";
            this.globalChatMenuItem.Size = new System.Drawing.Size(175, 22);
            this.globalChatMenuItem.Text = "Global Chat";
            this.globalChatMenuItem.Click += new System.EventHandler(this.GlobalChatMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(329, 689);
            this.Controls.Add(this.shadow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(329, 689);
            this.Name = "frmMain";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.PanelTransfer.ResumeLayout(false);
            this.PanelTransfer.PerformLayout();
            this.panelReceived.ResumeLayout(false);
            this.panelReceived.PerformLayout();
            this.panelSent.ResumeLayout(false);
            this.panelSent.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.DeviceContainer.ResumeLayout(false);
            this.WelcomeBox.ResumeLayout(false);
            this.WelcomeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.BoxMenu.ResumeLayout(false);
            this.TryMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer ClearLabel;
        public MetroPanel DeviceContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        public SKYNET_ContextMenuStrip BoxMenu;
        private System.Windows.Forms.ToolStripMenuItem explorarPCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hacerPingPorCMDMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HerramientasMenuItem;
        private SKYNET_ContextMenuStrip TryMenu;
        private System.Windows.Forms.ToolStripMenuItem MostrarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OnlineAlertMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseBoxMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PingConstante;
        private System.Windows.Forms.ToolStripMenuItem EditarMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem OfflineAlertMenuItem;
        private System.Windows.Forms.Panel WelcomeBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label ProfileSelected;
        private System.Windows.Forms.ToolStripMenuItem DevicePingInfoMenuItem;
        public System.Windows.Forms.Label byHackerprod;
        private System.Windows.Forms.ToolStripMenuItem PuertosMenuItem;
        private System.Windows.Forms.Panel PanelTransfer;
        private System.Windows.Forms.Panel panelReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelSent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ReceivedPerSecond;
        private System.Windows.Forms.Label SentPerSecond;
        private System.Windows.Forms.Label Received;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Sent;
        private System.Windows.Forms.Timer timerTransfer;
        private System.Windows.Forms.ToolStripMenuItem agregarEquipoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarEquiposMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPerfilesMenuItem;
        public System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.ToolStripMenuItem MinimizeMenuItem;
        public System.Windows.Forms.Panel PanelBottom;
        public SKYNET_ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_AddDevice;
        private System.Windows.Forms.ToolStripMenuItem menu_Profiles;
        private System.Windows.Forms.ToolStripMenuItem menu_SearchDevice;
        private System.Windows.Forms.ToolStripMenuItem menu_Settings;
        private SKYNET_ShadowBox shadow;
        private System.Windows.Forms.ToolStripMenuItem cloneDevice;
        public System.Windows.Forms.Label LB_Tittle;
        private System.Windows.Forms.ToolStripMenuItem enviarMensajeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalChatMenuItem;
        private SKYNET_Box SettingsBox;
        private SKYNET_Box MinimizeBox;
        private SKYNET_Box CloseBox;
    }
}