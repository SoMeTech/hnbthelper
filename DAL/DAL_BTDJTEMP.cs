using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:BTDJTEMP
    /// </summary>
    public partial class DAL_BTDJTEMP
    {
        public DAL_BTDJTEMP()
        { }
        #region  BasicMethod
        public bool imptmp(Model.BTDJTEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.BTDJTEMP (OBJECTCODE,SSSSIDCARDNUM,SSSSOBJECTNAME,REGMONEY,AMOUNT,TYPECODE,BATCHID,BATCHCODE,OFFSET,LSSUECYCLE,BANKCODE)  VALUES (");
            strSql.Append(":OBJECTCODE,:SSSSIDCARDNUM,:SSSSOBJECTNAME,:regmoney,:amount,:typecode,:batchid,:batchcode,:offset,:lssuecycle,:bankcode)");
            OracleParameter[] parameters = {
                                               new OracleParameter(":OBJECTCODE", OracleType.VarChar,20),
                                               new OracleParameter(":SSSSIDCARDNUM", OracleType.VarChar,100),
                                               new OracleParameter(":SSSSOBJECTNAME", OracleType.VarChar,100),
                                               new OracleParameter(":regmoney", OracleType.Number,10),
                                               new OracleParameter(":amount", OracleType.Number,8),
                                               new OracleParameter(":typecode", OracleType.VarChar,6),
                                               new OracleParameter(":batchid",OracleType.VarChar,36),
                                               new OracleParameter(":batchcode",OracleType.Number,5),
                                               new OracleParameter(":offset",OracleType.VarChar,2),
                                               new OracleParameter(":lssuecycle",OracleType.Char,1),
                                               new OracleParameter(":bankcode",OracleType.VarChar,6)
                                           };
            parameters[0].Value = model.OBJECTCODE;
            parameters[1].Value = model.SSSSIDCARDNUM;
            parameters[2].Value = model.SSSSOBJECTNAME;
            parameters[3].Value = model.REGMONEY;
            parameters[4].Value = model.AMOUNT;
            parameters[5].Value = model.TYPECODE;
            parameters[6].Value = model.Batchid;
            parameters[7].Value = model.Batchcode;
            parameters[8].Value = model.Offset;
            parameters[9].Value = model.Lssuecycle;
            parameters[10].Value = model.Batchcode;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UptypeID(Model.BTDJTEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COUNTYDATA.btdjtemp  a set a.typeid= ");
            strSql.Append("(select distinct substr(b.typeid,14,22)   from COUNTYDATA.fstype b ");
            strSql.Append(" where a.typecode=b.typecode and length(categorycode)=9) ");
            strSql.Append(" where exists (select 1 from  COUNTYDATA.fstype b where  a.typecode=b.typecode)");
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
        public bool UpObjectid(Model.BTDJTEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update countydata.btdjtemp  a set a.objectid=");
            strSql.Append(" ( select objectid   from COUNTYDATA.baseobject b");
            strSql.Append(" where a.OBJECTCODE=b.OBJECTCODE)");
            strSql.Append(" where exists (select 1 from  COUNTYDATA.baseobject b where  a.OBJECTCODE=b.OBJECTCODE)");
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
        public bool UpAccountnum(Model.BTDJTEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update countydata.btdjtemp  a set a.accountnum= ");
            strSql.Append(" (select accountnum   from COUNTYDATA.baseobjectaccount b ");
            strSql.Append(" where a.objectid=b.objectid) ");
            strSql.Append(" where exists (select 1 from  COUNTYDATA.baseobjectaccount b where  a.objectid=b.objectid)");
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
        public int GetErrCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) from COUNTYDATA.btdjtemp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
        public bool delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.BTDJTEMP");
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
        public int exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM User_Tables");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
        public DataSet GetBank(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT bankcode,bankname FROM COUNTYDATA.basebank");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool Createjmtb(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("create table COUNTYDATA.JM (");
            strSql.Append("key  VARCHAR2(2) not null,");
            strSql.Append("pass VARCHAR2(7)");
            strSql.Append(" )");
            strSql.Append(" tablespace COUNTYDATA ");
            strSql.Append(" pctfree 10");
            strSql.Append(" initrans 1");
            strSql.Append(" maxtrans 255");
            strSql.Append(" storage");
            strSql.Append(" (");
            strSql.Append(" initial 64");
            strSql.Append(" minextents 1");
            strSql.Append(" maxextents unlimited");
            strSql.Append(" )");
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
