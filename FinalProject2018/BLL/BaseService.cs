using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;

namespace BLL
{
    public abstract class BaseService
    {
        public static ModelStorManagment db = new ModelStorManagment();
       // abstract public DbSet<T> tabel { get;  }
    }
}
