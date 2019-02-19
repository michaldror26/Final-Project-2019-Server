using Entities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BIService : BaseService
    {
        ProductService pService;
        CategoryService cService;
        IEnumerable<SaleOrder> lso;
        IEnumerable<SaleOrderProduct> lsop;

        public BIService()
        {
            pService = new ProductService();
            cService = new CategoryService();
            lso = db.SaleOrders;
            lsop = db.SaleOrderProducts.Include("Product");
        }
 
        public Dictionary<string, int> saleByCategories()
        {
             Dictionary<string, int> ret = new Dictionary<string, int>();
            int sum;

          //  var ret = db.SaleOrderProducts.Include("Product").Include("Product.Category").Include("SaleOrder")
          //      .Where(so => so.SaleOrder.Date.Year == DateTime.Now.Year)
          //      .GroupBy(sop => cService.GetParentCategory(sop.Product.Category, ancestor).Name)
          //      .Select(c => new KeyValuePair<string, float>(c.Key, c.Sum(sop => sop.Product.SellingPrice * sop.Amount)))
          //      .ToList();
          //List<KeyValuePair<string,float>> ret1= ret.ToList();

            sum = saleByCategory("אתרוגים");
            ret.Add("אתרוגים", sum);

            sum = saleByCategory("לולבים");
            ret.Add("לולבים", sum);

            sum = saleByCategory("ערבות");
            ret.Add("ערבות", sum);

            sum = saleByCategory("הדסים");
            ret.Add("הדסים", sum);

            ret.OrderBy(kvp => kvp.Value);

            return ret;
        }

        public Dictionary<string, int> amountSaleByCategories()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            int sum;

            //  var ret = db.SaleOrderProducts.Include("Product").Include("Product.Category").Include("SaleOrder")
            //      .Where(so => so.SaleOrder.Date.Year == DateTime.Now.Year)
            //      .GroupBy(sop => cService.GetParentCategory(sop.Product.Category, ancestor).Name)
            //      .Select(c => new KeyValuePair<string, float>(c.Key, c.Sum(sop => sop.Product.SellingPrice * sop.Amount)))
            //      .ToList();
            //List<KeyValuePair<string,float>> ret1= ret.ToList();

            sum = amountSaleByCategory("אתרוגים");
            ret.Add("אתרוגים", sum);

            sum = amountSaleByCategory("לולבים");
            ret.Add("לולבים", sum);

            sum = amountSaleByCategory("ערבות");
            ret.Add("ערבות", sum);

            sum = amountSaleByCategory("הדסים");
            ret.Add("הדסים", sum);

            ret.OrderBy(kvp => kvp.Value);

            return ret;
        }

        public Dictionary<string, int> saleByCustomers()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();

            //בהמשך לסנן לקוחות ע"פ עונה
            IEnumerable<Customer> customers = db.Customers;
            var result = from c in customers
                         join so in lso on c.ID equals so.CustomerId
                         where so.Date.Year == DateTime.Now.Year
                         select so into so1
                         join sop in lsop on so1.ID equals sop.SaleOrderId
                         group new { so1.Customer, sop.Product.SellingPrice, sop.Amount } by so1.Customer into g
                         select new
                         {
                             customer = g.Key.FirstName + " " + g.Key.LastName,
                             sum = g.Sum(gg => gg.SellingPrice * gg.Customer.DiscountPercentage/100*gg.Amount)
                         };

            foreach (var item in result)
            {
                ret.Add(item.customer, (int)item.sum);
            }

            ret.OrderBy(r => r.Value);
            return ret;
        }

        public Dictionary<string, int> amountSaleByCustomers()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();

            //בהמשך לסנן לקוחות ע"פ עונה
            IEnumerable<Customer> customers = db.Customers;
            var result = from c in customers
                         join so in lso on c.ID equals so.CustomerId
                         where so.Date.Year == DateTime.Now.Year
                         select so into so1
                         join sop in lsop on so1.ID equals sop.SaleOrderId
                         group new { so1.Customer, sop.Product.SellingPrice, sop.Amount } by so1.Customer into g
                         select new
                         {
                             customer = g.Key.FirstName + " " + g.Key.LastName,
                             sum = g.Sum(gg =>gg.Amount)
                         };

            foreach (var item in result)
            {
                ret.Add(item.customer, (int)item.sum);
            }

            ret.OrderBy(r => r.Value);
            return ret;
        }

        public float cartAverage(int month, int year)
        {


            float avg = (from so in lso
                         join sop in lsop on so.ID equals sop.SaleOrderId
                         where so.Date.Year == year
                         && so.Date.Month == month
                         select sop.Amount * sop.Product.SellingPrice).ToList().Average();
            return avg;

        }

        public IEnumerable<int> saleByMonth()
        {
            return saleByMonth(DateTime.Now.Year);
        }

        public IEnumerable<int> amountSaleByMonth()
        {
            return saleByMonth(DateTime.Now.Year);
        }

        public IEnumerable<int> saleByMonth(int year)
        {
            
            int[] month = new int[] { 1,2,3,4,5,6,7,8,9,10,11,12 };

            
            var lsg = from so in lso
                      where so.Date.Year == year
                      join sop in lsop on so.ID equals sop.SaleOrderId
                      group new{sop, so.Customer} by so.Date.Month into g
                      select new
                      {
                          g.Key,
                          sum = (int)g.Sum(gg => gg.sop.Product.SellingPrice *gg.Customer.DiscountPercentage/100* gg.sop.Amount)
                      };
          

            var result = from m in month
                         from g in lsg.Where(gg => gg.Key == m).DefaultIfEmpty()
                         select g != null ? g.sum : 0;

            


            return result;
        }

        public IEnumerable<int> amountSaleByMonth(int year)
        {

            int[] month = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


            var lsg = from so in lso
                      where so.Date.Year == year
                      join sop in lsop on so.ID equals sop.SaleOrderId
                      group new { sop.Amount} by so.Date.Month into g
                      select new
                      {
                          g.Key,
                          sum = (int)g.Sum(gg => gg.Amount)
                      };


            var result = from m in month
                         from g in lsg.Where(gg => gg.Key == m).DefaultIfEmpty()
                         select g != null ? g.sum : 0;




            return result;
        }

        private int saleByCategory(string categoryName)
        {
            List<Product> products = pService.getAllProduct(categoryName);
            float sum = (from p in products
                         join sop in lsop on p.ID equals sop.ProductId
                         select sop into sop1
                         join so in lso on sop1.SaleOrderId equals so.ID
                         where so.Date.Year == DateTime.Now.Year                
                         select sum = sop1.Product.SellingPrice *so.Customer.DiscountPercentage/100*sop1.Amount
                         ).ToList().Sum();
            return (int)sum;
        }


        private int amountSaleByCategory(string categoryName)
        {
            List<Product> products = pService.getAllProduct(categoryName);
            float sum = (from p in products
                         join sop in lsop on p.ID equals sop.ProductId
                         select sop into sop1
                         join so in lso on sop1.SaleOrderId equals so.ID
                         where so.Date.Year == DateTime.Now.Year
                         select sum = sop1.Amount
                         ).ToList().Sum();
            return (int)sum;
        }
        //private List<SaleOrder> getAllSalesByMonth(int month, int year)
        //{
        //from so in lso
        //join sop in lsop on so.ID equals sop.SaleOrderId
        //where so.Date.Year == year
        //&& so.Date.Month == month
        //select sop.Amount * sop.Product.SellingPrice


        // }

    }
}
