﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entities
{
    [Table("purchase_order_product")]
    public class PurchaseOrderProduct
    {
        [Key]
        [Column(Order = 1)]
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Amount { get; set; }

    }
}
