using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;

namespace TianchengTesco.IDAL
{
   public interface IPermissions:IDALBase<Permissions>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Permissions> Query();
        List<Permissions> GetPermissionsByUserId(int UsersId);
    }
}
