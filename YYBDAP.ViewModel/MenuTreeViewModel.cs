/************************************************************
 * 项目名称：YYBDAP.ViewModel
 * 项目描述：
 * 类名称：MenuTreeViewModel
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.ViewModel
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/27 19:52:00
 * 更新时间：2017/7/27 19:52:00
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYBDAP.ViewModel
{
    /// <summary>
    /// 菜单
    /// </summary>
    public partial class MenuTreeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public Int16 order { get; set; }
        public Int16 isHeader { get; set; }
        public object childMenus { get; set; }
    }
}
