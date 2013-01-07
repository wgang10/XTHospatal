using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class InternalMedicine
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _bloodpressure;
        private string _bloodpressure1;
        private string _developmentstatus;
        private string _neurological;
        private string _lung;
        private string _heartblood;
        private string _abdominalorgans;
        private string _liver;
        private string _spleen;
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
        /// 血压(千帕)
        /// </summary>
        public string BloodPressure
        {
            set { _bloodpressure = value; }
            get { return _bloodpressure; }
        }
        /// <summary>
        /// 血压(毫米汞柱)
        /// </summary>
        public string BloodPressure1
        {
            set { _bloodpressure1 = value; }
            get { return _bloodpressure1; }
        }
        /// <summary>
        /// 发育及营养状况
        /// </summary>
        public string DevelopmentStatus
        {
            set { _developmentstatus = value; }
            get { return _developmentstatus; }
        }
        /// <summary>
        /// 神经及精神
        /// </summary>
        public string Neurological
        {
            set { _neurological = value; }
            get { return _neurological; }
        }
        /// <summary>
        /// 肺及呼吸道
        /// </summary>
        public string Lung
        {
            set { _lung = value; }
            get { return _lung; }
        }
        /// <summary>
        /// 心脏及血管
        /// </summary>
        public string HeartBlood
        {
            set { _heartblood = value; }
            get { return _heartblood; }
        }
        /// <summary>
        /// 腹部器官
        /// </summary>
        public string AbdominalOrgans
        {
            set { _abdominalorgans = value; }
            get { return _abdominalorgans; }
        }
        /// <summary>
        /// 肝
        /// </summary>
        public string Liver
        {
            set { _liver = value; }
            get { return _liver; }
        }
        /// <summary>
        /// 脾
        /// </summary>
        public string Spleen
        {
            set { _spleen = value; }
            get { return _spleen; }
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
