using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianchengTesco.IDAL
{
    public interface IDALBase<T> where T:class,new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Add(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T QueryById(int Id);
    }
}
