using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using Entities;

namespace API.Controllers
{
    [RoutePrefix("api/customer")]
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        private CustomerService service;
        
        public CustomerController()
        {
            service = new CustomerService();
        }

        // GET: api/customer
        [HttpGet]
        [Route("getAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return service.GetAllCustomers().ToList();
        }

        // GET: api/customer/getCustomerById/5
        [HttpGet]
        public Customer getCustomerById(int id)
        {
            return service.getCustomerById(id);
        }

        // POST: api/customer
        [HttpPost]
        [Route("editCustomer")]
        public Customer EditCustomer([FromBody]Customer customer)
        {
            //if (ModelState.IsValid)
            //{
                return service.EditCustomer(customer);
           // }
            //return null;
        }

        // DELETE: api/user/DeleteCustomer/5
        [HttpDelete]
        [Route("deleteCustomer")]
        public Customer DeleteCustomer(int id)
        {
            return service.DeleteCustomer(id);
        }

        // ADD: api/user/AddCustomer
        [HttpPut]
        [Route("addCustomer")]
        public Customer AddCustomer([FromBody]Customer customer)
        {
            //if (ModelState.IsValid)
            //{
                return service.AddCustomer(customer);
            //}
            //return null;
        }
    }
}
