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
    [Table("sale_order_product")]
    public class SaleOrderProduct
    {
        [Key]
        [Column(Order = 1)]
        public int SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Amount { get; set; }
    }
}
