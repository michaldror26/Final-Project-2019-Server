using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("employee_schedule")]
    public class EmployeeSchedule
    {
        [Key]
        public int EmployeeScheduleId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public DateTime EnterDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
        public string EnterPlace { get; set; }
        public string Exitaplace { get; set; }
    }
}
