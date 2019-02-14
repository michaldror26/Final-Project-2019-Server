using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("api/bi")]
    [EnableCors("*", "*", "*")]
    public class BIController : ApiController
    {
        BIService service;
        public BIController()
        {
            service = new BIService();
        }

        // GET: api/bi/saleValue
        [HttpGet]
        [Route("saleValue")]
        public Dictionary<string,int> GetAllCustomers()
        {
            return service.saleValueByCategories();
        }
    }
}
