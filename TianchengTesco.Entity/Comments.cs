using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TianchengTesco.Entity
{
    /// <summary>
    /// 评论表
    /// </summary>
   public class Comments
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public int OId { get; set; }
        /// <summary>
        /// 回复
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [NotMapped]
        public int UId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        [NotMapped]
        public int GId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [NotMapped]
        public string UName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [NotMapped]
        public string GName { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        [NotMapped]
        public int State { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        [NotMapped]
        public int SId { get; set; }
    }
}
