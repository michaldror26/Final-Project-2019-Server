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
            return service.GetAllCustomers();
        }

        // PUT: api/customer/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/user/5
        public void Delete(int id)
        {
            service.DeleteCustomer(id);
        }
        
        #region old
        public EmployeeService employeeService = new EmployeeService();
        
        //public IEnumerable<string> Get()
        //{
        //    return Em;
        //}

        // GET: api/test/5
        //public AuthenticationType Get(int id)
        //{
        //    return employeeService.GetEmployeeById(1);
        //}

        // POST: api/test
        public void Post([FromBody]string value)
        {
        }
       
        #endregion
    }
}
