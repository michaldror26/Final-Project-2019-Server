using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace BLL
{
    class CustomerPaymentService : BaseService
    {
        public List<CustomerPayment> GetAllCustomerPayments()
        {
            return db.CustomerPayments.ToList();
        }

        public CustomerPayment getCustomerPaymentById(int id)
        {
            return db.CustomerPayments.FirstOrDefault(c => c.CustomerPaymentId == id);
        }
    }
}
