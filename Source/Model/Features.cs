using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Features
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _lefteye;
        private string _righteye;
        private string _correctedleft;
        private string _correctedright;
        private string _colorvisionforce;
        private string _trachomaleft;
        private string _trachomaright;
        private string _othereye;
        private string _listeningleft;
        private string _listeningright;
        private string _ear;
        private string _olfactory;
        private string _noseparanasalsinusdisease;
        private string _throat;
        private string _lippalate;
        private string _stuttering;
        private string _caries;
        private string _missingteeth;
        private string _periodontaldisease;
        private string _other;
        private string _medicaladvice;
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
        /// 视力左
        /// </summary>
        public string LeftEye
        {
            set { _lefteye = value; }
            get { return _lefteye; }
        }
        /// <summary>
        /// 视力右
        /// </summary>
        public string RightEye
        {
            set { _righteye = value; }
            get { return _righteye; }
        }
        /// <summary>
        /// 矫正视力左
        /// </summary>
        public string CorrectedLeft
        {
            set { _correctedleft = value; }
            get { return _correctedleft; }
        }
        /// <summary>
        /// 矫正视力右
        /// </summary>
        public string CorrectedRight
        {
            set { _correctedright = value; }
            get { return _correctedright; }
        }
        /// <summary>
        /// 辨色力
        /// </summary>
        public string ColorVisionForce
        {
            set { _colorvisionforce = value; }
            get { return _colorvisionforce; }
        }
        /// <summary>
        /// 沙眼左
        /// </summary>
        public string TrachomaLeft
        {
            set { _trachomaleft = value; }
            get { return _trachomaleft; }
        }
        /// <summary>
        /// 沙眼右
        /// </summary>
        public string TrachomaRight
        {
            set { _trachomaright = value; }
            get { return _trachomaright; }
        }
        /// <summary>
        /// 眼其他
        /// </summary>
        public string OtherEye
        {
            set { _othereye = value; }
            get { return _othereye; }
        }
        /// <summary>
        /// 听力左
        /// </summary>
        public string ListeningLeft
        {
            set { _listeningleft = value; }
            get { return _listeningleft; }
        }
        /// <summary>
        /// 听力右
        /// </summary>
        public string ListeningRight
        {
            set { _listeningright = value; }
            get { return _listeningright; }
        }
        /// <summary>
        /// 耳疾
        /// </summary>
        public string Ear
        {
            set { _ear = value; }
            get { return _ear; }
        }
        /// <summary>
        /// 嗅觉
        /// </summary>
        public string Olfactory
        {
            set { _olfactory = value; }
            get { return _olfactory; }
        }
        /// <summary>
        /// 鼻及鼻窦疾病
        /// </summary>
        public string NoseParanasalSinusDisease
        {
            set { _noseparanasalsinusdisease = value; }
            get { return _noseparanasalsinusdisease; }
        }
        /// <summary>
        /// 咽喉
        /// </summary>
        public string Throat
        {
            set { _throat = value; }
            get { return _throat; }
        }
        /// <summary>
        /// 唇腭
        /// </summary>
        public string LipPalate
        {
            set { _lippalate = value; }
            get { return _lippalate; }
        }
        /// <summary>
        /// 口吃
        /// </summary>
        public string Stuttering
        {
            set { _stuttering = value; }
            get { return _stuttering; }
        }
        /// <summary>
        /// 龋齿
        /// </summary>
        public string Caries
        {
            set { _caries = value; }
            get { return _caries; }
        }
        /// <summary>
        /// 缺齿
        /// </summary>
        public string MissingTeeth
        {
            set { _missingteeth = value; }
            get { return _missingteeth; }
        }
        /// <summary>
        /// 牙周病
        /// </summary>
        public string PeriodontalDisease
        {
            set { _periodontaldisease = value; }
            get { return _periodontaldisease; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// 医生意见
        /// </summary>
        public string MedicalAdvice
        {
            set { _medicaladvice = value; }
            get { return _medicaladvice; }
        }
        /// <summary>
        /// 医师
        /// </summary>
        public string Physicians
        {
            set { _physicians = value; }
            get { return _physicians; }
        }
    }
}
