using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class SaleOrderService : BaseService
    {
        public List<SaleOrder> GetAllSaleOrders()
        {
            return db.SaleOrders.ToList();
        }

        public List<SaleOrder> GetAllSaleOrdersOfCustomer(int customerId)
        {
            return db.SaleOrders
                .Where(saleOrders => saleOrders.CustomerId == customerId)
                .ToList();
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו

        }
        public SaleOrder GetSaleOrderById(int id)
        {
            return db.SaleOrders.FirstOrDefault(e => e.SaleOrderId == id);
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
        }

        public void AddSaleOrder(SaleOrder saleOrder)
        { 
                db.SaleOrders.Add(saleOrder);             
                db.SaveChanges();
        }

        public void DeleteSaleOrder(int id)
        {
            SaleOrder saleOrder = db.SaleOrders.FirstOrDefault(c => c.SaleOrderId == id);
            db.SaleOrders.Remove(saleOrder);
            //לבדוק אם מוחק גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו

            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                db.SaveChanges();
                System.Diagnostics.Debugger.Launch();
            }
        }

        public void EditSaleOrder(SaleOrder saleOrder)
        {

        }

        #region toCheckIfItNeeded
        public void EditSaleOrderProduct(SaleOrderProduct saleOrderProduct)
        {

        }

        public void DeleteSaleOrderProduct(int saleOrderProductId)
        {

        }
        public void EditSaleOrderProduct(int saleOrderProductId)
        {

        }
        #endregion
    }
}
