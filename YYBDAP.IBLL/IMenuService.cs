/************************************************************
 * 项目名称：YYBDAP.IBLL
 * 项目描述：
 * 类名称：IMenuService
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.IBLL
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/27 17:34:08
 * 更新时间：2017/7/27 17:34:08
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYBDAP.Model;
using YYBDAP.ViewModel;

namespace YYBDAP.IBLL
{
    /// <summary>
    /// 菜单服务接口
    /// </summary>
    public partial interface IMenuService : IBaseService<Menu>
    {
        /// <summary>
        /// 菜单显示列表
        /// </summary>
        /// <returns></returns>
        List<MenuTreeViewModel> GetMenuList();
    }
}
