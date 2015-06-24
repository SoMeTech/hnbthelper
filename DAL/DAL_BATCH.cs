using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
namespace DAL
{
	/// <summary>
	/// 数据访问类:BATCH
	/// </summary>
	public partial class DAL_BATCH
	{
        public DAL_BATCH()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BATCH model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("INSERT INTO COUNTYDATA.BATCH(");
			strSql.Append("TYPECODE,BATCHNAME)");
			strSql.Append(" VALUES (");
			strSql.Append(":TYPECODE,:BATCHNAME)");
			OracleParameter[] parameters = {
					new OracleParameter(":TYPECODE", OracleType.VarChar,6),
					new OracleParameter(":BATCHNAME", OracleType.VarChar,50)};
			parameters[0].Value = model.TYPECODE;
			parameters[1].Value = model.BATCHNAME;
			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BATCH model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.BATCH SET ");
			strSql.Append("TYPECODE=:TYPECODE,");
			strSql.Append("BATCHNAME=:BATCHNAME");
			strSql.Append(" WHERE BATCHID=:BATCHID ");
			OracleParameter[] parameters = {
					new OracleParameter(":TYPECODE", OracleType.VarChar,6),
					new OracleParameter(":BATCHNAME", OracleType.VarChar,50),
					new OracleParameter(":BATCHID", OracleType.Number,4)};
			parameters[0].Value = model.TYPECODE;
			parameters[1].Value = model.BATCHNAME;
			parameters[2].Value = model.BATCHID;
			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal BATCHID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.BATCH ");
			strSql.Append(" WHERE BATCHID=:BATCHID ");
			OracleParameter[] parameters = {
					new OracleParameter(":BATCHID", OracleType.Number,22)			};
			parameters[0].Value = BATCHID;
			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT BATCHID,TYPECODE,BATCHNAME ");
            strSql.Append(" FROM COUNTYDATA.BATCH ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
		#endregion  BasicMethod
	}
}
