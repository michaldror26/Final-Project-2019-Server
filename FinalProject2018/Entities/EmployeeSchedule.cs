using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmployeeSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime EnterDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
        public string EnterPlace { get; set; }
        public string Exitaplace { get; set; }
    }
}
