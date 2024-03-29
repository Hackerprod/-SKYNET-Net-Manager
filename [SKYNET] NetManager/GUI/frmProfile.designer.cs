﻿using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeleteProfile = new SKYNET.SKYNET_Button();
            this.AddProfile = new SKYNET.SKYNET_Button();
            this.SetProfile = new SKYNET.SKYNET_Button();
            this.profileBox = new SKYNET.GUI.SKYNET_ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.PN_Top.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(287, 26);
            this.PN_Top.TabIndex = 5;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.ImageSize = 12;
            this.CloseBox.Location = new System.Drawing.Point(253, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 31;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_BoxClicked);
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(485, 375);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 16;
            this.acceptBtn.Text = "button1";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel3.Controls.Add(this.DeleteProfile);
            this.panel3.Controls.Add(this.AddProfile);
            this.panel3.Controls.Add(this.SetProfile);
            this.panel3.Controls.Add(this.profileBox);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 103);
            this.panel3.TabIndex = 8;
            // 
            // DeleteProfile
            // 
            this.DeleteProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.DeleteProfile.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.DeleteProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DeleteProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.DeleteProfile.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.DeleteProfile.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.DeleteProfile.ImageIcon = null;
            this.DeleteProfile.Location = new System.Drawing.Point(192, 75);
            this.DeleteProfile.MenuMode = false;
            this.DeleteProfile.Name = "DeleteProfile";
            this.DeleteProfile.Rounded = false;
            this.DeleteProfile.Size = new System.Drawing.Size(84, 24);
            this.DeleteProfile.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.DeleteProfile.TabIndex = 24;
            this.DeleteProfile.Text = "Delete";
            this.DeleteProfile.Click += new System.EventHandler(this.DeleteProfile_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.AddProfile.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.AddProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.AddProfile.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.AddProfile.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.AddProfile.ImageIcon = null;
            this.AddProfile.Location = new System.Drawing.Point(102, 75);
            this.AddProfile.MenuMode = false;
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Rounded = false;
            this.AddProfile.Size = new System.Drawing.Size(84, 24);
            this.AddProfile.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.AddProfile.TabIndex = 23;
            this.AddProfile.Text = "Create";
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // SetProfile
            // 
            this.SetProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.SetProfile.BackColorMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.SetProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SetProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.SetProfile.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.SetProfile.ImageAlignment = SKYNET.SKYNET_Button._ImgAlign.Left;
            this.SetProfile.ImageIcon = null;
            this.SetProfile.Location = new System.Drawing.Point(12, 75);
            this.SetProfile.MenuMode = false;
            this.SetProfile.Name = "SetProfile";
            this.SetProfile.Rounded = false;
            this.SetProfile.Size = new System.Drawing.Size(84, 24);
            this.SetProfile.Style = SKYNET.SKYNET_Button._Style.TextOnly;
            this.SetProfile.TabIndex = 22;
            this.SetProfile.Text = "Load";
            this.SetProfile.Click += new System.EventHandler(this.SetProfile_Click);
            // 
            // profileBox
            // 
            this.profileBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.profileBox.BackColorMouseOver = System.Drawing.Color.Empty;
            this.profileBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.profileBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.profileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.profileBox.ForeColor = System.Drawing.Color.White;
            this.profileBox.FormattingEnabled = true;
            this.profileBox.ItemHeight = 18;
            this.profileBox.Location = new System.Drawing.Point(12, 35);
            this.profileBox.Name = "profileBox";
            this.profileBox.Size = new System.Drawing.Size(263, 24);
            this.profileBox.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label10.Location = new System.Drawing.Point(9, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Current profile name";
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(0, 325);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(31, 41);
            this.Browser.TabIndex = 19;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(287, 140);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PN_Top);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Net Manager";
            this.PN_Top.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PN_Top;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private SKYNET_Button SetProfile;
        private SKYNET_ComboBox profileBox;
        private SKYNET_Button DeleteProfile;
        private SKYNET_Button AddProfile;
        private SKYNET_Box CloseBox;
    }
}