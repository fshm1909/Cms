using System.Web.Mvc;

namespace CMS.Web.Areas.Cms
{
    public class CmsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cms";
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