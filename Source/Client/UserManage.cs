using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XTHospitalUI
{
    public partial class UserManage : FormBase
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Show();
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUSER_ID.Text.Trim().Length < 1 || txtUSER_WD.Text.Trim().Length < 1)
            {
                MessageBox.Show("用户名和密码不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.LoginUser model = new XTHospitalUI.XTHotpatalWebServices.LoginUser();
            model.UserID = txtUSER_ID.Text.Trim();
            model.UserPwd = txtUSER_WD.Text.Trim();
            model.MEMO = txtMEMO.Text.Trim();
            model.UserType = cmbUSER_GROUP.SelectedIndex.ToString();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult;
            resoult = webService.AddUser(model);
            if (resoult.ErrorFlag)
            {
                ControlInitial();
                BindGridData();
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Hide();
            Initial();
            GlobalVal.SplashObj.Dispose();
        }

        private void UserManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            //GlobalVal.ShowForm.Show();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtUSER_ID.Text.Trim().Length < 1)
            {
                MessageBox.Show("用户名不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Method.MessageShow("Q22007") != DialogResult.Yes)//Are You Sure Delete This Data?
            {
                return;
            }
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult;
            resoult = webService.DeleteUser(txtUSER_ID.Text.Trim());
            if (resoult.ErrorFlag)
            {
                ControlInitial();
                BindGridData();
                MessageBox.Show("操作成功！");
            }
            else
            {
                //MessageBox.Show(resoult.ErrorID);
                Method.MessageShow(resoult.ErrorID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void Initial()
        {
            BindGridData();
            grdMain.Height = 232;
            grdMain.Width = 753;
            ControlInitial();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindGridData()
        {
            grdMain.Rows.Clear();
            grdMain.Columns.Clear();
            GridViewInitial();
            this.Cursor = Cursors.WaitCursor;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue returnValue;
            try
            {
                returnValue = webService.GetUserList();
                if (!returnValue.ErrorFlag)
                {
                    MessageBox.Show(returnValue.ErrorID);
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (returnValue.ResultDataSet.Tables[0].Rows.Count > 10)
                {
                    grdMain.Columns["UserMemo"].Width = 403;
                }
                else
                {
                    grdMain.Columns["UserMemo"].Width = 420;
                }
                grpList.Text = "一览 共" + returnValue.Count  + "条数据";
                for (int i = 0; i < returnValue.ResultDataSet.Tables[0].Rows.Count; i++)
                {
                    grdMain.Rows.Add((i + 1).ToString(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["UserID"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["UserPwd"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["UserType"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["UserTypeName"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["MEMO"].ToString().Trim());
                }
            }
            catch
            {
                Method.MessageShow("E11004");//An unknown error process!
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        private void GridViewInitial()
        {
            grdMain.RowHeadersVisible = false;
            grdMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdMain.ReadOnly = true;
            grdMain.AllowUserToAddRows = false;
            grdMain.TabStop = false;
            grdMain.AllowUserToResizeRows = false;
            grdMain.Columns.Add("NO", "NO.");
            grdMain.Columns.Add("UserID", "用户名");
            grdMain.Columns.Add("UserPWD", "");
            grdMain.Columns.Add("UserType", "");
            grdMain.Columns.Add("UserTypeName", "权限");
            grdMain.Columns.Add("UserMemo", "备注");
            grdMain.Columns["NO"].Width = 30;
            grdMain.Columns["UserID"].Width = 150;
            grdMain.Columns["UserPWD"].Width = 0;
            grdMain.Columns["UserType"].Width = 0;
            grdMain.Columns["UserTypeName"].Width = 150;
            grdMain.Columns["UserMemo"].Width = 420;
            grdMain.Columns["UserPWD"].Visible = false;
            grdMain.Columns["UserType"].Visible = false;
            grdMain.Columns["NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdMain.Columns["NO"].Frozen = true;
            grdMain.Columns["UserID"].Frozen = true;
            grdMain.Columns["UserTypeName"].Frozen = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ControlInitial()
        {
            txtUSER_ID.Text = "";
            txtUSER_WD.Text = "";
            txtMEMO.Text = "";
            cmbUSER_GROUP.SelectedIndex  = 0;
            txtUSER_ID.Focus();
        }

        private void grdMain_Click(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count > 0)
            {
                this.txtUSER_ID.Text = grdMain.CurrentRow.Cells["UserID"].Value.ToString();
                this.txtUSER_WD.Text = grdMain.CurrentRow.Cells["UserPWD"].Value.ToString();
                this.txtMEMO.Text = grdMain.CurrentRow.Cells["UserMemo"].Value.ToString();
                this.cmbUSER_GROUP.SelectedIndex =Int32.Parse(grdMain.CurrentRow.Cells["UserType"].Value.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlInitial();
        }
    }
}