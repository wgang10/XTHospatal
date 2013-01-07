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
    public class DAL_Feme : IDAL_Feme
    {
        private string SearchID_SQL = @"Select EmployeeID From Feme
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Feme(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,Menarche,MenopauseAge,MenstrualCycle,MenstrualVolume,Dysmenorrhea,DiseaseHistory,FamilyTumorTistory,DiseaseHistoryOther,AndrogenUsed,EstrogenUsed,Cervical,Uterine,Genital,Leucorrhea,Vaginal,AnnexLeft,AnnexRight,CheckCases,InfraredScanBreast,Conclusion,Physicians)
values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMoth,@Menarche,@MenopauseAge,@MenstrualCycle,@MenstrualVolume,@Dysmenorrhea,@DiseaseHistory,@FamilyTumorTistory,@DiseaseHistoryOther,@AndrogenUsed,@EstrogenUsed,@Cervical,@Uterine,@Genital,@Leucorrhea,@Vaginal,@AnnexLeft,@AnnexRight,@CheckCases,@InfraredScanBreast,@Conclusion,@Physicians)";
        private string Update_SQL = @"Update Feme Set 
UPDATE_DATETIME=FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMoth", OleDbType.VarWChar,6),
					new OleDbParameter("@Menarche", OleDbType.VarWChar,3),
					new OleDbParameter("@MenopauseAge", OleDbType.VarWChar,3),
					new OleDbParameter("@MenstrualCycle", OleDbType.VarWChar,1),
					new OleDbParameter("@MenstrualVolume", OleDbType.VarWChar,1),
					new OleDbParameter("@Dysmenorrhea", OleDbType.VarWChar,1),
					new OleDbParameter("@DiseaseHistory", OleDbType.VarWChar,50),
					new OleDbParameter("@FamilyTumorTistory", OleDbType.VarWChar,1),
					new OleDbParameter("@DiseaseHistoryOther", OleDbType.VarWChar,255),
					new OleDbParameter("@AndrogenUsed", OleDbType.VarWChar,1),
					new OleDbParameter("@EstrogenUsed", OleDbType.VarWChar,1),
					new OleDbParameter("@Cervical", OleDbType.VarWChar,255),
					new OleDbParameter("@Uterine", OleDbType.VarWChar,255),
					new OleDbParameter("@Genital", OleDbType.VarWChar,255),
					new OleDbParameter("@Leucorrhea", OleDbType.VarWChar,255),
					new OleDbParameter("@Vaginal", OleDbType.VarWChar,255),
					new OleDbParameter("@AnnexLeft", OleDbType.VarWChar,255),
					new OleDbParameter("@AnnexRight", OleDbType.VarWChar,255),
					new OleDbParameter("@CheckCases", OleDbType.VarWChar,255),
					new OleDbParameter("@InfraredScanBreast", OleDbType.VarWChar,255),
					new OleDbParameter("@Conclusion", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,255)};
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

        public ReturnValue Update(Feme model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@Menarche", OleDbType.VarWChar,3),
					new OleDbParameter("@MenopauseAge", OleDbType.VarWChar,3),
					new OleDbParameter("@MenstrualCycle", OleDbType.VarWChar,1),
					new OleDbParameter("@MenstrualVolume", OleDbType.VarWChar,1),
					new OleDbParameter("@Dysmenorrhea", OleDbType.VarWChar,1),
					new OleDbParameter("@DiseaseHistory", OleDbType.VarWChar,50),
					new OleDbParameter("@FamilyTumorTistory", OleDbType.VarWChar,1),
					new OleDbParameter("@DiseaseHistoryOther", OleDbType.VarWChar,255),
					new OleDbParameter("@AndrogenUsed", OleDbType.VarWChar,1),
					new OleDbParameter("@EstrogenUsed", OleDbType.VarWChar,1),
					new OleDbParameter("@Cervical", OleDbType.VarWChar,255),
					new OleDbParameter("@Uterine", OleDbType.VarWChar,255),
					new OleDbParameter("@Genital", OleDbType.VarWChar,255),
					new OleDbParameter("@Leucorrhea", OleDbType.VarWChar,255),
					new OleDbParameter("@Vaginal", OleDbType.VarWChar,255),
					new OleDbParameter("@AnnexLeft", OleDbType.VarWChar,255),
					new OleDbParameter("@AnnexRight", OleDbType.VarWChar,255),
					new OleDbParameter("@CheckCases", OleDbType.VarWChar,255),
					new OleDbParameter("@InfraredScanBreast", OleDbType.VarWChar,255),
					new OleDbParameter("@Conclusion", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,255),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMoth", OleDbType.VarWChar,6)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Menarche;
            parameters[3].Value = model.MenopauseAge;
            parameters[4].Value = model.MenstrualCycle;
            parameters[5].Value = model.MenstrualVolume;
            parameters[6].Value = model.Dysmenorrhea;
            parameters[7].Value = model.DiseaseHistory;
            parameters[8].Value = model.FamilyTumorTistory;
            parameters[9].Value = model.DiseaseHistoryOther;
            parameters[10].Value = model.AndrogenUsed;
            parameters[11].Value = model.EstrogenUsed;
            parameters[12].Value = model.Cervical;
            parameters[13].Value = model.Uterine;
            parameters[14].Value = model.Genital;
            parameters[15].Value = model.Leucorrhea;
            parameters[16].Value = model.Vaginal;
            parameters[17].Value = model.AnnexLeft;
            parameters[18].Value = model.AnnexRight;
            parameters[19].Value = model.CheckCases;
            parameters[20].Value = model.InfraredScanBreast;
            parameters[21].Value = model.Conclusion;
            parameters[22].Value = model.Physicians;
            parameters[23].Value = model.EmployeeID;
            parameters[24].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parameters);
        }
    }
}
