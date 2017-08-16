using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Web.Http.Cors;

namespace YY.Edu.Sys.Api.Controllers
{

    /// <summary>
    /// 路由前缀  
    /// 访问 http://localhost:53262/api/city 默认请求无参Get方法
    /// 访问 http://localhost:53262/api/city/1 请求一个参数的Get方法
    /// 参考restful api 设计原则，资源的概念 http://www.ruanyifeng.com/blog/2014/05/restful_api.html
    /// </summary>
    [RoutePrefix("api/City")]
    //[EnableCors(origins: "http://localhost:37315/", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class CityController : ApiController
    {
        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            //传参 http://www.cnblogs.com/landeanfen/p/5337072.html
            //dynamic

            //返回值 http://www.cnblogs.com/landeanfen/p/5501487.html
            //1 return Json<obj>;
            //2 return Ok<obj>;
            //3 return NotFound<obj>;
            //4 return Content<HttpStatusCode.OK,obj>;
            //5 return BadRequest(); 返回400错误
            var query = Helper.DapperHelper.Instance.Query<Models.City>("select * from city where 1=1");
            return Ok(query);
        }

        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            //查询
            var query = Helper.DapperHelper.Instance.Query<Models.City>("select * from city where CityID=@id", new { Id = 1 });
            return Ok(query);
            //return Json(query.ToString());
        }

        [HttpPost]
        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        [HttpPost]
        public IHttpActionResult Add(Models.City city)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //单条添加
            var result = Helper.DapperHelper.Instance.Execute("Insert into city values (@cityname)",
                                   new { CityName = city.CityName });

            if (result > 0)
            {
                return Ok(new { error = false, code = "1000", message = "添加成功" });
            }
            else
            {
                return Content(HttpStatusCode.OK, new { error = true, code = "1001", message = "添加失败" });
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}