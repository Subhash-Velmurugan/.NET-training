using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge7
{
    internal class updatesalary
    {
        static string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employeemanagement;Integrated Security=True";
        public static void Main()
        {
            Console.Write("Enter Employee ID to update salary: ");
            int empId = int.Parse(Console.ReadLine());
            UpdateSalary(empId);
            DisplayEmployees();
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
        static void UpdateSalary(int empId)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployeeSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Empno", SqlDbType.Int).Value = empId;
                SqlParameter outParam = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal);
                outParam.Direction = ParameterDirection.Output;
                outParam.Precision = 10;
                outParam.Scale = 2;
                cmd.Parameters.Add(outParam);
                con.Open();
                cmd.ExecuteNonQuery();
                decimal updatedSalary = (decimal)cmd.Parameters["@UpdatedSalary"].Value;
                Console.WriteLine($"Updated Salary: {updatedSalary}");
            }
        }

    }
}
