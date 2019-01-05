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
        public Customer getCustomerById(int id)
        {
            return service.getCustomerById(id);
        }

        // POST: api/customer
        [HttpPost]
        [Route("editCustomer")]
        public bool EditCustomer([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.AddCustomer(customer);
                return true;
            }
            return false;
        }

        // DELETE: api/user/DeleteCustomer/5
        [HttpGet]
        [Route("deleteCustomer")]
        public bool DeleteCustomer(int id)
        {
            service.DeleteCustomer(id);
            return true;
        }

        // ADD: api/user/AddCustomer
        [HttpPost]
        public bool AddCustomer([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.AddCustomer(customer);
                return true;
            }
            return false;
        }
    }
}
