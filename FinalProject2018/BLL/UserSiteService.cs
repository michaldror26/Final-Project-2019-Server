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
        public SiteUser getUserByUserName(string userName)
        {
            return db.SiteUsers.FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public SiteUser getUserByUserNameAndPass(string userName, string userPassword)
        {
            return db.SiteUsers.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(userPassword));
        }

        public List<SiteUser> getAllUsers()
        {
            return db.SiteUsers.ToList();
        }

        public SiteUser getUserById(int id)
        {
            return db.SiteUsers.FirstOrDefault(u => u.SiteUserId == id);
        }

        public void AddUser(SiteUser user)
        {
            db.SiteUsers.Add(user);
        }

        public void DeleteUser(int id)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(c => c.SiteUserId == id);
            db.SiteUsers.Remove(siteUser);
        }

        public void EditUser(User user)
        {

        }


        public int Login(String userName, String password)
        {
            SiteUser siteUser = getUserByUserName(userName);
            if (siteUser != null)
                if (siteUser.Password.Equals(password))
                    return siteUser.SiteUserId;
            return -1;
        }
        public int Register(SiteUser siteUser, int userId)
        {
            db.SiteUsers.Add(siteUser);
            int siteUserId = Login(siteUser.UserName, siteUser.Password);
            if (siteUser.AuthenticationType.AuthName == "Customer")
                (new CustomerService()).UpdateCustomerSiteUserId(siteUserId);
            else
                 if (siteUser.AuthenticationType.AuthName == "Employee")
                (new EmployeeService()).UpdateEmployeeSiteUserId(siteUserId);
            return userId;
        }

        public void ForgetUserName()
        {

        }

        public void ForgetPassword(string userName)
        {
            SiteUser user = getUserByUserName(userName);
            string newPass = randStr(5); ;
            //user.SiteUser.Password = newPass;קיווקו 
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
