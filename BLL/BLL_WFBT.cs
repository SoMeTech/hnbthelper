using System.Data;
namespace BLL
{
    public partial class BLL_WFBT
    {
        public BLL_WFBT()
        { }
        private readonly DAL.DAL_WFBT dal = new DAL.DAL_WFBT();
        public bool impWFBT(Model.WFBT model)
        {
            return dal.impWFBT(model);
        }
        public bool ImpWFBTByTrans(Model.WFBT model)
        {
            return dal.ImpWFBTByTrans(model);
        }
        public DataSet GetLb(string strWhere)
        {
            return dal.GetLb(strWhere);
        }
        public DataSet GetFF(string strWhere)
        {
            return dal.GetFF(strWhere);
        }
        public int GetErrCount(string strWhere)
        {
            return dal.GetErrCount(strWhere);
        }
        public bool delete(string strWhere)
        {
            return dal.delete(strWhere);
        }
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public bool DeleteCurr(string strWhere)
        {
            return dal.DeleteCurr(strWhere);
        }
        public DataSet Currentpay(string strWhere)
        {
            return dal.Currentpay(strWhere);
        }
    }
}
