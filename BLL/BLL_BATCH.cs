using System.Data;
namespace BLL
{
	/// <summary>
	/// BATCH
	/// </summary>
	public partial class BLL_BATCH
	{
		private readonly DAL.DAL_BATCH dal=new DAL.DAL_BATCH();
		public BLL_BATCH()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BATCH model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BATCH model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal BATCHID)
		{
			return dal.Delete(BATCHID);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		#endregion  BasicMethod
	}
}
