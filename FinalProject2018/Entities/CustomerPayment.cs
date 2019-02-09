using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("customer_payment")]
    public class CustomerPayment
    {
        [Key]
        public int CustomerPaymentId { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public float amount { get; set; }

        public int circulationMedium  { get; set; }

    }
}
