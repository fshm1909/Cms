﻿using System.Web.Mvc;

namespace CMS.Web.Areas.Study
{
    public class StudyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Study";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName + "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { $"CMS.Web.Areas.{AreaName}.Controllers" }
            );
        }
    }
}