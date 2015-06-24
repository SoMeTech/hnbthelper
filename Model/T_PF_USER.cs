using System;
namespace Model
{
	/// <summary>
	/// T_PF_USER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_PF_USER
	{
		public T_PF_USER()
		{}
		#region Model
		private string _usercode;
		private string _passwrd;
		private string _username;
		private string _identify;
		private string _pfcmz;
		private string _userstate;
		private string _depid;
		private string _loginname;
		private string _phone;
		private string _hzcustid="G0001";
		private decimal? _sysopertime;
		/// <summary>
		/// 
		/// </summary>
		public string USERCODE
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PASSWRD
		{
			set{ _passwrd=value;}
			get{return _passwrd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDENTIFY
		{
			set{ _identify=value;}
			get{return _identify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PFCMZ
		{
			set{ _pfcmz=value;}
			get{return _pfcmz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERSTATE
		{
			set{ _userstate=value;}
			get{return _userstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEPID
		{
			set{ _depid=value;}
			get{return _depid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LOGINNAME
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PHONE
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HZCUSTID
		{
			set{ _hzcustid=value;}
			get{return _hzcustid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SYSOPERTIME
		{
			set{ _sysopertime=value;}
			get{return _sysopertime;}
		}
		#endregion Model
	}
}
