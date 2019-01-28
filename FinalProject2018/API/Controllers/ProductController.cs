using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using Entities;

namespace API.Controllers
{
    [RoutePrefix("api/products")]
    [EnableCors("*", "*", "*")]
    public class ProductController : ApiController
    {
        ProductService service;
        public ProductController()
        {
            service = new ProductService();
        }

        [HttpGet]
        [Route("amount/{id}")]
        public int getAmount(int id)
        {
          return  service.getAmountProduct(id);
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public List<Product> getProductsByCategory(int categoryId)
        {
            return service.getAllProduct(categoryId);
        }
    }
}
