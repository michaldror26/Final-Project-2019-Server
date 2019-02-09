using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("purchase_order")]
    public class PurchaseOrder
    {
        public PurchaseOrder() { }
        public PurchaseOrder(int providerId, List<PurchaseOrderProduct> products, string remark)
        {
            this.ProviderId = providerId;
            this.PurchaseOrderProducts = products;
            this.Remark = remark;
        }
        [Key]
        public int PurchaseOrderId { get; set; }
        public DateTime Date { get; set; }

       // [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public string Remark { get; set; }
        public string isOrdered { get; set; }
          public virtual List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
        //public virtual List<OrderProduct> PurchaseOrderProducts { get; set; }

    }
}