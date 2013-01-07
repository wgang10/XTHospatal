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
    public class DAL_Features : IDAL_Features
    {
        private string SearchID_SQL = @"Select EmployeeID From Features
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Features(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,LeftEye,RightEye,CorrectedLeft,CorrectedRight,ColorVisionForce,TrachomaLeft,TrachomaRight,OtherEye,ListeningLeft,ListeningRight,Ear,Olfactory,NoseParanasalSinusDisease,Throat,LipPalate,Stuttering,Caries,MissingTeeth,PeriodontalDisease,Other,MedicalAdvice,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@LeftEye,@RightEye,@CorrectedLeft,@CorrectedRight,@ColorVisionForce,@TrachomaLeft,@TrachomaRight,@OtherEye,@ListeningLeft,@ListeningRight,@Ear,@Olfactory,@NoseParanasalSinusDisease,@Throat,@LipPalate,@Stuttering,@Caries,@MissingTeeth,@PeriodontalDisease,@Other,@MedicalAdvice,@Physicians)";
        private string Update_SQL = @"Update Features Set 
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
LeftEye=@LeftEye,
RightEye=@RightEye,
CorrectedLeft=@CorrectedLeft,
CorrectedRight=@CorrectedRight,
ColorVisionForce=@ColorVisionForce,
TrachomaLeft=@TrachomaLeft,
TrachomaRight=@TrachomaRight,
OtherEye=@OtherEye,
ListeningLeft=@ListeningLeft,
ListeningRight=@ListeningRight,
Ear=@Ear,
Olfactory=@Olfactory,
NoseParanasalSinusDisease=@NoseParanasalSinusDisease,
Throat=@Throat,
LipPalate=@LipPalate,
Stuttering=@Stuttering,
Caries=@Caries,
MissingTeeth=@MissingTeeth,
PeriodontalDisease=@PeriodontalDisease,
Other=@Other,
MedicalAdvice=@MedicalAdvice,
Physicians=@Physicians
where EmployeeID=@EmployeeID and YearMoth=@YearMonth ";

        public ReturnValue Add(Features model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@LeftEye", OleDbType.VarWChar,6),
					new OleDbParameter("@RightEye", OleDbType.VarWChar,6),
					new OleDbParameter("@CorrectedLeft", OleDbType.VarWChar,6),
					new OleDbParameter("@CorrectedRight", OleDbType.VarWChar,6),
					new OleDbParameter("@ColorVisionForce", OleDbType.VarWChar,12),
					new OleDbParameter("@TrachomaLeft", OleDbType.VarWChar,12),
					new OleDbParameter("@TrachomaRight", OleDbType.VarWChar,12),
					new OleDbParameter("@OtherEye", OleDbType.VarWChar,50),
					new OleDbParameter("@ListeningLeft", OleDbType.VarWChar,6),
					new OleDbParameter("@ListeningRight", OleDbType.VarWChar,6),
					new OleDbParameter("@Ear", OleDbType.VarWChar,50),
					new OleDbParameter("@Olfactory", OleDbType.VarWChar,50),
					new OleDbParameter("@NoseParanasalSinusDisease", OleDbType.VarWChar,128),
					new OleDbParameter("@Throat", OleDbType.VarWChar,128),
					new OleDbParameter("@LipPalate", OleDbType.VarWChar,128),
					new OleDbParameter("@Stuttering", OleDbType.VarWChar,50),
					new OleDbParameter("@Caries", OleDbType.VarWChar,50),
					new OleDbParameter("@MissingTeeth", OleDbType.VarWChar,50),
					new OleDbParameter("@PeriodontalDisease", OleDbType.VarWChar,128),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.LeftEye;
            parameters[5].Value = model.RightEye;
            parameters[6].Value = model.CorrectedLeft;
            parameters[7].Value = model.CorrectedRight;
            parameters[8].Value = model.ColorVisionForce;
            parameters[9].Value = model.TrachomaLeft;
            parameters[10].Value = model.TrachomaRight;
            parameters[11].Value = model.OtherEye;
            parameters[12].Value = model.ListeningLeft;
            parameters[13].Value = model.ListeningRight;
            parameters[14].Value = model.Ear;
            parameters[15].Value = model.Olfactory;
            parameters[16].Value = model.NoseParanasalSinusDisease;
            parameters[17].Value = model.Throat;
            parameters[18].Value = model.LipPalate;
            parameters[19].Value = model.Stuttering;
            parameters[20].Value = model.Caries;
            parameters[21].Value = model.MissingTeeth;
            parameters[22].Value = model.PeriodontalDisease;
            parameters[23].Value = model.Other;
            parameters[24].Value = model.MedicalAdvice;
            parameters[25].Value = model.Physicians;
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

        public ReturnValue Update(Features model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@LeftEye", OleDbType.VarWChar,6),
					new OleDbParameter("@RightEye", OleDbType.VarWChar,6),
					new OleDbParameter("@CorrectedLeft", OleDbType.VarWChar,6),
					new OleDbParameter("@CorrectedRight", OleDbType.VarWChar,6),
					new OleDbParameter("@ColorVisionForce", OleDbType.VarWChar,12),
					new OleDbParameter("@TrachomaLeft", OleDbType.VarWChar,12),
					new OleDbParameter("@TrachomaRight", OleDbType.VarWChar,12),
					new OleDbParameter("@OtherEye", OleDbType.VarWChar,50),
					new OleDbParameter("@ListeningLeft", OleDbType.VarWChar,6),
					new OleDbParameter("@ListeningRight", OleDbType.VarWChar,6),
					new OleDbParameter("@Ear", OleDbType.VarWChar,50),
					new OleDbParameter("@Olfactory", OleDbType.VarWChar,50),
					new OleDbParameter("@NoseParanasalSinusDisease", OleDbType.VarWChar,128),
					new OleDbParameter("@Throat", OleDbType.VarWChar,128),
					new OleDbParameter("@LipPalate", OleDbType.VarWChar,128),
					new OleDbParameter("@Stuttering", OleDbType.VarWChar,50),
					new OleDbParameter("@Caries", OleDbType.VarWChar,50),
					new OleDbParameter("@MissingTeeth", OleDbType.VarWChar,50),
					new OleDbParameter("@PeriodontalDisease", OleDbType.VarWChar,128),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.LeftEye;
            parametersUpdate[3].Value = model.RightEye;
            parametersUpdate[4].Value = model.CorrectedLeft;
            parametersUpdate[5].Value = model.CorrectedRight;
            parametersUpdate[6].Value = model.ColorVisionForce;
            parametersUpdate[7].Value = model.TrachomaLeft;
            parametersUpdate[8].Value = model.TrachomaRight;
            parametersUpdate[9].Value = model.OtherEye;
            parametersUpdate[10].Value = model.ListeningLeft;
            parametersUpdate[11].Value = model.ListeningRight;
            parametersUpdate[12].Value = model.Ear;
            parametersUpdate[13].Value = model.Olfactory;
            parametersUpdate[14].Value = model.NoseParanasalSinusDisease;
            parametersUpdate[15].Value = model.Throat;
            parametersUpdate[16].Value = model.LipPalate;
            parametersUpdate[17].Value = model.Stuttering;
            parametersUpdate[18].Value = model.Caries;
            parametersUpdate[19].Value = model.MissingTeeth;
            parametersUpdate[20].Value = model.PeriodontalDisease;
            parametersUpdate[21].Value = model.Other;
            parametersUpdate[22].Value = model.MedicalAdvice;
            parametersUpdate[23].Value = model.Physicians;
            parametersUpdate[24].Value = model.EmployeeID;
            parametersUpdate[25].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}
