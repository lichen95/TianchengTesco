using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.IDAL;
using TianchengTesco.Entity;

namespace TianchengTesco.BLL
{
   public class GoodsBLL:IBLLBase<Goods>
    {
        public static string typeName = "GoodsDAL";
        public IGoods iGoods;
        public GoodsBLL() : base(typeName)
        {
            iGoods = (IGoods)idal;
        }
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Goods t)
        {
            var result = iGoods.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iGoods.Delete(Id);
            return result;
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <returns></returns>
        public List<GoodsTypes> GetGoodsTypes()
        {
            var result = iGoods.GetGoodsTypes();
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Goods> Query()
        {
            var result = iGoods.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Goods QueryById(int Id)
        {
            var result = iGoods.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Goods t)
        {
            var result = iGoods.Update(t);
            return result;
        }
    }
}
