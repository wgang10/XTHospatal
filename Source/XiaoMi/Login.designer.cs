namespace wintrue_xiaomi
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblQQ = new System.Windows.Forms.Label();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPwd = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.WTBODY.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WTBODY
            // 
            this.WTBODY.BorderColor = System.Drawing.Color.White;
            this.WTBODY.Controls.Add(this.listBox1);
            this.WTBODY.Controls.Add(this.lblQQ);
            this.WTBODY.Controls.Add(this.txtQQ);
            this.WTBODY.Controls.Add(this.txtPwd);
            this.WTBODY.Controls.Add(this.lblPwd);
            this.WTBODY.Controls.Add(this.btnLogin);
            this.WTBODY.Location = new System.Drawing.Point(3, 41);
            this.WTBODY.Size = new System.Drawing.Size(694, 176);
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.Location = new System.Drawing.Point(26, 6);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(41, 12);
            this.lblQQ.TabIndex = 12;
            this.lblQQ.Text = "帐号：";
            // 
            // txtQQ
            // 
            this.txtQQ.BackColor = System.Drawing.SystemColors.Info;
            this.txtQQ.Location = new System.Drawing.Point(73, 3);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(134, 21);
            this.txtQQ.TabIndex = 0;
            this.txtQQ.Text = "328945440@qq.com";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.Info;
            this.txtPwd.Location = new System.Drawing.Point(73, 18);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(134, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(9, 63);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(202, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(26, 18);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(41, 12);
            this.lblPwd.TabIndex = 11;
            this.lblPwd.Text = "密码：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(235, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(450, 160);
            this.listBox1.TabIndex = 13;
            // 
            // Login
            // 
            this.Animate = wintrue.WT_UI.AnimateWindow.由中间四周展开;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 241);
            this.Controls.Add(this.WTBODY);
            this.HeadWidth = 40;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Ischange = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 860);
            this.Name = "Login";
            this.Text = "小米登录";
            this.ToolMenu = this.contextMenuStrip1;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.WTBODY, 0);
            this.WTBODY.ResumeLayout(false);
            this.WTBODY.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
    }
}