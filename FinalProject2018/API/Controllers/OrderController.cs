using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;

namespace API.Controllers
{
    [RoutePrefix("api/order")]
    [EnableCors("*", "*", "*")]
    public class OrderController : ApiController
    {
        SaleOrderService soService;
        PurchaseOrderService poService;

        public OrderController()
        {
            soService = new SaleOrderService();
            poService = new PurchaseOrderService();
        }

        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost()]
        [Route("customer/{id:int}")]
        public void Post([FromUri()] int id, [FromBody()]List<SaleOrderProduct> products)
        {
            SaleOrder so = new SaleOrder(id, products, "");
            soService.AddSaleOrder(so);
        }

        [HttpPost()]
        [Route("customer")]
        public void Post([FromBody()]List<SaleOrderProduct> products)
        {
            SaleOrder so = new SaleOrder((UserController.CurrentUser as Customer).CustomerId, products, "");
            soService.AddSaleOrder(so);
        }

        [HttpPost()]
        [Route("provider/{id:int}")]
        public void Post([FromUri()] int id, [FromBody()]List<PurchaseOrderProduct> products)
        {
            PurchaseOrder po = new PurchaseOrder(id, products, "");
            poService.AddPurchaseOrder(po);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
