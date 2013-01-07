namespace XTHospitalUI
{
    partial class FormBase
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(994, 64);
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.ForeColor = System.Drawing.Color.Blue;
            this.label140.Location = new System.Drawing.Point(324, 701);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(419, 12);
            this.label140.TabIndex = 38;
            this.label140.Text = "技术支持：尚美思 网址:www.shangmeisi.com Email:wangang-10@hotmail.com";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.ForeColor = System.Drawing.Color.Blue;
            this.label139.Location = new System.Drawing.Point(12, 701);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(161, 12);
            this.label139.TabIndex = 37;
            this.label139.Text = "版权所有：西安运动创伤医院";
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 722);
            this.Controls.Add(this.label140);
            this.Controls.Add(this.label139);
            this.Controls.Add(this.pictureBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 750);
            this.MinimumSize = new System.Drawing.Size(798, 600);
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "西安体育学院教职工健康状况信息管理系统";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label139;
    }
}