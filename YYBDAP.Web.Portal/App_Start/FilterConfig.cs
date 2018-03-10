using System.Web;
using System.Web.Mvc;
using YYBDAP.Web.Portal.Filters;

namespace YYBDAP.Web.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //MVC3 以后，filter注册的order数字越大，则越先处理
            filters.Add(new HandleErrorAttribute(), 1);
            //自定义的log日常处理
            filters.Add(new CustExceptionAttribute(), 2);

            //启用全局的权限过滤
            filters.Add(new AuthorizeAttribute());
        }
    }
}
