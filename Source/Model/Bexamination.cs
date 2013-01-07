using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Bexamination
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _bid;
        private string _historysigns;
        private string _laboratoryexamination;
        private string _diagnosis;
        private string _purpose;
        private string _results;
        private byte[] _bimage;
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
        /// B超编号
        /// </summary>
        public string BID
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 病史及体征
        /// </summary>
        public string HistorySigns
        {
            set { _historysigns = value; }
            get { return _historysigns; }
        }
        /// <summary>
        /// 化验检查
        /// </summary>
        public string LaboratoryExamination
        {
            set { _laboratoryexamination = value; }
            get { return _laboratoryexamination; }
        }
        /// <summary>
        /// 临床预诊
        /// </summary>
        public string Diagnosis
        {
            set { _diagnosis = value; }
            get { return _diagnosis; }
        }
        /// <summary>
        /// 检查目的和部位
        /// </summary>
        public string Purpose
        {
            set { _purpose = value; }
            get { return _purpose; }
        }
        /// <summary>
        /// 检查结果
        /// </summary>
        public string Results
        {
            set { _results = value; }
            get { return _results; }
        }
        /// <summary>
        /// 图像
        /// </summary>
        public byte[] BImage
        {
            set { _bimage = value; }
            get { return _bimage; }
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
