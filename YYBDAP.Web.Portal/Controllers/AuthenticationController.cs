using Framework.Common.Encryption;
using Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YYBDAP.IBLL;
using YYBDAP.Model;
using YYBDAP.ViewModel;

namespace YYBDAP.Web.Portal.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        IUserService userService;

        public AuthenticationController(IUserService _userService)
        {
            userService = _userService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View(new LoginErrorViewModel());
        }

        public ActionResult Logon()
        {
            return View(new LoginFormViewModel());
        }

        [HttpPost]
        public ActionResult DoLogon(YYBDAP.ViewModel.LoginFormViewModel login)
        {
            if (null == TempData["VerificationCode"] || TempData["VerificationCode"].ToString() != login.VerificationCode.ToUpper())
            {
                login.ErrorMsg = "验证码输入错误！";
                login.VerificationCode = "";
                return View("Logon", login);
            }

            YYBDAP.Model.User user = this.userService.Verification(login.UserName, SecurityEncrypt.DesEncrypt(login.Password));
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                user.LastLoginIP = WebHelper.GetIP();
                user.LastLoginTime = DateTime.Now;
                this.userService.Update(user);
                LoginUserViewModel loginUser = new LoginUserViewModel();
                loginUser.UserId = user.UserId;
                loginUser.UserName = user.UserName;
                loginUser.Description = user.Description;
                loginUser.DisplayName = user.DisplayName;
                loginUser.Status = user.Status;
                loginUser.LastLoginIP = user.LastLoginIP;
                loginUser.LastLoginTime = user.LastLoginTime;
                loginUser.RegistrationTime = user.RegistrationTime;
                Session["LoginUserVM"] = loginUser;
                return RedirectToAction("Index", "Home");
                //return RedirectToAction("Index", "User", new { area = "Manage" });
            }
            else
            {
                login.ErrorMsg = "用户名或密码错误！";
                return View("Logon", login);
            }
        }

        [HttpPost]
        public ActionResult DoLogin(YYBDAP.Model.User loginUser)
        {
            YYBDAP.Model.User user = this.userService.Verification(loginUser.UserName, loginUser.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                user.LastLoginIP = WebHelper.GetIP();
                user.LastLoginTime = DateTime.Now;
                this.userService.Update(user);
                return RedirectToAction("Index", "User", new { area = "Manage" });
            }
            else
            {
                LoginErrorViewModel levm = new LoginErrorViewModel();
                levm.UserName = loginUser.UserName;
                levm.ErrorMsg = "用户名或密码错误！";
                return View("Login", levm);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Logon", new LoginFormViewModel());
            //return RedirectToAction("Login");
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVerificationCode()
        {
            string verificationCode = VerificationCodeHelper.CreateVerificationText(4);
            Bitmap _img = VerificationCodeHelper.CreateVerificationImage(verificationCode, 95, 30);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
    }
}