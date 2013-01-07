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
    public class DAL_Employee : IDAL_Employee
    {
        private string Add_SQL = @"Insert into Employee(
			CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,EmployeeName,EmployeeSex,EmployeeBirthday,EmployeeWHCD,EmployeeHF,EmployeeJG,EmployeeXJD,EmployeeBM,EmployeeDW,EmployeeJWBS)
			Values (
			CONVERT(VarWChar,GETDATE(),112)+REPLACE(CONVERT(VarWChar,GETDATE(),108),':',''),CONVERT(VarWChar,GETDATE(),112)+REPLACE(CONVERT(VarWChar,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@EmployeeName,@EmployeeSex,@EmployeeBirthday,@EmployeeWHCD,@EmployeeHF,@EmployeeJG,@EmployeeXJD,@EmployeeBM,@EmployeeDW,@EmployeeJWBS)";
        private string UpdateEmployeePWD = @"Update Employee Set 
UPDATE_DATETIME=CONVERT(VarWChar,GETDATE(),112)+REPLACE(CONVERT(VarWChar,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
EmployeePWD=@EmployeePWD,
EmployeeEmail=@EmployeeEmail,
EmployeePhone=@EmployeePhone
Where EmployeeID=@EmployeeID";
        private string Search_SQL = @"Select UPDATER_ID,TERMINAL_CD,EmployeeID,EmployeeName,(Case EmployeeSex when '0' then 'ÄÐ' when '1' then 'Å®' else '' end) as EmployeeSex,EmployeeBirthday,EmployeeWHCD,EmployeeHF,EmployeeJG,EmployeeXJD,EmployeeBM,EmployeeDW,EmployeeJWBS 
FROM Employee ";
        private string SearchEmployeeID_SQL = @"Select EmployeeID From Employee where EmployeeID = @EmployeeID";
        private string UpdateEmployee_SQL = @"Update Employee Set 
UPDATE_DATETIME=CONVERT(VarWChar,GETDATE(),112)+REPLACE(CONVERT(VarWChar,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
EmployeeName=@EmployeeName,
EmployeeSex=@EmployeeSex,
EmployeeBirthday=@EmployeeBirthday,
EmployeeWHCD=@EmployeeWHCD,
EmployeeHF=@EmployeeHF,
EmployeeJG=@EmployeeJG,
EmployeeXJD=@EmployeeXJD,
EmployeeBM=@EmployeeBM,
EmployeeDW=@EmployeeDW,
EmployeeJWBS=@EmployeeJWBS
Where EmployeeID=@EmployeeID ";
        private string SearchAll_SQL = @"SELECT 
Emp.CREATE_DATETIME as Emp_CREATE_DATETIME
,Emp.UPDATE_DATETIME as Emp_UPDATE_DATETIME
,Emp.TRANS_STATE as Emp_TRANS_STATE
,Emp.UPDATER_ID as Emp_UPDATER_ID
,Emp.TERMINAL_CD as Emp_TERMINAL_CD
,Emp.EmployeeID as Emp_EmployeeID
,Emp.EmployeeName as Emp_EmployeeName
,Emp.EmployeeSex as Emp_EmployeeSex
,Emp.EmployeeBirthday as Emp_EmployeeBirthday
,Emp.EmployeeWHCD as Emp_EmployeeWHCD
,Emp.EmployeeHF as Emp_EmployeeHF
,Emp.EmployeeJG as Emp_EmployeeJG
,Emp.EmployeeXJD as Emp_EmployeeXJD
,Emp.EmployeeBM as Emp_EmployeeBM
,Emp.EmployeeDW as Emp_EmployeeDW
,Emp.EmployeeJWBS as Emp_EmployeeJWBS
,Bio.CREATE_DATETIME as Bio_CREATE_DATETIME
,Bio.UPDATE_DATETIME as Bio_UPDATE_DATETIME
,Bio.TRANS_STATE as Bio_TRANS_STATE
,Bio.UPDATER_ID as Bio_UPDATER_ID
,Bio.TERMINAL_CD as Bio_TERMINAL_CD
,Bio.HYNo as Bio_HYNo
,Bio.HYDr as Bio_HYDr
,Bio.HYTC as Bio_HYTC
,Bio.HYTG as Bio_HYTG
,Bio.HYHDLC as Bio_HYHDLC
,Bio.HYTBIL as Bio_HYTBIL
,Bio.HYDBIL as Bio_HYDBIL
,Bio.HYTP as Bio_HYTP
,Bio.HYALB as Bio_HYALB
,Bio.HYALT as Bio_HYALT
,Bio.HYHBsAg as Bio_HYHBsAg
,Bio.HYHBsAb as Bio_HYHBsAb
,Bio.HYHBeAg as Bio_HYHBeAg
,Bio.HYHBeAb as Bio_HYHBeAb
,Bio.HYHBcAb as Bio_HYHBcAb
,Fea.CREATE_DATETIME as Fea_CREATE_DATETIME
,Fea.UPDATE_DATETIME as Fea_UPDATE_DATETIME
,Fea.TRANS_STATE as Fea_TRANS_STATE
,Fea.UPDATER_ID as Fea_UPDATER_ID
,Fea.TERMINAL_CD as Fea_TERMINAL_CD
,Fea.LeftEye as Fea_LeftEye
,Fea.RightEye as Fea_RightEye
,Fea.CorrectedLeft as Fea_CorrectedLeft
,Fea.CorrectedRight as Fea_CorrectedRight
,Fea.ColorVisionForce as Fea_ColorVisionForce
,Fea.TrachomaLeft as Fea_TrachomaLeft
,Fea.TrachomaRight as Fea_TrachomaRight
,Fea.OtherEye as Fea_OtherEye
,Fea.ListeningLeft as Fea_ListeningLeft
,Fea.ListeningRight as Fea_ListeningRight
,Fea.Ear as Fea_Ear
,Fea.Olfactory as Fea_Olfactory
,Fea.NoseParanasalSinusDisease as Fea_NoseParanasalSinusDisease
,Fea.Throat as Fea_Throat
,Fea.LipPalate as Fea_LipPalate
,Fea.Stuttering as Fea_Stuttering
,Fea.Caries as Fea_Caries
,Fea.MissingTeeth as Fea_MissingTeeth
,Fea.PeriodontalDisease as Fea_PeriodontalDisease
,Fea.Other as Fea_Other
,Fea.MedicalAdvice as Fea_MedicalAdvice
,Fea.Physicians as Fea_Physicians
,Sur.CREATE_DATETIME as Sur_CREATE_DATETIME
,Sur.UPDATE_DATETIME as Sur_UPDATE_DATETIME
,Sur.TRANS_STATE as Sur_TRANS_STATE
,Sur.UPDATER_ID as Sur_UPDATER_ID
,Sur.TERMINAL_CD as Sur_TERMINAL_CD
,Sur.Length as Sur_Length
,Sur.Bust as Sur_Bust
,Sur.Weight as Sur_Weight
,Sur.BadBreath as Sur_BadBreath
,Sur.Skin as Sur_Skin
,Sur.Lymphoid as Sur_Lymphoid
,Sur.Thyroid as Sur_Thyroid
,Sur.Spine as Sur_Spine
,Sur.Limbs as Sur_Limbs
,Sur.Joint as Sur_Joint
,Sur.Flatfoot as Sur_Flatfoot
,Sur.Genitourinary as Sur_Genitourinary
,Sur.Anal as Sur_Anal
,Sur.Hernia as Sur_Hernia
,Sur.Other as Sur_Other
,Sur.MedicalAdvice as Sur_MedicalAdvice
,Sur.Physicians as Sur_Physicians
,Inte.CREATE_DATETIME as Int_CREATE_DATETIME
,Inte.UPDATE_DATETIME as Int_UPDATE_DATETIME
,Inte.TRANS_STATE as Int_TRANS_STATE
,Inte.UPDATER_ID as Int_UPDATER_ID
,Inte.TERMINAL_CD as Int_TERMINAL_CD
,Inte.BloodPressure as Int_BloodPressure
,Inte.DevelopmentStatus as Int_DevelopmentStatus
,Inte.Neurological as Int_Neurological
,Inte.Lung as Int_Lung
,Inte.HeartBlood as Int_HeartBlood
,Inte.AbdominalOrgans as Int_AbdominalOrgans
,Inte.Liver as Int_Liver
,Inte.Spleen as Int_Spleen
,Inte.Other as Int_Other
,Inte.MedicalAdvice as Int_MedicalAdvice
,Inte.Physicians as Int_Physicians
,ECG.CREATE_DATETIME as ECT_CREATE_DATETIME
,ECG.UPDATE_DATETIME as ECT_UPDATE_DATETIME
,ECG.TRANS_STATE as ECT_TRANS_STATE
,ECG.UPDATER_ID as ECT_UPDATER_ID
,ECG.TERMINAL_CD as ECT_TERMINAL_CD
,ECG.ECGNo as ECT_No
,ECG.ClinicalDiagnosis as ECT_ClinicalDiagnosis
,ECG.UsedDrugs as ECT_UsedDrugs
,ECG.SummaryHistory as ECT_SummaryHistory
,ECG.SummaryBody as ECT_SummaryBody
,ECG.PatientSituation as ECT_PatientSituation
,ECG.MedicalAdvice as ECT_MedicalAdvice
,ECG.ECG as ECT_Image
,ECG.Physicians as ECT_Physicians
,Xray.CREATE_DATETIME as Xray_CREATE_DATETIME
,Xray.UPDATE_DATETIME as Xray_UPDATE_DATETIME
,Xray.TRANS_STATE as Xray_TRANS_STATE
,Xray.UPDATER_ID as Xray_UPDATER_ID
,Xray.TERMINAL_CD as Xray_TERMINAL_CD
,Xray.PhotoNo as Xray_PhotoNo
,Xray.Symptoms as Xray_Symptoms
,Xray.Laboratory as Xray_Laboratory
,Xray.Diagnosis as Xray_Diagnosis
,Xray.Perspective as Xray_Perspective
,Xray.Camera as Xray_Camera
,Xray.Results as Xray_Results
,Xray.XImage as Xray_XImage
,Xray.Physicians as Xray_Physicians
,Bex.CREATE_DATETIME as Bex_CREATE_DATETIME
,Bex.UPDATE_DATETIME as Bex_UPDATE_DATETIME
,Bex.TRANS_STATE as Bex_TRANS_STATE
,Bex.UPDATER_ID as Bex_UPDATER_ID
,Bex.TERMINAL_CD as Bex_TERMINAL_CD
,Bex.BID as Bex_BID
,Bex.HistorySigns as Bex_HistorySigns
,Bex.LaboratoryExamination as Bex_LaboratoryExamination
,Bex.Diagnosis as Bex_Diagnosis
,Bex.Purpose as Bex_Purpose
,Bex.Results as Bex_Results
,Bex.BImage as Bex_BImage
,Bex.Physicians as Bex_Physicians
,Rep.CREATE_DATETIME
,Rep.UPDATE_DATETIME
,Rep.TRANS_STATE
,Rep.UPDATER_ID
,Rep.TERMINAL_CD
,Rep.ChestPerspective
,Rep.Laboratory
,Rep.Review
,Rep.Remarks
,Feme.Menarche As Feme_Menarche
,Feme.MenopauseAge As Feme_MenopauseAge
,Feme.MenstrualCycle As Feme_MenstrualCycle
,Feme.MenstrualVolume As Feme_MenstrualVolume
,Feme.Dysmenorrhea As Feme_Dysmenorrhea
,Feme.DiseaseHistory As Feme_DiseaseHistory 
,Feme.FamilyTumorTistory As Feme_FamilyTumorTistory
,Feme.DiseaseHistoryOther As Feme_DiseaseHistoryOther
,Feme.AndrogenUsed As Feme_AndrogenUsed
,Feme.EstrogenUsed As Feme_EstrogenUsed
,Feme.Cervical As Feme_Cervical
,Feme.Uterine As Feme_Uterine
,Feme.Genital As Feme_Genital
,Feme.Leucorrhea As Feme_Leucorrhea
,Feme.Vaginal As Feme_Vaginal
,Feme.AnnexLeft As Feme_AnnexLeft
,Feme.AnnexRight As Feme_AnnexRight
,Feme.CheckCases As Feme_CheckCases
,Feme.InfraredScanBreast As Feme_InfraredScanBreast
,Feme.Conclusion As Feme_Conclusion
,Feme.Physicians As Feme_Physicians
From Employee Emp 
	Left Join Biochemistry Bio
		On Bio.EmployeeID = Emp.EmployeeID And Bio.YearMoth = @YearMonth
	Left Join Features Fea 
		On Fea.EmployeeID = Emp.EmployeeID And Fea.YearMoth = @YearMonth
	Left Join Surgery Sur 
		On Sur.EmployeeID = Emp.EmployeeID And Sur.YearMoth = @YearMonth
	Left Join InternalMedicine Inte 
		On Inte.EmployeeID = Emp.EmployeeID And Inte.YearMoth = @YearMonth
	Left Join ECG 
		On ECG.EmployeeID = Emp.EmployeeID And ECG.YearMoth = @YearMonth
	Left Join Xray 
		On Xray.EmployeeID = Emp.EmployeeID And Xray.YearMoth = @YearMonth
	Left Join Bexamination Bex 
		On Bex.EmployeeID = Emp.EmployeeID And Bex.YearMoth = @YearMonth
	Left Join Report Rep 
		On Rep.EmployeeID = Emp.EmployeeID And Rep.YearMoth = @YearMonth
	left Join Feme 
		On Feme.EmployeeID = Emp.EmployeeID And Feme.YearMoth = @YearMonth
Where Emp.EmployeeID = @EmployeeID";

        private string GetEmployeeInfo_SQL = @"SELECT 
Emp.CREATE_DATETIME as Emp_CREATE_DATETIME
,Emp.UPDATE_DATETIME as Emp_UPDATE_DATETIME
,Emp.TRANS_STATE as Emp_TRANS_STATE
,Emp.UPDATER_ID as Emp_UPDATER_ID
,Emp.TERMINAL_CD as Emp_TERMINAL_CD
,Emp.EmployeeID as Emp_EmployeeID
,Emp.EmployeeName as Emp_EmployeeName
,Emp.EmployeeSex as Emp_EmployeeSex
,Emp.EmployeeBirthday as Emp_EmployeeBirthday
,Emp.EmployeeWHCD as Emp_EmployeeWHCD
,Emp.EmployeeHF as Emp_EmployeeHF
,Emp.EmployeeJG as Emp_EmployeeJG
,Emp.EmployeeXJD as Emp_EmployeeXJD
,Department.Name as Emp_EmployeeBM
,Emp.EmployeeDW as Emp_EmployeeDW
,Emp.EmployeeJWBS as Emp_EmployeeJWBS
,Emp.EmployeeGZID as Emp_EmployeeGZID
,Emp.EmployeePWD as Emp_EmployeePWD
,Emp.EmployeeEmail
,Emp.EmployeePhone
From Employee Emp
Where Emp.EmployeeID = @EmployeeID";

        private string SearchMyInfo_SQL = @"SELECT 
Emp.CREATE_DATETIME as Emp_CREATE_DATETIME
,Emp.UPDATE_DATETIME as Emp_UPDATE_DATETIME
,Emp.TRANS_STATE as Emp_TRANS_STATE
,Emp.UPDATER_ID as Emp_UPDATER_ID
,Emp.TERMINAL_CD as Emp_TERMINAL_CD
,Emp.EmployeeID as Emp_EmployeeID
,Emp.EmployeeName as Emp_EmployeeName
,Emp.EmployeeSex as Emp_EmployeeSex
,Emp.EmployeeBirthday as Emp_EmployeeBirthday
,Emp.EmployeeWHCD as Emp_EmployeeWHCD
,Emp.EmployeeHF as Emp_EmployeeHF
,Emp.EmployeeJG as Emp_EmployeeJG
,Emp.EmployeeXJD as Emp_EmployeeXJD
,Emp.EmployeeBM as Emp_EmployeeBM
,Emp.EmployeeDW as Emp_EmployeeDW
,Emp.EmployeeJWBS as Emp_EmployeeJWBS
,Bio.CREATE_DATETIME as Bio_CREATE_DATETIME
,Bio.UPDATE_DATETIME as Bio_UPDATE_DATETIME
,Bio.TRANS_STATE as Bio_TRANS_STATE
,Bio.UPDATER_ID as Bio_UPDATER_ID
,Bio.TERMINAL_CD as Bio_TERMINAL_CD
,Bio.HYNo as Bio_HYNo
,Bio.HYDr as Bio_HYDr
,Bio.HYTC as Bio_HYTC
,Bio.HYTG as Bio_HYTG
,Bio.HYHDLC as Bio_HYHDLC
,Bio.HYTBIL as Bio_HYTBIL
,Bio.HYDBIL as Bio_HYDBIL
,Bio.HYTP as Bio_HYTP
,Bio.HYALB as Bio_HYALB
,Bio.HYALT as Bio_HYALT
,Bio.HYHBsAg as Bio_HYHBsAg
,Bio.HYHBsAb as Bio_HYHBsAb
,Bio.HYHBeAg as Bio_HYHBeAg
,Bio.HYHBeAb as Bio_HYHBeAb
,Bio.HYHBcAb as Bio_HYHBcAb
,Fea.CREATE_DATETIME as Fea_CREATE_DATETIME
,Fea.UPDATE_DATETIME as Fea_UPDATE_DATETIME
,Fea.TRANS_STATE as Fea_TRANS_STATE
,Fea.UPDATER_ID as Fea_UPDATER_ID
,Fea.TERMINAL_CD as Fea_TERMINAL_CD
,Fea.LeftEye as Fea_LeftEye
,Fea.RightEye as Fea_RightEye
,Fea.CorrectedLeft as Fea_CorrectedLeft
,Fea.CorrectedRight as Fea_CorrectedRight
,Fea.ColorVisionForce as Fea_ColorVisionForce
,Fea.TrachomaLeft as Fea_TrachomaLeft
,Fea.TrachomaRight as Fea_TrachomaRight
,Fea.OtherEye as Fea_OtherEye
,Fea.ListeningLeft as Fea_ListeningLeft
,Fea.ListeningRight as Fea_ListeningRight
,Fea.Ear as Fea_Ear
,Fea.Olfactory as Fea_Olfactory
,Fea.NoseParanasalSinusDisease as Fea_NoseParanasalSinusDisease
,Fea.Throat as Fea_Throat
,Fea.LipPalate as Fea_LipPalate
,Fea.Stuttering as Fea_Stuttering
,Fea.Caries as Fea_Caries
,Fea.MissingTeeth as Fea_MissingTeeth
,Fea.PeriodontalDisease as Fea_PeriodontalDisease
,Fea.Other as Fea_Other
,Fea.MedicalAdvice as Fea_MedicalAdvice
,Fea.Physicians as Fea_Physicians
,Sur.CREATE_DATETIME as Sur_CREATE_DATETIME
,Sur.UPDATE_DATETIME as Sur_UPDATE_DATETIME
,Sur.TRANS_STATE as Sur_TRANS_STATE
,Sur.UPDATER_ID as Sur_UPDATER_ID
,Sur.TERMINAL_CD as Sur_TERMINAL_CD
,Sur.Length as Sur_Length
,Sur.Bust as Sur_Bust
,Sur.Weight as Sur_Weight
,Sur.BadBreath as Sur_BadBreath
,Sur.Skin as Sur_Skin
,Sur.Lymphoid as Sur_Lymphoid
,Sur.Thyroid as Sur_Thyroid
,Sur.Spine as Sur_Spine
,Sur.Limbs as Sur_Limbs
,Sur.Joint as Sur_Joint
,Sur.Flatfoot as Sur_Flatfoot
,Sur.Genitourinary as Sur_Genitourinary
,Sur.Anal as Sur_Anal
,Sur.Hernia as Sur_Hernia
,Sur.Other as Sur_Other
,Sur.MedicalAdvice as Sur_MedicalAdvice
,Sur.Physicians as Sur_Physicians
,Inte.CREATE_DATETIME as Int_CREATE_DATETIME
,Inte.UPDATE_DATETIME as Int_UPDATE_DATETIME
,Inte.TRANS_STATE as Int_TRANS_STATE
,Inte.UPDATER_ID as Int_UPDATER_ID
,Inte.TERMINAL_CD as Int_TERMINAL_CD
,Inte.BloodPressure as Int_BloodPressure
,Inte.DevelopmentStatus as Int_DevelopmentStatus
,Inte.Neurological as Int_Neurological
,Inte.Lung as Int_Lung
,Inte.HeartBlood as Int_HeartBlood
,Inte.AbdominalOrgans as Int_AbdominalOrgans
,Inte.Liver as Int_Liver
,Inte.Spleen as Int_Spleen
,Inte.Other as Int_Other
,Inte.MedicalAdvice as Int_MedicalAdvice
,Inte.Physicians as Int_Physicians
,ECG.CREATE_DATETIME as ECT_CREATE_DATETIME
,ECG.UPDATE_DATETIME as ECT_UPDATE_DATETIME
,ECG.TRANS_STATE as ECT_TRANS_STATE
,ECG.UPDATER_ID as ECT_UPDATER_ID
,ECG.TERMINAL_CD as ECT_TERMINAL_CD
,ECG.ECGNo as ECT_No
,ECG.ClinicalDiagnosis as ECT_ClinicalDiagnosis
,ECG.UsedDrugs as ECT_UsedDrugs
,ECG.SummaryHistory as ECT_SummaryHistory
,ECG.SummaryBody as ECT_SummaryBody
,ECG.PatientSituation as ECT_PatientSituation
,ECG.MedicalAdvice as ECT_MedicalAdvice
,ECG.ECG as ECT_Image
,ECG.Physicians as ECT_Physicians
,Xray.CREATE_DATETIME as Xray_CREATE_DATETIME
,Xray.UPDATE_DATETIME as Xray_UPDATE_DATETIME
,Xray.TRANS_STATE as Xray_TRANS_STATE
,Xray.UPDATER_ID as Xray_UPDATER_ID
,Xray.TERMINAL_CD as Xray_TERMINAL_CD
,Xray.PhotoNo as Xray_PhotoNo
,Xray.Symptoms as Xray_Symptoms
,Xray.Laboratory as Xray_Laboratory
,Xray.Diagnosis as Xray_Diagnosis
,Xray.Perspective as Xray_Perspective
,Xray.Camera as Xray_Camera
,Xray.Results as Xray_Results
,Xray.XImage as Xray_XImage
,Xray.Physicians as Xray_Physicians
,Bex.CREATE_DATETIME as Bex_CREATE_DATETIME
,Bex.UPDATE_DATETIME as Bex_UPDATE_DATETIME
,Bex.TRANS_STATE as Bex_TRANS_STATE
,Bex.UPDATER_ID as Bex_UPDATER_ID
,Bex.TERMINAL_CD as Bex_TERMINAL_CD
,Bex.BID as Bex_BID
,Bex.HistorySigns as Bex_HistorySigns
,Bex.LaboratoryExamination as Bex_LaboratoryExamination
,Bex.Diagnosis as Bex_Diagnosis
,Bex.Purpose as Bex_Purpose
,Bex.Results as Bex_Results
,Bex.BImage as Bex_BImage
,Bex.Physicians as Bex_Physicians
,Rep.CREATE_DATETIME
,Rep.UPDATE_DATETIME
,Rep.TRANS_STATE
,Rep.UPDATER_ID
,Rep.TERMINAL_CD
,Rep.ChestPerspective
,Rep.Laboratory
,Rep.Review
,Rep.Remarks
From Employee Emp 
	Left Join Biochemistry Bio
		On Bio.EmployeeID = Emp.EmployeeID And Bio.YearMonth = @YearMonth
	Left Join Features Fea 
		On Fea.EmployeeID = Emp.EmployeeID And Fea.YearMonth = @YearMonth
	Left Join Surgery Sur 
		On Sur.EmployeeID = Emp.EmployeeID And Sur.YearMonth = @YearMonth
	Left Join InternalMedicine Inte 
		On Inte.EmployeeID = Emp.EmployeeID And Inte.YearMonth = @YearMonth
	Left Join ECG 
		On ECG.EmployeeID = Emp.EmployeeID And ECG.YearMonth = @YearMonth
	Left Join Xray 
		On Xray.EmployeeID = Emp.EmployeeID And Xray.YearMonth = @YearMonth
	Left Join Bexamination Bex 
		On Bex.EmployeeID = Emp.EmployeeID And Bex.YearMonth = @YearMonth
	Left Join Report Rep 
		On Rep.EmployeeID = Emp.EmployeeID And Rep.YearMonth = @YearMonth
Where Emp.EmployeeGZID = @EmployeeGZID";


        public ReturnValue Add(Employee model)
        {
            SqlParameter[] parametersAdd = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeSex", SqlDbType.NVarChar,1),
					new SqlParameter("@EmployeeBirthday", SqlDbType.NVarChar,8),
					new SqlParameter("@EmployeeWHCD", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeHF", SqlDbType.NVarChar,1),
					new SqlParameter("@EmployeeJG", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeXJD", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeBM", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeDW", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeJWBS", SqlDbType.NVarChar,1024)};
            parametersAdd[0].Value = model.UPDATER_ID;
            parametersAdd[1].Value = model.TERMINAL_CD;
            parametersAdd[2].Value = model.EmployeeID;
            parametersAdd[3].Value = model.EmployeeName;
            parametersAdd[4].Value = model.EmployeeSex;
            parametersAdd[5].Value = model.EmployeeBirthday;
            parametersAdd[6].Value = model.EmployeeWHCD;
            parametersAdd[7].Value = model.EmployeeHF;
            parametersAdd[8].Value = model.EmployeeJG;
            parametersAdd[9].Value = model.EmployeeXJD;
            parametersAdd[10].Value = model.EmployeeBM;
            parametersAdd[11].Value = model.EmployeeDW;
            parametersAdd[12].Value = model.EmployeeJWBS;
            return SqlHelper.ExecuteSql(Add_SQL, parametersAdd);
        }

        public ReturnValue Search(string EmployeeID)
        {
            SqlParameter[] parametersSearchID = { new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 18) };
            parametersSearchID[0].Value = EmployeeID;
            return SqlHelper.Query(SearchEmployeeID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Employee model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeSex", SqlDbType.NVarChar,1),
					new SqlParameter("@EmployeeBirthday", SqlDbType.NVarChar,8),
					new SqlParameter("@EmployeeWHCD", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeHF", SqlDbType.NVarChar,1),
					new SqlParameter("@EmployeeJG", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeXJD", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeBM", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeDW", SqlDbType.NVarChar,200),
					new SqlParameter("@EmployeeJWBS", SqlDbType.NVarChar,1024)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.EmployeeName;
            parametersUpdate[4].Value = model.EmployeeSex;
            parametersUpdate[5].Value = model.EmployeeBirthday;
            parametersUpdate[6].Value = model.EmployeeWHCD;
            parametersUpdate[7].Value = model.EmployeeHF;
            parametersUpdate[8].Value = model.EmployeeJG;
            parametersUpdate[9].Value = model.EmployeeXJD;
            parametersUpdate[10].Value = model.EmployeeBM;
            parametersUpdate[11].Value = model.EmployeeDW;
            parametersUpdate[12].Value = model.EmployeeJWBS;
            return SqlHelper.ExecuteSql(UpdateEmployee_SQL, parametersUpdate);
        }

        public ReturnValue GetList(string strWhere)
        {
            return SqlHelper.Query(Search_SQL + strWhere);
        }

        public ReturnValue SearchAllInfo(string EmployeeID, string YearMonth)
        {
            SqlParameter[] parameters = { 
                new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 18),
                new SqlParameter("@YearMonth", SqlDbType.NVarChar, 6)};
            parameters[0].Value = EmployeeID;
            parameters[1].Value = YearMonth;
            return SqlHelper.Query(SearchAll_SQL, parameters);
        }

        public ReturnValue SearchMyInfo(string EmployeeGZID, string YearMonth)
        {
            SqlParameter[] parameters = { 
                new SqlParameter("@EmployeeGZID", SqlDbType.NVarChar, 8),
                new SqlParameter("@YearMonth", SqlDbType.NVarChar, 6)};
            parameters[0].Value = EmployeeGZID;
            parameters[1].Value = YearMonth;
            return SqlHelper.Query(SearchMyInfo_SQL, parameters);
        }

        public ReturnValue GetEmployeeInfo(string EmployeeID)
        {
            SqlParameter[] parametersSearchID = { new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 18) };
            parametersSearchID[0].Value = EmployeeID;
            return SqlHelper.Query(GetEmployeeInfo_SQL, parametersSearchID);
        }

        public ReturnValue ChangePassWord(Employee model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar),
					new SqlParameter("@EmployeePWD", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeeEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@EmployeePhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeNewPWD;
            parametersUpdate[3].Value = model.EmployeeEmail;
            parametersUpdate[4].Value = model.EmployeePhone;
            parametersUpdate[5].Value = model.EmployeeID;
            return SqlHelper.ExecuteSql(UpdateEmployeePWD, parametersUpdate);
        }

        public ReturnValue GetCheckEmployeeNum(string YearMonth,string strWhere)
        {
            throw new NotImplementedException();
        }
    }
}
