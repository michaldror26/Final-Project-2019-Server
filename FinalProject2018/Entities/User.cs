using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }

    public class SiteUser : User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }
        public int AuthenticationTypeId { get; set; }
        public virtual AuthenticationType AuthenticationType { get; set; }
    }
}
