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
    public class StoresApiController : ApiController
    {
        StoresBLL bll = new StoresBLL();
        public const int PAGESIZE = 3;
        /// <summary>
        /// 新增店铺
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddStores")]
        public int Add(Stores t)
        {
            var result = bll.Add(t);
            return result;
        }

        /// <summary>
        /// 删除店铺
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteStores")]
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
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryStores")]
        public PageBox Query(int pageIndex = 1, string StoresName = "")
        {
            var list = bll.Query();
            if (!string.IsNullOrWhiteSpace(StoresName))
                list = list.Where(m => m.StoresName.Contains(StoresName)).ToList();
            PageBox page = new PageBox
            {
                PageIndex = pageIndex,
                PageCount = list.Count / PAGESIZE + (list.Count % PAGESIZE > 0 ? 1 : 0),
                Data = list.Skip((pageIndex - 1) * PAGESIZE).Take(PAGESIZE)
            };
            return page;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryByIdStores")]
        public Stores QueryById(int Id)
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
        [Route("UpdateStores")]
        public int Update(Stores t)
        {
            var result = bll.Update(t);
            return result;
        }
        /// <summary>
        /// 获取所有店铺
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStores")]
        public List<Stores> GetStores()
        {
            var result = bll.Query();
            return result;
        }
    }
}
