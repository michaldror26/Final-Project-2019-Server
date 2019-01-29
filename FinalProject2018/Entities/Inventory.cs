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
    [Table("inventory")]
    class Inventory
    { 
        [Key]
        public int InventoryId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
