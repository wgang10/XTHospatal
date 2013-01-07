using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class MedicalItems
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _code;
        private string _financeid;
        private string _name;
        private string _units;
        private string _limit0;
        private string _limit1;
        private string _limit2;
        private string _limit3;
        private string _connotation;
        private string _exceptcontents;
        private string _description;

        /// <summary>
        /// 
        /// </summary>
        public string CREATE_DATETIME
        {
            set { _create_datetime = value; }
            get { return _create_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UPDATE_DATETIME
        {
            set { _update_datetime = value; }
            get { return _update_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TRANS_STATE
        {
            set { _trans_state = value; }
            get { return _trans_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UPDATER_ID
        {
            set { _updater_id = value; }
            get { return _updater_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TERMINAL_CD
        {
            set { _terminal_cd = value; }
            get { return _terminal_cd; }
        }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 财务分类
        /// </summary>
        public string FinanceID
        {
            set { _financeid = value; }
            get { return _financeid; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 计价单位
        /// </summary>
        public string Units
        {
            set {  _units= value; }
            get { return _units; }
        }
        /// <summary>
        /// 最高限价特级
        /// </summary>
        public string Limit0
        {
            set {  _limit0= value; }
            get { return _limit0; }
        }
        /// <summary>
        /// 最高限价一级
        /// </summary>
        public string Limit1
        {
            set { _limit1= value; }
            get { return _limit1; }
        }
        /// <summary>
        /// 最高限价二级
        /// </summary>
        public string Limit2 
        {
            set {  _limit2= value; }
            get { return _limit2; }
        }
        /// <summary>
        /// 最高限价三级
        /// </summary>
        public string Limit3
        {
            set {  _limit3= value; }
            get { return _limit3; }
        }
        /// <summary>
        /// 项目内涵
        /// </summary>
        public string Connotation
        {
            set {  _connotation= value; }
            get { return _connotation; }
        }
        /// <summary>
        /// 除外内容
        /// </summary>
        public string ExceptContents
        {
            set {  _exceptcontents= value; }
            get { return _exceptcontents; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            set {  _description= value; }
            get { return _description; }
        }
    }
}
