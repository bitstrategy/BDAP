using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.ViewModel;

namespace YYBDAP.Web.Portal.Filters
{
    /// <summary>
    /// 自定义异常筛选器
    /// </summary>
    public class CustExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        private ILogger log4netHelper = new Log4netHelper("logerror");
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            if (null == filterContext)
            {
                return;
            }

            if (!filterContext.ExceptionHandled)//异常尚未被其它handler处理过
            {
                //先把错误记录到日志
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                string msgTemplate = "在执行 controller[{0}] 的 action[{1}] 时产生异常";
                log4netHelper.Error(string.Format(msgTemplate, controllerName, actionName), filterContext.Exception);

                //设置异常已经处理,否则会被其他异常过滤器覆盖
                filterContext.ExceptionHandled = true;
                //在派生类中重写时，获取或设置一个值，该值指定是否禁用IIS自定义错误。
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                //处理404、500等错误
                Exception ex = filterContext.Exception;
                HttpException httpEx = new HttpException(ex.Message, ex);
                ExecptionViewModel evm = new ExecptionViewModel();
                evm.SrcIP = filterContext.HttpContext.Request.UserHostAddress;//HttpContext.Current.Request.UserHostAddress
                evm.ControllerName = controllerName;
                evm.ActionName = actionName;
                evm.ExecptionMsg = ex.Message;
                evm.StackTrace = ex.StackTrace;
                if (httpEx != null && (400 == httpEx.GetHttpCode() || 404 == httpEx.GetHttpCode()))
                {
                    evm.StatusCode = 404;
                }
                else
                {
                    evm.StatusCode = 500;
                }

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var t = new { result = false, message = "服务器异常,联系管理员或查看错误日志！" };
                    filterContext.Result = new JsonResult() { Data = t };
                }
                else
                {
                    ViewDataDictionary vdd = new ViewDataDictionary();
                    vdd.Add("ExecptionViewModel", evm);
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "~/views/Error/Index.cshtml",
                        ViewData = vdd,
                        TempData = filterContext.Controller.TempData
                    };
                }
            }
        }
    }
}