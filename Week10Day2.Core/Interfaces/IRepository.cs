using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day2.Core.Interfaces
{
    public interface IRepository<T>
    {
        T Insert(T item);
    }
}
