﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianchengTesco.Entity;

namespace TianchengTesco.IDAL
{
   public interface IStores:IDALBase<Stores>
    {
        List<Stores> Query();
    }
}
