using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("sale_shipping_certificate")]
    public class SaleShippingCertificate
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string Remark { get; set; }
        public virtual List<SaleShippingCertificateProduct> SaleShippingCertificateProducts { get; set; }

    }
}
