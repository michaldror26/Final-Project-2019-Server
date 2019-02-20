using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return tabel.FirstOrDefault(c => c.ID == id);
        }

        public override List<Category> getAll()
        {
            return tabel.ToList();
        }

        public Category get(string name)
        {
            return tabel.FirstOrDefault(c => c.Name == name);
        }

        public override void add(Category category)
        {
            tabel.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAllCategoriesAndSubCategory()
        {
            return tabel.ToList();
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
            if (c.ID == parentId)
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


       

        public override void delete(int id)
        {
            Category category = tabel.FirstOrDefault(c => c.ID == id);
            //לוודא שאין תת-קטגוריה שתלויה בו
            tabel.Remove(category);
            db.SaveChanges();
        }

        public void EditCategory(Category category)
        {

        }

      
    }
}
