using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;

namespace TianchengTesco.IDAL
{
   public interface IUsers:IDALBase<Users>
    {
        List<Users> Query();
        string Login(string Name, string Pwd);
    }
}
