/************************************************************
 * 项目名称：YYBDAP.BLL
 * 项目描述：
 * 类名称：UserService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.BLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 21:22:49
 * 更新时间：2017/7/7 21:22:49
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using Framework.Common.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.EFDAL;
using YYBDAP.IBLL;
using YYBDAP.IDAL;
using YYBDAP.Model;

namespace YYBDAP.BLL
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public partial class UserService : BaseService<User>, IUserService
    {
        public UserService() : base(RepositoryFactory.UserRepository)
        {
            
        }

        public bool Exist(int userId)
        {
            return this.CurrentRepository.Exist(u => u.UserId == userId);
        }

        public bool Exist(string userName)
        {
            return this.CurrentRepository.Exist(u => u.UserName == userName);
        }

        public User Find(int userId)
        {
            return this.CurrentRepository.Find(u => u.UserId == userId);
        }

        public User Find(string userName)
        {
            return this.CurrentRepository.Find(u => u.UserName == userName);
        }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            bool _isAsc = true;
            string _orderName = string.Empty;
            switch (order)//0-ID升序（默认），1ID降序，2注册时间升序，3注册时间降序，4登录时间升序，5登录时间降序
            {
                case 0:
                    _isAsc = true;
                    _orderName = "UserId";
                    break;
                case 1:
                    _isAsc = false;
                    _orderName = "UserId";
                    break;
                case 2:
                    _isAsc = true;
                    _orderName = "RegistrationTime";
                    break;
                case 3:
                    _isAsc = false;
                    _orderName = "RegistrationTime";
                    break;
                case 4:
                    _isAsc = true;
                    _orderName = "LastLoginTime";
                    break;
                case 5:
                    _isAsc = false;
                    _orderName = "LastLoginTime";
                    break;
                default:
                    _isAsc = true;
                    _orderName = "UserId";
                    break;
            }
            return this.CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, exp => true, _orderName, _isAsc);
        }

        /// <summary>
        /// 用户验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public User Verification(string userName, string userPwd)
        {
            //userPwd = SecurityEncrypt.DesEncrypt(userPwd);
            return this.CurrentRepository.Find(u => u.UserName == userName && u.Password == userPwd);
        }
    }
}
