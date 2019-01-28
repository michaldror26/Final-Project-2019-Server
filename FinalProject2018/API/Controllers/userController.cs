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

        public static User CurrentUser
        {
            get
            {
                var session = HttpContext.Current.Session;
                if (session != null)
                {
                    if (session["User"] == null)
                        throw new Exception("required login");//session["User"] = getUserFromDB(userName, password);//redirect To Login
                    return session["User"] as User;
                }
                return null;
            }
        }

        public UserController()
        {
            service = new UserSiteService();
        }


        // GET: api/user
        //  [HttpGet]
        //  [Route("getAllUsers")]
        // public List<SiteUser> GetAllUsers()
        // {
        //      return service.getAllUsers();
        //  }


        // PUT: api/user/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/user/5
        //  public void Delete(int id)
        //  {
        //     service.DeleteUser(id);
        //  }

        [HttpGet]
        [Route("login")]
        public User Login(string userName, string password)

        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                try
                {
                    User user = service.getUser(userName, password);
                    session["User"] = user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return CurrentUser;
                // return service.getUser(userName, password);
            }
            return null;
        }

        [HttpPost]
        [Route("logout")]
        public void Logout()

        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                session.Remove("user");
            }
        }


        [HttpGet]
        [Route("changePassword")]
        public string CangePassword(string userName)
        {
            return service.ChangePassword(userName);
        }


        [HttpPost]
        [Route("register")]
        public int Register(SiteUser registerUser, int userId)
        {
            //return service.Register(registerUser, userId);
            return 0;
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
