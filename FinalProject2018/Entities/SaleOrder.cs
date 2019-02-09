using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("sale_order")]
    public class SaleOrder
    {
        public SaleOrder() { }
        public SaleOrder(int customerId, List<SaleOrderProduct> products,string remark) {
            this.Date = DateTime.Now;
            this.CustomerId = customerId;
            this.SaleOrderProducts = products;
            this.Remark = remark;
        }
        [Key]
        public int SaleOrderId { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string Remark { get; set; }
        public virtual List<SaleOrderProduct> SaleOrderProducts { get; set; }
       // public virtual List<OrderProduct> orderProducts { get; set; }

    }
}
