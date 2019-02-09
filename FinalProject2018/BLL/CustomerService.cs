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
            return db.Customers.Find(id);
        }

        public Customer getCustomerIncludeSiteUserById(int userId)
        {
          return  db.Customers.Include("SiteUser").FirstOrDefault(c=>c.Id==userId);
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                 if (customer.SiteUser != null)
                {
                    customer.SiteUser.JoiningDate = DateTime.Now;
                    customer.SiteUser.AuthenticationTypeId = 2;
                }

                customer = db.Customers.Add(new Customer
                {
                    City = customer.City,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DiscountPercentage = customer.DiscountPercentage,
                    RegisteredDate = DateTime.Now,
                    MobilePhone = customer.MobilePhone,
                    Telephone = customer.Telephone,
                    SiteUser = customer.SiteUser
                });
               
                db.SaveChanges();
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

        public Customer DeleteCustomer(int id)
        {
            try
            {
                Customer customer = db.Customers.Include("SiteUser").FirstOrDefault(c=>c.Id==id);
           
                db.Customers.Remove(customer);
                if (customer.SiteUser != null)
                    db.SiteUsers.Remove(customer.SiteUser);

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
                Customer entity = db.Customers.Include("SiteUser").FirstOrDefault(c => c.Id == customer.Id);
                if (entity == null)
                {
                    return null;
                }

                db.Entry(entity).CurrentValues.SetValues(customer);

                //לקוח רשום
                if(entity.SiteUser!=null)
                {
                    //עדכון פרטי רישום
                    if(customer.SiteUser!=null)
                      db.Entry(entity.SiteUser).CurrentValues.SetValues(customer.SiteUser);
                    //מחיקת רישום
                    else
                        db.SiteUsers.Remove(entity.SiteUser);
                }
                else
                //לקוח שאינו רשום
                //מעונין להרשם
                    if (customer.SiteUser != null)
                    {
                          entity = (new UserSiteService()).RegisterUpdateUser(customer.SiteUser.UserName, customer.SiteUser.Password, 2, entity) as Customer;
                    }

                    db.SaveChanges();
                return entity;
             
            }
            catch (DbEntityValidationException e)
            {
                var errorMessage = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorMessage.Append(string.Format("{0} \n", ve.ErrorMessage));
                    }
                }
                throw new DbEntityValidationException(errorMessage.ToString());
            }
        }

        public Customer UpdateCustomerSiteUserId(int siteUserId, int cusId)
        {
            Customer c = db.Customers.Find(cusId);
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
