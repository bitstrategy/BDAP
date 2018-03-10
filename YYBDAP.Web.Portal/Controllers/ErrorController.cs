using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.ViewModel;

namespace YYBDAP.Web.Portal.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        /// <summary>
        /// 默认错误处理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 404找不到页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFoundPage()
        {
            return View();
        }

        /// <summary>
        /// 500服务器发生错误
        /// </summary>
        /// <returns></returns>
        public ActionResult ServerError()
        {
            return View();
        }
    }
}