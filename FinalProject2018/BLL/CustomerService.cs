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
        public override int add(BaseService val)
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerById(int id)
        {
            return db.SiteUser.FirstOrDefault(u => u.UserSiteId == id);
        }

        public void finishOrder(int custId, List<SaleOrderProduct> lst)
        {
            Customer cust = getCustomerById(custId);
            SaleOrder so = new SaleOrder();
            so.Date = DateTime.Now;
            so.Customer = cust;
            so.CustomerId = custId;
            so.Remark = "Done by customer";
            so.SaleOrderProducts = lst;

            cust.SaleOrders.Add(so);
            
        }

        public getSaleOrdersById(int id)
        {

        }

    }
}
