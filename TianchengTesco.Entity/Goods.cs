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
    /// 商品表
    /// </summary>
   public class Goods
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public int TId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 是否上架
        /// </summary>
        public int IsUse { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [NotMapped]
        public string TName { get; set; }
    }
}
