using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormImage : Form
    {
        public FormImage()
        {
            InitializeComponent();
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
            picShow.Image = GlobalVal.Image;
        }

        private void picShow_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}