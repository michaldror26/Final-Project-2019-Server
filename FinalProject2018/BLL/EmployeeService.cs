using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class EmployeeService : BaseEntityService<Employee>
    {
        public override List<Employee> getAll()
        {
            return tabel.ToList();
        }

        public override Employee get(int id)
        {
            return tabel.FirstOrDefault(e => e.ID == id);
        }

        public override void add(Employee employee)
        {
            tabel.Add(employee);
            db.SaveChanges();
        }

        public override void delete(int id)
        {
            Employee employee = tabel.FirstOrDefault(e => e.ID == id);
            tabel.Remove(employee);
            db.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {

        }
        public Employee UpdateEmployeeSiteUserId(int siteUserId, int empId)
        {
            Employee employee = tabel.FirstOrDefault(e => e.ID == empId);
           //yyy if (employee != null) { employee.SiteUserId = siteUserId; }
            return employee;
        }
    }
}
