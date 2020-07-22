using CMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Web;
using AutoMapper;
using CMS.DAL;
using CMS.Model;

namespace CMS.Web.Areas.Cms.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class Sys_UserController : BaseController
    {
        private Sys_UserBLL bll;

        public Sys_UserController(Sys_UserBLL Bll)
        {
            bll = Bll;
        }

        public ActionResult Index()
        {
            return View();
        }

        //获取分页数据
        [HttpPost]
        public JsonResult List()
        {
            LayTable result = new LayTable();//layui表格返回数据格式
            try
            {
                int page = int.Parse(Request.Params["page"]);//当前页码
                int limit = int.Parse(Request.Params["limit"]);//每页数量
                string field = Request.Params["field"];//排序字段名
                string order = Request.Params["order"];//排序方式：desc, asc, null(空对象，默认排序)

                //参数
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string[] par = { };

                foreach (string item in par)
                {
                    if (!string.IsNullOrWhiteSpace(Request.Params[item]))
                    {
                        dic.Add(item, Request.Params[item]);
                    }
                }

                var count = 0;
                var list = bll.PageList(page, limit, dic, field, order, out count);

                result.data = list;
                result.count = count;
            }
            catch (Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            return Json(result);
        }
    }
}