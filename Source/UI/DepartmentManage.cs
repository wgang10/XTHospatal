using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class DepartmentManage : FormBase
    {
        public DepartmentManage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Show();
            //this.Hide();
            GlobalVal.ShowForm.Show();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDepartName.Text.Trim().Length < 1)
            {
                MessageBox.Show("部门名称不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Department model = new UI.XTHotpatalWebServices.Department();
            model.Name = txtDepartName.Text.Trim();
            if (txtDepartmentID.Text.Trim().Length < 1)
            {

                if (MessageBox.Show("确定要添加新部门吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)//确定要添加新部门吗?
                {
                    return;
                }
                model.ID = System.Guid.NewGuid().ToString();
            }
            else
            {
                if (MessageBox.Show("确定要修改该部门吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)//确定要修改该部门吗?
                {
                    return;
                }
                model.ID = txtDepartmentID.Text.Trim();
            }
            model.Notes = txtMEMO.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new UI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult;
            try
            {
                resoult = webService.AddUpdateDepartment(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (resoult.ErrorFlag)
            {
                ControlInitial();
                BindGridData();
                //MessageBox.Show("操作成功！");
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
            //e.Cancel = true;
            //this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtDepartmentID.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择要删除的部门！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("确定要删除该部门吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            XTHotpatalWebServices.Service webService = new UI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult;
            resoult = webService.DeleteDepartment(txtDepartmentID.Text.Trim());
            if (resoult.ErrorFlag)
            {
                ControlInitial();
                BindGridData();
                //MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
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
            BindGridData();
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
            XTHotpatalWebServices.Service webService = new UI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue returnValue;
            try
            {
                returnValue = webService.GetDepartmentList();
                if (!returnValue.ErrorFlag)
                {
                    MessageBox.Show(returnValue.ErrorID);
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (returnValue.ResultDataSet.Tables[0].Rows.Count > 10)
                {
                    grdMain.Columns["Notes"].Width = 403;
                }
                else
                {
                    grdMain.Columns["Notes"].Width = 420;
                }
                grpList.Text = "一览 共" + returnValue.Count  + "条数据";
                for (int i = 0; i < returnValue.ResultDataSet.Tables[0].Rows.Count; i++)
                {
                    grdMain.Rows.Add((i + 1).ToString(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["ID"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["Name"].ToString().Trim(),
                        returnValue.ResultDataSet.Tables[0].Rows[i]["Notes"].ToString().Trim());
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
            grdMain.Columns.Add("ID", "");
            grdMain.Columns.Add("Name", "部门名称");
            grdMain.Columns.Add("Notes", "备注");
            grdMain.Columns["NO"].Width = 30;
            grdMain.Columns["ID"].Width = 0;
            grdMain.Columns["Name"].Width = 300;
            grdMain.Columns["Notes"].Width = 420;
            grdMain.Columns["ID"].Visible = false;
            grdMain.Columns["NO"].Frozen = true;
            grdMain.Columns["ID"].Frozen = true;
            grdMain.Columns["Name"].Frozen = true;
            grdMain.Columns["NO"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["Notes"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ControlInitial()
        {
            txtDepartName.Text = "";
            txtDepartmentID.Text = "";
            txtMEMO.Text = "";
            txtDepartName.Focus();
        }

        private void grdMain_Click(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count > 0)
            {
                this.txtDepartName.Text = grdMain.CurrentRow.Cells["Name"].Value.ToString();
                this.txtDepartmentID.Text = grdMain.CurrentRow.Cells["ID"].Value.ToString();
                this.txtMEMO.Text = grdMain.CurrentRow.Cells["Notes"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlInitial();
        }
    }
}