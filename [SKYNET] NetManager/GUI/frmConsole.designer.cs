
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
            this.status = new System.Windows.Forms.Label();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.PanelPing = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.MinimizeBox = new SKYNET.Controls.SKYNET_Box();
            this.PanelPing.SuspendLayout();
            this.PN_Top.SuspendLayout();
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
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 247;
            this.label1.Text = "Console";
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.MinimizeBox);
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Controls.Add(this.label1);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(526, 26);
            this.PN_Top.TabIndex = 26;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(492, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 248;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.MinimizeBox.Image = global::SKYNET.Properties.Resources.minimise;
            this.MinimizeBox.Location = new System.Drawing.Point(458, 0);
            this.MinimizeBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.MenuMode = false;
            this.MinimizeBox.MenuSeparation = 8;
            this.MinimizeBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(34, 26);
            this.MinimizeBox.TabIndex = 249;
            this.MinimizeBox.BoxClicked += new System.EventHandler(this.MinimizeBox_BoxClicked);
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(526, 325);
            this.Controls.Add(this.PN_Top);
            this.Controls.Add(this.PanelPing);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.PanelPing.ResumeLayout(false);
            this.PanelPing.PerformLayout();
            this.PN_Top.ResumeLayout(false);
            this.PN_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Panel pnlButtom;
        private System.Windows.Forms.Panel PanelPing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel PN_Top;
        private Controls.SKYNET_Box MinimizeBox;
        private Controls.SKYNET_Box CloseBox;
    }
}