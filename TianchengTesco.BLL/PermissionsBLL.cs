using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;

namespace TianchengTesco.BLL
{
   public class PermissionsBLL:IBLLBase<Permissions>
    {
        public static string typeName = "PermissionsDAL";
        public IPermissions iPermissions;
        public PermissionsBLL() : base(typeName)
        {
            iPermissions = (IPermissions)idal;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Permissions t)
        {
            var result = iPermissions.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iPermissions.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Permissions> Query()
        {
            var result = iPermissions.Query();
            return result;
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Permissions QueryById(int Id)
        {
            var result = iPermissions.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Permissions t)
        {
            var result = iPermissions.Update(t);
            return result;
        }
        /// <summary>
        /// 根据UsersId获取权限
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        public List<Permissions> GetPermissionsByUserId(int UsersId)
        {
            var result = iPermissions.GetPermissionsByUserId(UsersId);
            return result;
        }
    }
}
