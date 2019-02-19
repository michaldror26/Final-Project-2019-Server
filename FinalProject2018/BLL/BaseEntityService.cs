using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BaseEntityService<T>:BaseService
    {
        public abstract T get(int id);
        public abstract List<T> getAll();
        public abstract void add(T item);

    }
}
