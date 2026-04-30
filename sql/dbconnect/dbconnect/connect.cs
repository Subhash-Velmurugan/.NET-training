
using System;
using System.Data.SqlClient;

namespace dbconnect
{
    class program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB.;Database=ITdb;Integrated Security=True;";
            string query = "SELECT * FROM Clients";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to ITdb successfully.\n");

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        Console.WriteLine("Client Details:");
                        Console.WriteLine("------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"ID: {reader["Client_ID"]}, " +
                                $"Name: {reader["Cname"]}, " +
                                $"Business: {reader["Business"]}"
                            );
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
