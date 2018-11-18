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
    [RoutePrefix("api/user")]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        private UserSiteService service;

        public UserController()
        {
            service = new UserSiteService();
        }

        // GET: api/user
        [HttpGet]
        [Route("getAllUsers")]
        public List<SiteUser> GetAllUsers()
        {
            return service.getAllUsers();
        }

        // PUT: api/user/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/user/5
        public void Delete(int id)
        {
            service.DeleteUser(id);
        }

        [HttpPost]
        [Route("login")]
        public int Login()
        {
            string userName = HttpContext.Current.Request.Form["userName"];
            string password = HttpContext.Current.Request.Form["password"];
            return service.Login(userName, password);
        }

        [HttpPost]
        [Route("register")]
        public int Register(SiteUser registerUser, int userId)
        {
            return service.Register(registerUser, userId);
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
