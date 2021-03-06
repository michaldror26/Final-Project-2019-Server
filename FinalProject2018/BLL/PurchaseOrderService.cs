﻿using System;
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
        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            return db.PurchaseOrders.ToList();
        }

        public List<PurchaseOrder> GetAllPurchaseOrdersOfCustomer(int providerId)
        {
            return db.PurchaseOrders
                .Where(purchaseOrders => purchaseOrders.ProviderId == providerId)
                .ToList();
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו

        }
        public PurchaseOrder GetPurchaseOrderById(int id)
        {
            return db.PurchaseOrders.FirstOrDefault(po => po.ID == id);
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
        }

        public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            db.PurchaseOrders.Add(purchaseOrder);
            //לבדוק אם מכניס גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
           // db.SaveChanges();
        }

        public void DeletePurchaseOrder(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.FirstOrDefault(po=>po.ID == id);
            db.PurchaseOrders.Remove(purchaseOrder);
            //לבדוק אם מוחק גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
            db.SaveChanges();
        }

        public void EditPurchaseOrder(PurchaseOrder purchaseOrder)
        {

        }

        #region toCheckIfItNeeded
        public void EditPurchaseOrderProduct(PurchaseOrderProduct purchaseOrderProduct)
        {

        }

        public void DeletePurchaseOrderProduct(int purchaseOrderProductId)
        {

        }
        public void EditPurchaseOrderProduct(int purchaseOrderProductId)
        {

        }
        #endregion
    }
}