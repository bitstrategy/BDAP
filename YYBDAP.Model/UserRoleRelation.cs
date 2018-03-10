/************************************************************
 * 项目名称：YYBDAP.Model
 * 项目描述：
 * 类名称：UserRoleRelation
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.Model
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:23:34
 * 更新时间：2017/7/7 20:23:34
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
    /// 用户角色关系
    /// </summary>
    public partial class UserRoleRelation
    {
        /// <summary>
        /// 关系ID
        /// </summary>
        [Key]
        [Display(Name = "关系ID")]
        public int RelationId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required(ErrorMessage = "必要项")]
        [Display(Name = "用户ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Required(ErrorMessage = "必要项")]
        [Display(Name = "角色ID")]
        public int RoleId { get; set; }

        public UserRoleRelation()
        {

        }
    }
}
