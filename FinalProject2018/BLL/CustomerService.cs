using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    class CustomerService : BaseService
    {
        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer getCustomerById(int id)
        {
            return db.Customers.FirstOrDefault(u => u.CustomerId == id);
        }
    }
}
