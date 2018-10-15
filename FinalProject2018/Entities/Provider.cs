using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Provider
    {
        //מה לעשות עם הpassword & userName
        public int Id { get; set; }
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual List<PurchaseShippingCertificate> PurchaseShippingCertificates { get; set; }
    }
}
