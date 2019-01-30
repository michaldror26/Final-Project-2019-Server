using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
                customer.RegisteredDate = DateTime.Now;
                db.Customers.Add(customer);
                db.SaveChanges();
                if (customer.SiteUser != null)
                {
                    (new UserSiteService()).RegisterUpdateUser(customer.SiteUser.UserName, customer.SiteUser.Password, 2, customer.CustomerId);
                }
                return customer;//TODO return real from db
            }
            catch (DbEntityValidationException e)
            {
                var errorMessage = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        //errorMessage.Append(string.Format("Property: {0}, Error: {1}",
                        //    ve.PropertyName, ve.ErrorMessage));
                        errorMessage.Append(string.Format("{0} \n", ve.ErrorMessage));
                    }
                }
                throw new DbEntityValidationException(errorMessage.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
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
            try
            {
                var entity = db.Customers.Find(customer.CustomerId);
                if (entity == null)
                {
                    return null;
                }
                db.Entry(entity).CurrentValues.SetValues(customer);
                db.SaveChanges();
                if(customer.SiteUser != null)
                {
                    (new UserSiteService()).RegisterUpdateUser(customer.SiteUser.UserName, customer.SiteUser.Password, 2, customer.CustomerId);
                }
                return customer;
            }
            catch (DbEntityValidationException e)
            {
                var errorMessage = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        //errorMessage.Append(string.Format("Property: {0}, Error: {1}",
                        //    ve.PropertyName, ve.ErrorMessage));
                        errorMessage.Append(string.Format("{0} \n", ve.ErrorMessage));
                    }
                }
                throw new DbEntityValidationException(errorMessage.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer UpdateCustomerSiteUserId(int siteUserId, int cusId)
        {
            Customer c = db.Customers.FirstOrDefault(cus => cus.CustomerId == cusId);
            if (c != null) { c.SiteUserId = siteUserId; }
            return c;
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
