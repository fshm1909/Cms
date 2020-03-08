using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web
{
    /// <summary>
    /// layui动态表格返回类型
    /// </summary>
    public class LayTable
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public IEnumerable<object> data { get; set; }
    }
}