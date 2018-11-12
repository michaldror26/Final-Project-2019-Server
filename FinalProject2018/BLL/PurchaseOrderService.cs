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
        public void finishOrder(int custId, List<PurchaseOrderProduct> lst)
        {
            Provider p = null;//= getCustomerById(custId);
            PurchaseOrder po = new PurchaseOrder();
            po.Date = DateTime.Now;
            po.Provider = cust;
            po.CustomerId = custId;
         
            po.SaleOrderProducts = lst;

            p.PurchaseOrders.Add(po);

        }
    }
}
