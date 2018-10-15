using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PurchaseShippingCertificateProduct
    {
        public int PurchaseShippingCertificateId { get; set; }
        public virtual PurchaseShippingCertificate PurchaseShippingCertificate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public float PricePerProduct { get; set; }


    }
}
