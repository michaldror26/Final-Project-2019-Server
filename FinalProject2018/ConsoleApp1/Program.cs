using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using System.Data.Entity.Validation;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            ModelStorManagment modelStorManagment = new ModelStorManagment();
            AuthenticationType authenticationType = new AuthenticationType() { AuthenticationTypeId = 1, AuthName = "manager" };
            SiteUser user = new SiteUser() { UserId = 1258754, FirstName = "חיים", LastName = "כהן", MobilePhone = "0548466708", Telephone = "036191438", Email = "chaim@gmail.com", City = "bney brak", Password = "15987452", JoiningDate = new DateTime(),UserName="chaimke",UserSiteId=1, AuthenticationTypeId= authenticationType.AuthenticationTypeId };

            modelStorManagment.Users.Add(user);
            try
            {
                modelStorManagment.SaveChanges();
            }
            catch (DbEntityValidationException e1)
            {
                var v = e1.EntityValidationErrors.First().ValidationErrors;
            }

        }
    }
}
