/************************************************************
 * 项目名称：YYBDAP.EFDAL
 * 项目描述：
 * 类名称：BaseRepository
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.EFDAL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 20:42:59
 * 更新时间：2017/7/7 20:42:59
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.IDAL;

namespace YYBDAP.EFDAL
{
    /// <summary>
    /// 仓储基础
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EFDbContext dbContext = EFDbContextFactory.GetCurrentContext();
        public T Add(T entity)
        {
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Count(predicate);
        }

        public bool Delete(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return dbContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return dbContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = dbContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 集合排序
        /// </summary>
        /// <param name="source">需要排序的集合</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>排序后的集合</returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc = true)
        {
            if (null == source) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (null == _property) throw new ArgumentNullException("propertyName", "属性不能为空");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExp = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExp);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc = true)
        {
            var _list = dbContext.Set<T>().Where<T>(whereLambda);
            _list = OrderBy(_list, orderName, isAsc);
            return _list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc = true)
        {
            var _list = dbContext.Set<T>().Where<T>(whereLambda);
            totalRecord = _list.Count();
            _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        public bool Update(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
