using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.IBLL;

namespace YYBDAP.Web.Portal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(LoginUserVM);
        }

        public ActionResult Disktop()
        {
            return View();
        }
    }
}