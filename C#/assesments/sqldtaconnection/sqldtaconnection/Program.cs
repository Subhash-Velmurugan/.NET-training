using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    internal class Program
    {
        static SqlConnection conn;

        static void Main(string[] args)
        {
            SelectData();
            UpdateSalary();
            SelectData();
            DeleteData();

            Console.ReadKey();
        }
        static SqlConnection GetConnection()
        {
            conn = new SqlConnection(
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=InfiniteDB;" +
                "Integrated Security=True");

            conn.Open();
            return conn;
        }
        public static void SelectData()
        {
            try
            {
                conn = GetConnection();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tblEmployee", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\n--- Employee List ---");
                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["EmpId"]} {dr["EmpName"]} {dr["Gender"]} {dr["Salary"]} {dr["DepartmentId"]}");
                }

                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void UpdateSalary()
        {
            try
            {
                conn = GetConnection();

                Console.WriteLine("\nEnter Employee ID to update:");
                int eid = int.Parse(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand(
                    "SELECT * FROM tblEmployee WHERE EmpId=@eid", conn);

                cmd1.Parameters.AddWithValue("@eid", eid);

                SqlDataReader dr = cmd1.ExecuteReader();

                if (!dr.HasRows)
                {
                    Console.WriteLine("Employee not found");
                    dr.Close();
                    conn.Close();
                    return;
                }

                while (dr.Read())
                {
                    Console.WriteLine($"ID: {dr["EmpId"]}");
                    Console.WriteLine($"Name: {dr["EmpName"]}");
                    Console.WriteLine($"Salary: {dr["Salary"]}");
                }

                dr.Close();

                Console.WriteLine("Enter new salary:");
                decimal newsal = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Confirm update? (Y/N):");
                string ans = Console.ReadLine();

                if (ans.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    SqlCommand cmd2 = new SqlCommand(
                        "UPDATE tblEmployee SET Salary=@sal WHERE EmpId=@eid", conn);

                    cmd2.Parameters.AddWithValue("@sal", newsal);
                    cmd2.Parameters.AddWithValue("@eid", eid);

                    int result = cmd2.ExecuteNonQuery();

                    Console.WriteLine(
                        result > 0 ? "Salary updated successfully" : "Update failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void DeleteData()
        {
            try
            {
                conn = GetConnection();

                Console.WriteLine("\nEnter Employee ID to delete:");
                int eid = int.Parse(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand(
                    "SELECT * FROM tblEmployee WHERE EmpId=@eid", conn);

                cmd1.Parameters.AddWithValue("@eid", eid);

                SqlDataReader dr = cmd1.ExecuteReader();

                if (!dr.HasRows)
                {
                    Console.WriteLine("Employee not found");
                    dr.Close();
                    return;
                }

                while (dr.Read())
                {
                    Console.WriteLine($"ID: {dr["EmpId"]}");
                    Console.WriteLine($"Name: {dr["EmpName"]}");
                    Console.WriteLine($"Salary: {dr["Salary"]}");
                }

                dr.Close();

                Console.WriteLine("Confirm delete? (Y/N):");
                string ans = Console.ReadLine();

                if (ans.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    SqlCommand cmd2 = new SqlCommand(
                        "DELETE FROM tblEmployee WHERE EmpId=@eid", conn);

                    cmd2.Parameters.AddWithValue("@eid", eid);

                    int result = cmd2.ExecuteNonQuery();

                    Console.WriteLine(
                        result > 0 ? "Record deleted" : "Delete failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}