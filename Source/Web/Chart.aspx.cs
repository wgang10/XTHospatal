using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class _Chart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Calculate();
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
        txtTouRu.DataBind();
        txtHuibao.Text = string.Format("{0:F2}", result);
        txtLiXi.Text = string.Format("{0:F2}", lixi);

        FillColumnChart(dt);
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

    public void FillColumnChart(DataTable DT)
    {
        dataGridView1.DataSource = DT;
        dataGridView1.DataBind();

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
}
