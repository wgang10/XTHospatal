namespace WinFormAppTest
{
    partial class FormLiLv
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBenjin = new System.Windows.Forms.TextBox();
            this.txtLiLv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHuibao = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTouRu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLiXi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtTimesOfYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBenjin
            // 
            this.txtBenjin.Location = new System.Drawing.Point(71, 13);
            this.txtBenjin.Name = "txtBenjin";
            this.txtBenjin.Size = new System.Drawing.Size(100, 21);
            this.txtBenjin.TabIndex = 1;
            this.txtBenjin.Text = "1000";
            // 
            // txtLiLv
            // 
            this.txtLiLv.Location = new System.Drawing.Point(71, 40);
            this.txtLiLv.Name = "txtLiLv";
            this.txtLiLv.Size = new System.Drawing.Size(100, 21);
            this.txtLiLv.TabIndex = 2;
            this.txtLiLv.Text = "0.18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "本金";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "年利率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "时间";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(71, 67);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 21);
            this.txtTime.TabIndex = 6;
            this.txtTime.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "回报";
            // 
            // txtHuibao
            // 
            this.txtHuibao.Location = new System.Drawing.Point(697, 14);
            this.txtHuibao.Name = "txtHuibao";
            this.txtHuibao.Size = new System.Drawing.Size(154, 21);
            this.txtHuibao.TabIndex = 8;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(290, 16);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(100, 21);
            this.txtAdd.TabIndex = 9;
            this.txtAdd.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "每年追加本金";
            // 
            // txtTouRu
            // 
            this.txtTouRu.Location = new System.Drawing.Point(697, 43);
            this.txtTouRu.Name = "txtTouRu";
            this.txtTouRu.Size = new System.Drawing.Size(154, 21);
            this.txtTouRu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "投入";
            // 
            // txtLiXi
            // 
            this.txtLiXi.Location = new System.Drawing.Point(697, 71);
            this.txtLiXi.Name = "txtLiXi";
            this.txtLiXi.Size = new System.Drawing.Size(154, 21);
            this.txtLiXi.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "利息";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 111);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(839, 312);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "chart1";
            // 
            // txtTimesOfYear
            // 
            this.txtTimesOfYear.Location = new System.Drawing.Point(290, 40);
            this.txtTimesOfYear.Name = "txtTimesOfYear";
            this.txtTimesOfYear.Size = new System.Drawing.Size(100, 21);
            this.txtTimesOfYear.TabIndex = 2;
            this.txtTimesOfYear.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "年复利次数";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 438);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(839, 239);
            this.dataGridView1.TabIndex = 14;
            // 
            // FormLiLv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 689);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLiXi);
            this.Controls.Add(this.txtTouRu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.txtHuibao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimesOfYear);
            this.Controls.Add(this.txtLiLv);
            this.Controls.Add(this.txtBenjin);
            this.Controls.Add(this.button1);
            this.Name = "FormLiLv";
            this.Text = "FormLiLv";
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBenjin;
        private System.Windows.Forms.TextBox txtLiLv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHuibao;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTouRu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLiXi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox txtTimesOfYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}