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
    public class UserInfosApiController : ApiController
    {
        UserInfosBLL bll = new UserInfosBLL();
        public const int PAGESIZE = 3;
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUserInfos")]
        public int Add(UserInfos t)
        {
            var result = bll.Add(t);
            return result;
        }

        /// <summary>
        /// 用户删号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteUserInfos")]
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
        /// 用户登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LoginByUserInfos")]
        public int Login(string Name, string Pwd)
        {
            var result = bll.Login(Name, Pwd);
            return result;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryUserInfos")]
        public PageBox Query(int pageIndex=1,string Name="")
        {
            var list = bll.Query();
            if (!string.IsNullOrWhiteSpace(Name))
                list = list.Where(m => m.Name.Contains(Name)).ToList();
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
        [Route("QueryByIdUserInfos")]
        public UserInfos QueryById(int Id)
        {
            var result = bll.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UpdateUserInfos")]
        public int Update(UserInfos t)
        {
            var result = bll.Update(t);
            return result;
        }
    }
}
