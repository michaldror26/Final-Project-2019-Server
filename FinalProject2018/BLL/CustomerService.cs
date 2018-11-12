using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    class CustomerService : UserSiteService
    {
        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer getCustomerById(int id)
        {
            return db.Customers.FirstOrDefault(u => u.CustomerId == id);
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
