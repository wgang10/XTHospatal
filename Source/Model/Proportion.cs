using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Proportion
    {
        public Proportion()
        { }

        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _type;
        private string _drugscode;
        private string _provincecode;
        private decimal? _drugsprice;
        private decimal? _proportional;
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
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugsCode
        {
            set { _drugscode = value; }
            get { return _drugscode; }
        }
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
        public decimal? DrugsPrice
        {
            set { _drugsprice = value; }
            get { return _drugsprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Proportional
        {
            set { _proportional = value; }
            get { return _proportional; }
        }
    }
}
