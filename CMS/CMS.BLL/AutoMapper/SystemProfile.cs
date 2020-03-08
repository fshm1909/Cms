using AutoMapper;
using CMS.Model;
using CMS.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<Sys_User, Sys_User_Out>();
            CreateMap<Sys_User_In, Sys_User>();
        }
    }
}
