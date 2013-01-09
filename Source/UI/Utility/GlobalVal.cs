using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    public static class GlobalVal
    {
        public static string EmployeeID = string.Empty;
        public static string EmployeeName = string.Empty;
        public static Form ShowForm;
        public static Form UserManageForm;
        public static Form SearchForm;
        private static Search _formSearch;
        private static LogManage _formLogManage;
        private static UserManage _formUserManage;
        private static InfoEdite _formInfoEdite;
        private static DepartmentManage _formDepartmentManage;
        private static FormConfig _formConfig;
        private static EmployeeManage _empManage;
        private static EmployeeCheckNum _empCheckProject;


        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string gloStrLoginUserID = string.Empty;

        /// <summary>
        /// 登录用户权限
        /// </summary>
        public static string gloStrLoginUserType = string.Empty;

        /// <summary>
        /// 登录计算机名
        /// </summary>
        public static string gloStrTerminalCD =string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public static Image gloImage = null;

        /// <summary>
        /// 操作数据的年月
        /// </summary>
        public static string gloYearMonth = string.Empty;

        /// <summary>
        /// Message Title
        /// </summary>
        public static string glostrMsgTitle = "系统消息";

        /// <summary>
        /// System Name
        /// </summary>
        public static string glostrSystemName = "西安体育学院教职工健康信息管理系统";

        /// <summary>
        /// 技术支持公司
        /// </summary>
        public static string glostrSupportCompanyName = "技术支持:子杨软件";

        /// <summary>
        /// 技术支持公司网址
        /// </summary>
        public static string glostrSupportCompanyURL = @"http://www.ziyangsoft.com";

        /// <summary>
        /// 版权所有
        /// </summary>
        public static string glostrCopyright = "版权所有©西安运动创伤医院";

        /// <summary>
        /// 服务器地址
        /// </summary>
        public static string glostrServicesURL = "";

        /// <summary>
        /// 
        /// </summary>
        public static XTHotpatalWebServices.Service gloWebSerices = null;

        /// <summary>
        /// INI File Path
        /// </summary>
        public static string glostrIniFilePath = string.Empty;

        /// <summary>
        /// SplashForm Object
        /// </summary>
        public static SplashObject SplashObj;

        /// <summary>
        /// Message DataSet
        /// </summary>
        public static DataTable gloDataTableMessage;

        public static string glostrMsg = string.Empty;

        public static string glostrInvalidChars = "\"\\,'";

        public static bool blCloseForm = false;

        /// <summary>
        /// 检索窗体
        /// </summary>
        public static Search FormSearch
        {
            get 
            {
                if (_formSearch == null)
                {
                    _formSearch = new Search();
                }
                return _formSearch;
            }
        }

        /// <summary>
        /// 日志查询窗体
        /// </summary>
        public static LogManage FormLogManage
        {
            get
            {
                if (_formLogManage == null)
                {
                    _formLogManage = new LogManage();
                }
                return _formLogManage;
            }
        }

        /// <summary>
        /// 用户管理窗体
        /// </summary>
        public static UserManage FormUserManage
        {
            get
            {
                if (_formUserManage == null)
                {
                    _formUserManage = new UserManage();
                }
                return _formUserManage;
            }
        }

        /// <summary>
        /// 体检信息维护窗体
        /// </summary>
        public static InfoEdite FormInfoEdite
        {
            get
            {
                if (_formInfoEdite == null)
                {
                    _formInfoEdite = new InfoEdite();
                }
                return _formInfoEdite;
            }
        }

        /// <summary>
        /// 部门维护窗体
        /// </summary>
        public static DepartmentManage FormDepartmentManage
        {
            get
            {
                if (_formDepartmentManage == null)
                {
                    _formDepartmentManage = new DepartmentManage();
                }
                return _formDepartmentManage;
            }
        }

        /// <summary>
        /// 配置维护窗体
        /// </summary>
        public static FormConfig FormConfig
        {
            get
            {
                if (_formConfig == null)
                {
                    _formConfig = new FormConfig();
                }
                return _formConfig;
            }
        }

        /// <summary>
        /// 教职员工管理
        /// </summary>
        public static EmployeeManage EmpManage
        {
            get {
                if (_empManage == null)
                {
                    _empManage = new EmployeeManage();
                }
                return _empManage;
            }
        }

        /// <summary>
        /// 体检项目
        /// </summary>
        public static EmployeeCheckNum EmpCheckProject
        {
            get {
                if (_empCheckProject == null)
                {
                    _empCheckProject = new EmployeeCheckNum();
                }
                return _empCheckProject;
            }
        }
    }
}
