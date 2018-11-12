using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;


namespace BLL
{
    public class UserSiteService : BaseService
    {
        public User getUserByUserName(string userName)
        {
            return db.Users.FirstOrDefault(u => u.SiteUser.UserName.Equals(userName));
        }

        public User getUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserId == id);
        }


        public User Login(String userName, string password)
        {
            User user = getUserByUserName(userName);
            if (user == null)
                return null;
            if (!user.SiteUser.Password.Equals(password))
                return null;
            return user;
        }

        public void ForgetUserName()
        {
            
        }

        public void ForgetPassword(string userName)
        {
            User user = getUserByUserName(userName);
            string newPass = randStr(5); ;
            user.SiteUser.Password = newPass;
            //send an email
        }

        private string randStr(int n)
        {
            string str = string.Empty;
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < n; i++)
            {
                str += chars[rand.Next(0, chars.Length)];
            }
            return str;
        }
        public int ChangePassword(User user, string prevPass, string newPass1, string newPass2)
        {
            //User user = getSiteUserById(userId);
            //if (!user.Password.Equals(prevPass))
            //    return -1;
            //if (!newPass1.Equals(newPass2))
            //    return -2;
            //user.Password = newPass1;
            //return 0;
        }


    }
}
