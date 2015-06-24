using System;
namespace Model
{
    /// <summary>
    /// BTDJTEMP:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BTDJTEMP
    {
        public BTDJTEMP()
        { }
        #region Model
        private string _typeid;
        private string _objectid;
        private string _accountnum;
        private string _OBJECTCODE;
        private string _SSSSIDCARDNUM;
        private string _SSSSOBJECTNAME;
        private decimal? _regmoney;
        private decimal? _amount;
        private string _typecode;
        private string _batchid;
        private decimal? _batchcode;
        private string _offset;
        private string _lssuecycle;
        private string _bankcode;
        public string Bankcode
        {
            get { return _bankcode; }
            set { _bankcode = value; }
        }
        public string Lssuecycle
        {
            get { return _lssuecycle; }
            set { _lssuecycle = value; }
        }
        public string Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        public decimal? Batchcode
        {
            get { return _batchcode; }
            set { _batchcode = value; }
        }
        public string Batchid
        {
            get { return _batchid; }
            set { _batchid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        public string Objectid
        {
            get { return _objectid; }
            set { _objectid = value; }
        }
        public string Accountnum
        {
            get { return _accountnum; }
            set { _accountnum = value; }
        }
        public string OBJECTCODE
        {
            set { _OBJECTCODE = value; }
            get { return _OBJECTCODE; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SSSSIDCARDNUM
        {
            set { _SSSSIDCARDNUM = value; }
            get { return _SSSSIDCARDNUM; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SSSSOBJECTNAME
        {
            set { _SSSSOBJECTNAME = value; }
            get { return _SSSSOBJECTNAME; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? REGMONEY
        {
            set { _regmoney = value; }
            get { return _regmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TYPECODE
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        #endregion Model
    }
}
