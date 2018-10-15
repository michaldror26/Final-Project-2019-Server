using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : User
    {
        //איך לעשות ירושה ע"י : או ע"י קוד משתמש
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public virtual User User { get; set; }
        
        public DateTime JoiningDate { get; set; }
        public int DiscountPercentage { get; set; }
        public virtual List<SaleOrder> SaleOrders { get; set; }
        public virtual List<SaleShippingCertificate> SaleShippingCertificates { get; set; }
        public virtual List<CustomerPayment> CustomerPayments { get; set; }



    }
}
