using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public string Remark { get; set; }
        public virtual List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
       


    }
}
