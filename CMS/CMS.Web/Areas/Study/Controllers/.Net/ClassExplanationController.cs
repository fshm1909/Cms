using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Study.Controllers
{
    /// <summary>
    /// 类的详解
    /// </summary>
    public class ClassExplanationController : BaseController
    {
        public ActionResult Index()
        {
            //构造函数可以作为【对象初始化器】，直接初始化对象的可访问字段或属性。在中括号中对对象的字段进行赋值初始化。
            //体会：如果把字段设置成只读，则无法在对象初始化器中赋值，这是可以使用重载构造函数来初始化
            ClassExplanation_Test1 Text1 = new ClassExplanation_Test1 { _a="" };//无参构造函数可以直接省略空括号
            ClassExplanation_Test1 Text12 = new ClassExplanation_Test1("a") { _b = "" };
            //ClassExplanation_Test1 Text13 = new ClassExplanation_Test1("a") { _b = "" , _c=1};
            ClassExplanation_Test1._c2 = "123123";
            ClassExplanation_Test1._c2 = "123123";
            IList<int> list = new List<int> { 1, 2, 3 };

            string S=Text1[0];
            return View();
        }
    }
}