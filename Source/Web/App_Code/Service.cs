using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using XTHospital.BLL;
using XTHospital.COM;
using XTHospital.Model;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CheckWebServices()
    {
        return "WanGang";
    }

    [WebMethod(Description = "测试Web Service")]
    public ReturnValue SearchYearMonth()
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.GetYearMonth();
    }

    [WebMethod(Description = "验证用户")]
    public string[] ValidateUser(string LoginUserID, string TerminalCD,string UserID, string userPWD,string YearMonth)
    {
        string Message = string.Empty;
        string[] ReturnValue = {"","",""};
        BLL_LoginUser bll = new BLL_LoginUser();
        ReturnValue resoult = bll.GetUserPwd(UserID);
        if (resoult.ErrorFlag)
        {
            if (resoult.Count < 1)
            {
                ReturnValue[0] = "0";
                ReturnValue[1] = "用户名或密码错误！";
                ReturnValue[2] = "";
                return ReturnValue;
            }
            else
            {
                if (userPWD == resoult.ResultDataSet.Tables[0].Rows[0]["UserPwd"].ToString())
                {
                    ReturnValue resoultYearMonth = bll.SetYearMonth(LoginUserID,TerminalCD,YearMonth);
                    if (!resoultYearMonth.ErrorFlag)
                    {
                        ReturnValue[0] = "0";
                        ReturnValue[1] = resoultYearMonth.ErrorID;
                        ReturnValue[2] = "";
                        return ReturnValue;
                    }
                    else
                    {
                        ReturnValue[0] = "1";
                        ReturnValue[1] = "";
                        ReturnValue[2] = resoult.ResultDataSet.Tables[0].Rows[0]["UserType"].ToString();
                        return ReturnValue;
                    }
                }
                else
                {
                    ReturnValue[0] = "0";
                    ReturnValue[1] = "用户名或密码错误！";
                    ReturnValue[2] = "";
                    return ReturnValue;
                }
            }
        }
        else
        {
            ReturnValue[0] = "0";
            ReturnValue[1] = resoult.ErrorID;
            ReturnValue[2] = "";
            return ReturnValue;
        }
    }

    [WebMethod(Description = "添加体检年月日")]
    public string[] SetYearMonth(string LoginUserID, string TerminalCD, string YearMonth)
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        string Message = string.Empty;
        string[] ReturnValue = { "", "", "" };
        ReturnValue resoultYearMonth = bll.SetYearMonth(LoginUserID, TerminalCD, YearMonth);
        if (!resoultYearMonth.ErrorFlag)
        {
            ReturnValue[0] = "0";
            ReturnValue[1] = resoultYearMonth.ErrorID;
            ReturnValue[2] = "";
            return ReturnValue;
        }
        else
        {
            ReturnValue[0] = "1";
            ReturnValue[1] = "";
            ReturnValue[2] = "";
            return ReturnValue;
        }
    }

    [WebMethod(Description = "验证用户")]
    public string[] ValidateUserNoYearMonth(string LoginUserID, string TerminalCD, string UserID, string userPWD)
    {
        string Message = string.Empty;
        string[] ReturnValue = { "", "", "" };
        BLL_LoginUser bll = new BLL_LoginUser();
        ReturnValue resoult = bll.GetUserPwd(UserID);
        if (resoult.ErrorFlag)
        {
            if (resoult.Count < 1)
            {
                ReturnValue[0] = "0";
                ReturnValue[1] = "用户名或密码错误！";
                ReturnValue[2] = "";
                return ReturnValue;
            }
            else
            {
                if (userPWD == resoult.ResultDataSet.Tables[0].Rows[0]["UserPwd"].ToString())
                {                    
                    ReturnValue[0] = "1";
                    ReturnValue[1] = "";
                    ReturnValue[2] = resoult.ResultDataSet.Tables[0].Rows[0]["UserType"].ToString();
                    return ReturnValue;
                }
                else
                {
                    ReturnValue[0] = "0";
                    ReturnValue[1] = "用户名或密码错误！";
                    ReturnValue[2] = "";
                    return ReturnValue;
                }
            }
        }
        else
        {
            ReturnValue[0] = "0";
            ReturnValue[1] = resoult.ErrorID;
            ReturnValue[2] = "";
            return ReturnValue;
        }
    }

    [WebMethod(Description = "用户一览")]
    public ReturnValue GetUserList()
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.GetList();
    }

    [WebMethod(Description = "添加用户")]
    public ReturnValue AddUser(LoginUser model)
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "删除用户")]
    public ReturnValue DeleteUser(string UserID)
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.Delete(UserID);
    }

    [WebMethod(Description = "获得已有年月")]
    public ReturnValue GetYearMonth()
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.GetYearMonth();
    }

    [WebMethod(Description="生化检验")]
    public ReturnValue AddUpdateBiochemistry(Biochemistry model)
    {
        BLL_Biochemistry bll = new BLL_Biochemistry();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "B超")]
    public ReturnValue AddUpdateBexamination(Bexamination model)
    {
        BLL_Bexamination bll = new BLL_Bexamination();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "心电图")]
    public ReturnValue AddUpdateECG(ECG model)
    {
        BLL_ECG bll = new BLL_ECG();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "员工添加")]
    public ReturnValue AddEmployee(Employee model)
    {
        BLL_Employee bll = new BLL_Employee();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "员工一览")]
    public ReturnValue GetListEmployee(string strWhere)
    {
        BLL_Employee bll = new BLL_Employee();
        return bll.GetList(strWhere);
    }

    [WebMethod(Description = "员工信息检索")]
    public ReturnValue SearchEmployeeAllInfo(string EmployeeID, string YearMoth)
    {
        BLL_Employee bll = new BLL_Employee();
        return bll.SearchAllInfo(EmployeeID, YearMoth);
    }
    
    [WebMethod(Description = "体格检查-五官")]
    public ReturnValue AddUpdateFeatures(Features model)
    {
        BLL_Features bll = new BLL_Features();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "体格检查-外科")]
    public ReturnValue AddUpdateSurgery(Surgery model)
    {
        BLL_Surgery bll = new BLL_Surgery();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "体格检查-内科")]
    public ReturnValue AddUpdateInternalMeicine(InternalMedicine model)
    {
        BLL_InternalMedicine bll = new BLL_InternalMedicine();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "X射线")]
    public ReturnValue AddUpdateXray(Xray model)
    {
        BLL_Xray bll = new BLL_Xray();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "体格检查")]
    public ReturnValue AddUpdateComposition(Composition model)
    {
        BLL_Composition bll = new BLL_Composition();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "妇科检查")]
    public ReturnValue AddUpdateFeme(Feme model)
    {
        BLL_Feme bll = new BLL_Feme();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "报告")]
    public ReturnValue AddUpdateReport(Report model)
    {
        BLL_Report bll = new BLL_Report();
        return bll.AddUpdate(model);
    }

    [WebMethod(Description = "写日志")]
    public void AddLog(string strContent, string strType, string strClint)
    {
        BLL_Log.AddLog(strContent, strType, strClint);
    }

    [WebMethod(Description = "取得日志")]
    public ReturnValue GetLogList(string DateFrom, string DateTo, string Type)
    {
        BLL_Log bll = new BLL_Log();
        return bll.GetListLog(DateFrom, DateTo, Type);
    }

    [WebMethod(Description = "添加修改部门")]
    public ReturnValue AddUpdateDepartment(Department model)
    {
        BLL_Department bll = new BLL_Department();
        return bll.AddUpdateDepartment(model);
    }

    [WebMethod(Description = "取得部门")]
    public ReturnValue GetDepartmentList()
    {
        BLL_Department bll = new BLL_Department();
        return bll.GetDepartmentList();
    }

    [WebMethod(Description = "删除部门")]
    public ReturnValue DeleteDepartment(string DepartmentID)
    {
        BLL_Department bll = new BLL_Department();
        return bll.DeleteDepartment(DepartmentID);
    }

    [WebMethod(Description = "按年统计体检人数")]
    public ReturnValue StatisticNums()
    {
        BLL_LoginUser bll = new BLL_LoginUser();
        return bll.StatisticNums();
    }

    [WebMethod(Description = "取得员工信息")]
    public ReturnValue GetEmployeeInfo(string EmployeeID)
    {
        BLL_Employee bll = new BLL_Employee();
        return bll.GetEmployeeInfo(EmployeeID);
    }

    [WebMethod(Description = "按年查询人员各项检查项是否已经有记录")]
    public ReturnValue GetCheckEmployeeNum(string YearMonth, string EmployeeName, string EmployeeBM)
    {
        BLL_Employee bll = new BLL_Employee();
        return bll.GetCheckEmployeeNum(YearMonth, EmployeeName, EmployeeBM);
    }
}
