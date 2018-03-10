/************************************************************
 * 项目名称：YYBDAP.Model
 * 项目描述：
 * 类名称：Menu
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.Model
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/26 16:29:08
 * 更新时间：2017/7/26 16:29:08
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYBDAP.Model
{
    /// <summary>
    /// 菜单
    /// </summary>
    public partial class Menu
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Key]
        [Display(Name = "菜单ID")]
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "菜单名称")]
        public string MenuName { get; set; }

        /// <summary>
        /// 上级菜单ID
        /// </summary>
        [Display(Name = "上级菜单ID")]
        public int ParentId { get; set; }

        /// <summary>
        /// 菜单URL
        /// </summary>
        [Display(Name = "菜单URL")]
        [StringLength(2000, MinimumLength = 0, ErrorMessage = "{1}到{0}个字符")]
        public string URL { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Display(Name = "菜单图标")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "{1}到{0}个字符")]
        public string ICON { get; set; }

        /// <summary>
        /// 菜单排序键
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "菜单排序键")]
        public Int16 Order { get; set; }

        /// <summary>
        /// 是否菜单头
        /// </summary>
        [Display(Name = "是否菜单头")]
        public Int16 IsHeader { get; set; }

        public Menu()
        {

        }
    }
}
