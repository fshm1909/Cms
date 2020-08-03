using AutoMapper;
using CMS.DAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class BaseBll<TEntity> where TEntity : ModelBase, new()
    {
        //DAL层实例
        public ICommonDAL<TEntity> DAL { get; set; }

        //mapper实例
        public IMapper Mapper { get; set; }

        public BaseBll() { }

        //public BaseBll(CommonDAL<TEntity> Dal)
        //{
        //    DAL = Dal;//依赖注入，通过构造函数上层传入实例
        //}

        //public BaseBll(IMapper mapper)
        //{
        //    Mapper = mapper;//依赖注入，通过构造函数上层传入实例
        //}

        public BaseBll(IMapper mapper, ICommonDAL<TEntity> CommonDAL)
        {
            Mapper = mapper;//依赖注入，通过构造函数上层传入实例
            DAL = CommonDAL;//依赖注入，通过构造函数上层传入实例
        }


        #region 通用的数据库方法

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            return DAL.Get(id);
        }

        public TDto Get<TDto>(int id) where TDto : class, new()
        {
            var entity = Get(id);
            return Mapper.Map<TDto>(entity);
        }

        #endregion
    }
}
