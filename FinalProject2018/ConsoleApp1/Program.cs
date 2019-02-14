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

            BIService biService = new BIService();
            Dictionary<string, int> d= biService.saleValueByCategories();
            foreach (var item in d)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
