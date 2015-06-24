using System.Data;
namespace BLL
{
    /// <summary>
    /// BASEOBJECTCOMPANY
    /// </summary>
    public partial class BLL_BASEOBJECTCOMPANY
    {
        private readonly DAL.DAL_BASEOBJECTCOMPANY dal = new DAL.DAL_BASEOBJECTCOMPANY();
        public BLL_BASEOBJECTCOMPANY()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        #endregion  ExtensionMethod
    }
}
