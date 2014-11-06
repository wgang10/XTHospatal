using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using XTHospital.IDAL;
using XTHospital.DB;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.OleDbDAL
{
    public class DAL_Biochemistry : IDAL_Biochemistry
    {
        private string SearchID_SQL = @"Select EmployeeID From Biochemistry
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert into Biochemistry(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,HYNo,HYDr,HYTC,HYTG,HYHDLC,HYTBIL,HYDBIL,HYTP,HYALB,HYALT,HYHBsAg,HYHBsAb,HYHBeAg,HYHBeAb,HYHBcAb,HY_GLU,HY_UREA,HY_CR,HY_AFP,HY_CEA,HYLDLC,HYAPOAI,HYAPOB,HYAST,HYGT,HYALP,HYUA)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@HYNo,@HYDr,@HYTC,@HYTG,@HYHDLC,@HYTBIL,@HYDBIL,@HYTP,@HYALB,@HYALT,@HYHBsAg,@HYHBsAb,@HYHBeAg,@HYHBeAb,@HYHBcAb,@HY_GLU,@HY_UREA,@HY_CR,@HY_AFP,@HY_CEA,@HYLDLC,@HYAPOAI,@HYAPOB,@HYAST,@HYGT,@HYALP,@HYUA)";
        private string Update_SQL = @"Update Biochemistry Set 
UPDATE_DATETIME=FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),
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
HY_CEA=@HY_CEA,
HYLDLC=@HYLDLC,
HYAPOAI=@HYAPOAI,
HYAPOB=@HYAPOB,
HYAST=@HYAST,
HYGT=@HYGT,
HYALP=@HYALP,
HYUA=@HYUA
where EmployeeID=@EmployeeID and YearMoth=@YearMonth ";

        private string GetAll_SQL = @"select * from Biochemistry";

        public ReturnValue Add(Biochemistry model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.LongVarWChar),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@HYNo", OleDbType.VarWChar,10),
					new OleDbParameter("@HYDr", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTC", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTG", OleDbType.VarWChar,50),
					new OleDbParameter("@HYHDLC", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTBIL", OleDbType.VarWChar,50),
					new OleDbParameter("@HYDBIL", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTP", OleDbType.VarWChar,50),
					new OleDbParameter("@HYALB", OleDbType.VarWChar,50),
					new OleDbParameter("@HYALT", OleDbType.VarWChar,50),
					new OleDbParameter("@HYHBsAg", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBsAb", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBeAg", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBeAb", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBcAb", OleDbType.VarWChar,1),
                    new OleDbParameter("@HY_GLU", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_UREA", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_CR", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_AFP", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_CEA", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYLDLC", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAPOAI", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAPOB", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAST", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYGT", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYALP", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYUA", OleDbType.VarWChar,50)};
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
            parameters[24].Value = model.HYLDLC;
            parameters[25].Value = model.HYAPOAI;
            parameters[26].Value = model.HYAPOB;
            parameters[27].Value = model.HYAST;
            parameters[28].Value = model.HYGT;
            parameters[29].Value = model.HYALP;
            parameters[30].Value = model.HYUA;
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Search(string EmployeeID, string YearMonth)
        {
            OleDbParameter[] parametersSearchID = { 
                new OleDbParameter("@EmployeeID", OleDbType.VarWChar, 18),
                new OleDbParameter("@YearMonth", OleDbType.VarWChar, 6)};
            parametersSearchID[0].Value = EmployeeID;
            parametersSearchID[1].Value = YearMonth;
            return OleDbHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Biochemistry model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@HYNo", OleDbType.VarWChar,10),
					new OleDbParameter("@HYDr", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTC", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTG", OleDbType.VarWChar,50),
					new OleDbParameter("@HYHDLC", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTBIL", OleDbType.VarWChar,50),
					new OleDbParameter("@HYDBIL", OleDbType.VarWChar,50),
					new OleDbParameter("@HYTP", OleDbType.VarWChar,50),
					new OleDbParameter("@HYALB", OleDbType.VarWChar,50),
					new OleDbParameter("@HYALT", OleDbType.VarWChar,50),
					new OleDbParameter("@HYHBsAg", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBsAb", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBeAg", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBeAb", OleDbType.VarWChar,1),
					new OleDbParameter("@HYHBcAb", OleDbType.VarWChar,1),
                    new OleDbParameter("@HY_GLU", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_UREA", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_CR", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_AFP", OleDbType.VarWChar,50),
					new OleDbParameter("@HY_CEA", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYLDLC", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAPOAI", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAPOB", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYAST", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYGT", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYALP", OleDbType.VarWChar,50),
                    new OleDbParameter("@HYUA", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.HYNo;
            parametersUpdate[3].Value = model.HYDr;
            parametersUpdate[4].Value = model.HYTC;
            parametersUpdate[5].Value = model.HYTG;
            parametersUpdate[6].Value = model.HYHDLC;
            parametersUpdate[7].Value = model.HYTBIL;
            parametersUpdate[8].Value = model.HYDBIL;
            parametersUpdate[9].Value = model.HYTP;
            parametersUpdate[10].Value = model.HYALB;
            parametersUpdate[11].Value = model.HYALT;
            parametersUpdate[12].Value = model.HYHBsAg;
            parametersUpdate[13].Value = model.HYHBsAb;
            parametersUpdate[14].Value = model.HYHBeAg;
            parametersUpdate[15].Value = model.HYHBeAb;
            parametersUpdate[16].Value = model.HYHBcAb;
            parametersUpdate[17].Value = model.HY_GLU;
            parametersUpdate[18].Value = model.HY_UREA;
            parametersUpdate[19].Value = model.HY_CR;
            parametersUpdate[20].Value = model.HY_AFP;
            parametersUpdate[21].Value = model.HY_CEA;
            parametersUpdate[22].Value = model.HYLDLC;
            parametersUpdate[23].Value = model.HYAPOAI;
            parametersUpdate[24].Value = model.HYAPOB;
            parametersUpdate[25].Value = model.HYAST;
            parametersUpdate[26].Value = model.HYGT;
            parametersUpdate[27].Value = model.HYALP;
            parametersUpdate[28].Value = model.HYUA;
            parametersUpdate[29].Value = model.EmployeeID;
            parametersUpdate[30].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }

        public ReturnValue GetAll()
        {
            return OleDbHelper.Query(GetAll_SQL);
        }
    }
}
