using System.Data;
namespace BLL
{
    /// <summary>
    /// BASEOBJECT
    /// </summary>
    public partial class BLL_BASEOBJECT
    {
        private readonly DAL.DAL_BASEOBJECT dal = new DAL.DAL_BASEOBJECT();
        public BLL_BASEOBJECT()
        { }
        #region  BasicMethod
        public  DataSet getquery(string strWhere)
        {
            return dal.getquery(strWhere);
            }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// 
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public bool Updatesfz(Model.BASEOBJECT model)
        {
            return dal.Updatesfz(model);
        }
        public bool Updatexm(Model.BASEOBJECT model)
        {
            return dal.Updatexm(model);
        }
        public bool UpdateHOMEADDRESS(Model.BASEOBJECT model)
        {
            return dal.UpdateHOMEADDRESS(model);
        }
        public DataSet GetBasic(string strWhere)
        {
            return dal.GetBasic(strWhere);
        }
        public DataSet ExptoExcelBasic(string strWhere)
        {
            return dal.ExptoExcelBasic(strWhere);
        }
        public DataSet GetZbmj(string strWhere)
        {
            return dal.GetZbmj(strWhere);
        }
        public bool UP15to18(string strWhere)
        {
            return dal.UP15to18(strWhere);
        }
        public bool JM(string strWhere)
        {
            return dal.JM(strWhere);
        }
        public DataSet GetByCardTemp(string strWhere)
        {
            return dal.GetByCardTemp(strWhere);
        }
        public bool DelQuery(string strWhere)
        {
            return dal.DelQuery(strWhere);
        }
        public DataSet GetByYhzhTemp(string strWhere)
        {
            return dal.GetByYhzhTemp(strWhere);
        }
        public DataSet ExpBasic(string strWhere)
        {
            return dal.ExpBasic(strWhere);
        }
        public DataSet CNM(string strWhere)
        {
            return dal.CNM(strWhere);
        }
        #endregion  BasicMethod
    }
}
