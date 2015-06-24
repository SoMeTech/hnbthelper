using System;
namespace Model
{
    /// <summary>
    /// BTDJTEMP:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WFBT
    {
        public WFBT()
        { }
        #region Model
        private int _gh;
        private decimal? _je;
        private string _lb;
        public string Lb
        {
            get { return _lb; }
            set { _lb = value; }
        }
        public decimal? Je
        {
            get { return _je; }
            set { _je = value; }
        }
        public int Gh
        {
            get { return _gh; }
            set { _gh = value; }
        }
        private string _oid;
        public string Oid
        {
            get { return _oid; }
            set { _oid = value; }
        }
        private string _yzh;
        public string Yzh
        {
            get { return _yzh; }
            set { _yzh = value; }
        }
        private string _accountnum;
        public string Accountnum
        {
            get { return _accountnum; }
            set { _accountnum = value; }
        }
        private string _yxm;
        public string Yxm
        {
            get { return _yxm; }
            set { _yxm = value; }
        }
        private string _ssssobjectname;
        public string Ssssobjectname
        {
            get { return _ssssobjectname; }
            set { _ssssobjectname = value; }
        }
        private string _wfyy;
        public string Wfyy
        {
            get { return _wfyy; }
            set { _wfyy = value; }
        }
        private string _ssssidcardnum;
        public string Ssssidcardnum
        {
            get { return _ssssidcardnum; }
            set { _ssssidcardnum = value; }
        }
        private string _dz;
        public string Dz
        {
            get { return _dz; }
            set { _dz = value; }
        }
        #endregion Model
    }
}
