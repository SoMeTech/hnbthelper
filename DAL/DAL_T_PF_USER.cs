using System.Data;
using System.Text;
using DBUtility;
namespace DAL
{
	/// <summary>
	/// 数据访问类:T_PF_USER
	/// </summary>
	public partial class DAL_T_PF_USER
	{
		public DAL_T_PF_USER()
		{}
		#region  BasicMethod
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT USERCODE,PASSWRD,USERNAME,IDENTIFY,PFCMZ,USERSTATE,DEPID,LOGINNAME,PHONE,HZCUSTID,SYSOPERTIME ");
			strSql.Append(" FROM TOOLDATA.T_PF_USER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
		#endregion  BasicMethod
	}
}
