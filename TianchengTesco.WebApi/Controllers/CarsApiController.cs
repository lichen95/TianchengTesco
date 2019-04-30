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
    public class CarsApiController : ApiController
    {
        CarsBLL bll = new CarsBLL();
        public const int PAGESIZE =6;
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCars")]
        public int Add(Cars t)
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
        [Route("DeleteCars")]
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
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryCars")]
        public PageBox Query(int pageIndex=1,int UId=0)
        {
            var list = bll.Query();
            if (UId != 0)
            {
                list = list.Where(m => m.UId.Equals(UId)).ToList();
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
        [Route("QueryByIdCars")]
        public Cars QueryById(int Id)
        {
            var result = bll.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UpdateCars")]
        public int Update(int Id,int Nums)
        {
            var t = QueryById(Id);
            t.Nums = Nums;
            var result = bll.Update(t);
            return result;
        }
    }
}
