using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YY.Edu.Sys.Api.Helper
{
    public class DapperHelper
    {

        //静态只读的线程辅助对象
        static readonly object syncInstance = new object();

        private static System.Data.IDbConnection instance = null;

        /// <summary>
        /// dapper实例
        /// </summary>
        /// <returns></returns>
        public static System.Data.IDbConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                        {
                            instance = CreateInstance();
                        }
                    }
                }
                return instance;
            }
            set
            {
                instance = null;
            }
        }

        #region 初始化

        /// <summary>
        /// 创建云存储服务商实例
        /// </summary>
        /// <returns></returns>
        private static System.Data.IDbConnection CreateInstance()
        {
            // 添加
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            return connection;
        }

        #endregion
    }
}