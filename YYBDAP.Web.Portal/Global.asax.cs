using Framework.Common.Helper;
using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YYBDAP.Web.Portal.App_Code;

namespace YYBDAP.Web.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BundleTable.EnableOptimizations = true;

            //依赖注入初始化
            AutofacConfig.Initialise();

            //log4net初始化
            Log4netHelper.LogInit(Server.MapPath(ConfigHelper.GetAppSetting("Log4netConfigFilePath")));
        }
    }
}
