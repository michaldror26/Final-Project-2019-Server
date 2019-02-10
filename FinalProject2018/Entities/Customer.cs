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
    [Table("customer")]
    public class Customer : User
    {
        [Key]
        public int CustomerId { get; set; }
        //public int SiteUserId { get; set; }
        //public virtual SiteUser siteUser { get; set; }

        public DateTime RegisteredDate { get; set; }

        [DefaultValue(0)]
        public int DiscountPercentage { get; set; }

        public virtual List<SaleOrder> SaleOrders { get; set; }
        public virtual List<SaleShippingCertificate> SaleShippingCertificates { get; set; }
        public virtual List<CustomerPayment> CustomerPayments { get; set; }
    }
}
