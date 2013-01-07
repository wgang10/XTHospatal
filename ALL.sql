CREATE TABLE Department (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	ID                            nvarchar(50)   	,	/* ���ű�� */
	Name                          nvarchar(50)   	NOT NULL,	/* �������� */
	Memo                          nvarchar(256)  	,	/* ��ע */
	CONSTRAINT IPK_Depa
		PRIMARY KEY  (ID)
);

CREATE TABLE Employee (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	ID                            nvarchar(18)   	,	/* Ա�����֤ */
	Name                          nvarchar(50)   	NOT NULL,	/* ���� */
	Sex                           char(1)        	,	/* �Ա� */
	Birthday                      datetime       	,	/* �������� */
	Education                     nvarchar(50)   	,	/* �Ļ��̶� */
	Matrimony                     char(1)        	,	/* ��� */
	BirthPlace                    nvarchar(50)   	,	/* ���� */
	Address                       nvarchar(256)  	,	/* ��ס�� */
	Department                    nvarchar(50)   	,	/* ���� */
	Unit                          nvarchar(256)  	,	/* ��λ */
	MedichalHistory               nvarchar(1024) 	,	/* ������ʷ */
	QueryID                       nvarchar(50)   	,	/* ���ʺ� */
	QueryPassword                 nvarchar(50)   	,	/* ��ѯ���� */
	Email                         nvarchar(256)  	,	/* ���� */
	PhoneNo                       nvarchar(50)   	,	/* �绰 */
	ValidateCode                  nvarchar(50)   	,	/* ��֤�� */
	CONSTRAINT IPK_Empl
		PRIMARY KEY  (ID)
);

CREATE TABLE Biochemistry (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	HYNo                          nvarchar(10)   	,	/* ����� */
	HYDr                          nvarchar(50)   	,	/* ҽʦ */
	HYTC                          nvarchar(10)   	,	/* �ܵ��̴�(TC) */
	HYTG                          nvarchar(10)   	,	/* ������֬(TG) */
	HYHDLC                        nvarchar(10)   	,	/* ���ܶ�֬���׵��̴�(HDL-C) */
	HYTBIL                        nvarchar(10)   	,	/* �ܵ�����(TBIL) */
	HYDBIL                        nvarchar(10)   	,	/* ֱ�ӵ�����(DBIL) */
	HYTP                          nvarchar(10)   	,	/* �ܵ���(TP) */
	HYALB                         nvarchar(10)   	,	/* �׵���(ALB) */
	HYALT                         nvarchar(10)   	,	/* �ȱ�ת��ø(ALT) */
	HYHBsAg                       nvarchar(1)    	,	/* HBsAg */
	HYHBsAb                       nvarchar(1)    	,	/* HBsAb */
	HYHBeAg                       nvarchar(1)    	,	/* HBeAg */
	HYHBeAb                       nvarchar(1)    	,	/* HBeAb */
	HYHBcAb                       nvarchar(1)    	,	/* HBcAb */
	HY_GLU                        nvarchar(10)   	,	/* Ѫ�� */
	HY_UREA                       nvarchar(10)   	,	/* ���� */
	HY_CR                         nvarchar(10)   	,	/* ���� */
	HY_AFP                        nvarchar(10)   	,	/* ��̥���� */
	HY_CEA                        nvarchar(10)   	,	/* ���߿�ԭ */
	CONSTRAINT IPK_Bioc
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE LoginUser (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	LoginID                       nvarchar(50)   	NOT NULL,	/* �ʺ� */
	LoginPassword                 nvarchar(50)   	NOT NULL,	/* ���� */
	UserType                      char(1)        	NOT NULL,	/* Ȩ�� */
	Memo                          nvarchar(256)  	,	/* ��ע */
	CONSTRAINT IPK_Logi
		PRIMARY KEY  (LoginID)
);

CREATE TABLE YearMonth (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	SelectYearMonth               char(6)        	,	/* ���� */
	CONSTRAINT IPK_Year
		PRIMARY KEY  (SelectYearMonth)
);

CREATE TABLE Features (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	LeftEye                       nvarchar(6)    	,	/* ������ */
	RightEye                      nvarchar(6)    	,	/* ������ */
	CorrectedLeft                 nvarchar(6)    	,	/* ���������� */
	CorrectedRight                nvarchar(6)    	,	/* ���������� */
	ColorVisionForce              nvarchar(12)   	,	/* ��ɫ�� */
	TrachomaLeft                  nvarchar(12)   	,	/* ɳ���� */
	TrachomaRight                 nvarchar(12)   	,	/* ɳ���� */
	OtherEye                      nvarchar(50)   	,	/* ������ */
	ListeningLeft                 nvarchar(6)    	,	/* ������ */
	ListeningRight                nvarchar(6)    	,	/* ������ */
	Ear                           nvarchar(50)   	,	/* ���� */
	Olfactory                     nvarchar(50)   	,	/* ��� */
	NoseParanasalSinusDisease     nvarchar(128)  	,	/* �Ǽ���񼼲�� */
	Throat                        nvarchar(128)  	,	/* �ʺ� */
	LipPalate                     nvarchar(128)  	,	/* ���� */
	Stuttering                    nvarchar(50)   	,	/* �ڳ� */
	Caries                        nvarchar(50)   	,	/* ȣ�� */
	MissingTeeth                  nvarchar(50)   	,	/* ȱ�� */
	PeriodontalDisease            nvarchar(128)  	,	/* ���ܲ� */
	Other                         nvarchar(256)  	,	/* ���� */
	MedicalAdvice                 nvarchar(1024) 	,	/* ҽ����� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Feat
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Surgery (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	Length                        nvarchar(8)    	,	/* �� */
	Bust                          nvarchar(8)    	,	/* ��Χ */
	Weight                        nvarchar(8)    	,	/* ���� */
	BadBreath                     nvarchar(50)   	,	/* ������ */
	Skin                          nvarchar(128)  	,	/* Ƥ�� */
	Lymphoid                      nvarchar(128)  	,	/* �ܰ� */
	Thyroid                       nvarchar(128)  	,	/* ��״�� */
	Spine                         nvarchar(128)  	,	/* ���� */
	Limbs                         nvarchar(128)  	,	/* ��֫ */
	Joint                         nvarchar(128)  	,	/* �ؽ� */
	Flatfoot                      nvarchar(128)  	,	/* ��ƽ�� */
	Genitourinary                 nvarchar(128)  	,	/* ������ֳ�� */
	Anal                          nvarchar(128)  	,	/* ���� */
	Hernia                        nvarchar(128)  	,	/* �� */
	Other                         nvarchar(256)  	,	/* ���� */
	MedicalAdvice                 nvarchar(1024) 	,	/* ҽ����� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Surg
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE InternalMedicine (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	BloodPressure                 nvarchar(12)   	,	/* Ѫѹ(ǧ��) */
	BloodPressure1                nvarchar(12)   	,	/* Ѫѹ(���׹���) */
	DevelopmentStatus             nvarchar(1024) 	,	/* ������Ӫ��״�� */
	Neurological                  nvarchar(256)  	,	/* �񾭼����� */
	Lung                          nvarchar(256)  	,	/* �μ������� */
	HeartBlood                    nvarchar(256)  	,	/* ���༰Ѫ�� */
	AbdominalOrgans               nvarchar(256)  	,	/* �������� */
	Liver                         nvarchar(256)  	,	/* �� */
	Spleen                        nvarchar(256)  	,	/* Ƣ */
	Other                         nvarchar(256)  	,	/* ���� */
	MedicalAdvice                 nvarchar(1024) 	,	/* ҽ����� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Inte
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE ECG (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	ECGNo                         nvarchar(10)   	,	/* �ĵ�ͼ�� */
	ClinicalDiagnosis             nvarchar(1024) 	,	/* �ٴ���� */
	UsedDrugs                     nvarchar(256)  	,	/* ����ҩ�� */
	SummaryHistory                nvarchar(1024) 	,	/* ��ʷ��Ҫ */
	SummaryBody                   nvarchar(1024) 	,	/* �����Ҫ */
	PatientSituation              nvarchar(1)    	,	/* ����״�� */
	MedicalAdvice                 nvarchar(1024) 	,	/* ������ */
	ECG                           Image          	,	/* ͼ�� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_ECG
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Xray (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	PhotoNo                       nvarchar(10)   	,	/* ��Ӱ�� */
	Symptoms                      nvarchar(256)  	,	/* ��Ҫ֢״ */
	Laboratory                    nvarchar(256)  	,	/* ������������ */
	Diagnosis                     nvarchar(256)  	,	/* �ٴ�Ԥ�� */
	Perspective                   nvarchar(256)  	,	/* ͸�Ӳ�λ��Ŀ�� */
	Camera                        nvarchar(256)  	,	/* ���ಿλ��Ŀ�� */
	Results                       nvarchar(1024) 	,	/* ͸�Ӽ���� */
	XImage                        Image          	,	/* ͼ�� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Xray
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Bexamination (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	BID                           nvarchar(10)   	,	/* B����� */
	HistorySigns                  nvarchar(1024) 	,	/* ��ʷ������ */
	LaboratoryExamination         nvarchar(1024) 	,	/* ������ */
	Diagnosis                     nvarchar(1024) 	,	/* �ٴ�Ԥ�� */
	Purpose                       nvarchar(256)  	,	/* ���Ŀ�ĺͲ�λ */
	Results                       nvarchar(1024) 	,	/* ����� */
	BImage                        Image          	,	/* ͼ�� */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Bexa
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Report (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	Conclusion                    nvarchar(2048) 	,	/* ���� */
	Opinion                       nvarchar(2048) 	,	/* ��� */
	Memo                          nvarchar(2048) 	,	/* ��ע */
	CONSTRAINT IPK_Repo
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Feme (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	Menarche                      nvarchar(3)    	,	/* �¾����� */
	MenopauseAge                  nvarchar(3)    	,	/* �������� */
	MenstrualCycle                char(1)        	,	/* ���� */
	MenstrualVolume               char(1)        	,	/* �� */
	Dysmenorrhea                  char(1)        	,	/* ʹ�� */
	DiseaseHistory                nvarchar(50)   	,	/* ��ʷ */
	FamilyTumorTistory            char(1)        	,	/* ��ʷ��ͥ����ʷ */
	DiseaseHistoryOther           nvarchar(256)  	,	/* ��ʷ���� */
	AndrogenUsed                  char(1)        	,	/* �������Լ��� */
	EstrogenUsed                  char(1)        	,	/* ���ô��Լ��� */
	Cervical                      nvarchar(256)  	,	/* ���� */
	Uterine                       nvarchar(256)  	,	/* �ӹ� */
	Genital                       nvarchar(256)  	,	/* ���� */
	Leucorrhea                    nvarchar(256)  	,	/* �״� */
	Vaginal                       nvarchar(256)  	,	/* ���� */
	AnnexLeft                     nvarchar(256)  	,	/* ������ */
	AnnexRight                    nvarchar(256)  	,	/* ������ */
	CheckCases                    nvarchar(256)  	,	/* ������� */
	InfraredScanBreast            nvarchar(256)  	,	/* ���ٺ�����ɨ�� */
	Conclusion                    nvarchar(1024) 	,	/* ���� */
	Physicians                    nvarchar(256)  	,	/* ҽʦ */
	CONSTRAINT IPK_Feme
		PRIMARY KEY  (EmployeeID, YearMoth)
);

CREATE TABLE Log (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	LogContent                    nvarchar(1024) 	,	/* ��־���� */
	Type                          char(1)        	 	/* ���� */
);

CREATE TABLE Composition (
	CreateDatetime                datetime       	,	/* ���������Օr */
	UpdateDatetime                datetime       	,	/* ��K�����Օr */
	UpdateState                   char(1)        	,	/* ��K�I������ */
	UpdaterID                     nvarchar(50)   	,	/* ���µ�����ID */
	UpdaterIP                     nvarchar(256)  	,	/* ���¶�ĩ */
	EmployeeID                    nvarchar(18)   	,	/* Ա�����֤ */
	YearMoth                      nvarchar(6)    	,	/* ���� */
	FatType                       char(1)        	,	/* ��������/�ۺ����� */
	FatEvaluate                   char(1)        	,	/* ���� */
	FatTarget                     nvarchar(10)   	,	/* ����Ŀ��֬������ */
	MuscleTarget                  nvarchar(10)   	,	/* ����Ŀ�꼡������ */
	BodyWeightTarget              nvarchar(10)   	,	/* ����Ŀ������ */
	Physicians                    nvarchar(50)   	,	/* ҽʦ */
	CONSTRAINT IPK_Comp
		PRIMARY KEY  (EmployeeID, YearMoth)
);

