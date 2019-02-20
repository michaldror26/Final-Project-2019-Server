using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace BLL
{
    public class ProductService : BaseService
    {

        CategoryService cService;

        public ProductService()
        {
            cService = new CategoryService();
        }

        public int getAmountProduct(int id)
        {
            //Product p = db.Products.FirstOrDefault(p1 => p1.ProductId == id);
            //if (p != null)
            //   return p.Amount;
            return 0;
        }

        public List<Product> getAllProducts()
        {
            return db.Products.ToList();
        }


        public List<Product> getAllProduct(int categoryId)
        {
            //List<Category> lstc = cService.GetSubCategories(categoryId);
            //List<Product> lstp = new List<Product>();
            //foreach (Category c in lstc)
            //{
            //    if(c.Products!=null)
            //    lstp.AddRange(c.Products);
            //}
            //return lstp;
            List<Category>lstc=cService.GetSubCategories(categoryId);
            List<Product>lstp= db.Products.ToList();
            List<Product> ret = new List<Product>();
            foreach (Category c in lstc)
            {
               ret.AddRange(lstp.Where(p => p.CategoryId == c.ID).ToList());
            }
            return ret;
        }

        public List<Product> getAllProduct(Category category)
        {
            return getAllProduct(category.ID);
        }
        public List<Product> getAllProduct(string categoryName)
        {
            Category category = cService.get(categoryName);
            return getAllProduct(category.ID);
        }



    }
}
