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
    [Table("sale_shipping_certificate_product")]
    public class SaleShippingCertificateProduct
    {
        [Key]
        public int SaleShippingCertificateId { get; set; }
        public virtual SaleShippingCertificate SaleShippingCertificate { get; set; }
        //[Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }
        [Range(1, float.MaxValue, ErrorMessage = "PricePerProduct must be positive")]
        public float PricePerProduct { get; set; }
    }
}
