using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("authentication_type")]
   public class AuthenticationType
    {
        [Key]
        public int AuthenticationTypeId { get; set; }
        public string  AuthName { get; set; }
        public virtual List<SiteUser> SiteUsers { get; set; }
    }
}
