using System;
using Dapper;

namespace CMS.Model
{
    /// <summary>
	/// 实体-Sys_User
	/// </summary>
    [Table("Sys_User")]
    public partial class Sys_User : ModelBase
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
        /// <summary>
        ///删除标记
        /// <summary>
        public string DeleteFlag { get; set; }
    }
}
