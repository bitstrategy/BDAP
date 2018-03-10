/************************************************************
 * 项目名称：YYBDAP.BLL
 * 项目描述：
 * 类名称：MenuService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.BLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/27 17:37:57
 * 更新时间：2017/7/27 17:37:57
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.EFDAL;
using YYBDAP.IBLL;
using YYBDAP.Model;
using YYBDAP.ViewModel;

namespace YYBDAP.BLL
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public partial class MenuService : BaseService<Menu>, IMenuService
    {
        /// <summary>
        /// 菜单显示列表
        /// </summary>
        /// <returns></returns>
        public List<MenuTreeViewModel> GetMenuList()
        {
            List<MenuTreeViewModel> rootMTList = GetMenuTree();
            return rootMTList;
        }

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        private List<MenuTreeViewModel> GetMenuTree()
        {
            var allMenuList = this.CurrentRepository.FindList(p => true).ToList();
            List<MenuTreeViewModel> rootMTList = new List<MenuTreeViewModel>();
            foreach (var parNode in allMenuList.Where(p => p.ParentId == 0))
            {
                MenuTreeViewModel mv = new MenuTreeViewModel();
                mv.id = parNode.MenuId;
                mv.name = parNode.MenuName;
                mv.parentId = parNode.ParentId;
                mv.url = parNode.URL;
                mv.icon = parNode.ICON;
                mv.order = parNode.Order;
                mv.isHeader = parNode.IsHeader;
                mv.childMenus = CreateChildTree(allMenuList, mv);
                rootMTList.Add(mv);
            }
            return rootMTList;
        }

        /// <summary>
        /// 子节点
        /// </summary>
        /// <param name="allMenuList"></param>
        /// <param name="chlNode"></param>
        /// <returns></returns>
        private object CreateChildTree(List<Menu> allMenuList, MenuTreeViewModel chlNode)
        {
            int parNodeId = chlNode.id;
            List<MenuTreeViewModel> nodeList = new List<MenuTreeViewModel>();
            var childrenList = allMenuList.Where(t => t.ParentId == parNodeId);
            foreach (var chl in childrenList)
            {
                MenuTreeViewModel mv = new MenuTreeViewModel();
                mv.id = chl.MenuId;
                mv.name = chl.MenuName;
                mv.parentId = chl.ParentId;
                mv.url = chl.URL;
                mv.icon = chl.ICON;
                mv.order = chl.Order;
                mv.isHeader = chl.IsHeader;
                mv.childMenus = CreateChildTree(allMenuList, mv);
                nodeList.Add(mv);
            }
            return nodeList;
        }

        public MenuService() : base(RepositoryFactory.MenuRepository)
        {

        }
    }
}
