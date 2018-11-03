using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class CategoryService : BaseService
    {
        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category getCategoryrById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            //לוודא שאין תת-קטגוריה שתלויה בו
            db.Categories.Remove(category);
        }
    }
}
