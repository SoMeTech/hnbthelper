using System.Data;
namespace BLL
{
    /// <summary>
    /// FSREGISTRATION
    /// </summary>
    public partial class BLL_FSREGISTRATION
    {
        private readonly DAL.DAL_FSREGISTRATION dal = new DAL.DAL_FSREGISTRATION();
        public BLL_FSREGISTRATION()
        { }
        #region  BasicMethod
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
        public DataSet GetBatch(string strWhere)
        {
            return dal.GetBatch(strWhere);
        }
        public bool DeleteNull()
        {
            return dal.DeleteNull();
        }
        public bool Upff(string strWhere)
        {
            return dal.Upff(strWhere);
        }
        public DataSet GetHz(string strWhere)
        {
            return dal.GetHz(strWhere);
        }
        public bool Createtb(string strWhere)
        {
            return dal.Createtb(strWhere);
        }
        public bool insertintofsregistration(Model.FSREGISTRATION model)
        {
            return dal.insertintofsregistration(model);
        }
        public bool imptodjb(string strWhere)
        {
            return dal.imptodjb(strWhere);
        }
        public DataSet GetTownSum(string strWhere)
        {
            return dal.GetTownSum(strWhere);
        }
        public DataSet GetVillageSum(string strWhere)
        {
            return dal.GetVillageSum(strWhere);
        }
        public DataSet GetGroupSum(string strWhere)
        {
            return dal.GetGroupSum(strWhere);
        }
        public DataSet GetQuery(string strWhere)
        {
            return dal.GetQuery(strWhere);
        }
        public DataSet ExpToEx(string strWhere)
        {
            return dal.ExpToEx(strWhere);
        }
        #endregion  BasicMethod
        public DataSet Currentpay(string strWhere)
        {
            return dal.Currentpay(strWhere);
        }
        public bool imptcurr(string strWhere)
        {
            return dal.imptcurr(strWhere);
        }
        public bool DeleteCurr(string strWhere)
        {
            return dal.DeleteCurr(strWhere);
        }
        public DataSet GetExtQuery(string strWhere)
        {
            return dal.GetExtQuery(strWhere);
        }
        public int GetExsCount(string strWhere)
        {
            return dal.GetExsCount(strWhere);
        }
    }
}
