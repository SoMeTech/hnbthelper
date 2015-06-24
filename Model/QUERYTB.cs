using System;
namespace Model
{
    /// <summary>
    /// JM:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class QUERYTB
    {
        public QUERYTB()
        { }
        #region Model
        private string _queryid;
        /// <summary>
        /// 
        /// </summary>
        public string queryid
        {
            set { _queryid = value; }
            get { return _queryid; }
        }
        #endregion Model
    }
}
