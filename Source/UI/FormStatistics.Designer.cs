namespace UI
{
    partial class FormStatistics
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
      this.btnImport = new System.Windows.Forms.Button();
      this.btnSearch = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.button2 = new System.Windows.Forms.Button();
      this.grdMain = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
      this.SuspendLayout();
      // 
      // btnClose
      // 
      this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.btnClose.Location = new System.Drawing.Point(881, 70);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(91, 30);
      this.btnClose.TabIndex = 41;
      this.btnClose.Text = "关闭";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnImport
      // 
      this.btnImport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.btnImport.Location = new System.Drawing.Point(757, 70);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(91, 30);
      this.btnImport.TabIndex = 42;
      this.btnImport.Text = "导入";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
      // 
      // btnSearch
      // 
      this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.btnSearch.Location = new System.Drawing.Point(660, 70);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(91, 30);
      this.btnSearch.TabIndex = 43;
      this.btnSearch.Text = "查询";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(24, 106);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 22);
      this.label1.TabIndex = 45;
      this.label1.Text = "统计项目";
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button1.Location = new System.Drawing.Point(339, 102);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(91, 30);
      this.button1.TabIndex = 46;
      this.button1.Text = "统计";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(104, 108);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(220, 20);
      this.comboBox1.TabIndex = 47;
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(12, 134);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 23;
      this.dataGridView1.Size = new System.Drawing.Size(960, 150);
      this.dataGridView1.TabIndex = 48;
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button2.Location = new System.Drawing.Point(453, 102);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(91, 30);
      this.button2.TabIndex = 49;
      this.button2.Text = "个人统计";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // grdMain
      // 
      this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdMain.Location = new System.Drawing.Point(12, 290);
      this.grdMain.Name = "grdMain";
      this.grdMain.RowTemplate.Height = 23;
      this.grdMain.Size = new System.Drawing.Size(296, 396);
      this.grdMain.TabIndex = 50;
      this.grdMain.DoubleClick += new System.EventHandler(this.grdMain_DoubleClick);
      // 
      // FormStatistics
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(984, 712);
      this.Controls.Add(this.grdMain);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnSearch);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.btnClose);
      this.Name = "FormStatistics";
      this.Text = "FormStatistics";
      this.Load += new System.EventHandler(this.FormStatistics_Load);
      this.Controls.SetChildIndex(this.btnClose, 0);
      this.Controls.SetChildIndex(this.btnImport, 0);
      this.Controls.SetChildIndex(this.btnSearch, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.comboBox1, 0);
      this.Controls.SetChildIndex(this.dataGridView1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      this.Controls.SetChildIndex(this.grdMain, 0);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView grdMain;
    }
}