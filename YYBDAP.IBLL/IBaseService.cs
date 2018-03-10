﻿/************************************************************
 * 项目名称：YYBDAP.IBLL
 * 项目描述：
 * 类名称：IBaseService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.IBLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 21:07:52
 * 更新时间：2017/7/7 21:07:52
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YYBDAP.IBLL
{
    /// <summary>
    /// 业务服务基础接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IBaseService<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">需要更新的实体</param>
        /// <returns>更新是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">需要删除的实体</param>
        /// <returns>删除是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="whereLambda">过滤表达式</param>
        /// <returns>实体列表</returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda);
    }
}
