using Framework.Common.Encryption;
using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.BLL;
using YYBDAP.IBLL;
using YYBDAP.Web.Portal.App_Code;
using YYBDAP.Web.Portal.Controllers;

namespace YYBDAP.Web.Portal.Areas.Manage.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService = null;
        //public UserController()
        //{
        //    this.userService = new UserService();
        //}
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: Manage/User
        public ActionResult Index()
        {
            List<YYBDAP.Model.User> list = userService.FindList(u => true).ToList();
            return View(list);
        }

        [AllowAnonymous]
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateUser(YYBDAP.Model.User user)
        {
            return View();
        }

        [AllowAnonymous]
        public void DoCreate()
        {
            YYBDAP.Model.User u = new Model.User();
            u.UserName = "john";
            u.DisplayName = "管理员";
            u.Description = "超级管理员";
            u.Password = SecurityEncrypt.DesEncrypt("123456");
            u.EMail = "1236@qq.com";
            u.RegistrationTime = DateTime.Now;
            u.LastLoginTime = DateTime.Now;
            u.LastLoginIP = "127.0.0.1";
            u.Status = 0;
            userService.Add(u);
        }

        [AllowAnonymous]
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePwd()
        {
            return View();
        }
    }
}