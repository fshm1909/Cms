using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Sys_Menu_In
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int? PID { get; set; }
        /// <summary>
        ///菜单名称
        /// <summary>
        public string Name { get; set; }
        /// <summary>
        ///菜单所在项目区域
        /// <summary>
        public string Area { get; set; }
        /// <summary>
        ///菜单控制器
        /// <summary>
        public string Controllers { get; set; }
        /// <summary>
        ///菜单控制器方法
        /// <summary>
        public string Action { get; set; }
        /// <summary>
        ///图标
        /// <summary>
        public string Icon { get; set; }
        /// <summary>
        ///排序号
        /// <summary>
        public int? Sort { get; set; }
        /// <summary>
        ///添加人
        /// <summary>
        public string AddUser { get; set; }
    }
}
