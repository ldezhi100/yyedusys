using DapperExtensions;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YY.Edu.Sys.Api.Controllers
{
    [RoutePrefix("api/Campus")]
    public class CampusController : ApiController
    {
        private static readonly ILog logs = Comm.Helper.LogHelper.GetInstance();

        // GET: api/Campus
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Campus/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult Create(Sys.Models.Campus campusInfo)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {

                var result = Comm.Helper.DapperHelper.Instance.Insert(campusInfo);

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

        // POST: api/Campus
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Campus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Campus/5
        public void Delete(int id)
        {
        }
    }
}
