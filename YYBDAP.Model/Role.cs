/************************************************************
 * 项目名称：YYBDAP.Model
 * 项目描述：
 * 类名称：Role
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.Model
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:22:39
 * 更新时间：2017/7/7 20:22:39
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
    /// 角色
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key]
        [Display(Name = "角色ID")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色说明
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, ErrorMessage = "少于{0}个字符")]
        [Display(Name = "角色说明")]
        public string Description { get; set; }

        /// <summary>
        /// 角色类型
        /// <para>0普通（普通注册用户），1特权（像VIP之类的类型），2管理（管理权限的类型）</para>
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "角色类型")]
        public int Type { get; set; }

        /// <summary>
        /// 获取角色类型中文名称
        /// </summary>
        /// <returns>角色类型中文名称</returns>
        public string TypeToString()
        {
            switch (this.Type)
            {
                case 0:
                    return "普通";
                case 1:
                    return "特权";
                case 2:
                    return "管理";
                default:
                    return "未知";
            }
        }

        public Role()
        {

        }
    }
}
