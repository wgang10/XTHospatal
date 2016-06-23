using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using System.IO;

namespace UI
{
    public partial class FormStatistics : FormBase
    {
        string[] XT = {"HY_GLU"};//血糖
        string[] GG = {"HYTBIL","HYDBIL","HYTP","HYALB","HYALT","HYAST","HYGT","HYALP"};//肝功
        string[] SG = {"HY_UREA","HY_CR","HYUA"};//肾功
        string[] XZ = { "HYTC","HYTG","HYHDLC","HYLDLC","HYAPOAI","HYAPOB"};//血脂
        string[] FA = { "HY_AFP","HY_CEA"};//防癌

        DataTable tbStatistics;

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.FormShow.Show();
            this.Close();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
          Initial();
            GlobalVal.SplashObj.Dispose();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = null;
            //GlobalVal.gloWebSerices.GetAllBiochemistryDataCompleted += new webService.GetAllBiochemistryDataCompletedEventHandler(gloWebSerices_GetAllBiochemistryDataCompleted);
            //GlobalVal.gloWebSerices.GetAllBiochemistryDataAsync();
            //btnSearch.Enabled = false;
          webService.Service sw = new webService.Service();
          byte[] buffer = sw.GetAllBiochemistryData();
          if (buffer != null)
          {
            DataSet ds = DataSetZip.Decompress(buffer);
            this.dataGridView1.DataSource = ds.Tables[0];
            this.label1.Text = ds.Tables[0].Rows.Count.ToString();
          }

          BindGridData();
        }

        void gloWebSerices_GetAllBiochemistryDataCompleted(object sender, webService.GetAllBiochemistryDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result == null)
                {
                    MessageBox.Show("没有数据或发生错误。");
                }
                else
                {
                    DataSet ds = DataSetZip.Decompress(e.Result);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            btnSearch.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = null;
            //byte[] buffer = GlobalVal.gloWebSerices.GetAllBiochemistryData();
            //if (buffer != null)
            //{
            //    DataSet ds = DataSetZip.Decompress(buffer);
            //    this.dataGridView1.DataSource = ds.Tables[0];
            //}
          webService.Service ws = new webService.Service();
          webService.Service sw=new webService.Service();
          byte[] buffer = sw.GetAllBiochemistryData();
          bool resoult = ws.InportBiochemistryData(buffer);
          if (resoult)
          {
            MessageBox.Show("导入成功");
          }
          else
          {
            MessageBox.Show("导入失败");
          }
        }

      /// <summary>
      /// 获得统计数据
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //webService.Service ws = new webService.Service();
            //byte[] buffer = ws.GetStatisticsData();
            //if (buffer != null)
            //{
            //  DataSet ds = DataSetZip.Decompress(buffer);
            //  if (ds.Tables.Count > 0)
            //  {
            //    this.dataGridView1.DataSource = ds.Tables[0];
            //    tbStatistics = ds.Tables[0];
            //    BindChart(tbStatistics);
            //  }
            //}

            webService.ReturnValue resoult = GlobalVal.WebSerices.GetStatisticsBio("120103196202153240");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    tbStatistics = resoult.ResultDataSet.Tables[0];
                    BindChart(tbStatistics);
                }
                else
                {
                    MessageBox.Show(resoult.ErrorID);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string responseFromServer=@"{""client_id"":""100289171"",""openid"":""1AC83BAA19BB2E892033E0C07C27AC24""}";
            var user = JsonConvert.DeserializeObject<ObjUser>(responseFromServer);
            string openid = string.Empty;
            JsonReader Jreader = new JsonTextReader(new StringReader(responseFromServer));
            while (Jreader.Read())
            {
                Console.WriteLine(Jreader.TokenType + "\t\t" + Jreader.ValueType + "\t\t" + Jreader.Value);
                //openid = Jreader.Value.ToString();
            }
        }

        private void Initial()
        {
          GridViewInitial();
        }

        private void BindGridData()
        {
          webService.Service sw = new webService.Service();
          try
          {
            webService.ReturnValue resoult = sw.GetListEmployee(" Where Employee.EmployeeID <> '000000000000000000'");
            if (resoult.ErrorFlag)
            {
              for (int i = 0; i < resoult.ResultDataSet.Tables[0].Rows.Count; i++)
              {
                grdMain.Rows.Add((i + 1).ToString(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeID"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeName"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmpSex"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeBM"].ToString().Trim() == "请选择" ? "" : resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeBM"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeDW"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeJG"].ToString().Trim(),
                    resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeGZID"].ToString().Trim());
              }
            }
            else
            {
              MessageBox.Show(resoult.ErrorID);
            }
          }
          catch
          {
            this.Cursor = Cursors.Default;
          }
          this.Cursor = Cursors.Default;
        }

        private void GridViewInitial()
        {
          grdMain.ScrollBars = ScrollBars.Both;
          grdMain.RowHeadersVisible = false;
          grdMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          grdMain.ReadOnly = true;
          grdMain.AllowUserToAddRows = false;
          grdMain.TabStop = false;
          grdMain.AllowUserToResizeRows = false;
          grdMain.Columns.Add("NO", "NO.");
          grdMain.Columns.Add("EmployeeID", "身份证号码");
          grdMain.Columns.Add("EmployeeName", "姓名");
          grdMain.Columns.Add("EmployeeSex", "性别");
          grdMain.Columns.Add("EmployeeBM", "部门");
          grdMain.Columns.Add("EmployeeDW", "单位");
          grdMain.Columns.Add("EmployeeJG", "籍贯");
          grdMain.Columns.Add("EmployeeGZID", "查询账号");
          grdMain.Columns["NO"].Width = 30;
          grdMain.Columns["EmployeeID"].Width = 120;
          grdMain.Columns["EmployeeName"].Width = 70;
          grdMain.Columns["EmployeeSex"].Width = 60;
          grdMain.Columns["EmployeeBM"].Width = 150;
          grdMain.Columns["EmployeeDW"].Width = 147;
          grdMain.Columns["EmployeeJG"].Width = 110;
          grdMain.Columns["EmployeeGZID"].Width = 110;

          grdMain.Columns["NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          grdMain.Columns["NO"].Frozen = true;
        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
          string EmployeeID = grdMain.CurrentRow.Cells["EmployeeID"].Value.ToString();
          webService.Service ws = new webService.Service();
          byte[] buffer = ws.GetStatisticsDataByID(EmployeeID);
          if (buffer != null)
          {
            DataSet ds = DataSetZip.Decompress(buffer);
            if (ds.Tables.Count > 0)
            {
              this.dataGridView1.DataSource = ds.Tables[0];

            
              int length = 0;
              int lenghtCopy = 0;
              if (ckbFA.Checked)//防癌
              {
                  length += FA.Length;
              }
              if (ckbXZ.Checked)//血脂
              {
                  length += XZ.Length;
              }
              if (ckbGG.Checked)//肝功
              {
                  length += GG.Length;
              }
              if (ckbSG.Checked)//肾功
              {
                  length += SG.Length;
              }
              if (ckbXT.Checked)//血糖
              {
                  length += XT.Length;
              }
              string[] series = new string[length];
              if (ckbFA.Checked)//防癌
              {
                  FA.CopyTo(series, lenghtCopy);
                  lenghtCopy += FA.Length;
              }
              if (ckbXZ.Checked)//血脂
              {
                  XZ.CopyTo(series, lenghtCopy);
                  lenghtCopy += XZ.Length;
              }
              if (ckbGG.Checked)//肝功
              {
                  GG.CopyTo(series, lenghtCopy);
                  lenghtCopy += GG.Length;
              }
              if (ckbSG.Checked)//肾功
              {
                  SG.CopyTo(series, lenghtCopy);
                  lenghtCopy += SG.Length;
              }
              if (ckbXT.Checked)//血糖
              {
                  XT.CopyTo(series, lenghtCopy);
                  lenghtCopy += XT.Length;
              }

              try
              {
                  chart2.Series.Clear();
                  chart2.DataSource = ds.Tables[0];

                  for (int i = 0; i < series.Length; i++)
                  {
                      Series series1 = new Series(series[i]);
                      series1.ChartType = SeriesChartType.Column;
                      chart2.Series.Add(series1);
                      series1.XValueMember = "YearMonth";
                      series1.YValueMembers = series[i];
                  }
                  chart2.DataBind();
              }
              catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
              }
            }
          }

        }

        private void BindChart(DataTable tb)
        {
            chart2.Series.Clear();
            chart2.DataSource = tb;

            //            string[] series ={"HYTC","HYTG","HYHDLC","HYLDLC","HYAPOAI","HYAPOB","HYTBIL","HYDBIL",
            //"HYTP","HYALB","HYALT","HYAST","HYGT","HYALP","HY_GLU","HY_UREA","HY_CR","HYUA","HY_AFP","HY_CEA"};
            string[] series ={"HYTC","HYTG","HYHDLC","HYLDLC","HYAPOAI","HYAPOB"};

            for (int i = 0; i < series.Length; i++)
            {
                Series series1 = new Series(series[i]);
                series1.ChartType = SeriesChartType.Spline;
                chart2.Series.Add(series1);
                series1.XValueMember = "YearMoth";
                series1.YValueMembers = series[i];
            }
            chart2.DataBind();
        }

        private void ItemCheckedChanged(object sender, EventArgs e)
        {
            if (tbStatistics == null)
            {
                return;
            }
            int length=0;
            int lenghtCopy = 0;
            if (ckbFA.Checked)//防癌
            {
                length += FA.Length;
            }
            if (ckbXZ.Checked)//血脂
            {
                length += XZ.Length;
            }
            if (ckbGG.Checked)//肝功
            {
                length += GG.Length;
            }
            if (ckbSG.Checked)//肾功
            {
                length += SG.Length;
            }
            if (ckbXT.Checked)//血糖
            {
                length += XT.Length;
            }
            string[] series=new string[length];
            if (ckbFA.Checked)//防癌
            {
                FA.CopyTo(series, lenghtCopy);
                lenghtCopy += FA.Length;
            }
            if (ckbXZ.Checked)//血脂
            {
                XZ.CopyTo(series, lenghtCopy);
                lenghtCopy += XZ.Length;
            }
            if (ckbGG.Checked)//肝功
            {
                GG.CopyTo(series, lenghtCopy);
                lenghtCopy += GG.Length;
            }
            if (ckbSG.Checked)//肾功
            {
                SG.CopyTo(series, lenghtCopy);
                lenghtCopy += SG.Length;
            }
            if (ckbXT.Checked)//血糖
            {
                XT.CopyTo(series, lenghtCopy);
                lenghtCopy += XT.Length;
            }

            chart2.Series.Clear();
            chart2.DataSource = tbStatistics;

            for (int i = 0; i < series.Length; i++)
            {
                Series series1 = new Series(series[i]);
                series1.ChartType = SeriesChartType.Spline;
                chart2.Series.Add(series1);
                series1.XValueMember = "YearMonth";
                series1.YValueMembers = series[i];
            }
            chart2.DataBind();
        }

        /// <summary>
        /// 个人统计，打开员工选择窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPersonal_Click(object sender, EventArgs e)
        {
            if (GlobalVal.FormEmpManage.ShowDialog(this) == DialogResult.OK)
            {
                webService.Service ws = new webService.Service();
                byte[] buffer = ws.GetStatisticsDataByID(GlobalVal.StatisticsEmployeeID);
                if (buffer != null)
                {
                    DataSet ds = DataSetZip.Decompress(buffer);
                    if (ds.Tables.Count > 0)
                    {
                        this.dataGridView1.DataSource = ds.Tables[0];


                        int length = 0;
                        int lenghtCopy = 0;
                        if (ckbFA.Checked)//防癌
                        {
                            length += FA.Length;
                        }
                        if (ckbXZ.Checked)//血脂
                        {
                            length += XZ.Length;
                        }
                        if (ckbGG.Checked)//肝功
                        {
                            length += GG.Length;
                        }
                        if (ckbSG.Checked)//肾功
                        {
                            length += SG.Length;
                        }
                        if (ckbXT.Checked)//血糖
                        {
                            length += XT.Length;
                        }
                        string[] series = new string[length];
                        if (ckbFA.Checked)//防癌
                        {
                            FA.CopyTo(series, lenghtCopy);
                            lenghtCopy += FA.Length;
                        }
                        if (ckbXZ.Checked)//血脂
                        {
                            XZ.CopyTo(series, lenghtCopy);
                            lenghtCopy += XZ.Length;
                        }
                        if (ckbGG.Checked)//肝功
                        {
                            GG.CopyTo(series, lenghtCopy);
                            lenghtCopy += GG.Length;
                        }
                        if (ckbSG.Checked)//肾功
                        {
                            SG.CopyTo(series, lenghtCopy);
                            lenghtCopy += SG.Length;
                        }
                        if (ckbXT.Checked)//血糖
                        {
                            XT.CopyTo(series, lenghtCopy);
                            lenghtCopy += XT.Length;
                        }

                        try
                        {
                            chart2.Series.Clear();
                            chart2.DataSource = ds.Tables[0];

                            for (int i = 0; i < series.Length; i++)
                            {
                                Series series1 = new Series(series[i]);
                                series1.ChartType = SeriesChartType.Column;
                                chart2.Series.Add(series1);
                                series1.XValueMember = "YearMonth";
                                series1.YValueMembers = series[i];
                            }
                            chart2.DataBind();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                
            }
        }
        
    }
    class ObjUser
    {
        public string client_id
        {
            set;
            get;
        }

        public string openid
        {
            set;
            get;
        }
    }
}
