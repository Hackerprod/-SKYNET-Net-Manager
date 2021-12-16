
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsole));
            this.panelMin = new System.Windows.Forms.Panel();
            this.minBtn = new System.Windows.Forms.PictureBox();
            this.panelClose = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.status = new System.Windows.Forms.Label();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.PanelPing = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).BeginInit();
            this.panelClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.PanelPing.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMin
            // 
            this.panelMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panelMin.Controls.Add(this.minBtn);
            this.panelMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMin.Location = new System.Drawing.Point(449, 0);
            this.panelMin.Name = "panelMin";
            this.panelMin.Size = new System.Drawing.Size(38, 26);
            this.panelMin.TabIndex = 6;
            this.panelMin.Click += new System.EventHandler(this.minBtn_Click);
            this.panelMin.MouseLeave += new System.EventHandler(this.panelMin_MouseLeave);
            this.panelMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMin_MouseMove);
            // 
            // minBtn
            // 
            this.minBtn.Image = global::SKYNET.Properties.Resources.minimise;
            this.minBtn.Location = new System.Drawing.Point(14, 8);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(13, 12);
            this.minBtn.TabIndex = 4;
            this.minBtn.TabStop = false;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            this.minBtn.MouseLeave += new System.EventHandler(this.panelMin_MouseLeave);
            this.minBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMin_MouseMove);
            // 
            // panelClose
            // 
            this.panelClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panelClose.Controls.Add(this.closeBtn);
            this.panelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClose.Location = new System.Drawing.Point(487, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(39, 26);
            this.panelClose.TabIndex = 5;
            this.panelClose.Click += new System.EventHandler(this.closeBtn_Click);
            this.panelClose.MouseLeave += new System.EventHandler(this.panelClose_MouseLeave);
            this.panelClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelClose_MouseMove);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::SKYNET.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(13, 5);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBtn.TabIndex = 4;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseLeave += new System.EventHandler(this.panelClose_MouseLeave);
            this.closeBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelClose_MouseMove);
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
            // pnlButtom
            // 
            this.pnlButtom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.pnlButtom.Location = new System.Drawing.Point(0, 305);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(533, 22);
            this.pnlButtom.TabIndex = 234;
            // 
            // PanelPing
            // 
            this.PanelPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.PanelPing.Controls.Add(this.textBox);
            this.PanelPing.Controls.Add(this.txtConsole);
            this.PanelPing.Location = new System.Drawing.Point(3, 31);
            this.PanelPing.Name = "PanelPing";
            this.PanelPing.Size = new System.Drawing.Size(521, 273);
            this.PanelPing.TabIndex = 245;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(535, 193);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(14, 23);
            this.textBox.TabIndex = 1;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtConsole.Location = new System.Drawing.Point(6, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(509, 273);
            this.txtConsole.TabIndex = 25;
            this.txtConsole.Text = "";
            this.txtConsole.TextChanged += new System.EventHandler(this.txtConsole_TextChanged);
            this.txtConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsole_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 247;
            this.label1.Text = "Consola";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panelMin);
            this.panel1.Controls.Add(this.panelClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 26);
            this.panel1.TabIndex = 26;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(526, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelPing);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyNet Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.panelMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).EndInit();
            this.panelClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.PanelPing.ResumeLayout(false);
            this.PanelPing.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMin;
        private System.Windows.Forms.PictureBox minBtn;
        private System.Windows.Forms.Panel panelClose;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Panel pnlButtom;
        private System.Windows.Forms.Panel PanelPing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panel1;
    }
}