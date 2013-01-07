using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Drug
    {
        public Drug()
        {
            _drugclasscode = "";
            _type1 = "";
            _type2 = "";
            _code = "";
            _chinaname = "";
            _englishname = "";
            _formulation = "";
            _notes = "";
            _provincecode="";
        }

        #region Model

        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _drugclasscode;
        private string _type1;
        private string _type2;
        private string _code;
        private string _provincecode;
        private string _chinaname;
        private string _englishname;
        private string _formulation;
        private string _notes;
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceCode
        {
            set { _provincecode = value; }
            get { return _provincecode; }
        }
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
        /// 
        /// </summary>
        public string DrugClassCode
        {
            set { _drugclasscode = value; }
            get { return _drugclasscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type1
        {
            set { _type1 = value; }
            get { return _type1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type2
        {
            set { _type2 = value; }
            get { return _type2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ChinaName
        {
            set { _chinaname = value; }
            get { return _chinaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnglishName
        {
            set { _englishname = value; }
            get { return _englishname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Formulation
        {
            set { _formulation = value; }
            get { return _formulation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Notes
        {
            set { _notes = value; }
            get { return _notes; }
        }
        #endregion Model
    }
}
