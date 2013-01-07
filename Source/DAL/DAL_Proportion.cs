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
    public class DAL_Proportion : IDAL_Proportion
    {
        private string GetListCount_SQL = @"Select DrugsPrice,Proportional From Proportion where Type=@Type and DrugsCode=@DrugsCode and ProvinceCode=@ProvinceCode";

        private string Update_SQL = @"Update Proportion Set 
UPDATE_DATETIME=CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
DrugsPrice=@DrugsPrice,
Proportional=@Proportional
Where Type=@Type And DrugsCode=@DrugsCode And ProvinceCode=@ProvinceCode";

        private string Insert_SQL = @"Insert Into Proportion(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Type,DrugsCode,ProvinceCode,DrugsPrice,Proportional)
 values (CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@Type,@DrugsCode,@ProvinceCode,@DrugsPrice,@Proportional)";

        public ReturnValue GetListCount(string Type, string DrugsCode, string ProvinceCode)
        {
            SqlParameter[] parameters = {new SqlParameter("@Type", SqlDbType.NVarChar,1),
					new SqlParameter("@DrugsCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = Type;
            parameters[1].Value = DrugsCode;
            parameters[2].Value = ProvinceCode;
            return DB.SqlHelper.Query(GetListCount_SQL, parameters);
        }

        public ReturnValue Insert(Proportion model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Type", SqlDbType.NVarChar,1),
					new SqlParameter("@DrugsCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugsPrice", SqlDbType.Money,8),
					new SqlParameter("@Proportional", SqlDbType.Float,8)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.DrugsCode;
            parameters[4].Value = model.ProvinceCode;
            if (model.DrugsPrice == null)
            {
                parameters[5].Value = DBNull.Value;
            }
            else
            {
                parameters[5].Value = model.DrugsPrice;
            }
            if (model.Proportional == null)
            {
                parameters[6].Value = DBNull.Value;
            }
            else
            {
                parameters[6].Value = model.Proportional;
            }
            return SqlHelper.ExecuteSql(Insert_SQL, parameters);
        }

        public ReturnValue Update(Proportion model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Type", SqlDbType.NVarChar,1),
					new SqlParameter("@DrugsCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugsPrice", SqlDbType.Money,8),
					new SqlParameter("@Proportional", SqlDbType.Float,8)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.DrugsCode;
            parameters[4].Value = model.ProvinceCode;
            if (model.DrugsPrice == null)
            {
                parameters[5].Value = DBNull.Value;
            }
            else
            {
                parameters[5].Value = model.DrugsPrice;
            }
            if (model.Proportional == null)
            {
                parameters[6].Value = DBNull.Value;
            }
            else
            {
                parameters[6].Value = model.Proportional;
            }
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }
    }
}
