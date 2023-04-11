using SKYNET.Controls;

namespace SKYNET
{
    partial class frmConnectionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectionInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LV_ARP = new SKYNET.Controls.SKYNET_ListView();
            this.CProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.R_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_Proccess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PN_Top = new System.Windows.Forms.Panel();
            this.BT_Close = new SKYNET.Controls.SKYNET_Box();
            this.ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PN_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.PN_Top);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 555);
            this.panel1.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel3.Controls.Add(this.LV_ARP);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(12, 44);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel3.Size = new System.Drawing.Size(552, 499);
            this.panel3.TabIndex = 27;
            // 
            // LV_ARP
            // 
            this.LV_ARP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.LV_ARP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_ARP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CProtocol,
            this.L_Address,
            this.R_Address,
            this.Status,
            this.C_Proccess});
            this.LV_ARP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_ARP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LV_ARP.ForeColor = System.Drawing.Color.White;
            this.LV_ARP.FullRowSelect = true;
            this.LV_ARP.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_ARP.Location = new System.Drawing.Point(5, 26);
            this.LV_ARP.Name = "LV_ARP";
            this.LV_ARP.OwnerDraw = true;
            this.LV_ARP.Selectable = true;
            this.LV_ARP.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.LV_ARP.SelectedIndex = 0;
            this.LV_ARP.Size = new System.Drawing.Size(542, 473);
            this.LV_ARP.TabIndex = 27;
            this.LV_ARP.UseCompatibleStateImageBehavior = false;
            this.LV_ARP.View = System.Windows.Forms.View.Details;
            // 
            // CProtocol
            // 
            this.CProtocol.Text = "Protocol";
            // 
            // L_Address
            // 
            this.L_Address.Text = "L_Address";
            this.L_Address.Width = 120;
            // 
            // R_Address
            // 
            this.R_Address.Text = "R_Address";
            this.R_Address.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 80;
            // 
            // C_Proccess
            // 
            this.C_Proccess.Text = "C_Proccess";
            this.C_Proccess.Width = 130;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 26);
            this.panel2.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.label6.Location = new System.Drawing.Point(378, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Proccess";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.label4.Location = new System.Drawing.Point(302, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Protocol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.label2.Location = new System.Drawing.Point(181, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remote EndPoint";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.label1.Location = new System.Drawing.Point(62, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local EndPoint";
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.BT_Close);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.ForeColor = System.Drawing.Color.White;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(576, 26);
            this.PN_Top.TabIndex = 24;
            // 
            // BT_Close
            // 
            this.BT_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_Close.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_Close.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.BT_Close.Image = global::SKYNET.Properties.Resources.close;
            this.BT_Close.ImageSize = 10;
            this.BT_Close.Location = new System.Drawing.Point(542, 0);
            this.BT_Close.MenuMode = false;
            this.BT_Close.MenuSeparation = 8;
            this.BT_Close.Name = "BT_Close";
            this.BT_Close.Size = new System.Drawing.Size(34, 26);
            this.BT_Close.TabIndex = 0;
            this.BT_Close.BoxClicked += new System.EventHandler(this.BT_Close_BoxClicked);
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
            // frmConnectionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(576, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1360, 728);
            this.Name = "frmConnectionInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PN_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PN_Top;
        private SKYNET_Box BT_Close;
        private System.Windows.Forms.Panel panel3;
        private SKYNET_ListView LV_ARP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader L_Address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader R_Address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader CProtocol;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader C_Proccess;
    }
}