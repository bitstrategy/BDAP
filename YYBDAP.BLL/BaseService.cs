﻿/************************************************************
 * 项目名称：YYBDAP.BLL
 * 项目描述：
 * 类名称：BaseService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.BLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 21:19:00
 * 更新时间：2017/7/7 21:19:00
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.IBLL;
using YYBDAP.IDAL;

namespace YYBDAP.BLL
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public partial class BaseService<T> : IBaseService<T> where T : class
    {
        /// <summary>
        /// 当前调用仓储
        /// </summary>
        protected IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(IBaseRepository<T> currentRepository)
        {
            this.CurrentRepository = currentRepository;
        }

        public T Add(T entity)
        {
            return this.CurrentRepository.Add(entity);
        }

        public bool Delete(T entity)
        {
            return this.CurrentRepository.Delete(entity);
        }

        public bool Update(T entity)
        {
            return this.CurrentRepository.Update(entity);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentRepository.FindList(whereLambda);
        }
    }
}
