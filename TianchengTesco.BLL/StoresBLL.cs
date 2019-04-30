using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;

namespace TianchengTesco.BLL
{
   public class StoresBLL:IBLLBase<Stores>
    {
        public static string typeName = "StoresDAL";
        public IStores iStores;
        public StoresBLL() : base(typeName)
        {
            iStores = (IStores)idal;
        }
        /// <summary>
        /// 新增店铺
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Stores t)
        {
            var result = iStores.Add(t);
            return result;
        }

        /// <summary>
        /// 删除店铺
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iStores.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public List<Stores> Query()
        {
            var result = iStores.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Stores QueryById(int Id)
        {
            var result = iStores.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Stores t)
        {
            var result = iStores.Update(t);
            return result;
        }
    }
}
