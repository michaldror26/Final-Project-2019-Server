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
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Required field!")]
        public float SellingPrice { get; set; }

        public  string Image { get; set; }
       
    }
}
