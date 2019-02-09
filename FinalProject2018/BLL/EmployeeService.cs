﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class EmployeeService : BaseService
    {
        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(e => e.Id == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {

        }
        public Employee UpdateEmployeeSiteUserId(int siteUserId, int empId)
        {
            Employee employee = db.Employees.FirstOrDefault(emp => emp.Id == empId);
           //yyy if (employee != null) { employee.SiteUserId = siteUserId; }
            return employee;
        }
    }
}
