/************************************************************
 * 项目名称：Framework.Common
 * 项目描述：
 * 类名称：ConfigHelper
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：Framework.Common
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/7 17:45:28
 * 更新时间：2017/7/7 17:45:28
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;

namespace Framework.Common.Helper
{
    public static partial class ConfigHelper
    {

        /// <summary>
        /// 网站根路径
        /// </summary>
        private static string siteroot = HostingEnvironment.MapPath("~/");

        /// <summary>
        /// 获取配置文件中AppSetting节点的相对路径对应的绝对路径
        /// </summary>
        /// <param name="key">相对路径设置的键值</param>
        /// <returns>绝对路径</returns>
        public static string AppSettingMapPath(string key)
        {
            if (String.IsNullOrEmpty(siteroot))
            {
                siteroot = HostingEnvironment.MapPath("~/");
            }
            //拼接路径
            string path = siteroot + ConfigurationManager.AppSettings[key].ToString();
            return path;

        }
        
        /// <summary>
        /// 将虚拟路径转换为物理路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>虚拟路径对应的物理路径</returns>
        public static string MapPath(string virtualPath)
        {
            if (String.IsNullOrEmpty(siteroot))
            {
                siteroot = HostingEnvironment.MapPath("~/");
            }
            //拼接路径
            string path = siteroot + virtualPath;
            return path;
        }


        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static string GetAppSetting(string key) => ConfigurationManager.AppSettings[key].ToString();

        /// <summary>
        /// 获取配置文件中ConnectionStrings节点的值
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>键值对应的连接字符串值</returns>
        public static string GetConnectionString(string key) => ConfigurationManager.ConnectionStrings[key].ConnectionString;
        
        /// <summary>
        /// 更新appkey节点的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool UpdateAppSettings(string key, string value)
        {
            string filename = HostingEnvironment.MapPath("~/web.config");
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(filename);
            }
            catch (Exception)
            {
                return false;
            }

            XmlNodeList DocdNodeNameArr = xmldoc.DocumentElement.ChildNodes;//文档节点名称数组
            foreach (XmlElement element in DocdNodeNameArr)
            {
                if (element.Name == "appSettings")//找到名称为 appSettings 的节点
                {
                    XmlNodeList KeyNameArr = element.ChildNodes;//子节点名称数组
                    if (KeyNameArr.Count > 0)
                    {
                        foreach (XmlElement xmlElement in KeyNameArr)
                        {
                            //找到键值，修改为想要修改的值
                            if (xmlElement.Attributes["key"].InnerXml.Equals(key))
                            {
                                xmlElement.Attributes["value"].Value = value;
                                ConfigurationManager.RefreshSection("appSettings");
                                return true;
                            }
                        }
                        //没有相应的节点
                        return false;
                    }
                    else
                    {
                        //不存在 AppSettings 节点
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
