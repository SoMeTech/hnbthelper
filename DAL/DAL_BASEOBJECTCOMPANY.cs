using System.Data;
using System.Text;
using DBUtility;
namespace DAL
{
    /// <summary>
    /// 数据访问类:BASEOBJECTCOMPANY
    /// </summary>
    public partial class DAL_BASEOBJECTCOMPANY
    {
        public DAL_BASEOBJECTCOMPANY()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CATEGORYID,PID,CATEGORYCODE,CATEGORYNAME,EDIUSRCODE,EDIDATE,EDITIME,REGDATE,LOGICCODE,LOGICTIME,ISEFFECT,COUNTYCODE,REMARK,HZCUSTID,SYSOPERTIME ");
            strSql.Append(" FROM COUNTYDATA.BASEOBJECTCOMPANY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  BasicMethod
    }
}
