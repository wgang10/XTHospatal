namespace UI
{
    partial class FromMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnDepartmentManage = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnInfoEdite = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnLogManage = new System.Windows.Forms.Button();
            this.alphaBlendingBringer1 = new UI.AlphaBlendingBringer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDepartmentManage
            // 
            this.btnDepartmentManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDepartmentManage.Image = global::UI.Properties.Resources._4;
            this.btnDepartmentManage.Location = new System.Drawing.Point(28, 85);
            this.btnDepartmentManage.Name = "btnDepartmentManage";
            this.btnDepartmentManage.Size = new System.Drawing.Size(128, 107);
            this.btnDepartmentManage.TabIndex = 39;
            this.btnDepartmentManage.Text = "部门管理";
            this.btnDepartmentManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartmentManage.UseVisualStyleBackColor = true;
            this.btnDepartmentManage.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEmployee.Image = global::UI.Properties.Resources._12;
            this.btnEmployee.Location = new System.Drawing.Point(180, 85);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(128, 107);
            this.btnEmployee.TabIndex = 40;
            this.btnEmployee.Text = "教职工管理";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnProject
            // 
            this.btnProject.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProject.Image = global::UI.Properties.Resources._19;
            this.btnProject.Location = new System.Drawing.Point(495, 218);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(128, 107);
            this.btnProject.TabIndex = 41;
            this.btnProject.Text = "项目检查状况";
            this.btnProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnInfoEdite
            // 
            this.btnInfoEdite.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInfoEdite.Image = global::UI.Properties.Resources._10;
            this.btnInfoEdite.Location = new System.Drawing.Point(28, 218);
            this.btnInfoEdite.Name = "btnInfoEdite";
            this.btnInfoEdite.Size = new System.Drawing.Size(128, 107);
            this.btnInfoEdite.TabIndex = 42;
            this.btnInfoEdite.Text = "体检信息维护";
            this.btnInfoEdite.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInfoEdite.UseVisualStyleBackColor = true;
            this.btnInfoEdite.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Image = global::UI.Properties.Resources._2;
            this.btnSearch.Location = new System.Drawing.Point(180, 218);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 107);
            this.btnSearch.TabIndex = 43;
            this.btnSearch.Text = "体检信息查询";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.Image = global::UI.Properties.Resources._3;
            this.btnConfig.Location = new System.Drawing.Point(652, 85);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(128, 107);
            this.btnConfig.TabIndex = 44;
            this.btnConfig.Text = "参数设置";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Image = global::UI.Properties.Resources._9;
            this.btnPrint.Location = new System.Drawing.Point(337, 218);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(128, 107);
            this.btnPrint.TabIndex = 45;
            this.btnPrint.Text = "报告打印";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserManage.Image = global::UI.Properties.Resources._11;
            this.btnUserManage.Location = new System.Drawing.Point(337, 85);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(128, 107);
            this.btnUserManage.TabIndex = 46;
            this.btnUserManage.Text = "用户管理";
            this.btnUserManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserManage.UseVisualStyleBackColor = true;
            this.btnUserManage.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStatistics.Image = global::UI.Properties.Resources._8;
            this.btnStatistics.Location = new System.Drawing.Point(652, 218);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(128, 107);
            this.btnStatistics.TabIndex = 47;
            this.btnStatistics.Text = "信息统计";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystem.Image = global::UI.Properties.Resources._5;
            this.btnSystem.Location = new System.Drawing.Point(804, 85);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(128, 107);
            this.btnSystem.TabIndex = 48;
            this.btnSystem.Text = "系统设置";
            this.btnSystem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSystem.UseVisualStyleBackColor = true;
            this.btnSystem.Click += new System.EventHandler(this.btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Chart1);
            this.groupBox1.Location = new System.Drawing.Point(28, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 331);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历次体检人数统计";
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.IsStaggered = true;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.Chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(6, 20);
            this.Chart1.Name = "Chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.CustomProperties = "LabelStyle=Bottom";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Default";
            series1.Name = "Default";
            this.Chart1.Series.Add(series1);
            this.Chart1.Size = new System.Drawing.Size(892, 305);
            this.Chart1.TabIndex = 1;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "历次体检人数统计";
            this.Chart1.Titles.Add(title1);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelp.Image = global::UI.Properties.Resources._17;
            this.btnHelp.Location = new System.Drawing.Point(495, 85);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(128, 107);
            this.btnHelp.TabIndex = 50;
            this.btnHelp.Text = "帮助";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnLogManage
            // 
            this.btnLogManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogManage.Image = global::UI.Properties.Resources._1;
            this.btnLogManage.Location = new System.Drawing.Point(804, 218);
            this.btnLogManage.Name = "btnLogManage";
            this.btnLogManage.Size = new System.Drawing.Size(128, 107);
            this.btnLogManage.TabIndex = 51;
            this.btnLogManage.Text = "日志查看";
            this.btnLogManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogManage.UseVisualStyleBackColor = true;
            this.btnLogManage.Click += new System.EventHandler(this.btn_Click);
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 722);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnInfoEdite);
            this.Controls.Add(this.btnLogManage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSystem);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnUserManage);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnDepartmentManage);
            this.Name = "FromMain";
            this.Load += new System.EventHandler(this.FromMain_Load);
            this.VisibleChanged += new System.EventHandler(this.FromMain_VisibleChanged);
            this.Controls.SetChildIndex(this.btnDepartmentManage, 0);
            this.Controls.SetChildIndex(this.btnEmployee, 0);
            this.Controls.SetChildIndex(this.btnProject, 0);
            this.Controls.SetChildIndex(this.btnConfig, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnUserManage, 0);
            this.Controls.SetChildIndex(this.btnStatistics, 0);
            this.Controls.SetChildIndex(this.btnSystem, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnLogManage, 0);
            this.Controls.SetChildIndex(this.btnInfoEdite, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDepartmentManage;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnInfoEdite;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnLogManage;
        private AlphaBlendingBringer alphaBlendingBringer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;

    }
}