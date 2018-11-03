using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    class SaleOrderService : BaseService
    {
        public void finishOrder(int custId, List<SaleOrderProduct> lst)
        {
            Customer cust=null;//= getCustomerById(custId);
            SaleOrder so = new SaleOrder();
            so.Date = DateTime.Now;
            so.Customer = cust;
            so.CustomerId = custId;
            so.Remark = "Done by customer";
            so.SaleOrderProducts = lst;

            cust.SaleOrders.Add(so);

        }

        public SaleOrder getSaleOrderById(int id)
        {
            return db.SaleOrders.FirstOrDefault(u => u.SaleOrderId == id);
        }

        public List<SaleOrder> getSiteUserById()
        {
            return db.SaleOrders.ToList();
        }

    }
}
