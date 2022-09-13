


using SKYNET.Controls;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmCropEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCropEditor));
            this.PN_Top = new System.Windows.Forms.Panel();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.l_Preview = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.Rotate_L = new SKYNET.SKYNET_Button();
            this.Redondear = new SKYNET.Controls.SKYNET_Check();
            this._circled = new System.Windows.Forms.Label();
            this.ShowLine = new SKYNET.Controls.SKYNET_Check();
            this._showlines = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p_Preview = new System.Windows.Forms.PictureBox();
            this.btn_Apply = new SKYNET.SKYNET_Button();
            this.ImageCrop = new SKYNET.ImageCropControl();
            this.label6 = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.PN_Top.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_Preview)).BeginInit();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(46)))), ((int)(((byte)(60)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(725, 26);
            this.PN_Top.TabIndex = 5;
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(819, 372);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 16;
            this.acceptBtn.Text = "button1";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(-21, -2);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(16, 20);
            this.Browser.TabIndex = 18;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panelBody.Controls.Add(this.panel3);
            this.panelBody.Controls.Add(this.panel2);
            this.panelBody.Controls.Add(this.panel16);
            this.panelBody.Controls.Add(this.Rotate_L);
            this.panelBody.Controls.Add(this.Redondear);
            this.panelBody.Controls.Add(this._circled);
            this.panelBody.Controls.Add(this.ShowLine);
            this.panelBody.Controls.Add(this._showlines);
            this.panelBody.Controls.Add(this.panel1);
            this.panelBody.Controls.Add(this.btn_Apply);
            this.panelBody.Controls.Add(this.ImageCrop);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.panelBody.Location = new System.Drawing.Point(0, 26);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(8);
            this.panelBody.Size = new System.Drawing.Size(725, 361);
            this.panelBody.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.panel3.Controls.Add(this.l_Preview);
            this.panel3.Location = new System.Drawing.Point(560, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 25);
            this.panel3.TabIndex = 100;
            // 
            // l_Preview
            // 
            this.l_Preview.AutoSize = true;
            this.l_Preview.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.l_Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.l_Preview.Location = new System.Drawing.Point(35, 5);
            this.l_Preview.Name = "l_Preview";
            this.l_Preview.Size = new System.Drawing.Size(76, 15);
            this.l_Preview.TabIndex = 96;
            this.l_Preview.Text = "Vista previa";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel2.Location = new System.Drawing.Point(543, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 338);
            this.panel2.TabIndex = 99;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel16.Location = new System.Drawing.Point(562, 224);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(145, 1);
            this.panel16.TabIndex = 98;
            // 
            // Rotate_L
            // 
            this.Rotate_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.Rotate_L.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.Rotate_L.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rotate_L.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Rotate_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.Rotate_L.ForeColorMouseOver = System.Drawing.Color.White;
            this.Rotate_L.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.Rotate_L.ImageIcon = null;
            this.Rotate_L.Location = new System.Drawing.Point(560, 294);
            this.Rotate_L.MenuMode = false;
            this.Rotate_L.Name = "Rotate_L";
            this.Rotate_L.Rounded = true;
            this.Rotate_L.Size = new System.Drawing.Size(145, 25);
            this.Rotate_L.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.Rotate_L.TabIndex = 97;
            this.Rotate_L.Text = "Rotar Imagen";
            this.Rotate_L.Click += new System.EventHandler(this.Rotate_L_Click);
            // 
            // Redondear
            // 
            this.Redondear.BackColor = System.Drawing.Color.Transparent;
            this.Redondear.Checked = false;
            this.Redondear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Redondear.Location = new System.Drawing.Point(671, 230);
            this.Redondear.Name = "Redondear";
            this.Redondear.Size = new System.Drawing.Size(34, 25);
            this.Redondear.TabIndex = 96;
            this.Redondear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Redondear_MouseClick);
            // 
            // _circled
            // 
            this._circled.AutoSize = true;
            this._circled.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this._circled.ForeColor = System.Drawing.Color.White;
            this._circled.Location = new System.Drawing.Point(559, 235);
            this._circled.Name = "_circled";
            this._circled.Size = new System.Drawing.Size(71, 15);
            this._circled.TabIndex = 95;
            this._circled.Text = "Redondear";
            // 
            // ShowLine
            // 
            this.ShowLine.BackColor = System.Drawing.Color.Transparent;
            this.ShowLine.Checked = false;
            this.ShowLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowLine.Location = new System.Drawing.Point(671, 193);
            this.ShowLine.Name = "ShowLine";
            this.ShowLine.Size = new System.Drawing.Size(34, 25);
            this.ShowLine.TabIndex = 92;
            this.ShowLine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowLine_MouseClick);
            // 
            // _showlines
            // 
            this._showlines.AutoSize = true;
            this._showlines.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this._showlines.ForeColor = System.Drawing.Color.White;
            this._showlines.Location = new System.Drawing.Point(559, 198);
            this._showlines.Name = "_showlines";
            this._showlines.Size = new System.Drawing.Size(91, 15);
            this._showlines.TabIndex = 91;
            this._showlines.Text = "Mostrar lineas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.p_Preview);
            this.panel1.Location = new System.Drawing.Point(560, 42);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(145, 145);
            this.panel1.TabIndex = 38;
            // 
            // p_Preview
            // 
            this.p_Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.p_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Preview.Location = new System.Drawing.Point(2, 2);
            this.p_Preview.Name = "p_Preview";
            this.p_Preview.Size = new System.Drawing.Size(141, 141);
            this.p_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_Preview.TabIndex = 1;
            this.p_Preview.TabStop = false;
            // 
            // btn_Apply
            // 
            this.btn_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.btn_Apply.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Apply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Apply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.btn_Apply.ForeColorMouseOver = System.Drawing.Color.White;
            this.btn_Apply.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.btn_Apply.ImageIcon = null;
            this.btn_Apply.Location = new System.Drawing.Point(560, 325);
            this.btn_Apply.MenuMode = false;
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Rounded = true;
            this.btn_Apply.Size = new System.Drawing.Size(145, 25);
            this.btn_Apply.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.btn_Apply.TabIndex = 37;
            this.btn_Apply.Text = "Guardar cambios";
            this.btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // ImageCrop
            // 
            this.ImageCrop.AccessibleName = "Image crop pane";
            this.ImageCrop.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.ImageCrop.AspectRatio = 1D;
            this.ImageCrop.Bitmap = null;
            this.ImageCrop.GridLines = false;
            this.ImageCrop.Location = new System.Drawing.Point(11, 12);
            this.ImageCrop.Name = "ImageCrop";
            this.ImageCrop.Size = new System.Drawing.Size(526, 339);
            this.ImageCrop.TabIndex = 0;
            this.ImageCrop.CropRectangleChanged += new System.EventHandler(this.ImageCrop_CropRectangleChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Game Coordinator Client";
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.panelLogo.Controls.Add(this.label6);
            this.panelLogo.Controls.Add(this.Logo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.ForeColor = System.Drawing.Color.White;
            this.panelLogo.Location = new System.Drawing.Point(0, 26);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(725, 0);
            this.panelLogo.TabIndex = 33;
            // 
            // Logo
            // 
            this.Logo.Location = new System.Drawing.Point(136, 7);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(105, 105);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 1;
            this.Logo.TabStop = false;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(46)))), ((int)(((byte)(60)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(46)))), ((int)(((byte)(60)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(691, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 0;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // frmCropEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(725, 406);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelLogo);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.PN_Top);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(17)))), ((int)(((byte)(22)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmCropEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[SKYNET] Dota2 GCS";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.PN_Top.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p_Preview)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelLogo;
        private ImageCropControl ImageCrop;
        private SKYNET_Button btn_Apply;
        private SKYNET_Check ShowLine;
        private System.Windows.Forms.Label _showlines;
        private SKYNET_Check Redondear;
        private System.Windows.Forms.Label _circled;
        private SKYNET_Button Rotate_L;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label l_Preview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox p_Preview;
        private SKYNET_Box CloseBox;
    }
}