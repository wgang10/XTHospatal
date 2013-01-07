namespace UI
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.btnClose = new System.Windows.Forms.Button();
            this.alphaBlendingBringer1 = new UI.AlphaBlendingBringer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbWoman = new System.Windows.Forms.RadioButton();
            this.rdbMan = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBM = new System.Windows.Forms.ComboBox();
            this.label134 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.btnAddNewYearMonth = new System.Windows.Forms.Button();
            this.cmbYearMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(810, 120);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNo);
            this.groupBox1.Controls.Add(this.rdbWoman);
            this.groupBox1.Controls.Add(this.rdbMan);
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBM);
            this.groupBox1.Controls.Add(this.label134);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 76);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索条件";
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNo.Location = new System.Drawing.Point(198, 46);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(76, 25);
            this.rdbNo.TabIndex = 49;
            this.rdbNo.Text = "未指定";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbWoman
            // 
            this.rdbWoman.AutoSize = true;
            this.rdbWoman.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbWoman.Location = new System.Drawing.Point(157, 46);
            this.rdbWoman.Name = "rdbWoman";
            this.rdbWoman.Size = new System.Drawing.Size(44, 25);
            this.rdbWoman.TabIndex = 48;
            this.rdbWoman.Text = "女";
            this.rdbWoman.UseVisualStyleBackColor = true;
            // 
            // rdbMan
            // 
            this.rdbMan.AutoSize = true;
            this.rdbMan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbMan.Location = new System.Drawing.Point(116, 46);
            this.rdbMan.Name = "rdbMan";
            this.rdbMan.Size = new System.Drawing.Size(44, 25);
            this.rdbMan.TabIndex = 47;
            this.rdbMan.Text = "男";
            this.rdbMan.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbAll.Location = new System.Drawing.Point(65, 46);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(60, 25);
            this.rdbAll.TabIndex = 46;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "全部";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 45;
            this.label3.Text = "性别";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(486, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 30);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(65, 14);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(128, 29);
            this.txtName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "姓名";
            // 
            // cmbBM
            // 
            this.cmbBM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBM.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBM.FormattingEnabled = true;
            this.cmbBM.Items.AddRange(new object[] {
            "",
            "党委与院长办公室",
            "机关一总支",
            "机关二总支",
            "机关三总支",
            "科研所",
            "研究生部",
            "体育系",
            "运动系",
            "武术系",
            "社体系",
            "人文系",
            "人体系",
            "艺术系",
            "竞技体育学校",
            "高职学院",
            "组织部",
            "宣传部",
            "纪监审办公室",
            "团委",
            "工会",
            "学生处",
            "教务处",
            "科研处",
            "现代教育技术与网络信息中心",
            "人事处",
            "财务处",
            "保卫处",
            "竞训处",
            "离退休管理办公室",
            "沣峪口校区管委会",
            "国际交流中心及台港澳办公室",
            "后勤产业集团总公司",
            "后勤管理处",
            "全国田径理论研究会",
            "时尚球类",
            "场馆器材处",
            "图书馆",
            "学报与期刊编辑部",
            "毕业生就业指导中心",
            "运动创伤医院",
            "其他"});
            this.cmbBM.Location = new System.Drawing.Point(259, 14);
            this.cmbBM.MaxDropDownItems = 20;
            this.cmbBM.Name = "cmbBM";
            this.cmbBM.Size = new System.Drawing.Size(211, 29);
            this.cmbBM.TabIndex = 38;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label134.Location = new System.Drawing.Point(211, 17);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(42, 21);
            this.label134.TabIndex = 39;
            this.label134.Text = "部门";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Controls.Add(this.grdMain);
            this.groupBox2.Location = new System.Drawing.Point(14, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(968, 538);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "职工一览  提示：双击可修改信息";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(312, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(650, 516);
            this.webBrowser1.TabIndex = 40;
            // 
            // grdMain
            // 
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Location = new System.Drawing.Point(6, 16);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowTemplate.Height = 23;
            this.grdMain.Size = new System.Drawing.Size(296, 516);
            this.grdMain.TabIndex = 1;
            this.grdMain.Click += new System.EventHandler(this.grdMain_Click);
            this.grdMain.DoubleClick += new System.EventHandler(this.grdMain_DoubleClick);
            // 
            // btnAddNewYearMonth
            // 
            this.btnAddNewYearMonth.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNewYearMonth.Location = new System.Drawing.Point(810, 84);
            this.btnAddNewYearMonth.Name = "btnAddNewYearMonth";
            this.btnAddNewYearMonth.Size = new System.Drawing.Size(91, 30);
            this.btnAddNewYearMonth.TabIndex = 59;
            this.btnAddNewYearMonth.Text = "添加";
            this.btnAddNewYearMonth.UseVisualStyleBackColor = true;
            this.btnAddNewYearMonth.Click += new System.EventHandler(this.btnAddNewYearMonth_Click);
            // 
            // cmbYearMonth
            // 
            this.cmbYearMonth.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYearMonth.FormattingEnabled = true;
            this.cmbYearMonth.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cmbYearMonth.Location = new System.Drawing.Point(689, 85);
            this.cmbYearMonth.MaxLength = 6;
            this.cmbYearMonth.Name = "cmbYearMonth";
            this.cmbYearMonth.Size = new System.Drawing.Size(115, 29);
            this.cmbYearMonth.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(612, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 57;
            this.label1.Text = "体检时间";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 718);
            this.Controls.Add(this.btnAddNewYearMonth);
            this.Controls.Add(this.cmbYearMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
            this.Load += new System.EventHandler(this.Search_Load);
            this.VisibleChanged += new System.EventHandler(this.Search_VisibleChanged);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbYearMonth, 0);
            this.Controls.SetChildIndex(this.btnAddNewYearMonth, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private AlphaBlendingBringer alphaBlendingBringer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBM;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbWoman;
        private System.Windows.Forms.RadioButton rdbMan;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnAddNewYearMonth;
        private System.Windows.Forms.ComboBox cmbYearMonth;
        private System.Windows.Forms.Label label1;
    }
}