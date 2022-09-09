namespace SKYNET.GUI
{
    partial class DeviceHistory
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
            this.BarContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BarContainer
            // 
            this.BarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.BarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarContainer.Location = new System.Drawing.Point(2, 2);
            this.BarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.BarContainer.Name = "BarContainer";
            this.BarContainer.Size = new System.Drawing.Size(136, 126);
            this.BarContainer.TabIndex = 0;
            // 
            // DeviceHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(94)))), ((int)(((byte)(108)))));
            this.Controls.Add(this.BarContainer);
            this.Name = "DeviceHistory";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(140, 130);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarContainer;
    }
}
