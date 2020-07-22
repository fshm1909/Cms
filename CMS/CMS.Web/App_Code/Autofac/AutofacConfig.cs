using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using CMS.BLL;
using CMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web
{
    /// <summary>
    /// Autofac配置类
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void Register()
        {
            //容器配置实例=>进行容器的注册组件=>创建容器=>解析服务

            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            // MVC - 注册所有控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //注册AutoMapper模块
            builder.RegisterModule(new CMS.Web.AutoMapperModule());

            //创建地图配置实例（配置映射关系，此处使用配置文件（MapperProfile）获取配置关系）
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<CMS.Web.MapperProfile>(); });
            //创建mapper实例（此处可以依赖注入创建实例）
            var mapper = config.CreateMapper();
            //注册mapper实例组件
            builder.RegisterInstance(mapper);

            //注册DAL层组件和服务
            builder.RegisterGeneric(typeof(CommonDAL<>)).As(typeof(ICommonDAL<>)).InstancePerLifetimeScope(); 

            //注册Bll层
            //builder.RegisterType<Sys_UserBLL>();
            builder.RegisterAssemblyTypes(Assembly.Load("CMS.BLL"));

            //创建一个Autofac的容器
            var container = builder.Build();
            //将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}