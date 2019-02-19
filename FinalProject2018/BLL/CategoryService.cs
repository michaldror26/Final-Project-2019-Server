using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class CategoryService : BaseEntityService<Category>
    {
        public override Category get(int id)
        {
            return db.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public override List<Category> getAll()
        {
            return db.Categories.ToList();
        }

        public Category get(string name)
        {
            return db.Categories.FirstOrDefault(c => c.Name == name);
        }

        public override void add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAllCategoriesAndSubCategory()
        {
            return db.Categories.ToList();
        }
        

        public List<Category> GetSubCategories(int categoryId)
        {
            
            List<Category> list = getAll();
            List<Category> ret = new List<Category>();
            foreach (Category c in list)
            {
                if (isSub(c, categoryId))
                    ret.Add(c);
            }
            return ret;
        }

        private bool isSub(Category c, int parentId)
        {
            if (c == null)
                return false;
            if (c.CategoryId == parentId)
                return true;
            return isSub(c.ParentCategory, parentId);

        }

        #region getSubCategoryWay2
        //Category c = db.Categories.Include("Products").FirstOrDefault(c2 => c2.CategoryId ==categoryId);
        //lstc.Add(c);
        //getSub(c.CategoryId);
        //return lstc;

        // private List<Category> lstc=new List<Category>();
        //public List<Category> GetSubCategories(Category category)
        //{
        //    return GetSubCategories(category.CategoryId);
        //}

        //private void getSub(int categoryId)
        //{
        //    List<Category>lst= db.Categories.Include("Products").Where(c => c.ParentCategoryId == categoryId).ToList();
        //    this.lstc.AddRange(lst);
        //    if (lst!=null)
        //    {
        //        foreach (Category c in lst)
        //        {
        //            getSub(c.CategoryId);
        //        }
        //    }
        //}
        #endregion


       

        public void DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            //לוודא שאין תת-קטגוריה שתלויה בו
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void EditCategory(Category category)
        {

        }

      
    }
}
