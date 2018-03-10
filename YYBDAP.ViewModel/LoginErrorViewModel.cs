/************************************************************
 * 项目名称：YYBDAP.ViewModel
 * 项目描述：
 * 类名称：LoginErrorViewModel
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.ViewModel
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/20 11:14:49
 * 更新时间：2017/7/20 11:14:49
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
    /// 登录错误
    /// </summary>
    public partial class LoginErrorViewModel
    {
        public string ErrorMsg { get; set; }

        public string UserName { get; set; }

        public LoginErrorViewModel()
        {

        }
    }
}
