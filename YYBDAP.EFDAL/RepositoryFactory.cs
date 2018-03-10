/************************************************************
 * 项目名称：YYBDAP.EFDAL
 * 项目描述：
 * 类名称：RepositoryFactory
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.EFDAL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 21:01:33
 * 更新时间：2017/7/7 21:01:33
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.IDAL;

namespace YYBDAP.EFDAL
{
    /// <summary>
    /// 仓储实例工厂
    /// </summary>
    public partial class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储实例
        /// </summary>
        public static IUserRepository UserRepository { get { return new UserRepository(); } }

        /// <summary>
        /// 角色仓储实例
        /// </summary>
        public static IRoleRepository RoleRepository { get { return new RoleRepository(); } }

        /// <summary>
        /// 菜单仓储实例
        /// </summary>
        public static IMenuRepository MenuRepository { get { return new MenuRepository(); } }

        /// <summary>
        /// 用户角色关系仓储实例
        /// </summary>
        public static IUserRoleRelationRepository UserRoleRelationRepository { get { return new UserRoleRelationRepository(); } }
    }
}
