using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class EmployeeCheckNum : FormBase
    {
        public EmployeeCheckNum()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeCheckNum_Load(object sender, EventArgs e)
        {
            Initial();
            GlobalVal.SplashObj.Dispose();
        }

        private void Initial()
        {
            GridViewInitial();
            Method.CmbDataBound("Department", cmbBM);
            Method.CmbDataBound("YearMonth", cmbYearMonth);
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
            grdMain.Columns.Add("SH", "生化");
            grdMain.Columns.Add("WG", "五官");
            grdMain.Columns.Add("WK", "外科");
            grdMain.Columns.Add("NK", "内科");
            grdMain.Columns.Add("XDT", "心电图");
            grdMain.Columns.Add("XX", "X线");
            grdMain.Columns.Add("BC", "B超");
            grdMain.Columns.Add("FK", "妇科");
            grdMain.Columns.Add("TCF", "体成分");
            grdMain.Columns.Add("BG", "报告");
            grdMain.Columns["NO"].Width = 30;
            grdMain.Columns["EmployeeID"].Width = 120;
            grdMain.Columns["EmployeeName"].Width = 65;
            grdMain.Columns["EmployeeSex"].Width = 55;
            grdMain.Columns["EmployeeBM"].Width = 90;
            grdMain.Columns["SH"].Width = 55;
            grdMain.Columns["WG"].Width = 55;
            grdMain.Columns["WK"].Width = 55;
            grdMain.Columns["NK"].Width = 55;
            grdMain.Columns["XDT"].Width = 68;
            grdMain.Columns["XX"].Width = 55;
            grdMain.Columns["BC"].Width = 55;
            grdMain.Columns["FK"].Width = 55;
            grdMain.Columns["TCF"].Width = 68;
            grdMain.Columns["BG"].Width = 55;
            grdMain.Columns["NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdMain.Columns["NO"].Frozen = true;
            //grdMain.Columns["EmployeeID"].Frozen = true;
            //grdMain.Columns["EmployeeName"].Frozen = true;
            //grdMain.Columns["EmployeeSex"].Frozen = true;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            grdMain.Rows.Clear();
            if (cmbYearMonth.Text.Trim().Length < 1)
            {
                return;
            }
            string EmployeeBM=string.Empty;
            if (cmbBM.Text.Trim().Length > 0)
            {
                EmployeeBM = cmbBM.SelectedValue.ToString();
            }


            XTHotpatalWebServices.ReturnValue resoult = GlobalVal.gloWebSerices.GetCheckEmployeeNum(cmbYearMonth.Text, txtName.Text.Trim(), EmployeeBM);
            if (resoult.ErrorFlag)
            {
                for (int i = 0; i < resoult.ResultDataSet.Tables[0].Rows.Count; i++)
                {
                    grdMain.Rows.Add((i + 1).ToString(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["编号"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["姓名"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["性别"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["部门"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["生化检验"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["五官"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["外科"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["内科"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["心电图"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["X线"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["B超"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["妇科"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["体成分"].ToString().Trim(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["报告"].ToString().Trim());
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Hide();
        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            GlobalVal.EmployeeID = grdMain.CurrentRow.Cells["EmployeeID"].Value.ToString();
            GlobalVal.EmployeeName = grdMain.CurrentRow.Cells["EmployeeName"].Value.ToString();
            GlobalVal.gloYearMonth = cmbYearMonth.Text.Trim();
            //GlobalVal.ShowForm.Show();
            GlobalVal.FormInfoEdite.ShowDialog();
            //this.Hide();
        }
    }
}
