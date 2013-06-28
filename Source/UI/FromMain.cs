using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormLogManage.ShowDialog();
                    LogManage logManage = new LogManage();
                    logManage.ShowDialog();
                    break;
                case "btnSearch"://查询
                case "btnPrint"://打印
                case "btnInfoEdite"://体检信息维护
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    GlobalVal.FormSearch.ShowDialog();
                    break;
                //case "btnInfoEdite"://体检信息维护
                //    GlobalVal.SplashObj = SplashObject.GetLoading();
                //    GlobalVal.FormInfoEdite.ShowDialog();
                //    break;
                case "btnEmployee"://教职工管理
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    GlobalVal.EmpManage.ShowDialog();
                    //EmployeeManage employeeManage = new EmployeeManage();
                    //employeeManage.ShowDialog();
                    break;
                case "btnUserManage"://用户管理
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormUserManage.ShowDialog();
                    UserManage userManage = new UserManage();
                    userManage.ShowDialog();
                    break;
                case "btnDepartmentManage"://部门管理
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormDepartmentManage.ShowDialog();
                    DepartmentManage DepManage = new DepartmentManage();
                    DepManage.ShowDialog();
                    break;
                case "btnProject"://项目检查状况
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //EmployeeCheckNum CheckProject = new EmployeeCheckNum();
                    //CheckProject.ShowDialog();
                    GlobalVal.EmpCheckProject.ShowDialog();
                    break;
                case "btnConfig":
                case "btnSystem":
                case "btnStatistics":
                case "btnHelp":
                    GlobalVal.ShowForm.Hide();
                    GlobalVal.SplashObj = SplashObject.GetLoading();
                    //GlobalVal.FormConfig.ShowDialog();
                    FormConfig config = new FormConfig();
                    config.ShowDialog();
                    break;
            }
        }

        private void FromMain_Load(object sender, EventArgs e)
        {
            this.Activate();
            GlobalVal.SplashObj.Dispose();
            try
            {
                FromLogin frm = new FromLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Activate();
                    GlobalVal.ShowForm = this;
                    BindChartData();
                    try
                    {
                        this.Text = GlobalVal.glostrSystemName + "    "
                            + GlobalVal.glostrAppNo.Substring(0, GlobalVal.glostrAppNo.IndexOf("@"))
                            + "    " + GlobalVal.gloStrLoginUserID;
                    }
                    catch { }
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindChartData()
        {

            XTHotpatalWebServices.ReturnValue resoult = GlobalVal.gloWebSerices.StatisticNums();
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
