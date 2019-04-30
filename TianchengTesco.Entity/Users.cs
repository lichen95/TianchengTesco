using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 后台用户表
    /// </summary>
   public class Users
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RolesIds { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RolesNames { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsUse { get; set; }
    }
}
