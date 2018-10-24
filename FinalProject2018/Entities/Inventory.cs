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
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        public int ProductId { get; set; }

        [Key]
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Amount { get; set; }
    }
}
