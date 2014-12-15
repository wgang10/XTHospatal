using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FromNews : Form
    {
        public FromNews()
        {
            InitializeComponent();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string NewsTitle
        {
            set
            {
                this.lbTitle.Text = value;
            }
        }

        public string NewsConnent
        {
            set {
                this.txtBody.Text = value;
            }
        }

        public string NewsUpdateTime
        {
            set
            {
                this.lbTime.Text = value;
            }
        }
    }
}
