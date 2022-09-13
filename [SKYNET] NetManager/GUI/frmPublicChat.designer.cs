using SKYNET.Controls;
using System.Windows.Forms;

namespace SKYNET
{
    partial class frmPublicChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublicChat));
            this._accept = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LV_Chat = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TB_Message = new SKYNET.Controls.SKYNET_TextBox();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_Box();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // _accept
            // 
            this._accept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._accept.Location = new System.Drawing.Point(485, 375);
            this._accept.Name = "_accept";
            this._accept.Size = new System.Drawing.Size(75, 23);
            this._accept.TabIndex = 16;
            this._accept.Text = "button1";
            this._accept.UseVisualStyleBackColor = true;
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.LV_Chat);
            this.panel1.Controls.Add(this.TB_Message);
            this.panel1.Controls.Add(this.PN_Top);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 361);
            this.panel1.TabIndex = 25;
            // 
            // LV_Chat
            // 
            this.LV_Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.LV_Chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_Chat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnMessage});
            this.LV_Chat.ForeColor = System.Drawing.Color.White;
            this.LV_Chat.FullRowSelect = true;
            this.LV_Chat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Chat.HideSelection = false;
            this.LV_Chat.Location = new System.Drawing.Point(10, 32);
            this.LV_Chat.Name = "LV_Chat";
            this.LV_Chat.Size = new System.Drawing.Size(532, 272);
            this.LV_Chat.TabIndex = 25;
            this.LV_Chat.UseCompatibleStateImageBehavior = false;
            this.LV_Chat.View = System.Windows.Forms.View.Details;
            this.LV_Chat.SelectedIndexChanged += new System.EventHandler(this.LV_Chat_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 111;
            // 
            // columnMessage
            // 
            this.columnMessage.Text = "Message";
            this.columnMessage.Width = 400;
            // 
            // TB_Message
            // 
            this.TB_Message.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.TB_Message.ForeColor = System.Drawing.Color.White;
            this.TB_Message.IsPassword = false;
            this.TB_Message.Location = new System.Drawing.Point(10, 314);
            this.TB_Message.Logo = null;
            this.TB_Message.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_Message.Multiline = true;
            this.TB_Message.Name = "TB_Message";
            this.TB_Message.OnlyNumbers = false;
            this.TB_Message.ShowLogo = false;
            this.TB_Message.Size = new System.Drawing.Size(532, 35);
            this.TB_Message.TabIndex = 0;
            this.TB_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TB_Message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Message_KeyUp);
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.CloseBox);
            this.PN_Top.Controls.Add(this.label2);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(554, 26);
            this.PN_Top.TabIndex = 24;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.CloseBox.Image = global::SKYNET.Properties.Resources.close;
            this.CloseBox.Location = new System.Drawing.Point(520, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MenuMode = false;
            this.CloseBox.MenuSeparation = 8;
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 30;
            this.CloseBox.BoxClicked += new System.EventHandler(this.CloseBox_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Message to ";
            // 
            // frmPublicChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(554, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this._accept);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmPublicChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FrmPrivateChat_Shown);
            this.panel1.ResumeLayout(false);
            this.PN_Top.ResumeLayout(false);
            this.PN_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button _accept;
        private Button ok;
        private Panel panel1;
        private Panel PN_Top;
        private Label label2;
        private SKYNET_TextBox TB_Message;
        private SKYNET_Box CloseBox;
        private ListView LV_Chat;
        private ColumnHeader columnName;
        private ColumnHeader columnMessage;
    }
}