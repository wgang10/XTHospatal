using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormHelp : FormBase
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Close();
        }
    }
}
