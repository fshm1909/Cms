//-------------------------------------------------------------------------------------
// <auto-generated>
//     此代码由 Entities.tt T4模板生成
//     生成时间 2020-08-04 18:10:06
//     对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// </auto-generated>
//-------------------------------------------------------------------------------------

using System;
using Dapper;

namespace CMS.Model
{
    /// <summary>
	/// 实体-Sys_Menu
	/// </summary>
	[Table("Sys_Menu")]
	public partial class Sys_Menu : ModelBase
	{
        [Key]
        ///
        ///主键
        ///
        public int ID { get; set; }
        ///
        ///父级ID
        ///
        public int? PID { get; set; }
        ///
        ///菜单名称
        ///
        public string Name { get; set; }
        ///
        ///菜单所在项目区域
        ///
        public string Area { get; set; }
        ///
        ///菜单控制器
        ///
        public string Controllers { get; set; }
        ///
        ///菜单控制器方法
        ///
        public string Action { get; set; }
        ///
        ///图标
        ///
        public string Icon { get; set; }
        ///
        ///排序号
        ///
        public int? Sort { get; set; }
        ///
        ///是否启用
        ///
        public bool? IsEnable { get; set; }
        ///
        ///添加人
        ///
        public string AddUser { get; set; }
        ///
        ///添加时间
        ///
        public DateTime? AddTime { get; set; }
        ///
        ///删除标记
        ///
        public bool? DeleteFlag { get; set; }
        ///
        ///删除时间
        ///
        public DateTime? DeleteTime { get; set; }
	}
}

