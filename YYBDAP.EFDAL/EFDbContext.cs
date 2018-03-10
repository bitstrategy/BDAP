/************************************************************
 * 项目名称：YYBDAP.EFDAL
 * 项目描述：
 * 类名称：EFDbContext
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.EFDAL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:38:17
 * 更新时间：2017/7/7 20:38:17
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.Model;

namespace YYBDAP.EFDAL
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public partial class EFDbContext : DbContext
    {
        /// <summary>
        /// 用户集合
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 角色集合
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 菜单集合
        /// </summary>
        public DbSet<Menu> Menus { get; set; }

        /// <summary>
        /// 用户角色关系集合
        /// </summary>
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }

        /// <summary>
        /// 菜单角色关系集合
        /// </summary>
        public DbSet<MenuRoleRelation> MenuRoleRelations { get; set; }

        public EFDbContext() : base("Portal_DB")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//去掉表名复数
            base.OnModelCreating(modelBuilder);
        }
    }
}
