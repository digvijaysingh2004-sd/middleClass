using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MiddelClass.Models;

namespace MiddelClass.Builder
{
    public class AccountBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;

        public AdminloginModel GetAdminLogin(string userid)
        {
            AdminloginModel admindata = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAdminLogin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Userid", userid);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                admindata = new AdminloginModel
                                {
                                    EmployeeId = reader["EmployeeId"]?.ToString() ?? string.Empty,
                                    UserId = reader["UserId"]?.ToString() ?? string.Empty,
                                    Password = reader["Password"]?.ToString() ?? string.Empty,
                                    UserType = reader["UserType"]?.ToString() ?? string.Empty,
                                    FirstName = reader["FirstName"]?.ToString() ?? string.Empty,
                                    MiddelName = reader["MiddelName"]?.ToString() ?? string.Empty,
                                    LastName = reader["LastName"]?.ToString() ?? string.Empty
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error properly (consider using a logging framework)
                Console.WriteLine($"Error in GetUserLogin: {ex.Message}");
            }

            return admindata;
        }
    }
}