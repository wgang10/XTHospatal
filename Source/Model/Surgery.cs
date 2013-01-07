using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Surgery
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _length;
        private string _bust;
        private string _weight;
        private string _badbreath;
        private string _skin;
        private string _lymphoid;
        private string _thyroid;
        private string _spine;
        private string _limbs;
        private string _joint;
        private string _flatfoot;
        private string _genitourinary;
        private string _anal;
        private string _hernia;
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
        /// 身长
        /// </summary>
        public string Length
        {
            set { _length = value; }
            get { return _length; }
        }
        /// <summary>
        /// 胸围
        /// </summary>
        public string Bust
        {
            set { _bust = value; }
            get { return _bust; }
        }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 呼吸差
        /// </summary>
        public string BadBreath
        {
            set { _badbreath = value; }
            get { return _badbreath; }
        }
        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin
        {
            set { _skin = value; }
            get { return _skin; }
        }
        /// <summary>
        /// 淋巴
        /// </summary>
        public string Lymphoid
        {
            set { _lymphoid = value; }
            get { return _lymphoid; }
        }
        /// <summary>
        /// 甲状腺
        /// </summary>
        public string Thyroid
        {
            set { _thyroid = value; }
            get { return _thyroid; }
        }
        /// <summary>
        /// 脊柱
        /// </summary>
        public string Spine
        {
            set { _spine = value; }
            get { return _spine; }
        }
        /// <summary>
        /// 四肢
        /// </summary>
        public string Limbs
        {
            set { _limbs = value; }
            get { return _limbs; }
        }
        /// <summary>
        /// 关节
        /// </summary>
        public string Joint
        {
            set { _joint = value; }
            get { return _joint; }
        }
        /// <summary>
        /// 扁平足
        /// </summary>
        public string Flatfoot
        {
            set { _flatfoot = value; }
            get { return _flatfoot; }
        }
        /// <summary>
        /// 泌尿生殖器
        /// </summary>
        public string Genitourinary
        {
            set { _genitourinary = value; }
            get { return _genitourinary; }
        }
        /// <summary>
        /// 肛门
        /// </summary>
        public string Anal
        {
            set { _anal = value; }
            get { return _anal; }
        }
        /// <summary>
        /// 疝
        /// </summary>
        public string Hernia
        {
            set { _hernia = value; }
            get { return _hernia; }
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
