using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;
using XTHospital.COMM.Entity;

public partial class BindingToQQ : System.Web.UI.Page
{
    BLLUser bll;

    public BindingToQQ()
    {
        bll = new BLLUser();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["code"] != null)
        {
            #region 绑定QQ
            try
            {
                //参考地址 http://wiki.connect.qq.com/%E4%BD%BF%E7%94%A8authorization_code%E8%8E%B7%E5%8F%96access_token
                //Step1：获取Authorization Code
                //如果用户成功登录并授权，则会跳转到指定的回调地址，并在redirect_uri地址后带上Authorization Code和原始的state值
                string code = Request.QueryString["code"].ToString();
                string apppid = ConfigurationManager.AppSettings["appid"];
                string appkey = ConfigurationManager.AppSettings["appkey"];
                string callbackUrl = ConfigurationManager.AppSettings["callbackUrl"];
                string state = ConfigurationManager.AppSettings["state"];
                string Url = string.Format("https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id={0}&client_secret={1}&code={2}&redirect_uri={3}"
                    , apppid, appkey, code, callbackUrl);


                //Response.Redirect(Url);

                //Step2：通过Authorization Code获取Access Token
                WebRequest request = WebRequest.Create(Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                //lbMessage2.Text = responseFromServer;
                //如果成功返回，即可在返回包中获取到Access Token
                //access_token=FE04************************CCE2&expires_in=7776000&refresh_token=88E4************************BE
                /*
                 * access_token	授权令牌，Access_Token。
                 * expires_in	该access token的有效期，单位为秒。
                 * refresh_token	在授权自动续期步骤中，获取新的Access_Token时需要提供的参数。
                 */
                //access_token=AEE7091E761C2A571991234AD280E6BA&expires_in=7776000

                string access_token = responseFromServer.Substring(responseFromServer.IndexOf("=") + 1);
                access_token = access_token.Substring(0, access_token.IndexOf("&"));
                //Step3：使用Access Token来获取用户的OpenID
                Url = string.Format("https://graph.qq.com/oauth2.0/me?access_token={0}", access_token);
                request = WebRequest.Create(Url);
                response = (HttpWebResponse)request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                //lbMessage3.Text = responseFromServer;
                //获取到用户OpenID，返回包如下：
                //callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} );
                //callback( {"client_id":"100289171","openid":"1AC83BAA19BB2E892033E0C07C27AC24"} ); 
                responseFromServer = responseFromServer.Replace("callback(", "").Replace(" );", "");
                string openid = string.Empty;
                var opid = JsonConvert.DeserializeObject<ObjOpenID>(responseFromServer);
                if (opid != null)
                    openid = opid.openid;
                //openid = responseFromServer.Replace(@"\", "").Substring(responseFromServer.IndexOf("openid") + 9);
                //openid = openid.Substring(0, openid.IndexOf("}") - 1);
                //lbMessage4.Text = "openid=" + openid;

                //Step4：使用Access Token以及OpenID来访问和修改用户数据
                //以调用get_user_info接口为例：
                //发送请求到get_user_info的URL（请将access_token，appid等参数值替换为你自己的）：
                Url = string.Format("https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}", access_token, apppid, openid);
                request = WebRequest.Create(Url);
                response = (HttpWebResponse)request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                var Juser = JsonConvert.DeserializeObject<ObjUser>(responseFromServer);
                if (Juser != null)
                {
                    //lbMessage5.Text = responseFromServer;
                    //string[] UserInfo = responseFromServer.Split(',');
                    //lbMessage6.Text = "昵称：" + UserInfo[2].Substring(UserInfo[2].IndexOf(":") + 2, UserInfo[2].Length - UserInfo[3].IndexOf(":") - 2);
                    //Image1.ImageUrl = UserInfo[3].Substring(UserInfo[3].IndexOf("http"), UserInfo[3].Length - UserInfo[3].IndexOf("http") - 1);
                    //Image2.ImageUrl = UserInfo[4].Substring(UserInfo[4].IndexOf("http"), UserInfo[4].Length - UserInfo[4].IndexOf("http") - 1);
                    //Image3.ImageUrl = UserInfo[5].Substring(UserInfo[5].IndexOf("http"), UserInfo[5].Length - UserInfo[5].IndexOf("http") - 1);

                    //（2）成功返回后，即可获取到用户数据：
                    /*
                    {
                           "ret":0,
                           "msg":"",
                           "nickname":"YOUR_NICK_NAME",
                           ...
                    }
                    */




                    //更新用户QQ信息
                    //首先检查本QQ是否被其他账号绑定
                    //更新信息后返回会员信息页面
                    string msg = string.Empty;
                    Member modelMember = (Member)Session["MemberInfo"];
                    IList<Member> members = bll.GetMemberByOpenID(openid);
                    if (members.Count > 0)
                    {
                        lbLoginMessage.Text = "本QQ已经被其他账号绑定，请使用其他QQ进行绑定。";
                        XTHospital.COM.UtilityLog.WriteInfo(string.Format("用户 {0} 绑定QQ{1}失败，原因：已经被其他账号绑定", modelMember.Email, Juser.nickname));
                        lbLoginMessage.Visible = true;
                        Response.Redirect(string.Format("MemberInfo.aspx?msg=QQ[{0}]已经被其他账号绑定，请使用其他QQ进行绑定。", Juser.nickname), true);
                    }
                    else
                    {   
                        modelMember.OpenId = openid;
                        modelMember.Nickname = Juser.nickname;
                        modelMember.PhotoURL = Juser.figureurl;
                        //进行绑定
                        if (bll.UpdateMember(modelMember))
                        {
                            Session["MemberInfo"] = modelMember;
                            XTHospital.COM.UtilityLog.WriteInfo(string.Format("用户 {0} 绑定QQ{1}成功。", modelMember.Email, modelMember.Nickname));
                            Response.Redirect("MemberInfo.aspx", true);
                        }
                        else
                        {
                            lbLoginMessage.Text = "绑定QQ失败！";
                            XTHospital.COM.UtilityLog.WriteInfo(string.Format("用户 {0} 绑定QQ{1}失败，原因：内部错误。", modelMember.Email, modelMember.Nickname));
                            lbLoginMessage.Visible = true;
                            Response.Redirect(string.Format("MemberInfo.aspx?msg={0}", "绑定QQ失败！原因：内部错误."), true);
                        }
                        //绑定成功后返回会员信息页面
                    }
                }
            }
            catch (Exception ex)
            {
                XTHospital.COM.UtilityLog.WriteError(ex.Message);
                lbLoginMessage.Text = ex.Message;
                lbLoginMessage.Visible = true;
            }
            #endregion
        }
    }
    class ObjOpenID
    {
        public string client_id
        {
            set;
            get;
        }

        public string openid
        {
            set;
            get;
        }
    }

    class ObjUser
    {
        public string ret
        {
            set;
            get;
        }

        public string msg
        {
            set;
            get;
        }
        public string nickname
        {
            set;
            get;
        }
        public string gender
        {
            set;
            get;
        }
        public string figureurl
        {
            set;
            get;
        }
        public string figureurl_1
        {
            set;
            get;
        }
        public string figureurl_2
        {
            set;
            get;
        }
        public string figureurl_qq_1
        {
            set;
            get;
        }
        public string figureurl_qq_2
        {
            set;
            get;
        }
        public string is_yellow_vip
        {
            set;
            get;
        }
        public string vip
        {
            set;
            get;
        }
        public string yellow_vip_level
        {
            set;
            get;
        }
        public string level
        {
            set;
            get;
        }
        public string is_yellow_year_vip
        {
            set;
            get;
        }
    }
}