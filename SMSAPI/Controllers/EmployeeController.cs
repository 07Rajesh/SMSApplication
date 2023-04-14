using BussinessAccessLayer.BlEmployee;
using BussinessAccessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSAPI.DBAccess;
using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class EmployeeController : ControllerBase
    {
      //  BLEmployee employeeDb = new BLEmployee();
        ApiResponse response = new ApiResponse();

        IEmployee employeeDb;
        public EmployeeController(IEmployee _employeedb)
        {
            employeeDb = _employeedb;
        }


        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var emps =await employeeDb.GetEmployees();
                response.Ok = true;
                response.Message = $"Total {emps.Count} Record Fetch successfully";
                response.Data = emps;
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                
            }
           
            return Ok(response);
        }

        [Route("PostEmployees")]
        [HttpPost]
        public async Task<IActionResult> PostEmployees(Employee employee)
        {
            try
            {
               // Request.Form["FirstName"]   //data handle karna 
               //agar is trh se data hanle/recieve krna rhe h to jquery call krenge iski(postemployees)->
               // to isme object bna ke data nhi bhejenge

                var res =await employeeDb.CreateEmployee(employee);
                if (res == "ok") 
                { 
                    
                     response.Ok = true;
                     response.Message = $"Employee Created successfully";
                    
                }
                else if(res=="fail")
                {
                    response.Ok = false;
                    response.Message = $"Employee Email Already Exist";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;

                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;

            }
            

            return Ok(response);
        }

        [Route("DeleteEmployees")]
        [HttpGet]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            try
            {
                var res =await employeeDb.DeleteEmployee(id);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee Deleted successfully";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Something went wrong ";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;

                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;

            }


            return Ok(response);
        }

        [Route("UpdateEmployees")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployees(Employee employee)
        {
            try
            {
                var res =await employeeDb.UpdateEmployee(employee);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee Updated successfully";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;

                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;

            }


            return Ok(response);
        }
    }
}
