using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.IDAL;
using TianchengTesco.Entity;

namespace TianchengTesco.BLL
{
   public class RolesBLL:IBLLBase<Roles>
    {
        public static string typeName = "RolesDAL";
        public IRoles iRoles;
        public RolesBLL() : base(typeName)
        {
            iRoles = (IRoles)idal;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Roles t)
        {
            var result = iRoles.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iRoles.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Roles> Query()
        {
            var result = iRoles.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Roles QueryById(int Id)
        {
            var result = iRoles.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Roles t)
        {
            var result = iRoles.Update(t);
            return result;
        }
    }
}
