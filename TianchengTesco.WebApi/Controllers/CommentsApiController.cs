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
    public class CommentsApiController : ApiController
    {
        CommentsBLL bll = new CommentsBLL();
        OrdersBLL orderBLL = new OrdersBLL();
        public const int PAGESIZE = 5;
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddComments")]
        public int Add(Comments t)
        {
            var result = bll.Add(t);
            if (result > 0)
            {
               var o= orderBLL.QueryById(t.OId);
                o.State = 5;
                var s = orderBLL.Update(o);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteComments")]
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
        [Route("QueryComments")]
        public PageBox Query(int pageIndex = 1,string UName="",string GName="",int GId=0,int SId=0)
        {
            var list = bll.Query();
            if (!string.IsNullOrWhiteSpace(UName))
                list = list.Where(m => m.UName.Contains(UName)).ToList();
            if (!string.IsNullOrWhiteSpace(GName))
                list = list.Where(m => m.GName.Contains(GName)).ToList();
            if (GId!=0)
                list = list.Where(m => m.GId.Equals(GId)).ToList();
            if (SId != 0)
                list = list.Where(m => m.SId.Equals(SId)).ToList();
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
        [Route("QueryByIdComments")]
        public Comments QueryById(int Id)
        {
            var result = bll.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateComments")]
        public int Update(Comments t)
        {
            var result = bll.Update(t);
            return result;
        }
    }
}
