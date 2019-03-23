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

        //GET: api/bi/sale/product
       [HttpGet]
       [Route("sale/product")]
        public Dictionary<string,int> GetSaleByProduct()
        {
              return service.saleByCategories();
        }

        //GET: api/bi/sale/amount/product
        [HttpGet]
        [Route("sale/amount/product")]
        public Dictionary<string, int> GetAmountSaleByProduct()
        {
            return service.amountSaleByCategories();
        }

        // GET: api/bi/sale/customer
        [HttpGet]
        [Route("sale/customer")]
        public object GetSaleByCustomer()
        {  
            return service.saleByCustomers();
        }

        // GET: api/bi/sale/amount/customer
        [HttpGet]
        [Route("sale/amount/customer")]
        public object GetAmountSaleByCustomer()
        {
            return service.amountSaleByCustomers();
        }

        // GET: api/bi/sale/month
        [HttpGet]
        [Route("sale/month")]
        public object GetSaleByMonth()
        {
            return service.saleByMonth();
        }

        // GET: api/bi/sale/amount/month
        [HttpGet]
        [Route("sale/amount/month")]
        public object GetAmountSaleByMonth()
        {
            return service.amountSaleByMonth();
        }

        // GET: api/bi/sale/2019/month
        [HttpGet]
        [Route("sale/{year:int}/month")]
        public object GetSaleByMonth(int year)
        {
            return service.amountSaleByMonth(year);
        }

        // GET: api/bi/sale/2019/amount/month
        [HttpGet]
        [Route("sale/{year:int}/amount/month")]
        public object GetAmountSaleByMonth(int year)
        {
            return service.amountSaleByMonth(year);
        }

    }
}
