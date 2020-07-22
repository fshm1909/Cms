using CMS.Model;
using CMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CMS.BLL
{
    public class Sys_UserBLL : BaseBll<Sys_User>
    {
        //调用父类构造函数
        public Sys_UserBLL(IMapper mapper, ICommonDAL<Sys_User> CommonDAL) : base(mapper, CommonDAL) { }
        
        #region 查

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageNumber">当前页码</param>
        /// <param name="rowsPerPage">每页数量</param>
        /// <param name="dic_conditions">查询参数</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序规则</param>
        /// <param name="count">查询到的数量</param>
        /// <returns></returns>
        public IEnumerable<dynamic> PageListDynamic(int pageNumber, int rowsPerPage, Dictionary<string, string> dic_conditions, string field, string order, out int count)
        {
            string sql = "select * from Sys_User ";

            #region 参数查询

            string where = " WHERE DeleteFlag=0";

            //数据库参数
            Dictionary<string, object> dic = new Dictionary<string, object>();

            //发票抬头
            if (dic_conditions.ContainsKey("fapiaoName"))
            {
                dic.Add("@fapiaoName", dic_conditions["fapiaoName"]);
                where += " AND fapiaoName=@fapiaoName ";
            }

            //联系地址
            if (dic_conditions.ContainsKey("linkaddress"))
            {
                dic.Add("@linkaddress", dic_conditions["linkaddress"]);
                where += " AND linkaddress LIKE '%'+@linkaddress+'%' ";
            }

            //联系电话
            if (dic_conditions.ContainsKey("linktel"))
            {
                dic.Add("@linktel", dic_conditions["linktel"]);
                where += " AND linktel LIKE '%'+@linktel+'%' ";
            }

            //申请理由
            if (dic_conditions.ContainsKey("reason"))
            {
                dic.Add("@reason", dic_conditions["reason"]);
                where += " AND reason LIKE '%'+@reason+'%' ";
            }

            #endregion

            #region 排序

            //排序sql语句拼接
            string orderby = " ID DESC ";//默认排序
            if (!string.IsNullOrWhiteSpace(field))
            {
                orderby = string.Format("{0} {1}", field, string.IsNullOrWhiteSpace(order) ? "DESC" : order);
            }

            #endregion

            var list = DAL.GetDynamicPaged(pageNumber, rowsPerPage, orderby, sql + where, dic);
            count = DAL.RecordCount(sql + where, dic);

            return list;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageNumber">当前页码</param>
        /// <param name="rowsPerPage">每页数量</param>
        /// <param name="dic_conditions">查询参数</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序规则</param>
        /// <param name="count">查询到的数量</param>
        /// <returns></returns>
        public IEnumerable<Sys_User_Out> PageList(int pageNumber, int rowsPerPage, Dictionary<string, string> dic_conditions, string field, string order, out int count)
        {
            #region 参数查询

            string where = " WHERE DeleteFlag=0";

            //数据库参数
            Dictionary<string, object> dic = new Dictionary<string, object>();

            //发票抬头
            if (dic_conditions.ContainsKey("fapiaoName"))
            {
                dic.Add("@fapiaoName", dic_conditions["fapiaoName"]);
                where += " AND fapiaoName=@fapiaoName ";
            }

            //联系地址
            if (dic_conditions.ContainsKey("linkaddress"))
            {
                dic.Add("@linkaddress", dic_conditions["linkaddress"]);
                where += " AND linkaddress LIKE '%'+@linkaddress+'%' ";
            }

            //联系电话
            if (dic_conditions.ContainsKey("linktel"))
            {
                dic.Add("@linktel", dic_conditions["linktel"]);
                where += " AND linktel LIKE '%'+@linktel+'%' ";
            }

            //申请理由
            if (dic_conditions.ContainsKey("reason"))
            {
                dic.Add("@reason", dic_conditions["reason"]);
                where += " AND reason LIKE '%'+@reason+'%' ";
            }

            #endregion

            #region 排序

            //排序sql语句拼接
            string orderby = " ID DESC ";//默认排序
            if (!string.IsNullOrWhiteSpace(field))
            {
                orderby = string.Format("{0} {1}", field, string.IsNullOrWhiteSpace(order) ? "DESC" : order);
            }

            #endregion

            var list = DAL.GetListPaged(pageNumber, rowsPerPage, where, orderby, dic);
            count = DAL.RecordCount(where, dic);

            return Mapper.Map<IEnumerable<Sys_User_Out>>(list); ;
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Sys_User_In model)
        {
            var dbtran = DAL.BeginTransaction();//开启事务
            try
            {
                var entity = Mapper.Map<Sys_User>(model);

                int? ID = DAL.Insert(entity, dbtran);

                dbtran.Commit();//提交事务
                return 1;
            }
            catch (Exception ee)
            {
                dbtran.Rollback();//事务回滚
                return 0;
            }
            finally
            {
                dbtran.Dispose();//释放事务资源
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(Sys_User_In model)
        {
            var dbtran = DAL.BeginTransaction();
            try
            {
                var entity = DAL.Get(model.ID, dbtran);

                //Mapper.Map<Sys_User_In, Sys_User>(model, entity);//把model数据转移到entity

                DAL.Update(entity, dbtran);

                dbtran.Commit();//提交事务

                return 1;
            }
            catch (Exception ee)
            {
                dbtran.Rollback();//事务回滚
                return 0;
            }
            finally
            {
                dbtran.Dispose();//释放事务资源
            }
        }

        #endregion

    }
}
