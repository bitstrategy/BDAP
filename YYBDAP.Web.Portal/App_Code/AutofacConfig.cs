using Autofac;
using Autofac.Integration.Mvc;
using Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace YYBDAP.Web.Portal.App_Code
{
    /// <summary>
    /// Autofac配置实现依赖注入
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 依赖注入初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = CreateBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static ContainerBuilder CreateBuilder()
        {
            //第一步： 构造一个AutoFac的builder容器
            var builder = new ContainerBuilder();

            //第二步：告诉AutoFac容器，创建项目中的指定类的对象实例，以接口的形式存储（其实就是创建业务逻辑层程序集中所有类的对象实例，然后以其接口的形式保存到AutoFac容器内存中，当然如果有需要也可以创建其他程序集的所有类的对象实例，这个只需要我们指定就可以了）
            string[] assList = ConfigHelper.GetAppSetting("AutofacRegDllList").Split(';');
            for (int i = 0; i < assList.Length; i++)
            {
                //加载程序集
                Assembly ass = Assembly.Load(assList[i]);

                //得到程序集中所有类的集合
                Type[] types = ass.GetTypes();

                //RegisterTypes注册所有类的实例，AsImplementedInterfaces以其接口形式保存。
                builder.RegisterTypes(types.Where(u => u.FullName.Contains("Service")).ToArray()).AsImplementedInterfaces().InstancePerLifetimeScope();
            }
            //第三步：创建一个真正的AutoFac的工作容器  

            return builder;
        }

        public static string GetDllList()
        {
            string dlllist = ConfigHelper.GetAppSetting("AutofacRegDllList");
            return dlllist;
        }
    }
}