using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Cache;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;
using Newtonsoft.Json;
using log4net.Config;
using log4net;
using System.Configuration;
using TianchengTesco.Common;

namespace TianchengTesco.DAL
{
    public class UserInfosDAL : IUserInfos
    {
        public string Cache = "UserInfos:";

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(UserInfos t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    dbContext.Entry(t).State = System.Data.Entity.EntityState.Added;
                    var result = dbContext.SaveChanges();
                    if (result > 0)
                    {
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

        /// <summary>
        /// 用户删号
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
        /// 用户登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int Login(string Name, string Pwd)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = 0;
                    var userInfos = dbContext.UserInfos.Where(m => m.UName.Equals(Name) && m.Pwd.Equals(Pwd)).FirstOrDefault();
                    if (userInfos != null)
                    {
                        result = userInfos.Id;
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
                        LogHelper.WriteLog(Name + "于" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + "前台登录成功");
                    
                    if (CacheCommon.Ins.GetValue<UserInfos>(Cache + userInfos.Id) == null)
                        {
                            CacheCommon.Ins.SetValue(Cache + userInfos.Id, JsonConvert.SerializeObject(result));
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
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfos> Query()
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.UserInfos.ToList();
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
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserInfos QueryById(int Id)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.UserInfos.Find(Id);
                    if (result != null)
                    {
                        if (CacheCommon.Ins.GetValue<UserInfos>(Cache + Id) == null)
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
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(UserInfos t)
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
