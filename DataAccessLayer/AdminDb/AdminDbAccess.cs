using Microsoft.Data.SqlClient;
using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.DBAccess
{
    public class AdminDbAccess

    {
        public ConnectDb db = new ConnectDb();
   
        public string LoginAdmin(AdminLogin admin)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("login_user", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

              
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
               


                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "fail";
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
