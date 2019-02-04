using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        [Route("includeSiteUser/{customerId}")]
        public Customer getCustomerIncludeiteUserById(int customerId)
        {
            return service.getCustomerIncludeSiteUserById(customerId);
        }

        // POST: api/customer/editCustomer
        [HttpPost]
        [Route("editCustomer")]
        public Customer EditCustomer([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join("\n", ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage));
                throw new HttpListenerException(500, message);
            }
            return service.EditCustomer(customer);
        }

        // DELETE: api/customer/DeleteCustomer/5
        [HttpDelete]
        [Route("deleteCustomer")]
        public Customer DeleteCustomer(int id)
        {
            return service.DeleteCustomer(id);
        }

        // ADD: api/customer/AddCustomer
        [HttpPut]
        [Route("addCustomer")]
        public Customer AddCustomer([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join("\n", ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage));
                throw new HttpListenerException(500, message);
            }
            return service.AddCustomer(customer);
        }
    }
}
