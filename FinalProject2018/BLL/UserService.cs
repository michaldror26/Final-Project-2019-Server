using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DAL;
using Entities;


namespace BLL
{
    public class UserService:BaseService
    {
        //TO DO
        //static public ModelStorManagment ctx = new ModelStorManagment();


        public SiteUser getSiteUserByUserName(string userName)
        {
            return db.SiteUser.FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public SiteUser getSiteUserById(int id)
        {
            return db.SiteUser.FirstOrDefault(u => u.UserSiteId == id);
        }
  
        public int AuthenticationById(int id)
        {
            SiteUser user = getSiteUserById(id);
            return user.AuthenticationTypeId;
        }

        public int login(String userName, string password)
        {
            SiteUser user = getSiteUserByUserName(userName);
            if (user == null)
                return -1;
            if (!user.Password.Equals(password))
                return -2;
            return user.UserSiteId;
        }

        public void forgetUserName()
        { }
        
        public void forgetPassword(int id)
        {
            SiteUser user = getSiteUserById(id);
            string newPass = string.Empty;
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < 5 ; i++)
            {
                newPass += chars[rand.Next(0, chars.Length)];
            }
            //שליחת מייל
        }

        public int changePassword(int userId, string prevPass, string newPass1, string newPass2 )
        {
            SiteUser user = getSiteUserById(userId);
            if (!user.Password.Equals(prevPass))
                return -1;
            if (!newPass1.Equals(newPass2))
                return -2;
            user.Password = newPass1;
            return 0;
        }

   
}
