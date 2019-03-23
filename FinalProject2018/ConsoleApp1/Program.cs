using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity.Validation;
using System.IO;
using BLL;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CategoryService cs = new CategoryService();
            //SaleOrderProduct ps = new SaleOrderProduct();
            BIService bs = new BIService();
            //List<Product> ps= ps.getAllProducts();
            // var g=lp.GroupBy(x => cs.GetParentCategory(x.Category, 1)).ToList();
            var g= bs.saleByCustomers();
            foreach (var item in g)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);

            }



            Console.ReadLine();
        }
    }
}
