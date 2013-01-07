using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XTHospital.IDAL;
using XTHospital.DB;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.DAL
{
    public class DAL_Drug : IDAL_Drug
    {
        private string GetList_SQL = @"Select * From(Select
ROW_NUMBER() OVER(ORDER BY Code) AS ROWNO,
((Case Drug.Type2 When '0' Then '西药' When '1' Then '中药' Else '' End)+'-'+(Case Drug.Type1 When '0' Then '甲类' When '1' Then '乙类' Else '' End)) As TypeName,
Drug.Type2,Drug.Code,Drug.ChinaName,Drug.EnglishName,Drug.Formulation,Drug.Notes,Pro.DrugsPrice,Pro.Proportional
FROM Drug Left Join Proportion Pro
	On Pro.Type = Drug.Type2  And Pro.DrugsCode =Drug.Code And Pro.ProvinceCode = @ProvinceCode
Where 1=1 @@@) TB ";

        private string GetListCount_SQL = @"Select Code FROM Drug where 1=1 @@@ ";

        private string Search_SQL = @"Select Code,ChinaName,Type2 From Drug Where Type2 = @Type2 And Code = @Code ";

        private string GetDrugInfo_SQL = @"Select DrugClassCode,
DrugClass.Name As DrugClassName,
(Case Type2 When '0' Then '西药' When '1' Then '中药' Else '' End) As Type2Name,
(Case Type1 When '0' Then '甲类' When '1' Then '乙类' Else '' End) As Type1Name,
Type2,Type1,Drug.Code,Drug.ChinaName,Drug.EnglishName,Formulation,Notes,
Pro.DrugsPrice,Pro.Proportional
FROM Drug Left Join Proportion Pro
	On Pro.Type = Drug.Type2 And Pro.DrugsCode = Drug.Code And Pro.ProvinceCode = @ProvinceCode 
Left Join DrugClass On DrugClass.Code = Drug.DrugClassCode
Where Drug.Code = @Code And Drug.Type2 = @Type";

        #region IDAL_Drug 成员

        public ReturnValue GetList(int intStart, int intEnd,Drug model)
        {
            string strPageWhere = " Where TB.ROWNO >= @PageStart and TB.ROWNO<=@PageEnd ";
            string strWhere = string.Empty;
            SqlParameter[] parameters = {new SqlParameter("@PageStart", SqlDbType.Int),
                new SqlParameter("@PageEnd", SqlDbType.Int),
                new SqlParameter("@ProvinceCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = intStart;
            parameters[1].Value = intEnd;
            parameters[2].Value = model.ProvinceCode;

            if (model.ChinaName.Length > 0)//药品名称
            {
                strWhere += " And Drug.ChinaName Like '%" + model.ChinaName + "%' ";
            }
            if (model.Type2.Trim() != "999")//中西分类
            {
                strWhere += " And Drug.Type2 = '" + model.Type2 + "' ";
            }
            if (model.DrugClassCode.Trim() != "999")//药品分类
            {
                strWhere += " And Drug.type2 + right('0'+replace(Convert(Varchar(2),DrugClassCode),'.',''),2)  = '" + model.DrugClassCode + "' ";
            }
            return SqlHelper.Query(GetList_SQL.Replace("@@@", strWhere) + strPageWhere, parameters);
        }

        public ReturnValue GetList(string strWhere)
        {
            return SqlHelper.Query(GetList_SQL.Replace("@@@", strWhere));
        }

        public ReturnValue GetListCount(Drug model)
        {
            string strWhere = string.Empty;
            if (model.ChinaName.Length > 0)//药品名称
            {
                strWhere += " And ChinaName Like '%"+model.ChinaName+"%' ";
            }
            if (model.Type2.Trim() != "999")//中西分类
            {
                strWhere += " And Type2 = '" + model.Type2 + "' ";
            }
            if (model.DrugClassCode.Trim() != "999")//药品分类
            {
                strWhere += " And type2 + right('0'+replace(Convert(Varchar(2),DrugClassCode),'.',''),2) = '" + model.DrugClassCode + "' ";
            }
            return SqlHelper.Query(GetListCount_SQL.Replace("@@@",strWhere));
        }

        public ReturnValue Search(string Type2,string DrugCode)
        {
            SqlParameter[] parameters = { 
                new SqlParameter("@Type2", SqlDbType.NVarChar, 1),
                new SqlParameter("@Code", SqlDbType.NVarChar, 50)};
            parameters[0].Value = Type2;
            parameters[1].Value = DrugCode;
            return SqlHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetDrugInfo(string ProvinceCode, string Code, string Type)
        {
            SqlParameter[] parameters = {new SqlParameter("@ProvinceCode", SqlDbType.NVarChar,50),
                new SqlParameter("@Code", SqlDbType.NVarChar,50),
                new SqlParameter("@Type", SqlDbType.NVarChar,1)};
            parameters[0].Value = ProvinceCode;
            parameters[1].Value = Code;
            parameters[2].Value = Type;
            return SqlHelper.Query(GetDrugInfo_SQL,parameters);
        }

        #endregion
    }
}
