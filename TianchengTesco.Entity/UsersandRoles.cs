using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
   public class UsersandRoles
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolesId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UsersId { get; set; }
    }
}
