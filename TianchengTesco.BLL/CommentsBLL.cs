using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;
using TianchengTesco.IDAL;

namespace TianchengTesco.BLL
{
   public class CommentsBLL : IBLLBase<Comments>
    {
        public static string typeName = "CommentsDAL";
        public IComments iComments;
        public CommentsBLL() : base(typeName)
        {
            iComments = (IComments)idal;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Comments t)
        {
            var result = iComments.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var result = iComments.Delete(Id);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Comments> Query()
        {
            var result = iComments.Query();
            return result;
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Comments QueryById(int Id)
        {
            var result = iComments.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Comments t)
        {
            var result = iComments.Update(t);
            return result;
        }
    }
}
