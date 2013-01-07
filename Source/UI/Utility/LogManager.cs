using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace UI
{
    public class LogManager
    {
        private static string strClsName = "UtilityLog";
        private static log4net.ILog logger = log4net.LogManager.GetLogger(strClsName);

        /// <summary>
        /// WriteClientErrLog4Net
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool WriteClientErrLog4Net(System.Exception ex)
        {
            try
            {
                logger.Error(ex.Message + ex.StackTrace);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// WriteClientInfoLog4Net
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool WriteClientInfoLog4Net(string strInfo)
        {
            try
            {
                logger.Info(strInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// WriteClientDebugLog4Net
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool WriteClientDebugLog4Net(string strDebug)
        {
            try
            {
                logger.Debug(strDebug);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// WriteClientWarnLog4Net
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool WriteClientWarnLog4Net(string strWarn)
        {
            try
            {
                logger.Warn(strWarn);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
