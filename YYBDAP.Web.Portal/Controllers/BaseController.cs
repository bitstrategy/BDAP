using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.ViewModel;

namespace YYBDAP.Web.Portal.Controllers
{
    public class BaseController : Controller
    {
        private Log4netHelper logger = new Log4netHelper("logerror");
        protected LoginUserViewModel LoginUserVM { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (null == Session["LoginUserVM"])
            {
                LoginUserVM = new LoginUserViewModel();
                filterContext.HttpContext.Response.Redirect("~/Authentication/Logon", true);
            }
            else
            {
                LoginUserVM = Session["LoginUserVM"] as LoginUserViewModel;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}