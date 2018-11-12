using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Entities;

namespace API.Controllers
{
    public class userController : ApiController
    {
        public EmployeeService employeeService = new EmployeeService();
        // GET: api/test
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

        // PUT: api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/test/5
        public void Delete(int id)
        {
        }
    }
}
