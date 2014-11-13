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
        private static FormSearch _formSearch;
        private static FormLogManage _formLogManage;
        private static FormUserManage _formUserManage;
        private static FormInfoEdite _formInfoEdite;
        private static FormDepartmentManage _formDepartmentManage;
        private static FormConfig _formConfig;
        private static FormEmployeeManage _empManage;
        private static FormEmployeeCheckNum _empCheckProject;
        private static FormStatistics _formStatistics;

        /// <summary>
        /// 加载图片url
        /// </summary>
        public static string gloPictureLoadingUrl = "";
        /// <summary>
        /// 登陆图片url
        /// </summary>
        public static string gloPictureLoginUrl = "";
        /// <summary>
        /// Top图片url
        /// </summary>
        public static string gloPictureTopUrl = "";
        /// <summary>
        /// 程序安装路径 默认为C:\XTHospatal
        /// </summary>
        public static string gloAappPath = @"C:\XTHospatal";
        /// <summary>
        /// 系统名称
        /// </summary>
        public static string gloSystemName = @"XTHospatal";
        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string gloStrLoginUserID { get; set; }

        /// <summary>
        /// 登录用户权限
        /// </summary>
        public static string gloStrLoginUserType = string.Empty;

        /// <summary>
        /// 登录计算机名
        /// </summary>
        public static string gloStrTerminalCD =string.Empty;

        /// <summary>
        /// 启动类型
        /// </summary>
        public static string gloLaunchType= string.Empty;

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
        public static string glostrServicesURL = "www.ziyangsoft.com";

        /// <summary>
        /// 程序号
        /// </summary>
        //public static string glostrAppNo = "";

        /// <summary>
        /// 
        /// </summary>
        public static webService.Service gloWebSerices = null;

        /// <summary>
        /// INI File Path
        /// </summary>
        public static string glostrIniFilePath = string.Empty;

        /// <summary>
        /// SplashForm Object
        /// </summary>
        public static SplashObject SplashObj;

        /// <summary>
        /// 当前统计员工编号
        /// </summary>
        public static string StatisticsEmployeeID = string.Empty;

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
        public static FormSearch FormSearch
        {
            get 
            {
                if (_formSearch == null)
                {
                    _formSearch = new FormSearch();
                }
                return _formSearch;
            }
        }

        /// <summary>
        /// 日志查询窗体
        /// </summary>
        public static FormLogManage FormLogManage
        {
            get
            {
                if (_formLogManage == null)
                {
                    _formLogManage = new FormLogManage();
                }
                return _formLogManage;
            }
        }

        /// <summary>
        /// 用户管理窗体
        /// </summary>
        public static FormUserManage FormUserManage
        {
            get
            {
                if (_formUserManage == null)
                {
                    _formUserManage = new FormUserManage();
                }
                return _formUserManage;
            }
        }

        /// <summary>
        /// 体检信息维护窗体
        /// </summary>
        public static FormInfoEdite FormInfoEdite
        {
            get
            {
                if (_formInfoEdite == null)
                {
                    _formInfoEdite = new FormInfoEdite();
                }
                return _formInfoEdite;
            }
        }

        /// <summary>
        /// 部门维护窗体
        /// </summary>
        public static FormDepartmentManage FormDepartmentManage
        {
            get
            {
                if (_formDepartmentManage == null)
                {
                    _formDepartmentManage = new FormDepartmentManage();
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
        public static FormEmployeeManage FormEmpManage
        {
            get {
                if (_empManage == null)
                {
                    _empManage = new FormEmployeeManage();
                }
                return _empManage;
            }
        }

        /// <summary>
        /// 体检项目
        /// </summary>
        public static FormEmployeeCheckNum FormCheckNum
        {
            get {
                if (_empCheckProject == null)
                {
                    _empCheckProject = new FormEmployeeCheckNum();
                }
                return _empCheckProject;
            }
        }

        /// <summary>
        /// 统计窗体
        /// </summary>
        public static FormStatistics Statistics
        {
            get
            {
                if (_formStatistics == null)
                {
                    _formStatistics = new FormStatistics();
                }
                return _formStatistics;
            }
        }
    }
}
