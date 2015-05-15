using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class FormSystem : FormBase
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public FormSystem()
        {
            InitializeComponent();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage2.Controls.Add(this.chart2);
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 75);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(850, 250);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "chart1";
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
        }

        private void FormSystem_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.FormShow.Show();
            this.Close();
        }

        private void btnAddNews_Click(object sender, EventArgs e)
        {
            webService.Notic model = new webService.Notic();
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }

            if (string.IsNullOrEmpty(lbID.Text))
            {
                model.Id = -1;
            }
            else
            {
                model.Id = Int32.Parse(lbID.Text);
            }
            model.SystemName = txtSystemName.Text;
            model.Title = txtTitle.Text;
            model.Url = txtUrl.Text;
            model.Body = txtBody.Text;
            bool isSuccese = GlobalVal.WebSerices.AddUpdateNews(model);
            if (isSuccese)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("保存失败。");
            }
        }

        private void LoadNews(int Nums)
        {
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }
            webService.Notic[] news = GlobalVal.WebSerices.GetNews("ALL", Nums);
            lbID.Text = string.Empty;
            this.dataGridView1.DataSource = news;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }
            bool isSuccess = GlobalVal.WebSerices.DeleteNewsLogic(Int32.Parse(lbID.Text));//逻辑删除
            if (isSuccess)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }
            bool isSuccess = GlobalVal.WebSerices.DeleteNewsPhysic(Int32.Parse(lbID.Text));//逻辑删除
            if (isSuccess)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbID.Text = "";
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (tabControl1.Visible == true)
            {
                tabControl1.Visible = false;
                btnManage.Text = "确定";
                return;
            }
            GlobalVal.ManagerPassword = Method.GetWebConfig(ConfigName.ManagerPassword);
            if (Method.EncryptPWD(txtManagementPassword.Text) == GlobalVal.ManagerPassword)
            {
                tabControl1.Visible = true;
                btnManage.Text = "锁定";
                txtManagementPassword.Text = "";
            }
            else
            {
                MessageBox.Show("密码错误！");
                txtManagementPassword.Focus();
                txtManagementPassword.SelectAll();
            }
        }

        private void FormSystem_Shown(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
        }

        private void Calculate()
        {
            DataTable dt = CreateDataTable();

            decimal original = decimal.Parse(txtBenjin.Text);
            decimal rate = decimal.Parse(txtLiLv.Text);//利率
            int time = int.Parse(txtTime.Text);//时间
            int timeOfYear = int.Parse(txtTimesOfYear.Text);//年复利次数
            decimal add = decimal.Parse(txtAdd.Text);//每年追加
            decimal result = original;
            decimal touru = original;
            decimal lixi = 0;
            int year = 1;

            for (int i = 1; i <= time * timeOfYear; i++)
            {
                if (i > timeOfYear && (i - 1) % timeOfYear == 0)
                {
                    result += add;
                    touru += add;
                }
                result += result * rate / timeOfYear;

                if (i >= timeOfYear && (i) % timeOfYear == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Time"] = year++;
                    dr["Lixi"] = string.Format("{0:F2}", result - touru);
                    dr["All"] = string.Format("{0:F2}", result);
                    dr["TouRu"] = string.Format("{0:F2}", touru);
                    dt.Rows.Add(dr);
                }
            }
            lixi = result - touru;
            txtTouRu.Text = string.Format("{0:F2}", touru);
            txtHuibao.Text = string.Format("{0:F2}", result);
            txtLiXi.Text = string.Format("{0:F2}", lixi);

            FillColumnChart(dt);
        }

        private void SetChart()
        {
            string[] x = { "z", "a", "b", "c" };
            int[] y1 = { 1, 2, 3, 4 };
            int[] y2 = { 2, 3, 5, 6 };

            //FillColumnChart(chart2, x, y1, y2);
        }

        public void FillColumnChart(DataTable DT)
        {
            dataGridView2.DataSource = DT;

            chart2.Series.Clear();

            Series seriesAll = new Series("总收入");
            chart2.Series.Add(seriesAll);
            Series seriesLixi = new Series("利息");
            chart2.Series.Add(seriesLixi);
            Series seriesTouRu = new Series("本金");
            chart2.Series.Add(seriesTouRu);
            chart2.DataSource = DT;

            //设置图表Y轴对应项
            seriesAll.YValueMembers = "All";
            seriesLixi.YValueMembers = "Lixi";
            seriesTouRu.YValueMembers = "TouRu";

            //设置图表X轴对应项
            chart2.Series[0].XValueMember = "Time";

            //chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            //chart2.ChartAreas[0].Area3DStyle.Inclination = 30;
            //chart2.ChartAreas[0].Area3DStyle.PointDepth = 50;
            //chart2.ChartAreas[0].Area3DStyle.IsClustered = true;
            //chart2.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart2.DataBind();
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time");
            dt.Columns.Add("All");
            dt.Columns.Add("Lixi");
            dt.Columns.Add("TouRu");
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnNewsSearch_Click(object sender, EventArgs e)
        {
            LoadNews(100);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }
            webService.Notic news = (webService.Notic)dataGridView1.CurrentRow.DataBoundItem;
            lbID.Text = news.Id.ToString();
            lbCreatetime.Text = news.CreateTime.ToString();
            txtSystemName.Text = news.SystemName;
            txtTitle.Text = news.Title;
            txtUrl.Text = news.Url;
            txtBody.Text = news.Body;
        }
    }
}
