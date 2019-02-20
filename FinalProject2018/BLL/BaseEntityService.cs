using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BaseEntityService<T>:BaseService where T : class
    {
        public BaseEntityService()
        {
            this._tabel = db.Set<T>();
        }
        private DbSet<T> _tabel;
        internal virtual DbSet<T> tabel { get { return _tabel; } }
        public abstract T get(int id);
        public abstract List<T> getAll();
        public abstract void add(T item);
        public abstract void delete(int id);
        //public abstract void edit(T item);
    }
}
