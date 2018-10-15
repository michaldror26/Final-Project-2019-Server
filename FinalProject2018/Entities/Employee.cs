using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        //האם לעשות בצורה של ירושה או ע"י קוד משתמש?
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Role { get; set; }
        public float Salary { get; set; }
        public virtual List<EmployeeSchedule> EmployeeSchedules { get; set; }

    }
}
