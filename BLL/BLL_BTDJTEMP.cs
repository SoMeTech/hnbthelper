using System.Data;
namespace BLL
{
    /// <summary>
    /// btdjtemp
    /// </summary>
    public partial class BLL_BTDJTEMP
    {
        private readonly DAL.DAL_BTDJTEMP dal = new DAL.DAL_BTDJTEMP();
        public BLL_BTDJTEMP()
        { }
        #region  BasicMethod
        public bool imptmp(Model.BTDJTEMP model)
        {
            return dal.imptmp(model);
        }
        public bool UptypeID(Model.BTDJTEMP model)
        {
            return dal.UptypeID(model);
        }
        public bool UpObjectid(Model.BTDJTEMP model)
        {
            return dal.UpObjectid(model);
        }
        public bool UpAccountnum(Model.BTDJTEMP model)
        {
            return dal.UpAccountnum(model);
        }
        public int GetErrCount(string strWhere)
        {
            return dal.GetErrCount(strWhere);
        }
        public bool delete(string strWhere)
        {
            return dal.delete(strWhere);
        }
        public int exists(string strWhere)
        {
            return dal.exists(strWhere);
        }
        public DataSet GetBank(string strWhere)
        {
            return dal.GetBank(strWhere);
        }
        public bool Createjmtb(string strWhere)
        {
            return dal.Createjmtb(strWhere);
        }
        #endregion  BasicMethod
    }
}
