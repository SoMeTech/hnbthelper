using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
namespace DAL
{
    /// <summary>
    /// 数据访问类:FSREGISTRATION
    /// </summary>
    public partial class DAL_FSREGISTRATION
    {
        public DAL_FSREGISTRATION()
        { }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT REGID,TYPEID,OBJECTID,TYPECODE,CATEGORYCODE,AMOUNT,STANDARD,REGMONEY,ACCOUNTNUM,NOTICEDATE,PAYDATE,PAYTYPE,RECEIVEDATE,IMPORTDATE,IMPORTTME,NOTICENO,BATCHID,EDIUSRCODE,EDIDATE,EDITIME,REGDATE,LOGICCODE,LOGICTIME,ISEFFECT,EXPORTDATE,EXPORTTME,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,LSSUETYPE,STATE,GENRECORDID,OFFSET,PAYCOMPANY,PAYADDRESS,REMARK,COUNTYCODE,FSYEAR,LSSUECYCLE,GENERATEID,FLOWID,BATCHCODE,HZCUSTID,SYSOPERTIME ");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        
        public DataSet Export(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TO_CHAR(RPAD(NVL(ACCOUNTNUM,' '),20,' '))");
            strSql.Append("||TO_CHAR(Rpad(substr(SSSSOBJECTNAME, 1, 10), 10, ' '))");
            strSql.Append("||TO_CHAR(RPAD(substr(GH,1,10),10,' '))");
            strSql.Append("||TO_CHAR(RPAD('1',10,' '))");
            strSql.Append("||TO_CHAR(RPAD(NVL(SSSSIDCARDNUM, ' '), 20, ' '))");
            strSql.Append("||TO_CHAR(RPAD(sum(REGMONEY),16,' '),'999999999999.99')");
            strSql.Append("||TO_CHAR(substr(rpad('a',21,' '),2,22))");
            strSql.Append("  FROM COUNTYDATA.CURRENTPAY  group by gh,ACCOUNTNUM,SSSSOBJECTNAME,SSSSIDCARDNUM");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool imptcurr(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.CURRENTPAY(OBJECTCODE,ACCOUNTNUM,SSSSOBJECTNAME,GH,SSSSIDCARDNUM,REGMONEY)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" VALUES( " + strWhere + ")");
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
        public DataSet Currentpay(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.OBJECTCODE,A.ACCOUNTNUM,A.SSSSOBJECTNAME,d.GH,A.SSSSIDCARDNUM,SUM(C.REGMONEY) ");
            strSql.Append("FROM V_BASEOBJECT A INNER JOIN COUNTYDATA.FSREGISTRATION C ON A.OBJECTID=C.OBJECTID  INNER JOIN COUNTYDATA.OBJECTGH D ON A.OBJECTID=D.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE a.isenable=1 and c.REGMONEY>0  and c.iseffect=0" + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetBatch(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  BATCHCODE,description,batchid  from COUNTYDATA.FSBATCH");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool DeleteCurr(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.CURRENTPAY");
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
        public bool DeleteNull()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.FSREGISTRATION WHERE FSYEAR=" + DateTime.Now.Year + " AND REGMONEY=0");
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
        public bool Upff(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.FSREGISTRATION ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" " + strWhere);
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
        public DataSet GetHz(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TO_CHAR(RPAD(NVL(OBJECTCODE,' '),18,' '))||','");
            strSql.Append("||TO_CHAR(Rpad(substr(SSSSOBJECTNAME,1,8),8,' '))||','");
            strSql.Append("||TO_CHAR(RPAD(NVL(ACCOUNTNUM,' '),20,' '))||','");
            strSql.Append("||TO_CHAR(rpad(sum(REGMONEY),8,' '),'99999.99')||';'");
            strSql.Append(" from COUNTYDATA.CURRENTPAY GROUP BY OBJECTCODE,SSSSOBJECTNAME,ACCOUNTNUM");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool Createtb(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("create table COUNTYDATA.BTDJTEMP (");
            strSql.Append("typeid     varchar2(36),");
            strSql.Append("OBJECTID     VARCHAR2(36),");
            strSql.Append("ACCOUNTNUM     varchar2(30),");
            strSql.Append("OBJECTCODE     varchar2(20),");
            strSql.Append("SSSSIDCARDNUM  varchar2(100),");
            strSql.Append("SSSSOBJECTNAME varchar2(100),");
            strSql.Append("regmoney       number(10,2),");
            strSql.Append("amount         number(8,2),");
            strSql.Append("typecode       varchar2(6),");
            strSql.Append("batchid        varchar2(36),");
            strSql.Append("batchcode      NUMBER(5),");
            strSql.Append("offset      varchar2(2),");
            strSql.Append("lssuecycle      char(1),");
            strSql.Append("bankcode      varchar2(6))");
            strSql.Append("tablespace COUNTYDATA");
            strSql.Append(" storage");
            strSql.Append("(initial 64K");
            strSql.Append(" minextents 1");
            strSql.Append("maxextents unlimited)");
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
        public bool insertintofsregistration(Model.FSREGISTRATION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.FSREGISTRATION(REGID,TYPEID,OBJECTID,TYPECODE,CATEGORYCODE,AMOUNT,STANDARD,REGMONEY,ACCOUNTNUM,BATCHID,EDIUSRCODE,EDIDATE,EDITIME,REGDATE,LOGICTIME,ISEFFECT,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,OFFSET,FSYEAR,LSSUECYCLE,BATCHCODE,HZCUSTID,SYSOPRETIME)  VALUES (");
            strSql.Append(":regid,:typeid,:objectid,:typecode,:categorycode,:amount,:standard,:regmoney,:accountnum,:batchid,:ediusrcode,:edidate,:editime,:regdate,:logictime,:iseffect,:SSSSOBJECTNAME,:SSSSIDCARDNUM,:OBJECTCODE,:bankcode,:offset,:fsyear,:lssuecycle,:batchcode,:hzcustid,:sysopretime)");
            OracleParameter[] parameters = { 
                                               new OracleParameter(":regid", OracleType.VarChar,36),
                                               new OracleParameter(":typeid", OracleType.VarChar,36),
                                               new OracleParameter(":objectid", OracleType.VarChar,36),
                                               new OracleParameter(":typecode", OracleType.VarChar,6),
                                               new OracleParameter(":categorycode", OracleType.VarChar,20),
                                               new OracleParameter(":amount", OracleType.Number,8),
                                               new OracleParameter(":standard", OracleType.VarChar,500),
                                               new OracleParameter(":regmoney", OracleType.Number,10),
                                               new OracleParameter(":accountnum", OracleType.VarChar,30),
                                               new OracleParameter(":batchid", OracleType.VarChar,36),
                                               new OracleParameter(":ediusrcode", OracleType.VarChar,50),
                                               new OracleParameter(":edidate", OracleType.Char,10),
                                               new OracleParameter(":editime", OracleType.Char,8),
                                               new OracleParameter(":regdate", OracleType.Char,10),
                                               new OracleParameter(":logictime", OracleType.Char,17),
                                               new OracleParameter(":iseffect", OracleType.Char,1),
                                               new OracleParameter(":SSSSOBJECTNAME", OracleType.VarChar,100),
                                               new OracleParameter(":SSSSIDCARDNUM", OracleType.VarChar,100),
                                               new OracleParameter(":OBJECTCODE", OracleType.VarChar,20),
                                               new OracleParameter(":bankcode", OracleType.VarChar,6),
                                               new OracleParameter(":offset", OracleType.VarChar,2),
                                               new OracleParameter(":fsyear", OracleType.Number,4),
                                               new OracleParameter(":lssuecycle", OracleType.Char,1),
                                               new OracleParameter(":batchcode", OracleType.Number,5),
                                               new OracleParameter(":hzcustid", OracleType.VarChar,10),
                                               new OracleParameter(":sysopertime", OracleType.Number,20)
                                           };
            parameters[0].Value = model.REGID;
            parameters[1].Value = model.TYPEID;
            parameters[2].Value = model.OBJECTID;
            parameters[3].Value = model.TYPECODE;
            parameters[4].Value = model.CATEGORYCODE;
            parameters[5].Value = model.AMOUNT;
            parameters[6].Value = model.STANDARD;
            parameters[7].Value = model.REGMONEY;
            parameters[8].Value = model.ACCOUNTNUM;
            parameters[9].Value = model.BATCHID;
            parameters[10].Value = model.EDIUSRCODE;
            parameters[11].Value = model.EDIDATE;
            parameters[12].Value = model.EDITIME;
            parameters[13].Value = model.REGDATE;
            parameters[14].Value = model.LOGICTIME;
            parameters[15].Value = model.ISEFFECT;
            parameters[16].Value = model.SSSSOBJECTNAME;
            parameters[17].Value = model.SSSSIDCARDNUM;
            parameters[18].Value = model.OBJECTCODE;
            parameters[19].Value = model.BANKCODE;
            parameters[20].Value = model.OFFSET;
            parameters[21].Value = model.FSYEAR;
            parameters[22].Value = model.LSSUECYCLE;
            parameters[23].Value = model.BATCHCODE;
            parameters[24].Value = model.HZCUSTID;
            parameters[25].Value = model.SYSOPERTIME;
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
        public bool imptodjb(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.FSREGISTRATION(REGID,TYPEID,OBJECTID,TYPECODE,CATEGORYCODE,AMOUNT,STANDARD,REGMONEY,ACCOUNTNUM,BATCHID,EDIUSRCODE,EDIDATE,EDITIME,REGDATE,LOGICTIME,ISEFFECT,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,OFFSET,FSYEAR,LSSUECYCLE,BATCHCODE,HZCUSTID,SYSOPRETIME)");
            strSql.Append(" SELECT SYS_GUID(),OBJECTID,TYPECODE,SUBSTR(OBJECTCODE,1,15),AMOUNT,0,REGMONEY,ACCOUNTNUM,BATCHID,SUBSTR(OBJECTCODE,1,9)||'001', TO_CHAR(SYSDATE,'YYYY-MM-DD'),TO_CHAR(SYSDATE,'HH24:MI:SS'),TO_CHAR(SYSDATE,'YYYY-MM-DD'),TO_CHAR(SYSDATE,'YYYYMMDDHH24MISSSSS'),0,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,OFFSET,TO_NUMBER(TO_CHAR(SYSDATE,'YYYY')),LSSUECYCLE,BATCHCODE,'SoMe001',TO_NUMBER(TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS')||'000') FROM COUNTYDATA.BTDJTEMP");
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
        public DataSet GetTownSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUBSTR(A.OBJECTCODE,1,9) \"A乡镇代码\",B.CATEGORYNAME \"B乡镇名称\",C.TYPENAME \"C补贴类型名称\",A.TYPECODE \"D补贴类型代码\",SUM(A.AMOUNT) AS \"F补贴数量\",SUM(A.REGMONEY) \"E补贴金额\" ");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION A LEFT JOIN COUNTYDATA.BASEOBJECTCOMPANY B ON SUBSTR(OBJECTCODE,1,9)=B.CATEGORYCODE  LEFT JOIN COUNTYDATA.BTLX C ON A.TYPECODE=C.TYPECODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetVillageSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUBSTR(A.OBJECTCODE,1,12) \"A村代码\",B.CATEGORYNAME \"B村名称\",C.TYPENAME \"C补贴类型名称\",A.TYPECODE \"D补贴类型代码\",SUM(A.AMOUNT) AS \"F补贴数量\",SUM(A.REGMONEY) \"E补贴金额\" ");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION A LEFT JOIN COUNTYDATA.BASEOBJECTCOMPANY B ON SUBSTR(OBJECTCODE,1,12)=B.CATEGORYCODE  LEFT JOIN COUNTYDATA.BTLX C ON A.TYPECODE=C.TYPECODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetGroupSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUBSTR(A.OBJECTCODE,1,15) \"A组代码\",B.CATEGORYNAME \"B组名称\",C.TYPENAME \"C补贴类型名称\",A.TYPECODE \"D补贴类型代码\",SUM(A.AMOUNT) AS \"F补贴数量\",SUM(A.REGMONEY) \"E补贴金额\" ");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION A LEFT JOIN COUNTYDATA.BASEOBJECTCOMPANY B ON SUBSTR(OBJECTCODE,1,15)=B.CATEGORYCODE  LEFT JOIN COUNTYDATA.BTLX C ON A.TYPECODE=C.TYPECODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetQuery(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT B.OBJECTCODE,B.SSSSOBJECTNAME,B.HOMEADDRESS,B.SSSSIDCARDNUM,B.ACCOUNTNUM, D.TYPENAME,A.TYPECODE,A.AMOUNT,A.STANDARD,A.REGMONEY");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION A LEFT JOIN V_BASEOBJECT B ON A.OBJECTID=B.OBJECTID  LEFT JOIN COUNTYDATA.BTLX D ON A.TYPECODE=D.TYPECODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        public int GetExsCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM COUNTYDATA.FSREGISTRATION ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public DataSet GetExtQuery(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.REGID,B.OBJECTCODE,B.SSSSOBJECTNAME,B.HOMEADDRESS,A.TYPEID, D.TYPENAME,A.TYPECODE,A.REGMONEY");
            strSql.Append(" FROM COUNTYDATA.FSREGISTRATION A LEFT JOIN V_BASEOBJECT B ON A.OBJECTID=B.OBJECTID  LEFT JOIN COUNTYDATA.FSTYPE D ON A.TYPECODE=D.TYPECODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE A.REGMONEY>0 AND SUBSTR(B.OBJECTCODE,1,9)=SUBSTR(D.CATEGORYCODE,1,9) AND LENGTH(D.CATEGORYCODE)=9 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet ExpToEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.SSSSOBJECTNAME,A.ACCOUNTNUM,A.SSSSIDCARDNUM,SUM(C.REGMONEY) AS BTJE");
            strSql.Append(" FROM V_BASEOBJECT a ");
            strSql.Append(" INNER Join COUNTYDATA.FSREGISTRATION c on a.OBJECTID=c.OBJECTID ");
            strSql.Append(" inner Join COUNTYDATA.OBJECTGH d on a.OBJECTID=d.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.isenable=1 and c.REGMONEY>0  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
    }
}
