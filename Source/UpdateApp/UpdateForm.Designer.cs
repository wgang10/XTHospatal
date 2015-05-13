namespace UpdateApp
{
    partial class UpdateForm
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
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.lbMessageSize = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.progressBarSize = new System.Windows.Forms.ProgressBar();
            this.lbMessageFile = new System.Windows.Forms.Label();
            this.btnUnZip = new System.Windows.Forms.Button();
            this.btnMD5 = new System.Windows.Forms.Button();
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtEncryptOriginal = new System.Windows.Forms.TextBox();
            this.txtEncryptNew = new System.Windows.Forms.TextBox();
            this.btntxtEncrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarFile
            // 
            this.progressBarFile.Location = new System.Drawing.Point(12, 12);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(541, 13);
            this.progressBarFile.TabIndex = 0;
            // 
            // lbMessageSize
            // 
            this.lbMessageSize.Location = new System.Drawing.Point(12, 83);
            this.lbMessageSize.Name = "lbMessageSize";
            this.lbMessageSize.Size = new System.Drawing.Size(541, 23);
            this.lbMessageSize.TabIndex = 1;
            this.lbMessageSize.Text = "正在升级";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(478, 272);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBarSize
            // 
            this.progressBarSize.Location = new System.Drawing.Point(12, 67);
            this.progressBarSize.Name = "progressBarSize";
            this.progressBarSize.Size = new System.Drawing.Size(541, 13);
            this.progressBarSize.TabIndex = 4;
            // 
            // lbMessageFile
            // 
            this.lbMessageFile.Location = new System.Drawing.Point(12, 28);
            this.lbMessageFile.Name = "lbMessageFile";
            this.lbMessageFile.Size = new System.Drawing.Size(541, 23);
            this.lbMessageFile.TabIndex = 5;
            this.lbMessageFile.Text = "正在升级";
            // 
            // btnUnZip
            // 
            this.btnUnZip.Location = new System.Drawing.Point(478, 243);
            this.btnUnZip.Name = "btnUnZip";
            this.btnUnZip.Size = new System.Drawing.Size(75, 23);
            this.btnUnZip.TabIndex = 6;
            this.btnUnZip.Text = "UnZip";
            this.btnUnZip.UseVisualStyleBackColor = true;
            this.btnUnZip.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // btnMD5
            // 
            this.btnMD5.Location = new System.Drawing.Point(478, 214);
            this.btnMD5.Name = "btnMD5";
            this.btnMD5.Size = new System.Drawing.Size(75, 23);
            this.btnMD5.TabIndex = 7;
            this.btnMD5.Text = "md5";
            this.btnMD5.UseVisualStyleBackColor = true;
            this.btnMD5.Click += new System.EventHandler(this.btnMD5_Click);
            // 
            // txtMD5
            // 
            this.txtMD5.Location = new System.Drawing.Point(12, 188);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.Size = new System.Drawing.Size(541, 21);
            this.txtMD5.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(14, 215);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(458, 196);
            this.listBox1.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(478, 301);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Json";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtEncryptOriginal
            // 
            this.txtEncryptOriginal.Location = new System.Drawing.Point(14, 124);
            this.txtEncryptOriginal.Name = "txtEncryptOriginal";
            this.txtEncryptOriginal.Size = new System.Drawing.Size(448, 21);
            this.txtEncryptOriginal.TabIndex = 12;
            // 
            // txtEncryptNew
            // 
            this.txtEncryptNew.Location = new System.Drawing.Point(12, 151);
            this.txtEncryptNew.Name = "txtEncryptNew";
            this.txtEncryptNew.Size = new System.Drawing.Size(541, 21);
            this.txtEncryptNew.TabIndex = 13;
            // 
            // btntxtEncrypt
            // 
            this.btntxtEncrypt.Location = new System.Drawing.Point(478, 124);
            this.btntxtEncrypt.Name = "btntxtEncrypt";
            this.btntxtEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btntxtEncrypt.TabIndex = 14;
            this.btntxtEncrypt.Text = "加密";
            this.btntxtEncrypt.UseVisualStyleBackColor = true;
            this.btntxtEncrypt.Click += new System.EventHandler(this.btntxtEncrypt_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 427);
            this.Controls.Add(this.btntxtEncrypt);
            this.Controls.Add(this.txtEncryptNew);
            this.Controls.Add(this.txtEncryptOriginal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtMD5);
            this.Controls.Add(this.btnMD5);
            this.Controls.Add(this.btnUnZip);
            this.Controls.Add(this.lbMessageFile);
            this.Controls.Add(this.progressBarSize);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbMessageSize);
            this.Controls.Add(this.progressBarFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级程序";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarFile;
        private System.Windows.Forms.Label lbMessageSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar progressBarSize;
        private System.Windows.Forms.Label lbMessageFile;
        private System.Windows.Forms.Button btnUnZip;
        private System.Windows.Forms.Button btnMD5;
        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtEncryptOriginal;
        private System.Windows.Forms.TextBox txtEncryptNew;
        private System.Windows.Forms.Button btntxtEncrypt;
    }
}