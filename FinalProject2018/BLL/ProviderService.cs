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
    public class ProviderService : BaseService
    {
        public List<Provider> GetAllProviders()
        {
            return db.Providers.ToList();
        }

        public Provider GetProviderById(int id)
        {
            return db.Providers.FirstOrDefault(p => p.Id == id);
        }

        public void AddProvider(Provider provider)
        {
            db.Providers.Add(provider);
            db.SaveChanges();
        }

        public void DeleteProvider(int id)
        {
            Provider provider = db.Providers.FirstOrDefault(p => p.Id == id);
            db.Providers.Remove(provider);
            db.SaveChanges();
        }

        public void EditProvider(Provider provider)
        {

        }
    }
}
