using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class Biochemistry
    {
        private string _create_datetime;
        private string _update_datetime;
        private string _trans_state;
        private string _updater_id;
        private string _terminal_cd;
        private string _employeeid;
        private string _yearmonth;
        private string _hyno;
        private string _hydr;
        private string _hytc;
        private string _hytg;
        private string _hyhdlc;
        private string _hytbil;
        private string _hydbil;
        private string _hytp;
        private string _hyalb;
        private string _hyalt;
        private string _hyhbsag;
        private string _hyhbsab;
        private string _hyhbeag;
        private string _hyhbeab;
        private string _hyhbcab;
        private string _hy_glu;
        private string _hy_urea;
        private string _hy_cr;
        private string _hy_afp;
        private string _hy_cea;

        private string _hy_ldlc;
        private string _hy_apoai;
        private string _hy_apob;
        private string _hy_ast;
        private string _hy_gt;
        private string _hy_alp;
        private string _hy_ua;

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
        /// 化验号
        /// </summary>
        public string HYNo
        {
            set { _hyno = value; }
            get { return _hyno; }
        }
        /// <summary>
        /// 医师
        /// </summary>
        public string HYDr
        {
            set { _hydr = value; }
            get { return _hydr; }
        }
        /// <summary>
        /// 总胆固醇(TC)
        /// </summary>
        public string HYTC
        {
            set { _hytc = value; }
            get { return _hytc; }
        }
        /// <summary>
        /// 甘油三脂(TG)
        /// </summary>
        public string HYTG
        {
            set { _hytg = value; }
            get { return _hytg; }
        }
        /// <summary>
        /// 高密度脂蛋白胆固醇(HDL-C)
        /// </summary>
        public string HYHDLC
        {
            set { _hyhdlc = value; }
            get { return _hyhdlc; }
        }

        /// <summary>
        /// 低密度脂蛋白胆固醇(LDL-C)
        /// </summary>
        public string HYLDLC
        {
            set { _hy_ldlc = value; }
            get { return _hy_ldlc; }
        }

        /// <summary>
        /// 载脂蛋白AI(APOAI)
        /// </summary>
        public string HYAPOAI
        {
            set { _hy_apoai = value; }
            get { return _hy_apoai; }
        }

        /// <summary>
        /// 载脂蛋白B(APOB)
        /// </summary>
        public string HYAPOB
        {
            set { _hy_apob = value; }
            get { return _hy_apob; }
        }

        /// <summary>
        /// 总胆红素(TBIL)
        /// </summary>
        public string HYTBIL
        {
            set { _hytbil = value; }
            get { return _hytbil; }
        }
        /// <summary>
        /// 直接胆红素(DBIL)
        /// </summary>
        public string HYDBIL
        {
            set { _hydbil = value; }
            get { return _hydbil; }
        }
        /// <summary>
        /// 总蛋白(TP)
        /// </summary>
        public string HYTP
        {
            set { _hytp = value; }
            get { return _hytp; }
        }
        /// <summary>
        /// 白蛋白(ALB)
        /// </summary>
        public string HYALB
        {
            set { _hyalb = value; }
            get { return _hyalb; }
        }
        /// <summary>
        /// 谷丙转氨酶(ALT)=>丙氨酸氨基转移酶
        /// </summary>
        public string HYALT
        {
            set { _hyalt = value; }
            get { return _hyalt; }
        }


        /// <summary>
        /// 天门冬氨酸氨基转移酶(AST)
        /// </summary>
        public string HYAST
        {
            set { _hy_ast = value; }
            get { return _hy_ast; }
        }
        /// <summary>
        /// γ-谷胺酰转肽酶(γ-GT)
        /// </summary>
        public string HYGT
        {
            set { _hy_gt = value; }
            get { return _hy_gt; }
        }
        /// <summary>
        /// 碱性磷酸酶(ALP)
        /// </summary>
        public string HYALP
        {
            set { _hy_alp = value; }
            get { return _hy_alp; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HYHBsAg
        {
            set { _hyhbsag = value; }
            get { return _hyhbsag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYHBsAb
        {
            set { _hyhbsab = value; }
            get { return _hyhbsab; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYHBeAg
        {
            set { _hyhbeag = value; }
            get { return _hyhbeag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYHBeAb
        {
            set { _hyhbeab = value; }
            get { return _hyhbeab; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYHBcAb
        {
            set { _hyhbcab = value; }
            get { return _hyhbcab; }
        }

        /// <summary>
        /// 血糖
        /// </summary>
        public string HY_GLU
        {
            set { _hy_glu = value; }
            get { return _hy_glu; }
        }
        /// <summary>
        /// 尿素
        /// </summary>
        public string HY_UREA
        {
            set { _hy_urea = value; }
            get { return _hy_urea; }
        }
        /// <summary>
        /// 肌酐
        /// </summary>
        public string HY_CR
        {
            set { _hy_cr = value; }
            get { return _hy_cr; }
        }
        /// <summary>
        /// 尿酸（UA）
        /// </summary>
        public string HYUA
        {
            set { _hy_ua = value; }
            get { return _hy_ua; }
        }
        /// <summary>
        /// 甲胎蛋白
        /// </summary>
        public string HY_AFP
        {
            set { _hy_afp = value; }
            get { return _hy_afp; }
        }
        /// <summary>
        /// 癌胚抗原
        /// </summary>
        public string HY_CEA
        {
            set { _hy_cea = value; }
            get { return _hy_cea; }
        }
    }
}
