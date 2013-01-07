using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XTHospitalUI
{
    public partial class Search : FormBase
    {
        public Search()
        {
            InitializeComponent();
            //this.Load += delegate { this.alphaBlendingBringer1.SetAlphaBlending(this); };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Show();
            this.Hide();
        }

        private void Initial()
        {
            InitializationCombox();
            GridViewInitial();
            BindGridData();
            Method.CmbDataBound("YearMonth", cmbYearMonth);
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
            //grdMain.Columns["EmployeeID"].Frozen = true;
            //grdMain.Columns["EmployeeName"].Frozen = true;
            //grdMain.Columns["EmployeeSex"].Frozen = true;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Hide();
            Initial();
            GlobalVal.SplashObj.Dispose();
        }

        private void BindGridData()
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            try
            {
                XTHotpatalWebServices.ReturnValue resoult = webService.GetListEmployee(" Where Employee.EmployeeID <> '000000000000000000'");
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
                    //默认显示当前选择人员的信息
                    if (resoult.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        string EmployeeID = grdMain.CurrentRow.Cells["EmployeeGZID"].Value.ToString();
                        string gloYearMonth = cmbYearMonth.Text.Trim();
                        webBrowser1.Url = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebURL"] + "/Print.aspx?FromType=UI&UserID=" + EmployeeID + "&YearMonth=" + gloYearMonth);
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
            GlobalVal.EmployeeID = grdMain.CurrentRow.Cells["EmployeeID"].Value.ToString();
            GlobalVal.EmployeeName = grdMain.CurrentRow.Cells["EmployeeName"].Value.ToString();
            GlobalVal.gloYearMonth = cmbYearMonth.Text.Trim();
            //GlobalVal.ShowForm.Show();
            GlobalVal.FormInfoEdite.ShowDialog();
            //this.Hide();
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GlobalVal.ShowForm.Show();
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


            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            try
            {
                XTHotpatalWebServices.ReturnValue resoult = webService.GetListEmployee(strWhere);
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
        
        private void Search_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //GlobalVal.ShowForm.Hide();
                GlobalVal.SplashObj.Dispose();
                InitializationCombox();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //if (!GlobalVal.blCloseForm)
            //{
            //    e.Cancel = true;
            //    base.OnFormClosing(e);
            //    this.Hide();
            //}
            //else
            //{
            //    e.Cancel = false;
            //}
            e.Cancel = true;
            this.Hide();
        }

        private void grdMain_Click(object sender, EventArgs e)
        {
            string EmployeeID = grdMain.CurrentRow.Cells["EmployeeGZID"].Value.ToString();
            string gloYearMonth = cmbYearMonth.Text.Trim();
            webBrowser1.Url = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebURL"]+"/Print.aspx?FromType=UI&UserID=" + EmployeeID + "&YearMonth=" + gloYearMonth+"#"+System.DateTime.Now.ToString());
        }

        /// <summary>
        /// 添加体检年月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewYearMonth_Click(object sender, EventArgs e)
        {
            string strYearMonth=cmbYearMonth.Text.Trim();
            if (strYearMonth.Length < 1)
            {
                MessageBox.Show("请选择或输入年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbYearMonth.Focus();
                cmbYearMonth.Select();
                return;
            }
            if (!CheckYearMonth(strYearMonth))
            {
                MessageBox.Show("请输入正确的年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbYearMonth.Focus();
                cmbYearMonth.Select();
                return;
            }
            XTHotpatalWebServices.Service webSerices = new XTHospitalUI.XTHotpatalWebServices.Service();
            string[] resoult = webSerices.SetYearMonth(GlobalVal.gloStrLoginUserID,GlobalVal.gloStrTerminalCD, strYearMonth);
            if (resoult[0] != "1")
            {
                MessageBox.Show(resoult[1], "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Method.CmbDataBound("YearMonth", cmbYearMonth);

                for (int i = 0; i < cmbYearMonth.Items.Count; i++)
                {
                    if (cmbYearMonth.GetItemText(cmbYearMonth.Items[i]) == strYearMonth)
                    {
                        cmbYearMonth.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// SetYearMonth
        /// </summary>
        /// <param name="YearMonth"></param>
        /// <returns></returns>
        private bool CheckYearMonth(string YearMonth)
        {
            bool blFlag = false;
            int intYear = 0;
            int intMonth = 0;
            if (YearMonth.Trim().Length == 6)
            {
                try
                {
                    intYear = Int32.Parse(YearMonth.Substring(0, 4));
                    intMonth = Int32.Parse(YearMonth.Substring(4, 2));
                    if (1900 <= intYear && intYear <= 2100 && 1 <= intMonth && intMonth <= 12)
                    {
                        blFlag = true;
                    }
                }
                catch
                {
                }
            }
            return blFlag;
        }
    }
}