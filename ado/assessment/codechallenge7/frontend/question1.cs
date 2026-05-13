using System;
using System.Data;
using System.Data.SqlClient;

namespace codechallenge7
{
    class Program
    {
        static string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employeemanagement;Integrated Security=True";
        static void Main()
        {
            InsertEmployee("Bob", 30000, "P");
            DisplayEmployees();
        }
        static void InsertEmployee(string name, decimal salary, string type)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", name);
                cmd.Parameters.AddWithValue("@Empsal", salary);
                cmd.Parameters.AddWithValue("@Emptype", type);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee Inserted Successfully!");
            }
        }
        static void DisplayEmployees()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_Details", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nEmployee Records:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"EmpNo: {reader["Empno"]}, Name: {reader["EmpName"]}, Salary: {reader["Empsal"]}, Type: {reader["Emptype"]}");
                }
            }
        }
    }
}