namespace UI
{
    partial class FromNews
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(399, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // txtBody
            // 
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(12, 38);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(462, 201);
            this.txtBody.TabIndex = 1;
            this.txtBody.Text = "";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTitle.Location = new System.Drawing.Point(13, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(62, 16);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(14, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "提示：双击可关闭本窗口";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(351, 17);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(119, 12);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "2014/12/12 23:36:55";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FromNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(486, 280);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FromNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FromNews";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnColse_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
    }
}