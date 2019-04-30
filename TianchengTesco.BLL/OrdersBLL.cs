using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.IDAL;
using TianchengTesco.Entity;

namespace TianchengTesco.BLL
{
   public class OrdersBLL:IBLLBase<Orders>
    {
        public static string typeName = "OrdersDAL";
        public IOrders iOrders;
        public OrdersBLL() : base(typeName)
        {
            iOrders = (IOrders)idal;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Orders t)
        {
            var result = iOrders.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iOrders.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Orders> Query()
        {
            var result = iOrders.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Orders QueryById(int Id)
        {
            var result = iOrders.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Orders t)
        {
            var result = iOrders.Update(t);
            return result;
        }
    }
}
