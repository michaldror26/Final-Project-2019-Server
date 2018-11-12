using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class EmployeeService : BaseService
    {
        public List<Employee> GetAllEmployeers()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }
    }
}
