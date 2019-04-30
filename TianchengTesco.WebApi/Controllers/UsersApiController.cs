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
    public class UsersApiController : ApiController
    {
        UsersBLL bll = new UsersBLL();
        public const int PAGESIZE = 3;
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUsers")]
        public int Add(string UName,string Pwd,string Name,string Sex,int Age,string Phone,string Email,string RolesIds,string RolesNames,int SId,int IsUse)
        {
            Users t = new Users
            {
                UName = UName,
                Pwd=Pwd,
                Name=Name,
                Sex=Sex,
                Age=Age,
                Phone=Phone,
                Email=Email,
                RolesIds=RolesIds,
                RolesNames=RolesNames,
                SId=SId,
                IsUse=IsUse
            };
            var result = bll.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteUsers")]
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
        [Route("QueryUsers")]
        public PageBox Query(int pageIndex = 1, string Name = "")
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
        [Route("QueryByIdUsers")]
        public Users QueryById(int Id)
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
        [Route("UpdateUsers")]
        public int Update(int Id,string UName, string Pwd, string Name, string Sex, int Age, string Phone, string Email, string RolesIds, string RolesNames, int SId, int IsUse)
        {
            Users t = new Users
            {
                Id=Id,
                UName = UName,
                Pwd = Pwd,
                Name = Name,
                Sex = Sex,
                Age = Age,
                Phone = Phone,
                Email = Email,
                RolesIds = RolesIds,
                RolesNames = RolesNames,
                SId = SId,
                IsUse = IsUse
            };
            var result = bll.Update(t);
            return result;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LoginByAdmin")]
        public string Login(string Name, string Pwd)
        {
            var result = bll.Login(Name, Pwd);
            return result;
        }
    }
}
