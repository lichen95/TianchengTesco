using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianchengTesco.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 根据指定的Key获取缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        T GetValue<T>(string Key);

        /// <summary>
        /// 获取所有缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        List<T> GetALL<T>() where T:class,new();

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <param name="Value">缓存值</param>
        /// <param name="TimeOut">过期时间</param>
        /// <returns></returns>
        int SetValue(string Key,object Value, int TimeOut= 864000);

        /// <summary>
        /// 删除所有的缓存
        /// </summary>
        /// <returns></returns>
        int DeleteALL();

        /// <summary>
        /// 删除指定Key的缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        int DeleteValue(string Key);
    }
}
