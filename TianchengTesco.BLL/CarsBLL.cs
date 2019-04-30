using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.IDAL;
using TianchengTesco.Entity;

namespace TianchengTesco.BLL
{
   public class CarsBLL:IBLLBase<Cars>
    {
        public static string typeName = "CarsDAL";
        public ICars iCars;
        public CarsBLL() : base(typeName)
        {
            iCars = (ICars)idal;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Cars t)
        {
            var result = iCars.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iCars.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Cars> Query()
        {
            var result = iCars.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Cars QueryById(int Id)
        {
            var result = iCars.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Cars t)
        {
            var result = iCars.Update(t);
            return result;
        }
    }
}
