using System;
namespace Model
{
    /// <summary>
    /// BASEOBJECT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BASEOBJECT
    {
        public BASEOBJECT()
        { }
        #region Model
        private string _objectid;
        private string _categoryid;
        private string _OBJECTCODE;
        private string _SSSSOBJECTNAME;
        private string _cardtype;
        private string _accountnum;
        private string _SSSSIDCARDNUM;
        private string _HOMEADDRESS;
        private decimal? _membernum;
        private string _economicproperty;
        private string _isenable;
        private string _sex;
        private string _phone;
        private string _status;
        private decimal? _athomepeople;
        private decimal? _outhomepeople;
        private string _postcode;
        private string _bankname;
        private string _ismain;
        private decimal? _children;
        private string _isdraw;
        private string _drawnum;
        private string _singletontype;
        private string _poorcase;
        private decimal? _income;
        private decimal? _housearea;
        private decimal? _ensurednum;
        private string _lowinsurance;
        private string _providetype;
        private string _protectedobj;
        private string _protectedobjtype;
        private string _poorfamily;
        private string _belongthree;
        private string _address;
        private string _remark;
        private string _ediusrcode;
        private string _edidate;
        private string _editime;
        private string _regdate;
        private string _logiccode;
        private string _iseffect;
        private string _logictime;
        private decimal? _tdcbmj;
        private string _tdcbzh;
        private decimal? _slcbmj;
        private string _slcbzh;
        private decimal? _smcbmj;
        private string _smcbzh;
        private string _cbxxbq;
        private decimal? _whbjqs;
        private decimal? _qlgjqs;
        private string _jqxxbz;
        private decimal? _htmj;
        private decimal? _cdmj;
        private decimal? _zdmj;
        private decimal? _mdmj;
        private string _lzbtmjxxbz;
        private decimal? _wdmj;
        private decimal? _zbmj;
        private decimal? _ssmj;
        private decimal? _kymj;
        private decimal? _qtlszwmj;
        private decimal? _fzmj;
        private decimal? _azdmj;
        private decimal? _amdmj;
        private decimal? _awdmj;
        private string _zzxxbz;
        private string _ymlx;
        private decimal? _dxlsl;
        private decimal? _jxlsl;
        private decimal? _xsymkl;
        private string _ymxxbz;
        private string _fqzsylx;
        private string _jsxxbz;
        private decimal? _bfjhsy;
        private decimal? _jzdmj;
        private decimal? _jmdmj;
        private decimal? _jwdmj;
        private decimal? _zzxjddfy;
        private decimal? _zzqtnftdfy;
        private decimal? _yjsmj;
        private decimal? _yjscc;
        private string _nfcbtdfyqkbz;
        private string _zxlfyjr;
        private string _dbhxtwjr;
        private string _lsygbgjs;
        private string _zxhjsstwzs;
        private string _swry;
        private string _zxcjjr;
        private string _ncywbjs;
        private string _knccgb;
        private string _wfh;
        private string _xzxxbz;
        private string _countycode = "431106";
        private decimal? _sumslxxslmj;
        private decimal? _sumslxxrglslmj;
        private decimal? _sumslxxtrlslmj;
        private decimal? _sumslxxkylslmj;
        private decimal? _sumslxxhsslmj;
        private decimal? _sumtdxx;
        private decimal? _sumtdxxst;
        private decimal? _sumtdxxht;
        private decimal? _sumtdxxcd;
        private decimal? _sumtdxxelse;
        private string _ncznqkbz;
        private decimal? _cnwnldl;
        private decimal? _cnwcwnldl;
        private string _yzbm;
        private string _hkh;
        private string _khyh;
        private string _jjbz;
        private decimal? _sumslxxtantuslmj;
        private decimal? _sumslxxyouchaslmj;
        private decimal? _sumslxxzhulinslmj;
        private string _otheridentificdnumber;
        private string _landmgrgcardnumber;
        private string _hzcustid = "G0001";
        private decimal? _sysopertime;
        /// <summary>
        /// 
        /// </summary>
        public string OBJECTID
        {
            set { _objectid = value; }
            get { return _objectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CATEGORYID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OBJECTCODE
        {
            set { _OBJECTCODE = value; }
            get { return _OBJECTCODE; }
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
        public string CARDTYPE
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ACCOUNTNUM
        {
            set { _accountnum = value; }
            get { return _accountnum; }
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
        public string HOMEADDRESS
        {
            set { _HOMEADDRESS = value; }
            get { return _HOMEADDRESS; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MEMBERNUM
        {
            set { _membernum = value; }
            get { return _membernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ECONOMICPROPERTY
        {
            set { _economicproperty = value; }
            get { return _economicproperty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ISENABLE
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PHONE
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ATHOMEPEOPLE
        {
            set { _athomepeople = value; }
            get { return _athomepeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OUTHOMEPEOPLE
        {
            set { _outhomepeople = value; }
            get { return _outhomepeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POSTCODE
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BANKNAME
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ISMAIN
        {
            set { _ismain = value; }
            get { return _ismain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CHILDREN
        {
            set { _children = value; }
            get { return _children; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ISDRAW
        {
            set { _isdraw = value; }
            get { return _isdraw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DRAWNUM
        {
            set { _drawnum = value; }
            get { return _drawnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SINGLETONTYPE
        {
            set { _singletontype = value; }
            get { return _singletontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POORCASE
        {
            set { _poorcase = value; }
            get { return _poorcase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? INCOME
        {
            set { _income = value; }
            get { return _income; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HOUSEAREA
        {
            set { _housearea = value; }
            get { return _housearea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ENSUREDNUM
        {
            set { _ensurednum = value; }
            get { return _ensurednum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOWINSURANCE
        {
            set { _lowinsurance = value; }
            get { return _lowinsurance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PROVIDETYPE
        {
            set { _providetype = value; }
            get { return _providetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PROTECTEDOBJ
        {
            set { _protectedobj = value; }
            get { return _protectedobj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PROTECTEDOBJTYPE
        {
            set { _protectedobjtype = value; }
            get { return _protectedobjtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POORFAMILY
        {
            set { _poorfamily = value; }
            get { return _poorfamily; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BELONGTHREE
        {
            set { _belongthree = value; }
            get { return _belongthree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EDIUSRCODE
        {
            set { _ediusrcode = value; }
            get { return _ediusrcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EDIDATE
        {
            set { _edidate = value; }
            get { return _edidate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EDITIME
        {
            set { _editime = value; }
            get { return _editime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string REGDATE
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGICCODE
        {
            set { _logiccode = value; }
            get { return _logiccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ISEFFECT
        {
            set { _iseffect = value; }
            get { return _iseffect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGICTIME
        {
            set { _logictime = value; }
            get { return _logictime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TDCBMJ
        {
            set { _tdcbmj = value; }
            get { return _tdcbmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TDCBZH
        {
            set { _tdcbzh = value; }
            get { return _tdcbzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SLCBMJ
        {
            set { _slcbmj = value; }
            get { return _slcbmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SLCBZH
        {
            set { _slcbzh = value; }
            get { return _slcbzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SMCBMJ
        {
            set { _smcbmj = value; }
            get { return _smcbmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMCBZH
        {
            set { _smcbzh = value; }
            get { return _smcbzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CBXXBQ
        {
            set { _cbxxbq = value; }
            get { return _cbxxbq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WHBJQS
        {
            set { _whbjqs = value; }
            get { return _whbjqs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QLGJQS
        {
            set { _qlgjqs = value; }
            get { return _qlgjqs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JQXXBZ
        {
            set { _jqxxbz = value; }
            get { return _jqxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HTMJ
        {
            set { _htmj = value; }
            get { return _htmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CDMJ
        {
            set { _cdmj = value; }
            get { return _cdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZDMJ
        {
            set { _zdmj = value; }
            get { return _zdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MDMJ
        {
            set { _mdmj = value; }
            get { return _mdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LZBTMJXXBZ
        {
            set { _lzbtmjxxbz = value; }
            get { return _lzbtmjxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WDMJ
        {
            set { _wdmj = value; }
            get { return _wdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZBMJ
        {
            set { _zbmj = value; }
            get { return _zbmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SSMJ
        {
            set { _ssmj = value; }
            get { return _ssmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KYMJ
        {
            set { _kymj = value; }
            get { return _kymj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QTLSZWMJ
        {
            set { _qtlszwmj = value; }
            get { return _qtlszwmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FZMJ
        {
            set { _fzmj = value; }
            get { return _fzmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AZDMJ
        {
            set { _azdmj = value; }
            get { return _azdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AMDMJ
        {
            set { _amdmj = value; }
            get { return _amdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AWDMJ
        {
            set { _awdmj = value; }
            get { return _awdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZZXXBZ
        {
            set { _zzxxbz = value; }
            get { return _zzxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YMLX
        {
            set { _ymlx = value; }
            get { return _ymlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DXLSL
        {
            set { _dxlsl = value; }
            get { return _dxlsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JXLSL
        {
            set { _jxlsl = value; }
            get { return _jxlsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XSYMKL
        {
            set { _xsymkl = value; }
            get { return _xsymkl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YMXXBZ
        {
            set { _ymxxbz = value; }
            get { return _ymxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FQZSYLX
        {
            set { _fqzsylx = value; }
            get { return _fqzsylx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JSXXBZ
        {
            set { _jsxxbz = value; }
            get { return _jsxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BFJHSY
        {
            set { _bfjhsy = value; }
            get { return _bfjhsy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JZDMJ
        {
            set { _jzdmj = value; }
            get { return _jzdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JMDMJ
        {
            set { _jmdmj = value; }
            get { return _jmdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JWDMJ
        {
            set { _jwdmj = value; }
            get { return _jwdmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZZXJDDFY
        {
            set { _zzxjddfy = value; }
            get { return _zzxjddfy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZZQTNFTDFY
        {
            set { _zzqtnftdfy = value; }
            get { return _zzqtnftdfy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YJSMJ
        {
            set { _yjsmj = value; }
            get { return _yjsmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YJSCC
        {
            set { _yjscc = value; }
            get { return _yjscc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NFCBTDFYQKBZ
        {
            set { _nfcbtdfyqkbz = value; }
            get { return _nfcbtdfyqkbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZXLFYJR
        {
            set { _zxlfyjr = value; }
            get { return _zxlfyjr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DBHXTWJR
        {
            set { _dbhxtwjr = value; }
            get { return _dbhxtwjr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LSYGBGJS
        {
            set { _lsygbgjs = value; }
            get { return _lsygbgjs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZXHJSSTWZS
        {
            set { _zxhjsstwzs = value; }
            get { return _zxhjsstwzs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SWRY
        {
            set { _swry = value; }
            get { return _swry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZXCJJR
        {
            set { _zxcjjr = value; }
            get { return _zxcjjr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NCYWBJS
        {
            set { _ncywbjs = value; }
            get { return _ncywbjs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KNCCGB
        {
            set { _knccgb = value; }
            get { return _knccgb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WFH
        {
            set { _wfh = value; }
            get { return _wfh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XZXXBZ
        {
            set { _xzxxbz = value; }
            get { return _xzxxbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COUNTYCODE
        {
            set { _countycode = value; }
            get { return _countycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXSLMJ
        {
            set { _sumslxxslmj = value; }
            get { return _sumslxxslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXRGLSLMJ
        {
            set { _sumslxxrglslmj = value; }
            get { return _sumslxxrglslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXTRLSLMJ
        {
            set { _sumslxxtrlslmj = value; }
            get { return _sumslxxtrlslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXKYLSLMJ
        {
            set { _sumslxxkylslmj = value; }
            get { return _sumslxxkylslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXHSSLMJ
        {
            set { _sumslxxhsslmj = value; }
            get { return _sumslxxhsslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMTDXX
        {
            set { _sumtdxx = value; }
            get { return _sumtdxx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMTDXXST
        {
            set { _sumtdxxst = value; }
            get { return _sumtdxxst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMTDXXHT
        {
            set { _sumtdxxht = value; }
            get { return _sumtdxxht; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMTDXXCD
        {
            set { _sumtdxxcd = value; }
            get { return _sumtdxxcd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMTDXXELSE
        {
            set { _sumtdxxelse = value; }
            get { return _sumtdxxelse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NCZNQKBZ
        {
            set { _ncznqkbz = value; }
            get { return _ncznqkbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CNWNLDL
        {
            set { _cnwnldl = value; }
            get { return _cnwnldl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CNWCWNLDL
        {
            set { _cnwcwnldl = value; }
            get { return _cnwcwnldl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YZBM
        {
            set { _yzbm = value; }
            get { return _yzbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HKH
        {
            set { _hkh = value; }
            get { return _hkh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KHYH
        {
            set { _khyh = value; }
            get { return _khyh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JJBZ
        {
            set { _jjbz = value; }
            get { return _jjbz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXTANTUSLMJ
        {
            set { _sumslxxtantuslmj = value; }
            get { return _sumslxxtantuslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXYOUCHASLMJ
        {
            set { _sumslxxyouchaslmj = value; }
            get { return _sumslxxyouchaslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SUMSLXXZHULINSLMJ
        {
            set { _sumslxxzhulinslmj = value; }
            get { return _sumslxxzhulinslmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERIDENTIFICDNUMBER
        {
            set { _otheridentificdnumber = value; }
            get { return _otheridentificdnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LANDMGRGCARDNUMBER
        {
            set { _landmgrgcardnumber = value; }
            get { return _landmgrgcardnumber; }
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
