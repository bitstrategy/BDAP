/************************************************************
 * 项目名称：YYBDAP.Model
 * 项目描述：
 * 类名称：User
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.Model
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:17:20
 * 更新时间：2017/7/7 20:17:20
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
    /// 用户
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [Display(Name = "用户ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "用户描述")]
        public string Description { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{1}到{0}个字符")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮箱")]
        public string EMail { get; set; }

        /// <summary>
        /// 状态
        /// <para>0正常，1锁定，2未通过邮件验证，3未通过管理员</para>
        /// </summary>
        [Display(Name = "状态")]
        public Int16 Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [Display(Name = "注册时间")]
        public DateTime RegistrationTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Display(Name = "上次登录时间")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录IP
        /// </summary>
        [Display(Name = "上次登录IP")]
        public string LastLoginIP { get; set; }

        public User()
        {

        }
    }
}
