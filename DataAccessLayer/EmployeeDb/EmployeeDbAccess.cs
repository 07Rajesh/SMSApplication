using Microsoft.Data.SqlClient;
using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.DBAccess
{
    public class EmployeeDbAccess
    {
        public ConnectDb db = new ConnectDb();
        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_get_Employees", db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Employee> lstEmployee = new List<Employee>();

            while(dr.Read())
            {
                Employee emp = new Employee();

                emp.Id = (int)dr["Id"];
                emp.FirstName = dr["FirstName"].ToString();
                emp.LastName = dr["LastName"].ToString();
                emp.Gender = dr["Gender"].ToString();
                emp.Email = dr["Email"].ToString();
                emp.Password = dr["Password"].ToString();
                emp.Mobile = dr["Mobile"].ToString();
                emp.Address1 = dr["Address1"].ToString();
                emp.Address2 = dr["Address2"].ToString();
                emp.Pincode = dr["Pincode"].ToString();
                emp.IsActive =Convert.ToBoolean(dr["Is_Active"]);
               emp.EmpCode = dr["Emp_Code"].ToString();
                lstEmployee.Add(emp);
            }
            db.connection.Close();
            return lstEmployee;
        }

        public string CreateEmployee(Employee employee)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert_Employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
                cmd.Parameters.AddWithValue("@Address1", employee.Address1);
                cmd.Parameters.AddWithValue("@Address2", employee.Address2);
                cmd.Parameters.AddWithValue("@Pincode", employee.Pincode);
                cmd.Parameters.AddWithValue("@Is_Active", employee.IsActive);


                int i =(int) cmd.ExecuteScalar();
                if (i==1)
                {
                    message = "ok";
                }
                else
                {
                    message = "Fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;

            }
            return message;
        }

        public string DeleteEmployee(int id)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_Employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@id",id);


                int i = (int)cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "Fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;

            }
            return message;
        }


        public string UpdateEmployee(Employee employee)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update_Employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
                cmd.Parameters.AddWithValue("@Address1", employee.Address1);
                cmd.Parameters.AddWithValue("@Address2", employee.Address2);
                cmd.Parameters.AddWithValue("@Pincode", employee.Pincode); 
                cmd.Parameters.AddWithValue("@Is_Active", employee.IsActive);


                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "Fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;

            }
            return message;
        }
    }
}
