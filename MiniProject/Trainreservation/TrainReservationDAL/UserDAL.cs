using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using TrainReservationEntities.Models;
namespace TrainReservationDAL
{
    public class UserDAL
    {
        public bool Register(User user)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    "INSERT INTO Users VALUES(@u,@p,@r)";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u",
                    user.Username);

                cmd.Parameters.AddWithValue("@p",
                    user.Password);

                cmd.Parameters.AddWithValue("@r",
                    user.UserType);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public string Login(string username,
                            string password)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT UserType
                      FROM Users
                      WHERE Username=@u
                      AND Password=@p";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u",
                    username);

                cmd.Parameters.AddWithValue("@p",
                    password);

                con.Open();

                object result =
                    cmd.ExecuteScalar();

                return result?.ToString();
            }
        }
    }
}