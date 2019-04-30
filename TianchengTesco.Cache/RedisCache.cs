using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianchengTesco.Cache
{
    using ServiceStack.Redis;
    /// <summary>
    /// 使用Redis实现缓存
    /// </summary>
    public class RedisCache : ICache
    {
        #region -- 连接信息 --
        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static PooledRedisClientManager prcm;
        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisCache()
        {
            CreateManager();
        }
        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            string[] writeServerList = SplitString("127.0.0.1:6379", ",");
            string[] readServerList = SplitString("127.0.0.1:6379", ",");

            prcm = new PooledRedisClientManager(readServerList, writeServerList,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = 60,
                                 MaxReadPoolSize = 60,
                                 AutoStart = true,
                                 DefaultDb = 0
                             });
        }
        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }
        #endregion

        /// <summary>
        /// 删除所有的缓存
        /// </summary>
        /// <returns></returns>
        public int DeleteALL()
        {
            int result = 0;
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    redis.FlushAll();
                }
                result = 1;
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
            int result = 0;
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    if (redis.Remove(Key))
                    {
                        result = 1;
                    }
                }
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
        public List<T> GetALL<T>() where T : class, new()
        {
            List<T> list = new List<T>();
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    foreach (var item in redis.GetAllKeys())
                    {
                        list.Add(redis.Get<T>(item));
                    }
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
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    return redis.Get<T>(Key);
                }
            }
            catch (Exception )
            {

            }
            return default(T);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <param name="Value">缓存值</param>
        /// <returns></returns>
        public int SetValue(string Key, object Value,int TimeOut)
        {
            int Result = 0;
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    if (redis.Set(Key, Value, DateTime.Now.AddSeconds(TimeOut)))
                    {
                        Result = 1;
                    }
                }
            }
            catch (Exception )
            {
                Result = -1;
            }
            return Result;
        }
    }
}
