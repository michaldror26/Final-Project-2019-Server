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
    [RoutePrefix("api/inventory")]
    [EnableCors("*", "*", "*")]
    public class InventoryController : ApiController
    {
        InventoryService service;
        public InventoryController()
        {
            service = new InventoryService();
        }

        [HttpGet]
        [Route("getInventory")]
        public List<Inventory> get()
        {
            return service.getInventory();
        }
        
    }
}
