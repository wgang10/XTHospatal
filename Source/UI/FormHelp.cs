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
            this.richTextBox1.Text = @"1、创建部门
2、创建教职工，教职工隶属于某一个部门。
3、创建用户，用户可对数据进行录入及维护。
4、体检信息维护是双击某一个教职工后可打开信息编辑界面。注意当前所编辑体检信息的体检时间。
5、项目检查状况可查看某次体检都录入了哪些项目，方便没有录入的项目继续录入。
6、系统设置可对系统的一些配置进行维护。
7、参数设置主要对一些体检参数进行维护，如生化指标。
8、日志查看，可查看用户登录、查询、维护等等信息。
9、信息统计，可对个人数据及全体大数据做出想要的统计结果。";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.FormShow.Show();
            this.Close();
        }
    }
}
