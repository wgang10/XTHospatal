CREATE TABLE Department (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	ID                            nvarchar(50)   	,	/* 部门编号 */
	Name                          nvarchar(50)   	NOT NULL,	/* 部门名称 */
	Memo                          nvarchar(256)  	,	/* 备注 */
	CONSTRAINT IPK_Depa
		PRIMARY KEY  (ID)
);

CREATE TABLE Employee (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	ID                            nvarchar(18)   	,	/* 员工身份证 */
	Name                          nvarchar(50)   	NOT NULL,	/* 姓名 */
	Sex                           char(1)        	,	/* 性别 */
	Birthday                      datetime       	,	/* 出生年月 */
	Education                     nvarchar(50)   	,	/* 文化程度 */
	Matrimony                     char(1)        	,	/* 婚否 */
	BirthPlace                    nvarchar(50)   	,	/* 籍贯 */
	Address                       nvarchar(256)  	,	/* 现住地 */
	Department                    nvarchar(50)   	,	/* 部门 */
	Unit                          nvarchar(256)  	,	/* 单位 */
	MedichalHistory               nvarchar(1024) 	,	/* 既往病史 */
	QueryID                       nvarchar(50)   	,	/* 工资号 */
	QueryPassword                 nvarchar(50)   	,	/* 查询密码 */
	Email                         nvarchar(256)  	,	/* 邮箱 */
	PhoneNo                       nvarchar(50)   	,	/* 电话 */
	ValidateCode                  nvarchar(50)   	,	/* 验证码 */
	CONSTRAINT IPK_Empl
		PRIMARY KEY  (ID)
);

CREATE TABLE Biochemistry (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	HYNo                          nvarchar(10)   	,	/* 化验号 */
	HYDr                          nvarchar(50)   	,	/* 医师 */
	HYTC                          nvarchar(10)   	,	/* 总胆固醇(TC) */
	HYTG                          nvarchar(10)   	,	/* 甘油三脂(TG) */
	HYHDLC                        nvarchar(10)   	,	/* 高密度脂蛋白胆固醇(HDL-C) */
	HYTBIL                        nvarchar(10)   	,	/* 总胆红素(TBIL) */
	HYDBIL                        nvarchar(10)   	,	/* 直接胆红素(DBIL) */
	HYTP                          nvarchar(10)   	,	/* 总蛋白(TP) */
	HYALB                         nvarchar(10)   	,	/* 白蛋白(ALB) */
	HYALT                         nvarchar(10)   	,	/* 谷丙转氨酶(ALT) */
	HYHBsAg                       nvarchar(1)    	,	/* HBsAg */
	HYHBsAb                       nvarchar(1)    	,	/* HBsAb */
	HYHBeAg                       nvarchar(1)    	,	/* HBeAg */
	HYHBeAb                       nvarchar(1)    	,	/* HBeAb */
	HYHBcAb                       nvarchar(1)    	,	/* HBcAb */
	HY_GLU                        nvarchar(10)   	,	/* 血糖 */
	HY_UREA                       nvarchar(10)   	,	/* 尿素 */
	HY_CR                         nvarchar(10)   	,	/* 肌酐 */
	HY_AFP                        nvarchar(10)   	,	/* 甲胎蛋白 */
	HY_CEA                        nvarchar(10)   	,	/* 癌胚抗原 */
	CONSTRAINT IPK_Bioc
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE LoginUser (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	LoginID                       nvarchar(50)   	NOT NULL,	/* 帐号 */
	LoginPassword                 nvarchar(50)   	NOT NULL,	/* 密码 */
	UserType                      char(1)        	NOT NULL,	/* 权限 */
	Memo                          nvarchar(256)  	,	/* 备注 */
	CONSTRAINT IPK_Logi
		PRIMARY KEY  (LoginID)
);

CREATE TABLE YearMonth (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	SelectYearMonth               char(6)        	,	/* 年月 */
	CONSTRAINT IPK_Year
		PRIMARY KEY  (SelectYearMonth)
);

CREATE TABLE Features (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	LeftEye                       nvarchar(6)    	,	/* 视力左 */
	RightEye                      nvarchar(6)    	,	/* 视力右 */
	CorrectedLeft                 nvarchar(6)    	,	/* 矫正视力左 */
	CorrectedRight                nvarchar(6)    	,	/* 矫正视力右 */
	ColorVisionForce              nvarchar(12)   	,	/* 辨色力 */
	TrachomaLeft                  nvarchar(12)   	,	/* 沙眼左 */
	TrachomaRight                 nvarchar(12)   	,	/* 沙眼右 */
	OtherEye                      nvarchar(50)   	,	/* 眼其他 */
	ListeningLeft                 nvarchar(6)    	,	/* 听力左 */
	ListeningRight                nvarchar(6)    	,	/* 听力右 */
	Ear                           nvarchar(50)   	,	/* 耳疾 */
	Olfactory                     nvarchar(50)   	,	/* 嗅觉 */
	NoseParanasalSinusDisease     nvarchar(128)  	,	/* 鼻及鼻窦疾病 */
	Throat                        nvarchar(128)  	,	/* 咽喉 */
	LipPalate                     nvarchar(128)  	,	/* 唇腭 */
	Stuttering                    nvarchar(50)   	,	/* 口吃 */
	Caries                        nvarchar(50)   	,	/* 龋齿 */
	MissingTeeth                  nvarchar(50)   	,	/* 缺齿 */
	PeriodontalDisease            nvarchar(128)  	,	/* 牙周病 */
	Other                         nvarchar(256)  	,	/* 其他 */
	MedicalAdvice                 nvarchar(1024) 	,	/* 医生意见 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Feat
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Surgery (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	Length                        nvarchar(8)    	,	/* 身长 */
	Bust                          nvarchar(8)    	,	/* 胸围 */
	Weight                        nvarchar(8)    	,	/* 体重 */
	BadBreath                     nvarchar(50)   	,	/* 呼吸差 */
	Skin                          nvarchar(128)  	,	/* 皮肤 */
	Lymphoid                      nvarchar(128)  	,	/* 淋巴 */
	Thyroid                       nvarchar(128)  	,	/* 甲状腺 */
	Spine                         nvarchar(128)  	,	/* 脊柱 */
	Limbs                         nvarchar(128)  	,	/* 四肢 */
	Joint                         nvarchar(128)  	,	/* 关节 */
	Flatfoot                      nvarchar(128)  	,	/* 扁平足 */
	Genitourinary                 nvarchar(128)  	,	/* 泌尿生殖器 */
	Anal                          nvarchar(128)  	,	/* 肛门 */
	Hernia                        nvarchar(128)  	,	/* 疝 */
	Other                         nvarchar(256)  	,	/* 其他 */
	MedicalAdvice                 nvarchar(1024) 	,	/* 医生意见 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Surg
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE InternalMedicine (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	BloodPressure                 nvarchar(12)   	,	/* 血压(千帕) */
	BloodPressure1                nvarchar(12)   	,	/* 血压(毫米汞柱) */
	DevelopmentStatus             nvarchar(1024) 	,	/* 发育及营养状况 */
	Neurological                  nvarchar(256)  	,	/* 神经及精神 */
	Lung                          nvarchar(256)  	,	/* 肺及呼吸道 */
	HeartBlood                    nvarchar(256)  	,	/* 心脏及血管 */
	AbdominalOrgans               nvarchar(256)  	,	/* 腹部器官 */
	Liver                         nvarchar(256)  	,	/* 肝 */
	Spleen                        nvarchar(256)  	,	/* 脾 */
	Other                         nvarchar(256)  	,	/* 其他 */
	MedicalAdvice                 nvarchar(1024) 	,	/* 医生意见 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Inte
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE ECG (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	ECGNo                         nvarchar(10)   	,	/* 心电图号 */
	ClinicalDiagnosis             nvarchar(1024) 	,	/* 临床诊断 */
	UsedDrugs                     nvarchar(256)  	,	/* 曾用药物 */
	SummaryHistory                nvarchar(1024) 	,	/* 病史概要 */
	SummaryBody                   nvarchar(1024) 	,	/* 查体概要 */
	PatientSituation              nvarchar(1)    	,	/* 病人状况 */
	MedicalAdvice                 nvarchar(1024) 	,	/* 诊断意见 */
	ECG                           Image          	,	/* 图像 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_ECG
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Xray (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	PhotoNo                       nvarchar(10)   	,	/* 摄影号 */
	Symptoms                      nvarchar(256)  	,	/* 主要症状 */
	Laboratory                    nvarchar(256)  	,	/* 体征及化验检查 */
	Diagnosis                     nvarchar(256)  	,	/* 临床预诊 */
	Perspective                   nvarchar(256)  	,	/* 透视部位及目的 */
	Camera                        nvarchar(256)  	,	/* 照相部位及目的 */
	Results                       nvarchar(1024) 	,	/* 透视检查结果 */
	XImage                        Image          	,	/* 图像 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Xray
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Bexamination (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	BID                           nvarchar(10)   	,	/* B超编号 */
	HistorySigns                  nvarchar(1024) 	,	/* 病史及体征 */
	LaboratoryExamination         nvarchar(1024) 	,	/* 化验检查 */
	Diagnosis                     nvarchar(1024) 	,	/* 临床预诊 */
	Purpose                       nvarchar(256)  	,	/* 检查目的和部位 */
	Results                       nvarchar(1024) 	,	/* 检查结果 */
	BImage                        Image          	,	/* 图像 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Bexa
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Report (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	Conclusion                    nvarchar(2048) 	,	/* 结论 */
	Opinion                       nvarchar(2048) 	,	/* 意见 */
	Memo                          nvarchar(2048) 	,	/* 备注 */
	CONSTRAINT IPK_Repo
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Feme (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	Menarche                      nvarchar(3)    	,	/* 月经初潮 */
	MenopauseAge                  nvarchar(3)    	,	/* 绝经年龄 */
	MenstrualCycle                char(1)        	,	/* 周期 */
	MenstrualVolume               char(1)        	,	/* 量 */
	Dysmenorrhea                  char(1)        	,	/* 痛经 */
	DiseaseHistory                nvarchar(50)   	,	/* 病史 */
	FamilyTumorTistory            char(1)        	,	/* 病史家庭肿瘤史 */
	DiseaseHistoryOther           nvarchar(256)  	,	/* 病史其他 */
	AndrogenUsed                  char(1)        	,	/* 曾用雄性激素 */
	EstrogenUsed                  char(1)        	,	/* 曾用雌性激素 */
	Cervical                      nvarchar(256)  	,	/* 宫颈 */
	Uterine                       nvarchar(256)  	,	/* 子宫 */
	Genital                       nvarchar(256)  	,	/* 外阴 */
	Leucorrhea                    nvarchar(256)  	,	/* 白带 */
	Vaginal                       nvarchar(256)  	,	/* 阴道 */
	AnnexLeft                     nvarchar(256)  	,	/* 附件左 */
	AnnexRight                    nvarchar(256)  	,	/* 附件右 */
	CheckCases                    nvarchar(256)  	,	/* 病例检查 */
	InfraredScanBreast            nvarchar(256)  	,	/* 乳腺红外线扫描 */
	Conclusion                    nvarchar(1024) 	,	/* 结论 */
	Physicians                    nvarchar(256)  	,	/* 医师 */
	CONSTRAINT IPK_Feme
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Log (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	LogContent                    nvarchar(1024) 	,	/* 日志内容 */
	Type                          char(1)        	 	/* 类型 */
);

CREATE TABLE Composition (
	CreateDatetime                datetime       	,	/* 数据作成日時 */
	UpdateDatetime                datetime       	,	/* 最終更新日時 */
	UpdateState                   char(1)        	,	/* 最終処理区分 */
	UpdaterID                     nvarchar(50)   	,	/* 更新担当者ID */
	UpdaterIP                     nvarchar(256)  	,	/* 更新端末 */
	EmployeeID                    nvarchar(18)   	,	/* 员工身份证 */
	YearMoth                      nvarchar(6)    	,	/* 年月 */
	FatType                       char(1)        	,	/* 腹部肥胖/综合评价 */
	FatEvaluate                   char(1)        	,	/* 评估 */
	FatTarget                     nvarchar(10)   	,	/* 调节目标脂肪重量 */
	MuscleTarget                  nvarchar(10)   	,	/* 调节目标肌肉重量 */
	BodyWeightTarget              nvarchar(10)   	,	/* 调节目标体重 */
	Physicians                    nvarchar(50)   	,	/* 医师 */
	CONSTRAINT IPK_Comp
		PRIMARY KEY  (EmployeeID, YearMoth)
);

