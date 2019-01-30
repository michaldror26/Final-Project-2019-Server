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


        public void DeleteUser(int id)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(c => c.SiteUserId == id);
            db.SiteUsers.Remove(siteUser);
        }

        public void EditUser(User user)
        {
         
        }
        private User gerUserBySiteUserId(SiteUser siteUser)
        {
            if (siteUser.AuthenticationTypeId == 1)
            {
                return db.Customers.FirstOrDefault(c => c.SiteUserId == siteUser.SiteUserId);
            }
            else if (siteUser.AuthenticationTypeId == 2)
            {
                return db.Employees.FirstOrDefault(c => c.SiteUserId == siteUser.SiteUserId);
            }
            return null;
        }
        public User Login(String userName, String password)
        {
            SiteUser siteUser = getUserByUserName(userName);
            if (siteUser != null)
                if (siteUser.Password.Equals(password))
                    return gerUserBySiteUserId(siteUser);
            throw new Exception("שם משתמש או סיסמא שגויים");
        }

        public User RegisterUpdateUser(String userName, String password, int authType, int userId)//userId = id of customer or employee
        {
            SiteUser site_user = getUserByUserNameAndPass(userName, password);
            if (site_user != null)
            {
                throw new Exception("קיים כבר שם משתמש וסיסמא זהים");
            }

            SiteUser siteUser = new SiteUser() { UserName = userName, Password = password, AuthenticationTypeId = authType };
            try
            {
                siteUser.JoiningDate = DateTime.Now;
                db.SiteUsers.Add(siteUser);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("לא הצלחנו לרשום אותך למערכת");
            }
            SiteUser site_User = getUserByUserNameAndPass(userName, password);
            //update user with siteUserId
            return updateUserWithSiteUserId(site_User, userId);
        }

        private User updateUserWithSiteUserId(SiteUser site_User, int userId)
        {
            if (site_User != null)
            {
                if (site_User.AuthenticationType.AuthName == "Customer")
                    return (new CustomerService()).UpdateCustomerSiteUserId(site_User.SiteUserId, userId);
                else
                 if (site_User.AuthenticationType.AuthName == "Employee")
                    return (new EmployeeService()).UpdateEmployeeSiteUserId(site_User.SiteUserId, userId);
            }
            return null;

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
