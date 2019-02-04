using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CurrentUser
    {
        public static User currentUser
        {
            get
            {
                var session = HttpContext.Current.Session;
                if (session != null)
                {
                    if (session["User"] == null)
                        throw new Exception("required login");//redirect To Login
                    return session["User"] as User;
                }
                return null;
            }
        }
    }
}