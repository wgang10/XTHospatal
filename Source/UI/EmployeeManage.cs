using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class EmployeeManage : FormBase
    {
        public EmployeeManage()
        {
            InitializeComponent();
        }

        private void InitializationCombox()
        {
            Method.CmbDataBound("Department", cmbBM);
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
            grdMain.Columns.Add("EmployeePhone", "电话");
            grdMain.Columns["NO"].Width = 30;
            grdMain.Columns["EmployeeID"].Width = 120;
            grdMain.Columns["EmployeeName"].Width = 70;
            grdMain.Columns["EmployeeSex"].Width = 60;
            grdMain.Columns["EmployeeBM"].Width = 150;
            grdMain.Columns["EmployeeDW"].Width = 147;
            grdMain.Columns["EmployeeJG"].Width = 110;
            grdMain.Columns["EmployeeGZID"].Width = 110;
            grdMain.Columns["EmployeePhone"].Width = 120;

            grdMain.Columns["NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdMain.Columns["NO"].Frozen = true;
            //grdMain.Columns["EmployeeID"].Frozen = true;
            //grdMain.Columns["EmployeeName"].Frozen = true;
            //grdMain.Columns["EmployeeSex"].Frozen = true;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Initial();
            GlobalVal.SplashObj.Dispose();
        }

        private void Initial()
        {
            InitializationCombox();
            GridViewInitial();
            BindGridData();
        }

        private void BindGridData()
        {
            
            try
            {
                XTHotpatalWebServices.ReturnValue resoult = GlobalVal.gloWebSerices.GetListEmployee(" Where Employee.EmployeeID <> '000000000000000000'");
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
                            resoult.ResultDataSet.Tables[0].Rows[i]["EmployeeGZID"].ToString().Trim(),
                            resoult.ResultDataSet.Tables[0].Rows[i]["EmployeePhone"].ToString().Trim());
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

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            if (this.Owner is FormStatistics)
            {
                GlobalVal.StatisticsEmployeeID = grdMain.CurrentRow.Cells["EmployeeID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                EmployeeEdite employeeEdite = new EmployeeEdite(grdMain.CurrentRow.Cells["EmployeeID"].Value.ToString());
                employeeEdite.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdMain.Rows.Clear();
            string strWhere = " Where Employee.EmployeeID <> '000000000000000000' ";
            if (txtName.Text.Trim().Length > 0)
            {
                strWhere += " And Employee.EmployeeName Like '%" + txtName.Text.Trim() + "%' ";
            }
            if (cmbBM.Text.Trim().Length > 0)
            {
                strWhere += " And Employee.EmployeeBM='" + cmbBM.SelectedValue.ToString() + "'";
            }
            if (rdbMan.Checked)
            {
                strWhere += " And Employee.EmployeeSex = '0' ";
            }
            else if (rdbWoman.Checked)
            {
                strWhere += " And Employee.EmployeeSex = '1' ";
            }
            else if (rdbNo.Checked)
            {
                strWhere += " And Employee.EmployeeSex = '' ";
            }


            
            try
            {
                XTHotpatalWebServices.ReturnValue resoult = GlobalVal.gloWebSerices.GetListEmployee(strWhere);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Hide();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeEdite employeeEdite = new EmployeeEdite();
            employeeEdite.ShowDialog();
        }
    }
}