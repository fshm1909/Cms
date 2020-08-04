using AutoMapper;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web
{
    /// <summary>
    /// AutoMapper映射配置文件（创建映射关系）
    /// </summary>
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Sys_User, Sys_User_Out>();
            CreateMap<Sys_User_In, Sys_User>();

            CreateMap<Sys_Menu, Sys_Menu_Out>();
            CreateMap<Sys_Menu, Sys_Menu_OutNav>();
            CreateMap<Sys_Menu_In, Sys_Menu>();
        }
    }
}