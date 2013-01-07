using System;
using System.Reflection;
using System.Configuration;
using XTHospital.IDAL;

namespace XTHospital.FDAL
{
    public sealed class Factory
    {
        private static readonly string strPath = System.Configuration.ConfigurationManager.AppSettings["DAL"];

        #region CreateObject With Cache

        /// <summary>
        /// CreateObject With Cache
        /// </summary>
        /// <param name="path"></param>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        //public static object CreateObject(string path, string CacheKey)
        //{
        //    object objType = DataCache.GetCache(CacheKey);
        //    if (objType == null)
        //    {
        //        try
        //        {
        //            objType = Assembly.Load(path).CreateInstance(CacheKey);
        //            DataCache.SetCache(CacheKey, objType);
        //        }
        //        catch
        //        { }
        //    }
        //    return objType;
        //}

        #endregion

        #region CreateObject No Cache

        /// <summary>
        /// CreateObject No Cache
        /// </summary>
        /// <param name="path"></param>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        private static object CreateObject(string strPath, string strCacheKey)
        {
            try
            {
                object objType = Assembly.Load(strPath).CreateInstance(strCacheKey);
                return objType;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Creat DAL_Bexamination
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Bexamination CreateBexamination()
        {
            string strCacheKey = strPath + ".DAL_Bexamination";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Bexamination)objType;
        }

        /// <summary>
        /// Creat DAl_Biochemistry
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Biochemistry CreateBiochemistry()
        {
            string strCacheKey = strPath + ".DAL_Biochemistry";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Biochemistry)objType;
        }

        /// <summary>
        /// Creat DAL_ECG
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_ECG CreateECG()
        {
            string strCacheKey = strPath + ".DAL_ECG";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_ECG)objType;
        }

        /// <summary>
        /// Creat DAL_Employee
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Employee CreateEmployee()
        {
            string strCacheKey = strPath + ".DAL_Employee";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Employee)objType;
        }

        /// <summary>
        /// Creat DAL_Features
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Features CreateFeatures()
        {
            string strCacheKey = strPath + ".DAL_Features";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Features)objType;
        }

        /// <summary>
        /// Creat DAL_Features
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_InternalMedicine CreateInternalMedicine()
        {
            string strCacheKey = strPath + ".DAL_InternalMedicine";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_InternalMedicine)objType;
        }

        /// <summary>
        /// Creat DAL_LoginUser
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_LoginUser CreateLoginUser()
        {
            string strCacheKey = strPath + ".DAL_LoginUser";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_LoginUser)objType;
        }

        /// <summary>
        /// Creat DAL_Report
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Report CreateReport()
        {
            string strCacheKey = strPath + ".DAL_Report";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Report)objType;
        }

        /// <summary>
        /// Creat DAL_Surgery
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Surgery CreateSurgery()
        {
            string strCacheKey = strPath + ".DAL_Surgery";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Surgery)objType;
        }

        /// <summary>
        /// Creat DAL_Xray
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Xray CreateXray()
        {
            string strCacheKey = strPath + ".DAL_Xray";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Xray)objType;
        }

        /// <summary>
        /// Creat DAL_Feme
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Feme CreateFeme()
        {
            string strCacheKey = strPath + ".DAL_Feme";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Feme)objType;
        }

        /// <summary>
        /// Creat DAL_Province
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Province CreateProvince()
        {
            string strCacheKey = strPath + ".DAL_Province";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Province)objType;
        }

        /// <summary>
        /// Creat DAL_YearMonth
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_YearMonth CreateYearMonth()
        {
            string strCacheKey = strPath + ".DAL_YearMonth";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_YearMonth)objType;
        }

        /// <summary>
        /// Creat DAL_MedicalItems
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_MedicalItems CreateMedicalItems()
        {
            string strCacheKey = strPath + ".DAL_MedicalItems";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_MedicalItems)objType;
        }

        /// <summary>
        /// Creat DAL_DrugClass
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_DrugClass CreateDrugClass()
        {
            string strCacheKey = strPath + ".DAL_DrugClass";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_DrugClass)objType;
        }

        /// <summary>
        /// Creat DAL_Drug
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Drug CreateDrug()
        {
            string strCacheKey = strPath + ".DAL_Drug";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Drug)objType;
        }

        /// <summary>
        /// Creat DAL_Composition
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Composition CreateComposition()
        {
            string strCacheKey = strPath + ".DAL_Composition";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Composition)objType;
        }

        /// <summary>
        /// Creat DAL_Proportion
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Proportion CreateProportion()
        {
            string strCacheKey = strPath + ".DAL_Proportion";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Proportion)objType;
        }

        /// <summary>
        /// Creat DAL_Log
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Log CreateLog()
        {
            string strCacheKey = strPath + ".DAL_Log";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Log)objType;
        }

        /// <summary>
        /// Creat DAL_Department
        /// </summary>
        /// <returns></returns>
        public static XTHospital.IDAL.IDAL_Department CreateDepartment()
        {
            string strCacheKey = strPath + ".DAL_Department";
            object objType = CreateObject(strPath, strCacheKey);
            return (IDAL_Department)objType;
        }
    }
}
