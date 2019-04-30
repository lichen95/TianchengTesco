using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TianchengTesco.BLL;
using TianchengTesco.Entity;

namespace TianchengTesco.WebApi.Controllers
{
    [RoutePrefix("TianchengTesco")]
    public class OrdersController : ApiController
    {
        OrdersBLL bll = new OrdersBLL();
        CarsBLL carsBLL = new CarsBLL();
        GoodsBLL goodsBLL = new GoodsBLL();
        public const int PAGESIZE = 6;
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOrders")]
        public int Add(Orders t)
        {
            t.CreateDate = DateTime.Now;
            t.State = 0;
            var result = bll.Add(t);
            if (result > 0)
            {
                var good = goodsBLL.QueryById(t.GId);
                good.Num -= t.Nums;
                var g = goodsBLL.Update(good);
            }
            return result;
        }

        /// <summary>
        /// 购物车结算
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Settlement")]
        public List<int> Settlement(string Ids)
        {
            var arr = Ids.Split(',');
            var result = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
               var car= carsBLL.QueryById(Convert.ToInt32(arr[i]));
                Orders t = new Orders();
                t.GId = car.GId;
                t.Nums = car.Nums;
                t.CreateDate = DateTime.Now;
                t.UId = car.UId;
                t.State = 0;
                var h = bll.Add(t);
                result.Add(h);
                if (h > 0)
                {
                    var good = goodsBLL.QueryById(t.GId);
                    good.Num -= t.Nums;
                    var g = goodsBLL.Update(good);
                    var j = carsBLL.Delete(car.Id);
                }     
            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteOrders")]
        public int Delete(int Id)
        {
            var result = bll.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryOrders")]
        public PageBox Query(int pageIndex=1, int UId = 0,int SId=0)
        {
            var list = bll.Query();
            if (UId != 0)
            {
                list = list.Where(m => m.UId.Equals(UId)).ToList();
            }
            if (SId != 0)
            {
                list = list.Where(m => m.SId.Equals(SId)).ToList();
            }
            PageBox page = new PageBox
            {
                PageIndex = pageIndex,
                PageCount = list.Count / PAGESIZE + (list.Count % PAGESIZE > 0 ? 1 : 0),
                Data = list.Skip((pageIndex - 1) * PAGESIZE).Take(PAGESIZE)
            };
            return page;
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryByIdOrders")]
        public Orders QueryById(int Id)
        {
            var result = bll.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 根据id获取订单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrdersById")]
        public Orders GetOrdersById(int Id)
        {
            var result = bll.Query().Where(m=>m.Id.Equals(Id)).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateOrders")]
        public int Update(string Ids,int State)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = bll.QueryById(Convert.ToInt32(arr[i]));
                t.State = State;
                result += bll.Update(t);
            }
            return result;
        }
    }
}
