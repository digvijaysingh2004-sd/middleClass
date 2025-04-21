using MiddelClass.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MiddelClass.Builder
{
    public class CollectionBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;

        public List<SummerEditModel> GetSummerEditPage()
        {
            List<SummerEditModel> summerdata = new List<SummerEditModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSummerEdit1", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SummerEditModel summer = new SummerEditModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : string.Empty,
                                Badge = reader["Badge"] != DBNull.Value ? reader["Badge"].ToString() : string.Empty,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                            };

                            summerdata.Add(summer);
                        }
                    }
                }
            }
            return summerdata;
        }
    }
}