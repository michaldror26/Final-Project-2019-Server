using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class CustomerService : UserSiteService
    {
        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer getCustomerById(int id)
        {
            return db.Customers.FirstOrDefault(u => u.CustomerId == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return customer;//TODO return real from db
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Customer DeleteCustomer(int id)
        {
            try
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.CustomerId == id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Customer EditCustomer(Customer customer)
        {
            //db.Customers.Attach(customer);
            try
            {

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return customer;//TODO return real from db
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void UpdateCustomerSiteUserId(int siteUserId)
        {

        }
        //public List<string> func(User user)
        //{
        //    List<List<string>> ret = new List<List<string>>();
        // //   if(user is Customer)
        //    Customer cust = user as Customer;

        //  List<SaleOrder> soLst=  db.SaleOrders.Where(s => s.CustomerId== 1).ToList();
        //  List<SaleShippingCertificate> ssLst=  db.SaleShippingCertificates.Where(s => s.CustomerId == 1).ToList();

        //    foreach(SaleOrder so in soLst)
        //    {
        //        foreach(SaleOrderProduct sop in so.SaleOrderProducts)
        //        {
        //           foreach(SaleShippingCertificate ss in ssLst)
        //            {
        //                foreach(SaleShippingCertificateProduct ssp in ss.SaleShippingCertificateProducts)
        //                {
        //                    if (sop.ProductId == ssp.ProductId)
        //                        ret.Add();
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
