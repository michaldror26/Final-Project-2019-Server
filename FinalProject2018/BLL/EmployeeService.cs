using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    class EmployeeService : UserService
    {
        public Employee getEmployeeById(int id)
        {
            return db.SiteUser.FirstOrDefault(u => u.UserSiteId == id);
        }

        public List<EmployeeSchedule> getEmoloyeeSchedule(int id)
        {
            Employee emp = getEmployeeById(id);
            if(emp != null)
            {
                return emp.EmployeeSchedules;
            }
            return null;
        }

        public int enter(int id)
        {
            Employee emp = getEmployeeById(id);
            if (emp == null)
                return -1;

            EmployeeSchedule es = new EmployeeSchedule();
            //צריך לעדכן את ה id או שזה מתעדכן עי האנטיטיז?
            es.EnterDateTime = = DateTime.Now;
            //צריך להוסיף לקיחת מיקום
            emp.EmployeeSchedules.add(es);
            return 0;
        }

        public int exit(int id)
        {
            Employee emp = getEmployeeById(id);
            if (emp == null)
                return -1;
            try
            {
                DateTime exitDate = DateTime.Now;
                if (exitDate > emp.EmployeeSchedules.Last().EnterDateTime)
                    emp.EmployeeSchedules.Last().ExitDateTime = DateTime.Now;
                //צריך להוסיף לקיחת מיקום והשוואה
            }
            catch
            {
                return -1;
            }
            return 0;
        }
    }
}
