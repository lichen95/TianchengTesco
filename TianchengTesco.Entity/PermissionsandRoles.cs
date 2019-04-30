using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 权限角色关联表
    /// </summary>
   public class PermissionsandRoles
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PermissionsId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolesId { get; set; }
    }
}
