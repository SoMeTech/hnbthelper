using System.Data;
namespace BLL
{
	/// <summary>
	/// RCBTDJTEMP
	/// </summary>
	public partial class BLL_RCBTDJTEMP
	{
		private readonly DAL.DAL_RCBTDJTEMP dal=new DAL.DAL_RCBTDJTEMP();
		public BLL_RCBTDJTEMP()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.RCBTDJTEMP model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.RCBTDJTEMP model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal GH)
		{
			return dal.Delete(GH);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet Export(string strWhere)
        {
            return dal.Export(strWhere);
        }
        public DataSet Find(string strWhere)
        {
            return dal.Find(strWhere);
        }
        public bool DeleteBybatchid(decimal batchid)
        {
            return dal.DeleteBybatchid(batchid);
        }
        public bool Upbt(Model.RCBTDJTEMP model)
        {
            return dal.Upbt(model);
        }
        public bool DeleteBtByGh(decimal gh)
        {
            return dal.DeleteBtByGh(gh);
        }
        public DataSet SUM(string strWhere)
        {
            return dal.SUM(strWhere);
        }
		#endregion  BasicMethod
	}
}
