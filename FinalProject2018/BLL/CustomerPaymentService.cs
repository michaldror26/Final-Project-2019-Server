using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace BLL
{
    public class CustomerPaymentService : BaseEntityService<CustomerPayment>
    {
        public override CustomerPayment get(int id)
        {
            return db.CustomerPayments.FirstOrDefault(cp => cp.ID == id);
        }

        public override List<CustomerPayment> getAll()
        {
            return db.CustomerPayments.ToList();
        }

        public override void add(CustomerPayment customerPayment)
        {
            db.CustomerPayments.Add(customerPayment);
            db.SaveChanges();
        }
        

        public void DeleteCustomerPayment(int id)
        {
            CustomerPayment customerPayment = db.CustomerPayments.FirstOrDefault(cp => cp.ID == id);
            db.CustomerPayments.Remove(customerPayment);
            db.SaveChanges();
        }

        public void EditCustomerPayment(CustomerPayment customerPayment)
        {

        }

        public override void delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
