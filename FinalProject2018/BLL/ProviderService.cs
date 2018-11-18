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
            return db.Providers.FirstOrDefault(e => e.ProviderId == id);
        }

        public void AddProvider(Provider provider)
        {
            db.Providers.Add(provider);
        }

        public void DeleteProvider(int id)
        {
            Provider provider = db.Providers.FirstOrDefault(c => c.ProviderId == id);
            db.Providers.Remove(provider);
        }

        public void EditProvider(Provider provider)
        {

        }
    }
}
