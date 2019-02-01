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

        public List<Product> getAllProduct()
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
               ret.AddRange(lstp.Where(p => p.CategoryId == c.CategoryId).ToList());
            }
            return ret;
        }

        public List<Product> getAllProduct(Category category)
        {
            return getAllProduct(category.CategoryId);
        }





        //public Product getProductById(int id)
        //{
        //    return db.Products.FirstOrDefault(p => p.ProductId == id);
        //}

        //public List<Product> getAllProductByCategory(Category category)
        //{//עושים את הסינון הזה בקליינט
        //    return db.Products.Where(p => p.Category == category).ToList();
        //}
        //public List<Product> getAllProductByCategory(int category)
        //{//עושים את הסינון הזה בקליינט
        //    return db.Products.Where(p => p.CategoryId == category).ToList();
        //}

        //public List<Product> getAllProductByCategory(string category)
        //{//עושים את הסינון הזה בקליינט
        //    return db.Products.Where(p => p.Category.Name == category).ToList();
        //}


        ////האם יחזיר ליסט של סטרינג או של קטגורי?
        //public List<string> getFullCategory(int id)
        //{
        //    Product p = getProductById(id);
        //    return FullCategory(p.Category);
        //}

        //public Category getMainCategory(int id)
        //{
        //    Product p = getProductById(id);
        //    return FullCategory1(p.Category).First();

        //}

        //private List<string> FullCategory(Category c)
        //{
        //    List<string> lst;
        //    if (c == null)
        //        return new List<string>();

        //  lst=  FullCategory(c.ParentCategory);
        //    lst.Add(c.Name);
        //    return lst;
        //}

        //private List<Category> FullCategory1(Category c)
        //{
        //    List<Category> lst;
        //    if (c == null)
        //        return new List<Category>();

        //    lst = FullCategory1(c.ParentCategory);
        //    lst.Add(c);
        //    return lst;
        //}


    }
}
