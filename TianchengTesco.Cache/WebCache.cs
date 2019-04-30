using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianchengTesco.Cache
{
    using System.Web;
    using System.Web.Caching;
    using Newtonsoft.Json;
    /// <summary>
    /// 使用WebCache实现缓存
    /// </summary>
    public class WebCache : ICache
    {
        /// <summary>
        /// 删除所有的缓存
        /// </summary>
        /// <returns></returns>
        public int DeleteALL()
        {
            var result = 0;
            try
            {
                var cache = HttpRuntime.Cache;
                var cacheEnum = cache.GetEnumerator();
                while (cacheEnum.MoveNext())
                {
                    result++;
                    cache.Remove(cacheEnum.Key.ToString());
                }
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// 删除指定Key的缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        public int DeleteValue(string Key)
        {
            var result = 0;
            try
            {
                HttpRuntime.Cache.Remove(Key);
                result = 1;
            }
            catch (Exception )
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// 获取所有缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        public List<T> GetALL<T>() where T:class,new()
        {
            List<T> list = new List<T>();
            T t = new T();
            try
            {
                var cache = HttpRuntime.Cache;
                var cacheEnum = cache.GetEnumerator();
                while (cacheEnum.MoveNext())
                {
                    var Key = cacheEnum.Key.ToString();
                   t= JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(HttpRuntime.Cache.Get(Key)));
                    list.Add(t);
                }
            }
            catch (Exception )
            {
               
            }
            return list;
        }

        /// <summary>
        /// 根据指定的Key获取缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        public T GetValue<T>(string Key)
        {
           return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(HttpRuntime.Cache.Get(Key)));
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <param name="Value">缓存值</param>
        /// <param name="TimeOut">864000七天过期</param>
        /// <returns></returns>
        public int SetValue(string Key, object Value,int TimeOut = 864000)
        {
            int result = 0;
            try
            {
                if (Value != null)
                {
                    HttpRuntime.Cache.Insert(Key, Value, null, DateTime.Now.AddSeconds(TimeOut), TimeSpan.Zero,CacheItemPriority.High,null);
                    result = 1;
                } 
            }
            catch (Exception )
            {
                result=-1;
            }
            return result;
        }
    }
}
