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
        public IHttpActionResult Page4Venue(string query)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();

                Comm.RequestModel.RequestModelBase<Sys.Models.Student> oData = Newtonsoft.Json.JsonConvert.DeserializeObject<Comm.RequestModel.RequestModelBase<Sys.Models.Student>>(query);

                if (oData.SearchCondition.VenueID <= 0 || oData.PageIndex < 0 || oData.PageSize <= 0)
                    return BadRequest();

                PageCriteria criteria = new PageCriteria();
                criteria.Condition = "1=1";

                criteria.Condition += string.Format(" and v.VenueID = {0}", oData.SearchCondition.VenueID);

                if (!string.IsNullOrEmpty(oData.SearchCondition.UserName))
                    criteria.Condition += string.Format(" and s.UserName = '{0}'", oData.SearchCondition.UserName);
                if (!string.IsNullOrEmpty(oData.SearchCondition.ParentMobile))
                    criteria.Condition += string.Format(" and s.ParentMobile = '{0}'", oData.SearchCondition.ParentMobile);
                if (!string.IsNullOrEmpty(oData.SearchCondition.FullName))
                    criteria.Condition += string.Format(" and s.FullName like '%{0}%'", oData.SearchCondition.FullName);
                if (!string.IsNullOrEmpty(oData.SearchCondition.ParentFullName))
                    criteria.Condition += string.Format(" and s.ParentFullName like '%{0}%'", oData.SearchCondition.ParentFullName);

                criteria.CurrentPage = oData.PageIndex + 1;//adminlte 加载的datatable起始页为0
                criteria.Fields = "s.StudentID,s.UserName,s.[Address],s.HeadUrl,s.Mobile,s.FullName,s.ParentFullName,s.ParentMobile,v.VenueName,v.LinkMan,v.LinkManMobile";
                criteria.PageSize = oData.PageSize;
                criteria.TableName = "Student as s join Student_Venue as sv on s.StudentID=sv.StudentID join Venue as v on sv.VenueID=v.VenueID";
                criteria.PrimaryKey = "s.StudentID";

                var r = Comm.Helper.DapperHelper.GetPageData<Models.Response.StudentResponse>(criteria);

                return Ok(new Comm.ResponseModel.ResponseModel4Page<Models.Response.StudentResponse>()
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
