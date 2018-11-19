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
    public class PurchaseShippingCertificateService : BaseService
    {
        public List<PurchaseShippingCertificate> GetAllPurchaseShippingCertificates()
        {
            return db.PurchaseShippingCertificates.ToList();
        }

        public List<PurchaseShippingCertificate> GetAllPurchaseShippingCertificatesOfCustomer(int providerId)
        {
            return db.PurchaseShippingCertificates
                .Where(purchaseShippingCertificates => purchaseShippingCertificates.ProviderId == providerId)
                .ToList();
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו

        }
        public PurchaseShippingCertificate GetPurchaseShippingCertificateById(int id)
        {
            return db.PurchaseShippingCertificates.FirstOrDefault(e => e.PurchaseShippingCertificateId == id);
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
        }

        public void AddPurchaseShippingCertificate(PurchaseShippingCertificate purchaseShippingCertificate)
        {
            db.PurchaseShippingCertificates.Add(purchaseShippingCertificate);
            //לבדוק אם מכניס גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
            db.SaveChanges();
        }

        public void DeletePurchaseShippingCertificate(int id)
        {
            PurchaseShippingCertificate purchaseShippingCertificate = db.PurchaseShippingCertificates.FirstOrDefault(c => c.PurchaseShippingCertificateId == id);
            db.PurchaseShippingCertificates.Remove(purchaseShippingCertificate);
            //לבדוק אם מוחק גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
            db.SaveChanges();
        }

        public void EditPurchaseShippingCertificate(PurchaseShippingCertificate purchaseShippingCertificate)
        {

        }

        #region toCheckIfItNeeded
        public void EditPurchaseShippingCertificateProduct(PurchaseShippingCertificateProduct purchaseShippingCertificateProduct)
        {

        }

        public void DeletePurchaseShippingCertificateProduct(int purchaseShippingCertificateProductId)
        {

        }
        public void EditPurchaseShippingCertificateProduct(int purchaseShippingCertificateProductId)
        {

        }
        #endregion
    }
}
