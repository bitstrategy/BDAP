/************************************************************
 * 项目名称：YYBDAP.ViewModel
 * 项目描述：
 * 类名称：ExecptionViewModel
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：YYBDAP.ViewModel
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/11 14:44:52
 * 更新时间：2017/7/11 14:44:52
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
    /// 错误显示实体
    /// </summary>
    public partial class ExecptionViewModel
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string SrcIP { get; set; }

        /// <summary>
        /// http状态码
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 控制器名
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 异常详细信息
        /// </summary>
        public string ExecptionMsg { get; set; }

        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace { get; set; }

        public ExecptionViewModel()
        {
            
        }
    }
}
