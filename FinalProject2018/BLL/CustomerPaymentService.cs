using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace BLL
{
    public class CustomerPaymentService : BaseService
    {
        public List<CustomerPayment> GetAllCustomerPayments()
        {
            return db.CustomerPayments.ToList();
        }

        public CustomerPayment getCustomerPaymentById(int id)
        {
            return db.CustomerPayments.FirstOrDefault(c => c.CustomerPaymentId == id);
        }

        public void AddCustomerPayment(CustomerPayment customerPayment)
        {
            db.CustomerPayments.Add(customerPayment);
        }

        public void DeleteCustomerPayment(int id)
        {
            CustomerPayment customerPayment = db.CustomerPayments.FirstOrDefault(c => c.CustomerPaymentId == id);
            db.CustomerPayments.Remove(customerPayment);
        }

        public void EditCustomerPayment(CustomerPayment customerPayment)
        {

        }
    }
}
