/************************************************************
 * 项目名称：Framework.Common.Helper
 * 项目描述：
 * 类名称：JSONHelper
 * 版本号：
 * 说明：
 * 作者：Administrator
 * 所在的域：JOHN-PC
 * 命名空间：Framework.Common.Helper
 * 注册组织：
 * 机器名称：JOHN-PC
 * CLR版本：4.0.30319.42000
 * .NET Framework版本：4.5.2
 * 创建时间：2017/7/27 19:34:40
 * 更新时间：2017/7/27 19:34:40
 * *********************************************************
 * Copyright © Administrator 2017. All rights reserved
 * ********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Helper
{
    /// <summary>
    /// JSON转换辅助类
    /// </summary>
    public partial class JSONHelper
    {
        /// <summary>
        /// 将字符串中特殊字符转成JSON格式字符
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>符合JSON格式的字符串</returns>
        public static string StringToJSON(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="str">要格式化的字符串</param>
        /// <param name="type">要格式化的类型</param>
        /// <returns>格式化的字符串</returns>
        public static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = StringToJSON(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type == typeof(Guid))
            {
                str = "\"" + str + "\"";
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

        /// <summary>
        /// List转换为JSON
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>JSON字符串</returns>
        public static string ListToJSON<T>(IList<T> list)
        {
            object obj = list[0];
            return ListToJSON<T>(list, obj.GetType().Name);
        }

        /// <summary>
        /// List转换为JSON
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="jsonName">JSON名称</param>
        /// <returns>JSON字符串</returns>
        public static string ListToJSON<T>(IList<T> list, string jsonName)
        {
            StringBuilder json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = list[0].GetType().Name;
            json.Append("{\"" + jsonName + "\":[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        Type type = pi[j].GetValue(list[i], null).GetType();
                        json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));
                        if (j < pi.Length - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (i < list.Count - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]}");
            return json.ToString();
        }

        /// <summary>
        /// 对象转换成JSON
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>JSON字符串</returns>
        public static string ObjectToJSON(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                object objectValue = propertyInfo[i].GetGetMethod().Invoke(obj, null);
                Type type = propertyInfo[i].PropertyType;
                string strValue = objectValue.ToString();
                strValue = StringFormat(strValue, type);
                sb.Append("\"" + propertyInfo[i].Name + "\":");
                sb.Append(strValue + ",");

            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 对象集合转换成JSON
        /// </summary>
        /// <param name="arr">对象集合</param>
        /// <returns>JSON字符串</returns>
        public static string EnumerToJSON(IEnumerable arr)
        {
            string str = "{";
            foreach (object item in arr)
            {
                str += ObjectToJSON(item) + ",";
            }
            str.Remove(str.Length - 1, str.Length);
            return str + "]";
        }

        /// <summary>
        /// DataTable转换成JSON
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>JSON字符串</returns>
        public static string DataTableToJSON(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                str.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();

                    Type type = dt.Columns[j].DataType;
                    str.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        str.Append(strValue + ",");
                    }
                    else
                    {
                        str.Append(strValue);
                    }
                }
                str.Append("},");
            }
            str.Remove(str.Length - 1, 1);
            str.Append("]");
            return str.ToString();
        }

        /// <summary>
        /// DataSet转换成JSON
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns>JSON字符串</returns>
        public static string DataSetToJSON(DataSet ds)
        {
            string str = "{";
            foreach (DataTable table in ds.Tables)
            {
                str += "\"" + table.TableName + "\":" + DataTableToJSON(table) + ",";
            }
            str = str.TrimEnd(',');
            return str + "}";
        }

        /// <summary>
        /// DataReader转转成JSON
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <returns>JSON字符串</returns>
        public static string DataReaderToJSON(DbDataReader dr)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            while (dr.Read())
            {
                str.Append("{");
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Type type = dr.GetFieldType(i);
                    string strKey = dr.GetName(i);
                    string strValue = dr[i].ToString();
                    str.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (i < dr.FieldCount - 1)
                    {
                        str.Append(strValue + ",");
                    }
                    else
                    {
                        str.Append(strValue);
                    }
                }
                str.Append("},");
            }
            dr.Close();
            str.Remove(str.Length - 1, 1);
            str.Append("]");
            return str.ToString();
        }
    }
}
