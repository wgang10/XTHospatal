using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Feme
    {
        #region Model
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _menarche;
        private string _menopauseage;
        private string _menstrualcycle;
        private string _menstrualvolume;
        private string _dysmenorrhea;
        private string _diseasehistory;
        private string _familytumortistory;
        private string _diseasehistoryother;
        private string _androgenused;
        private string _estrogenused;
        private string _cervical;
        private string _uterine;
        private string _genital;
        private string _leucorrhea;
        private string _vaginal;
        private string _annexleft;
        private string _annexright;
        private string _checkcases;
        private string _infraredscanbreast;
        private string _conclusion;
        private string _physicians;
        /// <summary>
        /// 数据作成日時
        /// </summary>
        public string CREATE_DATETIME
        {
            set { _create_datetime = value; }
            get { return _create_datetime; }
        }
        /// <summary>
        /// 最終更新日時
        /// </summary>
        public string UPDATE_DATETIME
        {
            set { _update_datetime = value; }
            get { return _update_datetime; }
        }
        /// <summary>
        /// 最終処理区分
        /// </summary>
        public string TRANS_STATE
        {
            set { _trans_state = value; }
            get { return _trans_state; }
        }
        /// <summary>
        /// 更新担当者ID
        /// </summary>
        public string UPDATER_ID
        {
            set { _updater_id = value; }
            get { return _updater_id; }
        }
        /// <summary>
        /// 更新端末
        /// </summary>
        public string TERMINAL_CD
        {
            set { _terminal_cd = value; }
            get { return _terminal_cd; }
        }
        /// <summary>
        /// 员工身份证
        /// </summary>
        public string EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
        /// <summary>
        /// 年月
        /// </summary>
        public string YearMonth
        {
            set { _yearmonth = value; }
            get { return _yearmonth; }
        }
        /// <summary>
        /// 月经初潮
        /// </summary>
        public string Menarche
        {
            set { _menarche = value; }
            get { return _menarche; }
        }
        /// <summary>
        /// 绝经年龄
        /// </summary>
        public string MenopauseAge
        {
            set { _menopauseage = value; }
            get { return _menopauseage; }
        }
        /// <summary>
        /// 月经周期
        /// </summary>
        public string MenstrualCycle
        {
            set { _menstrualcycle = value; }
            get { return _menstrualcycle; }
        }
        /// <summary>
        /// 月经量
        /// </summary>
        public string MenstrualVolume
        {
            set { _menstrualvolume = value; }
            get { return _menstrualvolume; }
        }
        /// <summary>
        /// 痛经
        /// </summary>
        public string Dysmenorrhea
        {
            set { _dysmenorrhea = value; }
            get { return _dysmenorrhea; }
        }
        /// <summary>
        /// 病史
        /// </summary>
        public string DiseaseHistory
        {
            set { _diseasehistory = value; }
            get { return _diseasehistory; }
        }
        /// <summary>
        /// 病史家庭肿瘤史
        /// </summary>
        public string FamilyTumorTistory
        {
            set { _familytumortistory = value; }
            get { return _familytumortistory; }
        }
        /// <summary>
        /// 病史其他
        /// </summary>
        public string DiseaseHistoryOther
        {
            set { _diseasehistoryother = value; }
            get { return _diseasehistoryother; }
        }
        /// <summary>
        /// 曾用雄性激素
        /// </summary>
        public string AndrogenUsed
        {
            set { _androgenused = value; }
            get { return _androgenused; }
        }
        /// <summary>
        /// 曾用雌性激素
        /// </summary>
        public string EstrogenUsed
        {
            set { _estrogenused = value; }
            get { return _estrogenused; }
        }
        /// <summary>
        /// 宫颈
        /// </summary>
        public string Cervical
        {
            set { _cervical = value; }
            get { return _cervical; }
        }
        /// <summary>
        /// 子宫
        /// </summary>
        public string Uterine
        {
            set { _uterine = value; }
            get { return _uterine; }
        }
        /// <summary>
        /// 外阴
        /// </summary>
        public string Genital
        {
            set { _genital = value; }
            get { return _genital; }
        }
        /// <summary>
        /// 白带
        /// </summary>
        public string Leucorrhea
        {
            set { _leucorrhea = value; }
            get { return _leucorrhea; }
        }
        /// <summary>
        /// 阴道
        /// </summary>
        public string Vaginal
        {
            set { _vaginal = value; }
            get { return _vaginal; }
        }
        /// <summary>
        /// 附件左
        /// </summary>
        public string AnnexLeft
        {
            set { _annexleft = value; }
            get { return _annexleft; }
        }
        /// <summary>
        /// 附件右
        /// </summary>
        public string AnnexRight
        {
            set { _annexright = value; }
            get { return _annexright; }
        }
        /// <summary>
        /// 病例检查
        /// </summary>
        public string CheckCases
        {
            set { _checkcases = value; }
            get { return _checkcases; }
        }
        /// <summary>
        /// 乳腺红外线扫描
        /// </summary>
        public string InfraredScanBreast
        {
            set { _infraredscanbreast = value; }
            get { return _infraredscanbreast; }
        }
        /// <summary>
        /// 结论
        /// </summary>
        public string Conclusion
        {
            set { _conclusion = value; }
            get { return _conclusion; }
        }
        /// <summary>
        /// 医师
        /// </summary>
        public string Physicians
        {
            set { _physicians = value; }
            get { return _physicians; }
        }

        public Feme()
        {
            _create_datetime = string.Empty;
            _update_datetime = string.Empty;
            _trans_state = string.Empty;
            _updater_id = string.Empty;
            _terminal_cd = string.Empty;
            _employeeid = string.Empty;
            _yearmonth = string.Empty;
            _menarche = string.Empty;
            _menopauseage = string.Empty;
            _menstrualcycle = string.Empty;
            _menstrualvolume = string.Empty;
            _dysmenorrhea = string.Empty;
            _diseasehistory = string.Empty;
            _familytumortistory = string.Empty;
            _diseasehistoryother = string.Empty;
            _androgenused = string.Empty;
            _estrogenused = string.Empty;
            _cervical = string.Empty;
            _uterine = string.Empty;
            _genital = string.Empty;
            _leucorrhea = string.Empty;
            _vaginal = string.Empty;
            _annexleft = string.Empty;
            _annexright = string.Empty;
            _checkcases = string.Empty;
            _infraredscanbreast = string.Empty;
            _conclusion = string.Empty;
            _physicians = string.Empty;
        }
        #endregion Model
    }
}
