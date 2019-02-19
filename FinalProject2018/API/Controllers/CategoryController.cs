using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("api/category")]
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        CategoryService service;
        public CategoryController()
        {
            service = new CategoryService();
        }

        [HttpGet]
        [Route("getCategories")]
        public List<Category> getCategores()
        {
             return service.getAll();
        }

        [HttpGet]
        [Route("{id}")]
        public List<Category> getCategores(int id)
        {
            return service.GetSubCategories(id);
        }
        [HttpGet]
        [Route("GetAllCategoriesAndSubCategory")]
        public List<Category> GetAllCategoriesAndSubCategory()
        {
            return service.GetAllCategoriesAndSubCategory();
        }
    }
}
