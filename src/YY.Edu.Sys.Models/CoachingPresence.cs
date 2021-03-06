﻿using System;
namespace YY.Edu.Sys.Models
{
	/// <summary>
	/// CoachingPresence:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CoachingPresence
	{
		public CoachingPresence()
		{}
		#region Model
		private int _fcid;
		private string _title;
		private int? _fctype;
		private string _fcurl;
		private DateTime? _addtime;
		private int? _coachid;
		private int? _fcstate=0;
		private int? _venueid;
		/// <summary>
		/// 教师风采主键ID
		/// </summary>
		public int FCID
		{
			set{ _fcid=value;}
			get{return _fcid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 类型1图片2视频
		/// </summary>
		public int? FCType
		{
			set{ _fctype=value;}
			get{return _fctype;}
		}
		/// <summary>
		/// 图片或视频地址
		/// </summary>
		public string FCUrl
		{
			set{ _fcurl=value;}
			get{return _fcurl;}
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
		/// 教练ID
		/// </summary>
		public int? CoachID
		{
			set{ _coachid=value;}
			get{return _coachid;}
		}
		/// <summary>
		/// 0，无效，1有效，2删除
		/// </summary>
		public int? FCState
		{
			set{ _fcstate=value;}
			get{return _fcstate;}
		}
		/// <summary>
		/// 场馆ID
		/// </summary>
		public int? VenueID
		{
			set{ _venueid=value;}
			get{return _venueid;}
		}
		#endregion Model

	}
}

