using System.Data;
namespace BLL
{
    /// <summary>
    /// BTLX
    /// </summary>
    public partial class BLL_BTLX
    {
        private readonly DAL.DAL_BTLX dal = new DAL.DAL_BTLX();
        public BLL_BTLX()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetTownLxID(string strWhere)
        {
            return dal.GetTownLxID(strWhere);
        }
        public DataSet GetFlow(string strWhere)
        {
            return dal.GetFlow(strWhere);
        }
        #endregion  BasicMethod
    }
}
