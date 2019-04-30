using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace TianchengTesco.Factory
{
    public class DataAccess<T>
    {
        public static string nameSpace = ConfigurationManager.AppSettings["DbName"].ToString();
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static T GetFactory(string typeName)
        {
            return (T)Assembly.Load(nameSpace).CreateInstance(nameSpace + "." + typeName);
        }
    }
}
