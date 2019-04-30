using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Cache;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;
using log4net.Config;
using log4net;
using System.Configuration;
using TianchengTesco.Common;
using Newtonsoft.Json;

namespace TianchengTesco.DAL
{
    public class CarsDAL : ICars
    {
        public string Cache = "Cars:";

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Cars t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    dbContext.Entry(t).State = System.Data.Entity.EntityState.Added;
                    var result = dbContext.SaveChanges();
                    if (result > 0)
                    {
                        CacheCommon.Ins.SetValue(Cache + t.Id,JsonConvert.SerializeObject(t));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //初始化日志文件 
                string state = ConfigurationManager.AppSettings["IsWriteLog"];
                //判断是否开启日志记录
                if (state == "1")
                {
                    var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                              ConfigurationManager.AppSettings["log4net"];
                    var fi = new System.IO.FileInfo(path);
                    log4net.Config.XmlConfigurator.Configure(fi);
                }
                LogHelper.WriteLog("错误:",ex);
                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var t = QueryById(Id);
                    dbContext.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                    var result = dbContext.SaveChanges();
                    if (result > 0)
                    {
                        CacheCommon.Ins.DeleteValue(Cache + t.Id);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //初始化日志文件 
                string state = ConfigurationManager.AppSettings["IsWriteLog"];
                //判断是否开启日志记录
                if (state == "1")
                {
                    var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                              ConfigurationManager.AppSettings["log4net"];
                    var fi = new System.IO.FileInfo(path);
                    log4net.Config.XmlConfigurator.Configure(fi);
                }
                LogHelper.WriteLog("错误:", ex);
                throw;
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Cars> Query()
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var linq = from s in dbContext.Cars.ToList()
                               join
c in dbContext.Goods.ToList() on
s.GId equals c.Id
                               select new Cars
                               {
                                   Id=s.Id,
                                   GId=s.GId,
                                   Nums=s.Nums,
                                   UId=s.UId,
                                   GName=c.Name,
                                   Price=c.Price,
                                   Img=c.Img,
                                   SId=c.SId
                               };
                    return linq.ToList();
                }
            }
            catch (Exception ex)
            {
                //初始化日志文件 
                string state = ConfigurationManager.AppSettings["IsWriteLog"];
                //判断是否开启日志记录
                if (state == "1")
                {
                    var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                              ConfigurationManager.AppSettings["log4net"];
                    var fi = new System.IO.FileInfo(path);
                    log4net.Config.XmlConfigurator.Configure(fi);
                }
                LogHelper.WriteLog("错误:", ex);
                throw;
            }
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Cars QueryById(int Id)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.Cars.Find(Id);
                    if (result != null)
                    {
                        if (CacheCommon.Ins.GetValue<Cars>(Cache + Id) == null)
                        {
                            CacheCommon.Ins.SetValue(Cache + Id, JsonConvert.SerializeObject(result));
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //初始化日志文件 
                string state = ConfigurationManager.AppSettings["IsWriteLog"];
                //判断是否开启日志记录
                if (state == "1")
                {
                    var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                              ConfigurationManager.AppSettings["log4net"];
                    var fi = new System.IO.FileInfo(path);
                    log4net.Config.XmlConfigurator.Configure(fi);
                }
                LogHelper.WriteLog("错误:", ex);
                throw;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Cars t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    dbContext.Entry(t).State = System.Data.Entity.EntityState.Modified;
                    var result = dbContext.SaveChanges();
                    if (result > 0)
                    {
                        CacheCommon.Ins.DeleteValue(Cache + t.Id);
                        CacheCommon.Ins.SetValue(Cache + t.Id, JsonConvert.SerializeObject(t));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //初始化日志文件 
                string state = ConfigurationManager.AppSettings["IsWriteLog"];
                //判断是否开启日志记录
                if (state == "1")
                {
                    var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                              ConfigurationManager.AppSettings["log4net"];
                    var fi = new System.IO.FileInfo(path);
                    log4net.Config.XmlConfigurator.Configure(fi);
                }
                LogHelper.WriteLog("错误:", ex);
                throw;
            }
        }
    }
}
