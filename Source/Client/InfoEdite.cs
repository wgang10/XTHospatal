using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Net;

namespace XTHospitalUI
{
    public partial class InfoEdite : FormBase
    {
        public InfoEdite()
        {
            InitializeComponent();
        }

        private void InitializationCombox()
        {
            Method.CmbDataBound("Department", cmbBM);
        }

        private void InfoEdite_Load(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Hide();
            //GlobalVal.SplashObj.Dispose();
            txtYearMonth.Text = GlobalVal.gloYearMonth;
            cmbBM.SelectedIndex = 0;
            //FromLogin frm = new FromLogin();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            InitializationCombox();//初始化部门下拉框
            if (GlobalVal.gloStrLoginUserType == "0")//管理员
            {
                //btnUserManage.Visible = true;
                btnAdd.Visible = true;
                btnHY_Add.Visible = true;
                btnTG_WGAdd.Visible = true;
                btnTG_WKAdd.Visible = true;
                btnTG_NKAdd.Visible = true;
                btnECGAdd.Visible = true;
                btnXRayImageAdd.Visible = true;
                btnBAdd.Visible = true;
                btnReportAdd.Visible = true;
                btnNew.Visible = true;
                btnSaveMBBexamination.Visible = true;
                btnSaveMBECG.Visible = true;
                btnSaveMBFeatures.Visible = true;
                btnSaveMBInternalMedicine.Visible = true;
                btnSaveMBSurgery.Visible = true;
                btnSaveMBXray.Visible = true;
                btnInputMBBexamination.Visible = true;
                btnInputMBECG.Visible = true;
                btnInputMBFeatures.Visible = true;
                btnInputMBInternalMedicine.Visible = true;
                btnInputMBSurgery.Visible = true;
                btnInputMBXray.Visible = true;
                //btnDepartment.Visible = true;
                //btnLog.Visible = true;
                btnComposition.Visible = true;
            }
            else if (GlobalVal.gloStrLoginUserType == "1")//高级用户
            {
                //btnUserManage.Visible = false;
                btnAdd.Visible = true;
                btnHY_Add.Visible = true;
                btnTG_WGAdd.Visible = true;
                btnTG_WKAdd.Visible = true;
                btnTG_NKAdd.Visible = true;
                btnECGAdd.Visible = true;
                btnXRayImageAdd.Visible = true;
                btnBAdd.Visible = true;
                btnReportAdd.Visible = true;
                btnNew.Visible = true;
                btnSaveMBBexamination.Visible = true;
                btnSaveMBECG.Visible = true;
                btnSaveMBFeatures.Visible = true;
                btnSaveMBInternalMedicine.Visible = true;
                btnSaveMBSurgery.Visible = true;
                btnSaveMBXray.Visible = true;
                btnInputMBBexamination.Visible = true;
                btnInputMBECG.Visible = true;
                btnInputMBFeatures.Visible = true;
                btnInputMBInternalMedicine.Visible = true;
                btnInputMBSurgery.Visible = true;
                btnInputMBXray.Visible = true;
                //btnDepartment.Visible = false;
                //btnLog.Visible = true;
                btnComposition.Visible = true;
            }
            else if (GlobalVal.gloStrLoginUserType == "2")//一般用户
            {
                //btnUserManage.Visible = false;
                btnAdd.Visible = false;
                btnHY_Add.Visible = false;
                btnTG_WGAdd.Visible = false;
                btnTG_WKAdd.Visible = false;
                btnTG_NKAdd.Visible = false;
                btnECGAdd.Visible = false;
                btnXRayImageAdd.Visible = false;
                btnBAdd.Visible = false;
                btnReportAdd.Visible = false;
                btnNew.Visible = false;
                btnSaveMBBexamination.Visible = false;
                btnSaveMBECG.Visible = false;
                btnSaveMBFeatures.Visible = false;
                btnSaveMBInternalMedicine.Visible = false;
                btnSaveMBSurgery.Visible = false;
                btnSaveMBXray.Visible = false;
                btnInputMBBexamination.Visible = false;
                btnInputMBECG.Visible = false;
                btnInputMBFeatures.Visible = false;
                btnInputMBInternalMedicine.Visible = false;
                btnInputMBSurgery.Visible = false;
                btnInputMBXray.Visible = false;
                //btnDepartment.Visible = false;
                //btnLog.Visible = true;
                btnComposition.Visible = false;
            }
            else//未知权限
            {
                //btnUserManage.Visible = false;
                btnAdd.Visible = false;
                btnHY_Add.Visible = false;
                btnTG_WGAdd.Visible = false;
                btnTG_WKAdd.Visible = false;
                btnTG_NKAdd.Visible = false;
                btnECGAdd.Visible = false;
                btnXRayImageAdd.Visible = false;
                btnBAdd.Visible = false;
                btnReportAdd.Visible = false;
                btnNew.Visible = false;
                btnSaveMBBexamination.Visible = false;
                btnSaveMBECG.Visible = false;
                btnSaveMBFeatures.Visible = false;
                btnSaveMBInternalMedicine.Visible = false;
                btnSaveMBSurgery.Visible = false;
                btnSaveMBXray.Visible = false;
                btnInputMBBexamination.Visible = false;
                btnInputMBECG.Visible = false;
                btnInputMBFeatures.Visible = false;
                btnInputMBInternalMedicine.Visible = false;
                btnInputMBSurgery.Visible = false;
                btnInputMBXray.Visible = false;
                //btnDepartment.Visible = false;
                //btnLog.Visible = false;
                btnComposition.Visible = false;
            }
            //}
            //else
            //{
            //    Application.Exit();
            //    return;
            //}
            GlobalVal.SplashObj.Dispose();
        }

        private void InfoEdite_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitializationCombox();//再次绑定部门下拉框
                this.txtGlobal_EmployeeID.Text = GlobalVal.EmployeeID;
                this.txtGlobal_EmployeeName.Text = GlobalVal.EmployeeName;
                if (GlobalVal.EmployeeID.Length != 0 && GlobalVal.gloYearMonth.Length != 0)
                {
                    BindAllInfo(GlobalVal.EmployeeID, GlobalVal.gloYearMonth);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalVal.SplashObj = SplashObject.GetLoading();
            //GlobalVal.ShowForm = this;
            //if (GlobalVal.SearchForm == null)
            //{
            //    GlobalVal.SearchForm = new Search();
            //}
            //GlobalVal.SearchForm.Show();
            this.Hide();
            GlobalVal.FormSearch.ShowDialog();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            string age=Method.GetAge(dtpBirthday.Value).ToString();
            if (age == "-1")
            {
                txtAge.Text = "";
                MessageBox.Show("生日不能大于现在时间！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtAge.Text = age;
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //GlobalVal.ShowForm.Show();
            this.Hide();
            //if (MessageBox.Show("确定要退出系统吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    GlobalVal.blCloseForm = true;
            //    XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            //    webService.AddLog("管理用户[" + GlobalVal.gloStrLoginUserID + "]退出了系统.", "2", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
            //    Application.Exit();
            //}
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //if (!GlobalVal.blCloseForm)
            //{
            //    if (MessageBox.Show("确定要退出系统吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        e.Cancel = false;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
            //else
            //{
            //    e.Cancel = false;
            //}
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 添加员工概要信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 1 || txtEmployeeGZID.Text.Trim().Length <1 || txtEmployeePWD.Text.Trim().Length<1 || txtEmployeeID.Text.Trim().Length < 1)
            {
                MessageBox.Show("姓名、工资号、查询密码及身份证不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Employee model = new XTHospitalUI.XTHotpatalWebServices.Employee();
            model.EmployeeName = txtName.Text.Trim();
            model.EmployeeID = txtEmployeeID.Text.Trim();
            model.EmployeeGZID = txtEmployeeGZID.Text.Trim();
            model.EmployeePWD = txtEmployeePWD.Text.Trim();
            if (rdbSexM.Checked)
            {
                model.EmployeeSex = "0";
            }
            else if (rdbSexW.Checked)
            {
                model.EmployeeSex = "1";
            }
            else
            {
                model.EmployeeSex = "";
            }
            model.EmployeeBirthday = dtpBirthday.Text.Trim().Replace("-", "");
            model.EmployeeID = txtEmployeeID.Text.Trim();
            model.EmployeeWHCD = txtEmployeeWHCD.Text.Trim();
            if (rdbHF1.Checked)
            {
                model.EmployeeHF = "0";
            }
            else if (rdbHF2.Checked)
            {
                model.EmployeeHF = "1";
            }
            else if (rdbHF3.Checked)
            {
                model.EmployeeHF = "2";
            }
            else
            {
                model.EmployeeHF = "";
            }
            model.EmployeeJG = txtJG.Text.Trim();
            model.EmployeeXJD = txtXJD.Text.Trim();
            model.EmployeeBM = cmbBM.SelectedValue.ToString();
            model.EmployeeDW = txtDW.Text.Trim();
            model.EmployeeJWBS = txtJWBS.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            model.EmployeeEmail = txtEmail.Text;
            model.EmployeePhone = txtEmployeePhone.Text;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddEmployee(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
                //ClearControl();
                GlobalVal.EmployeeID = txtEmployeeID.Text.Trim();
                GlobalVal.EmployeeName = txtName.Text.Trim();
                txtGlobal_EmployeeID.Text = GlobalVal.EmployeeID;
                txtGlobal_EmployeeName.Text = GlobalVal.EmployeeName;
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 生化检验单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHY_Add_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Biochemistry model = new XTHospitalUI.XTHotpatalWebServices.Biochemistry();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.HYNo = txtHY_No.Text.Trim();
            model.HYDr = txtHY_Dr.Text.Trim();
            model.HYTC = txtHY_TC.Text.Trim();
            model.HYTG = txtHY_TG.Text.Trim();
            model.HYHDLC = txtHY_HDL_C.Text.Trim();
            model.HYTBIL = txtHY_TBIL.Text.Trim();
            model.HYDBIL = txtHY_DBIL.Text.Trim();
            model.HYTP = txtHY_TP.Text.Trim();
            model.HYALB = txtHY_ALB.Text.Trim();
            model.HYALT = txtHY_ALT.Text.Trim();
            model.HY_GLU = txtGLU.Text.Trim();//血糖
            model.HY_UREA = txtUREA.Text.Trim();//尿素
            model.HY_CR = txtCR.Text.Trim();//肌酐
            model.HY_AFP = txtAFP.Text.Trim();//甲胎蛋白
            model.HY_CEA = txtCEA.Text.Trim();//癌胚抗原
            //HBsAg
            if(rdbHBsAg1.Checked )
            {
                model.HYHBsAg ="0";
            }
            else if (rdbHBsAg2.Checked)
            {
                model.HYHBsAg = "1";
            }
            else
            {
                model.HYHBsAg = "";
            }
            //HBsAb
            if(rdbHBsAb1 .Checked )
            {
                model.HYHBsAb="0";
            }
            else if (rdbHBsAb2.Checked)
            {
                model.HYHBsAb = "1";
            }
            else
            {
                model.HYHBsAb = "";
            }
            //HBeAg
            if(rdbHBeAg1 .Checked )
            {
                model.HYHBeAg="0";
            }
            else if (rdbHBeAg2.Checked)
            {
                model.HYHBeAg = "1";
            }
            else
            {
                model.HYHBeAg = "";
            }
            //HBeAb
            if(rdbHBeAb1 .Checked )
            {
                model.HYHBeAb ="0";
            }
            else if (rdbHBeAb2.Checked)
            {
                model.HYHBeAb = "1";
            }
            else
            {
                model.HYHBeAb = "";
            }
            //HBcAb
            if (rdbHBcAb1.Checked)
            {
                model.HYHBcAb = "0";
            }
            else if (rdbHBcAb2.Checked)
            {
                model.HYHBcAb = "1";
            }
            else
            {
                model.HYHBcAb = "";
            }
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateBiochemistry(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 体格检查-五官
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTG_WGAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Features model = new XTHospitalUI.XTHotpatalWebServices.Features();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.LeftEye = this.txtLeftEye.Text.Trim();
            model.RightEye = this.txtRightEye.Text.Trim();
            model.CorrectedLeft = this.txtCorrectedLeft.Text.Trim();
            model.CorrectedRight = this.txtCorrectedRight.Text.Trim();
            model.ColorVisionForce = this.txtColorVisionForce.Text.Trim();
            model.TrachomaLeft = this.txtTrachomaLeft.Text.Trim();
            model.TrachomaRight = this.txtTrachomaRight.Text.Trim();
            model.OtherEye = this.txtOtherEye.Text.Trim();
            model.ListeningLeft = this.txtListeningLeft.Text.Trim();
            model.ListeningRight = this.txtListeningRight.Text.Trim();
            model.Ear = this.txtEar.Text.Trim();
            model.Olfactory = this.txtOlfactory.Text.Trim();
            model.NoseParanasalSinusDisease = this.txtNoseParanasalSinusDisease.Text.Trim();
            model.Throat = this.txtThroat.Text.Trim();
            model.LipPalate = this.txtLipPalate.Text.Trim();
            model.Stuttering = this.txtStuttering.Text.Trim();
            model.Caries = this.txtCaries.Text.Trim();
            model.MissingTeeth = this.txtMissingTeeth.Text.Trim();
            model.PeriodontalDisease = this.txtPeriodontalDisease.Text.Trim();
            model.Other = this.txtFeaturesOther.Text.Trim();
            model.MedicalAdvice = this.txtMedicalAdvice.Text.Trim();
            model.Physicians = this.txtFeaturesPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateFeatures(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 体格检查-外科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTG_WKAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Surgery model = new XTHospitalUI.XTHotpatalWebServices.Surgery();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.Length=this.txtLength.Text.Trim ();
            model.Bust=this.txtBust.Text.Trim ();
            model.Weight=this.txtWeight.Text.Trim ();
            model.BadBreath=this.txtBadBreath.Text.Trim ();
            model.Skin=this.txtSkin.Text.Trim ();
            model.Lymphoid=this.txtLymphoid.Text.Trim ();
            model.Thyroid=this.txtThyroid.Text.Trim ();
            model.Spine=this.txtSpine.Text.Trim ();
            model.Limbs=this.txtLimbs.Text.Trim ();
            model.Joint=this.txtJoint.Text.Trim ();
            model.Flatfoot=this.txtFlatfoot.Text.Trim ();
            model.Genitourinary=this.txtGenitourinary.Text.Trim ();
            model.Anal=this.txtAnal.Text.Trim ();
            model.Hernia=this.txtHernia.Text.Trim ();
            model.Other=this.txtSurgeryOther.Text.Trim ();
            model.MedicalAdvice = this.txtSurgeryMedicalAdvice.Text.Trim();
            model.Physicians=this.txtSurgeryPhysicians.Text.Trim ();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateSurgery(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 体格检查-内科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTG_NKAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.InternalMedicine model = new XTHospitalUI.XTHotpatalWebServices.InternalMedicine();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.BloodPressure=this.txtBloodPressure.Text.Trim();
            model.BloodPressure1 = this.txtBloodPressure1.Text.Trim();
            model.DevelopmentStatus=this.txtDevelopmentStatus.Text.Trim();
            model.Neurological=this.txtNeurological.Text.Trim();
            model.Lung=this.txtLung.Text.Trim();
            model.HeartBlood=this.txtHeartBlood.Text.Trim();
            model.AbdominalOrgans=this.txtAbdominalOrgans.Text.Trim();
            model.Liver=this.txtLiver.Text.Trim();
            model.Spleen=this.txtSpleen.Text.Trim();
            model.Other=this.txtInternalMedicineOther.Text.Trim();
            model.MedicalAdvice=this.txtInternalMedicineMedicalAdvice.Text.Trim();
            model.Physicians = this.txtInternalMedicinePhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateInternalMeicine(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 心电图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnECGAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.ECG model = new XTHospitalUI.XTHotpatalWebServices.ECG();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;

            model.ECGNo = this.txtECGNo.Text.Trim();
            model.ClinicalDiagnosis = this.txtClinicalDiagnosis.Text.Trim();
            model.UsedDrugs = this.txtUsedDrugs.Text.Trim();
            model.SummaryHistory = this.txtSummaryHistory.Text.Trim();
            model.SummaryBody = this.txtSummaryBody.Text.Trim();
            if (rdbPatientSituation1.Checked)
            {
                model.PatientSituation = "1";
            }
            else if (rdbPatientSituation2.Checked)
            {
                model.PatientSituation = "2";
            }
            else
            {
                model.PatientSituation = "";
            }
            
            model.MedicalAdvice = this.txtECGMedicalAdvice.Text.Trim();
            if (picECG.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picECG.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.ECGImage = buffer;
            }
            else
            {
                model.ECGImage = null;
            }
            model.Physicians = this.txtECGPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateECG(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// X射线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXRayImageAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Xray model = new XTHospitalUI.XTHotpatalWebServices.Xray();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.PhotoNo = this.txtPhotoNo.Text.Trim();
            model.Symptoms = this.txtSymptoms.Text.Trim();
            model.Laboratory = this.txtLaboratory.Text.Trim();
            model.Diagnosis = this.txtDiagnosis.Text.Trim();
            model.Perspective = this.txtPerspective.Text.Trim();
            model.Camera = this.txtCamera.Text.Trim();
            model.Results = this.txtXRayResults.Text.Trim();
            if (picXImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picXImage.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.XImage = buffer;
            }
            else
            {
                model.XImage = null;
            }
            model.Physicians = this.txtXRayPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateXray(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// B超
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Bexamination model = new XTHospitalUI.XTHotpatalWebServices.Bexamination();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;

            model.BID = this.txtBID.Text.Trim();
            model.HistorySigns = this.txtHistorySigns.Text.Trim();
            model.LaboratoryExamination = this.txtLaboratoryExamination.Text.Trim();
            model.Diagnosis = this.txtBDiagnosis.Text.Trim();
            model.Purpose = this.txtPurpose.Text.Trim();
            model.Results = this.txtBResults.Text.Trim();
            if (picBImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picBImage.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.BImage = buffer;
            }
            else
            {
                model.BImage = null;
            }
            model.Physicians = this.txtBPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateBexamination(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Report model = new XTHospitalUI.XTHotpatalWebServices.Report();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.ChestPerspective = this.txtChestPerspective.Text.Trim();
            model.Laboratory = this.txtReportLaboratory.Text.Trim();
            model.Review = this.txtReview.Text.Trim();
            model.Remarks = this.txtRemarks.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.AddUpdateReport(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserManage_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm = this;
            UserManage frm = new UserManage();
            frm.Show();
        }

        private void btnPicECGSearch_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有图片(*.bmp;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.gif;*.jpeg;*.jpg;*.png";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Length > 2097152)
                {
                    Method.MessageShow("W11020");//Image size must be less than 2M.
                    return;
                }
                else
                {
                    this.picECG.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnPicECGClear_Click(object sender, EventArgs e)
        {
            this.picECG.Image = null;
        }

        private void btnXRayImageSearch_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有图片(*.bmp;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.gif;*.jpeg;*.jpg;*.png";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Length > 2097152)
                {
                    Method.MessageShow("W11020");//Image size must be less than 100 KB.
                    return;
                }
                else
                {
                    this.picXImage.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnXRayImageClear_Click(object sender, EventArgs e)
        {
            this.picXImage.Image = null;
        }

        private void btnPicBClear_Click(object sender, EventArgs e)
        {
            this.picBImage.Image = null;
        }

        private void btnPicBSearch_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有图片(*.bmp;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.gif;*.jpeg;*.jpg;*.png";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Length > 2097152)
                {
                    Method.MessageShow("W11020");//Image size must be less than 100 KB.
                    return;
                }
                else
                {
                    this.picBImage.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// 放大显示心电图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picECG_DoubleClick(object sender, EventArgs e)
        {
            if (picECG.Image != null)
            {
                GlobalVal.gloImage = picECG.Image;
                FormImage formShow = new FormImage();
                formShow.ShowDialog();
            }
        }

        /// <summary>
        /// 放大显示X线图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picXImage_DoubleClick(object sender, EventArgs e)
        {
            if (picXImage.Image != null)
            {
                GlobalVal.gloImage = picXImage.Image;
                FormImage formShow = new FormImage();
                formShow.ShowDialog();
            }
        }

        /// <summary>
        /// 放大显示B超图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBImage_DoubleClick(object sender, EventArgs e)
        {
            if (picBImage.Image != null)
            {
                GlobalVal.gloImage = picBImage.Image;
                FormImage formShow = new FormImage();
                formShow.ShowDialog();
            }
        }

        /// <summary>
        /// BindAllInfo
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="YearMonth"></param>
        private void BindAllInfo(string EmployeeID, string YearMonth)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult =webService.SearchEmployeeAllInfo(EmployeeID, YearMonth);
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    #region **********概要信息*****************
                    this.txtName.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeName"].ToString();//姓名
                    this.txtEmployeeGZID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeGZID"].ToString(); ;//工资编号
                    this.txtEmployeePWD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeePWD"].ToString(); ;//查询密码
                    this.txtEmployeeID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeID"].ToString();//员工身份证
                    string strSexTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeSex"].ToString();//性别
                    if (strSexTemp == "0")
                    {
                        this.rdbSexM.Checked=true;
                        this.rdbSexW.Checked = false;
                    }
                    else if (strSexTemp == "1")
                    {
                        this.rdbSexM.Checked = false;
                        this.rdbSexW.Checked = true;
                    }
                    else
                    {
                        this.rdbSexM.Checked = false;
                        this.rdbSexW.Checked = false;
                    }
                    string strBirthday = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBirthday"].ToString();//出生年月
                    if (strBirthday.Length > 0)
                    {
                        this.dtpBirthday.Text = strBirthday.Substring(0,4)+"-"+strBirthday.Substring(4,2)+"-"+strBirthday.Substring (6,2);
                    }
                    string age = Method.GetAge(dtpBirthday.Value).ToString();
                    this.txtAge.Text = age;
                    this.txtEmployeeWHCD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeWHCD"].ToString();//文化程度
                    string HFTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeHF"].ToString();//婚否
                    if (HFTemp=="0")
                    {
                        rdbHF1.Checked=true;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = false;
                    }
                    else if (HFTemp == "1")
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = true;
                        rdbHF3.Checked = false;
                    }
                    else if (HFTemp == "2")
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = true;
                    }
                    else
                    {
                        rdbHF1.Checked = false;
                        rdbHF2.Checked = false;
                        rdbHF3.Checked = false;
                    }
                    this.txtJG.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJG"].ToString();//籍贯
                    this.txtXJD.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeXJD"].ToString();//现住地
                    string strBM = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeBM"].ToString();//部门
                    cmbBM.SelectedValue = strBM;
                    for (int i = 0; i < cmbBM.Items.Count; i++)
                    {
                        if (cmbBM.GetItemText(cmbBM.Items[i]) == strBM)
                        {
                            cmbBM.SelectedIndex = i;
                            break;
                        }
                    }
                    this.txtDW.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeDW"].ToString();//单位
                    this.txtJWBS.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Emp_EmployeeJWBS"].ToString();//既往病史
                    this.txtEmail.Text = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString();//Email
                    this.txtEmployeePhone.Text = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePhone"].ToString();//联系电话
                    #endregion

                    #region **********生化检验单*****************
                    this.txtHY_No.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYNo"].ToString();//化验号
                    this.txtHY_Dr.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYDr"].ToString();//医师
                    this.txtHY_TC.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTC"].ToString();//总胆固醇(TC)
                    this.txtHY_TG.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTG"].ToString();//甘油三脂(TG)
                    this.txtHY_HDL_C.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHDLC"].ToString();//高密度脂蛋白胆固醇(HDL-C)
                    this.txtHY_TBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTBIL"].ToString();//总胆红素(TBIL)
                    this.txtHY_DBIL.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYDBIL"].ToString();//直接胆红素(DBIL)
                    this.txtHY_TP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYTP"].ToString();//总蛋白(TP)
                    this.txtHY_ALB.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALB"].ToString();//白蛋白(ALB)
                    this.txtHY_ALT.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYALT"].ToString();//谷丙转氨酶(ALT)
                    this.txtGLU.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_GLU"].ToString();//血糖
                    this.txtUREA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_UREA"].ToString();//尿素
                    this.txtCR.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CR"].ToString();//肌酐
                    this.txtAFP.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_AFP"].ToString();//甲胎蛋白
                    this.txtCEA.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HY_CEA"].ToString();//癌胚抗原
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAg"].ToString() == "0")//HBsAg
                    {
                        rdbHBsAg1.Checked = true;
                        rdbHBsAg2.Checked = false;
                    }
                    else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAg"].ToString() == "1")//HBsAg
                    {
                        rdbHBsAg1.Checked = false;
                        rdbHBsAg2.Checked = true;
                    }
                    else
                    {
                        rdbHBsAg1.Checked = false;
                        rdbHBsAg2.Checked = false;
                    }
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAb"].ToString() == "0")//HBsAb
                    {
                        rdbHBsAb1.Checked = true;
                        rdbHBsAb2.Checked = false;
                    }
                    else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBsAb"].ToString() == "1")//HBsAb
                    {
                        rdbHBsAb1.Checked = false;
                        rdbHBsAb2.Checked = true;
                    }
                    else
                    {
                        rdbHBsAb1.Checked = false;
                        rdbHBsAb2.Checked = false;
                    }
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAg"].ToString() == "0")//HBeAg
                    {
                        rdbHBeAg1.Checked = true;
                        rdbHBeAg2.Checked = false;
                    }
                    else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAg"].ToString() == "1")//HBeAg
                    {
                        rdbHBeAg1.Checked = false;
                        rdbHBeAg2.Checked = true;
                    }
                    else
                    {
                        rdbHBeAg1.Checked = false;
                        rdbHBeAg2.Checked = false;
                    }
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAb"].ToString() == "0")//HBeAb
                    {
                        rdbHBeAb1.Checked = true;
                        rdbHBeAb2.Checked = false;
                    }
                    else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBeAb"].ToString() == "1")//HBeAb
                    {
                        rdbHBeAb1.Checked = false;
                        rdbHBeAb2.Checked = true;
                    }
                    else
                    {
                        rdbHBeAb1.Checked = false;
                        rdbHBeAb2.Checked = false;
                    }
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBcAb"].ToString() == "0")//HBcAb
                    {
                        rdbHBcAb1.Checked = true;
                        rdbHBcAb2.Checked = false;
                    }
                    else if (resoult.ResultDataSet.Tables[0].Rows[0]["Bio_HYHBcAb"].ToString() == "0")//HBcAb
                    {
                        rdbHBcAb1.Checked = false;
                        rdbHBcAb2.Checked = true;
                    }
                    else
                    {
                        rdbHBcAb1.Checked = false;
                        rdbHBcAb2.Checked = false;
                    }
                    #endregion 

                    #region **********体格检查（五官）*****************
                    this.txtLeftEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LeftEye"].ToString();//视力左
                    this.txtRightEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_RightEye"].ToString();//视力右
                    this.txtCorrectedLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedLeft"].ToString();//矫正视力左
                    this.txtCorrectedRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedRight"].ToString();//矫正视力右
                    this.txtColorVisionForce.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ColorVisionForce"].ToString();//辨色力
                    this.txtTrachomaLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaLeft"].ToString();//沙眼左
                    this.txtTrachomaRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaRight"].ToString();//沙眼右
                    this.txtOtherEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_OtherEye"].ToString();//眼其他
                    this.txtListeningLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningLeft"].ToString();//听力左
                    this.txtListeningRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningRight"].ToString();//听力右
                    this.txtEar.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Ear"].ToString();//耳疾
                    this.txtOlfactory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Olfactory"].ToString();//嗅觉
                    this.txtNoseParanasalSinusDisease.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_NoseParanasalSinusDisease"].ToString();//鼻及鼻窦疾病
                    this.txtThroat.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Throat"].ToString();//咽喉
                    this.txtLipPalate.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LipPalate"].ToString();//唇腭
                    this.txtStuttering.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Stuttering"].ToString();//口吃
                    this.txtCaries.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Caries"].ToString();//龋齿
                    this.txtMissingTeeth.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MissingTeeth"].ToString();//缺齿
                    this.txtPeriodontalDisease.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_PeriodontalDisease"].ToString();//牙周病
                    this.txtFeaturesOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Other"].ToString();//其他
                    this.txtMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MedicalAdvice"].ToString();//医生意见
                    this.txtFeaturesPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Physicians"].ToString();//医师
                    #endregion

                    #region **********体格检查（外科）*****************
                    this.txtLength.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Length"].ToString();//身长
                    this.txtBust.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Bust"].ToString();//胸围
                    this.txtWeight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Weight"].ToString();//体重
                    this.txtBadBreath.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_BadBreath"].ToString();//呼吸差
                    this.txtSkin.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Skin"].ToString();//皮肤
                    this.txtLymphoid.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Lymphoid"].ToString();//淋巴
                    this.txtThyroid.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Thyroid"].ToString();//甲状腺
                    this.txtSpine.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Spine"].ToString();//脊柱
                    this.txtLimbs.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Limbs"].ToString();//四肢
                    this.txtJoint.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Joint"].ToString();//关节
                    this.txtFlatfoot.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Flatfoot"].ToString();//扁平足
                    this.txtGenitourinary.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Genitourinary"].ToString();//泌尿生殖器
                    this.txtAnal.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Anal"].ToString();//肛门
                    this.txtHernia.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Hernia"].ToString();//疝
                    this.txtSurgeryOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Other"].ToString();//其他
                    this.txtSurgeryMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_MedicalAdvice"].ToString();//医生意见
                    this.txtSurgeryPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Physicians"].ToString();//医师
                    #endregion

                    #region **********体格检查（内科）*****************
                    this.txtBloodPressure.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure"].ToString();//血压
                    this.txtBloodPressure1.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure1"].ToString();//血压
                    this.txtDevelopmentStatus.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_DevelopmentStatus"].ToString();//发育及营养状况
                    this.txtNeurological.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Neurological"].ToString();//神经及精神
                    this.txtLung.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Lung"].ToString();//肺及呼吸道
                    this.txtHeartBlood.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_HeartBlood"].ToString();//心脏及血管
                    this.txtAbdominalOrgans.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_AbdominalOrgans"].ToString();//腹部器官
                    this.txtLiver.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Liver"].ToString();//肝
                    this.txtSpleen.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Spleen"].ToString();//脾
                    this.txtInternalMedicineOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Other"].ToString();//其他
                    this.txtInternalMedicineMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_MedicalAdvice"].ToString();//医生意见
                    this.txtInternalMedicinePhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Physicians"].ToString();//医师
                    #endregion

                    #region **********心电图检查*****************
                    this.txtECGNo.Text=resoult.ResultDataSet.Tables[0].Rows[0]["ECT_No"].ToString();//心电图号
                    this.txtClinicalDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_ClinicalDiagnosis"].ToString();//临床诊断
                    this.txtUsedDrugs.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_UsedDrugs"].ToString();//曾用药物
                    this.txtSummaryHistory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryHistory"].ToString();//病史概要
                    this.txtSummaryBody.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryBody"].ToString();//查体概要
                    string strPatientSituation = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_PatientSituation"].ToString();//病人状况
                    if (strPatientSituation == "1")
                    {
                        rdbPatientSituation1.Checked = true;
                        rdbPatientSituation2.Checked = false;
                    }
                    else if (strPatientSituation == "2")
                    {
                        rdbPatientSituation1.Checked = false;
                        rdbPatientSituation2.Checked = true;
                    }
                    else
                    {
                        rdbPatientSituation1.Checked = false;
                        rdbPatientSituation2.Checked = false;
                    }
                    txtECGMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_MedicalAdvice"].ToString();//诊断意见
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"] != DBNull.Value)
                    {
                        MemoryStream msECG = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"]);
                        Image imageECG = Image.FromStream(msECG, true);
                        this.picECG.Image = imageECG;
                    }
                    else
                    {
                        this.picECG.Image = null;
                    }
                    this.txtECGPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Physicians"].ToString();//医师
                    #endregion

                    #region **********X线检查*****************
                    this.txtPhotoNo.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_PhotoNo"].ToString();//摄影号
                    this.txtSymptoms.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Symptoms"].ToString();//主要症状
                    this.txtLaboratory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Laboratory"].ToString();//体征及化验检查
                    this.txtDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Diagnosis"].ToString();//临床预诊
                    this.txtPerspective.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Perspective"].ToString();//透视部位及目的
                    this.txtCamera.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Camera"].ToString();//照相部位及目的
                    this.txtXRayResults.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Results"].ToString();//透视检查结果

                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"] != DBNull.Value)
                    {
                        MemoryStream msXray = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"]);
                        Image imageXray = Image.FromStream(msXray, true);
                        this.picXImage.Image = imageXray;
                    }
                    else
                    {
                        this.picXImage.Image = null;
                    }
                    this.txtXRayPhysicians.Text  = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Physicians"].ToString();//医师
                    #endregion

                    #region **********B超检查*****************
                    this.txtBID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BID"].ToString();//B超编号
                    this.txtHistorySigns.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_HistorySigns"].ToString();//病史及体征
                    this.txtLaboratoryExamination.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_LaboratoryExamination"].ToString();//化验检查
                    this.txtBDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Diagnosis"].ToString();//临床预诊
                    this.txtPurpose.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Purpose"].ToString();//检查目的和部位
                    this.txtBResults.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Results"].ToString();//检查结果
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"] != DBNull.Value)
                    {
                        MemoryStream msBex = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"]);
                        Image imageBex = Image.FromStream(msBex, true);
                        this.picBImage.Image = imageBex;
                    }
                    else
                    {
                        this.picBImage.Image = null;
                    }
                    this.txtBPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Physicians"].ToString();//医师
                    #endregion

                    #region **********体成分*****************
                    rdbFatType1.Checked = false;
                    rdbFatType2.Checked = false;
                    rdbFatEvaluate1.Checked = false;
                    rdbFatEvaluate2.Checked = false;
                    rdbFatEvaluate3.Checked = false;
                    rdbFatEvaluate4.Checked = false;
                    rdbFatEvaluate5.Checked = false;
                    rdbFatEvaluate6.Checked = false;
                    rdbFatEvaluate7.Checked = false;
                    rdbFatEvaluate8.Checked = false;
                    rdbFatEvaluate9.Checked = false;
                    string FatType = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatType"].ToString();
                    string FatEvaluate = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatEvaluate"].ToString();

                    switch (FatType)
                    {
                        case "1":
                            rdbFatType1.Checked=true;
                            break;
                        case "2":
                            rdbFatType2.Checked=true;
                            break;
                    }

                    switch (FatEvaluate)
                    {
                        case "1":
                            rdbFatEvaluate1.Checked = true;
                            break;
                        case "2":
                            rdbFatEvaluate2.Checked = true;
                            break;
                        case "3":
                            rdbFatEvaluate3.Checked = true;
                            break;
                        case "4":
                            rdbFatEvaluate4.Checked = true;
                            break;
                        case "5":
                            rdbFatEvaluate5.Checked = true;
                            break;
                        case "6":
                            rdbFatEvaluate6.Checked = true;
                            break;
                        case "7":
                            rdbFatEvaluate7.Checked = true;
                            break;
                        case "8":
                            rdbFatEvaluate8.Checked = true;
                            break;
                        case "9":
                            rdbFatEvaluate9.Checked = true;
                            break;
                    }

                    this.txtFatTarget.Text = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_FatTarget"].ToString();
                    this.txtMuscleTarget.Text = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_MuscleTarget"].ToString();
                    this.txtBodyWeightTarget.Text = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_BodyWeightTarget"].ToString();
                    this.txtCompositionPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["BodyComposi_Physicians"].ToString();
                    #endregion

                    #region **********妇科检查*****************
                    this.txtMenarche.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Menarche"].ToString();//月经初潮
                    this.txtMenopauseAge.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenopauseAge"].ToString();//绝经年龄

                    string strMenstrualCycleTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenstrualCycle"].ToString();//周期 MenstrualCycle
                    if (strMenstrualCycleTemp.Trim() == "0")
                    {
                        rdbMenstrualCycle0.Checked=true;
                        rdbMenstrualCycle1.Checked = false;
                    }
                    else if (strMenstrualCycleTemp.Trim() == "1")
                    {
                        rdbMenstrualCycle0.Checked = false;
                        rdbMenstrualCycle1.Checked = true;
                    }
                    else
                    {
                        rdbMenstrualCycle0.Checked = false;
                        rdbMenstrualCycle1.Checked = false;
                    }
                    string strMenstrualVolumeTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_MenstrualVolume"].ToString();//量 MenstrualVolume
                    if (strMenstrualVolumeTemp.Trim() == "0")
                    {
                        rdbMenstrualVolume0.Checked = true;
                        rdbMenstrualVolume1.Checked = false;
                        rdbMenstrualVolume2.Checked = false;
                    }
                    else if (strMenstrualVolumeTemp.Trim() == "1")
                    {
                        rdbMenstrualVolume0.Checked = false;
                        rdbMenstrualVolume1.Checked = true;
                        rdbMenstrualVolume2.Checked = false;
                    }
                    else if (strMenstrualVolumeTemp.Trim() == "2")
                    {
                        rdbMenstrualVolume0.Checked = false;
                        rdbMenstrualVolume1.Checked = false;
                        rdbMenstrualVolume2.Checked = true;
                    }
                    else
                    {
                        rdbMenstrualVolume0.Checked = false;
                        rdbMenstrualVolume1.Checked = false;
                        rdbMenstrualVolume2.Checked = false;
                    }
                    string strDysmenorrheaTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Dysmenorrhea"].ToString();//痛经 Dysmenorrhea
                    if (strDysmenorrheaTemp.Trim() == "0")
                    {
                        rdbDysmenorrhea0.Checked = true;
                        rdbDysmenorrhea1.Checked = false;
                        rdbDysmenorrhea2.Checked = false;
                    }
                    else if (strDysmenorrheaTemp.Trim() == "1")
                    {
                        rdbDysmenorrhea0.Checked = false;
                        rdbDysmenorrhea1.Checked = true;
                        rdbDysmenorrhea2.Checked = false;
                    }
                    else if (strDysmenorrheaTemp.Trim() == "2")
                    {
                        rdbDysmenorrhea0.Checked = false;
                        rdbDysmenorrhea1.Checked = false;
                        rdbDysmenorrhea2.Checked = true;
                    }
                    else
                    {
                        rdbDysmenorrhea0.Checked = false;
                        rdbDysmenorrhea1.Checked = false;
                        rdbDysmenorrhea2.Checked = false;
                    }
                    string strDiseaseHistoryTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_DiseaseHistory"].ToString();//病史 DiseaseHistory
                    if (strDiseaseHistoryTemp.IndexOf("[宫颈炎]") > -1)
                    {
                        ckbDiseaseHistoryGJY.Checked = true;
                    }
                    else
                    {
                        ckbDiseaseHistoryGJY.Checked = false;
                    }
                    if (strDiseaseHistoryTemp.IndexOf("[附件炎]") > -1)
                    {
                        ckbDiseaseHistoryFJY.Checked = true;
                    }
                    else
                    {
                        ckbDiseaseHistoryFJY.Checked = false;
                    }
                    if (strDiseaseHistoryTemp.IndexOf("[子宫肌瘤]") > -1)
                    {
                        ckbDiseaseHistoryZGJL.Checked = true;
                    }
                    else
                    {
                        ckbDiseaseHistoryZGJL.Checked = false;
                    }
                    if (strDiseaseHistoryTemp.IndexOf("[卵巢囊肿]") > -1)
                    {
                        ckbDiseaseHistoryLCNZ.Checked = true;
                    }
                    else
                    {
                        ckbDiseaseHistoryLCNZ.Checked = false;
                    }
                    if (strDiseaseHistoryTemp.IndexOf("[月经病]") > -1)
                    {
                        ckbDiseaseHistoryYJB.Checked = true;
                    }
                    else
                    {
                        ckbDiseaseHistoryYJB.Checked = false;
                    }
                    string strFamilyTumorTistoryTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_FamilyTumorTistory"].ToString();//病史家庭肿瘤史 FamilyTumorTistory
                    if (strFamilyTumorTistoryTemp.Trim() == "0")
                    {
                        rdbFamilyTumorTistory0.Checked = true;
                        rdbFamilyTumorTistory1.Checked = false;
                    }
                    else if (strFamilyTumorTistoryTemp.Trim() == "1")
                    {
                        rdbFamilyTumorTistory0.Checked = false;
                        rdbFamilyTumorTistory1.Checked = true;
                    }
                    else
                    {
                        rdbFamilyTumorTistory0.Checked = false;
                        rdbFamilyTumorTistory1.Checked = false;
                    }
                    this.txtDiseaseHistoryOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_DiseaseHistoryOther"].ToString();//病史其他
                    string strAndrogenUsedTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AndrogenUsed"].ToString();//曾用雄性激素 AndrogenUsed
                    if (strAndrogenUsedTemp.Trim() == "0")
                    {
                        rdbAndrogenUsed0.Checked = true;
                        rdbAndrogenUsed1.Checked = false;
                        rdbAndrogenUsed2.Checked = false;
                    }
                    else if (strAndrogenUsedTemp.Trim() == "1")
                    {
                        rdbAndrogenUsed0.Checked = false;
                        rdbAndrogenUsed1.Checked = true;
                        rdbAndrogenUsed2.Checked = false;
                    }
                    else if (strAndrogenUsedTemp.Trim() == "2")
                    {
                        rdbAndrogenUsed0.Checked = false;
                        rdbAndrogenUsed1.Checked = false;
                        rdbAndrogenUsed2.Checked = true;
                    }
                    else
                    {
                        rdbAndrogenUsed0.Checked = false;
                        rdbAndrogenUsed1.Checked = false;
                        rdbAndrogenUsed2.Checked = false;
                    }
                    string strEstrogenUsedTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_EstrogenUsed"].ToString();//曾用雌性激素 EstrogenUsed
                    if (strEstrogenUsedTemp.Trim() == "0")
                    {
                        rdbEstrogenUsed0.Checked = true;
                        rdbEstrogenUsed1.Checked = false;
                        rdbEstrogenUsed2.Checked = false;
                    }
                    else if (strEstrogenUsedTemp.Trim() == "1")
                    {
                        rdbEstrogenUsed0.Checked = false ;
                        rdbEstrogenUsed1.Checked = true ;
                        rdbEstrogenUsed2.Checked = false;
                    }
                    else if (strEstrogenUsedTemp.Trim() == "2")
                    {
                        rdbEstrogenUsed0.Checked = false ;
                        rdbEstrogenUsed1.Checked = false;
                        rdbEstrogenUsed2.Checked = true ;
                    }
                    else
                    {
                        rdbEstrogenUsed0.Checked = false ;
                        rdbEstrogenUsed1.Checked = false;
                        rdbEstrogenUsed2.Checked = false;
                    }
                    string strCervicalTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Cervical"].ToString();//宫颈 Cervical
                    if (strCervicalTemp.IndexOf("[光滑]") > -1)
                    {
                        ckbCervicalGH.Checked = true;
                    }
                    else
                    {
                        ckbCervicalGH.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[肥大]") > -1)
                    {
                        ckbCervicalFD.Checked = true;
                    }
                    else
                    {
                        ckbCervicalFD.Checked = false;
                    }


                    if (strCervicalTemp.IndexOf("[萎缩]") > -1)
                    {
                        ckbCervicalWS.Checked = true;
                    }
                    else
                    {
                        ckbCervicalWS.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[充血]") > -1)
                    {
                        ckbCervicalCX.Checked = true;
                    }
                    else
                    {
                        ckbCervicalCX.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[旧裂]") > -1)
                    {
                        ckbCervicalJL.Checked = true;
                    }
                    else
                    {
                        ckbCervicalJL.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[外翻]") > -1)
                    {
                        ckbCervicalWF.Checked = true;
                    }
                    else
                    {
                        ckbCervicalWF.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[囊肿]") > -1)
                    {
                        ckbCervicalNZ.Checked = true;
                    }
                    else
                    {
                        ckbCervicalNZ.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[肌瘤]") > -1)
                    {
                        ckbCervicalJiLiu.Checked = true;
                    }
                    else
                    {
                        ckbCervicalJiLiu.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[颈管炎]") > -1)
                    {
                        ckbCervicalJGY.Checked = true;
                    }
                    else
                    {
                        ckbCervicalJGY.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[息肉]") > -1)
                    {
                        ckbCervicalXR.Checked = true;
                    }
                    else
                    {
                        ckbCervicalXR.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂十]") > -1)
                    {
                        ckbCervicalML10.Checked = true;
                    }
                    else
                    {
                        ckbCervicalML10.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂廿]") > -1)
                    {
                        ckbCervicalML20.Checked = true;
                    }
                    else
                    {
                        ckbCervicalML20.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂卅]") > -1)
                    {
                        ckbCervicalML30.Checked = true;
                    }
                    else
                    {
                        ckbCervicalML30.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂颗粒]") > -1)
                    {
                        ckbCervicalMLKL.Checked = true;
                    }
                    else
                    {
                        ckbCervicalMLKL.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂乳头]") > -1)
                    {
                        ckbCervicalMLRT.Checked = true;
                    }
                    else
                    {
                        ckbCervicalMLRT.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂触血]") > -1)
                    {
                        ckbCervicalMLCX.Checked = true;
                    }
                    else
                    {
                        ckbCervicalMLCX.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂单纯]") > -1)
                    {
                        ckbCervicalMLDC.Checked = true;
                    }
                    else
                    {
                        ckbCervicalMLDC.Checked = false;
                    }
                    if (strCervicalTemp.IndexOf("[糜烂泸泡]") > -1)
                    {
                        ckbCervicalMLLP.Checked = true;
                    }
                    else
                    {
                        ckbCervicalMLLP.Checked = false;
                    }
                    string strUterineTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Uterine"].ToString();//子宫 Uterine
                    if (strUterineTemp.IndexOf("[前位]") > -1)
                    {
                        ckbUterineQW.Checked = true;
                    }
                    else
                    {
                        ckbUterineQW.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[中位]") > -1)
                    {
                        ckbUterineZW.Checked = true;
                    }
                    else
                    {
                        ckbUterineZW.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[后位]") > -1)
                    {
                        ckbUterineHW.Checked = true;
                    }
                    else
                    {
                        ckbUterineHW.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[常大]") > -1)
                    {
                        ckbUterineCD.Checked = true;
                    }
                    else
                    {
                        ckbUterineCD.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[增大]") > -1)
                    {
                        ckbUterineZD.Checked = true;
                    }
                    else
                    {
                        ckbUterineZD.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[缩小]") > -1)
                    {
                        ckbUterineSX.Checked = true;
                    }
                    else
                    {
                        ckbUterineSX.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[萎缩]") > -1)
                    {
                        ckbUterineWS.Checked = true;
                    }
                    else
                    {
                        ckbUterineWS.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[活动]") > -1)
                    {
                        ckbUterineHD.Checked = true;
                    }
                    else
                    {
                        ckbUterineHD.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[久活动]") > -1)
                    {
                        ckbUterineJHD.Checked = true;
                    }
                    else
                    {
                        ckbUterineJHD.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[不活动]") > -1)
                    {
                        ckbUterineBHD.Checked = true;
                    }
                    else
                    {
                        ckbUterineBHD.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[压痛]") > -1)
                    {
                        ckbUterineYT.Checked = true;
                    }
                    else
                    {
                        ckbUterineYT.Checked = false;
                    }
                    if (strUterineTemp.IndexOf("[肌瘤]") > -1)
                    {
                        ckbUterineJL.Checked = true;
                    }
                    else
                    {
                        ckbUterineJL.Checked = false;
                    }
                    string strGenitalTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Genital"].ToString();//外阴 Genital
                    if (strGenitalTemp.IndexOf("[溃疡]") > -1)
                    {
                        ckbGenitalKY.Checked = true;
                    }
                    else
                    {
                        ckbGenitalKY.Checked = false;
                    }
                    if (strGenitalTemp.IndexOf("[湿疹]") > -1)
                    {
                        ckbGenitalSZ.Checked = true;
                    }
                    else
                    {
                        ckbGenitalSZ.Checked = false;
                    }
                    if (strGenitalTemp.IndexOf("[白斑]") > -1)
                    {
                        ckbGenitalBB.Checked = true;
                    }
                    else
                    {
                        ckbGenitalBB.Checked = false;
                    }
                    string strLeucorrheaTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Leucorrhea"].ToString();//白带 Leucorrhea
                    if (strLeucorrheaTemp.IndexOf("[正常]") > -1)
                    {
                        ckbLeucorrheaZC.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaZC.Checked = false;
                    }
                    if (strLeucorrheaTemp.IndexOf("[脓血]") > -1)
                    {
                        ckbLeucorrheaNX.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaNX.Checked = false;
                    }
                    if (strLeucorrheaTemp.IndexOf("[血性]") > -1)
                    {
                        ckbLeucorrheaXX.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaXX.Checked = false;
                    }
                    if (strLeucorrheaTemp.IndexOf("[泡沫]") > -1)
                    {
                        ckbLeucorrheaPM.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaPM.Checked = false;
                    }
                    if (strLeucorrheaTemp.IndexOf("[凝块]") > -1)
                    {
                        ckbLeucorrheaNK.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaNK.Checked = false;
                    }
                    if (strLeucorrheaTemp.IndexOf("[臭味]") > -1)
                    {
                        ckbLeucorrheaCW.Checked = true;
                    }
                    else
                    {
                        ckbLeucorrheaCW.Checked = false;
                    }
                    string strVaginalTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Vaginal"].ToString();//阴道 Vaginal
                    if (strVaginalTemp.IndexOf("[正常]") > -1)
                    {
                        ckbVaginalZC.Checked = true;
                    }
                    else
                    {
                        ckbVaginalZC.Checked = false;
                    }
                    if (strVaginalTemp.IndexOf("[炎症]") > -1)
                    {
                        ckbVaginalYZ.Checked = true;
                    }
                    else
                    {
                        ckbVaginalYZ.Checked = false;
                    }
                    if (strVaginalTemp.IndexOf("[肿瘤]") > -1)
                    {
                        ckbVaginalZL.Checked = true;
                    }
                    else
                    {
                        ckbVaginalZL.Checked = false;
                    }
                    string strAnnexLeftTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AnnexLeft"].ToString();//附件左 AnnexLeft
                    if (strAnnexLeftTemp.IndexOf("[正常]") > -1)
                    {
                        ckbAnnexLeftZC.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftZC.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[增厚十]") > -1)
                    {
                        ckbAnnexLeftZH10.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftZH10.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[增厚廿]") > -1)
                    {
                        ckbAnnexLeftZH20.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftZH20.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[增厚卅]") > -1)
                    {
                        ckbAnnexLeftZH30.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftZH30.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[压痛]") > -1)
                    {
                        ckbAnnexLeftYT.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftYT.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[积液]") > -1)
                    {
                        ckbAnnexLeftJY.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftJY.Checked = false;
                    }
                    if (strAnnexLeftTemp.IndexOf("[囊肿]") > -1)
                    {
                        ckbAnnexLeftNZ.Checked = true;
                    }
                    else
                    {
                        ckbAnnexLeftNZ.Checked = false;
                    }
                    string strAnnexRightTemp = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_AnnexRight"].ToString();//附件右 AnnexRight
                    if (strAnnexRightTemp.IndexOf("[正常]") > -1)
                    {
                        ckbAnnexRightZC.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightZC.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[增厚十]") > -1)
                    {
                        ckbAnnexRightZH10.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightZH10.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[增厚廿]") > -1)
                    {
                        ckbAnnexRightZH20.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightZH20.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[增厚卅]") > -1)
                    {
                        ckbAnnexRightZH30.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightZH30.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[压痛]") > -1)
                    {
                        ckbAnnexRightYT.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightYT.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[积液]") > -1)
                    {
                        ckbAnnexRightJY.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightJY.Checked = false;
                    }
                    if (strAnnexRightTemp.IndexOf("[囊肿]") > -1)
                    {
                        ckbAnnexRightNZ.Checked = true;
                    }
                    else
                    {
                        ckbAnnexRightNZ.Checked = false;
                    }
                    this.txtCheckCases.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_CheckCases"].ToString();//病例检查
                    this.txtInfraredScanBreast.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_InfraredScanBreast"].ToString();//乳腺红外线扫描
                    this.txtFemeConclusion.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Conclusion"].ToString();//结论
                    this.txtFemePhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Feme_Physicians"].ToString();//医师
                    #endregion

                    #region **********报告*****************
                    this.txtChestPerspective.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ChestPerspective"].ToString();//胸部透视
                    this.txtReportLaboratory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Laboratory"].ToString();//化验(肝功、乙肝系列)
                    this.txtReview.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Review"].ToString();//审查单位意见
                    this.txtRemarks.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Remarks"].ToString();//备注
                    #endregion
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            tabControl1.SelectedIndex = 0;
            this.txtName.Focus();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void ClearControl()
        {
            GlobalVal.EmployeeID = "";
            GlobalVal.EmployeeName = "";
            this.txtGlobal_EmployeeID.Text = "";
            this.txtGlobal_EmployeeName.Text = "";
            //**********概要信息*****************
            this.txtName.Text = "";//姓名
            this.txtEmployeeID.Text = "";//员工身份证
            this.txtEmployeeGZID.Text = "";//工资编号
            this.txtEmployeePWD.Text = "";//查询密码
            string strSexTemp = "";//性别            
            this.rdbSexM.Checked = false;
            this.rdbSexW.Checked = false;
            //string strBirthday = "";//出生年月
            //if (strBirthday.Length > 0)
            //{
            //    this.dtpBirthday.Text = strBirthday.Substring(0, 4) + "-" + strBirthday.Substring(4, 2) + "-" + strBirthday.Substring(6, 2);
            //}
            //string age = GetAge(dtpBirthday.Value).ToString();
            //this.txtAge.Text = age;
            this.txtEmployeeWHCD.Text = ""; ;//文化程度
            string HFTemp = "";//婚否
            rdbHF1.Checked = false;
            rdbHF2.Checked = false;
            rdbHF3.Checked = false;
            this.txtJG.Text = "";//籍贯
            this.txtXJD.Text = "";//现住地
            cmbBM.SelectedIndex = 0;
            this.txtDW.Text = "";//单位
            this.txtJWBS.Text = "";//既往病史
            //**********生化检验单*****************
            this.txtHY_No.Text = "";//化验号
            this.txtHY_Dr.Text = "";//医师
            this.txtHY_TC.Text = "";//总胆固醇(TC)
            this.txtHY_TG.Text = "";//甘油三脂(TG)
            this.txtHY_HDL_C.Text = "";//高密度脂蛋白胆固醇(HDL-C)
            this.txtHY_TBIL.Text = "";//总胆红素(TBIL)
            this.txtHY_DBIL.Text = "";//直接胆红素(DBIL)
            this.txtHY_TP.Text = "";//总蛋白(TP)
            this.txtHY_ALB.Text = "";//白蛋白(ALB)
            this.txtHY_ALT.Text = "";//谷丙转氨酶(ALT)
            this.txtGLU.Text = "";//血糖
            this.txtUREA.Text = "";//尿素
            this.txtCR.Text = "";//肌酐
            this.txtAFP.Text = "";//甲胎蛋白
            this.txtCEA.Text = "";//癌胚抗原
            rdbHBsAg1.Checked = false;
            rdbHBsAg2.Checked = false;
            rdbHBsAb1.Checked = false;
            rdbHBsAb2.Checked = false;
            rdbHBeAg1.Checked = false;
            rdbHBeAg2.Checked = false;
            rdbHBeAb1.Checked = false;
            rdbHBeAb2.Checked = false;
            rdbHBcAb1.Checked = false;
            rdbHBcAb2.Checked = false;
            //**********体格检查（五官）*****************
            this.txtLeftEye.Text = "";//视力左
            this.txtRightEye.Text = "";//视力右
            this.txtCorrectedLeft.Text = "";//矫正视力左
            this.txtCorrectedRight.Text = "";//矫正视力右
            this.txtColorVisionForce.Text = "";//辨色力
            this.txtTrachomaLeft.Text = "";//沙眼左
            this.txtTrachomaRight.Text = "";//沙眼右
            this.txtOtherEye.Text = "";//眼其他
            this.txtListeningLeft.Text = "";//听力左
            this.txtListeningRight.Text = "";//听力右
            this.txtEar.Text = "";//耳疾
            this.txtOlfactory.Text = "";//嗅觉
            this.txtNoseParanasalSinusDisease.Text = "";//鼻及鼻窦疾病
            this.txtThroat.Text = "";//咽喉
            this.txtLipPalate.Text = "";//唇腭
            this.txtStuttering.Text = "";//口吃
            this.txtCaries.Text = "";//龋齿
            this.txtMissingTeeth.Text = "";//缺齿
            this.txtPeriodontalDisease.Text = "";//牙周病
            this.txtFeaturesOther.Text = "";//其他
            this.txtMedicalAdvice.Text = "";//医生意见
            this.txtFeaturesPhysicians.Text = "";//医师
            //**********体格检查（外科）*****************
            this.txtLength.Text = "";//身长
            this.txtBust.Text = "";//胸围
            this.txtWeight.Text = "";//体重
            this.txtBadBreath.Text = "";//呼吸差
            this.txtSkin.Text = "";//皮肤
            this.txtLymphoid.Text = "";//淋巴
            this.txtThyroid.Text = "";//甲状腺
            this.txtSpine.Text = "";//脊柱
            this.txtLimbs.Text = "";//四肢
            this.txtJoint.Text = "";//关节
            this.txtFlatfoot.Text = "";//扁平足
            this.txtGenitourinary.Text = "";//泌尿生殖器
            this.txtAnal.Text = "";//肛门
            this.txtHernia.Text = "";//疝
            this.txtSurgeryOther.Text = "";//其他
            this.txtSurgeryMedicalAdvice.Text = "";//医生意见
            this.txtSurgeryPhysicians.Text = "";//医师
            //**********体格检查（内科）*****************
            this.txtBloodPressure.Text = "";//血压
            this.txtBloodPressure1.Text = "";//血压
            this.txtDevelopmentStatus.Text = "";//发育及营养状况
            this.txtNeurological.Text = "";//神经及精神
            this.txtLung.Text = "";//肺及呼吸道
            this.txtHeartBlood.Text = "";//心脏及血管
            this.txtAbdominalOrgans.Text = "";//腹部器官
            this.txtLiver.Text = "";//肝
            this.txtSpleen.Text = "";//脾
            this.txtInternalMedicineOther.Text = "";//其他
            this.txtInternalMedicineMedicalAdvice.Text = "";//医生意见
            this.txtInternalMedicinePhysicians.Text = "";//医师
            //**********心电图检查*****************
            this.txtECGNo.Text = "";//心电图号
            this.txtClinicalDiagnosis.Text = "";//临床诊断
            this.txtUsedDrugs.Text = "";//曾用药物
            this.txtSummaryHistory.Text = "";//病史概要
            this.txtSummaryBody.Text = "";//查体概要
            string strPatientSituation = "";//病人状况            
            rdbPatientSituation1.Checked = false;
            rdbPatientSituation2.Checked = false;
            txtECGMedicalAdvice.Text = "";//诊断意见            
            this.picECG.Image = null;
            this.txtECGPhysicians.Text = "";//医师
            //**********X线检查*****************
            this.txtPhotoNo.Text = "";//摄影号
            this.txtSymptoms.Text = "";//主要症状
            this.txtLaboratory.Text = "";//体征及化验检查
            this.txtDiagnosis.Text = "";//临床预诊
            this.txtPerspective.Text = "";//透视部位及目的
            this.txtCamera.Text = "";//照相部位及目的
            this.txtXRayResults.Text = "";//透视检查结果            
            this.picXImage.Image = null;
            this.txtXRayPhysicians.Text = "";//医师
            //**********B超检查*****************
            this.txtBID.Text = "";//B超编号
            this.txtHistorySigns.Text = "";//病史及体征
            this.txtLaboratoryExamination.Text = "";//化验检查
            this.txtBDiagnosis.Text = "";//临床预诊
            this.txtPurpose.Text = "";//检查目的和部位
            this.txtBResults.Text = "";//检查结果            
            this.picBImage.Image = null;
            this.txtBPhysicians.Text = "";//医师

            #region **********妇科检查*****************
            this.txtMenarche.Text = "";//月经初潮
            this.txtMenopauseAge.Text = "";//绝经年龄
            rdbMenstrualCycle0.Checked = false;//周期
            rdbMenstrualCycle1.Checked = false;//周期
            rdbMenstrualVolume0.Checked = false;//量
            rdbMenstrualVolume1.Checked = false;//量
            rdbMenstrualVolume2.Checked = false;//量
            rdbDysmenorrhea0.Checked = false;//痛经
            rdbDysmenorrhea1.Checked = false;//痛经
            rdbDysmenorrhea2.Checked = false;//痛经
            ckbDiseaseHistoryGJY.Checked = false;//病史
            ckbDiseaseHistoryFJY.Checked = false;//病史
            ckbDiseaseHistoryZGJL.Checked = false;//病史
            ckbDiseaseHistoryLCNZ.Checked = false;//病史
            ckbDiseaseHistoryYJB.Checked = false;//病史
            rdbFamilyTumorTistory0.Checked = false;//病史家庭肿瘤史
            rdbFamilyTumorTistory1.Checked = false;//病史家庭肿瘤史
            this.txtDiseaseHistoryOther.Text = "";//病史其他
            rdbAndrogenUsed0.Checked = false;//曾用雄性激素
            rdbAndrogenUsed1.Checked = false;//曾用雄性激素
            rdbAndrogenUsed2.Checked = false;//曾用雄性激素
            rdbEstrogenUsed0.Checked = false;//曾用雌性激素
            rdbEstrogenUsed1.Checked = false;//曾用雌性激素
            rdbEstrogenUsed2.Checked = false;//曾用雌性激素
            ckbCervicalGH.Checked = false;//宫颈[光滑]
            ckbCervicalFD.Checked = false;//宫颈[肥大]
            ckbCervicalWS.Checked = false;//宫颈[萎缩]
            ckbCervicalCX.Checked = false;//宫颈[充血]
            ckbCervicalJL.Checked = false;//宫颈[旧裂]
            ckbCervicalWF.Checked = false;//宫颈[外翻]
            ckbCervicalNZ.Checked = false;//宫颈[囊肿]
            ckbCervicalJiLiu.Checked = false;//宫颈[肌瘤]
            ckbCervicalJGY.Checked = false;//宫颈[颈管炎]
            ckbCervicalXR.Checked = false;//宫颈[息肉]
            ckbCervicalML10.Checked = false;//宫颈[糜烂十]
            ckbCervicalML20.Checked = false;//宫颈[糜烂廿]
            ckbCervicalML30.Checked = false;//宫颈[糜烂卅]
            ckbCervicalMLKL.Checked = false;//宫颈[糜烂颗粒]
            ckbCervicalMLRT.Checked = false;//宫颈[糜烂乳头]
            ckbCervicalMLCX.Checked = false;//宫颈[糜烂触血]
            ckbCervicalMLDC.Checked = false;//宫颈[糜烂单纯]
            ckbCervicalMLLP.Checked = false;//宫颈[糜烂泸泡]
            ckbUterineQW.Checked = false;//子宫[前位]
            ckbUterineZW.Checked = false;//子宫[中位]
            ckbUterineHW.Checked = false;//子宫[后位]
            ckbUterineCD.Checked = false;//子宫[常大]
            ckbUterineZD.Checked = false;//子宫[增大]
            ckbUterineSX.Checked = false;//子宫[缩小]
            ckbUterineWS.Checked = false;//子宫[萎缩]
            ckbUterineHD.Checked = false;//子宫[活动]
            ckbUterineJHD.Checked = false;//子宫[久活动]
            ckbUterineBHD.Checked = false;//子宫[不活动]
            ckbUterineYT.Checked = false;//子宫[压痛]
            ckbUterineJL.Checked = false;//子宫[肌瘤]
            ckbGenitalKY.Checked = false;//外阴[溃疡]
            ckbGenitalSZ.Checked = false;//外阴[湿疹]
            ckbGenitalBB.Checked = false;//外阴[白斑]
            ckbLeucorrheaZC.Checked = false;//白带[正常]
            ckbLeucorrheaNX.Checked = false;//白带[脓血]
            ckbLeucorrheaXX.Checked = false;//白带[血性]
            ckbLeucorrheaPM.Checked = false;//白带[泡沫]
            ckbLeucorrheaNK.Checked = false;//白带[凝块]
            ckbLeucorrheaCW.Checked = false;//白带[臭味]
            ckbVaginalZC.Checked = false;//阴道[正常]
            ckbVaginalYZ.Checked = false;//阴道[炎症]
            ckbVaginalZL.Checked = false;//阴道[肿瘤]
            ckbAnnexLeftZC.Checked = false;//附件左[正常]
            ckbAnnexLeftZH10.Checked = false;//附件左[增厚十]
            ckbAnnexLeftZH20.Checked = false;//附件左[增厚廿]
            ckbAnnexLeftZH30.Checked = false;//附件左[增厚卅]
            ckbAnnexLeftYT.Checked = false;//附件左[压痛]
            ckbAnnexLeftJY.Checked = false;//附件左[积液]
            ckbAnnexLeftNZ.Checked = false;//附件左[囊肿]
            ckbAnnexRightZC.Checked = false;//附件右[正常]
            ckbAnnexRightZH10.Checked = false;//附件右[增厚十]
            ckbAnnexRightZH20.Checked = false;//附件右[增厚廿]
            ckbAnnexRightZH30.Checked = false;//附件右[增厚卅]
            ckbAnnexRightYT.Checked = false;//附件右[压痛]
            ckbAnnexRightJY.Checked = false;//附件右[积液]
            ckbAnnexRightNZ.Checked = false;//附件右[囊肿]
            this.txtCheckCases.Text = "";//病例检查
            this.txtInfraredScanBreast.Text = "";//乳腺红外线扫描
            this.txtFemeConclusion.Text = "";//结论
            this.txtFemePhysicians.Text = "";//医师
            #endregion

            //**********体成分*****************
            rdbFatType1.Checked = false;
            rdbFatType2.Checked = false;
            rdbFatEvaluate1.Checked = false;
            rdbFatEvaluate2.Checked = false;
            rdbFatEvaluate3.Checked = false;
            rdbFatEvaluate4.Checked = false;
            rdbFatEvaluate5.Checked = false;
            rdbFatEvaluate6.Checked = false;
            rdbFatEvaluate7.Checked = false;
            rdbFatEvaluate8.Checked = false;
            rdbFatEvaluate9.Checked = false;
            this.txtFatTarget.Text="";
            this.txtMuscleTarget.Text = "";
            this.txtBodyWeightTarget.Text = "";
            this.txtCompositionPhysicians.Text = "";
            //**********报告*****************
            this.txtChestPerspective.Text = "";//胸部透视
            this.txtReportLaboratory.Text = "";//化验(肝功、乙肝系列)
            this.txtReview.Text = "";//审查单位意见
            this.txtRemarks.Text = "";//备注
        }

        /// <summary>
        /// 保存模板 B超
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBBexamination_Click(object sender, EventArgs e)
        {            
            XTHotpatalWebServices.Bexamination model = new XTHospitalUI.XTHotpatalWebServices.Bexamination();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";
            model.BID = this.txtBID.Text.Trim();
            model.HistorySigns = this.txtHistorySigns.Text.Trim();
            model.LaboratoryExamination = this.txtLaboratoryExamination.Text.Trim();
            model.Diagnosis = this.txtBDiagnosis.Text.Trim();
            model.Purpose = this.txtPurpose.Text.Trim();
            model.Results = this.txtBResults.Text.Trim();
            if (picBImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picBImage.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.BImage = buffer;
            }
            else
            {
                model.BImage = null;
            }
            model.Physicians = this.txtBPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateBexamination(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 保存模板 X线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBXray_Click(object sender, EventArgs e)
        {   
            XTHotpatalWebServices.Xray model = new XTHospitalUI.XTHotpatalWebServices.Xray();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";
            model.PhotoNo = this.txtPhotoNo.Text.Trim();
            model.Symptoms = this.txtSymptoms.Text.Trim();
            model.Laboratory = this.txtLaboratory.Text.Trim();
            model.Diagnosis = this.txtDiagnosis.Text.Trim();
            model.Perspective = this.txtPerspective.Text.Trim();
            model.Camera = this.txtCamera.Text.Trim();
            model.Results = this.txtXRayResults.Text.Trim();
            if (picXImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picXImage.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.XImage = buffer;
            }
            else
            {
                model.XImage = null;
            }
            model.Physicians = this.txtXRayPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateXray(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 保存模板 心电图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBECG_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.ECG model = new XTHospitalUI.XTHotpatalWebServices.ECG();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";

            model.ECGNo = this.txtECGNo.Text.Trim();
            model.ClinicalDiagnosis = this.txtClinicalDiagnosis.Text.Trim();
            model.UsedDrugs = this.txtUsedDrugs.Text.Trim();
            model.SummaryHistory = this.txtSummaryHistory.Text.Trim();
            model.SummaryBody = this.txtSummaryBody.Text.Trim();
            if (rdbPatientSituation1.Checked)
            {
                model.PatientSituation = "1";
            }
            else if (rdbPatientSituation2.Checked)
            {
                model.PatientSituation = "2";
            }
            else
            {
                model.PatientSituation = "";
            }

            model.MedicalAdvice = this.txtECGMedicalAdvice.Text.Trim();
            if (picECG.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picECG.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] buffer = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                model.ECGImage = buffer;
            }
            else
            {
                model.ECGImage = null;
            }
            model.Physicians = this.txtECGPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateECG(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 保存模板 体格检查-内科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBInternalMedicine_Click(object sender, EventArgs e)
        {   
            XTHotpatalWebServices.InternalMedicine model = new XTHospitalUI.XTHotpatalWebServices.InternalMedicine();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";
            model.BloodPressure = this.txtBloodPressure.Text.Trim();
            model.BloodPressure1 = this.txtBloodPressure1.Text.Trim();
            model.DevelopmentStatus = this.txtDevelopmentStatus.Text.Trim();
            model.Neurological = this.txtNeurological.Text.Trim();
            model.Lung = this.txtLung.Text.Trim();
            model.HeartBlood = this.txtHeartBlood.Text.Trim();
            model.AbdominalOrgans = this.txtAbdominalOrgans.Text.Trim();
            model.Liver = this.txtLiver.Text.Trim();
            model.Spleen = this.txtSpleen.Text.Trim();
            model.Other = this.txtInternalMedicineOther.Text.Trim();
            model.MedicalAdvice = this.txtInternalMedicineMedicalAdvice.Text.Trim();
            model.Physicians = this.txtInternalMedicinePhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateInternalMeicine(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 保存模板 体格检查-外科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBSurgery_Click(object sender, EventArgs e)
        {   
            XTHotpatalWebServices.Surgery model = new XTHospitalUI.XTHotpatalWebServices.Surgery();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";
            model.Length = this.txtLength.Text.Trim();
            model.Bust = this.txtBust.Text.Trim();
            model.Weight = this.txtWeight.Text.Trim();
            model.BadBreath = this.txtBadBreath.Text.Trim();
            model.Skin = this.txtSkin.Text.Trim();
            model.Lymphoid = this.txtLymphoid.Text.Trim();
            model.Thyroid = this.txtThyroid.Text.Trim();
            model.Spine = this.txtSpine.Text.Trim();
            model.Limbs = this.txtLimbs.Text.Trim();
            model.Joint = this.txtJoint.Text.Trim();
            model.Flatfoot = this.txtFlatfoot.Text.Trim();
            model.Genitourinary = this.txtGenitourinary.Text.Trim();
            model.Anal = this.txtAnal.Text.Trim();
            model.Hernia = this.txtHernia.Text.Trim();
            model.Other = this.txtSurgeryOther.Text.Trim();
            model.MedicalAdvice = this.txtSurgeryMedicalAdvice.Text.Trim();
            model.Physicians = this.txtSurgeryPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateSurgery(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 保存模板 体格检查-五官
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMBFeatures_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Features model = new XTHospitalUI.XTHotpatalWebServices.Features();
            model.EmployeeID = "000000000000000000";
            model.YearMonth = "000000";
            model.LeftEye = this.txtLeftEye.Text.Trim();
            model.RightEye = this.txtRightEye.Text.Trim();
            model.CorrectedLeft = this.txtCorrectedLeft.Text.Trim();
            model.CorrectedRight = this.txtCorrectedRight.Text.Trim();
            model.ColorVisionForce = this.txtColorVisionForce.Text.Trim();
            model.TrachomaLeft = this.txtTrachomaLeft.Text.Trim();
            model.TrachomaRight = this.txtTrachomaRight.Text.Trim();
            model.OtherEye = this.txtOtherEye.Text.Trim();
            model.ListeningLeft = this.txtListeningLeft.Text.Trim();
            model.ListeningRight = this.txtListeningRight.Text.Trim();
            model.Ear = this.txtEar.Text.Trim();
            model.Olfactory = this.txtOlfactory.Text.Trim();
            model.NoseParanasalSinusDisease = this.txtNoseParanasalSinusDisease.Text.Trim();
            model.Throat = this.txtThroat.Text.Trim();
            model.LipPalate = this.txtLipPalate.Text.Trim();
            model.Stuttering = this.txtStuttering.Text.Trim();
            model.Caries = this.txtCaries.Text.Trim();
            model.MissingTeeth = this.txtMissingTeeth.Text.Trim();
            model.PeriodontalDisease = this.txtPeriodontalDisease.Text.Trim();
            model.Other = this.txtFeaturesOther.Text.Trim();
            model.MedicalAdvice = this.txtMedicalAdvice.Text.Trim();
            model.Physicians = this.txtFeaturesPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateFeatures(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 体格检查-五官
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBFeatures_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {   
                    //**********体格检查（五官）*****************
                    this.txtLeftEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LeftEye"].ToString();//视力左
                    this.txtRightEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_RightEye"].ToString();//视力右
                    this.txtCorrectedLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedLeft"].ToString();//矫正视力左
                    this.txtCorrectedRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_CorrectedRight"].ToString();//矫正视力右
                    this.txtColorVisionForce.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ColorVisionForce"].ToString();//辨色力
                    this.txtTrachomaLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaLeft"].ToString();//沙眼左
                    this.txtTrachomaRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_TrachomaRight"].ToString();//沙眼右
                    this.txtOtherEye.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_OtherEye"].ToString();//眼其他
                    this.txtListeningLeft.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningLeft"].ToString();//听力左
                    this.txtListeningRight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_ListeningRight"].ToString();//听力右
                    this.txtEar.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Ear"].ToString();//耳疾
                    this.txtOlfactory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Olfactory"].ToString();//嗅觉
                    this.txtNoseParanasalSinusDisease.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_NoseParanasalSinusDisease"].ToString();//鼻及鼻窦疾病
                    this.txtThroat.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Throat"].ToString();//咽喉
                    this.txtLipPalate.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_LipPalate"].ToString();//唇腭
                    this.txtStuttering.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Stuttering"].ToString();//口吃
                    this.txtCaries.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Caries"].ToString();//龋齿
                    this.txtMissingTeeth.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MissingTeeth"].ToString();//缺齿
                    this.txtPeriodontalDisease.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_PeriodontalDisease"].ToString();//牙周病
                    this.txtFeaturesOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Other"].ToString();//其他
                    this.txtMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_MedicalAdvice"].ToString();//医生意见
                    this.txtFeaturesPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Fea_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 体格检查-外科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBSurgery_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {   
                    //**********体格检查（外科）*****************
                    this.txtLength.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Length"].ToString();//身长
                    this.txtBust.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Bust"].ToString();//胸围
                    this.txtWeight.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Weight"].ToString();//体重
                    this.txtBadBreath.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_BadBreath"].ToString();//呼吸差
                    this.txtSkin.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Skin"].ToString();//皮肤
                    this.txtLymphoid.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Lymphoid"].ToString();//淋巴
                    this.txtThyroid.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Thyroid"].ToString();//甲状腺
                    this.txtSpine.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Spine"].ToString();//脊柱
                    this.txtLimbs.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Limbs"].ToString();//四肢
                    this.txtJoint.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Joint"].ToString();//关节
                    this.txtFlatfoot.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Flatfoot"].ToString();//扁平足
                    this.txtGenitourinary.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Genitourinary"].ToString();//泌尿生殖器
                    this.txtAnal.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Anal"].ToString();//肛门
                    this.txtHernia.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Hernia"].ToString();//疝
                    this.txtSurgeryOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Other"].ToString();//其他
                    this.txtSurgeryMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_MedicalAdvice"].ToString();//医生意见
                    this.txtSurgeryPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Sur_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 体格检查-内科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBInternalMedicine_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {   
                    //**********体格检查（内科）*****************
                    this.txtBloodPressure.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure"].ToString();//血压
                    this.txtBloodPressure1.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_BloodPressure1"].ToString();//血压
                    this.txtDevelopmentStatus.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_DevelopmentStatus"].ToString();//发育及营养状况
                    this.txtNeurological.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Neurological"].ToString();//神经及精神
                    this.txtLung.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Lung"].ToString();//肺及呼吸道
                    this.txtHeartBlood.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_HeartBlood"].ToString();//心脏及血管
                    this.txtAbdominalOrgans.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_AbdominalOrgans"].ToString();//腹部器官
                    this.txtLiver.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Liver"].ToString();//肝
                    this.txtSpleen.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Spleen"].ToString();//脾
                    this.txtInternalMedicineOther.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Other"].ToString();//其他
                    this.txtInternalMedicineMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_MedicalAdvice"].ToString();//医生意见
                    this.txtInternalMedicinePhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Int_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 心电图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBECG_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    //**********心电图检查*****************
                    this.txtECGNo.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_No"].ToString();//心电图号
                    this.txtClinicalDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_ClinicalDiagnosis"].ToString();//临床诊断
                    this.txtUsedDrugs.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_UsedDrugs"].ToString();//曾用药物
                    this.txtSummaryHistory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryHistory"].ToString();//病史概要
                    this.txtSummaryBody.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_SummaryBody"].ToString();//查体概要
                    string strPatientSituation = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_PatientSituation"].ToString();//病人状况
                    if (strPatientSituation == "1")
                    {
                        rdbPatientSituation1.Checked = true;
                        rdbPatientSituation2.Checked = false;
                    }
                    else if (strPatientSituation == "2")
                    {
                        rdbPatientSituation1.Checked = false;
                        rdbPatientSituation2.Checked = true;
                    }
                    else
                    {
                        rdbPatientSituation1.Checked = false;
                        rdbPatientSituation2.Checked = false;
                    }
                    txtECGMedicalAdvice.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_MedicalAdvice"].ToString();//诊断意见
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"] != DBNull.Value)
                    {
                        MemoryStream msECG = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Image"]);
                        Image imageECG = Image.FromStream(msECG, true);
                        this.picECG.Image = imageECG;
                    }
                    else
                    {
                        this.picECG.Image = null;
                    }
                    this.txtECGPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["ECT_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 X线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBXray_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    //**********X线检查*****************
                    this.txtPhotoNo.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_PhotoNo"].ToString();//摄影号
                    this.txtSymptoms.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Symptoms"].ToString();//主要症状
                    this.txtLaboratory.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Laboratory"].ToString();//体征及化验检查
                    this.txtDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Diagnosis"].ToString();//临床预诊
                    this.txtPerspective.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Perspective"].ToString();//透视部位及目的
                    this.txtCamera.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Camera"].ToString();//照相部位及目的
                    this.txtXRayResults.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Results"].ToString();//透视检查结果

                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"] != DBNull.Value)
                    {
                        MemoryStream msXray = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Xray_XImage"]);
                        Image imageXray = Image.FromStream(msXray, true);
                        this.picXImage.Image = imageXray;
                    }
                    else
                    {
                        this.picXImage.Image = null;
                    }
                    this.txtXRayPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Xray_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 导入模板 B超
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputMBBexamination_Click(object sender, EventArgs e)
        {
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.SearchEmployeeAllInfo("000000000000000000", "000000");
            if (resoult.ErrorFlag)
            {
                if (resoult.Count > 0)
                {
                    //**********B超检查*****************
                    this.txtBID.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BID"].ToString();//B超编号
                    this.txtHistorySigns.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_HistorySigns"].ToString();//病史及体征
                    this.txtLaboratoryExamination.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_LaboratoryExamination"].ToString();//化验检查
                    this.txtBDiagnosis.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Diagnosis"].ToString();//临床预诊
                    this.txtPurpose.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Purpose"].ToString();//检查目的和部位
                    this.txtBResults.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Results"].ToString();//检查结果
                    if (resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"] != DBNull.Value)
                    {
                        MemoryStream msBex = new MemoryStream((byte[])resoult.ResultDataSet.Tables[0].Rows[0]["Bex_BImage"]);
                        Image imageBex = Image.FromStream(msBex, true);
                        this.picBImage.Image = imageBex;
                    }
                    else
                    {
                        this.picBImage.Image = null;
                    }
                    this.txtBPhysicians.Text = resoult.ResultDataSet.Tables[0].Rows[0]["Bex_Physicians"].ToString();//医师
                }
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        /// <summary>
        /// 妇科检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFemeAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Feme model = new XTHospitalUI.XTHotpatalWebServices.Feme();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;
            model.Menarche=txtMenarche.Text.Trim();				//月经初潮
            model.MenopauseAge = txtMenopauseAge.Text.Trim();	//绝经年龄
            //*****************************************
            if(rdbMenstrualCycle0.Checked)
            {
                model.MenstrualCycle = "0";		//月经周期
            }
            else if (rdbMenstrualCycle1.Checked)
            {
                model.MenstrualCycle = "1";		//月经周期
            }
            else
            {
                model.MenstrualCycle = "";		//月经周期
            }
            //*****************************************
            if (rdbMenstrualVolume0.Checked)
            {
                model.MenstrualVolume = "0";		//月经量
            }
            else if (rdbMenstrualVolume1.Checked)
            {
                model.MenstrualVolume = "1";		//月经量
            }
            else if (rdbMenstrualVolume2.Checked)
            {
                model.MenstrualVolume = "2";		//月经量
            }
            else
            {
                model.MenstrualVolume = "";		//月经量
            }
            //*****************************************
            if (rdbDysmenorrhea0.Checked)
            {
                model.Dysmenorrhea = "0";		//痛经
            }
            else if (rdbDysmenorrhea1.Checked)
            {
                model.Dysmenorrhea = "1";		//痛经
            }
            else if (rdbDysmenorrhea2.Checked)
            {
                model.Dysmenorrhea = "2";		//痛经
            }
            else
            {
                model.Dysmenorrhea = "";		//痛经
            }
            //****************病史*********************
            if (ckbDiseaseHistoryGJY.Checked)
            {
                model.DiseaseHistory += "[宫颈炎]";
            }
            if (ckbDiseaseHistoryFJY.Checked)
            {
                model.DiseaseHistory += "[附件炎]";
            }
            if (ckbDiseaseHistoryZGJL.Checked)
            {
                model.DiseaseHistory += "[子宫肌瘤]";
            }
            if (ckbDiseaseHistoryLCNZ.Checked)
            {
                model.DiseaseHistory += "[卵巢囊肿]";
            }
            if (ckbDiseaseHistoryYJB.Checked)
            {
                model.DiseaseHistory += "[月经病]";
            }
            //*****************************************
            if (rdbFamilyTumorTistory0.Checked)
            {
                model.FamilyTumorTistory = "0";	//病史家庭肿瘤史
            }
            else if (rdbFamilyTumorTistory1.Checked)
            {
                model.FamilyTumorTistory = "1";	//病史家庭肿瘤史
            }
            else
            {
                model.FamilyTumorTistory = "";	//病史家庭肿瘤史
            }
            model.DiseaseHistoryOther = txtDiseaseHistoryOther.Text.Trim();	//病史其他
            //*****************************************
            if (rdbAndrogenUsed0.Checked)
            {
                model.AndrogenUsed = "0";			//曾用雄性激素
            }
            else if (rdbAndrogenUsed1.Checked)
            {
                model.AndrogenUsed = "1";			//曾用雄性激素
            }
            else if(rdbAndrogenUsed2.Checked)
            {
                model.AndrogenUsed = "2";			//曾用雄性激素
            }
            else
            {
                model.AndrogenUsed = "";			//曾用雄性激素
            }
            //*****************************************
            if (rdbEstrogenUsed0.Checked)
            {
                model.EstrogenUsed = "0";			//曾用雌性激素
            }
            else if (rdbEstrogenUsed1.Checked)
            {
                model.EstrogenUsed = "1";			//曾用雌性激素
            }
            else if (rdbEstrogenUsed2.Checked)
            {
                model.EstrogenUsed = "2";			//曾用雌性激素
            }
            else 
            {
                model.EstrogenUsed = "";			//曾用雌性激素
            }
            //*****************************************
            if (ckbCervicalGH.Checked)
            {
                model.Cervical += "[光滑]";           //宫颈
            }
            if (ckbCervicalFD.Checked)
            {
                model.Cervical += "[肥大]";           //宫颈
            }
            if (ckbCervicalWS.Checked)
            {
                model.Cervical += "[萎缩]";           //宫颈
            }
            if (ckbCervicalCX.Checked)
            {
                model.Cervical += "[充血]";           //宫颈
            }
            if (ckbCervicalJL.Checked)
            {
                model.Cervical += "[旧裂]";           //宫颈
            }
            if (ckbCervicalWF.Checked)
            {
                model.Cervical += "[外翻]";           //宫颈
            }
            if (ckbCervicalNZ.Checked)
            {
                model.Cervical += "[囊肿]";           //宫颈
            }
            if (ckbCervicalJiLiu.Checked)
            {
                model.Cervical += "[肌瘤]";           //宫颈
            }
            if (ckbCervicalJGY.Checked)
            {
                model.Cervical += "[颈管炎]";           //宫颈
            }
            if (ckbCervicalXR.Checked)
            {
                model.Cervical += "[息肉]";           //宫颈
            }
            if (ckbCervicalML10.Checked)
            {
                model.Cervical += "[糜烂十]";           //宫颈
            }
            if (ckbCervicalML20.Checked)
            {
                model.Cervical += "[糜烂廿]";           //宫颈
            }
            if (ckbCervicalML30.Checked)
            {
                model.Cervical += "[糜烂卅]";           //宫颈
            }
            if (ckbCervicalMLKL.Checked)
            {
                model.Cervical += "[糜烂颗粒]";           //宫颈
            }
            if (ckbCervicalMLRT.Checked)
            {
                model.Cervical += "[糜烂乳头]";           //宫颈
            }
            if (ckbCervicalMLCX.Checked)
            {
                model.Cervical += "[糜烂触血]";           //宫颈
            }
            if (ckbCervicalMLDC.Checked)
            {
                model.Cervical += "[糜烂单纯]";           //宫颈
            }
            if (ckbCervicalMLLP.Checked)
            {
                model.Cervical += "[糜烂泸泡]";           //宫颈
            }
            //*****************************************
            if (ckbUterineQW.Checked)
            {
                model.Uterine += "[前位]";				//子宫
            }
            if (ckbUterineZW.Checked)
            {
                model.Uterine += "[中位]";				//子宫
            }
            if (ckbUterineHW.Checked)
            {
                model.Uterine += "[后位]";				//子宫
            }
            if (ckbUterineCD.Checked)
            {
                model.Uterine += "[常大]";				//子宫
            }
            if (ckbUterineZD.Checked)
            {
                model.Uterine += "[增大]";				//子宫
            }
            if (ckbUterineSX.Checked)
            {
                model.Uterine += "[缩小]";				//子宫
            }
            if (ckbUterineWS.Checked)
            {
                model.Uterine += "[萎缩]";				//子宫
            }
            if (ckbUterineHD.Checked)
            {
                model.Uterine += "[活动]";				//子宫
            }
            if (ckbUterineJHD.Checked)
            {
                model.Uterine += "[久活动]";				//子宫
            }
            if (ckbUterineBHD.Checked)
            {
                model.Uterine += "[不活动]";				//子宫
            }
            if (ckbUterineYT.Checked)
            {
                model.Uterine += "[压痛]";				//子宫
            }
            if (ckbUterineJL.Checked)
            {
                model.Uterine += "[肌瘤]";				//子宫
            }
            //*****************************************
            if (ckbGenitalKY.Checked)
            {
                model.Genital += "[溃疡]";				//外阴
            }
            if (ckbGenitalSZ.Checked)
            {
                model.Genital += "[湿疹]";				//外阴
            }
            if (ckbGenitalBB.Checked)
            {
                model.Genital += "[白斑]";				//外阴
            }
            //*****************************************
            if (ckbLeucorrheaZC.Checked)
            {
                model.Leucorrhea += "[正常]";			//白带
            }
            if (ckbLeucorrheaNX.Checked)
            {
                model.Leucorrhea += "[脓血]";			//白带
            }
            if (ckbLeucorrheaXX.Checked)
            {
                model.Leucorrhea += "[血性]";			//白带
            }
            if (ckbLeucorrheaPM.Checked)
            {
                model.Leucorrhea += "[泡沫]";			//白带
            }
            if (ckbLeucorrheaNK.Checked)
            {
                model.Leucorrhea += "[凝块]";			//白带
            }
            if (ckbLeucorrheaCW.Checked)
            {
                model.Leucorrhea += "[臭味]";			//白带
            }
            //*****************************************
            if (ckbVaginalZC.Checked)
            {
                model.Vaginal += "[正常]";				//阴道
            }
            if (ckbVaginalYZ.Checked)
            {
                model.Vaginal += "[炎症]";				//阴道
            }
            if (ckbVaginalZL.Checked)
            {
                model.Vaginal += "[肿瘤]";				//阴道
            }
            //*****************************************
            if (ckbAnnexLeftZC.Checked)
            {
                model.AnnexLeft += "[正常]";			//附件左
            }
            if (ckbAnnexLeftZH10.Checked)
            {
                model.AnnexLeft += "[增厚十]";			//附件左
            }
            if (ckbAnnexLeftZH20.Checked)
            {
                model.AnnexLeft += "[增厚廿]";			//附件左
            }
            if (ckbAnnexLeftZH30.Checked)
            {
                model.AnnexLeft += "[增厚卅]";			//附件左
            }
            if (ckbAnnexLeftYT.Checked)
            {
                model.AnnexLeft += "[压痛]";			//附件左
            }
            if (ckbAnnexLeftJY.Checked)
            {
                model.AnnexLeft += "[积液]";			//附件左
            }
            if (ckbAnnexLeftNZ.Checked)
            {
                model.AnnexLeft += "[囊肿]";			//附件左
            }
            //*****************************************
            if (ckbAnnexRightZC.Checked)
            {
                model.AnnexRight += "[正常]";			//附件右
            }
            if (ckbAnnexRightZH10.Checked)
            {
                model.AnnexRight += "[增厚十]";			//附件右
            }
            if (ckbAnnexRightZH20.Checked)
            {
                model.AnnexRight += "[增厚廿]";			//附件右
            }
            if (ckbAnnexRightZH30.Checked)
            {
                model.AnnexRight += "[增厚卅]";			//附件右
            }
            if (ckbAnnexRightYT.Checked)
            {
                model.AnnexRight += "[压痛]";			//附件右
            }
            if (ckbAnnexRightJY.Checked)
            {
                model.AnnexRight += "[积液]";			//附件右
            }
            if (ckbAnnexRightNZ.Checked)
            {
                model.AnnexRight += "[囊肿]";			//附件右
            }
            //*****************************************
            model.CheckCases = txtCheckCases.Text.Trim();			            //病例检查
            model.InfraredScanBreast = txtInfraredScanBreast.Text.Trim();	    //乳腺红外线扫描
            model.Conclusion = txtFemeConclusion.Text.Trim();			        //结论
            model.Physicians=txtFemePhysicians.Text.Trim();			            //医师
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateFeme(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm = this;
            LogManage frm = new LogManage();
            frm.Show();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {   
            GlobalVal.ShowForm = this;
            DepartmentManage frm = new DepartmentManage();
            frm.Show();
        }

        /// <summary>
        /// 体成分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComposition_Click(object sender, EventArgs e)
        {
            if (GlobalVal.EmployeeID.Trim().Length < 1)
            {
                MessageBox.Show("请先进行人员选择或添加人员！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            XTHotpatalWebServices.Composition model = new XTHospitalUI.XTHotpatalWebServices.Composition();
            model.EmployeeID = GlobalVal.EmployeeID;
            model.YearMonth = GlobalVal.gloYearMonth;

            if (rdbFatType1.Checked)
            {
                model.FatType = "1";
            }
            else if (rdbFatType2.Checked)
            {
                model.FatType = "2";
            }
            else
            {
                MessageBox.Show(@"请选择腹部肥胖/综合评价！");
                return;
            }

            if (rdbFatEvaluate1.Checked)
            {
                model.FatEvaluate = "1";
            }
            else if (rdbFatEvaluate2.Checked)
            {
                model.FatEvaluate = "2";
            }
            else if (rdbFatEvaluate3.Checked)
            {
                model.FatEvaluate = "3";
            }
            else if (rdbFatEvaluate4.Checked)
            {
                model.FatEvaluate = "4";
            }
            else if (rdbFatEvaluate5.Checked)
            {
                model.FatEvaluate = "5";
            }
            else if (rdbFatEvaluate6.Checked)
            {
                model.FatEvaluate = "6";
            }
            else if (rdbFatEvaluate7.Checked)
            {
                model.FatEvaluate = "7";
            }
            else if (rdbFatEvaluate8.Checked)
            {
                model.FatEvaluate = "8";
            }
            else if (rdbFatEvaluate9.Checked)
            {
                model.FatEvaluate = "9";
            }
            else
            {
                MessageBox.Show(@"请选择评估！");
                return;
            }

            model.FatTarget = this.txtFatTarget.Text.Trim();
            model.MuscleTarget = this.txtMuscleTarget.Text.Trim();
            model.BodyWeightTarget = this.txtBodyWeightTarget.Text.Trim();
            model.Physicians = this.txtCompositionPhysicians.Text.Trim();
            model.UPDATER_ID = GlobalVal.gloStrLoginUserID;
            model.TERMINAL_CD = GlobalVal.gloStrTerminalCD;
            XTHotpatalWebServices.Service webService = new XTHospitalUI.XTHotpatalWebServices.Service();
            XTHotpatalWebServices.ReturnValue resoult = webService.AddUpdateComposition(model);
            if (resoult.ErrorFlag)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show(resoult.ErrorID);
            }
        }
    }
}