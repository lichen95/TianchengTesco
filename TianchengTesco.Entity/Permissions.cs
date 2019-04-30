using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permissions
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 页面URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsUse { get; set; }
    }
}
