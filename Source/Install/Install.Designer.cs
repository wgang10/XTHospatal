namespace Install
{
  partial class Install
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
            this.progressBarSize = new System.Windows.Forms.ProgressBar();
            this.lbMessageSize = new System.Windows.Forms.Label();
            this.lbMessageFile = new System.Windows.Forms.Label();
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBarSize
            // 
            this.progressBarSize.Location = new System.Drawing.Point(3, 78);
            this.progressBarSize.Name = "progressBarSize";
            this.progressBarSize.Size = new System.Drawing.Size(555, 12);
            this.progressBarSize.TabIndex = 0;
            // 
            // lbMessageSize
            // 
            this.lbMessageSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessageSize.Location = new System.Drawing.Point(11, 104);
            this.lbMessageSize.Name = "lbMessageSize";
            this.lbMessageSize.Size = new System.Drawing.Size(536, 23);
            this.lbMessageSize.TabIndex = 1;
            this.lbMessageSize.Text = "正在下载...";
            // 
            // lbMessageFile
            // 
            this.lbMessageFile.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessageFile.Location = new System.Drawing.Point(11, 38);
            this.lbMessageFile.Name = "lbMessageFile";
            this.lbMessageFile.Size = new System.Drawing.Size(536, 23);
            this.lbMessageFile.TabIndex = 3;
            this.lbMessageFile.Text = "正在下载...";
            // 
            // progressBarFile
            // 
            this.progressBarFile.Location = new System.Drawing.Point(2, 12);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(555, 12);
            this.progressBarFile.TabIndex = 2;
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 147);
            this.Controls.Add(this.lbMessageFile);
            this.Controls.Add(this.progressBarFile);
            this.Controls.Add(this.lbMessageSize);
            this.Controls.Add(this.progressBarSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Install";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体检系统安装程序";
            this.Shown += new System.EventHandler(this.Install_Shown);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBarSize;
    private System.Windows.Forms.Label lbMessageSize;
    private System.Windows.Forms.Label lbMessageFile;
    private System.Windows.Forms.ProgressBar progressBarFile;
  }
}

