using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using wintrue;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace wintrue_xiaomi
{
    public partial class Login : WT_UI
    {
        public Login()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
        private void ChangeMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = message;
            });
        }
        public void LoginQQ(string username,string userPWD)
        {
            //if (txtQQ.Text.Trim() == "")
            //{
            //    MsgBox.Show("请输入小米登录账号！");
            //    return;
            //}
            //else if (txtPwd.Text.Trim() == "")
            //{
            //    MsgBox.Show("请输入密码！");
            //    return;
            //}
            this.Invoke((MethodInvoker)delegate
            {
                this.btnLogin.Enabled = false;
            });
            ChangeMessage("正在登录...");            
            
            string id = string.Empty;
            string nickname = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;
            string postData = "passToken=&user=" + username + "&pwd=" + userPWD + "&callback=https%3A%2F%2Faccount.xiaomi.com&sid=passport&qs=%253Fsid%253Dpassport&hidden=&_sign=KKkRvCpZoDC%2BgLdeyOsdMhwV0Xg%3D";
            HttpHelper.GetHtml("https://account.xiaomi.com/pass/serviceLogin");
            string result = HttpHelper.GetHtml("https://account.xiaomi.com/pass/serviceLoginAuth2", postData, true, HttpHelper.CookieContainer);
            //string result2 = HttpHelper.GetHtml("http://account.xiaomi.com/pass/userInfo?userId=8744426", HttpHelper.CookieContainer);
            if (result.Contains("<table class=\"mess\">"))
            {
                try
                {
                    Regex regexarticles = new Regex("<span class=\"right\">(\\d+) | <a href=\"/pass/logout?userId=", RegexOptions.Compiled);
                    Match m = regexarticles.Match(result);
                    id = m.Groups[1].ToString();
                    Regex regexarticles2 = new Regex("&nickname=(.{0,10})\">更改</a>", RegexOptions.Compiled);
                    Match m2 = regexarticles2.Match(result);
                    nickname = m2.Groups[1].ToString();
                    Regex regexarticles3 = new Regex("&type=EM&replace=true&address=(.{0,30})\">更改</a>", RegexOptions.Compiled);
                    Match m3 = regexarticles3.Match(result);
                    email = m3.Groups[1].ToString();
                    Regex regexarticles4 = new Regex("&type=PH&replace=true&address=(.{0,15})\">更改</a>", RegexOptions.Compiled);
                    Match m4 = regexarticles4.Match(result);
                    phone = m4.Groups[1].ToString();
                    //MsgBox.Show("登录成功！\r\n你的小米ID为：" + id 
                    //    + "，\r\n昵称为：" + nickname
                    //    + "，\r\n邮箱为：" + email
                    //    + "，\r\n手机为：" + phone);
                    //listUser.Add(new Account(username, userPWD, id, nickname, email, phone));
                    listBox1.Items.Add(username + "----" + userPWD + "----" + id + "----" + nickname + "----" + email + "----" + phone);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
            else
            {
                MsgBox.Show(username+"登录失败！");
                this.Invoke((MethodInvoker)delegate
                {
                    this.btnLogin.Enabled = true;
                });
            }



        }


        private void btnLogin_Click(object sender, EventArgs e)
        {         
            Thread thread = new Thread(new ThreadStart(LoginXiaoMi));
            thread.IsBackground = true;
            thread.Start();            
        }

        private void LoginXiaoMi()
        {
            Dictionary<string, string> user = new Dictionary<string, string>();
            user.Add("wgang10@foxmail.com", "jianmei@123");
            user.Add("wgang10@gmail.com", "jianmei@123");
            user.Add("115039554@qq.com", "jianmei@123");
            user.Add("1258070001@qq.com", "jianmei@123");

            foreach (string userid in user.Keys)
            {
                LoginQQ(userid, user[userid]);
            }
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            System.Environment.Exit(0);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe ab = new AboutMe();
            ab.ShowDialog();

        }




    }
}