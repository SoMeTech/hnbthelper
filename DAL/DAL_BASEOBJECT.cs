using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
namespace DAL
{
    /// <summary>
    /// 数据访问类:BASEOBJECT
    /// </summary>
    public partial class DAL_BASEOBJECT
    {
        public DAL_BASEOBJECT()
        { }
        #region  BasicMethod
        public  DataSet getquery(string strWhere)
        {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select queryid from countydata.querytb ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

      
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OBJECTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM COUNTYDATA.BASEOBJECT");
            strSql.Append(" WHERE OBJECTID=:OBJECTID ");
            OracleParameter[] parameters = {
					new OracleParameter(":OBJECTID", OracleType.VarChar,36)			};
            parameters[0].Value = OBJECTID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OBJECTID,CATEGORYID,OBJECTCODE,SSSSOBJECTNAME,CARDTYPE,ACCOUNTNUM,SSSSIDCARDNUM,HOMEADDRESS,MEMBERNUM,ECONOMICPROPERTY,ISENABLE,SEX,PHONE,STATUS,ATHOMEPEOPLE,OUTHOMEPEOPLE,POSTCODE,BANKNAME,ISMAIN,CHILDREN,ISDRAW,DRAWNUM,SINGLETONTYPE,POORCASE,INCOME,HOUSEAREA,ENSUREDNUM,LOWINSURANCE,PROVIDETYPE,PROTECTEDOBJ,PROTECTEDOBJTYPE,POORFAMILY,BELONGTHREE,ADDRESS,REMARK,EDIUSRCODE,EDIDATE,EDITIME,REGDATE,LOGICCODE,ISEFFECT,LOGICTIME,TDCBMJ,TDCBZH,SLCBMJ,SLCBZH,SMCBMJ,SMCBZH,CBXXBQ,WHBJQS,QLGJQS,JQXXBZ,HTMJ,CDMJ,ZDMJ,MDMJ,LZBTMJXXBZ,WDMJ,ZBMJ,SSMJ,KYMJ,QTLSZWMJ,FZMJ,AZDMJ,AMDMJ,AWDMJ,ZZXXBZ,YMLX,DXLSL,JXLSL,XSYMKL,YMXXBZ,FQZSYLX,JSXXBZ,BFJHSY,JZDMJ,JMDMJ,JWDMJ,ZZXJDDFY,ZZQTNFTDFY,YJSMJ,YJSCC,NFCBTDFYQKBZ,ZXLFYJR,DBHXTWJR,LSYGBGJS,ZXHJSSTWZS,SWRY,ZXCJJR,NCYWBJS,KNCCGB,WFH,XZXXBZ,COUNTYCODE,SUMSLXXSLMJ,SUMSLXXRGLSLMJ,SUMSLXXTRLSLMJ,SUMSLXXKYLSLMJ,SUMSLXXHSSLMJ,SUMTDXX,SUMTDXXST,SUMTDXXHT,SUMTDXXCD,SUMTDXXELSE,NCZNQKBZ,CNWNLDL,CNWCWNLDL,YZBM,HKH,KHYH,JJBZ,SUMSLXXTANTUSLMJ,SUMSLXXYOUCHASLMJ,SUMSLXXZHULINSLMJ,OTHERIDENTIFICDNUMBER,LANDMGRGCARDNUMBER,HZCUSTID,SYSOPERTIME ");
            strSql.Append(" FROM V_BASEOBJECT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        ///<summary>
        ///解密身份证
        ///</summary>
        public bool Updatesfz(Model.BASEOBJECT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.BASEOBJECT SET SSSSIDCARDNUM=REPLACE(TRANSLATE(SSSSIDCARDNUM,'BA@GFEDKJC+','1234567890X'),'^1','') WHERE INSTR(SSSSIDCARDNUM,'^1')>0 ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Updatexm(Model.BASEOBJECT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.BASEOBJECT SET SSSSOBJECTNAME =JM_DECRYPTION(SSSSOBJECTNAME) WHERE INSTR(SSSSOBJECTNAME,'^1')>0");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataSet ExpBasic(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OBJECTCODE,HOMEADDRESS,SSSSOBJECTNAME,SSSSIDCARDNUM,ACCOUNTNUM FROM V_BASEOBJECT WHERE 1=1");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool UpdateHOMEADDRESS(Model.BASEOBJECT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.BASEOBJECT T SET T.HOMEADDRESS =(SELECT T1.CATEGORYNAME||T2.CATEGORYNAME||T3.CATEGORYNAME ");
            strSql.Append(" FROM COUNTYDATA.BASEOBJECTCOMPANY T1  LEFT JOIN  COUNTYDATA.BASEOBJECTCOMPANY T2 ON T2.PID=T1.CATEGORYID ");
            strSql.Append(" LEFT JOIN COUNTYDATA.BASEOBJECTCOMPANY T3 ON T3.PID=T2.CATEGORYID ");
            strSql.Append(" WHERE T1.CATEGORYCODE = SUBSTR(T.OBJECTCODE, 0, 9) AND T2.CATEGORYCODE=SUBSTR(T.OBJECTCODE, 0, 12) AND T3.CATEGORYCODE=SUBSTR(T.OBJECTCODE, 0, 15)");
            strSql.Append(" ) WHERE HOMEADDRESS IS NULL");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataSet GetBasic(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  OBJECTID,SSSSOBJECTNAME,SSSSIDCARDNUM,HOMEADDRESS,OBJECTCODE,ACCOUNTNUM");
            strSql.Append(" FROM V_BASEOBJECT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet ExptoExcelBasic(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT HOMEADDRESS,OBJECTCODE,SSSSOBJECTNAME,SSSSIDCARDNUM,ACCOUNTNUM ");
            strSql.Append(" FROM V_BASEOBJECT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(@strSql.ToString());
        }
        public DataSet GetZbmj(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT HOMEADDRESS,OBJECTCODE,SSSSOBJECTNAME,SSSSIDCARDNUM,ACCOUNTNUM,ZDMJ,MDMJ,WDMJ,ZBMJ");
            strSql.Append(" FROM V_BASEOBJECT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(@strSql.ToString());
        }
        public bool UP15to18(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.BASEOBJECT SET SSSSIDCARDNUM=SUBSTR(SSSSIDCARDNUM,1,6)||'19'||SUBSTR(SSSSIDCARDNUM,7,15)||GETVERIFY_ISO7064(SUBSTR(SSSSIDCARDNUM,1,6)||'19'||SUBSTR(SSSSIDCARDNUM,7,15))");
            strSql.Append(" WHERE INSTR(A.SSSSIDCARDNUM,'^1')=0 AND LENGTH(SSSSIDCARDNUM)=15");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool JM(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("CREATE OR REPLACE FUNCTION JM_ujm(name in varchar2) return varchar2 is");
            strSql.Append(" Result varchar2(400);");
            strSql.Append("ls_sql varchar2(4000);");
            strSql.Append(" v_length number := (length(name) - 2) / 9;");
            strSql.Append("v_mm  varchar2(4000);");
            strSql.Append("m number;");
            strSql.Append("begin");
            strSql.Append(" begin");
            strSql.Append("for i in 1 .. v_length loop");
            strSql.Append("m:= i * 7 - 6;");
            strSql.Append("ls_sql := 'select a.key from jm a where a.pass =substr(regexp_replace(''' || name || ''', ''\\^1V6|V6'', ''''), ' || m || ', 7)';");
            strSql.Append("execute immediate ls_sql  into v_mm;");
            strSql.Append("Result := Result || v_mm;");
            strSql.Append("end loop;");
            strSql.Append("exception when others then Result := '';");
            strSql.Append("end;");
            strSql.Append("return(Result);");
            strSql.Append("end;");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //按身份证查询，导入临时表的方法
        public DataSet GetByCardTemp(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT B.HOMEADDRESS AS \"A家庭地址\",B.OBJECTCODE AS \"B农户代码\",B.SSSSOBJECTNAME AS \"C农户姓名\",B.SSSSIDCARDNUM AS QUERY,B.ACCOUNTNUM AS \"E银行账号\" ");
            strSql.Append(" FROM COUNTYDATA.QUERYTB A LEFT JOIN V_BASEOBJECT B ON A.QUERYID='^1'||translate(B.ssssidcardnum,'1234567890X','BA@GFEDKJC+')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(@strSql.ToString());
        }
        //按银行账号查询，导入临时表的方法
        public DataSet GetByYhzhTemp(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT B.HOMEADDRESS AS \"A家庭地址\",B.OBJECTCODE AS \"B农户代码\",B.SSSSOBJECTNAME AS \"C农户姓名\",B.SSSSIDCARDNUM AS \"D身份证号\",B.ACCOUNTNUM AS QUERY ");
            strSql.Append(" FROM COUNTYDATA.QUERYTB A LEFT JOIN V_BASEOBJECT B ON A.QUERYID=B.ACCOUNTNUM");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(@strSql.ToString());
        }
        public DataSet CNM(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SSSSOBJECTNAME,OBJECTID,SSSSIDCARDNUM,OBJECTCODE FROM COUNTYDATA.BASEOBJECT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(@strSql.ToString());
        }
        //清空临时表
        public bool DelQuery(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.QUERYTB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod
    }
}
