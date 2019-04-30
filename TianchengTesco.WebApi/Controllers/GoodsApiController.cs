using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TianchengTesco.Entity;
using TianchengTesco.BLL;

namespace TianchengTesco.WebApi.Controllers
{
    [RoutePrefix("TianchengTesco")]
    public class GoodsApiController : ApiController
    {
        GoodsBLL bll = new GoodsBLL();
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddGoods")]
        public int Add(Goods t)
        {
            var result = bll.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteGoods")]
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += bll.Delete(Convert.ToInt32(arr[i]));
            }
            return result;
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGoodsTypes")]
        public List<GoodsTypes> GetGoodsTypes()
        {
            var result = bll.GetGoodsTypes();
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryGoods")]
        public PageBox Query(int pageIndex = 1,int pageSize=3, string Name = "",int TId=0,int SId=0,int isUse=-1)
        {
            var list = bll.Query();
            if (!string.IsNullOrWhiteSpace(Name))
                list = list.Where(m => m.Name.Contains(Name)).ToList();
            if(TId!=0)
                list = list.Where(m => m.TId.Equals(TId)).ToList();
            if (SId != 0)
                list = list.Where(m => m.SId.Equals(SId)).ToList();
            if (isUse != -1)
                list = list.Where(m => m.IsUse.Equals(isUse)).ToList();
            PageBox page = new PageBox
            {
                PageIndex = pageIndex,
                PageCount = list.Count / pageSize + (list.Count % pageSize > 0 ? 1 : 0),
                Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            return page;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryByIdGoods")]
        public Goods QueryById(int Id)
        {
            var result = bll.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateGoods")]
        public int Update(Goods t)
        {
            var result = bll.Update(t);
            return result;
        }
    }
}
