using AutoMapper;
using CMS.BLL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CMS.Web
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class MapperConfig
    {
        /// <summary>
        /// 注册器
        /// </summary>
        public static void Register()
        {
            //每个AppDomain(应用程序域)只能进行一次配置（类似单例）
            //创建地图配置实例（配置映射关系，此处使用配置文件（SystemProfile）获取配置关系）
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<SystemProfile>(); });
            //创建地图实例（此处可以依赖注入创建实例）
            var mapper = config.CreateMapper();

            //使用mapper对象来进行对象转换
            //mapper.Map();

            //mapper.ProjectTo()
            //IServiceCollection
        }
    }
}