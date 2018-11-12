using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entities
{
    [Table("purchase_shipping_certificate_product")]
    public class PurchaseShippingCertificateProduct
    {
        [Key]
        [Column(Order = 1)]
        public int PurchaseShippingCertificateId { get; set; }
        public virtual PurchaseShippingCertificate PurchaseShippingCertificate { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "PricePerProduct must be positive")]
        public float PricePerProduct { get; set; }


    }
}
