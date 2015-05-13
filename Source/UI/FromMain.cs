using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FromMain : FormBase
    {
        public FromMain()
        {
            InitializeComponent();
            this.Load += delegate { this.alphaBlendingBringer1.SetAlphaBlending(this); };
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string btnName=string.Empty;
            btnName = ((Button)sender).Name;
            switch (btnName)
            {
                case "btnLogManage"://日志管理
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormLogManage.ShowDialog();//为了每次打开都是最新数据
                    FormLogManage fromlogManage = new FormLogManage();
                    fromlogManage.ShowDialog();
                    break;
                case "btnSearch"://查询
                case "btnPrint"://打印
                case "btnInfoEdite"://体检信息维护
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    GlobalVal.FormSearch.ShowDialog();
                    break;
                //case "btnInfoEdite"://体检信息维护
                //    GlobalVal.SplashObj = SplashObject.GetLoading();
                //    GlobalVal.FormInfoEdite.ShowDialog();
                //    break;
                case "btnEmployee"://教职工管理
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    GlobalVal.FormEmpManage.ShowDialog();
                    //EmployeeManage employeeManage = new EmployeeManage();
                    //employeeManage.ShowDialog();
                    break;
                case "btnUserManage"://用户管理
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormUserManage.ShowDialog();
                    FormUserManage userManage = new FormUserManage();
                    userManage.ShowDialog();
                    break;
                case "btnDepartmentManage"://部门管理
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormDepartmentManage.ShowDialog();
                    FormDepartmentManage DepManage = new FormDepartmentManage();
                    DepManage.ShowDialog();
                    break;
                case "btnProject"://项目检查状况
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //EmployeeCheckNum CheckProject = new EmployeeCheckNum();
                    //CheckProject.ShowDialog();
                    GlobalVal.FormCheckNum.ShowDialog();
                    break;
                case "btnStatistics"://信息统计
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormConfig.ShowDialog();
                    FormStatistics statistics = new FormStatistics();
                    statistics.ShowDialog();
                    break;
                case "btnConfig"://参数设置
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormConfig.ShowDialog();
                    FormConfig config = new FormConfig();
                    config.ShowDialog();
                    break;
                case "btnSystem"://系统设置
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormConfig.ShowDialog();
                    FormSystem formSystem = new FormSystem();
                    formSystem.ShowDialog();
                    break;
                case "btnHelp"://帮助
                    GlobalVal.FormShow.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormConfig.ShowDialog();
                    FormHelp formHelp = new FormHelp();
                    formHelp.ShowDialog();
                    break;
            }
        }

        private void FromMain_Load(object sender, EventArgs e)
        {
            this.Activate();
            //检查并更新update.exe文件
            //是否存在
            string updateExe = GlobalVal.AappPath + @"\UpdateApp.exe";
            string updateExeUrl = GlobalVal.ServicesURL + @"/App/UpdateApp.exe.zip";
            WebClient downWebClient = new WebClient();
            downWebClient.DownloadFileCompleted += delegate(object wcsender, AsyncCompletedEventArgs ex)
            {
                if (ex.Error != null)
                {
                    MessageBox.Show(ex.Error.Message);
                }
                else
                {
                    GlobalVal.SplashObj.Dispose();
                }
            };
            if (File.Exists(updateExe))
            {
                //检查是否需要更新
                string localMd5 = Method.GetMD5HashFromFile(updateExe);
                string serverMd5 = GetUpdateAppMD5();
                if (localMd5 != serverMd5)
                {
                    File.Delete(updateExe);
                    downWebClient.DownloadFileAsync(new Uri(updateExeUrl), updateExe);
                }
            }
            else
            {
                //直接下载
                downWebClient.DownloadFileAsync(new Uri(updateExeUrl), updateExe);
            }
            
            try
            {
                if (this.DesignMode != true)
                {
                    FormLogin frm = new FormLogin();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.Activate();
                        GlobalVal.FormShow = this;
                        BindChartData();
                        try
                        {
                            this.Text = GlobalVal.SystemNameCN + "    当前登录用户：" + GlobalVal.LoginUserID;
                            LoginUser = GlobalVal.LoginUserID;
                        }
                        catch { }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string GetUpdateAppMD5()
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}", GlobalVal.ServicesURL + "/GetUpdateExeMD5.ashx"));
            WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();
            Encoding encode = System.Text.Encoding.Default;
            StreamReader readStream = new StreamReader(resStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                String str = new String(read, 0, count);
                strRet = strRet + str;
                count = readStream.Read(read, 0, 256);
            }
            resStream.Close();
            readStream.Close();
            res.Close();
            return strRet;
        }

        private void BindChartData()
        {

            webService.ReturnValue resoult = GlobalVal.WebSerices.StatisticNums();
            if (resoult.ErrorFlag)
            {
                DataSetHelper dsHelper = new DataSetHelper();
                DataTable tb = dsHelper.SelectGroupByInto("new", resoult.ResultDataSet.Tables[0], "YearMonth,Max(Nums) Nums", "YearMonth<>'000000'", "YearMonth");
                Chart1.DataSource = tb;
                Chart1.Series[0].XValueMember = "YearMonth";
                Chart1.Series[0].YValueMembers = "Nums";
                Chart1.Series[0].Name = "人数";
                Chart1.DataBind();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            BindChartData();
        }

        private void FromMain_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (GlobalVal.blCloseForm)
            {
                e.Cancel = false;
                return;
            }
            if (MessageBox.Show("确定要退出系统吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
