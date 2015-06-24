using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
namespace DAL
{
	/// <summary>
	/// 数据访问类:RCBTDJTEMP
	/// </summary>
	public partial class DAL_RCBTDJTEMP
	{
		public DAL_RCBTDJTEMP()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.RCBTDJTEMP model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("INSERT INTO COUNTYDATA.RCBTDJTEMP(");
			strSql.Append("GH,BTLX,OBJECT_NAME,ZHM,BATCHID,SFZH,DZ,LXDH,YHZH,BTSL,BTBZ,BTJE,FSYEAR,FSMONTH,FF,REGDATE,FFDATE,WFYY,MEMO,EXPAND1,EXPAND2,EXPAND3,EXPAND4,EXPAND5)");
			strSql.Append(" VALUES (");
			strSql.Append(":GH,:BTLX,:OBJECT_NAME,:ZHM,:BATCHID,:SFZH,:DZ,:LXDH,:YHZH,:BTSL,:BTBZ,:BTJE,:FSYEAR,:FSMONTH,:FF,:REGDATE,:FFDATE,:WFYY,:MEMO,:EXPAND1,:EXPAND2,:EXPAND3,:EXPAND4,:EXPAND5)");
			OracleParameter[] parameters = {
					new OracleParameter(":GH", OracleType.Number,4),
					new OracleParameter(":BTLX", OracleType.VarChar,10),
					new OracleParameter(":OBJECT_NAME", OracleType.NVarChar),
					new OracleParameter(":ZHM", OracleType.NVarChar),
					new OracleParameter(":BATCHID", OracleType.Number,4),
					new OracleParameter(":SFZH", OracleType.VarChar,30),
					new OracleParameter(":DZ", OracleType.VarChar,50),
					new OracleParameter(":LXDH", OracleType.VarChar,20),
					new OracleParameter(":YHZH", OracleType.VarChar,30),
					new OracleParameter(":BTSL", OracleType.Number,18),
					new OracleParameter(":BTBZ", OracleType.Number,18),
					new OracleParameter(":BTJE", OracleType.Number,10),
					new OracleParameter(":FSYEAR", OracleType.Number,4),
					new OracleParameter(":FSMONTH", OracleType.Number,4),
					new OracleParameter(":FF", OracleType.Char,1),
					new OracleParameter(":REGDATE", OracleType.Char,10),
					new OracleParameter(":FFDATE", OracleType.Char,10),
					new OracleParameter(":WFYY", OracleType.VarChar,50),
					new OracleParameter(":MEMO", OracleType.VarChar,50),
					new OracleParameter(":EXPAND1", OracleType.VarChar,50),
					new OracleParameter(":EXPAND2", OracleType.VarChar,50),
					new OracleParameter(":EXPAND3", OracleType.VarChar,50),
					new OracleParameter(":EXPAND4", OracleType.VarChar,50),
					new OracleParameter(":EXPAND5", OracleType.VarChar,50)};
			parameters[0].Value = model.GH;
			parameters[1].Value = model.BTLX;
			parameters[2].Value = model.OBJECT_NAME;
			parameters[3].Value = model.ZHM;
			parameters[4].Value = model.BATCHID;
			parameters[5].Value = model.SFZH;
			parameters[6].Value = model.DZ;
			parameters[7].Value = model.LXDH;
			parameters[8].Value = model.YHZH;
			parameters[9].Value = model.BTSL;
			parameters[10].Value = model.BTBZ;
			parameters[11].Value = model.BTJE;
			parameters[12].Value = model.FSYEAR;
			parameters[13].Value = model.FSMONTH;
			parameters[14].Value = model.FF;
			parameters[15].Value = model.REGDATE;
			parameters[16].Value = model.FFDATE;
			parameters[17].Value = model.WFYY;
			parameters[18].Value = model.MEMO;
			parameters[19].Value = model.EXPAND1;
			parameters[20].Value = model.EXPAND2;
			parameters[21].Value = model.EXPAND3;
			parameters[22].Value = model.EXPAND4;
			parameters[23].Value = model.EXPAND5;
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
		public bool Update(Model.RCBTDJTEMP model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.RCBTDJTEMP set ");
			strSql.Append("BTLX=:BTLX,");
			strSql.Append("OBJECT_NAME=:OBJECT_NAME,");
			strSql.Append("ZHM=:ZHM,");
			strSql.Append("BATCHID=:BATCHID,");
			strSql.Append("SFZH=:SFZH,");
			strSql.Append("DZ=:DZ,");
			strSql.Append("LXDH=:LXDH,");
			strSql.Append("YHZH=:YHZH,");
			strSql.Append("BTSL=:BTSL,");
			strSql.Append("BTBZ=:BTBZ,");
			strSql.Append("BTJE=:BTJE,");
			strSql.Append("FSYEAR=:FSYEAR,");
			strSql.Append("FSMONTH=:FSMONTH,");
			strSql.Append("FF=:FF,");
			strSql.Append("REGDATE=:REGDATE,");
			strSql.Append("FFDATE=:FFDATE,");
			strSql.Append("WFYY=:WFYY,");
			strSql.Append("MEMO=:MEMO,");
			strSql.Append("EXPAND1=:EXPAND1,");
			strSql.Append("EXPAND2=:EXPAND2,");
			strSql.Append("EXPAND3=:EXPAND3,");
			strSql.Append("EXPAND4=:EXPAND4,");
			strSql.Append("EXPAND5=:EXPAND5");
			strSql.Append(" where GH=:GH ");
			OracleParameter[] parameters = {
					new OracleParameter(":BTLX", OracleType.VarChar,10),
					new OracleParameter(":OBJECT_NAME", OracleType.NVarChar),
					new OracleParameter(":ZHM", OracleType.NVarChar),
					new OracleParameter(":BATCHID", OracleType.Number,4),
					new OracleParameter(":SFZH", OracleType.VarChar,30),
					new OracleParameter(":DZ", OracleType.VarChar,50),
					new OracleParameter(":LXDH", OracleType.VarChar,20),
					new OracleParameter(":YHZH", OracleType.VarChar,30),
					new OracleParameter(":BTSL", OracleType.Number,18),
					new OracleParameter(":BTBZ", OracleType.Number,18),
					new OracleParameter(":BTJE", OracleType.Number,10),
					new OracleParameter(":FSYEAR", OracleType.Number,4),
					new OracleParameter(":FSMONTH", OracleType.Number,4),
					new OracleParameter(":FF", OracleType.Char,1),
					new OracleParameter(":REGDATE", OracleType.Char,10),
					new OracleParameter(":FFDATE", OracleType.Char,10),
					new OracleParameter(":WFYY", OracleType.VarChar,50),
					new OracleParameter(":MEMO", OracleType.VarChar,50),
					new OracleParameter(":EXPAND1", OracleType.VarChar,50),
					new OracleParameter(":EXPAND2", OracleType.VarChar,50),
					new OracleParameter(":EXPAND3", OracleType.VarChar,50),
					new OracleParameter(":EXPAND4", OracleType.VarChar,50),
					new OracleParameter(":EXPAND5", OracleType.VarChar,50),
					new OracleParameter(":GH", OracleType.Number,4)};
			parameters[0].Value = model.BTLX;
			parameters[1].Value = model.OBJECT_NAME;
			parameters[2].Value = model.ZHM;
			parameters[3].Value = model.BATCHID;
			parameters[4].Value = model.SFZH;
			parameters[5].Value = model.DZ;
			parameters[6].Value = model.LXDH;
			parameters[7].Value = model.YHZH;
			parameters[8].Value = model.BTSL;
			parameters[9].Value = model.BTBZ;
			parameters[10].Value = model.BTJE;
			parameters[11].Value = model.FSYEAR;
			parameters[12].Value = model.FSMONTH;
			parameters[13].Value = model.FF;
			parameters[14].Value = model.REGDATE;
			parameters[15].Value = model.FFDATE;
			parameters[16].Value = model.WFYY;
			parameters[17].Value = model.MEMO;
			parameters[18].Value = model.EXPAND1;
			parameters[19].Value = model.EXPAND2;
			parameters[20].Value = model.EXPAND3;
			parameters[21].Value = model.EXPAND4;
			parameters[22].Value = model.EXPAND5;
			parameters[23].Value = model.GH;
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
		public bool Delete(decimal GH)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.RCBTDJTEMP ");
			strSql.Append(" WHERE GH=:GH ");
			OracleParameter[] parameters = {
					new OracleParameter(":GH", OracleType.Number,22)			};
			parameters[0].Value = GH;
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
			strSql.Append("SELECT GH,BTLX,OBJECT_NAME,ZHM,BATCHID,SFZH,DZ,LXDH,YHZH,BTSL,BTBZ,BTJE,FSYEAR,FSMONTH,FF,REGDATE,FFDATE,WFYY,MEMO,EXPAND1,EXPAND2,EXPAND3,EXPAND4,EXPAND5 ");
            strSql.Append(" FROM COUNTYDATA.RCBTDJTEMP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
        public DataSet Export(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TO_CHAR(RPAD(NVL(yhzh, ' '), 20, ' '))");
            strSql.Append("||TO_CHAR(Rpad(substr(zhm , 1, 10), 10, ' '))");
            strSql.Append("||TO_CHAR(Rpad(substr(gh, 1, 10), 10, ' '))");
            strSql.Append("||TO_CHAR(Rpad('1', 10, ' '))");
            strSql.Append("||TO_CHAR(RPAD(NVL(sfzh, ' '), 20, ' '))");
            strSql.Append("||TO_CHAR(RPAD(sum(btje), 16, ' '), '999999999999.99')");
            strSql.Append("||TO_CHAR(substr(rpad('a', 21, ' '), 2, 20))  ");
            strSql.Append(" FROM  COUNTYDATA.rcbtdjtemp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE FF=0 AND BTJE>0 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public DataSet Find(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.dz,a.gh,a.object_name,a.zhm,a.lxdh,a.sfzh,a.yhzh,c.TYPENAME,a.btsl,a.btbz,a.btje,a.ff,a.ffdate,a.wfyy,b.batchname ");
            strSql.Append("FROM   COUNTYDATA.rcbtdjtemp a,COUNTYDATA.batch b,COUNTYDATA.FSTYPE c where a.batchid=b.batchid and a.btlx=c.typecode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere + "  group by gh,dz,object_name,zhm,lxdh,sfzh,yhzh,typename,btsl,btbz,btje,ff,ffdate,wfyy,batchname order by gh");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool DeleteBybatchid(decimal batchid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.RCBTDJTEMP ");
            strSql.Append(" WHERE batchid=:batchid");
            OracleParameter[] parameters = {
					new OracleParameter(":batchid", OracleType.Number,22)			};
            parameters[0].Value = batchid;
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
        public bool DeleteBtByGh(decimal gh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM COUNTYDATA.RCBTDJTEMP ");
            strSql.Append(" WHERE gh=:gh");
            OracleParameter[] parameters = {
					new OracleParameter(":gh", OracleType.Number,22)			};
            parameters[0].Value = gh;
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
        public bool Upbt(Model.RCBTDJTEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE COUNTYDATA.RCBTDJTEMP SET ");
            strSql.Append("object_name=:object_name,");
            strSql.Append("zhm=:zhm,");
            strSql.Append("sfzh=:sfzh,");
            strSql.Append("dz=:dz,");
            strSql.Append("yhzh=:yhzh,");
            strSql.Append("btsl=:btsl,");
            strSql.Append("btje=:btje");
            strSql.Append(" where gh=:gh");
            OracleParameter[] parameters = {
					new OracleParameter(":object_name", OracleType.VarChar,10),
					new OracleParameter(":zhm", OracleType.VarChar,10),
					new OracleParameter(":sfzh", OracleType.VarChar,30),
					new OracleParameter(":dz", OracleType.VarChar,50),					
					new OracleParameter(":yhzh", OracleType.VarChar,30),
					new OracleParameter(":btsl", OracleType.Number,9),
					new OracleParameter(":btje", OracleType.Number,8),
					new OracleParameter(":gh", OracleType.Number,4)};
            parameters[0].Value = model.OBJECT_NAME;
            parameters[1].Value = model.ZHM;
            parameters[2].Value = model.SFZH;
            parameters[3].Value = model.DZ;
            parameters[4].Value = model.YHZH;
            parameters[5].Value = model.BTSL;
            parameters[6].Value = model.BTJE;
            parameters[7].Value = model.GH;
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
        public DataSet SUM(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT nvl(sum(btje),0),count(*) ");
            strSql.Append(" FROM   COUNTYDATA.rcbtdjtemp  where  ff=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
		#endregion  BasicMethod
	}
}
