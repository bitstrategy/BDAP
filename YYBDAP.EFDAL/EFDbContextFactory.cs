/************************************************************
 * 项目名称：YYBDAP.EFDAL
 * 项目描述：
 * 类名称：EFDbContextFactory
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.EFDAL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:35:53
 * 更新时间：2017/7/7 20:35:53
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace YYBDAP.EFDAL
{
    /// <summary>
    /// DbContext工厂
    /// </summary>
    public partial class EFDbContextFactory
    {
        /// <summary>
        /// 创建数据库上下文
        /// <para>已存在就直接取,不存在就创建,保证线程内是唯一。</para>
        /// </summary>
        /// <returns>数据库上下文对象</returns>
        public static EFDbContext GetCurrentContext()
        {
            EFDbContext dbContext = CallContext.GetData(typeof(EFDbContext).Name) as EFDbContext;
            if (null == dbContext)
            {
                dbContext = new EFDbContext();
                CallContext.SetData(typeof(EFDbContext).Name, dbContext);
            }

            return dbContext;
        }
    }
}
