using System;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using DBUtility;
using System.Collections;
namespace DAL
{
    public partial class DAL_WFBT
    {
        public DAL_WFBT()
        { }
        public bool impWFBT(Model.WFBT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.WFBT (gh,yxm,je,lb,yzh,wfyy) VALUES (");
            strSql.Append(":Gh,:Yxm,:Je,:Lb,:yzh,:wfyy)");
            OracleParameter[] parameters = {
                                               new OracleParameter(":Gh", OracleType.Number,10),
                                               new OracleParameter(":Yxm", OracleType.VarChar,10),
                                               new OracleParameter(":Je", OracleType.Number,10),
                                               new OracleParameter(":Lb", OracleType.VarChar,20),
                                               new OracleParameter(":yzh", OracleType.VarChar,30),
                                               new OracleParameter(":wfyy", OracleType.VarChar,100)
                                           };
            parameters[0].Value = model.Gh;
            parameters[1].Value = model.Yxm;
            parameters[2].Value = model.Je;
            parameters[3].Value = model.Lb;
            parameters[4].Value = model.Yzh;
            parameters[5].Value = model.Wfyy;
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
        public bool ImpWFBTByTrans(Model.WFBT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.WFBT (gh,yxm,je,lb,yzh,wfyy) VALUES (");
            strSql.Append(":Gh,:Yxm,:Je,:Lb,:yzh,:wfyy)");
            OracleParameter[] parameters = {
                                               new OracleParameter(":Gh", OracleType.Number,10),
                                               new OracleParameter(":Yxm", OracleType.VarChar,10),
                                               new OracleParameter(":Je", OracleType.Number,10),
                                               new OracleParameter(":Lb", OracleType.VarChar,20),
                                               new OracleParameter(":yzh", OracleType.VarChar,30),
                                               new OracleParameter(":wfyy", OracleType.VarChar,100)
                                           };
            parameters[0].Value = model.Gh;
            parameters[1].Value = model.Yxm;
            parameters[2].Value = model.Je;
            parameters[3].Value = model.Lb;
            parameters[4].Value = model.Yzh;
            parameters[5].Value = model.Wfyy;
            Hashtable SQLStringList = new Hashtable();
            SQLStringList.Add(strSql, parameters);
            try
            {
                DbHelperOra.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataSet GetLb(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT LB FROM COUNTYDATA.WFBT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet Currentpay(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ACCOUNTNUM,SSSSOBJECTNAME,GH,SSSSIDCARDNUM,JE ");
            strSql.Append("FROM COUNTYDATA.WFBT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetFF(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TO_CHAR(RPAD(NVL(ACCOUNTNUM, ' '), 20, ' '))");
            strSql.Append("||TO_CHAR(Rpad(substr(ssssobjectname , 1, 10), 10, ' '))");
            strSql.Append("||TO_CHAR(Rpad(substr(gh, 1, 10), 10, ' '))");
            strSql.Append("||TO_CHAR(Rpad('1', 10, ' '))");
            strSql.Append("||TO_CHAR(RPAD(NVL(ssssidcardnum, ' '), 20, ' '))");
            strSql.Append("||TO_CHAR(RPAD(sum(REGMONEY), 16, ' '), '999999999999.99')");
            strSql.Append("||TO_CHAR(substr(rpad('a', 21, ' '), 2, 20))");
            strSql.Append(" FROM COUNTYDATA.CURRENTPAY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public int GetErrCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM COUNTYDATA.WFBT ");
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
        public bool delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.WFBT ");
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT GH,YXM,YZH,ssssobjectname,ACCOUNTNUM,SSSSIDCARDNUM,DZ,LB,JE,WFYY FROM COUNTYDATA.WFBT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
    }
}
