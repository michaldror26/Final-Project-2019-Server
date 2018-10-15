﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public virtual Category ParentCategory { get; set; }
  
        public virtual List<Product> Products { get; set; }
      
    }
}
