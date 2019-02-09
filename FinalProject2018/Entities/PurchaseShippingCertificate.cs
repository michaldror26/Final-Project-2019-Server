using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("purchase_shipping_certificate")]
    public class PurchaseShippingCertificate
    {
        [Key]
        public int PurchaseShippingCertificateId { get; set; }
        public DateTime Date { get; set; }

       // [ForeignKey("Provider")]
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        public string Remark { get; set; }
        public virtual List<PurchaseShippingCertificateProduct> PurchaseShippingCertificateProducts { get; set; }
    }
}
