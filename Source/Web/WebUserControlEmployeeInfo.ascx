<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlEmployeeInfo.ascx.cs" Inherits="WebUserControlEmployeeInfo" %>
    <link rel="stylesheet" href="css/screen.css"/>
	<script type="text/javascript" src="Script/JScript.js"></script>
    <script type="text/javascript">
        function printdiv(printpage) {
            window.print();
        }
    </script>
<div id="PDIV">
	<div id="E001" runat="server" class="ContentPrint">
        <table width="100%" border="0">
          <tr>
            <td class="TitleStyle" style="width:235px;">概要信息</td>
            <td colspan="2" valign="bottom" align="right">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="黑体" 
                    Text="体检时间:" Font-Size="18pt" ForeColor="Blue"></asp:Label>
                <asp:DropDownList ID="drpYearMonth" runat="server" Width="120px" AutoPostBack="True" 
                    Font-Bold="True" Font-Names="黑体" 
                    onselectedindexchanged="drpYearMonth_SelectedIndexChanged" 
                    Font-Size="18pt" ForeColor="Blue" />
                &nbsp;<input id="打印" class="BTN" style="width:80px; height:25px; font-size:15pt;" type="button" onclick="printdiv('PDIV')" value="打印" />
            </td>
          </tr>
          <tr>
            <td style="width: 235px">姓名:<span class="ReultStyle"><%=strName%></span></td>
            <td>性别:<span class="ReultStyle"><%=strSex%></span></td>
            <td>婚否:<span class="ReultStyle"><%=strHF%></span></td>
          </tr>
            <tr>
                <td style="width: 235px">出生日期:<span class="ReultStyle"><%=strBirthday%></span>&nbsp;&nbsp;年龄:<span class="ReultStyle"><%=strAge%></span></td>
                <td>联系电话:<span class="ReultStyle"><%=strEmployeePhone%></span></td>
                <td>Email:<span class="ReultStyle"><%=strEmail%></span></td>
            </tr>
          <tr>
            <td style="width: 235px">身份证:<span class="ReultStyle"><%=strEmployeeID%></span></td>
            <td>查询账号:<span class="ReultStyle"><%=strEmployeeGZID%></span></td>
            <td>文化程度:<span class="ReultStyle"><%=strEmployeeWHCD%></span></td>
          </tr>
          <tr>
            <td style="width: 235px">籍贯:<span class="ReultStyle"><%=strJG%></span></td>
            <td colspan="2">现住址:<span class="ReultStyle"><%=strXJD%></span></td>
          </tr>
          <tr>
            <td valign="top">部门:<span class="ReultStyle"><%=strBM%></span></td>
            <td colspan="2" align="left" rowspan="2" valign="top">所在单位:<span class="ReultStyle"><%=strDW%></span></td>
          </tr>
          <tr>
            <td style="width: 235px">既往病史</td>
          </tr>
          <tr>
            <td colspan="3"><span class="ReultStyle"><%=strJWBS%></span></td>
          </tr>
        </table>
    </div>
    
	<div id="E002" runat="server" class="ContentPrint">
        <table width="100%"  border="0">
          <tr>
           <td class="TitleStyle" style="width:35%;">生化检验单</td>
            <td style="width:23%;">&nbsp;</td>
            <td style="width:18%;">&nbsp;医师:<span class="ReultStyle"><%=strHY_Dr%></span></td>
            <td style="width:24%;">&nbsp;</td>
          </tr>
          <tr>
            <td>化验号:<span class="ReultStyle"><%=strHY_No%></span></td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="boldStyle">血脂</td>
            <td>&nbsp;</td>
            <td class="boldStyle">血糖</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>总胆固醇(TC):<span class="ReultStyle"><%=strHY_TC%></span></td>
            <td><%=T_HY_TC%></td>
            <td>血糖(GLU):<span class="ReultStyle"><%=strGLU%></span></td>
            <td><%=T_GLU%></td>
          </tr>
          <tr>
            <td>甘油三酯(TG):<span class="ReultStyle"><%=strHY_TG%></span></td>
            <td><%=T_HY_TG%></td>
            <td class="boldStyle">肾功</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>高密度脂蛋白胆固醇(HDL-C):<span class="ReultStyle"><%=strHY_HDL_C%></span></td>
            <td><%=T_HY_HDL_C%></td>
            <td>尿素(urea):<span class="ReultStyle"><%=strUREA%></span></td>
            <td><%=T_UREA%></td>
          </tr>
          <tr>
            <td>低密度脂蛋白胆固醇(LDL-C):<span class="ReultStyle"><%=strHYLDLC%></span></td>
            <td><%=T_HYLDLC%></td>
            <td>肌酐(Cr):<span class="ReultStyle"><%=strCR%></span></td>
            <td><%=T_CR%></td>
          </tr>
          <tr>
            <td>载脂蛋白AI(APOAI):<span class="ReultStyle"><%=strHYAPOAI%></span></td>
            <td><%=T_HYAPOAI%></td>
            <td>尿酸(UA):<span class="ReultStyle"><%=strHYUA%></span></td>
            <td><%=T_HYUA%></td>
          </tr>
          <tr>
            <td>载脂蛋白B(APOB):<span class="ReultStyle"><%=strHYAPOB%></span></td>
            <td><%=T_HYAPOB%></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="boldStyle">肝功</td>
            <td>&nbsp;</td>
            <td class="boldStyle">防癌</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>总胆红素(TBIL):<span class="ReultStyle"><%=strHY_TBIL%></span></td>
            <td><%=T_HY_TBIL%></td>
            <td>甲胎蛋白(AFP):<span class="ReultStyle"><%=strAFP%></span></td>
            <td><%=T_AFP%></td>
          </tr>
          <tr>
            <td>直接胆红素(DBIL):<span class="ReultStyle"><%=strHY_DBIL%></span></td>
            <td><%=T_HY_DBIL%></td>
            <td>癌胚抗原(CEA):<span class="ReultStyle"><%=strCEA%></span></td>
            <td><%=T_CEA%></td>
          </tr>
          <tr>
            <td>总蛋白(TP):<span class="ReultStyle"><%=strHY_TP%></span></td>
            <td><%=T_HY_TP%></td>
            <td></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>白蛋白(ALB):<span class="ReultStyle"><%=strHY_ALB%></span></td>
            <td><%=T_HY_ALB%></td>
            <td></td>
            <td> &nbsp;</td>
          </tr>
          <tr>
            <td>丙氨酸氨基转移酶(ALT):<span class="ReultStyle"><%=strHY_ALT%></span></td>
            <td><%=T_HY_ALT%> </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>天门冬氨酸氨基转移酶(AST):<span class="ReultStyle"><%=strHYAST%></span></td>
            <td><%=T_HYAST%></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>γ-谷胺酰转肽酶(γ-GT):<span class="ReultStyle"><%=strHYGT%></span></td>
            <td colspan="2"><%=T_HYGT%></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>碱性磷酸酶(ALP):<span class="ReultStyle"><%=strHYALP%></span></td>
            <td colspan="2"><%=T_HYALP%></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="boldStyle">乙肝五项</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="4">HBsAg:<span class="ReultStyle"><%=strHBsAg%></span>&nbsp;&nbsp;HBsAb:<span class="ReultStyle"><%=strHBsAb%></span>&nbsp;&nbsp;HBeAg:<span class="ReultStyle"><%=strHBeAg%></span>&nbsp;&nbsp;HBeAb:<span class="ReultStyle"><%=strHBeAb%></span>&nbsp;&nbsp;HBcAb:<span class="ReultStyle"><%=strHBcAb%></span></td>
          </tr>
        </table>
    </div>
    
    <div id="E003" runat="server" class="ContentPrint">
        <table width="100%"  border="0">
          <tr>
            <td class="TitleStyle">体格检查-五官</td>
            <td>&nbsp;</td>
            <td colspan="3">医师:<span class="ReultStyle"><%=strFeaturesPhysicians%></span></td>
          </tr>
          <tr>
            <td  class="boldStyle" style="width:25%">眼</td>
            <td style="width:20%">&nbsp;</td>
            <td style="width:20%">&nbsp;</td>
            <td style="width:20%">&nbsp;</td>
            <td style="width:15%">&nbsp;</td>
          </tr>
          <tr>
            <td>视力:左 <span class="ReultStyle"><%=strLeftEye%></span>&nbsp;&nbsp;右<span class="ReultStyle"><%=strRightEye%></span></td>
            <td>矫正视力:左<span class="ReultStyle"><%=strCorrectedLeft%></span>&nbsp;&nbsp;右<span class="ReultStyle"><%=strCorrectedRight%></span></td>
            <td>辨色力:<span class="ReultStyle"><%=strColorVisionForce%></span></td>
            <td>砂眼:左<span class="ReultStyle"><%=strTrachomaLeft%></span>&nbsp;&nbsp;右<span class="ReultStyle"><%=strTrachomaRight%></span></td>
            <td>其他眼疾:<span class="ReultStyle"><%=strOtherEye%></span></td>
          </tr>
          <tr>
            <td  class="boldStyle">耳</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>听力:左<span class="ReultStyle"><%=strListeningLeft%></span>公尺&nbsp;&nbsp;右<span class="ReultStyle"><%=strListeningRight%></span>公尺</td>
            <td colspan="4">耳疾:<span class="ReultStyle"><%=strEar%></span></td>
          </tr>
          <tr>
            <td  class="boldStyle">鼻</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>嗅觉:<span class="ReultStyle"><%=strOlfactory%></span></td>
            <td colspan="4">鼻及鼻窦疾病:<span class="ReultStyle"><%=strNoseParanasalSinusDisease%></span></td>
          </tr>
          <tr>
            <td class="boldStyle">咽喉、唇腭、口吃</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>咽喉:<span class="ReultStyle"><%=strThroat%></span></td>
            <td>唇腭:<span class="ReultStyle"><%=strLipPalate%></span></td>
            <td colspan="3">口吃:<span class="ReultStyle"><%=strStuttering%></span></td>
          </tr>
          <tr>
            <td class="boldStyle">齿</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>龋齿:<span class="ReultStyle"><%=strCaries%></span></td>
            <td>缺齿:<span class="ReultStyle"><%=strMissingTeeth%></span></td>
            <td colspan="3">牙周病:<span class="ReultStyle"><%=strPeriodontalDisease%></span></td>
          </tr>
          <tr>
            <td colspan="5">其他:<span class="ReultStyle"><%=strFeaturesOther%></span></td>
          </tr>
          <tr>
            <td class="boldStyle">医生意见</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="5"><span class="ReultStyle"><%=strMedicalAdvice%></span></td>
          </tr>
          <tr>
            <td style="color:Blue; font-weight:bold;">体格检查-外科</td>
            <td>&nbsp;</td>
            <td colspan="3">医师:<span class="ReultStyle"><%=strSurgeryPhysicians%></span></td>
          </tr>
          <tr>
            <td>身长:<span class="ReultStyle"><%=strLength%></span>公分</td>
            <td>胸围:<span class="ReultStyle"><%=strBust%></span>公分</td>
            <td colspan="3">体重:<span class="ReultStyle"><%=strWeight%></span>公斤</td>
          </tr>
          <tr>
            <td>呼吸差:<span class="ReultStyle"><%=strBadBreath%></span>公斤</td>
            <td>皮肤:<span class="ReultStyle"><%=strSkin%></span></td>
	        <td colspan="3">淋巴:<span class="ReultStyle"><%=strLymphoid%></span></td>
          </tr>
          <tr>
            <td>甲状腺:<span class="ReultStyle"><%=strThyroid%></span></td>
            <td>脊柱:<span class="ReultStyle"><%=strSpine%></span></td>
            <td colspan="3">四肢:<span class="ReultStyle"><%=strLimbs%></span></td>
          </tr>
          <tr>
            <td>关节:<span class="ReultStyle"><%=strJoint%></span></td>
            <td>扁平足:<span class="ReultStyle"><%=strFlatfoot%></span></td>
            <td colspan="3">泌尿生殖器:<span class="ReultStyle"><%=strGenitourinary%></span></td>
          </tr>
          <tr>
            <td>肛门:<span class="ReultStyle"><%=strAnal%></span></td>
            <td>疝:<span class="ReultStyle"><%=strHernia%></span></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="5">其他:<span class="ReultStyle"><%=strSurgeryOther%></span></td>
          </tr>
          <tr>
            <td>医生意见</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="5"><span class="ReultStyle"><%=strSurgeryMedicalAdvice%></span></td>
          </tr>
          <tr>
            <td style="color:Blue; font-weight:bold;">体格检查-内科</td>
            <td>&nbsp;</td>
            <td colspan="3">医师:<span class="ReultStyle"><%=strInternalMedicinePhysicians%></span></td>
          </tr>
          <tr>
            <td colspan="5">血压:<span class="ReultStyle"><%=strBloodPressure%></span>千帕(kpa)&nbsp;&nbsp;<span class="ReultStyle"><%=strBloodPressure1%></span>毫米汞柱(mmHg)</td>
          </tr>
          <tr>
            <td colspan="5">发育及营养状况:<span class="ReultStyle"><%=strDevelopmentStatus%></span></td>
          </tr>
          <tr>
            <td colspan="5">神经及精神:<span class="ReultStyle"><%=strNeurological%></span></td>
          </tr>
          <tr>
            <td colspan="5">肺及呼吸道:<span class="ReultStyle"><%=strLung%></span></td>
          </tr>
          <tr>
            <td colspan="5">心脏及血管:<span class="ReultStyle"><%=strHeartBlood%></span></td>
          </tr>
          <tr>
            <td colspan="5">腹部器官:<span class="ReultStyle"><%=strAbdominalOrgans%></span></td>
          </tr>
          <tr>
            <td colspan="2">肝:<span class="ReultStyle"><%=strLiver%></span></td>
            <td colspan="3">脾:<span class="ReultStyle"><%=strSpleen%></span></td>
          </tr>
          <tr>
            <td colspan="5">其他:<span class="ReultStyle"><%=strInternalMedicineOther%></span></td>
          </tr>
          <tr>
            <td>医生意见</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="5"><span class="ReultStyle"><%=strInternalMedicineMedicalAdvice%></span></td>
          </tr>
        </table>
    </div>
    
    <div id="E004" runat="server" class="ContentPrint">
        <table width="100%"  border="0">
          <tr>
            <td class="TitleStyle" style="width:50%;">心电图检查</td>
            <td style="width:50%;">&nbsp;</td>
          </tr>
          <tr>
            <td>心电图号:<span class="ReultStyle"><%=strECGNo%></span></td>
            <td>医师:<span class="ReultStyle"><%=strECGPhysicians%></span></td>
          </tr>
          <tr>
            <td colspan="2">临床诊断:<span class="ReultStyle"><%=strClinicalDiagnosis%></span></td>
          </tr>
          <tr>
            <td colspan="2">曾用药物:<span class="ReultStyle"><%=strUsedDrugs%></span></td>
          </tr>
          <tr>
            <td colspan="2">病史概要:<span class="ReultStyle"><%=strSummaryHistory%></span></td>
          </tr>
          <tr>
            <td colspan="2">查体概要:<span class="ReultStyle"><%=strSummaryBody%></span></td>
          </tr>
          <tr>
            <td colspan="2">病人状况:<span class="ReultStyle"><%=strPatientSituation%></span></td>
          </tr>
          <tr>
            <td colspan="2">诊断意见</td>
          </tr>
          <tr>
            <td colspan="2"><span class="ReultStyle"><%=txtECGMedicalAdvice%></span></td>
          </tr>
          <tr>
            <td style="color:Blue; font-weight:bold;">X线检查</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>摄影号:<span class="ReultStyle"><%=strPhotoNo%></span></td>
            <td>医师:<span class="ReultStyle"><%=strXRayPhysicians%></span></td>
          </tr>
          <tr>
            <td colspan="2">主要症状:<span class="ReultStyle"><%=strSymptoms%></span></td>
          </tr>
          <tr>
            <td colspan="2">体征及化验检查:<span class="ReultStyle"><%=strLaboratory%></span></td>
          </tr>
          <tr>
            <td colspan="2">临床预诊:<span class="ReultStyle"><%=strDiagnosis%></span></td>
          </tr>
          <tr>
            <td colspan="2">透视部位及目的:<span class="ReultStyle"><%=strPerspective%></span></td>
          </tr>
          <tr>
            <td colspan="2">照相部位及目的:<span class="ReultStyle"><%=strCamera%></span></td>
          </tr>
          <tr>
            <td colspan="2">检查结果</td>
          </tr>
          <tr>
            <td colspan="2"><span class="ReultStyle"><%=strXRayResults%></span></td>
          </tr>
          <tr>
            <td style="color:Blue; font-weight:bold;">B超检查</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>B超编号:<span class="ReultStyle"><%=strBID%></span></td>
            <td>医师:<span class="ReultStyle"><%=strBPhysicians%></span></td>
          </tr>
          <tr>
            <td colspan="2">病史及体征:<span class="ReultStyle"><%=strHistorySigns%></span></td>
          </tr>
          <tr>
            <td colspan="2">化验检查:<span class="ReultStyle"><%=strLaboratoryExamination%></span></td>
          </tr>
          <tr>
            <td colspan="2">临床预诊:<span class="ReultStyle"><%=strBDiagnosis%></span></td>
          </tr>
          <tr>
            <td colspan="2">检查目的和部位:<span class="ReultStyle"><%=strPurpose%></span></td>
          </tr>
          <tr>
            <td>检查结果</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="2"><span class="ReultStyle"><%=strBResults%></span></td>
          </tr>
        </table>
    </div>

    <div id="E005" runat="server" class="ContentPrint">
        <table width="100%"  border="0">
          <tr>
            <td class="TitleStyle" style="width:50%;">体成分分析</td>
          </tr>
          <tr>
            <td>腹部肥胖/综合评价:<span class="ReultStyle"><%=strFatType%></span></td>
            <td>医师:<span class="ReultStyle"><%=strCompositionPhysicians%></span></td>
          </tr>
          <tr>
            <td>评估:<span class="ReultStyle"><%=strFatEvaluate%></span></td>
          </tr>
          <tr>
            <td>调节目标:
            脂肪重量:&nbsp;<span class="ReultStyle"><%=strFatTarget%></span>&nbsp;kg&nbsp;&nbsp;
            肌肉重量:&nbsp;<span class="ReultStyle"><%=strMuscleTarget%></span>&nbsp;kg&nbsp;&nbsp;
            体重:&nbsp;<span class="ReultStyle"><%=strBodyWeightTarget%></span>&nbsp;kg</td>
          </tr>
        </table>
	
	</div>
    
    <div id="E006" class="ContentPrint" runat="server">
        <table width="100%"  border="0">
          <tr>
            <td style="width:50%;" class="TitleStyle">妇科检查</td>
            <td style="width:50%;">医师:<span class="ReultStyle"><%=strFeme_Physicians%></span></td>
          </tr>
          <tr>
            <td>
                月经初潮:<span class="ReultStyle"><%=strFeme_Menarche%></span>岁</td>
            <td>
                绝经年龄:<span class="ReultStyle"><%=strFeme_MenopauseAge%></span>岁</td>
          </tr>
          <tr>
            <td>
                月经周期:<span class="ReultStyle"><%=strFeme_MenstrualCycle%></span></td>
            <td>
                月经量:<span class="ReultStyle"><%=strFeme_MenstrualVolume%></span></td>
          </tr>
          <tr>
            <td>
                痛经:<span class="ReultStyle"><%=strFeme_Dysmenorrhea%></span></td>
            <td>
                家族肿瘤史:<span class="ReultStyle"><%=strFeme_FamilyTumorTistory%></span></td>
          </tr>
          <tr>
            <td>
                病史:<span class="ReultStyle"><%=strFeme_DiseaseHistory%></span></td>
            <td>
                病史其他:<span class="ReultStyle"><%=strFeme_DiseaseHistoryOther%></span></td>
          </tr>
          <tr>
            <td>
                曾用雄性激素:<span class="ReultStyle"><%=strFeme_AndrogenUsed%></span></td>
            <td>
                曾用雌性激素:<span class="ReultStyle"><%=strFeme_EstrogenUsed%></span></td>
          </tr>
          <tr>
            <td colspan="2">
                宫颈:<span class="ReultStyle"><%=strFeme_Cervical%></span></td>
          </tr>
          <tr>
            <td colspan="2">
                子宫:<span class="ReultStyle"><%=strFeme_Uterine%></span></td>
          </tr>
          <tr>
            <td>
                外阴:<span class="ReultStyle"><%=strFeme_Genital%></span></td>
            <td>
                阴道:<span class="ReultStyle"><%=strFeme_Vaginal%></span></td>
          </tr>
          <tr>
            <td colspan="2">
                白带:<span class="ReultStyle"><%=strFeme_Leucorrhea%></span></td>
          </tr>
          <tr>
            <td colspan="2">
                附件左:<span class="ReultStyle"><%=strFeme_AnnexLeft%></span></td>
          </tr>
            <tr>
                <td colspan="2">
                    附件右:<span class="ReultStyle"><%=strFeme_AnnexRight%></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    病理检查:<span class="ReultStyle"><%=strFeme_CheckCases%></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    乳腺红外线扫描:<span class="ReultStyle"><%=strFeme_InfraredScanBreast%></span></td>
            </tr>
            <tr>
                <td colspan="2">结论</td>
            </tr>
          <tr>
            <td colspan="2"><span class="ReultStyle"><%=strFeme_Conclusion%></span></td>
          </tr>
        </table>
    </div>
    
    <div id="E007" runat="server" class="ContentPrint">
        <table width="100%"  border="0">
          <tr>
            <td class="TitleStyle">检查报告</td>
          </tr>
            <tr>
                <td>体检结论</td>
            </tr>
          <tr>
            <td><span class="ReultStyle"><%=strChestPerspective%></span></td>
          </tr>
          <tr>
            <td>建议</td>
          </tr>
          <tr>
            <td><span class="ReultStyle"><%=strReview%></span></td>
          </tr>
          <tr>
            <td>备注</td>
          </tr>
          <tr>
            <td><span class="ReultStyle"><%=strRemarks%></span></td>
          </tr>
          <tr>
            <td>
                <div style="color :Red; margin:0 20 0 0"><asp:Literal ID="LiteralMsg" runat="server" />
            </td>
          </tr>
        </table>
	</div>
</div>