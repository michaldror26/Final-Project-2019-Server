using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("orderProduct")]
    class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
      //  public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Amount { get; set; }

        [Column("parsed_price")]
        public int parsedPrice { get; set; }
    }
}
