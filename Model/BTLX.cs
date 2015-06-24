using System;
namespace Model
{
    /// <summary>
    /// BTLX:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BTLX
    {
        public BTLX()
        { }
        #region Model
        private string _typecode;
        private string _typename;
        private string _zyl;
        private string _lssuecycle;
        private string _ftypcode;
        private string _hzcustid = "G0001";
        private decimal? _sysopertime;
        /// <summary>
        /// 
        /// </summary>
        public string TYPECODE
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TYPENAME
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZYL
        {
            set { _zyl = value; }
            get { return _zyl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LSSUECYCLE
        {
            set { _lssuecycle = value; }
            get { return _lssuecycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FTYPCODE
        {
            set { _ftypcode = value; }
            get { return _ftypcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HZCUSTID
        {
            set { _hzcustid = value; }
            get { return _hzcustid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SYSOPERTIME
        {
            set { _sysopertime = value; }
            get { return _sysopertime; }
        }
        #endregion Model
    }
}
