using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CMS.Common
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
