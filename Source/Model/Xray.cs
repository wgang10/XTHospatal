using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Xray
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _photono;
        private string _symptoms;
        private string _laboratory;
        private string _diagnosis;
        private string _perspective;
        private string _camera;
        private string _results;
        private byte[] _ximage;
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
        /// 摄影号
        /// </summary>
        public string PhotoNo
        {
            set { _photono = value; }
            get { return _photono; }
        }
        /// <summary>
        /// 主要症状
        /// </summary>
        public string Symptoms
        {
            set { _symptoms = value; }
            get { return _symptoms; }
        }
        /// <summary>
        /// 体征及化验检查
        /// </summary>
        public string Laboratory
        {
            set { _laboratory = value; }
            get { return _laboratory; }
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
        /// 透视部位及目的
        /// </summary>
        public string Perspective
        {
            set { _perspective = value; }
            get { return _perspective; }
        }
        /// <summary>
        /// 照相部位及目的
        /// </summary>
        public string Camera
        {
            set { _camera = value; }
            get { return _camera; }
        }
        /// <summary>
        /// 透视检查结果
        /// </summary>
        public string Results
        {
            set { _results = value; }
            get { return _results; }
        }
        /// <summary>
        /// 图像
        /// </summary>
        public byte[] XImage
        {
            set { _ximage = value; }
            get { return _ximage; }
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
