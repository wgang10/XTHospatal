using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormStatistics : FormBase
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Close();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            GlobalVal.gloWebSerices.GetAllBiochemistryDataCompleted += new XTHotpatalWebServices.GetAllBiochemistryDataCompletedEventHandler(gloWebSerices_GetAllBiochemistryDataCompleted);
            GlobalVal.gloWebSerices.GetAllBiochemistryDataAsync();
            btnSearch.Enabled = false;
        }

        void gloWebSerices_GetAllBiochemistryDataCompleted(object sender, XTHotpatalWebServices.GetAllBiochemistryDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result == null)
                {
                    MessageBox.Show("没有数据或发生错误。");
                }
                else
                {
                    DataSet ds = DataSetZip.Decompress(e.Result);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            btnSearch.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            byte[] buffer = GlobalVal.gloWebSerices.GetAllBiochemistryData();
            if (buffer != null)
            {
                DataSet ds = DataSetZip.Decompress(buffer);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
