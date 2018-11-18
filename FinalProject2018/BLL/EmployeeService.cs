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
            return db.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(c => c.EmployeeId == id);
            db.Employees.Remove(employee);
        }

        public void EditEmployee(Employee employee)
        {

        }
        public void UpdateEmployeeSiteUserId(int siteUserId)
        {

        }
    }
}