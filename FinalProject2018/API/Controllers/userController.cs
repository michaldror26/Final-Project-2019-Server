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
using Newtonsoft.Json.Linq;

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

        // GET: api/getAllUsers
        [HttpGet]
        [Route("getAllUsers")]
        public List<SiteUser> GetAllUsers()
        {
            return service.getAllUsers();
        }

        [HttpDelete]
        // DELETE: api/user/5
        public void Delete(int id)
        {
            service.DeleteUser(id);
        }

        [HttpPost]
        [Route("login")]
        //public int Login([FromBody]string userName, [FromBody]string password)
        public User Login(SiteUser siteUser)
        {
            //string userName = HttpContext.Current.Request.Form["userName"];
            //string password = HttpContext.Current.Request.Form["password"];
            return service.Login(siteUser);
        }

        [HttpPost]
        [Route("register")]
        public User Register([FromBody]JObject data)
        {
            string userName = data["userName"].ToString();
            int userId = data["userId"].ToObject<int>();
            string password = data["password"].ToString();
            int authType = data["authType"].ToObject<int>();

            return service.RegisterUpdateUser(userName, password, authType, userId);
        }
    }
}
