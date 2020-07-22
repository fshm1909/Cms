using System;
using System.Collections.Generic;
using System.Data;
using CMS.Common;
using CMS.Model;
using Dapper;

namespace CMS.DAL
{
    /// <summary>
    /// 封装数据库操作类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CommonDAL<TEntity> : ICommonDAL<TEntity>, IDisposable where TEntity : ModelBase, new()
    {
        #region 配置

        protected IDbConnection _dbconn;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IDbConnection DbConn
        {
            get
            {
                if (_dbconn == null || string.IsNullOrEmpty(_dbconn.ConnectionString))
                {
                    _dbconn = ConnectionHelper.GetSqlConnection();
                }
                return _dbconn;
            }
        }

        protected int? _commandTimeout = default(int?);

        //数据库等待命令执行的时间
        public int? CommandTimeout
        {
            get
            {
                return _commandTimeout;
            }
            set
            {
                _commandTimeout = value;
            }
        }

        public CommonDAL()
        {
        }

        #endregion

        #region 资源释放

        /// <summary>
        /// 用析构函数释放资源，析构函数有垃圾回收装置调用，即由系统来管理释放资源Dispose()由用户手动释放
        /// (在.NET中应该尽可能的少用析构函数释放资源。在没有析构函数的对象在垃圾处理器一次处理中从内存删除，但有析构函数的对象，需要两次，第一次调用析构函数，第二次删除对象。而且在析构函数中包含大量的释放资源代码，会降低垃圾回收器的工作效率，影响性能。所以对于包含非托管资源的对象，最好及时的调用Dispose()方法来回收资源，而不是依赖垃圾回收器。)
        /// </summary>
        //~DAL()
        //{
        //    // 为了保持代码的可读性性和可维护性,千万不要在这里写释放非托管资源的代码 
        //    // 必须以Dispose(false)方式调用,以false告诉Dispose(bool disposing)函数是从垃圾回收器在调用Finalize时调用的 
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);//释放托管和非托管资源

            //将对象从垃圾回收器链表中移除，
            //从而在垃圾回收器工作时，只释放托管资源，而不执行此对象的析构函数
            GC.SuppressFinalize(this);
        }

        private bool _IsDisposed = false; // 是否已释放资源的标志

        /// <summary>
        /// 无法被客户直接调用 
        /// 如果 disposing 是 true, 那么这个方法是被客户直接调用的,那么托管的,和非托管的资源都可以释放 
        /// 如果 disposing 是 false, 那么函数是从垃圾回收器在调用Finalize时调用的,此时不应当引用其他托管对象所以,只能释放非托管资源
        /// 参数为true表示释放所有资源，只能由使用者调用（Dispose()方法使用）;参数为false表示释放非托管资源，只能由垃圾回收器自动调用（~Repository()析构函数使用）
        /// </summary>
        /// <param name="disposing"></param>
        protected void Dispose(bool disposing)
        {
            if (!this._IsDisposed)// 如果资源未释放 这个判断主要用了防止对象被多次释放
            {
                if (disposing)
                {
                    //释放托管资源                   
                }
                //释放非托管资源
                DbConn.Dispose();
            }

            this._IsDisposed = true; // 标识此对象已释放
        }

        #endregion

        #region 数据库方法

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <returns></returns>
        public IDbTransaction BeginTransaction()
        {
            return DbConn.BeginTransaction();
        }

        #region 增

        /// <summary>
        /// 增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public int? Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new()
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Insert(entity, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Insert(entity, transaction, commandTimeout);
            }
        }


        #endregion

        #region 删

        /// <summary>
        /// 根据主键ID字段删除
        /// </summary>
        public int Delete(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Delete<TEntity>(id, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Delete<TEntity>(id, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 根据实体类型删除
        /// </summary>
        public int Delete(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Delete(entity, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Delete(entity, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 根据实体类型删除
        /// </summary>
        public int Delete<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new()
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Delete(entity, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Delete(entity, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.DeleteList<TEntity>(whereConditions, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.DeleteList<TEntity>(whereConditions, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 批量删除（带参数）
        /// </summary>
        public int DeleteList(string whereConditions, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.DeleteList<TEntity>(whereConditions, param, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.DeleteList<TEntity>(whereConditions, param, transaction, commandTimeout);
            }
        }
        #endregion

        #region 改

        /// <summary>
        /// 修改
        /// </summary>
        public int Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new()
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Update(entity, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Update(entity, transaction, commandTimeout);
            }
        }

        #endregion

        #region 查

        /// <summary>
        /// 根据主键ID获取实体
        /// </summary>
        public TEntity Get(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Get<TEntity>(id, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Get<TEntity>(id, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 根据主键ID获取实体
        /// </summary>
        public T Get<T>(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new()
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Get<T>(id, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.Get<T>(id, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        public IEnumerable<TEntity> GetList()
        {
            using (DbConn)
            {
                return DbConn.GetList<TEntity>();
            }
        }

        /// <summary>
        /// 根据条件获取集合（带参数）
        /// </summary>
        public IEnumerable<TEntity> GetList(string whereConditions, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.GetList<TEntity>(whereConditions, param, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.GetList<TEntity>(whereConditions, param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 分页查询（返回实体集合）
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="rowsPerPage">每页条数</param>
        /// <param name="conditions">where语句</param>
        /// <param name="orderby">排序语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby,
            object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.GetListPaged<TEntity>(pageNumber, rowsPerPage, conditions, orderby, param, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.GetListPaged<TEntity>(pageNumber, rowsPerPage, conditions, orderby, param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 分页查询（返回动态类型集合）
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="rowsPerPage">每页条数</param>
        /// <param name="sql">sql语句</param>
        /// <param name="orderby">排序语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetDynamicPaged(int pageNumber, int rowsPerPage, string sql, string orderby, object param = null,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            string sqlPage = string.Format(@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY {0}) AS r_num  FROM ({1}) AS t1 ) AS t2 WHERE r_num BETWEEN ({2}-1)*{3}+1 AND {2}*{3}", orderby, sql, pageNumber, rowsPerPage);

            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Query(sqlPage, param, transaction, buffered, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.Query(sqlPage, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// 根据where语句返回数量
        /// </summary>
        public int RecordCount(string where = "", object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.RecordCount<TEntity>(where, param, transaction, commandTimeout);
                }
            }
            else
            {
                return DbConn.RecordCount<TEntity>(where, param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 根据sql语句返回数量（需要优化）
        /// </summary>
        public int RecordQueryCount(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            string countKey = "r_count";
            string sqlCount = string.Format("SELECT COUNT(1) AS {0} FROM({1}) AS t1", countKey, sql);
            IDictionary<string, object> dic = null;

            if (transaction == null)
            {
                using (DbConn)
                {
                    dic = DbConn.QuerySingle(sqlCount, param, transaction, commandTimeout);
                }
            }
            else
            {
                dic = DbConn.QuerySingle(sqlCount, param, transaction, commandTimeout);
            }
            return Convert.ToInt32(dic[countKey]);
        }


        /// <summary>
        /// 根据sql语句返回数量（测试）
        /// </summary>
        public int RecordQueryCount2(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            string sqlCount = string.Format("SELECT COUNT(1) FROM({0}) AS t1", sql);
            object count = null;

            if (transaction == null)
            {
                using (DbConn)
                {
                    count = DbConn.ExecuteScalar(sqlCount, param, transaction, commandTimeout);
                }
            }
            else
            {
                count = DbConn.ExecuteScalar(sqlCount, param, transaction, commandTimeout);
            }
            return Convert.ToInt32(count);
        }

        /// <summary>
        /// 根据sql语句返回实体集合
        /// </summary>
        public IEnumerable<TEntity> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true,
            int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Query<TEntity>(sql, param, transaction, buffered, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.Query<TEntity>(sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// 根据sql语句返回实体集合（自定义泛型）
        /// </summary>
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true,
            int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?)) where T : class, new()
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// 根据sql语句返回动态类型
        /// </summary>
        public dynamic QuerySingleOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.QuerySingleOrDefault(sql, param, transaction, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.QuerySingleOrDefault(sql, param, transaction, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// 根据sql语句返回第一条实体数据
        /// </summary>
        public TEntity QueryFirstOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.QueryFirstOrDefault<TEntity>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.QueryFirstOrDefault<TEntity>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// 根据sql语句返回第一条动态类型数据
        /// </summary>
        public dynamic QueryFirstOrDefaultDynamic(string sql, object param = null, IDbTransaction transaction = null,            int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.QueryFirstOrDefault(sql, param, transaction, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.QueryFirstOrDefault(sql, param, transaction, commandTimeout, commandType);
            }
        }

        #endregion

        #region 特殊

        /// <summary>
        /// 执行sql语句
        /// </summary>
        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
            {
                using (DbConn)
                {
                    return DbConn.Execute(sql, param, transaction, commandTimeout, commandType);
                }
            }
            else
            {
                return DbConn.Execute(sql, param, transaction, commandTimeout, commandType);
            }
        }

        #endregion

        #endregion
    }
}
