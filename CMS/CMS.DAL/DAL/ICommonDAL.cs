using CMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public interface ICommonDAL<TEntity> where TEntity : ModelBase, new()
    {
        IDbTransaction BeginTransaction();
        int? Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new();

        int Delete(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        int Delete(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        int Delete<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new();
        int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        int DeleteList(string whereConditions, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));

        int Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new();

        TEntity Get(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        T Get<T>(object id, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : ModelBase, new();
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(string whereConditions, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        IEnumerable<dynamic> GetDynamicPaged(int pageNumber, int rowsPerPage, string sql, string orderby, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        int RecordCount(string where = "", object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        int RecordQueryCount(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        int RecordQueryCount2(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        IEnumerable<TEntity> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?)) where T : class, new();
        dynamic QuerySingleOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        TEntity QueryFirstOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        dynamic QueryFirstOrDefaultDynamic(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
