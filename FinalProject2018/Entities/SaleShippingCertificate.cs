using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SaleShippingCertificate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Remark { get; set; }
        public virtual List<SaleShippingCertificateProduct> SaleShippingCertificateProducts { get; set; }

    }
}
