using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormConfig : FormBase
    {
        public FormConfig()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.FormShow.Show();
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
        }
    }
}
