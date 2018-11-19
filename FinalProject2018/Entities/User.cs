using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("user")]
    public abstract class User
    {
        [RegularExpression(@"[A-Za-zא-ת]+",
        ErrorMessage = "First name can contain only letters")]
        [Required(ErrorMessage = "Required field!")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-zא-ת]+",
        ErrorMessage = "First name can contain only letters")]
        [Required(ErrorMessage = "Required field!")]
        public string LastName { get; set; }

        [RegularExpression(@"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/",
                  ErrorMessage = "MobilePhone is not valid")]
        [Required(ErrorMessage = "Required field!")]
        public string MobilePhone { get; set; }

        [RegularExpression(@"/\(?([0-9]{0,2,3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/",
                   ErrorMessage = "Telephone is not valid")]
        public string Telephone { get; set; }

        public string City { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Required field!")]
        public string Email { get; set; }
    }

    [Table("site_user")]
    public class SiteUser 
    {
        [Key]
        public int SiteUserId { get; set; }
       

        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[NotMapped]
        //public string ConfirmPassword { get; set; }

        public DateTime JoiningDate { get; set; }

        [ForeignKey("AuthenticationType")]
        public int AuthenticationTypeId { get; set; }
        public virtual AuthenticationType AuthenticationType { get; set; }
    }
}
