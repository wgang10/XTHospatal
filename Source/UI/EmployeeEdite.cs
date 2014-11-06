using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class EmployeeEdite : FormBase
    {
        private string G_EmployeeID = string.Empty;
        public EmployeeEdite()
        {
            InitializeComponent();
        }

        public EmployeeEdite(string EmployeeID)
        {   
            InitializeComponent();
            G_EmployeeID = EmployeeID;
        }

        private void InitializationCombox()
        {
            Method.CmbDataBound("Department", cmbBM);
        }

        /// <summary>
        /// 绑定员工信息
        /// </summary>
        /// <param name="EmployeeID"></param>
        private void BindEmployeeInfo(string EmployeeID)
        {

            webService.ReturnValue resoult = GlobalVal.gloWebSerices.GetEmployeeInfo(EmployeeID);
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    #region **********职工信息*****************
                    this.txtName.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeName"].ToString();//姓名
                    this.txtEmployeeGZID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeGZID"].ToString(); ;//工资编号
                    this.txtEmployeePWD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeePWD"].ToString(); ;//查询密码
                    this.txtEmployeeID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeID"].ToString();//员工身份证
                    string strSexTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeSex"].ToString();//性别
                    if (strSexTemp == "0")
                    {
                        this.rdbSexM.Checked = true;
                        this.rdbSexW.Checked = false;
                    }
                    else if (strSexTemp == "1")
                    {
                        this.rdbSexM.Checked = false;
                        this.rdbSexW.Checked = true;
                    }
                    else
                    {
                        this.rdbSexM.Checked = false;
                        this.rdbSexW.Checked = false;
                    }
                    string strBirthday = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBirthday"].ToString();//出生年月
                    if (strBirthday.Length > 0)
                    {
                        this.dtpBirthday.Text = strBirthday.Substring(0, 4) + "-" + strBirthday.Substring(4, 2) + "-" + strBirthday.Substring(6, 2);
                    }
                    string age = Method.GetAge(dtpBirthday.Value).ToString();
                    this.txtAge.Text = age;
                    this.txtEmployeeWHCD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeWHCD"].ToString();//文化程度
                    string HFTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeHF"].ToString();//婚否
                    if (HFTemp == "0")
                    {
                        rdbHF1.Checked = true;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = false;
                    }
                    else if (HFTemp == "1")
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = true;
                        rdbHF3.Checked = false;
                    }
                    else if (HFTemp == "2")
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = true;
                    }
                    else
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = false;
                    }
                    this.txtJG.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJG"].ToString();//籍贯
                    this.txtXJD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeXJD"].ToString();//现住地
                    string strBM = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBM"].ToString();//部门
                    cmbBM.SelectedValue = strBM;
                    for (int i = 0; i < cmbBM.Items.Count; i++)
                    {
                        if (cmbBM.GetItemText(cmbBM.Items[i]) == strBM)
                        {
                            cmbBM.SelectedIndex = i;
                            break;
                        }
                    }
                    this.txtDW.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeDW"].ToString();//单位
                    this.txtJWBS.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJWBS"].ToString();//既往病史
                    this.txtEmail.Text = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString();//Email
                    this.txtEmployeePhone.Text = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePhone"].ToString();//联系电话
                    #endregion
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
            this.Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 1 || txtEmployeeGZID.Text.Trim().Length < 1 || txtEmployeePWD.Text.Trim().Length < 1 || txtEmployeeID.Text.Trim().Length < 1)
            {
                MessageBox.Show("姓名、工资号、查询密码及身份证不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            webService.Employee model = new UI.webService.Employee();
            model.EmployeeName = txtName.Text.Trim();
            model.EmployeeID = txtEmployeeID.Text.Trim();
            model.EmployeeGZID = txtEmployeeGZID.Text.Trim();
            model.EmployeePWD = txtEmployeePWD.Text.Trim();
            if (rdbSexM.Checked)
            {
                model.EmployeeSex = "0";
            }
            else if (rdbSexW.Checked)
            {
                model.EmployeeSex = "1";
            }
            else
            {
                model.EmployeeSex = "";
            }
            model.EmployeeBirthday = dtpBirthday.Text.Trim().Replace("-", "");
            model.EmployeeID = txtEmployeeID.Text.Trim();
            model.EmployeeWHCD = txtEmployeeWHCD.Text.Trim();
            if (rdbHF1.Checked)
            {
                model.EmployeeHF = "0";
            }
            else if (rdbHF2.Checked)
            {
                model.EmployeeHF = "1";
            }
            else if (rdbHF3.Checked)
            {
                model.EmployeeHF = "2";
            }
            else
            {
                model.EmployeeHF = "";
            }
            model.EmployeeJG = txtJG.Text.Trim();
            model.EmployeeXJD = txtXJD.Text.Trim();
            model.EmployeeBM = cmbBM.SelectedValue.ToString();
            model.EmployeeDW = txtDW.Text.Trim();
            model.EmployeeJWBS = txtJWBS.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            model.EmployeeEmail = txtEmail.Text;
            model.EmployeePhone = txtEmployeePhone.Text;

            webService.ReturnValue resoult = GlobalVal.gloWebSerices.AddEmployee(model);
            if (resoult.ErrorFlag)
            {
                if (DialogResult.OK == MessageBox.Show("操作成功！是否关闭本窗口？", "系统提示", MessageBoxButtons.OKCancel))
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeEdite_Load(object sender, EventArgs e)
        {
            InitializationCombox();
            if (!string.IsNullOrEmpty(G_EmployeeID))
            {
                BindEmployeeInfo(G_EmployeeID);
                txtEmployeeID.ReadOnly = true;
                txtEmployeeID.Enabled = false;
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            string age = Method.GetAge(dtpBirthday.Value).ToString();
            if (age == "-1")
            {
                txtAge.Text = "";
                MessageBox.Show("生日不能大于现在时间！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtAge.Text = age;
            }
        }
    }
}
