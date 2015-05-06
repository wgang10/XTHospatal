using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using wintrue;

namespace wintrue_xiaomi
{
    public partial class AboutMe //: WT_UI
    {
        public AboutMe()
        {
            InitializeComponent();
        }
        int strIndex = 0;
        string str = "\r" + "无聊中。。。\r\r" + "弄了个登录https的类。。。\r\r" + "简单得不能再简单！\r\r" + "如大家有对软件更好的的建议，欢迎访问我的博客！http://www.wintrue.cn\r\r" + "\r" + "\r"+ "      软件版权所有，转载请注明出处！\r" + "\r" + "                       2013年8月1日";
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = str.Substring(0, strIndex);

            if (strIndex >= str.Length)
            {
                timer1.Stop();
            }
            strIndex++;
        }

        private void AboutMe_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}