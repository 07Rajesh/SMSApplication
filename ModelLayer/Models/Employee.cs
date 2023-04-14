using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Gender { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Mobile { get; set; } 
        public string Address1 { get; set; } 
        public string Address2 { get; set; }
        public string Pincode { get; set; }
        public bool IsActive { get; set; }
       public string EmpCode { get; set; }

        
    }
}
