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
    public class DAL_Features : IDAL_Features
    {
        private string SearchID_SQL = @"Select EmployeeID From Features
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into Features(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,LeftEye,RightEye,CorrectedLeft,CorrectedRight,ColorVisionForce,TrachomaLeft,TrachomaRight,OtherEye,ListeningLeft,ListeningRight,Ear,Olfactory,NoseParanasalSinusDisease,Throat,LipPalate,Stuttering,Caries,MissingTeeth,PeriodontalDisease,Other,MedicalAdvice,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@LeftEye,@RightEye,@CorrectedLeft,@CorrectedRight,@ColorVisionForce,@TrachomaLeft,@TrachomaRight,@OtherEye,@ListeningLeft,@ListeningRight,@Ear,@Olfactory,@NoseParanasalSinusDisease,@Throat,@LipPalate,@Stuttering,@Caries,@MissingTeeth,@PeriodontalDisease,@Other,@MedicalAdvice,@Physicians)";
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
where EmployeeID=@EmployeeID and YearMonth=@YearMonth ";

        public ReturnValue Add(Features model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@LeftEye", SqlDbType.NVarChar,6),
					new SqlParameter("@RightEye", SqlDbType.NVarChar,6),
					new SqlParameter("@CorrectedLeft", SqlDbType.NVarChar,6),
					new SqlParameter("@CorrectedRight", SqlDbType.NVarChar,6),
					new SqlParameter("@ColorVisionForce", SqlDbType.NVarChar,12),
					new SqlParameter("@TrachomaLeft", SqlDbType.NVarChar,12),
					new SqlParameter("@TrachomaRight", SqlDbType.NVarChar,12),
					new SqlParameter("@OtherEye", SqlDbType.NVarChar,50),
					new SqlParameter("@ListeningLeft", SqlDbType.NVarChar,6),
					new SqlParameter("@ListeningRight", SqlDbType.NVarChar,6),
					new SqlParameter("@Ear", SqlDbType.NVarChar,50),
					new SqlParameter("@Olfactory", SqlDbType.NVarChar,50),
					new SqlParameter("@NoseParanasalSinusDisease", SqlDbType.NVarChar,128),
					new SqlParameter("@Throat", SqlDbType.NVarChar,128),
					new SqlParameter("@LipPalate", SqlDbType.NVarChar,128),
					new SqlParameter("@Stuttering", SqlDbType.NVarChar,50),
					new SqlParameter("@Caries", SqlDbType.NVarChar,50),
					new SqlParameter("@MissingTeeth", SqlDbType.NVarChar,50),
					new SqlParameter("@PeriodontalDisease", SqlDbType.NVarChar,128),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
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

        public ReturnValue Update(Features model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@LeftEye", SqlDbType.NVarChar,6),
					new SqlParameter("@RightEye", SqlDbType.NVarChar,6),
					new SqlParameter("@CorrectedLeft", SqlDbType.NVarChar,6),
					new SqlParameter("@CorrectedRight", SqlDbType.NVarChar,6),
					new SqlParameter("@ColorVisionForce", SqlDbType.NVarChar,12),
					new SqlParameter("@TrachomaLeft", SqlDbType.NVarChar,12),
					new SqlParameter("@TrachomaRight", SqlDbType.NVarChar,12),
					new SqlParameter("@OtherEye", SqlDbType.NVarChar,50),
					new SqlParameter("@ListeningLeft", SqlDbType.NVarChar,6),
					new SqlParameter("@ListeningRight", SqlDbType.NVarChar,6),
					new SqlParameter("@Ear", SqlDbType.NVarChar,50),
					new SqlParameter("@Olfactory", SqlDbType.NVarChar,50),
					new SqlParameter("@NoseParanasalSinusDisease", SqlDbType.NVarChar,128),
					new SqlParameter("@Throat", SqlDbType.NVarChar,128),
					new SqlParameter("@LipPalate", SqlDbType.NVarChar,128),
					new SqlParameter("@Stuttering", SqlDbType.NVarChar,50),
					new SqlParameter("@Caries", SqlDbType.NVarChar,50),
					new SqlParameter("@MissingTeeth", SqlDbType.NVarChar,50),
					new SqlParameter("@PeriodontalDisease", SqlDbType.NVarChar,128),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.LeftEye;
            parametersUpdate[5].Value = model.RightEye;
            parametersUpdate[6].Value = model.CorrectedLeft;
            parametersUpdate[7].Value = model.CorrectedRight;
            parametersUpdate[8].Value = model.ColorVisionForce;
            parametersUpdate[9].Value = model.TrachomaLeft;
            parametersUpdate[10].Value = model.TrachomaRight;
            parametersUpdate[11].Value = model.OtherEye;
            parametersUpdate[12].Value = model.ListeningLeft;
            parametersUpdate[13].Value = model.ListeningRight;
            parametersUpdate[14].Value = model.Ear;
            parametersUpdate[15].Value = model.Olfactory;
            parametersUpdate[16].Value = model.NoseParanasalSinusDisease;
            parametersUpdate[17].Value = model.Throat;
            parametersUpdate[18].Value = model.LipPalate;
            parametersUpdate[19].Value = model.Stuttering;
            parametersUpdate[20].Value = model.Caries;
            parametersUpdate[21].Value = model.MissingTeeth;
            parametersUpdate[22].Value = model.PeriodontalDisease;
            parametersUpdate[23].Value = model.Other;
            parametersUpdate[24].Value = model.MedicalAdvice;
            parametersUpdate[25].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}
