using CMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Cms.Controllers
{
    /// <summary>
    /// CMS系统首页
    /// </summary>
    public class HomeController : BaseController
    {
        private Sys_MenuBLL bll;

        public HomeController(Sys_MenuBLL Bll)
        {
            bll = Bll;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetMenu()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.Success = true;
                response.Message = "";
                response.Data = bll.GetMenu();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return Json(response, JsonRequestBehavior.DenyGet);
        }
    }
}