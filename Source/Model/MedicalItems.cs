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
        /// ��Ŀ���
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string FinanceID
        {
            set { _financeid = value; }
            get { return _financeid; }
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// �Ƽ۵�λ
        /// </summary>
        public string Units
        {
            set {  _units= value; }
            get { return _units; }
        }
        /// <summary>
        /// ����޼��ؼ�
        /// </summary>
        public string Limit0
        {
            set {  _limit0= value; }
            get { return _limit0; }
        }
        /// <summary>
        /// ����޼�һ��
        /// </summary>
        public string Limit1
        {
            set { _limit1= value; }
            get { return _limit1; }
        }
        /// <summary>
        /// ����޼۶���
        /// </summary>
        public string Limit2 
        {
            set {  _limit2= value; }
            get { return _limit2; }
        }
        /// <summary>
        /// ����޼�����
        /// </summary>
        public string Limit3
        {
            set {  _limit3= value; }
            get { return _limit3; }
        }
        /// <summary>
        /// ��Ŀ�ں�
        /// </summary>
        public string Connotation
        {
            set {  _connotation= value; }
            get { return _connotation; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string ExceptContents
        {
            set {  _exceptcontents= value; }
            get { return _exceptcontents; }
        }
        /// <summary>
        /// ˵��
        /// </summary>
        public string Description
        {
            set {  _description= value; }
            get { return _description; }
        }
    }
}
