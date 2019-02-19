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
    public class BIService : BaseService
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

        public Dictionary<string, int> saleByCategories()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            int sum;

            sum = saleByCategory("אתרוגים");
            ret.Add("אתרוגים", sum);

            sum = saleByCategory("לולבים");
            ret.Add("לולבים", sum);

            sum = saleByCategory("ערבות");
            ret.Add("ערבות", sum);

            sum = saleByCategory("הדסים");
            ret.Add("הדסים", sum);

            return ret;
        }


        public object saleByCustomers()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();

            //בהמשך לסנן לקוחות ע"פ עונה
            List<Customer> customers = db.Customers.ToList();
            var result = from c in customers
                         join so in lso on c.CustomerId equals so.CustomerId
                         where so.Date.Year == DateTime.Now.Year
                         select so into so1
                         join sop in lsop on so1.SaleOrderId equals sop.SaleOrderId
                         group new { so1.Customer, sop.Amount } by so1.Customer into g
                         select new
                         {
                             customer = g.Key.FirstName + " " + g.Key.LastName,
                             amount = g.Sum(gg => gg.Amount)
                         };

            foreach (var item in result)
            {
                ret.Add(item.customer, item.amount);
            }

            return ret;
        }


        private int saleByCategory(string categoryName)
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
