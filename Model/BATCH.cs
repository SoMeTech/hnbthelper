using System;
namespace Model
{
	/// <summary>
	/// BATCH:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BATCH
	{
		public BATCH()
		{}
		#region Model
		private decimal _batchid;
		private string _typecode;
		private string _batchname;
		/// <summary>
		/// 
		/// </summary>
		public decimal BATCHID
		{
			set{ _batchid=value;}
			get{return _batchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TYPECODE
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BATCHNAME
		{
			set{ _batchname=value;}
			get{return _batchname;}
		}
		#endregion Model
	}
}
