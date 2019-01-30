using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entities
{
    [Table("employee")]
    public class Employee: User
    {
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey("SiteUser")]
        [DefaultValue(2)]
        public Nullable<int> SiteUserId { get; set; }
        public virtual SiteUser SiteUser { get; set; }

        public string Role { get; set; }
        public float Salary { get; set; }
        public virtual List<EmployeeSchedule> EmployeeSchedules { get; set; }

      

    }
}
