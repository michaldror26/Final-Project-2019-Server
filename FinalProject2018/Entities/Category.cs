using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        //[ForeignKey("ParentCategory")]
        public int ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
