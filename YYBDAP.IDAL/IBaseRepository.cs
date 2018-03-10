/************************************************************
 * 项目名称：YYBDAP.IDAL
 * 项目描述：
 * 类名称：IBaseRepository
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.IDAL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:25:10
 * 更新时间：2017/7/7 20:25:10
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YYBDAP.IDAL
{
    /// <summary>
    /// 仓储常用基础操作接口
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    public partial interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>添加后的实体</returns>
        T Add(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>删除是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>更新是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>符合查询表达式的实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="whereLambda">筛选表达式</param>
        /// <returns>实体列表</returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isAsc">是否升序(默认true，升序)</param>
        /// <returns>排序后的实体列表</returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc = true);

        /// <summary>
        /// 查找实体分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isAsc">是否升序(默认true，升序)</param>
        /// <returns></returns>
        IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc = true);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>是否存在</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
