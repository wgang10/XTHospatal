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
    public class DAL_Feme : IDAL_Feme
    {
        private string SearchID_SQL = @"Select EmployeeID From Feme
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Feme(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,Menarche,MenopauseAge,MenstrualCycle,MenstrualVolume,Dysmenorrhea,DiseaseHistory,FamilyTumorTistory,DiseaseHistoryOther,AndrogenUsed,EstrogenUsed,Cervical,Uterine,Genital,Leucorrhea,Vaginal,AnnexLeft,AnnexRight,CheckCases,InfraredScanBreast,Conclusion,Physicians)
values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMoth,@Menarche,@MenopauseAge,@MenstrualCycle,@MenstrualVolume,@Dysmenorrhea,@DiseaseHistory,@FamilyTumorTistory,@DiseaseHistoryOther,@AndrogenUsed,@EstrogenUsed,@Cervical,@Uterine,@Genital,@Leucorrhea,@Vaginal,@AnnexLeft,@AnnexRight,@CheckCases,@InfraredScanBreast,@Conclusion,@Physicians)";
        private string Update_SQL = @"Update Feme Set 
UPDATE_DATETIME=CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
Menarche=@Menarche,
MenopauseAge=@MenopauseAge,
MenstrualCycle=@MenstrualCycle,
MenstrualVolume=@MenstrualVolume,
Dysmenorrhea=@Dysmenorrhea,
DiseaseHistory=@DiseaseHistory,
FamilyTumorTistory=@FamilyTumorTistory,
DiseaseHistoryOther=@DiseaseHistoryOther,
AndrogenUsed=@AndrogenUsed,
EstrogenUsed=@EstrogenUsed,
Cervical=@Cervical,
Uterine=@Uterine,
Genital=@Genital,
Leucorrhea=@Leucorrhea,
Vaginal=@Vaginal,
AnnexLeft=@AnnexLeft,
AnnexRight=@AnnexRight,
CheckCases=@CheckCases,
InfraredScanBreast=@InfraredScanBreast,
Conclusion=@Conclusion,
Physicians=@Physicians
Where EmployeeID=@EmployeeID and YearMoth=@YearMoth";

        public ReturnValue Add(Feme model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMoth", SqlDbType.NVarChar,6),
					new SqlParameter("@Menarche", SqlDbType.NVarChar,3),
					new SqlParameter("@MenopauseAge", SqlDbType.NVarChar,3),
					new SqlParameter("@MenstrualCycle", SqlDbType.NVarChar,1),
					new SqlParameter("@MenstrualVolume", SqlDbType.NVarChar,1),
					new SqlParameter("@Dysmenorrhea", SqlDbType.NVarChar,1),
					new SqlParameter("@DiseaseHistory", SqlDbType.NVarChar,50),
					new SqlParameter("@FamilyTumorTistory", SqlDbType.NVarChar,1),
					new SqlParameter("@DiseaseHistoryOther", SqlDbType.NVarChar,255),
					new SqlParameter("@AndrogenUsed", SqlDbType.NVarChar,1),
					new SqlParameter("@EstrogenUsed", SqlDbType.NVarChar,1),
					new SqlParameter("@Cervical", SqlDbType.NVarChar,255),
					new SqlParameter("@Uterine", SqlDbType.NVarChar,255),
					new SqlParameter("@Genital", SqlDbType.NVarChar,255),
					new SqlParameter("@Leucorrhea", SqlDbType.NVarChar,255),
					new SqlParameter("@Vaginal", SqlDbType.NVarChar,255),
					new SqlParameter("@AnnexLeft", SqlDbType.NVarChar,255),
					new SqlParameter("@AnnexRight", SqlDbType.NVarChar,255),
					new SqlParameter("@CheckCases", SqlDbType.NVarChar,255),
					new SqlParameter("@InfraredScanBreast", SqlDbType.NVarChar,255),
					new SqlParameter("@Conclusion", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.Menarche;
            parameters[5].Value = model.MenopauseAge;
            parameters[6].Value = model.MenstrualCycle;
            parameters[7].Value = model.MenstrualVolume;
            parameters[8].Value = model.Dysmenorrhea;
            parameters[9].Value = model.DiseaseHistory;
            parameters[10].Value = model.FamilyTumorTistory;
            parameters[11].Value = model.DiseaseHistoryOther;
            parameters[12].Value = model.AndrogenUsed;
            parameters[13].Value = model.EstrogenUsed;
            parameters[14].Value = model.Cervical;
            parameters[15].Value = model.Uterine;
            parameters[16].Value = model.Genital;
            parameters[17].Value = model.Leucorrhea;
            parameters[18].Value = model.Vaginal;
            parameters[19].Value = model.AnnexLeft;
            parameters[20].Value = model.AnnexRight;
            parameters[21].Value = model.CheckCases;
            parameters[22].Value = model.InfraredScanBreast;
            parameters[23].Value = model.Conclusion;
            parameters[24].Value = model.Physicians;
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

        public ReturnValue Update(Feme model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMoth", SqlDbType.NVarChar,6),
					new SqlParameter("@Menarche", SqlDbType.NVarChar,3),
					new SqlParameter("@MenopauseAge", SqlDbType.NVarChar,3),
					new SqlParameter("@MenstrualCycle", SqlDbType.NVarChar,1),
					new SqlParameter("@MenstrualVolume", SqlDbType.NVarChar,1),
					new SqlParameter("@Dysmenorrhea", SqlDbType.NVarChar,1),
					new SqlParameter("@DiseaseHistory", SqlDbType.NVarChar,50),
					new SqlParameter("@FamilyTumorTistory", SqlDbType.NVarChar,1),
					new SqlParameter("@DiseaseHistoryOther", SqlDbType.NVarChar,255),
					new SqlParameter("@AndrogenUsed", SqlDbType.NVarChar,1),
					new SqlParameter("@EstrogenUsed", SqlDbType.NVarChar,1),
					new SqlParameter("@Cervical", SqlDbType.NVarChar,255),
					new SqlParameter("@Uterine", SqlDbType.NVarChar,255),
					new SqlParameter("@Genital", SqlDbType.NVarChar,255),
					new SqlParameter("@Leucorrhea", SqlDbType.NVarChar,255),
					new SqlParameter("@Vaginal", SqlDbType.NVarChar,255),
					new SqlParameter("@AnnexLeft", SqlDbType.NVarChar,255),
					new SqlParameter("@AnnexRight", SqlDbType.NVarChar,255),
					new SqlParameter("@CheckCases", SqlDbType.NVarChar,255),
					new SqlParameter("@InfraredScanBreast", SqlDbType.NVarChar,255),
					new SqlParameter("@Conclusion", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.Menarche;
            parameters[5].Value = model.MenopauseAge;
            parameters[6].Value = model.MenstrualCycle;
            parameters[7].Value = model.MenstrualVolume;
            parameters[8].Value = model.Dysmenorrhea;
            parameters[9].Value = model.DiseaseHistory;
            parameters[10].Value = model.FamilyTumorTistory;
            parameters[11].Value = model.DiseaseHistoryOther;
            parameters[12].Value = model.AndrogenUsed;
            parameters[13].Value = model.EstrogenUsed;
            parameters[14].Value = model.Cervical;
            parameters[15].Value = model.Uterine;
            parameters[16].Value = model.Genital;
            parameters[17].Value = model.Leucorrhea;
            parameters[18].Value = model.Vaginal;
            parameters[19].Value = model.AnnexLeft;
            parameters[20].Value = model.AnnexRight;
            parameters[21].Value = model.CheckCases;
            parameters[22].Value = model.InfraredScanBreast;
            parameters[23].Value = model.Conclusion;
            parameters[24].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }
    }
}
