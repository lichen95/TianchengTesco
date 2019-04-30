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
    public class PermissionsApiController : ApiController
    {
        PermissionsBLL bll = new PermissionsBLL();
        public const int PAGESIZE = 3;
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPermissions")]
        public int Add(Permissions t)
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
        [Route("DeletePermissions")]
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
        [Route("QueryPermissions")]
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
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryByIdPermissions")]
        public Permissions QueryById(int Id)
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
        [Route("UpdatePermissions")]
        public int Update(Permissions t)
        {
            var result = bll.Update(t);
            return result;
        }
        /// <summary>
        /// 获取所有启用权限
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permissions> GetPermissions()
        {
            var result = bll.Query().Where(m=>m.IsUse==1).ToList();
            return result;
        }
        /// <summary>
        /// 根据UsersId获取权限
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissionsByUserId")]
        public List<Permissions> GetPermissionsByUserId(int UsersId)
        {
            var result = bll.GetPermissionsByUserId(UsersId).Where(m => m.IsUse == 1).ToList();
            return result;
        }
    }
}
