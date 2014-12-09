using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COMM.Entity;
using XTHospital.ORM;
using System.Configuration;

namespace XTHospital.BLL
{
    public class BLLUser
    {
        /// <summary>
        /// 检查邮箱是否已注册
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool CheckEmail(string Email, ref string Msg)
        {
            IList<Member> list = OptionMember.GetAllMemberByEmail(Email);
            if (list.Count > 0)
            {
                if (list[0].Status != 3)
                {
                    Msg = "邮箱已注册，请直接登录";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="Nickname"></param>
        /// <param name="Email"></param>
        /// <param name="PassWord"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool RegistMember(string Nickname, string Email, string PassWord, ref string Msg, ref int ID)
        {
            IList<Member> list = OptionMember.GetAllMemberByEmail(Email);
            if (list.Count > 0)
            {
                if (list[0].Status != 3)
                {
                    Msg = "邮箱已注册，请直接登录";
                    ID = list[0].Id;
                    return false;
                }
                else
                {
                    list[0].Nickname = Nickname;
                    list[0].LoginPWD = COM.Mothod.EncryptPWD(PassWord);
                    list[0].UpdateTime = DateTime.Now;
                    list[0].CreatTime = DateTime.Now;
                    list[0].VerifictionCode = COM.Mothod.GenerateVerifictionCode();
                    int limitMinutes = 30;
                    int.TryParse(ConfigurationManager.AppSettings["VerifictionCodeLimitMinutes"], out limitMinutes);
                    list[0].VerifictionCodeLimit = DateTime.Now.AddMinutes(limitMinutes);
                    Msg = String.Format("{0} [过期时间：{1:yyyy/MM/dd HH:mm:ss}]", list[0].VerifictionCode, list[0].VerifictionCodeLimit.Value);
                    ID = list[0].Id;
                    return OptionMember.UpdateMember(list[0]);
                }
            }
            else
            {
                Member model = new Member();

                model.Nickname = Nickname;
                model.Email = Email;
                model.LoginPWD = COM.Mothod.EncryptPWD(PassWord);
                model.Status = 3;//刚注册未验证
                model.LoginTimes = 0;
                model.Integral = 0;
                model.UpdateTime = DateTime.Now;
                model.CreatTime = DateTime.Now;
                model.VerifictionCode = COM.Mothod.GenerateVerifictionCode();
                int limitMinutes = 30;
                int.TryParse(ConfigurationManager.AppSettings["VerifictionCodeLimitMinutes"], out limitMinutes);
                model.VerifictionCodeLimit = DateTime.Now.AddMinutes(limitMinutes);
                model.Id =OptionMember.SaveMember(model);
                if (model.Id == -1)
                {
                    Msg = "注册失败！";
                    return false;
                }
                else
                {
                    Msg = String.Format("{0} [过期时间:{1:yyyy/MM/dd HH:mm:ss}]", model.VerifictionCode, model.VerifictionCodeLimit.Value);
                    ID = model.Id;
                    return true;
                }
            }
        }
    }
}
