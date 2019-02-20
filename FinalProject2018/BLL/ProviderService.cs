using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace BLL
{
    public class ProviderService : BaseEntityService<Provider>
    {
        public override List<Provider> getAll()
        {
            return tabel.ToList();
        }

        public override Provider get(int id)
        {
            return tabel.FirstOrDefault(p => p.ID == id);
        }

        public override void add(Provider provider)
        {
            tabel.Add(provider);
            db.SaveChanges();
        }

        public override void delete(int id)
        {
            Provider provider = tabel.FirstOrDefault(p => p.ID == id);
           tabel.Remove(provider);
            db.SaveChanges();
        }

        public void EditProvider(Provider provider)
        {

        }
    }
}
