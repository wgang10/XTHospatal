using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class ECG
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _ecgno;
        private string _clinicaldiagnosis;
        private string _useddrugs;
        private string _summaryhistory;
        private string _summarybody;
        private string _patientsituation;
        private string _medicaladvice;
        private byte[] _ecg;
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
        /// 心电图号
        /// </summary>
        public string ECGNo
        {
            set { _ecgno = value; }
            get { return _ecgno; }
        }
        /// <summary>
        /// 临床诊断
        /// </summary>
        public string ClinicalDiagnosis
        {
            set { _clinicaldiagnosis = value; }
            get { return _clinicaldiagnosis; }
        }
        /// <summary>
        /// 曾用药物
        /// </summary>
        public string UsedDrugs
        {
            set { _useddrugs = value; }
            get { return _useddrugs; }
        }
        /// <summary>
        /// 病史概要
        /// </summary>
        public string SummaryHistory
        {
            set { _summaryhistory = value; }
            get { return _summaryhistory; }
        }
        /// <summary>
        /// 查体概要
        /// </summary>
        public string SummaryBody
        {
            set { _summarybody = value; }
            get { return _summarybody; }
        }
        /// <summary>
        /// 病人状况
        /// </summary>
        public string PatientSituation
        {
            set { _patientsituation = value; }
            get { return _patientsituation; }
        }
        /// <summary>
        /// 诊断意见
        /// </summary>
        public string MedicalAdvice
        {
            set { _medicaladvice = value; }
            get { return _medicaladvice; }
        }
        /// <summary>
        /// 图像
        /// </summary>
        public byte[] ECGImage
        {
            set { _ecg = value; }
            get { return _ecg; }
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
