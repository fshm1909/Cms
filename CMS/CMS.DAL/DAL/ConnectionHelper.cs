using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace CMS.DAL
{
    public class ConnectionHelper
    {
        //获取配置文件中“CMS”名称的数据库连接字符串
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["CMS"].ToString();

        /// <summary>
        /// 获取SQLServer的数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            var conn = CallContext.GetData("CMSConnection") as SqlConnection;

            if (conn == null || string.IsNullOrEmpty(conn.ConnectionString))
            {
                //创建对象
                conn = new SqlConnection(ConnectionString);
                CallContext.SetData("CMSConnection", conn);
            }

            //数据库连接对象状态是关闭则打开
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }
    }
}
