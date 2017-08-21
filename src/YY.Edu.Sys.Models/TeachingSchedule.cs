﻿using System;
namespace YY.Edu.Sys.Models
{
	/// <summary>
	/// TeachingSchedule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeachingSchedule
	{
		public TeachingSchedule()
		{}
		#region Model
		private int _pkid;
		private int? _venueid;
		private int? _campusid;
		private int? _coachid;
		private string _title;
		private DateTime? _curriculumdate;
		private string _curriculumbegintime;
		private string _curriculumendtime;
		private DateTime? _addtime= DateTime.Now;
		private decimal? _price;
		private decimal? _coachprice;
		private int? _state=1;
		private int? _pktype=1;
		private string _info;
        /// <summary>
        /// 
        /// </summary>
        /// 

        private string _venueName;
        private string _campusName;

        public string VenueName
        {
            set { _venueName = value; }
            get { return _venueName; }
        }

        public string CampusName
        {
            set { _campusName = value; }
            get { return _campusName; }
        }
        public int PKID
		{
			set{ _pkid=value;}
			get{return _pkid;}
		}
		/// <summary>
		/// 场馆ID
		/// </summary>
		public int? VenueID
		{
			set{ _venueid=value;}
			get{return _venueid;}
		}
		/// <summary>
		/// 校区ID
		/// </summary>
		public int? CampusID
		{
			set{ _campusid=value;}
			get{return _campusid;}
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
		/// 课时标题 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 课时日期
		/// </summary>
		public DateTime? CurriculumDate
		{
			set{ _curriculumdate=value;}
			get{return _curriculumdate;}
		}
		/// <summary>
		/// 课时开始时间
		/// </summary>
		public string CurriculumBeginTime
		{
			set{ _curriculumbegintime=value;}
			get{return _curriculumbegintime;}
		}
		/// <summary>
		/// 课时结束时间
		/// </summary>
		public string CurriculumEndTime
		{
			set{ _curriculumendtime=value;}
			get{return _curriculumendtime;}
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
		/// 对外学生价
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 教练价络
		/// </summary>
		public decimal? CoachPrice
		{
			set{ _coachprice=value;}
			get{return _coachprice;}
		}
		/// <summary>
		/// 1有效，2学校停课（需要判断，有没有学生预约）,3老师请假
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 1，1对1，2，1对多
		/// </summary>
		public int? PKType
		{
			set{ _pktype=value;}
			get{return _pktype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Info
		{
			set{ _info=value;}
			get{return _info;}
		}
		#endregion Model

	}
}

