using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormAppTest
{
    public partial class FormLiLv : Form
    {
        public FormLiLv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
            //SetChart();
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
                if (i > timeOfYear && (i-1) % timeOfYear == 0)
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
            dataGridView1.DataSource = DT;

            chart2.Series.Clear();

            Series seriesAll = new Series("总收入");
            chart2.Series.Add(seriesAll);
            Series seriesLixi = new Series("利息");
            chart2.Series.Add(seriesLixi);

            chart2.DataSource = DT;

            //设置图表Y轴对应项
            seriesAll.YValueMembers = "All";
            seriesLixi.YValueMembers = "Lixi";

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
            return dt;
        }
    }
}
