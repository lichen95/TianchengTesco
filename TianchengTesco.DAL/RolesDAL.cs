using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;
using System.Data;
using System.Data.SqlClient;
using TianchengTesco.Cache;
using Newtonsoft.Json;
using log4net.Config;
using log4net;
using System.Configuration;
using TianchengTesco.Common;

namespace TianchengTesco.DAL
{
    public class RolesDAL : IRoles
    {
        public string Cache = "Roles:";
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Roles t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var parm = new[] {
                    new SqlParameter("@name",t.Name),
                    new SqlParameter("@PermissionsIds",t.PermissionsIds),
                    new SqlParameter("@PermissionsNames",t.PermissionsNames),
                    new SqlParameter("@isUse",t.IsUse),
                    new SqlParameter("@rowCount",SqlDbType.Int)
                };
                    parm[4].Direction = ParameterDirection.Output;
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_AddRoles @name,@PermissionsIds,@PermissionsNames,@isUse,0", parm);
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
                    var parm = new[] {
                    new SqlParameter("@id",Id)
                };
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_DeleteRoles @id ", parm);
                    if (result > 0)
                    {
                        CacheCommon.Ins.DeleteValue(Cache + Id);
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
        public List<Roles> Query()
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.Roles.ToList();
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
        public Roles QueryById(int Id)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.Roles.Find(Id);
                    if (result != null)
                    {
                        if (CacheCommon.Ins.GetValue<Roles>(Cache + Id) == null)
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
        public int Update(Roles t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var parm = new[] {
                    new SqlParameter("@id",t.Id),
                    new SqlParameter("@name",t.Name),
                    new SqlParameter("@PermissionsIds",t.PermissionsIds),
                    new SqlParameter("@PermissionsNames",t.PermissionsNames),
                    new SqlParameter("@isUse",t.IsUse),
                    new SqlParameter("@rowCount",SqlDbType.Int)
                };
                    parm[5].Direction = ParameterDirection.Output;
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_UpdateRoles @id,@name,@PermissionsIds,@PermissionsNames,@isUse,0", parm);
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
