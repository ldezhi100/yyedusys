using System;
namespace YY.Edu.Sys.Api.Models
{
	/// <summary>
	/// VenueInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VenueInfo
	{
		public VenueInfo()
		{}
		#region Model
		private int _vinfoid;
		private string _introduce;
		private string _businesstime;
		private DateTime? _addtime= DateTime.Now;
		private int? _adduserid;
		private DateTime? _modifytime;
		private int? _modifyuserid;
		/// <summary>
		/// 
		/// </summary>
		public int VInfoID
		{
			set{ _vinfoid=value;}
			get{return _vinfoid;}
		}
		/// <summary>
		/// 场地介绍
		/// </summary>
		public string Introduce
		{
			set{ _introduce=value;}
			get{return _introduce;}
		}
		/// <summary>
		/// 营业时间介绍
		/// </summary>
		public string BusinessTime
		{
			set{ _businesstime=value;}
			get{return _businesstime;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人ID
		/// </summary>
		public int? AddUserID
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 修改人ID
		/// </summary>
		public int? ModifyUserID
		{
			set{ _modifyuserid=value;}
			get{return _modifyuserid;}
		}
		#endregion Model

	}
}

