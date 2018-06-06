namespace IntranetTransferer
{
    partial class Transferer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transferer));
            this.FileDrapPlace = new System.Windows.Forms.Label();
            this.YourAddressLB = new System.Windows.Forms.Label();
            this.LocalIPAddress = new System.Windows.Forms.Label();
            this.TargetIPAddressLB = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Label();
            this.SendTxtBtn = new System.Windows.Forms.Label();
            this.Notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.ExitMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshBtn = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Label();
            this.CopyBtn = new System.Windows.Forms.Label();
            ServerIPAddress = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            TextToSend = new System.Windows.Forms.TextBox();
            this.ExitMenu.SuspendLayout();
            this.HideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDrapPlace
            // 
            this.FileDrapPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileDrapPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileDrapPlace.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FileDrapPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.FileDrapPlace.ForeColor = System.Drawing.Color.DimGray;
            this.FileDrapPlace.Location = new System.Drawing.Point(15, 161);
            this.FileDrapPlace.Name = "FileDrapPlace";
            this.FileDrapPlace.Size = new System.Drawing.Size(368, 90);
            this.FileDrapPlace.TabIndex = 0;
            this.FileDrapPlace.Text = "Drag and drop file here";
            this.FileDrapPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YourAddressLB
            // 
            this.YourAddressLB.AutoSize = true;
            this.YourAddressLB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.YourAddressLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YourAddressLB.ForeColor = System.Drawing.Color.White;
            this.YourAddressLB.Location = new System.Drawing.Point(12, 19);
            this.YourAddressLB.Name = "YourAddressLB";
            this.YourAddressLB.Size = new System.Drawing.Size(134, 16);
            this.YourAddressLB.TabIndex = 1;
            this.YourAddressLB.Text = "Local IP Address :";
            // 
            // LocalIPAddress
            // 
            this.LocalIPAddress.AutoSize = true;
            this.LocalIPAddress.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LocalIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.LocalIPAddress.ForeColor = System.Drawing.Color.White;
            this.LocalIPAddress.Location = new System.Drawing.Point(158, 19);
            this.LocalIPAddress.Name = "LocalIPAddress";
            this.LocalIPAddress.Size = new System.Drawing.Size(68, 16);
            this.LocalIPAddress.TabIndex = 2;
            this.LocalIPAddress.Text = "127.0.0.1";
            // 
            // TargetIPAddressLB
            // 
            this.TargetIPAddressLB.AutoSize = true;
            this.TargetIPAddressLB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TargetIPAddressLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetIPAddressLB.ForeColor = System.Drawing.Color.White;
            this.TargetIPAddressLB.Location = new System.Drawing.Point(12, 43);
            this.TargetIPAddressLB.Name = "TargetIPAddressLB";
            this.TargetIPAddressLB.Size = new System.Drawing.Size(142, 16);
            this.TargetIPAddressLB.TabIndex = 1;
            this.TargetIPAddressLB.Text = "Target IP Address :";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConnectBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.ConnectBtn.ForeColor = System.Drawing.Color.White;
            this.ConnectBtn.Location = new System.Drawing.Point(286, 40);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(97, 26);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // SendTxtBtn
            // 
            this.SendTxtBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendTxtBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SendTxtBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendTxtBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.SendTxtBtn.ForeColor = System.Drawing.Color.White;
            this.SendTxtBtn.Location = new System.Drawing.Point(286, 74);
            this.SendTxtBtn.Name = "SendTxtBtn";
            this.SendTxtBtn.Size = new System.Drawing.Size(97, 24);
            this.SendTxtBtn.TabIndex = 4;
            this.SendTxtBtn.Text = "Send";
            this.SendTxtBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SendTxtBtn.Click += new System.EventHandler(this.SendTxtBtn_Click);
            // 
            // Notifier
            // 
            this.Notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("Notifier.Icon")));
            this.Notifier.Text = "IntranetTransferer";
            this.Notifier.Visible = true;
            // 
            // ExitMenu
            // 
            this.ExitMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.ExitMenu.Name = "ContextMenu";
            this.ExitMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // HideMenu
            // 
            this.HideMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem});
            this.HideMenu.Name = "HideContext";
            this.HideMenu.Size = new System.Drawing.Size(100, 26);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RefreshBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RefreshBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.RefreshBtn.ForeColor = System.Drawing.Color.White;
            this.RefreshBtn.Location = new System.Drawing.Point(286, 15);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(97, 24);
            this.RefreshBtn.TabIndex = 5;
            this.RefreshBtn.Text = "Next";
            this.RefreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(286, 129);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(97, 24);
            this.ClearBtn.TabIndex = 6;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CopyBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CopyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.CopyBtn.ForeColor = System.Drawing.Color.White;
            this.CopyBtn.Location = new System.Drawing.Point(286, 102);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(97, 24);
            this.CopyBtn.TabIndex = 6;
            this.CopyBtn.Text = "Copy";
            this.CopyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // ServerIPAddress
            // 
            ServerIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            ServerIPAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ServerIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ServerIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            ServerIPAddress.ForeColor = System.Drawing.Color.White;
            ServerIPAddress.Location = new System.Drawing.Point(165, 44);
            ServerIPAddress.Margin = new System.Windows.Forms.Padding(0);
            ServerIPAddress.MaxLength = 15;
            ServerIPAddress.Name = "ServerIPAddress";
            ServerIPAddress.Size = new System.Drawing.Size(110, 16);
            ServerIPAddress.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(160, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(120, 26);
            label2.TabIndex = 2;
            label2.Text = " ";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(15, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(265, 80);
            label3.TabIndex = 2;
            label3.Text = " ";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextToSend
            // 
            TextToSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            TextToSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            TextToSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextToSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            TextToSend.ForeColor = System.Drawing.Color.White;
            TextToSend.Location = new System.Drawing.Point(18, 77);
            TextToSend.Margin = new System.Windows.Forms.Padding(0);
            TextToSend.MaxLength = 30000;
            TextToSend.Multiline = true;
            TextToSend.Name = "TextToSend";
            TextToSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            TextToSend.Size = new System.Drawing.Size(259, 73);
            TextToSend.TabIndex = 3;
            // 
            // Transferer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(395, 270);
            this.Controls.Add(this.CopyBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.SendTxtBtn);
            this.Controls.Add(TextToSend);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(ServerIPAddress);
            this.Controls.Add(this.LocalIPAddress);
            this.Controls.Add(this.TargetIPAddressLB);
            this.Controls.Add(this.YourAddressLB);
            this.Controls.Add(label3);
            this.Controls.Add(this.FileDrapPlace);
            this.Controls.Add(label2);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Transferer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.ExitMenu.ResumeLayout(false);
            this.HideMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileDrapPlace;
        private System.Windows.Forms.Label YourAddressLB;
        private System.Windows.Forms.Label LocalIPAddress;
        private System.Windows.Forms.Label TargetIPAddressLB;
        private System.Windows.Forms.Label ConnectBtn;
        private System.Windows.Forms.Label SendTxtBtn;
        private System.Windows.Forms.NotifyIcon Notifier;
        private System.Windows.Forms.ContextMenuStrip ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip HideMenu;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.Label RefreshBtn;
        private System.Windows.Forms.Label ClearBtn;
        private System.Windows.Forms.Label CopyBtn;
        private System.Windows.Forms.TextBox ServerIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextToSend;
    }
}

