using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControlEmployeeInfo : System.Web.UI.UserControl
{
    #region 变量定义

    //**********概要信息*****************
    public string strName = string.Empty;//姓名
    public string strEmployeeGZID = string.Empty;//工资编号
    public string strEmployeeID = string.Empty;//员工身份证
    public string strSex = string.Empty;//性别
    public string strBirthday = string.Empty;//出生年月
    public string strAge = string.Empty;//年龄
    public string strEmployeeWHCD = string.Empty;//文化程度
    public string strHF = string.Empty;//婚否
    public string strJG = string.Empty;//籍贯
    public string strXJD = string.Empty;//现住地
    public string strBM = string.Empty;//部门
    public string strDW = string.Empty;//单位
    public string strJWBS = string.Empty;//既往病史
    public string strEmail = string.Empty;//Email
    public string strEmployeePhone = string.Empty;//联系电话
    //**********生化检验单*****************
    public string strHY_No = string.Empty;//化验号
    public string strHY_Dr = string.Empty;//医师
    public string strHY_TC = string.Empty;//总胆固醇(TC)
    public string strHY_TG = string.Empty;//甘油三脂(TG)
    public string strHY_HDL_C = string.Empty;//高密度脂蛋白胆固醇(HDL-C)
    public string strHY_TBIL = string.Empty;//总胆红素(TBIL)
    public string strHY_DBIL = string.Empty;//直接胆红素(DBIL)
    public string strHY_TP = string.Empty;//总蛋白(TP)
    public string strHY_ALB = string.Empty;//白蛋白(ALB)
    public string strHY_ALT = string.Empty;//谷丙转氨酶(ALT)
    public string strGLU = string.Empty;//血糖
    public string strUREA = string.Empty;//尿素
    public string strCR = string.Empty;//肌酐
    public string strAFP = string.Empty;//甲胎蛋白
    public string strCEA = string.Empty;//癌胚抗原
    public string strHBsAg = string.Empty;//HBsAg
    public string strHBsAb = string.Empty;//HBsAb
    public string strHBeAg = string.Empty;//HBeAg
    public string strHBeAb = string.Empty;//HBeAb
    public string strHBcAb = string.Empty;//HBcAb
    //**********体格检查（五官）*****************
    public string strLeftEye = string.Empty;//视力左
    public string strRightEye = string.Empty;//视力右
    public string strCorrectedLeft = string.Empty;//矫正视力左
    public string strCorrectedRight = string.Empty;//矫正视力右
    public string strColorVisionForce = string.Empty;//辨色力
    public string strTrachomaLeft = string.Empty;//沙眼左
    public string strTrachomaRight = string.Empty;//沙眼右
    public string strOtherEye = string.Empty;//眼其他
    public string strListeningLeft = string.Empty;//听力左
    public string strListeningRight = string.Empty;//听力右
    public string strEar = string.Empty;//耳疾
    public string strOlfactory = string.Empty;//嗅觉
    public string strNoseParanasalSinusDisease = string.Empty;//鼻及鼻窦疾病
    public string strThroat = string.Empty;//咽喉
    public string strLipPalate = string.Empty;//唇腭
    public string strStuttering = string.Empty;//口吃
    public string strCaries = string.Empty;//龋齿
    public string strMissingTeeth = string.Empty;//缺齿
    public string strPeriodontalDisease = string.Empty;//牙周病
    public string strFeaturesOther = string.Empty;//其他
    public string strMedicalAdvice = string.Empty;//医生意见
    public string strFeaturesPhysicians = string.Empty;//医师
    //**********体格检查（外科）*****************
    public string strLength = string.Empty;//身长
    public string strBust = string.Empty;//胸围
    public string strWeight = string.Empty;//体重
    public string strBadBreath = string.Empty;//呼吸差
    public string strSkin = string.Empty;//皮肤
    public string strLymphoid = string.Empty;//淋巴
    public string strThyroid = string.Empty;//甲状腺
    public string strSpine = string.Empty;//脊柱
    public string strLimbs = string.Empty;//四肢
    public string strJoint = string.Empty;//关节
    public string strFlatfoot = string.Empty;//扁平足
    public string strGenitourinary = string.Empty;//泌尿生殖器
    public string strAnal = string.Empty;//肛门
    public string strHernia = string.Empty;//疝
    public string strSurgeryOther = string.Empty;//其他
    public string strSurgeryMedicalAdvice = string.Empty;//医生意见
    public string strSurgeryPhysicians = string.Empty;//医师
    //**********体格检查（内科）*****************
    public string strBloodPressure = string.Empty;//血压1
    public string strBloodPressure1 = string.Empty;//血压2
    public string strDevelopmentStatus = string.Empty;//发育及营养状况
    public string strNeurological = string.Empty;//神经及精神
    public string strLung = string.Empty;//肺及呼吸道
    public string strHeartBlood = string.Empty;//心脏及血管
    public string strAbdominalOrgans = string.Empty;//腹部器官
    public string strLiver = string.Empty;//肝
    public string strSpleen = string.Empty;//脾
    public string strInternalMedicineOther = string.Empty;//其他
    public string strInternalMedicineMedicalAdvice = string.Empty;//医生意见
    public string strInternalMedicinePhysicians = string.Empty;//医师
    //**********心电图检查*****************
    public string strECGNo = string.Empty;//心电图号
    public string strClinicalDiagnosis = string.Empty;//临床诊断
    public string strUsedDrugs = string.Empty;//曾用药物
    public string strSummaryHistory = string.Empty;//病史概要
    public string strSummaryBody = string.Empty;//查体概要
    public string strPatientSituation = string.Empty;//病人状况
    public string txtECGMedicalAdvice = string.Empty;//诊断意见
    public string strECGPhysicians = string.Empty;//医师
    //**********X线检查*****************
    public string strPhotoNo = string.Empty;//摄影号
    public string strSymptoms = string.Empty;//主要症状
    public string strLaboratory = string.Empty;//体征及化验检查
    public string strDiagnosis = string.Empty;//临床预诊
    public string strPerspective = string.Empty;//透视部位及目的
    public string strCamera = string.Empty;//照相部位及目的
    public string strXRayResults = string.Empty;//透视检查结果
    public string strXRayPhysicians = string.Empty;//医师
    //**********B超检查*****************
    public string strBID = string.Empty;//B超编号
    public string strHistorySigns = string.Empty;//病史及体征
    public string strLaboratoryExamination = string.Empty;//化验检查
    public string strBDiagnosis = string.Empty;//临床预诊
    public string strPurpose = string.Empty;//检查目的和部位
    public string strBResults = string.Empty;//检查结果
    public string strBPhysicians = string.Empty;//医师
    //**********妇科检查*****************
    public string strFeme_Menarche = string.Empty;//月经初潮
    public string strFeme_MenopauseAge = string.Empty;//绝经年龄
    public string strFeme_MenstrualCycle = string.Empty;//周期
    public string strFeme_MenstrualVolume = string.Empty;//量
    public string strFeme_Dysmenorrhea = string.Empty;//痛经
    public string strFeme_DiseaseHistory = string.Empty;//病史 DiseaseHistory
    public string strFeme_FamilyTumorTistory = string.Empty;//病史家庭肿瘤史
    public string strFeme_DiseaseHistoryOther = string.Empty;//病史其他
    public string strFeme_AndrogenUsed = string.Empty;//曾用雄性激素
    public string strFeme_EstrogenUsed = string.Empty;//曾用雌性激素
    public string strFeme_Cervical = string.Empty;//宫颈 Cervical
    public string strFeme_Uterine = string.Empty;//子宫 Uterine
    public string strFeme_Genital = string.Empty;//外阴 Genital
    public string strFeme_Leucorrhea = string.Empty;//白带 Leucorrhea
    public string strFeme_Vaginal = string.Empty;//阴道 Vaginal
    public string strFeme_AnnexLeft = string.Empty;//附件左 AnnexLeft
    public string strFeme_AnnexRight = string.Empty;//附件右 AnnexRight
    public string strFeme_CheckCases = string.Empty;//病例检查
    public string strFeme_InfraredScanBreast = string.Empty;//乳腺红外线扫描
    public string strFeme_Conclusion = string.Empty;//结论
    public string strFeme_Physicians = string.Empty;//医师
    //**********体成分*****************
    public string strFatType = string.Empty;//腹部肥胖/综合评价
    public string strFatEvaluate = string.Empty;//评估
    public string strFatTarget = string.Empty;//调节目标脂肪重量
    public string strMuscleTarget = string.Empty;//调节目标肌肉重量
    public string strBodyWeightTarget = string.Empty;//调节目标体重
    public string strCompositionPhysicians = string.Empty;//医师
    //**********报告*****************
    public string strChestPerspective = string.Empty;//体检结论
    public string strReview = string.Empty;//建议
    public string strRemarks = string.Empty;//备注

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDepYearMonth();
        }
        try
        {
            if (Request.QueryString["FromType"] == "UI")
            {
                E001.Style.Remove("width");
                E001.Style.Add("width","600");
                E002.Style.Remove("width");
                E002.Style.Add("width", "600");
                E003.Style.Remove("width");
                E003.Style.Add("width", "600");
                E004.Style.Remove("width");
                E004.Style.Add("width", "600");
                E005.Style.Remove("width");
                E005.Style.Add("width", "600");
                E006.Style.Remove("width");
                E006.Style.Add("width", "600");
                E007.Style.Remove("width");
                E007.Style.Add("width", "600");
                string UserID = Request.QueryString["UserID"];
                string YearMonth = Request.QueryString["YearMonth"];
                drpYearMonth.SelectedValue = YearMonth;
                drpYearMonth.Enabled = false;
                ShowData(UserID, YearMonth);
            }
            else if (Session["LoginUserID"] == null || Session["LoginUserID"].ToString() == "")
            {
                Response.Redirect("MyLogin.aspx");
            }
            else if (!IsPostBack)
            {
                string UserID = Session["LoginUserID"].ToString();
                string YearMonth = drpYearMonth.SelectedValue;
                ShowData(UserID, YearMonth);
            }
        }
        catch
        {
            Response.Redirect("MyLogin.aspx");
        }
    }

    private void SetDepYearMonth()
    {
        XTHospital.COM.ReturnValue resoult = null;
        //Hashtable YearMonthHashTable = new Hashtable();
        XTHospital.BLL.BLL_LoginUser bll = new XTHospital.BLL.BLL_LoginUser();
        try
        {
            resoult = bll.GetYearMonth();
        }
        catch
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        if (resoult.ErrorFlag)
        {
            //YearMonthHashTable.Clear();
            //for (int i = 0; i < resoult.ResultDataSet.Tables[0].Rows.Count; i++)
            //{
            //    YearMonthHashTable.Add(resoult.ResultDataSet.Tables[0].Rows[i]["SelectYearMonthValue"].ToString(), resoult.ResultDataSet.Tables[0].Rows[i]["SelectYearMonth"].ToString());
            //}
            this.drpYearMonth.DataSource = resoult.ResultDataSet.Tables[0];
            this.drpYearMonth.DataTextField = "SelectYearMonthValue";
            this.drpYearMonth.DataValueField = "SelectYearMonthValue";
            this.drpYearMonth.DataBind();
        }
        else
        {
            LiteralMsg.Text = resoult.ErrorID;
            LiteralMsg.DataBind();
        }
    }

    private void ShowData(string LoginUserID, string YearMonth)
    {
        XTHospital.BLL.BLL_Employee bll = new XTHospital.BLL.BLL_Employee();
        XTHospital.COM.ReturnValue resoult = bll.SearchMyInfo(LoginUserID, YearMonth);
        if (resoult.ErrorFlag)
        {
            if (resoult.Count > 0)
            {
                #region **********概要信息*****************
                strName = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeName"].ToString();//姓名
                strEmployeeGZID = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeGZID"].ToString(); ;//工资编号
                strEmployeeID = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeID"].ToString();//员工身份证
                string strSexTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeSex"].ToString();//性别
                if (strSexTemp == "0")
                {
                    strSex = "男";
                }
                else if (strSexTemp == "1")
                {
                    strSex = "女";
                }
                else
                {
                    strSex = "";
                }
                string strBirthdayTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBirthday"].ToString();//出生年月
                if (strBirthdayTemp.Length > 0)
                {
                    strBirthday = strBirthdayTemp.Substring(0, 4) + "-" + strBirthdayTemp.Substring(4, 2) + "-" + strBirthdayTemp.Substring(6, 2);
                }
                strAge = GetAge(DateTime.Parse(strBirthday)).ToString();
                strEmployeeWHCD = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeWHCD"].ToString();//文化程度
                string strHFTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeHF"].ToString();//婚否
                if (strHFTemp == "0")
                {
                    strHF = "未婚";
                }
                else if (strHFTemp == "1")
                {
                    strHF = "已婚";
                }
                else if (strHFTemp == "2")
                {
                    strHF = "离异";
                }
                else
                {
                    strHF = "";
                }
                strJG = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJG"].ToString();//籍贯
                strXJD = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeXJD"].ToString();//现住地
                strBM = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBM"].ToString();//部门
                strDW = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeDW"].ToString();//单位
                strJWBS = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJWBS"].ToString();//既往病史
                strEmail = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString();//Email
                strEmployeePhone = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePhone"].ToString();//联系电话
                #endregion

                #region **********生化检验单*****************
                strHY_No = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYNo"].ToString();//化验号
                strHY_Dr = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYDr"].ToString();//医师
                strHY_TC = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTC"].ToString();//总胆固醇(TC)
                strHY_TG = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTG"].ToString();//甘油三脂(TG)
                strHY_HDL_C = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHDLC"].ToString();//高密度脂蛋白胆固醇(HDL-C)
                strHY_TBIL = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTBIL"].ToString();//总胆红素(TBIL)
                strHY_DBIL = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYDBIL"].ToString();//直接胆红素(DBIL)
                strHY_TP = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTP"].ToString();//总蛋白(TP)
                strHY_ALB = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALB"].ToString();//白蛋白(ALB)
                strHY_ALT = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALT"].ToString();//谷丙转氨酶(ALT)
                strGLU = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_GLU"].ToString();//血糖
                strUREA = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_UREA"].ToString();//尿素
                strCR = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CR"].ToString();//肌酐
                strAFP = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_AFP"].ToString();//甲胎蛋白
                strCEA = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CEA"].ToString();//癌胚抗原
                if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAg"].ToString() == "0")//HBsAg
                {
                    strHBsAg = "-";
                }
                else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAg"].ToString() == "1")//HBsAg
                {
                    strHBsAg = "+";
                }
                else
                {
                    strHBsAg = "";
                }
                if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAb"].ToString() == "0")//HBsAb
                {
                    strHBsAb = "-";
                }
                else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAb"].ToString() == "1")//HBsAb
                {
                    strHBsAb = "+";
                }
                else
                {
                    strHBsAb = "";
                }
                if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAg"].ToString() == "0")//HBeAg
                {
                    strHBeAg = "-";
                }
                else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAg"].ToString() == "1")//HBeAg
                {
                    strHBeAg = "+";
                }
                else
                {
                    strHBeAg = "";
                }
                if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAb"].ToString() == "0")//HBeAb
                {
                    strHBeAb = "-";
                }
                else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAb"].ToString() == "1")//HBeAb
                {
                    strHBeAb = "+";
                }
                else
                {
                    strHBeAb = "";
                }
                if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBcAb"].ToString() == "0")//HBcAb
                {
                    strHBcAb = "-";
                }
                else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBcAb"].ToString() == "1")//HBcAb
                {
                    strHBcAb = "+";
                }
                else
                {
                    strHBcAb = "";
                }
                #endregion

                #region **********体格检查（五官）*****************
                strLeftEye = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LeftEye"].ToString();//视力左
                strRightEye = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_RightEye"].ToString();//视力右
                strCorrectedLeft = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedLeft"].ToString();//矫正视力左
                strCorrectedRight = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedRight"].ToString();//矫正视力右
                strColorVisionForce = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ColorVisionForce"].ToString();//辨色力
                strTrachomaLeft = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaLeft"].ToString();//沙眼左
                strTrachomaRight = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaRight"].ToString();//沙眼右
                strOtherEye = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_OtherEye"].ToString();//眼其他
                strListeningLeft = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningLeft"].ToString();//听力左
                strListeningRight = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningRight"].ToString();//听力右
                strEar = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Ear"].ToString();//耳疾
                strOlfactory = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Olfactory"].ToString();//嗅觉
                strNoseParanasalSinusDisease = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_NoseParanasalSinusDisease"].ToString();//鼻及鼻窦疾病
                strThroat = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Throat"].ToString();//咽喉
                strLipPalate = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LipPalate"].ToString();//唇腭
                strStuttering = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Stuttering"].ToString();//口吃
                strCaries = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Caries"].ToString();//龋齿
                strMissingTeeth = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MissingTeeth"].ToString();//缺齿
                strPeriodontalDisease = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_PeriodontalDisease"].ToString();//牙周病
                strFeaturesOther = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Other"].ToString();//其他
                strMedicalAdvice = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MedicalAdvice"].ToString();//医生意见
                strFeaturesPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Physicians"].ToString();//医师
                #endregion

                #region **********体格检查（外科）*****************
                strLength = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Length"].ToString();//身长
                strBust = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Bust"].ToString();//胸围
                strWeight = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Weight"].ToString();//体重
                strBadBreath = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_BadBreath"].ToString();//呼吸差
                strSkin = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Skin"].ToString();//皮肤
                strLymphoid = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Lymphoid"].ToString();//淋巴
                strThyroid = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Thyroid"].ToString();//甲状腺
                strSpine = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Spine"].ToString();//脊柱
                strLimbs = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Limbs"].ToString();//四肢
                strJoint = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Joint"].ToString();//关节
                strFlatfoot = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Flatfoot"].ToString();//扁平足
                strGenitourinary = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Genitourinary"].ToString();//泌尿生殖器
                strAnal = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Anal"].ToString();//肛门
                strHernia = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Hernia"].ToString();//疝
                strSurgeryOther = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Other"].ToString();//其他
                strSurgeryMedicalAdvice = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_MedicalAdvice"].ToString();//医生意见
                strSurgeryPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Physicians"].ToString();//医师
                #endregion

                #region **********体格检查（内科）*****************
                strBloodPressure = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure"].ToString();//血压
                strBloodPressure1 = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure1"].ToString();//血压
                strDevelopmentStatus = resoult.ResultDataSet.Tables[0].Rows[0]["Int_DevelopmentStatus"].ToString();//发育及营养状况
                strNeurological = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Neurological"].ToString();//神经及精神
                strLung = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Lung"].ToString();//肺及呼吸道
                strHeartBlood = resoult.ResultDataSet.Tables[0].Rows[0]["Int_HeartBlood"].ToString();//心脏及血管
                strAbdominalOrgans = resoult.ResultDataSet.Tables[0].Rows[0]["Int_AbdominalOrgans"].ToString();//腹部器官
                strLiver = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Liver"].ToString();//肝
                strSpleen = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Spleen"].ToString();//脾
                strInternalMedicineOther = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Other"].ToString();//其他
                strInternalMedicineMedicalAdvice = resoult.ResultDataSet.Tables[0].Rows[0]["Int_MedicalAdvice"].ToString();//医生意见
                strInternalMedicinePhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Physicians"].ToString();//医师
                #endregion

                #region **********心电图检查*****************
                strECGNo = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_No"].ToString();//心电图号
                strClinicalDiagnosis = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_ClinicalDiagnosis"].ToString();//临床诊断
                strUsedDrugs = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_UsedDrugs"].ToString();//曾用药物
                strSummaryHistory = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryHistory"].ToString();//病史概要
                strSummaryBody = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryBody"].ToString();//查体概要
                strPatientSituation = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_PatientSituation"].ToString();//病人状况
                if (strPatientSituation == "1")
                {
                    strPatientSituation = "卧床";
                }
                else if (strPatientSituation == "2")
                {
                    strPatientSituation = "能走";
                }
                else
                {
                    strPatientSituation = "";
                }
                txtECGMedicalAdvice = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_MedicalAdvice"].ToString();//诊断意见
                //if (resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"] != DBNull.Value)
                //{
                //    MemoryStream msECG = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"]);
                //    Image imageECG = Image.FromStream(msECG, true);
                //    this.picECG.Image = imageECG;
                //}
                //else
                //{
                //    this.picECG.Image = null;
                //}
                strECGPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Physicians"].ToString();//医师
                #endregion

                #region **********X线检查*****************
                strPhotoNo = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_PhotoNo"].ToString();//摄影号
                strSymptoms = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Symptoms"].ToString();//主要症状
                strLaboratory = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Laboratory"].ToString();//体征及化验检查
                strDiagnosis = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Diagnosis"].ToString();//临床预诊
                strPerspective = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Perspective"].ToString();//透视部位及目的
                strCamera = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Camera"].ToString();//照相部位及目的
                strXRayResults = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Results"].ToString();//透视检查结果

                //if (resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"] != DBNull.Value)
                //{
                //    MemoryStream msXray = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"]);
                //    Image imageXray = Image.FromStream(msXray, true);
                //    this.picXImage.Image = imageXray;
                //}
                //else
                //{
                //    this.picXImage.Image = null;
                //}
                strXRayPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Physicians"].ToString();//医师
                #endregion

                #region **********B超检查*****************
                strBID = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BID"].ToString();//B超编号
                strHistorySigns = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_HistorySigns"].ToString();//病史及体征
                strLaboratoryExamination = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_LaboratoryExamination"].ToString();//化验检查
                strBDiagnosis = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Diagnosis"].ToString();//临床预诊
                strPurpose = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Purpose"].ToString();//检查目的和部位
                strBResults = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Results"].ToString();//检查结果
                //if (resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"] != DBNull.Value)
                //{
                //    MemoryStream msBex = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"]);
                //    Image imageBex = Image.FromStream(msBex, true);
                //    this.picBImage.Image = imageBex;
                //}
                //else
                //{
                //    this.picBImage.Image = null;
                //}
                strBPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Physicians"].ToString();//医师
                #endregion

                #region **********妇科检查*****************

                if (strSexTemp == "1")
                {
                    E006.Visible = true;
                    strFeme_Menarche = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Menarche"].ToString();//月经初潮
                    strFeme_MenopauseAge = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenopauseAge"].ToString();//绝经年龄
                    string strMenstrualCycleTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenstrualCycle"].ToString();//周期 MenstrualCycle
                    if (strMenstrualCycleTemp.Trim() == "0")
                    {
                        strFeme_MenstrualCycle = "规律";
                    }
                    else if (strMenstrualCycleTemp.Trim() == "1")
                    {
                        strFeme_MenstrualCycle = "不规律";
                    }
                    else
                    {
                        strFeme_MenstrualCycle = "";
                    }
                    string strMenstrualVolumeTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenstrualVolume"].ToString();//量 MenstrualVolume
                    if (strMenstrualVolumeTemp.Trim() == "0")
                    {
                        strFeme_MenstrualVolume = "多";
                    }
                    else if (strMenstrualVolumeTemp.Trim() == "1")
                    {
                        strFeme_MenstrualVolume = "中";
                    }
                    else if (strMenstrualVolumeTemp.Trim() == "2")
                    {
                        strFeme_MenstrualVolume = "少";
                    }
                    else
                    {
                        strFeme_MenstrualVolume = "";
                    }
                    string strDysmenorrheaTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Dysmenorrhea"].ToString();//痛经 Dysmenorrhea
                    if (strDysmenorrheaTemp.Trim() == "0")
                    {
                        strFeme_Dysmenorrhea = "无";
                    }
                    else if (strDysmenorrheaTemp.Trim() == "1")
                    {
                        strFeme_Dysmenorrhea = "轻";
                    }
                    else if (strDysmenorrheaTemp.Trim() == "2")
                    {
                        strFeme_Dysmenorrhea = "重";
                    }
                    else
                    {
                        strFeme_Dysmenorrhea = "";
                    }
                    strFeme_DiseaseHistory = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_DiseaseHistory"].ToString();//病史 DiseaseHistory
                    string strFamilyTumorTistoryTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_FamilyTumorTistory"].ToString();//病史家庭肿瘤史 FamilyTumorTistory
                    if (strFamilyTumorTistoryTemp.Trim() == "0")
                    {
                        strFeme_FamilyTumorTistory = "无";
                    }
                    else if (strFamilyTumorTistoryTemp.Trim() == "1")
                    {
                        strFeme_FamilyTumorTistory = "有";
                    }
                    else
                    {
                        strFeme_FamilyTumorTistory = "";
                    }
                    strFeme_DiseaseHistoryOther = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_DiseaseHistoryOther"].ToString();//病史其他
                    string strAndrogenUsedTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AndrogenUsed"].ToString();//曾用雄性激素 AndrogenUsed
                    if (strAndrogenUsedTemp.Trim() == "0")
                    {
                        strFeme_AndrogenUsed = "无";
                    }
                    else if (strAndrogenUsedTemp.Trim() == "1")
                    {
                        strFeme_AndrogenUsed = "短期";
                    }
                    else if (strAndrogenUsedTemp.Trim() == "2")
                    {
                        strFeme_AndrogenUsed = "长期";
                    }
                    else
                    {
                        strFeme_AndrogenUsed = "";
                    }
                    string strEstrogenUsedTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_EstrogenUsed"].ToString();//曾用雌性激素 EstrogenUsed
                    if (strEstrogenUsedTemp.Trim() == "0")
                    {
                        strFeme_EstrogenUsed = "无";
                    }
                    else if (strEstrogenUsedTemp.Trim() == "1")
                    {
                        strFeme_EstrogenUsed = "短期";
                    }
                    else if (strEstrogenUsedTemp.Trim() == "2")
                    {
                        strFeme_EstrogenUsed = "长期";
                    }
                    else
                    {
                        strFeme_EstrogenUsed = "";
                    }
                    strFeme_Cervical = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Cervical"].ToString();//宫颈 Cervical
                    strFeme_Uterine = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Uterine"].ToString();//子宫 Uterine
                    strFeme_Genital = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Genital"].ToString();//外阴 Genital
                    strFeme_Leucorrhea = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Leucorrhea"].ToString();//白带 Leucorrhea
                    strFeme_Vaginal = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Vaginal"].ToString();//阴道 Vaginal
                    strFeme_AnnexLeft = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AnnexLeft"].ToString();//附件左 AnnexLeft
                    strFeme_AnnexRight = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AnnexRight"].ToString();//附件右 AnnexRight
                    strFeme_CheckCases = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_CheckCases"].ToString();//病例检查
                    strFeme_InfraredScanBreast = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_InfraredScanBreast"].ToString();//乳腺红外线扫描
                    strFeme_Conclusion = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Conclusion"].ToString();//结论
                    strFeme_Physicians = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Physicians"].ToString();//医师
                }
                else
                {
                    E006.Visible = false;
                }

                #endregion

                #region

                //**********体成分*****************
                string FatType = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatType"].ToString();
                string FatEvaluate = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatEvaluate"].ToString();
                //1：皮下型 2：内脏型
                switch (FatType)
                {
                    case "1":
                        strFatType = "皮下型";
                        break;
                    case "2":
                        strFatType = "内脏型";
                        break;
                }
                //1：很瘦 2：偏瘦 3：标准 4：低脂肪肌肉型 5：超重 6：肌肉型 7：脂肪过多型 8：肥胖 9：严重肥胖
                switch (FatEvaluate)
                {
                    case "1":
                        strFatEvaluate = "很瘦";
                        break;
                    case "2":
                        strFatEvaluate = "偏瘦";
                        break;
                    case "3":
                        strFatEvaluate = "标准";
                        break;
                    case "4":
                        strFatEvaluate = "低脂肪肌肉型";
                        break;
                    case "5":
                        strFatEvaluate = "超重";
                        break;
                    case "6":
                        strFatEvaluate = "肌肉型";
                        break;
                    case "7":
                        strFatEvaluate = "脂肪过多型";
                        break;
                    case "8":
                        strFatEvaluate = "肥胖";
                        break;
                    case "9":
                        strFatEvaluate = "严重肥胖";
                        break;
                }

                strFatTarget = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatTarget"].ToString();
                strMuscleTarget = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_MuscleTarget"].ToString();
                strBodyWeightTarget = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_BodyWeightTarget"].ToString();
                strCompositionPhysicians = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_Physicians"].ToString();

                #endregion

                #region **********报告*****************
                strChestPerspective = resoult.ResultDataSet.Tables[0].Rows[0]["ChestPerspective"].ToString();//（胸部透视）体检结论
                //strReportLaboratory = resoult.ResultDataSet.Tables[0].Rows[0]["Laboratory"].ToString();//化验(肝功、乙肝系列)
                strReview = resoult.ResultDataSet.Tables[0].Rows[0]["Review"].ToString();//（审查单位意见）建议
                strRemarks = resoult.ResultDataSet.Tables[0].Rows[0]["Remarks"].ToString();//备注
                #endregion
            }
        }
    }

    public int GetAge(DateTime birthday)
    {
        DateTime now = DateTime.Now;
        int age = 0;
        if (birthday > now)
        {
            age = -1;
        }
        else
        {
            age = now.Year - birthday.Year - 1;
            if (now.Month > birthday.Month)
            {
                age = age + 1;
            }
            else if (now.Month == birthday.Month)
            {
                if (now.Day >= birthday.Day)
                {
                    age = age + 1;
                }
            }
        }
        return age;
    }

    //更改体检月年时
    protected void drpYearMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        string YearMonth = drpYearMonth.SelectedValue;
        string UserID = Session["LoginUserID"].ToString();
        ShowData(UserID, YearMonth);
    }
}