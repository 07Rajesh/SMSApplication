using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Interface
{
   public interface IEmployee
    {
       Task<List<Employee>> GetEmployees();
       Task<string> CreateEmployee(Employee employee);

        Task<string> DeleteEmployee(int id);
        Task<string> UpdateEmployee(Employee employee);

    }
}
