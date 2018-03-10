/************************************************************
 * 项目名称：YYBDAP.IBLL
 * 项目描述：
 * 类名称：IUserService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.IBLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 21:09:47
 * 更新时间：2017/7/7 21:09:47
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.Model;

namespace YYBDAP.IBLL
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public partial interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 用户验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        User Verification(string userName, string userPwd);

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>true | false</returns>
        bool Exist(string userName);

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>true | false</returns>
        bool Exist(int userId);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户对象</returns>
        User Find(string userName);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户对象</returns>
        User Find(int userId);

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="order">排序<br />0-ID升序（默认），1ID降序，2注册时间升序，3注册时间降序，4登录时间升序，5登录时间降序</param>
        /// <returns></returns>
        IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order);
    }
}
