using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormConfig : FormBase
    {
        public FormConfig()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.FormShow.Show();
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
            try
            {
                LoadStatisticsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadStatisticsData()
        {
            string HY_TC=string.Empty;
            string HY_TG = string.Empty;
            string HY_HDL_C = string.Empty;
            string HYLDLC = string.Empty;
            string HYAPOAI = string.Empty;
            string HYAPOB = string.Empty;

            List<StatisticItem> listHY_TC = new List<StatisticItem>();
            List<StatisticItem> listHY_TG = new List<StatisticItem>();
            List<StatisticItem> listHYHDLC = new List<StatisticItem>();
            List<StatisticItem> listHYLDLC = new List<StatisticItem>();
            List<StatisticItem> listHYAPOAI = new List<StatisticItem>();
            List<StatisticItem> listHYAPOB = new List<StatisticItem>();

            webService.ReturnValue resoult = GlobalVal.WebSerices.GetStatisticsBio("120103196202153240");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    double temp;
                    DataTable tbStatistics = resoult.ResultDataSet.Tables[0];
                    for (int i = 0; i < tbStatistics.Rows.Count; i++)
                    {
                        StatisticItem itemHY_TC = new StatisticItem();//总胆固醇(TC)
                        StatisticItem itemHY_TG = new StatisticItem();//甘油三脂(TG)
                        StatisticItem itemHYHDLC = new StatisticItem();//高密度脂蛋白胆固醇(HDL-C)
                        StatisticItem itemHYLDLC = new StatisticItem();//低密度脂蛋白胆固醇(LDL-C)
                        StatisticItem itemHYAPOAI = new StatisticItem();//载脂蛋白AI(APOAI)
                        StatisticItem itemHYAPOB = new StatisticItem();//载脂蛋白B(APOB)

                        if (double.TryParse(tbStatistics.Rows[i]["HYTC"].ToString(),out temp))
                        {
                            itemHY_TC.YourValue = temp;
                        }
                        if (double.TryParse(tbStatistics.Rows[i]["HYTG"].ToString(), out temp))
                        {
                            itemHY_TG.YourValue = temp;
                        }
                        if (double.TryParse(tbStatistics.Rows[i]["HYHDLC"].ToString(), out temp))
                        {
                            itemHYHDLC.YourValue = temp;
                        }
                        if (double.TryParse(tbStatistics.Rows[i]["HYLDLC"].ToString(), out temp))
                        {
                            itemHYLDLC.YourValue = temp;
                        }
                        if (double.TryParse(tbStatistics.Rows[i]["HYAPOAI"].ToString(), out temp))
                        {
                            itemHYAPOAI.YourValue = temp;
                        }
                        if (double.TryParse(tbStatistics.Rows[i]["HYAPOB"].ToString(), out temp))
                        {
                            itemHYAPOB.YourValue = temp;
                        }
                        itemHY_TC.Date = tbStatistics.Rows[i]["YearMoth"].ToString();
                        itemHY_TG.Date = tbStatistics.Rows[i]["YearMoth"].ToString();
                        itemHYHDLC.Date = tbStatistics.Rows[i]["YearMoth"].ToString();
                        itemHYLDLC.Date = tbStatistics.Rows[i]["YearMoth"].ToString();
                        itemHYAPOAI.Date = tbStatistics.Rows[i]["YearMoth"].ToString();
                        itemHYAPOB.Date = tbStatistics.Rows[i]["YearMoth"].ToString();

                        listHY_TC.Add(itemHY_TC);
                        listHY_TG.Add(itemHY_TG);
                        listHYHDLC.Add(itemHYHDLC);
                        listHYLDLC.Add(itemHYLDLC);
                        listHYAPOAI.Add(itemHYAPOAI);
                        listHYAPOB.Add(itemHYAPOB);

                        //this.txtHYAST.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYAST"].ToString();//天门冬氨酸氨基转移酶(AST)
                        //this.txtHYGT.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYGT"].ToString();//γ-谷胺酰转肽酶(γ-GT)
                        //this.txtHYALP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALP"].ToString();//碱性磷酸酶(ALP)
                        //this.txtHYUA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYUA"].ToString();//尿酸（UA）

                        //this.txtHY_TBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTBIL"].ToString();//总胆红素(TBIL)
                        //this.txtHY_DBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYDBIL"].ToString();//直接胆红素(DBIL)
                        //this.txtHY_TP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTP"].ToString();//总蛋白(TP)
                        //this.txtHY_ALB.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALB"].ToString();//白蛋白(ALB)
                        //this.txtHY_ALT.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALT"].ToString();//谷丙转氨酶(ALT)
                        //this.txtGLU.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_GLU"].ToString();//血糖
                        //this.txtUREA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_UREA"].ToString();//尿素
                        //this.txtCR.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CR"].ToString();//肌酐
                        //this.txtAFP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_AFP"].ToString();//甲胎蛋白
                        //this.txtCEA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CEA"].ToString();//癌胚抗原
                    }
                }
                else
                {
                    MessageBox.Show(resoult.ErrorID);
                }
            }

            //
            webService.ReturnValue resoultT = GlobalVal.WebSerices.GetBioTInfo();
            if (resoultT.ErrorFlag)
            {
                if (resoultT.Count > 0)
                {
                    HY_TC = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYTC"].ToString();//总胆固醇(TC) mmol / L 参考≦5.60
                    HY_TG = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYTG"].ToString();//甘油三脂(TG) mmol/L 参考≦2.30
                    HY_HDL_C = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYHDLC"].ToString();//高密度脂蛋白胆固醇(HDL-C) mmol/L 参考 1.20-1.68
                    HYLDLC = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYLDLC"].ToString();//低密度脂蛋白胆固醇(LDL-C) mmol/L 参考 2.07-3.10
                    HYAPOAI = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYAPOAI"].ToString();//载脂蛋白AI(APOAI) g/L    参考 1.00-1.60
                    HYAPOB = resoultT.ResultDataSet.Tables[0].Rows[0]["_Bio_HYAPOB"].ToString();//载脂蛋白B(APOB) g/L    参考 0.6-1.1

                    //this.txtHYAST.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYAST"].ToString();//天门冬氨酸氨基转移酶(AST)
                    //this.txtHYGT.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYGT"].ToString();//γ-谷胺酰转肽酶(γ-GT)
                    //this.txtHYALP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYALP"].ToString();//碱性磷酸酶(ALP)
                    //this.txtHYUA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYUA"].ToString();//尿酸（UA）

                    //this.txtHY_TBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYTBIL"].ToString();//总胆红素(TBIL)
                    //this.txtHY_DBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYDBIL"].ToString();//直接胆红素(DBIL)
                    //this.txtHY_TP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYTP"].ToString();//总蛋白(TP)
                    //this.txtHY_ALB.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYALB"].ToString();//白蛋白(ALB)
                    //this.txtHY_ALT.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HYALT"].ToString();//谷丙转氨酶(ALT)
                    //this.txtGLU.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HY_GLU"].ToString();//血糖
                    //this.txtUREA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HY_UREA"].ToString();//尿素
                    //this.txtCR.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HY_CR"].ToString();//肌酐
                    //this.txtAFP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HY_AFP"].ToString();//甲胎蛋白
                    //this.txtCEA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["_Bio_HY_CEA"].ToString();//癌胚抗原
                }
                else
                {
                    MessageBox.Show(resoult.ErrorID);
                }
            }
            int hight = 250;
            int width = 350;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            //总胆固醇(TC) mmol / L 参考≦5.60
            HY_TC = HY_TC.Replace("mmol","").Replace("/","").Replace("L","").Replace("参考", "").Replace("≦","").Trim();
            UControlChart chartHY_TC = new UControlChart();
            chartHY_TC.Height = hight;
            chartHY_TC.Width = width;
            chartHY_TC.Title = "总胆固醇(TC) mmol / L";
            flowLayoutPanel1.Controls.Add(chartHY_TC);
            chartHY_TC.MinValue = 0;
            chartHY_TC.MaxValue = double.Parse(HY_TC);
            chartHY_TC.StatisticItems = listHY_TC;
            //甘油三脂(TG) mmol/L 参考≦2.30
            HY_TG = HY_TG.Replace("mmol", "").Replace("/", "").Replace("L", "").Replace("参考", "").Replace("≦", "").Trim();
            UControlChart chartHY_TG = new UControlChart();
            chartHY_TG.Height = hight;
            chartHY_TG.Width = width;
            chartHY_TG.Title = "甘油三脂(TG) mmol/L";
            flowLayoutPanel1.Controls.Add(chartHY_TG);
            chartHY_TG.MinValue = 0;
            chartHY_TG.MaxValue = double.Parse(HY_TG);
            chartHY_TG.StatisticItems = listHY_TG;
            //高密度脂蛋白胆固醇(HDL-C) mmol/L 参考 1.20-1.68
            HY_HDL_C = HY_HDL_C.Replace("mmol", "").Replace("/", "").Replace("L", "").Replace("参考", "").Trim();
            UControlChart chartHYHDLC = new UControlChart();
            chartHYHDLC.Height = hight;
            chartHYHDLC.Width = width;
            chartHYHDLC.Title = "高密度脂蛋白胆固醇(HDL-C)";
            flowLayoutPanel1.Controls.Add(chartHYHDLC);
            chartHYHDLC.MinValue = double.Parse(HY_HDL_C.Split('-')[0]);
            chartHYHDLC.MaxValue = double.Parse(HY_HDL_C.Split('-')[1]);
            chartHYHDLC.StatisticItems = listHYHDLC;
            //低密度脂蛋白胆固醇(LDL-C) mmol/L 参考 2.07-3.10
            HYLDLC = HYLDLC.Replace("mmol", "").Replace("/", "").Replace("L", "").Replace("参考", "").Trim();
            UControlChart chartHYLDLC = new UControlChart();
            chartHYLDLC.Height = hight;
            chartHYLDLC.Width = width;
            chartHYLDLC.Title = "低密度脂蛋白胆固醇(LDL-C) mmol/L";
            flowLayoutPanel1.Controls.Add(chartHYLDLC);
            chartHYLDLC.MinValue = double.Parse(HYLDLC.Split('-')[0]);
            chartHYLDLC.MaxValue = double.Parse(HYLDLC.Split('-')[1]);
            chartHYLDLC.StatisticItems = listHYLDLC;
            //载脂蛋白AI(APOAI) g/L    参考 1.00-1.60
            HYAPOAI = HYAPOAI.Replace("g", "").Replace("/", "").Replace("L", "").Replace("参考", "").Trim();
            UControlChart chartHYAPOAI = new UControlChart();
            chartHYAPOAI.Height = hight;
            chartHYAPOAI.Width = width;
            chartHYAPOAI.Title = "载脂蛋白AI(APOAI) g/L";
            flowLayoutPanel1.Controls.Add(chartHYAPOAI);
            chartHYAPOAI.MinValue = double.Parse(HYAPOAI.Split('-')[0]);
            chartHYAPOAI.MaxValue = double.Parse(HYAPOAI.Split('-')[1]);
            chartHYAPOAI.StatisticItems = listHYAPOAI;
            //载脂蛋白B(APOB) g/L    参考 0.6-1.1
            HYAPOB = HYAPOB.Replace("g", "").Replace("/", "").Replace("L", "").Replace("参考", "").Trim();
            UControlChart chartHYAPOB = new UControlChart();
            chartHYAPOB.Height = hight;
            chartHYAPOB.Width = width;
            chartHYAPOB.Title = "载脂蛋白B(APOB) g/L";
            flowLayoutPanel1.Controls.Add(chartHYAPOB);
            chartHYAPOB.MinValue = double.Parse(HYAPOB.Split('-')[0]);
            chartHYAPOB.MaxValue = double.Parse(HYAPOB.Split('-')[1]);
            chartHYAPOB.StatisticItems = listHYAPOB;
        }
    }
}
