using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Composition
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _FatType;
        private string _FatEvaluate;
        private string _FatTarget;
        private string _MuscleTarget;
        private string _BodyWeightTarget;
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
        /// 腹部肥胖/综合评价
        /// 1：皮下型 2：内脏型
        /// </summary>
        public string FatType
        {
            set { _FatType = value; }
            get { return _FatType; }
        }
        /// <summary>
        /// 评估
        /// 1：很瘦 2：偏瘦 3：标准 4：低脂肪肌肉型 5：超重 6：肌肉型 7：脂肪过多型 8：肥胖 9：严重肥胖
        /// </summary>
        public string FatEvaluate
        {
            set { _FatEvaluate = value; }
            get { return _FatEvaluate; }
        }
        /// <summary>
        /// 调节目标脂肪重量
        /// </summary>
        public string FatTarget
        {
            set { _FatTarget = value; }
            get { return _FatTarget; }
        }
        /// <summary>
        /// 调节目标肌肉重量
        /// </summary>
        public string MuscleTarget
        {
            set { _MuscleTarget = value; }
            get { return _MuscleTarget; }
        }
        /// <summary>
        /// 调节目标体重
        /// </summary>
        public string BodyWeightTarget
        {
            set { _BodyWeightTarget = value; }
            get { return _BodyWeightTarget; }
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
