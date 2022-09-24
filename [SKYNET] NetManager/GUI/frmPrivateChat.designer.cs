using SKYNET.Controls;
using System.Windows.Forms;

namespace SKYNET
{
    partial class frmPrivateChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrivateChat));
            this.WebChat = new SKYNET.GUI.SKYNET_WebChat();
            this.TB_Message = new SKYNET.Controls.SKYNET_TextBox();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebChat
            // 
            this.WebChat.Location = new System.Drawing.Point(0, 34);
            this.WebChat.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.WebChat.Name = "WebChat";
            this.WebChat.Size = new System.Drawing.Size(543, 496);
            this.WebChat.TabIndex = 25;
            // 
            // TB_Message
            // 
            this.TB_Message.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.ForeColor = System.Drawing.Color.White;
            this.TB_Message.IsPassword = false;
            this.TB_Message.Location = new System.Drawing.Point(9, 547);
            this.TB_Message.Logo = global::SKYNET.Properties.Resources.send;
            this.TB_Message.LogoCursor = System.Windows.Forms.Cursors.Hand;
            this.TB_Message.Multiline = true;
            this.TB_Message.Name = "TB_Message";
            this.TB_Message.OnlyNumbers = false;
            this.TB_Message.ShowLogo = true;
            this.TB_Message.Size = new System.Drawing.Size(534, 35);
            this.TB_Message.TabIndex = 0;
            this.TB_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TB_Message.OnLogoClicked += new System.EventHandler(this.TB_Message_OnLogoClicked);
            this.TB_Message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Message_KeyUp);
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(550, 26);
            this.PN_Top.TabIndex = 24;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 10;
            this.CloseBox.Location = new System.Drawing.Point(516, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 30;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // frmPrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(550, 610);
            this.Controls.Add(this.PN_Top);
            this.Controls.Add(this.WebChat);
            this.Controls.Add(this.TB_Message);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmPrivateChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FrmPrivateChat_Shown);
            this.PN_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SKYNET_TextBox TB_Message;
        private GUI.SKYNET_WebChat WebChat;
        private Panel PN_Top;
        private SKYNET_Box CloseBox;
    }
}