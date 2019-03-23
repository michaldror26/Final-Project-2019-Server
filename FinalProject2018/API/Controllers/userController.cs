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
using System.Web.SessionState;

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
            // HttpSessionState session = HttpContext.Current.Session;
            try
            {
                User user = service.getUser(siteUser.UserName, siteUser.Password);
                HttpContext.Current.Session.Add("User", user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CurrentUser.currentUser;
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
        [HttpPost]
        [Route("changePassword")]
        public string changePassword(string userName)
        {
            MailViaGmailService mailService = new MailViaGmailService();
            UserSiteService userSiteService = new UserSiteService();
            SiteUser siteUser = userSiteService.getSiteUser(userName);
            if (siteUser != null)
            {
                User user = userSiteService.getUser(siteUser.ID);
                if (user != null)
                {
                    if (user.Email != null)
                    {
                        mailService.sendPasswordToCustomer(user.Email, user.FirstName + " " + user.LastName);
                        return "הסיסמא נשלחה לכתובת המייל שלך";
                    }
                    else
                    {
                        return "אין ברשותינו מידע על כתובת המייל שלך עבורו נשלח לך את סיסמתך למערכת<br> שלח בקשה למערכת לאיפוס סיסמתך<br>ואנו ניצור עימך קשר בהקדם";
                    }
                }
                else
                {
                    return "לא קיים משתמש בעל שם זה";
                }
            }
            else
            {
                return "לא קיים משתמש בעל שם זה";
            }
        }

    }
}
