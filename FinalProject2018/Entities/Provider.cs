using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("provider")]
    public class Provider: User
    {
        public int ID { get; set; }

        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual List<PurchaseShippingCertificate> PurchaseShippingCertificates { get; set; }
    }
}
