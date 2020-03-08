using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model.Dto
{
    public class Sys_User_Out
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        ///用户名
        /// <summary>
        public string UserName { get; set; }
        /// <summary>
        ///密码
        /// <summary>
        public string Pwd { get; set; }
        /// <summary>
        ///添加人
        /// <summary>
        public string AddUser { get; set; }
        /// <summary>
        ///添加时间
        /// <summary>
        public string AddTime { get; set; }
    }
}
