using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;


namespace BLL
{
    public class UserSiteService : BaseService
    {

        public User getUser(string userName, string password)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(su => su.UserName.Equals(userName));
            if (siteUser == null)
                throw new Exception("שם משתמש שגוי");
            if (!siteUser.Password.Equals(password))
                throw new Exception("סיסמה שגויה");
            User user= getUser(siteUser);
            if (user != null)
                return user;
            throw new Exception("המשתמש לא נמצא");

        }

        public User getUser(int siteUserId)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(su => su.Id==siteUserId);
            User user = getUser(siteUser);
            if (user != null)
                return user;
            throw new Exception("המשתמש לא נמצא");

        }


        public virtual User getUser(SiteUser siteUser)
        {
            if (siteUser.AuthenticationTypeId == 1)
            {
                Admin admin = db.Admins.FirstOrDefault(a => a.SiteUserId == siteUser.Id);
                if (admin != null)
                    return admin;
            }
            if (siteUser.AuthenticationTypeId == 2)
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.SiteUserId == siteUser.Id);
                if (customer != null)
                    return customer;
            }
            else if (siteUser.AuthenticationTypeId == 3)
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.SiteUserId == siteUser.Id);
                if (employee != null)
                    return employee;
            }
            return null;
        }

        //yyy!! public virtual User getCustomerById(int userId) {return getCustomerById(userId) };

        //yyy!! public User getIncludeSiteUser(int userId)
        //yyy!! {
        //yyy!!     getCustomerById(int id);
        //yyy!! }

        //change to voig and send email;
        public void ChangePassword(string userName)
        {

            string newPass = randStr(8);
            //  db.Entry(siteUser).State = EntityState.Modified;
            SiteUser siteUser = getSiteUser(userName);
            if(siteUser==null)
                throw new Exception("שם משתמש שגוי");

            siteUser.Password = newPass;
            db.SaveChanges();
       }
     

        public SiteUser getSiteUser(string userName)
        {
            return db.SiteUsers.FirstOrDefault(u => u.UserName.Equals(userName));
        }


        public void DeleteSiteUser(int id)
        {
            SiteUser siteUser = db.SiteUsers.FirstOrDefault(su => su.Id == id);
            db.SiteUsers.Remove(siteUser);
        }

        //public User RegisterUpdateUser(String userName, String password, int authType, int userId)//userId = id of customer or employee
        //{
        //    //User user = db.Customers.Include("SiteUser").FirstOrDefault(c=>c.userId);
        //    //return RegisterUpdateUser(userName,password,authType,)

        //}

        public User RegisterUpdateUser(String userName, String password, int authType, User user)//user = customer or employee
        {

            if (getSiteUser(userName) != null)
            {
                throw new Exception("שם משתמש אינו מורשה");
            }

            SiteUser siteUser = new SiteUser() { UserName = userName, Password = password, AuthenticationTypeId = authType };
            siteUser.JoiningDate = DateTime.Now;

            try
            {
                user.SiteUser = siteUser;              
                db.SiteUsers.Add(siteUser);
               // customer.SiteUserId = siteUser.Id;
                db.SaveChanges();
            }

            catch (Exception e)
            {
                throw new Exception("לא הצלחנו לרשום אותך למערכת");
            }
            //yyy  User user = getUser(userName, password);
            //yyy  //update user with siteUserId
            //yyy  return updateUserWithSiteUserId(siteUser, userId);
            return user;

        }

        private User updateUserWithSiteUserId(SiteUser site_User, int userId)
        {
            if (site_User != null)
            {
                if (site_User.AuthenticationTypeId == 1)
                    return (new CustomerService()).UpdateCustomerSiteUserId(site_User.Id, userId);
                else
                 if (site_User.AuthenticationTypeId == 2)
                    return (new EmployeeService()).UpdateEmployeeSiteUserId(site_User.Id, userId);
            }
            return null;

        }


        public void ForgetUserName()
        {

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
    }
}
