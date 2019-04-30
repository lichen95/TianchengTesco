using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Cache;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using log4net.Config;
using log4net;
using System.Configuration;
using TianchengTesco.Common;

namespace TianchengTesco.DAL
{
    public class UsersDAL : IUsers
    {
        public string Cache = "Users:";
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Users t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var parm = new[] {
                    new SqlParameter("@uname",t.UName),
                    new SqlParameter("@pwd",t.Pwd),
                    new SqlParameter("@name",t.Name),
                    new SqlParameter("@sex",t.Sex),
                    new SqlParameter("@age",t.Age),
                    new SqlParameter("@phone",t.Phone),
                    new SqlParameter("@email",t.Email),
                    new SqlParameter("@RolesIds",t.RolesIds),
                    new SqlParameter("@RolesNames",t.RolesNames),
                    new SqlParameter("@SId ",t.SId),
                    new SqlParameter("@isUse",t.IsUse),
                    new SqlParameter("@rowCount",SqlDbType.Int)
                };
                    parm[11].Direction = ParameterDirection.Output;
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_AddUsers @uname,@pwd,@name,@sex,@age,@phone,@email,@RolesIds,@RolesNames,@SId,@isUse,0", parm);
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
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_DeleteUsers @id ", parm);
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
        public List<Users> Query()
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.Users.ToList();
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
        public Users QueryById(int Id)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = dbContext.Users.Find(Id);
                    if (result != null)
                    {
                        if (CacheCommon.Ins.GetValue<Users>(Cache + Id) == null)
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
        public int Update(Users t)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var parm = new[] {
                    new SqlParameter("@id",t.Id),
                    new SqlParameter("@uname",t.UName),
                    new SqlParameter("@pwd",t.Pwd),
                    new SqlParameter("@name",t.Name),
                    new SqlParameter("@sex",t.Sex),
                    new SqlParameter("@age",t.Age),
                    new SqlParameter("@phone",t.Phone),
                    new SqlParameter("@email",t.Email),
                    new SqlParameter("@RolesIds",t.RolesIds),
                    new SqlParameter("@RolesNames",t.RolesNames),
                    new SqlParameter("@SId ",t.SId),
                    new SqlParameter("@isUse",t.IsUse),
                    new SqlParameter("@rowCount",SqlDbType.Int)
                };
                    parm[12].Direction = ParameterDirection.Output;
                    var result = dbContext.Database.ExecuteSqlCommand("exec p_UpdateUsers @id,@uname,@pwd,@name,@sex,@age,@phone,@email,@RolesIds,@RolesNames,@SId,@isUse,0", parm);
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

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public string Login(string Name, string Pwd)
        {
            try
            {
                using (EFDbContext dbContext = new EFDbContext())
                {
                    var result = "0";
                    var list = dbContext.Users.Where(m => m.UName.Equals(Name) && m.Pwd.Equals(Pwd)).FirstOrDefault();
                    if (list != null)
                    {
                        result = list.Id + "#" + list.SId;
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
                        LogHelper.WriteLog(Name + "于" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + "后台登录成功");
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
