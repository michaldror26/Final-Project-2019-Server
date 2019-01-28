using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public float SellingPrice { get; set; }

        public float Image { get; set; }

        public int Amount { get; set; }
    }
}
