using System.Data;
using System.Text;
using DBUtility;
namespace DAL
{
    /// <summary>
    /// 数据访问类:JM
    /// </summary>
    public partial class DAL_BTLX
    {
        public DAL_BTLX()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT TYPECODE,TYPECODE||' | '||TYPENAME AS TYPENAME ");
            strSql.Append(" FROM COUNTYDATA.FSTYPE WHERE LENGTH(TYPECODE)=4 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere + " ORDER BY TYPECODE");
            }
            else
            {
                strSql.Append(" ORDER BY TYPECODE");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetTownLxID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT TYPEID,TYPECODE,TYPECODE||' | '||TYPENAME AS TYPENAME ");
            strSql.Append(" FROM COUNTYDATA.FSTYPE WHERE LENGTH(TYPECODE)=4 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere + " ORDER BY TYPECODE");
            }
            else
            {
                strSql.Append(" ORDER BY TYPECODE");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet GetFlow(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT FLOWID,FLOWNAME FROM COUNTYDATA.FLFLOW");
            strSql.Append(" WHERE 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  BasicMethod
    }
}
