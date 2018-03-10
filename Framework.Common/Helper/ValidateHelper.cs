/************************************************************
 * 项目名称：Framework.Common
 * 项目描述：
 * 类名称：ValidateHelper
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：Framework.Common
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/8 21:40:36
 * 更新时间：2017/7/8 21:40:36
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Common.Helper
{
    /// <summary>
    /// 验证
    /// <para/>Author : AnDequan
    /// <para/>Date   : 2010-12-23
    /// </summary>
    public static partial class ValidateHelper
    {
        /// <summary>
        /// 验证非空
        /// </summary>
        /// <param name="value">要验证的字符串</param>
        /// <returns>true - 非空，false - 空</returns>
        public static bool NotEmpty(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Trim().Length > 0;
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="url">url地址</param>
        /// <returns>true - 正确，false - 不正确</returns>
        public static bool IsRightUrl(string url)
        {
            return Regex.IsMatch(url, "http(s)?://([//w-]+//.)+[//w-]+(//[w-.//?%&=]*)?");
        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns>true - IP正确，false - 不正确 </returns>
        public static bool IsRightIP(string ip)
        {
            string[] sLines = new string[4];
            sLines = ip.Split('.');
            foreach (string item in sLines)
            {
                if (Regex.IsMatch(item, @"/d*"))
                {
                    if (Convert.ToInt32(item) >= 255)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断数字
        /// </summary>
        /// <param name="value">要验证的值</param>
        /// <returns>true - 是数字，否则反之</returns>
        public static bool IsNumber(string value)
        {
            return Regex.IsMatch(value, "^[0-9]*$");
        }

        /// <summary>
        /// 判断带小数点
        /// </summary>
        /// <param name="value">要验证的值</param>
        /// <returns>true - 带小数点，否则反之</returns>
        public static bool IsWithPoint(string value)
        {
            return Regex.IsMatch(value, "^[0-9]+(.[0-9]{2})?$");
        }

        /// <summary>
        /// 判断是否英文大写
        /// </summary>
        /// <param name="value">验证字符串</param>
        /// <returns>true - 是,false - 否</returns>
        public static bool IsEnglishUpper(string value)
        {
            return Regex.IsMatch(value, "^[A-Z]+$");
        }

        /// <summary>
        /// 判断是否英文
        /// </summary>
        /// <param name="value">验证字符串</param>
        /// <returns></returns>
        public static bool IsEnglish(string value)
        {
            return Regex.IsMatch(value, "^[A-Za-z]+$");
        }

        /// <summary>
        /// 判断邮箱地址
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public static bool IsEmail(string sValue)
        {

            return Regex.IsMatch(sValue, @"^/w+([-+.]/w+)*@/w+([-.]/w+)*/./w+([-.]/w+)*$");
        }

        /// <summary>
        /// 判断电话号码
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public static bool IsTelePhone(string sValue)
        {
            return Regex.IsMatch(sValue, @"(^(/d{3,4}-)?/d{7,8})$|(13|15|18[0-9]{9})");
        }

        /// <summary>
        /// 判断网站地址
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public static bool IsInternalAddress(string sValue)
        {
            return Regex.IsMatch(sValue, @"^http://([/w-]+/.)+[/w-]+(/[/w-./?%&=]*)?$");
        }
    }
}
