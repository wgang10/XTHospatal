using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XTHospitalUI
{
    public partial class FormConfig : FormBase
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
        }
    }
}
