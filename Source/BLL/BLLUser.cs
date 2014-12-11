using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COMM.Entity;
using XTHospital.ORM;
using System.Configuration;
using XTHospital.COM;

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
        /// <param name="Email"></param>
        /// <param name="PassWord"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool RegistMember(string Email, string PassWord, ref string Msg, ref int ID)
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
                    list[0].LoginPWD = COM.Method.EncryptPWD(PassWord);
                    list[0].UpdateTime = DateTime.Now;
                    list[0].CreatTime = DateTime.Now;
                    list[0].VerifictionCode = COM.Method.GenerateVerifictionCode();
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

                model.Email = Email;
                model.LoginPWD = COM.Method.EncryptPWD(PassWord);
                model.Status = 3;//刚注册未验证
                model.LoginTimes = 0;
                model.Integral = 0;
                model.UpdateTime = DateTime.Now;
                model.CreatTime = DateTime.Now;
                model.VerifictionCode = COM.Method.GenerateVerifictionCode();
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

        /// <summary>
        /// 会员激活
        /// </summary>
        /// <param name="MemberID"></param>
        /// <param name="VerifictionCode"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool ActivatMember(int MemberID, string VerifictionCode, ref string Msg)
        {
            IList<Member> list = OptionMember.GetAllMemberByID(MemberID);
            if (list.Count > 0)
            {
                if (list[0].VerifictionCodeLimit < DateTime.Now)
                {
                    Msg = "验证码有效期已过，请重新发送验证码";
                    return false;
                }
                else
                {
                    if (list[0].VerifictionCode.Trim().Equals(VerifictionCode.Trim()))
                    {
                        //修改用户状态为正常
                        list[0].Status = 0;
                        list[0].Integral = 100;
                        list[0].UpdateTime = DateTime.Now;
                        bool isSuccess = OptionMember.UpdateMember(list[0]);
                        //添加用户历史信息
                        if (isSuccess)
                        {
                            #region 会员历史信息
                            HistoryOfMemberUpdate modelHis = new HistoryOfMemberUpdate();
                            modelHis.CreatTime = DateTime.Now;
                            modelHis.MemberId = list[0].Id;
                            modelHis.OpenId = list[0].OpenId;
                            modelHis.Nickname = list[0].Nickname;
                            modelHis.Question1 = list[0].Question1;
                            modelHis.Question2 = list[0].Question2;
                            modelHis.Question3 = list[0].Question3;
                            modelHis.Anwser1 = list[0].Anwser1;
                            modelHis.Anwser2 = list[0].Anwser2;
                            modelHis.Anwser3 = list[0].Anwser3;
                            modelHis.Email = list[0].Email;
                            modelHis.Phone = list[0].Phone;
                            modelHis.LoginPWD = list[0].LoginPWD;
                            modelHis.Type = list[0].Type;
                            modelHis.Photo = list[0].Photo;
                            modelHis.PhotoURL = list[0].PhotoURL;
                            modelHis.Gender = list[0].Gender;
                            modelHis.Birthday = list[0].Birthday;
                            modelHis.Birthplace = list[0].Birthplace;
                            modelHis.Education = list[0].Education;
                            modelHis.Job = list[0].Job;
                            modelHis.Address = list[0].Address;
                            modelHis.LoginTimes = list[0].LoginTimes;
                            modelHis.LastLoginDateTime = list[0].LastLoginDateTime;
                            modelHis.CurrentLoginDateTime = list[0].CurrentLoginDateTime;
                            modelHis.Integral = list[0].Integral;
                            modelHis.Status = list[0].Status;
                            #endregion

                            if (OptionMember.SaveHistoryOfMemberUpdate(modelHis) == -1)
                            {
                                Msg = "保存会员历史信息发生错误";
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            Msg = "保存会员信息发生错误";
                            return false;
                        }
                    }
                    else
                    {
                        Msg = "验证码错误";
                        return false;
                    }
                }
            }
            else
            {
                Msg = "没有找到本会员信息";
                return false;
            }
        }

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool LoginMember(int ID, ref string Msg, ref Member model)
        {
            bool isSuccess = false;
            IList<Member> list = OptionMember.GetNormalMemberByID(ID);
            if (list.Count > 0)
            {
                list[0].LoginTimes += 1;
                //如果最后登录时间不是今天（也就是今天第一次登录）积分+10
                if (list[0].LastLoginDateTime.HasValue && list[0].LastLoginDateTime.Value.Date != DateTime.Now.Date && list[0].LastLoginDateTime < DateTime.Now)
                {
                    list[0].Integral += 10;
                }
                list[0].LastLoginDateTime = list[0].CurrentLoginDateTime;
                list[0].CurrentLoginDateTime = DateTime.Now;
                list[0].UpdateTime = DateTime.Now;
                model = list[0];
                return OptionMember.UpdateMember(list[0]);
            }
            else
            {
                Msg = "会员不存在";//会员不存在
                return false;
            }
        }

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="PWD"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool LoginMember(string LoginID, string PWD, ref string Msg, ref Member model)
        {
            bool isSuccess = false;
            IList<Member> list = OptionMember.GetNormalMemberByEmail(LoginID);
            if (list.Count > 0)
            {
                if (!list[0].LoginPWD.Trim().Equals(COM.Method.EncryptPWD(PWD)))
                {
                    Msg = "账号或密码错误";
                    return false;
                }

                list[0].LoginTimes += 1;
                //如果最后登录时间不是今天（也就是今天第一次登录）积分+10
                if (list[0].LastLoginDateTime.HasValue && list[0].LastLoginDateTime.Value.Date != DateTime.Now.Date && list[0].LastLoginDateTime < DateTime.Now)
                {
                    list[0].Integral += 10;
                }
                list[0].LastLoginDateTime = list[0].CurrentLoginDateTime;
                list[0].CurrentLoginDateTime = DateTime.Now;
                list[0].UpdateTime = DateTime.Now;
                model = list[0];
                return OptionMember.UpdateMember(list[0]);
            }
            else
            {
                Msg = "账号或密码错误";//账号不存在
                return false;
            }
        }

        /// <summary>
        /// 取得全部会员信息
        /// </summary>
        /// <returns></returns>
        public IList<Member> GetAllMembers()
        {
            return OptionMember.GetAllMembers();
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteMember(int ID)
        {
            return true;
        }

        /// <summary>
        /// 根据会员ID查询会员信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IList<Member> GetAllMemberByID(int ID)
        {
            return OptionMember.GetAllMemberByID(ID);
        }

        /// <summary>
        /// 根据会员Email查询会员信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IList<Member> GetAllMemberByEmail(string email)
        {
            return OptionMember.GetAllMemberByEmail(email);
        }

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="Member"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool LoginMember(Member modelMember, ref string Msg)
        {
            bool isSuccess = false;
            try
            {
                IList<Member> list = OptionMember.GetMemberByOpenID(modelMember.OpenId);
                if (list.Count > 0)
                {
                    list[0].LoginTimes += 1;
                    list[0].Nickname = modelMember.Nickname;
                    //如果最后登录时间不是今天（也就是今天第一次登录）积分+10
                    if (list[0].LastLoginDateTime.Value.Date != DateTime.Now.Date && list[0].LastLoginDateTime < DateTime.Now)
                    {
                        list[0].Integral += 10;
                    }
                    list[0].LastLoginDateTime = list[0].CurrentLoginDateTime;
                    list[0].CurrentLoginDateTime = DateTime.Now;
                    list[0].UpdateTime = DateTime.Now;
                    list[0].PhotoURL = modelMember.PhotoURL;
                    isSuccess = OptionMember.UpdateMember(list[0]);
                }
                else
                {
                    Member model = new Member();
                    HistoryOfMemberUpdate modelHis = new HistoryOfMemberUpdate();
                    model.OpenId = modelMember.OpenId;
                    model.Nickname = modelMember.Nickname;
                    model.LastLoginDateTime = DateTime.Now;
                    model.CurrentLoginDateTime = DateTime.Now;
                    model.LoginTimes = 1;
                    model.Integral = 100;
                    model.Status = 0;
                    model.UpdateTime = DateTime.Now;
                    model.CreatTime = DateTime.Now;
                    model.PhotoURL = modelMember.PhotoURL;
                    modelHis.MemberId = OptionMember.SaveMember(model);
                    if (modelHis.MemberId != -1)
                    {
                        modelHis.CreatTime = DateTime.Now;

                        #region 会员历史信息
                        modelHis.OpenId = model.OpenId;
                        modelHis.Nickname = model.Nickname;
                        modelHis.Question1 = model.Question1;
                        modelHis.Question2 = model.Question2;
                        modelHis.Question3 = model.Question3;
                        modelHis.Anwser1 = model.Anwser1;
                        modelHis.Anwser2 = model.Anwser2;
                        modelHis.Anwser3 = model.Anwser3;
                        modelHis.Email = model.Email;
                        modelHis.Phone = model.Phone;
                        modelHis.LoginPWD = model.LoginPWD;
                        modelHis.Type = model.Type;
                        modelHis.Photo = model.Photo;
                        modelHis.PhotoURL = model.PhotoURL;
                        modelHis.Gender = model.Gender;
                        modelHis.Birthday = model.Birthday;
                        modelHis.Birthplace = model.Birthplace;
                        modelHis.Education = model.Education;
                        modelHis.Job = model.Job;
                        modelHis.Address = model.Address;
                        modelHis.LoginTimes = model.LoginTimes;
                        modelHis.LastLoginDateTime = model.LastLoginDateTime;
                        modelHis.CurrentLoginDateTime = model.CurrentLoginDateTime;
                        modelHis.Integral = model.Integral;
                        modelHis.Status = model.Status;
                        #endregion

                        OptionMember.SaveHistoryOfMemberUpdate(modelHis);
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                isSuccess = false;
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="OponID"></param>
        /// <returns></returns>
        public IList<Member> GetMemberByOpenID(string OponID)
        {
            return OptionMember.GetMemberByOpenID(OponID);
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMember(Member model)
        {
            return OptionMember.UpdateMember(model);
        }

        /// <summary>
        /// 绑定新邮箱
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="PassWord"></param>
        /// <param name="ID"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool BindNewEmail(string Email, string PassWord, int ID, ref string Msg)
        {
            IList<Member> list = OptionMember.GetAllMemberByEmail(Email);
            if (list.Count > 0)
            {
                if (list[0].Status != 3)
                {
                    Msg = "邮箱已被注册";
                    return false;
                }
            }
            list = OptionMember.GetAllMemberByID(ID);
            if (list.Count > 0)
            {
                list[0].Email = Email;
                list[0].Status = 4;
                list[0].LoginPWD = XTHospital.COM.Method.EncryptPWD(PassWord);
                list[0].UpdateTime = DateTime.Now;
                list[0].VerifictionCode = XTHospital.COM.Method.GenerateVerifictionCode();
                int limitMinutes = 30;
                int.TryParse(ConfigurationManager.AppSettings["VerifictionCodeLimitMinutes"], out limitMinutes);
                list[0].VerifictionCodeLimit = DateTime.Now.AddMinutes(limitMinutes);
                Msg = String.Format("{0} [过期时间：{1:yyyy/MM/dd HH:mm:ss}]", list[0].VerifictionCode, list[0].VerifictionCodeLimit.Value);
                return OptionMember.UpdateMember(list[0]);
                //添加历史信息
            }
            else
            {
                Msg = "会员不存在";
                return false;
            }
        }

        /// <summary>
        /// 绑定旧邮箱
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="PassWord"></param>
        /// <param name="ID"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool BindOldEmail(string Email, string PassWord, int ID, ref string Msg,ref int NewID)
        {
            bool isSuccess = false;
            IList<Member> listEmail = OptionMember.GetNormalMemberByEmail(Email);
            if (listEmail.Count < 1)
            {
                Msg = "账号不存在";
                return false;
            }
            else
            {
                if (!listEmail[0].LoginPWD.Trim().Equals(XTHospital.COM.Method.EncryptPWD(PassWord)))
                {
                    Msg = "账号或密码错误";
                    return false;
                }
                if (!string.IsNullOrEmpty(listEmail[0].OpenId))
                {
                    Msg = "此账号已与QQ账号绑定";
                    return false;
                }
                IList<Member> listQQ = OptionMember.GetAllMemberByID(ID);
                if (listQQ.Count > 0)
                {
                    listEmail[0].OpenId = listQQ[0].OpenId;
                    listEmail[0].Nickname = listQQ[0].Nickname;
                    listEmail[0].UpdateTime = DateTime.Now;
                    isSuccess = OptionMember.UpdateMember(listEmail[0]);
                    Msg = listEmail[0].LoginTimes.ToString();
                    if (isSuccess)
                    {
                        NewID = listEmail[0].Id;
                        //删除listQQ记录
                        isSuccess = OptionMember.DeleteMember(listQQ[0]);
                        //删除listQQ历史记录
                        //添加listEmail历史记录
                        #region 会员历史信息
                        HistoryOfMemberUpdate modelHis = new HistoryOfMemberUpdate();
                        modelHis.CreatTime = DateTime.Now;
                        modelHis.MemberId = listEmail[0].Id;
                        modelHis.OpenId = listEmail[0].OpenId;
                        modelHis.Nickname = listEmail[0].Nickname;
                        modelHis.Question1 = listEmail[0].Question1;
                        modelHis.Question2 = listEmail[0].Question2;
                        modelHis.Question3 = listEmail[0].Question3;
                        modelHis.Anwser1 = listEmail[0].Anwser1;
                        modelHis.Anwser2 = listEmail[0].Anwser2;
                        modelHis.Anwser3 = listEmail[0].Anwser3;
                        modelHis.Email = listEmail[0].Email;
                        modelHis.Phone = listEmail[0].Phone;
                        modelHis.LoginPWD = listEmail[0].LoginPWD;
                        modelHis.Type = listEmail[0].Type;
                        modelHis.Photo = listEmail[0].Photo;
                        modelHis.PhotoURL = listEmail[0].PhotoURL;
                        modelHis.Gender = listEmail[0].Gender;
                        modelHis.Birthday = listEmail[0].Birthday;
                        modelHis.Birthplace = listEmail[0].Birthplace;
                        modelHis.Education = listEmail[0].Education;
                        modelHis.Job = listEmail[0].Job;
                        modelHis.Address = listEmail[0].Address;
                        modelHis.LoginTimes = listEmail[0].LoginTimes;
                        modelHis.LastLoginDateTime = listEmail[0].LastLoginDateTime;
                        modelHis.CurrentLoginDateTime = listEmail[0].CurrentLoginDateTime;
                        modelHis.Integral = listEmail[0].Integral;
                        modelHis.Status = listEmail[0].Status;
                        #endregion
                        if (OptionMember.SaveHistoryOfMemberUpdate(modelHis) == -1)
                        {
                            Msg = "保存会员历史信息发生错误";
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }
                    return isSuccess;
                }
                else
                {
                    Msg = "会员不存在";
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="OldPWD"></param>
        /// <param name="NewPWD"></param>
        /// <returns></returns>
        public bool ChangePassWord(int ID, string OldPWD, string NewPWD,ref string msg)
        {
            bool isSuccess = false;
            IList<Member> list = OptionMember.GetNormalMemberByID(ID);
            if (list.Count > 0)
            {
                if (!list[0].LoginPWD.Trim().Equals(COM.Method.EncryptPWD(OldPWD)))
                {
                    msg = "原始密码错误。";
                }
                list[0].LoginPWD = COM.Method.EncryptPWD(NewPWD);
                isSuccess = OptionMember.UpdateMember(list[0]);
                if (isSuccess)
                {
                    msg = "修改密码成功。";
                }
                else
                {
                    msg = "修改密码失败。";
                }
            }
            else
            {
                msg = "账号无效。";
            }
            return isSuccess;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NewPWD"></param>
        /// <returns></returns>
        public bool FindPassWord(string Email, ref string NewPWD)
        {
            bool isSuccess = false;
            IList<Member> list = OptionMember.GetNormalMemberByEmail(Email);
            if (list.Count > 0)
            {
                NewPWD = XTHospital.COM.Method.GenerateVerifictionCode().Substring(0, 6);
                list[0].LoginPWD = COM.Method.EncryptPWD(NewPWD);
                isSuccess = OptionMember.UpdateMember(list[0]);
                if (!isSuccess)
                {
                    NewPWD = "找回密码失败。";
                }
            }
            else
            {
                NewPWD = "输入的邮箱无效。";
            }
            return isSuccess;
        }
    }
}
