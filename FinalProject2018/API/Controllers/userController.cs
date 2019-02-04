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
using API.Models;

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

        [HttpDelete]
        // DELETE: api/user/5
        public void Delete(int id)
        {
            service.DeleteSiteUser(id);
        }

        [HttpPost]
        [Route("login")]
        public User Login(SiteUser siteUser)

        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                try
                {
                    User user = service.getUser(siteUser.UserName, siteUser.Password);
                    session["User"] = user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return CurrentUser.currentUser;

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


        //[HttpPost]
        //[Route("register")]
        //public User Register([FromBody]JObject data)
        //{
        //    string userName = data["userName"].ToString();
        //    int userId = data["userId"].ToObject<int>();
        //    string password = data["password"].ToString();
        //    int authType = data["authType"].ToObject<int>();

        //    //return service.RegisterUpdateUser(userName, password, authType, userId);
        //    return new Customer();
        //}
    }
}
