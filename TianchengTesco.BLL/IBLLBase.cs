using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Factory;
using TianchengTesco.IDAL;

namespace TianchengTesco.BLL
{
    public class IBLLBase<T> where T:class,new()
    {
        public static IDALBase<T> idal;
        public IBLLBase(string typeName)
        {
            idal = DataAccess<IDALBase<T>>.GetFactory(typeName);
        }
    }
}
