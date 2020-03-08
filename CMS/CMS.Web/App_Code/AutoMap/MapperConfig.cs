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
    public class MapperConfig
    {
        public static void Register()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<SystemProfile>(); });

            var mapper = config.CreateMapper();
            //mapper.ProjectTo()
            //IServiceCollection
        }
    }
}