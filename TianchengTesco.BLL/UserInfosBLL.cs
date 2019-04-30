using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;

namespace TianchengTesco.BLL
{
   public class UserInfosBLL:IBLLBase<UserInfos>
    {
        public static string typeName = "UserInfosDAL";
        public IUserInfos iUserInfos;
        public UserInfosBLL() : base(typeName)
        {
            iUserInfos = (IUserInfos)idal;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(UserInfos t)
        {
            var result = iUserInfos.Add(t);
            return result;
        }

        /// <summary>
        /// 用户删号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iUserInfos.Delete(Id);
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int Login(string Name, string Pwd)
        {
            var result = iUserInfos.Login(Name, Pwd);
            return result;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfos> Query()
        {
            var result = iUserInfos.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserInfos QueryById(int Id)
        {
            var result = iUserInfos.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(UserInfos t)
        {
            var result = iUserInfos.Update(t);
            return result;
        }
    }
}
