using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BLL
{
    public class UserSiteService : BaseService
    {
        private SiteUser getSiteUser(string userName)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(u => u.UserName.Equals(userName));
            if (siteUser == null)
                throw new Exception("888");
            return siteUser;
        }

        public User getUser(string userName, string password)
        {
            SiteUser siteUser = db.SiteUsers.Include("user")
                .FirstOrDefault(u => u.UserName.Equals(userName));
            if (siteUser == null)
                throw new Exception("888");
            if (!siteUser.Password.Equals(password))
                throw new Exception("999");

            if (siteUser.AuthenticationTypeId == 2)
                return siteUser.User as Customer;

            return siteUser.User;
        }
        

        //  public List<User> getAllUsers() { }


        //  public User getUser(int id) {}

        private void AddSiteUser(SiteUser user)
        {

            db.SiteUsers.Add(user);

        }

        public void DeleteSiteUser(int id)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(c => c.SiteUserId == id);
            db.SiteUsers.Remove(siteUser);
        }

        public void EditUser(User user)
        {

        }


        public void ForgetUserName()
        {

        }

        //change to voig and send email;
        public string ChangePassword(string userName)
        {

            string newPass = randStr(8);
            SiteUser siteUser = null;
            //  db.Entry(siteUser).State = EntityState.Modified;
            try
            {
                siteUser = getSiteUser(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            siteUser.Password = newPass;
            db.SaveChanges();

            new SmtpClient("smtp.server.com", 25).Send("yehuditravina@gmail.com",
                                           "yr0548494662@gmail.com",
                                           "subject",
                                           "body");
            return siteUser.Password;
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
            //זה פשוט קיוקוו
            //User user = getSiteUserById(userId);
            //if (!user.Password.Equals(prevPass))
            //    return -1;
            //if (!newPass1.Equals(newPass2))
            //    return -2;
            //user.Password = newPass1;
            return 0;
        }


    }
}
