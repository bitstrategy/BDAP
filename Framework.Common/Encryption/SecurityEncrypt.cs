/************************************************************
 * 项目名称：Framework.Common.Encryption
 * 项目描述：
 * 类名称：SecurityEncrypt
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：Framework.Common.Encryption
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/20 10:08:26
 * 更新时间：2017/7/20 10:08:26
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Encryption
{
    /// <summary>
    /// 加密辅助类
    /// </summary>
    public partial class SecurityEncrypt
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private static string Key
        {
            get
            {
                return "P@ssw0rd";
            }
        }

        private static byte[] IV
        {
            get
            {
                return new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="inputStr">需加密字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(string inputStr, string encryptKey)
        {
            byte[] byKey = null;
            //byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(inputStr);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="inputStr">需解密的字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(string inputStr, string decryptKey)
        {
            byte[] byKey = null;
            //byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[inputStr.Length];
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="inputStr">需加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(string inputStr)
        {
            return DesEncrypt(inputStr, Key);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="inputStr">需解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(string inputStr)
        {
            return DesDecrypt(inputStr, Key);
        }
    }
}
