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
        [RegularExpression(@"[A-Za-zא-ת1-9 ]+",
        ErrorMessage = "שם פרטי יכול להכיל רק אותיות אנגלית ועברית או מספרים")]
        [Required(ErrorMessage = "שם פרטי הוא שדה חובה")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-z1-9 א-ת]+",
        ErrorMessage = "שם משפחה יכול להכיל רק אותיות אנגלית ועברית או מספרים")]
        [Required(ErrorMessage = "שם משפחה הוא שדה חובה!")]
        public string LastName { get; set; }

        [RegularExpression(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})",
                  ErrorMessage = "מס נייד אינו תקין")]
        [Required(ErrorMessage = "מספר נייד הוא שדה חובה!")]
        public string MobilePhone { get; set; }

        [RegularExpression(@"0\d-\d{7}",
                   ErrorMessage = "מספר טלפון אינו חוקי")]
        public string Telephone { get; set; }

        public string City { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "מייל אינו חוקי")]
        [Required(ErrorMessage = "שדה מייל הוא שדה חובה!")]
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
