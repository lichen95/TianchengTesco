using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.IDAL;
using TianchengTesco.Entity;

namespace TianchengTesco.BLL
{
   public class UsersBLL:IBLLBase<Users>
    {
        public static string typeName = "UsersDAL";
        public IUsers iUsers;
        public UsersBLL() : base(typeName)
        {
            iUsers = (IUsers)idal;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Users t)
        {
            var result = iUsers.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iUsers.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Users> Query()
        {
            var result = iUsers.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Users QueryById(int Id)
        {
            var result = iUsers.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Users t)
        {
            var result = iUsers.Update(t);
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public string Login(string Name, string Pwd)
        {
            var result = iUsers.Login(Name, Pwd);
            return result;
        }
    }
}
