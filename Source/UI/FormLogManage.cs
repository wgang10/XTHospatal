using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLogManage : FormBase
    {
        public FormLogManage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Close();
        }

        private void Initial()
        {
            dtpDateFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateDateTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
            GridViewInitial();
            BindGridData();
        }

        private void GridViewInitial()
        {
            grdMain.RowHeadersVisible = false;
            
            grdMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdMain.ReadOnly = true;
            grdMain.AllowUserToAddRows = false;
            grdMain.TabStop = false;
            grdMain.AllowUserToResizeRows = false;
            grdMain.Columns.Add("NO", "NO.");
            grdMain.Columns.Add("CREATE_DATETIME", "时间");
            grdMain.Columns.Add("TERMINAL_CD", "IP");
            grdMain.Columns.Add("Content", "日志内容");
            grdMain.Columns["NO"].Width = 30;
            grdMain.Columns["CREATE_DATETIME"].Width = 150;
            grdMain.Columns["TERMINAL_CD"].Width = 110;
            grdMain.Columns["Content"].Width = 461;
            grdMain.Columns["NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdMain.Columns["NO"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["CREATE_DATETIME"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["TERMINAL_CD"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["Content"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grdMain.Columns["NO"].Frozen = true;
            grdMain.Columns["CREATE_DATETIME"].Frozen = true;
            grdMain.Columns["TERMINAL_CD"].Frozen = true;
            grdMain.Height = 298;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Hide();
            Initial();
            GlobalVal.SplashObj.Dispose();
        }

        private void BindGridData()
        {
            grdMain.Rows.Clear();
            
            try
            {
                string strDateFrom = dtpDateFrom.Text.Trim().Replace("-", "").Replace("/","");
                string strDateTo = dateDateTo.Text.Trim().Replace("-", "").Replace("/", "");
                if (strDateFrom.Length > 0)
                {
                    strDateFrom += "000000";
                }
                if (strDateTo.Length > 0)
                {
                    strDateTo += "235959";
                }
                webService.ReturnValue resoult = GlobalVal.gloWebSerices.GetLogList(strDateFrom, strDateTo, "");
                if (resoult.ErrorFlag)
                {
                    for (int i = 0; i < resoult.ResultDataSet.Tables[0].Rows.Count; i++)
                    {
                        grdMain.Rows.Add((i + 1).ToString(),
                            FormatDate(resoult.ResultDataSet.Tables[0].Rows[i]["CREATE_DATETIME"].ToString()),
                            resoult.ResultDataSet.Tables[0].Rows[i]["TERMINAL_CD"].ToString().Trim(),
                            resoult.ResultDataSet.Tables[0].Rows[i]["Content"].ToString().Trim());
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
            if (grdMain.Rows.Count > 12)
            {
                grdMain.Columns["Content"].Width = 444;
            }
            else
            {
                grdMain.Columns["Content"].Width = 461;
            }
            this.Cursor = Cursors.Default;
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GlobalVal.ShowForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData();
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

        private void Search_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    GlobalVal.ShowForm.Hide();
            //    GlobalVal.SplashObj.Dispose();
            //}
        }

        private string FormatDate(string strDate)
        {
            string date = string.Empty;
            if (strDate.Trim().Length >= 14)
            {
                date = strDate.Substring(0, 4) + "-" + strDate.Substring(4, 2) + "-" + strDate.Substring(6, 2) + " " + strDate.Substring(8, 2) + ":" + strDate.Substring(10, 2) + ":" + strDate.Substring(12, 2);
            }
            return date;
        }
    }
}