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
    public class DAL_Biochemistry : IDAL_Biochemistry
    {
        private string SearchID_SQL = @"Select EmployeeID From Biochemistry
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert into Biochemistry(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,HYNo,HYDr,HYTC,HYTG,HYHDLC,HYTBIL,HYDBIL,HYTP,HYALB,HYALT,HYHBsAg,HYHBsAb,HYHBeAg,HYHBeAb,HYHBcAb,HY_GLU,HY_UREA,HY_CR,HY_AFP,HY_CEA)
Values (
'yyyyMMddhhmmss','yyyyMMddhhmmss','1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@HYNo,@HYDr,@HYTC,@HYTG,@HYHDLC,@HYTBIL,@HYDBIL,@HYTP,@HYALB,@HYALT,@HYHBsAg,@HYHBsAb,@HYHBeAg,@HYHBeAb,@HYHBcAb,@HY_GLU,@HY_UREA,@HY_CR,@HY_AFP,@HY_CEA)";
        private string Update_SQL = @"Update Biochemistry Set 
UPDATE_DATETIME='yyyyMMddhhmmss',
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
HYNo=@HYNo,
HYDr=@HYDr,
HYTC=@HYTC,
HYTG=@HYTG,
HYHDLC=@HYHDLC,
HYTBIL=@HYTBIL,
HYDBIL=@HYDBIL,
HYTP=@HYTP,
HYALB=@HYALB,
HYALT=@HYALT,
HYHBsAg=@HYHBsAg,
HYHBsAb=@HYHBsAb,
HYHBeAg=@HYHBeAg,
HYHBeAb=@HYHBeAb,
HYHBcAb=@HYHBcAb,
HY_GLU=@HY_GLU,
HY_UREA=@HY_UREA,
HY_CR=@HY_CR,
HY_AFP=@HY_AFP,
HY_CEA=@HY_CEA
where EmployeeID=@EmployeeID and YearMoth=@YearMonth ";

        private string GetAll_SQL = !"select * from Biochemistry";

        public ReturnValue Add(Biochemistry model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,256),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@HYNo", SqlDbType.NVarChar,10),
					new SqlParameter("@HYDr", SqlDbType.NVarChar,50),
					new SqlParameter("@HYTC", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTG", SqlDbType.NVarChar,10),
					new SqlParameter("@HYHDLC", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTBIL", SqlDbType.NVarChar,10),
					new SqlParameter("@HYDBIL", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTP", SqlDbType.NVarChar,10),
					new SqlParameter("@HYALB", SqlDbType.NVarChar,10),
					new SqlParameter("@HYALT", SqlDbType.NVarChar,10),
					new SqlParameter("@HYHBsAg", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBsAb", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBeAg", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBeAb", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBcAb", SqlDbType.NVarChar,1),
                    new SqlParameter("@HY_GLU", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_UREA", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_CR", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_AFP", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_CEA", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.HYNo;
            parameters[5].Value = model.HYDr;
            parameters[6].Value = model.HYTC;
            parameters[7].Value = model.HYTG;
            parameters[8].Value = model.HYHDLC;
            parameters[9].Value = model.HYTBIL;
            parameters[10].Value = model.HYDBIL;
            parameters[11].Value = model.HYTP;
            parameters[12].Value = model.HYALB;
            parameters[13].Value = model.HYALT;
            parameters[14].Value = model.HYHBsAg;
            parameters[15].Value = model.HYHBsAb;
            parameters[16].Value = model.HYHBeAg;
            parameters[17].Value = model.HYHBeAb;
            parameters[18].Value = model.HYHBcAb;
            parameters[19].Value = model.HY_GLU;
            parameters[20].Value = model.HY_UREA;
            parameters[21].Value = model.HY_CR;
            parameters[22].Value = model.HY_AFP;
            parameters[23].Value = model.HY_CEA;
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Search(string EmployeeID, string YearMonth)
        {
            SqlParameter[] parametersSearchID = { 
                new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 18),
                new SqlParameter("@YearMonth", SqlDbType.NVarChar, 6)};
            parametersSearchID[0].Value = EmployeeID;
            parametersSearchID[1].Value = YearMonth;
            return SqlHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Biochemistry model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@HYNo", SqlDbType.NVarChar,10),
					new SqlParameter("@HYDr", SqlDbType.NVarChar,50),
					new SqlParameter("@HYTC", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTG", SqlDbType.NVarChar,10),
					new SqlParameter("@HYHDLC", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTBIL", SqlDbType.NVarChar,10),
					new SqlParameter("@HYDBIL", SqlDbType.NVarChar,10),
					new SqlParameter("@HYTP", SqlDbType.NVarChar,10),
					new SqlParameter("@HYALB", SqlDbType.NVarChar,10),
					new SqlParameter("@HYALT", SqlDbType.NVarChar,10),
					new SqlParameter("@HYHBsAg", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBsAb", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBeAg", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBeAb", SqlDbType.NVarChar,1),
					new SqlParameter("@HYHBcAb", SqlDbType.NVarChar,1),
                    new SqlParameter("@HY_GLU", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_UREA", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_CR", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_AFP", SqlDbType.NVarChar,10),
					new SqlParameter("@HY_CEA", SqlDbType.NVarChar,10)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.HYNo;
            parametersUpdate[5].Value = model.HYDr;
            parametersUpdate[6].Value = model.HYTC;
            parametersUpdate[7].Value = model.HYTG;
            parametersUpdate[8].Value = model.HYHDLC;
            parametersUpdate[9].Value = model.HYTBIL;
            parametersUpdate[10].Value = model.HYDBIL;
            parametersUpdate[11].Value = model.HYTP;
            parametersUpdate[12].Value = model.HYALB;
            parametersUpdate[13].Value = model.HYALT;
            parametersUpdate[14].Value = model.HYHBsAg;
            parametersUpdate[15].Value = model.HYHBsAb;
            parametersUpdate[16].Value = model.HYHBeAg;
            parametersUpdate[17].Value = model.HYHBeAb;
            parametersUpdate[18].Value = model.HYHBcAb;
            parametersUpdate[19].Value = model.HY_GLU;
            parametersUpdate[20].Value = model.HY_UREA;
            parametersUpdate[21].Value = model.HY_CR;
            parametersUpdate[22].Value = model.HY_AFP;
            parametersUpdate[23].Value = model.HY_CEA;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }

        public ReturnValue GetAll()
        {
            return SqlHelper.Query(GetAll_SQL);
        }
    }
}
