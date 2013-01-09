using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

namespace UI
{
    public class Method
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder sbTemp, int size, string filePath);

        /// <summary>
        /// CheckIsNumber
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="intLength"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsNumber(string strValue, int intLength, bool blnAllowEmpty, bool blnShowMsg)
        {
            if (strValue.Length == 0)
            {
                if (blnAllowEmpty)
                {
                    return true;
                }
                else
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }
            if (!CheckIsHan(strValue))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11012";//Please enter a half-width characters！
                }
                return false;
            }
            if (!CheckIsOnlyNum(strValue))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11011";//Please enter a number!
                }
                return false;
            }
            if (strValue.Length > intLength)
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11006";//The length is input Wrong!
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取得年龄
        /// </summary>
        /// <param name="birthday">出生年月日</param>
        /// <returns></returns>
        public static int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = 0;
            if (birthday > now)
            {
                age = -1;
            }
            else
            {
                age = now.Year - birthday.Year - 1;
                if (now.Month > birthday.Month)
                {
                    age = age + 1;
                }
                else if (now.Month == birthday.Month)
                {
                    if (now.Day >= birthday.Day)
                    {
                        age = age + 1;
                    }
                }
            }
            return age;
        }

        /// <summary>
        /// CheckIsHanAll
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="intLength"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsHanAll(string strValue, bool blnAllowEmpty, bool blnShowMsg)
        {
            strValue = strValue.Trim();
            if (strValue.Length == 0)
            {
                if (blnAllowEmpty)
                {
                    return true;
                }
                else
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }
            if (!CheckIsHan(strValue))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11012";//Please enter a half-width characters！
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// CheckIsEmail
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsEmail(string strValue, bool blnAllowEmpty, bool blnShowMsg)
        {
            string strEmailNo = strValue;
            int intstrLength = strEmailNo.Length;
            int length = GetStrLength(strValue.Trim());
            if (intstrLength == 0)
            {
                if (!blnAllowEmpty)
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(strEmailNo, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11024";//Please enter a valid address E_Mail!
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// CheckIsTelNo
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="intLength"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsTelNo(string strValue, bool blnAllowEmpty, bool blnShowMsg)
        {
            int length = strValue.Length;
            string strtel = strValue;
            if (length == 0)
            {
                if (blnAllowEmpty)
                {
                    return true;
                }
                else
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }
            strtel = strtel.Replace("-", "");
            if (!CheckIsNumber(strtel, 13, blnAllowEmpty, true))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CheckIsAllInputType
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="intLength"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsAllInputType(string strValue, int intLength, bool blnAllowEmpty, bool blnShowMsg)
        {
            int length = GetStrLength(strValue.Trim());
            if (length == 0)
            {
                if (blnAllowEmpty)
                {
                    return true;
                }
                else
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }
            if (!IsErrChar(strValue))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11017";//There is an error in input!
                }
                return false;
            }
            if (length > intLength)
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11006";//The length is input Wrong!
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// CheckIsDate
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="blnAlloyEmpty"></param>
        /// <param name="blnShowMsg"></param>
        /// <returns></returns>
        public static bool CheckIsDate(string strDate, bool blnAlloyEmpty, bool blnShowMsg)
        {
            string strDate1 = string.Empty;
            string strDate2 = string.Empty;
            strDate1 = strDate.Replace("/", "").ToString().Trim();

            if (strDate1.Length == 0)
            {
                if (blnAlloyEmpty)
                {
                    return true;
                }
                else
                {
                    if (blnShowMsg)
                    {
                        GlobalVal.glostrMsg = "W11001";//Can't Empty.
                    }
                    return false;
                }
            }

            if (!CheckIsHan(strDate1))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11012";//Please enter a half-width characters！
                }
                return false;
            }

            if (strDate1.Length != 8)
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11006";//The length is input Wrong!
                }
                return false;

            }
            strDate2 = strDate1.Substring(0, 4) + "/" + strDate1.Substring(4, 2) + "/" + strDate1.Substring(6, 2);

            if (!IsDate(strDate2))
            {
                if (blnShowMsg)
                {
                    GlobalVal.glostrMsg = "W11027";//Please Enter the date!
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// IsErrChar
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static bool IsErrChar(string strVal)
        {
            if (strVal.IndexOfAny(GlobalVal.glostrInvalidChars.ToCharArray()) >= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// IsDate
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// GetStrLength
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static int GetStrLength(string strValue)
        {
            return Encoding.Default.GetByteCount(strValue);
        }

        /// <summary>
        /// CheckIsHan
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static bool CheckIsHan(string strVal)
        {
            if (Encoding.Default.GetByteCount(strVal) == strVal.Length)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// CheckIsOnlyNum
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool CheckIsOnlyNum(string strValue)
        {
            for (int i = 0; i < strValue.Length; i++)
            {
                if (!Char.IsNumber(strValue, i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool CheckIsIncludeSpecailChar(string strValue)
        {
            if (strValue == null || 0 == strValue.Trim().Length)
            {
                return true;
            }

            for (int i = 0; i < strValue.Length; i++)
            {
                if ('*' == strValue[i] || '/' == strValue[i]
                    || '?' == strValue[i] || '#' == strValue[i]
                    || '$' == strValue[i] || '%' == strValue[i]
                    || '&' == strValue[i] || '\"' == strValue[i]
                    || '\'' == strValue[i] || '<' == strValue[i]
                    || '>' == strValue[i] || '\\' == strValue[i]
                    || ',' == strValue[i] || ':' == strValue[i])
                {
                    GlobalVal.glostrMsg = "W11016";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string ToDBC(string strValue)
        {
            char[] chTemp = strValue.ToCharArray();
            for (int i = 0; i < chTemp.Length; i++)
            {
                if (chTemp[i] == 12288)
                {
                    chTemp[i] = (char)32;
                    continue;
                }
                if (chTemp[i] > 65280 && chTemp[i] < 65375)
                {
                    chTemp[i] = (char)(chTemp[i] - 65248);
                }
            }
            return new string(chTemp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMsgNo"></param>
        /// <param name="strReplace"></param>
        /// <returns></returns>
        public static DialogResult MessageShow(string strMsgNo, string strReplace)
        {
            string strMsgKind = "程序启动失败！错误号[999999]";
            string strMessage = string.Empty;
            string strMsgNoSp = string.Empty;
            string strTitle = GlobalVal.glostrMsgTitle;
            DialogResult DiaResult;
            if (strReplace.Trim().Length == 0)
            {
                strMessage = GetMsgInfo(strMsgNo);
            }
            else
            {
                strMessage = GetMsgInfo(strMsgNo, strReplace);
            }
            if (strMsgNo != "")
            {
                strMsgNoSp = strMsgNo.Substring(0, 1);
                switch (strMsgNoSp)
                {
                    //Information--OK  "I*****"
                    case "I":
                        DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    //Error--OK        "E****"
                    case "E":
                        DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    //Warning--OK      "W****"
                    case "W":
                        DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    //Question---YesNo "Q****" MessageBoxDefaultButton.Button1
                    case "Q":
                        string strDefoultBtn = GetDefaultButton(strMsgNo);
                        if (strDefoultBtn == "YES")
                        {
                            DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        }
                        else if (strDefoultBtn == "NO")
                        {
                            DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        }
                        else if (strDefoultBtn == "CANCEL")
                        {
                            DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        }
                        else
                        {
                            DiaResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        break;
                    default:
                        DiaResult = MessageBox.Show(strMsgKind, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                DiaResult = MessageBox.Show(strMsgKind, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return DiaResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMsgNo"></param>
        /// <returns></returns>
        public static DialogResult MessageShow(string strMsgNo)
        {
            return MessageShow(strMsgNo, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMsgNo"></param>
        /// <returns></returns>
        public static string GetDefaultButton(string strMsgNo)
        {
            string strMsgDefaultButton = strMsgNo.Substring(1, 1);
            string strDefaultButton = string.Empty;
            switch (strMsgDefaultButton)
            {
                case "1":
                    strDefaultButton = "YES";
                    break;
                case "2":
                    strDefaultButton = "NO";
                    break;
                case "3":
                    strDefaultButton = "CANCEL";
                    break;
                default:
                    break;
            }
            return strDefaultButton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMsgNo"></param>
        /// <param name="strReplace"></param>
        /// <returns></returns>
        public static string GetMsgInfo(string strMsgNo, string strReplace)
        {
            string strMsgInfo = string.Empty;
            //try
            //{
            //    //MessageType
            //    string strKey1 = strMsgNo.Substring(0, 1);
            //    //DefaultButton
            //    string strKey2 = strMsgNo.Substring(1, 1);
            //    //MessageID
            //    string strKey3 = strMsgNo.Substring(2, 4);
            //    string strSql = " MessageType= '" + strKey1 + "'  AND  DefaultButton='" + strKey2 + "' AND MessageID='" + strKey3 + "'";
            //    DataTable dtMsgResult = DataTableSelect(GlobalVal.gloDataTableMessage, strSql);
            //    if (dtMsgResult.Rows.Count > 0)
            //    {
            //        if (strKey1 == "E" || strKey1 == "W")
            //        {
            //            strMsgInfo = dtMsgResult.Rows[0]["Message"].ToString() + " Error Code[" + strMsgNo + "]";
            //        }
            //        else
            //        {
            //            strMsgInfo = dtMsgResult.Rows[0]["Message"].ToString();
            //        }
            //        if (strReplace == null || strReplace == string.Empty)
            //        {
            //        }
            //        else
            //        {
            //            strMsgInfo = strMsgInfo.Replace("@", strReplace);
            //        }
            //    }
            //    else
            //    {
            //        strMsgInfo = "Error Code Is Not Exist.Error Code[" + strMsgNo + "]";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogManager.WriteClientErrLog4Net(ex);
            //    return strMsgInfo;
            //}
            switch (strMsgNo)
            {
                case "E11001":
                    strMsgInfo = "数据库服务器链接错误！";
                    break;
                case "E11002":
                    strMsgInfo = "操作数据库时发生错误！";
                    break;
                case "Q22001":
                    strMsgInfo = "确定要退出吗?";
                    break;
                case "Q22007":
                    strMsgInfo = "确定要删除本数据吗?";
                    break;
                case "W11020":
                    strMsgInfo = "图像大小必须小于 2M";
                    break;
                case "W11023":
                    strMsgInfo = "所操作的数据不存在!";
                    break;
                case "W18888":
                    strMsgInfo = "程序已经运行!";
                    break;
                default:
                    strMsgInfo = "";
                    break;
            } 
            return strMsgInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMsgNo"></param>
        /// <returns></returns>
        public static string GetMsgInfo(string strMsgNo)
        {
            return GetMsgInfo(strMsgNo, "");
        }

        /// <summary>
        /// iniFile Read
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strKey"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public static string ReadFileContext(string strTitle, string strKey)
        {
            if (GlobalVal.glostrIniFilePath.Trim().Length < 1)
            {
                return string.Empty;
            }
            try
            {
                StringBuilder sbTemp = new StringBuilder(1024);
                int i = GetPrivateProfileString(strTitle, strKey, "", sbTemp, 1024, GlobalVal.glostrIniFilePath.Trim());
                return sbTemp.ToString().Trim();
            }
            catch (Exception ex)
            {
                LogManager.WriteClientErrLog4Net(ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMsgDataTable()
        {
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
             "Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resource\\;" +
             "Extended Properties=\"text;HDR=Yes;\"";
            //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            // "Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\;" +
            // "Extended Properties=\"text;HDR=Yes;\"";
            DataSet ExcelDs = new DataSet();
            try
            {
                OleDbDataAdapter ExcelDA = new OleDbDataAdapter("SELECT * FROM Message.csv", strCon);
                ExcelDA.Fill(ExcelDs, "Message");
            }
            catch (Exception ex)
            {
                LogManager.WriteClientErrLog4Net(ex);
                return new DataTable("Message");
            }
            return ExcelDs.Tables["Message"];

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtInput"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable DataTableSelect(DataTable dtInput, string strSql)
        {
            DataRow[] drfound;
            DataTable dtReturn = dtInput.Clone();
            drfound = dtInput.Select(strSql);
            foreach (DataRow drReturn in drfound)
            {
                dtReturn.ImportRow(drReturn);
            }
            return dtReturn;
        }

        /// <summary>
        /// TimeFormat
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string TimeFormat(string strDate)
        {
            string strNewTime = string.Empty;
            string strNewDate = string.Empty;
            string strTime = string.Empty;
            strDate = strDate.Trim();
            if (strDate == string.Empty || strDate == null)
            {
                return string.Empty;
            }
            if (strDate.Length < 8)
            {
                return strDate;
            }
            strNewDate = strDate.Substring(0, 4) + "/" + strDate.Substring(4, 2) + "/" + strDate.Substring(6, 2);
            if (strDate.Length < 9)
            {
                return strNewDate;
            }
            if (int.Parse(strDate.Substring(8, 1)) > 2)
            {
                strNewTime = "0" + strDate.Substring(8, 1) + ":" + strDate.Substring(9, 2) + ":" + strDate.Substring(11, 2);
            }
            else
            {
                strNewTime = strDate.Substring(8, 2) + ":" + strDate.Substring(10, 2) + ":" + strDate.Substring(12, 2);
            }
            strTime = strNewDate + " " + strNewTime;
            return strTime;
        }

        
        /// <summary>
        /// CmbDataBound
        /// </summary>
        /// <param name="strStysle"></param>
        /// <param name="cmbControl"></param>
        public static void CmbDataBound(string strStysle, System.Windows.Forms.ComboBox cmbControl)
        {
            switch (strStysle)
            {   
                case "YearMonth":
                    //cmbControl.Items.Clear();
                    cmbControl.DataSource = null;

                    XTHotpatalWebServices.ReturnValue resoult = GlobalVal.gloWebSerices.GetYearMonth();
                    if (resoult.ErrorFlag)
                    {
                        System.Data.DataTable tb = resoult.ResultDataSet.Tables[0];
                        //DataRow dr1 = tb.NewRow();
                        //dr1["SelectYearMonthValue"] = "";
                        //dr1["SelectYearMonth"] = "";
                        //tb.Rows.InsertAt(dr1, 0);
                        cmbControl.DataSource = tb;
                        cmbControl.DisplayMember = "SelectYearMonthValue";
                        cmbControl.ValueMember = "SelectYearMonth";
                    }
                    break;
                case "Department":
                    cmbControl.DataSource = null;                    
                    XTHotpatalWebServices.ReturnValue resoultDep = GlobalVal.gloWebSerices.GetDepartmentList();
                    if (resoultDep.ErrorFlag)
                    {
                        System.Data.DataTable tb = resoultDep.ResultDataSet.Tables[0];
                        DataRow dr1 = tb.NewRow();
                        dr1["ID"] = "";
                        dr1["Name"] = "";
                        tb.Rows.InsertAt(dr1, 0);
                        cmbControl.DataSource = tb;
                        cmbControl.DisplayMember = "Name";
                        cmbControl.ValueMember = "ID";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
