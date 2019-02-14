using Entities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BIService:BaseService
    {
        ProductService pService;
        List<SaleOrder> lso;
        List<SaleOrderProduct> lsop;

        public BIService()
        {
            pService = new ProductService();
            lso = db.SaleOrders.ToList();
            lsop = db.SaleOrderProducts.ToList();
        }

        public Dictionary<string, int> saleValueByCategories()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            int sum;

            sum = saleValueByCategory("אתרוגים");
            ret.Add("אתרוגים", sum);

            sum = saleValueByCategory("לולבים");
            ret.Add("לולבים", sum);

            sum = saleValueByCategory("ערבות");
            ret.Add("ערבות", sum);

            sum = saleValueByCategory("הדסים");
            ret.Add("הדסים", sum);

            return ret;
        }
          

        private int saleValueByCategory(string categoryName)
        {
            List<Product> products = pService.getAllProduct(categoryName);
            int sum = (from p in products
                       join sop in lsop on p.ProductId equals sop.ProductId
                       select sop into sop1
                       join so in lso on sop1.SaleOrderId equals so.SaleOrderId
                       where so.Date.Year == DateTime.Now.Year
                       select sop1.Amount).ToList().Sum();
            return sum;
        }
    }
}
