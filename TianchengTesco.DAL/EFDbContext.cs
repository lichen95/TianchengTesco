using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using System.Data.Entity;

namespace TianchengTesco.DAL
{
   /// <summary>
   /// EF上下文
   /// </summary>
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("name=conn")
        {
            Database.SetInitializer<EFDbContext>(null);
        }
        /// <summary>
        /// 权限表
        /// </summary>
        public DbSet<Permissions> Permissions { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Roles> Roles { get; set; }
        /// <summary>
        /// 权限角色关联表
        /// </summary>
        public DbSet<PermissionsandRoles> PermissionsandRoles { get; set; }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// 用户角色关联表
        /// </summary>
        public DbSet<UsersandRoles> UsersandRoles { get; set; }
        /// <summary>
        /// 店铺表
        /// </summary>
        public DbSet<Stores> Stores { get; set; }
        /// <summary>
        /// 商品表
        /// </summary>
        public DbSet<Goods> Goods { get; set; }
        /// <summary>
        /// 商品类型表
        /// </summary>
        public DbSet<GoodsTypes> GoodsTypes { get; set; }
        /// <summary>
        /// 购物车
        /// </summary>
        public DbSet<Cars> Cars { get; set; }
        /// <summary>
        /// 订单表
        /// </summary>
        public DbSet<Orders> Orders { get; set; }
        /// <summary>
        /// 前台用户表
        /// </summary>
        public DbSet<UserInfos> UserInfos { get; set; }
        /// <summary>
        /// 评论表
        /// </summary>
        public DbSet<Comments> Comments { get; set; }
    }
}
