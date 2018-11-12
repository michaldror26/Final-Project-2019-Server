using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("employee")]
    public class Employee: User
    {
        [Key]
        public int EmployeeId { get; set; }
        [ForeignKey("SiteUser")]
        public int SiteUserId { get; set; }
        public string Role { get; set; }
        public float Salary { get; set; }
        public virtual List<EmployeeSchedule> EmployeeSchedules { get; set; }

      

    }
}
