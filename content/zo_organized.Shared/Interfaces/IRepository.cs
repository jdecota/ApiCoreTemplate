﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zo_organized.Shared.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
