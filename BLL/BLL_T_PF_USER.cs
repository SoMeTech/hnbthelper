using System.Data;
namespace BLL
{
	/// <summary>
	/// T_PF_USER
	/// </summary>
	public partial class BLL_T_PF_USER
	{
		private readonly DAL.DAL_T_PF_USER dal=new DAL.DAL_T_PF_USER();
		public BLL_T_PF_USER()
		{}
		#region  BasicMethod
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
