using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using API.Models;

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

        // GET: api/Order/customer:id
      
        [Route("GetAllSaleOrders")]
        public List<SaleOrder> GetAllSaleOrders()
        {
            return soService.GetAllSaleOrders();
        }
       
        [Route("customer/{id:int}")]
        public List<SaleOrder> Get(int id)
        {
            return soService.GetAllSaleOrdersOfCustomer(id);
        }
        // GET: api/Order/:id
        [Route("GetOrder/{id:int}")]
        public SaleOrder GetOrder(int id)
        {
            return soService.GetSaleOrder(id);
        }

        // POST: api/Order/customer
        [HttpPost()]
        [Route("customer")]
        public void Post([FromBody()]List<SaleOrderProduct> products)
        {

            //ישתנה כשנשנה ל ID
            try
            {
                SaleOrder so;
                so = new SaleOrder((CurrentUser.currentUser as Customer).ID, products, "");
                soService.AddSaleOrder(so);
            }
            catch (Exception e)
            {
                //new CustomerService().getCustomerById()
            }

        }

        // POST: api/Order/customer/id
        [HttpPost()]
        [Route("customer/{id}")]
        public SaleOrder Post([FromUri()] int id, [FromBody()]List<SaleOrderProduct> products)
        {
            SaleOrder so = new SaleOrder(id, products, "");
           return soService.AddSaleOrder(so);
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
