using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace BLL
{
    public class PurchaseOrderService : BaseService
    {
        CustomerService customerService = new CustomerService();

        public void finishOrder(int custId, List<PurchaseOrderProduct> lst)
        {
            //Provider p = CustomerService.getCustomerById(custId);
            //PurchaseOrder po = new PurchaseOrder();
            //p.Date = DateTime.Now;
            //p.Provider = cust;
            //p.CustomerId = custId;
         
            //p.SaleOrderProducts = lst;

            //p.PurchaseOrders.Add(po);

        }
    }
}
