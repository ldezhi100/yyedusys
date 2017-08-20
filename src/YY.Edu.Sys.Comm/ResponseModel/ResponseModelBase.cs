using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YY.Edu.Sys.Comm.ResponseModel
{
    public class ResponseModelBase
    {

        /// <summary>
        /// 是否失败
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Msg { get; set; }

        public static ResponseModelBase Success()
        {
            return Res[ResponseModelErrorEnum.Success];
        }

        public static ResponseModelBase GetRes(ResponseModelErrorEnum resType)
        {

            if (Res == null || !Res.ContainsKey(resType))
                return Res[ResponseModelErrorEnum.SystemError];

            return Res[resType];

        }

        private static Dictionary<ResponseModelErrorEnum, ResponseModelBase> Res = new Dictionary<ResponseModelErrorEnum, ResponseModelBase>()
        {
            { ResponseModelErrorEnum.Success , new ResponseModelBase() {  Error = false, Code = 1001, Msg = "成功"} },
            { ResponseModelErrorEnum.SystemError , new ResponseModelBase() {  Error = true, Code = 1000, Msg = "系统错误"} },
        };


    }
}