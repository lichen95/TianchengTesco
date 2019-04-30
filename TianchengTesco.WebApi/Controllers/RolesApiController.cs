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
    public class RolesApiController : ApiController
    {
        RolesBLL bll = new RolesBLL();
        public const int PAGESIZE = 3;
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRoles")]
        public int Add(string Name,string PermissionsIds,string PermissionsNames,int IsUse)
        {
            Roles t = new Roles
            {
                Name = Name,
                PermissionsIds = PermissionsIds,
                PermissionsNames = PermissionsNames,
                IsUse = IsUse
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
        [Route("DeleteRoles")]
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
        [Route("QueryRoles")]
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
        [Route("QueryByIdRoles")]
        public Roles QueryById(int Id)
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
        [Route("UpdateRoles")]
        public int Update(int Id,string Name, string PermissionsIds, string PermissionsNames, int IsUse)
        {
            Roles t = new Roles
            {
                Id = Id,
                Name = Name,
                PermissionsIds = PermissionsIds,
                PermissionsNames = PermissionsNames,
                IsUse = IsUse
            };
            var result = bll.Update(t);
            return result;
        }
        /// <summary>
        /// 获取所有启用角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoles")]
        public List<Roles> GetRoles()
        {
            var result = bll.Query().Where(m => m.IsUse == 1).ToList();
            return result;
        }
    }
}
