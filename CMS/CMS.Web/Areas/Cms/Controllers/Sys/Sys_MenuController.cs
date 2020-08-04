using CMS.BLL;
using CMS.Common;
using CMS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Cms.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class Sys_MenuController : BaseController
    {
        private Sys_MenuBLL bll;

        public Sys_MenuController(Sys_MenuBLL Bll)
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

        //添加修改视图
        public ActionResult AddOrEdit(int ID = 0, int PID = 0)
        {
            Sys_Menu_Out model = null;

            if (ID > 0)
            {
                model = bll.Get<Sys_Menu_Out>(ID);
            }
            else
            {
                model = new Sys_Menu_Out();
                model.PID = PID;
            }

            return View(model);
        }

        //添加
        [HttpPost]
        public JsonResult GetMenu()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.Success = true;
                response.Message = "添加成功";
                response.Data = bll.GetMenu();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        //添加
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Add(Sys_Menu_In model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (model.PID == null) { model.PID = 0; }
                int result = bll.Add(model);
                if (result == 1)
                {
                    response.Success = true;
                    response.Message = "添加成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "添加失败";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        //修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Edit(Sys_Menu_In model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (model.PID == null) { model.PID = 0; }
                int result = bll.Edit(model);
                if (result == 1)
                {
                    response.Success = true;
                    response.Message = "修改成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "修改失败";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        //删除
        [HttpPost]
        public JsonResult Delete(string IdList)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (bll.DeleteList(IdList) > 0)
                {
                    response.Success = true;
                    response.Message = "删除成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "删除失败";
                }
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