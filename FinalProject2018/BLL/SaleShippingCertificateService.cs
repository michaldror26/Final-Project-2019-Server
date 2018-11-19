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
    public class SaleShippingCertificateService : BaseService
    {
        public List<SaleShippingCertificate> GetAllSaleShippingCertificates()
        {
            return db.SaleShippingCertificates.ToList();
        }

        public List<SaleShippingCertificate> GetAllSaleShippingCertificatesOfCustomer(int customerId)
        {
            return db.SaleShippingCertificates
                .Where(saleShippingCertificates => saleShippingCertificates.CustomerId == customerId)
                .ToList();
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו

        }
        public SaleShippingCertificate GetSaleShippingCertificateById(int id)
        {
            return db.SaleShippingCertificates.FirstOrDefault(e => e.SaleShippingCertificateId == id);
            //לבדוק אם מביא גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
        }

        public void AddSaleShippingCertificate(SaleShippingCertificate saleShippingCertificate)
        {
            db.SaleShippingCertificates.Add(saleShippingCertificate);
            //לבדוק אם מכניס גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
            db.SaveChanges();
        }

        public void DeleteSaleShippingCertificate(int id)
        {
            SaleShippingCertificate saleShippingCertificate = db.SaleShippingCertificates.FirstOrDefault(c => c.SaleShippingCertificateId == id);
            db.SaleShippingCertificates.Remove(saleShippingCertificate);
            //לבדוק אם מוחק גם את כל הרשימה של המוצרים לטבלת מוצרים שנרכשו
            db.SaveChanges();
        }

        public void EditSaleShippingCertificate(SaleShippingCertificate saleShippingCertificate)
        {

        }

        #region toCheckIfItNeeded
        public void EditSaleShippingCertificateProduct(SaleShippingCertificateProduct saleShippingCertificateProduct)
        {

        }

        public void DeleteSaleShippingCertificateProduct(int saleShippingCertificateProductId)
        {

        }
        public void EditSaleShippingCertificateProduct(int saleShippingCertificateProductId)
        {

        }
        #endregion
    }
}
