using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Net.Mail;

namespace XTHospital.COM
{
    public class Mothod
    {
        public static bool CheckYearMonth(string YearMonth)
        {
            bool blFlag = false;
            int intYear = 0;
            int intMonth = 0;
            if (YearMonth.Trim().Length == 6)
            {
                try
                {
                    intYear = Int32.Parse(YearMonth.Substring(0, 4));
                    intMonth = Int32.Parse(YearMonth.Substring(4, 2));
                    if (1900 <= intYear && intYear <= 2100 && 1 <= intMonth && intMonth <= 12)
                    {
                        blFlag = true;
                    }
                }
                catch
                {
                }
            }
            return blFlag;
        }

        public static string GetClintInfo()
        {
            string strClintInfo = string.Empty;
            //strClintInfo += "IP:" + Page.Request.UserHostAddress;
            return strClintInfo;
        }

        public static bool SendMail(string strMailTo,string strTitle,string strMailBody,out string strMessage)
        {
            strMessage="";
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
            objMailMessage.From = new MailAddress("wgang10@foxmail.com");
            objMailMessage.To.Add(new MailAddress(strMailTo));
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMailMessage.Subject = strTitle;
            objMailMessage.Body = strMailBody;
            objMailMessage.IsBodyHtml = false;
            SmtpClient objSmtpClient = new SmtpClient();
            objSmtpClient.Host = "smtp.qq.com";
            objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSmtpClient.Credentials = new System.Net.NetworkCredential("wgang10@foxmail.com", "wangang10");
            //objSmtpClient.EnableSsl = true;//SMTP 服务器要求安全连接需要设置此属性
            try
            {
                objSmtpClient.Send(objMailMessage);
                strMessage = "邮件发送成功！";
                return true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
                return false;
            }
        }
    }
}
