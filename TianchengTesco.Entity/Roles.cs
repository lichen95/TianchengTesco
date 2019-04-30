using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
   public class Roles
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionsIds { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionsNames { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsUse { get; set; }
    }
}
