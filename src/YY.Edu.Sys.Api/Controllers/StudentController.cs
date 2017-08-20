using Dapper;
using DapperExtensions;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YY.Edu.Sys.Comm.Helper;

namespace YY.Edu.Sys.Api.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {

        private static readonly ILog logs = Comm.Helper.LogHelper.GetInstance();

        // GET: api/Student
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public IHttpActionResult Create(YY.Edu.Sys.Models.Student student)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {

                var result = Comm.Helper.DapperHelper.Instance.Insert(student);

                if (result > 0)
                {
                    return Ok(Comm.ResponseModel.ResponseModelBase.Success());
                }
                else
                {
                    return Content(HttpStatusCode.OK, Comm.ResponseModel.ResponseModelBase.GetRes(Comm.ResponseModel.ResponseModelErrorEnum.SystemError));
                }

            }
            catch (Exception ex)
            {
                logs.Error("学生信息添加失败", ex);
                return BadRequest();
            }
        }


        [HttpPost]
        public IHttpActionResult Edit(YY.Edu.Sys.Models.Student student)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                //Models.VenueInfo venueInfo = Comm.Helper.DapperHelper.Instance.Get<Models.VenueInfo>(cityId);

                var result = Comm.Helper.DapperHelper.Instance.Update(student);

                if (result)
                {
                    return Ok(Comm.ResponseModel.ResponseModelBase.Success());
                }
                else
                {
                    return Content(HttpStatusCode.OK, Comm.ResponseModel.ResponseModelBase.GetRes(Comm.ResponseModel.ResponseModelErrorEnum.SystemError));
                }
            }
            catch (Exception ex)
            {
                logs.Error("场馆信息编辑失败", ex);
                return BadRequest();
            }

        }


        [HttpGet]
        public IHttpActionResult Page4Venue()
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();

                System.Web.HttpContextBase context = (System.Web.HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                System.Web.HttpRequestBase request = context.Request;//定义传统request对象
                string UserName = Comm.Helper.ParamHelper<string>.GetParam(request["UserName"], "");
                string ParentMobile = Comm.Helper.ParamHelper<string>.GetParam(request["ParentMobile"], "");
                string FullName = Comm.Helper.ParamHelper<string>.GetParam(request["FullName"], "");
                string ParentFullName = Comm.Helper.ParamHelper<string>.GetParam(request["ParentFullName"], "");
                int start = Comm.Helper.ParamHelper<int>.GetParam(request["start"], 0);
                start += 1;//adminlte 加载的datatable起始页为0
                int length = Comm.Helper.ParamHelper<int>.GetParam(request["length"], 0);
                int venueId = Comm.Helper.ParamHelper<int>.GetParam(request["venueId"], 0);

                if (venueId <= 0 || start < 0 || length <= 0)
                    return BadRequest();

                PageCriteria criteria = new PageCriteria();
                criteria.Condition = "1=1";

                criteria.Condition += string.Format(" and v.VenueID = {0}", venueId);

                if (!string.IsNullOrEmpty(UserName))
                    criteria.Condition += string.Format(" and s.UserName = '{0}'", UserName);
                if (!string.IsNullOrEmpty(ParentMobile))
                    criteria.Condition += string.Format(" and s.ParentMobile = '{0}'", ParentMobile);
                if (!string.IsNullOrEmpty(FullName))
                    criteria.Condition += string.Format(" and s.FullName like '%{0}%'", FullName);
                if (!string.IsNullOrEmpty(ParentFullName))
                    criteria.Condition += string.Format(" and s.ParentFullName like '%{0}%'", ParentFullName);

                criteria.CurrentPage = start;
                criteria.Fields = "s.StudentID,s.UserName,s.[Address],s.HeadUrl,s.Mobile,s.FullName,s.ParentFullName,s.ParentMobile,v.VenueName,v.LinkMan,v.LinkManMobile";
                criteria.PageSize = length;
                criteria.TableName = "Student as s join Student_Venue as sv on s.StudentID=sv.StudentID join Venue as v on sv.VenueID=v.VenueID";
                criteria.PrimaryKey = "s.StudentID";

                var r = Comm.Helper.DapperHelper.GetPageData<Models.QueryModel.StudentQuery>(criteria);

                return Ok(new Comm.ResponseModel.ResponseModel4Page<Models.QueryModel.StudentQuery>()
                {
                    data = r.Items,
                    recordsFiltered = r.TotalNum,
                    recordsTotal = r.TotalNum,
                });

            }
            catch (Exception ex)
            {
                logs.Error("学生查询失败", ex);
                return BadRequest();
            }
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {

        }
    }
}
