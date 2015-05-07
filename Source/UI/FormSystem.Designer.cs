namespace UI
{
    partial class FormSystem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNewsSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.lbCreatetime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNews = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLiXi = new System.Windows.Forms.TextBox();
            this.txtTouRu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtHuibao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimesOfYear = new System.Windows.Forms.TextBox();
            this.txtLiLv = new System.Windows.Forms.TextBox();
            this.txtBenjin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.txtManagementPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(872, 645);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 30);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 552);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNewsSearch);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.lbCreatetime);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lbID);
            this.tabPage1.Controls.Add(this.txtSystemName);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnAddNews);
            this.tabPage1.Controls.Add(this.txtBody);
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(952, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "公告新闻";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNewsSearch
            // 
            this.btnNewsSearch.Location = new System.Drawing.Point(381, 197);
            this.btnNewsSearch.Name = "btnNewsSearch";
            this.btnNewsSearch.Size = new System.Drawing.Size(75, 23);
            this.btnNewsSearch.TabIndex = 30;
            this.btnNewsSearch.Text = "查询";
            this.btnNewsSearch.UseVisualStyleBackColor = true;
            this.btnNewsSearch.Click += new System.EventHandler(this.btnNewsSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(940, 294);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(300, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "清空编号";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbCreatetime
            // 
            this.lbCreatetime.AutoSize = true;
            this.lbCreatetime.Location = new System.Drawing.Point(197, 17);
            this.lbCreatetime.Name = "lbCreatetime";
            this.lbCreatetime.Size = new System.Drawing.Size(0, 12);
            this.lbCreatetime.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Aquamarine;
            this.label6.Location = new System.Drawing.Point(20, 98);
            this.label6.MaximumSize = new System.Drawing.Size(50, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "内容";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Aquamarine;
            this.label5.Location = new System.Drawing.Point(20, 71);
            this.label5.MaximumSize = new System.Drawing.Size(50, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Aquamarine;
            this.label4.Location = new System.Drawing.Point(20, 50);
            this.label4.MaximumSize = new System.Drawing.Size(50, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "标题";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.BackColor = System.Drawing.Color.Aquamarine;
            this.lbID.Location = new System.Drawing.Point(20, 23);
            this.lbID.MaximumSize = new System.Drawing.Size(50, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(29, 12);
            this.lbID.TabIndex = 26;
            this.lbID.Text = "编号";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(315, 14);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(148, 21);
            this.txtSystemName.TabIndex = 22;
            this.txtSystemName.Text = "XTHospital";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(219, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "物理删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(138, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "逻辑删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNews
            // 
            this.btnAddNews.Location = new System.Drawing.Point(57, 197);
            this.btnAddNews.Name = "btnAddNews";
            this.btnAddNews.Size = new System.Drawing.Size(75, 23);
            this.btnAddNews.TabIndex = 21;
            this.btnAddNews.Text = "保存";
            this.btnAddNews.UseVisualStyleBackColor = true;
            this.btnAddNews.Click += new System.EventHandler(this.btnAddNews_Click);
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(55, 95);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(400, 96);
            this.txtBody.TabIndex = 18;
            this.txtBody.Text = "";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(55, 71);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(400, 21);
            this.txtUrl.TabIndex = 17;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(55, 47);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(400, 21);
            this.txtTitle.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtLiXi);
            this.tabPage2.Controls.Add(this.txtTouRu);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtAdd);
            this.tabPage2.Controls.Add(this.txtHuibao);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtTime);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtTimesOfYear);
            this.tabPage2.Controls.Add(this.txtLiLv);
            this.tabPage2.Controls.Add(this.txtBenjin);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(952, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 309);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(944, 214);
            this.dataGridView2.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(740, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "利息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(740, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "投入";
            // 
            // txtLiXi
            // 
            this.txtLiXi.Location = new System.Drawing.Point(775, 60);
            this.txtLiXi.Name = "txtLiXi";
            this.txtLiXi.Size = new System.Drawing.Size(154, 21);
            this.txtLiXi.TabIndex = 29;
            // 
            // txtTouRu
            // 
            this.txtTouRu.Location = new System.Drawing.Point(775, 32);
            this.txtTouRu.Name = "txtTouRu";
            this.txtTouRu.Size = new System.Drawing.Size(154, 21);
            this.txtTouRu.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "每年追加本金";
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(368, 5);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(100, 21);
            this.txtAdd.TabIndex = 26;
            this.txtAdd.Text = "0";
            // 
            // txtHuibao
            // 
            this.txtHuibao.Location = new System.Drawing.Point(775, 3);
            this.txtHuibao.Name = "txtHuibao";
            this.txtHuibao.Size = new System.Drawing.Size(154, 21);
            this.txtHuibao.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(740, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "回报";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(149, 56);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 21);
            this.txtTime.TabIndex = 23;
            this.txtTime.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "年复利次数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "年利率";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "本金";
            // 
            // txtTimesOfYear
            // 
            this.txtTimesOfYear.Location = new System.Drawing.Point(368, 29);
            this.txtTimesOfYear.Name = "txtTimesOfYear";
            this.txtTimesOfYear.Size = new System.Drawing.Size(100, 21);
            this.txtTimesOfYear.TabIndex = 18;
            this.txtTimesOfYear.Text = "1";
            // 
            // txtLiLv
            // 
            this.txtLiLv.Location = new System.Drawing.Point(149, 29);
            this.txtLiLv.Name = "txtLiLv";
            this.txtLiLv.Size = new System.Drawing.Size(100, 21);
            this.txtLiLv.TabIndex = 17;
            this.txtLiLv.Text = "0.18";
            // 
            // txtBenjin
            // 
            this.txtBenjin.Location = new System.Drawing.Point(149, 2);
            this.txtBenjin.Name = "txtBenjin";
            this.txtBenjin.Size = new System.Drawing.Size(100, 21);
            this.txtBenjin.TabIndex = 16;
            this.txtBenjin.Text = "1000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManage
            // 
            this.btnManage.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManage.Location = new System.Drawing.Point(727, 645);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(91, 30);
            this.btnManage.TabIndex = 42;
            this.btnManage.Text = "确定";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // txtManagementPassword
            // 
            this.txtManagementPassword.Location = new System.Drawing.Point(463, 653);
            this.txtManagementPassword.Name = "txtManagementPassword";
            this.txtManagementPassword.PasswordChar = '*';
            this.txtManagementPassword.Size = new System.Drawing.Size(258, 21);
            this.txtManagementPassword.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 656);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "只有输入管理密码才可进行管理操作";
            // 
            // FormSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 712);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtManagementPassword);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnClose);
            this.Name = "FormSystem";
            this.Text = "FormSystem";
            this.Load += new System.EventHandler(this.FormSystem_Load);
            this.Shown += new System.EventHandler(this.FormSystem_Shown);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnManage, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.txtManagementPassword, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbCreatetime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNews;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.TextBox txtManagementPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLiXi;
        private System.Windows.Forms.TextBox txtTouRu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtHuibao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimesOfYear;
        private System.Windows.Forms.TextBox txtLiLv;
        private System.Windows.Forms.TextBox txtBenjin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNewsSearch;
    }
}