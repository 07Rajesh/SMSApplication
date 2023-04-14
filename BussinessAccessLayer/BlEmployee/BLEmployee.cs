using BussinessAccessLayer.Interface;
using SMSAPI.DBAccess;
using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.BlEmployee
{
   public class BLEmployee: IEmployee
    {
        EmployeeDbAccess employeeDb = new EmployeeDbAccess();

        public async Task<List<Employee>> GetEmployees()
        {
            return employeeDb.GetEmployees();
        }
        public async Task<string> CreateEmployee(Employee employee)
        {
            return employeeDb.CreateEmployee(employee);
        }
        public async Task<string> DeleteEmployee(int id)
        {
            return employeeDb.DeleteEmployee(id);
        }
        public async Task<string> UpdateEmployee(Employee employee)
        {
            return employeeDb.UpdateEmployee(employee);
        }
    }
}
