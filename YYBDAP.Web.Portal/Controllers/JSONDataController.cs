using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYBDAP.IBLL;

namespace YYBDAP.Web.Portal.Controllers
{
    [AllowAnonymous]
    public class JSONDataController : Controller
    {
        private IMenuService menuService = null;
        public JSONDataController(IMenuService _menuService)
        {
            menuService = _menuService;
        }
        
        public JsonResult MenuList()
        {
            JsonResult jr = Json(menuService.GetMenuList(), JsonRequestBehavior.AllowGet);
            return jr;
        }
    }
}