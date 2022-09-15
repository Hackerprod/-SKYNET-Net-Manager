namespace SKYNET
{
    partial class Form1
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
            this.skyneT_WebChat1 = new SKYNET.GUI.SKYNET_WebChat();
            this.skyneT_TextBox1 = new SKYNET.Controls.SKYNET_TextBox();
            this.SuspendLayout();
            // 
            // skyneT_WebChat1
            // 
            this.skyneT_WebChat1.Location = new System.Drawing.Point(12, 12);
            this.skyneT_WebChat1.Name = "skyneT_WebChat1";
            this.skyneT_WebChat1.Size = new System.Drawing.Size(656, 439);
            this.skyneT_WebChat1.TabIndex = 0;
            // 
            // skyneT_TextBox1
            // 
            this.skyneT_TextBox1.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.skyneT_TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.skyneT_TextBox1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.skyneT_TextBox1.ForeColor = System.Drawing.Color.Black;
            this.skyneT_TextBox1.IsPassword = false;
            this.skyneT_TextBox1.Location = new System.Drawing.Point(12, 453);
            this.skyneT_TextBox1.Logo = null;
            this.skyneT_TextBox1.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.skyneT_TextBox1.Multiline = false;
            this.skyneT_TextBox1.Name = "skyneT_TextBox1";
            this.skyneT_TextBox1.OnlyNumbers = false;
            this.skyneT_TextBox1.ShowLogo = false;
            this.skyneT_TextBox1.Size = new System.Drawing.Size(656, 35);
            this.skyneT_TextBox1.TabIndex = 1;
            this.skyneT_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skyneT_TextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SkyneT_TextBox1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(682, 498);
            this.Controls.Add(this.skyneT_TextBox1);
            this.Controls.Add(this.skyneT_WebChat1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.SKYNET_WebChat skyneT_WebChat1;
        private Controls.SKYNET_TextBox skyneT_TextBox1;
    }
}