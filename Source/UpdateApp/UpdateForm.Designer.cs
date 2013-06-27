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
            this.button1.Location = new System.Drawing.Point(478, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(380, 135);
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
            this.btnUnZip.Location = new System.Drawing.Point(287, 135);
            this.btnUnZip.Name = "btnUnZip";
            this.btnUnZip.Size = new System.Drawing.Size(75, 23);
            this.btnUnZip.TabIndex = 6;
            this.btnUnZip.Text = "UnZip";
            this.btnUnZip.UseVisualStyleBackColor = true;
            this.btnUnZip.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // btnMD5
            // 
            this.btnMD5.Location = new System.Drawing.Point(196, 135);
            this.btnMD5.Name = "btnMD5";
            this.btnMD5.Size = new System.Drawing.Size(75, 23);
            this.btnMD5.TabIndex = 7;
            this.btnMD5.Text = "md5";
            this.btnMD5.UseVisualStyleBackColor = true;
            this.btnMD5.Click += new System.EventHandler(this.btnMD5_Click);
            // 
            // txtMD5
            // 
            this.txtMD5.Location = new System.Drawing.Point(12, 109);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.Size = new System.Drawing.Size(541, 21);
            this.txtMD5.TabIndex = 8;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 170);
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
    }
}