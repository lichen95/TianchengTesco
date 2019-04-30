using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianchengTesco.Cache
{
    using System.Configuration;
    /// <summary>
    /// 缓存调用类
    /// </summary>
   public class CacheCommon
    {
        private static CacheCommon _Ins = null;

        private ICache Cache;

        public static CacheCommon Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new CacheCommon();
                return _Ins;
            }

            set
            {
                _Ins = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CacheCommon()
        {
            var CacheType = "";
            try
            {
                CacheType = ConfigurationManager.AppSettings["CacheType"].ToString();
            }
            catch (Exception)
            {
                CacheType = "WebCache";
            }
            
            if (CacheType == "RedisCache")
            {
                Cache = new RedisCache();
            }
            else
            {
                Cache = new WebCache();
            }
        }

        /// <summary>
        /// 根据指定的Key获取缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        public T GetValue<T>(string Key)
        {
            return Cache.GetValue<T>(Key);
        }
        /// <summary>
        /// 删除所有的缓存
        /// </summary>
        /// <returns></returns>
        public int DeleteALL()
        {
            return Cache.DeleteALL();
        }

        /// <summary>
        /// 删除指定Key的缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <returns></returns>
        public int DeleteValue(string Key)
        {
            return Cache.DeleteValue(Key);
        }

        /// <summary>
        /// 获取所有缓存
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        public List<T> GetALL<T>() where T : class, new()
        {
            return Cache.GetALL<T>();
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="Key">Key键</param>
        /// <param name="Value">缓存值</param>
        /// <returns></returns>
        public int SetValue(string Key, object Value)
        {
            return Cache.SetValue(Key, Value, 864000);
        }
    }
}
