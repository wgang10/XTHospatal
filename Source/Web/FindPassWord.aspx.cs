using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindPassWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strUserID = txtLoginID.Text.Trim();
        string strMail = txtMail.Text.Trim();
        XTHospital.BLL.BLL_LoginUser bll = new XTHospital.BLL.BLL_LoginUser();
        XTHospital.COM.ReturnValue resoult = bll.GetEmployeePWD(strUserID);
        if (resoult.ErrorFlag)
        {
            if (resoult.Count < 1)
            {
                GlobalValue.GloWebSerices.AddLog("用户[" + strUserID + "]尝试找回密码失败，用户名不存在！", "1", Page.Request.UserHostAddress);//添加日志
                LiteralMsg.Text = "用户名不存在！";
                LiteralMsg.DataBind();
                return;
            }
            else
            {
                if (strMail == resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString())
                {
                    bool blFlag = false;
                    string strPassWord = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePWD"].ToString();
                    string strUserName = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
                    string strMessage=string.Empty;
                    string strTitle="健康查询系统密码";
                    string strMailTo=resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString().Trim();
                    string strMailBody = @"尊敬的阁下：
	您好！很高兴您能收到这封邮件。
	
	您最近忘记密码了吗?以后要牢记哦。
    
	您的账号为：" + strUserID + "   密码：" + strPassWord;
                    strMailBody += @"

致
	敬


    尚美思计算机科技有限公司

    本邮件为系统自动发送，请勿回复。";
                    blFlag = XTHospital.COM.Mothod.SendMail(strMailTo, strTitle, strMailBody, out strMessage);
                    if (blFlag)
                    {
                        GlobalValue.GloWebSerices.AddLog("用户[" + strUserName + "]使用了找回密码功能，将密码发送到了邮箱[" + strMailTo + "].", "1", Page.Request.UserHostAddress);//添加日志
                        LiteralMsg.Text = "密码已经发送到了您的邮箱！请查收";
                        LiteralMsg.DataBind();
                        return;
                    }
                    else
                    {
                        GlobalValue.GloWebSerices.AddLog("用户[" + strUserName + "]使用了找回密码功能，发送到邮箱[" + strMailTo + "]时失败." + strMessage, "1", Page.Request.UserHostAddress);//添加日志
                        LiteralMsg.Text = "发送到邮箱[" + strMailTo + "]时失败.";
                        LiteralMsg.DataBind();
                        return;
                    }
                }
                else
                {
                    GlobalValue.GloWebSerices.AddLog("用户[" + strUserID + "]尝试找回密码失败，所填邮箱不存在或不是其绑定的邮箱！", "1", Page.Request.UserHostAddress);//添加日志
                    LiteralMsg.Text = "输入的邮箱不存在或不是您当时绑定的邮箱！";
                    LiteralMsg.DataBind();
                    return;
                }
            }
        }
        else
        {
            LiteralMsg.Text = resoult.ErrorID;
            LiteralMsg.DataBind();
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
