using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class DrugClass
    {
        public DrugClass()
        { }
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _code;
        private string _name;
        private string _upcode;
        private string _type;
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpCode
        {
            set { _upcode = value; }
            get { return _upcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
    }
}
