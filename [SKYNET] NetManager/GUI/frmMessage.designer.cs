using SKYNET.Controls;

namespace SKYNET
{
    partial class frmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessage));
            this.ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Accept = new SKYNET_Button();
            this.btn_Cancel = new SKYNET_Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this._Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(483, 145);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(18, 23);
            this.ok.TabIndex = 24;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 195);
            this.panel1.TabIndex = 25;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Event_MouseUp);
            // 
            // btn_Accept
            // 
            this.btn_Accept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.btn_Accept.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.btn_Accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Accept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Accept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Accept.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.btn_Accept.ImageAlignment = SKYNET_Button._ImgAlign.Left;
            this.btn_Accept.ImageIcon = null;
            this.btn_Accept.Location = new System.Drawing.Point(273, 152);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Rounded = false;
            this.btn_Accept.Size = new System.Drawing.Size(93, 29);
            this.btn_Accept.Style = SKYNET_Button._Style.TextOnly;
            this.btn_Accept.TabIndex = 27;
            this.btn_Accept.Text = "Aceptar";
            this.btn_Accept.Click += new System.EventHandler(this.acepctBtn_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.btn_Cancel.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Cancel.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.btn_Cancel.ImageAlignment = SKYNET_Button._ImgAlign.Left;
            this.btn_Cancel.ImageIcon = null;
            this.btn_Cancel.Location = new System.Drawing.Point(372, 152);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Rounded = false;
            this.btn_Cancel.Size = new System.Drawing.Size(93, 29);
            this.btn_Cancel.Style = SKYNET_Button._Style.TextOnly;
            this.btn_Cancel.TabIndex = 26;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel15.Controls.Add(this.txtMessage);
            this.panel15.Controls.Add(this._Cancel);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.panel15.Location = new System.Drawing.Point(0, 26);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(10);
            this.panel15.Size = new System.Drawing.Size(477, 120);
            this.panel15.TabIndex = 25;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMessage.Location = new System.Drawing.Point(10, 10);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(457, 100);
            this.txtMessage.TabIndex = 26;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // Cancel
            // 
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.Location = new System.Drawing.Point(484, 90);
            this._Cancel.Name = "Cancel";
            this._Cancel.Size = new System.Drawing.Size(16, 23);
            this._Cancel.TabIndex = 25;
            this._Cancel.Text = "cancel";
            this._Cancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.Header);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 26);
            this.panel2.TabIndex = 24;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Event_MouseUp);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Header.Location = new System.Drawing.Point(9, 4);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(52, 16);
            this.Header.TabIndex = 0;
            this.Header.Text = "Mensaje";
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(477, 195);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Panel panel1;
        private SKYNET_Button btn_Accept;
        private SKYNET_Button btn_Cancel;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.TextBox txtMessage;
    }
}