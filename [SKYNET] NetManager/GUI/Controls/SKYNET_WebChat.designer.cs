namespace SKYNET.GUI
{
    partial class SKYNET_WebChat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webChat = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webChat
            // 
            this.webChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webChat.Location = new System.Drawing.Point(0, 0);
            this.webChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChat.Name = "webChat";
            this.webChat.ScrollBarsEnabled = false;
            this.webChat.Size = new System.Drawing.Size(376, 303);
            this.webChat.TabIndex = 0;
            this.webChat.WebBrowserShortcutsEnabled = false;
            // 
            // SKYNET_WebChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webChat);
            this.Name = "SKYNET_WebChat";
            this.Size = new System.Drawing.Size(376, 303);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webChat;
    }
}
