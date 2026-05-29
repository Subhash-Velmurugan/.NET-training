using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainReservationApp
{
    internal class Program
    {
        static string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=TrainReservationDB;Trusted_Connection=True;"; 
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1.Register\n2.Login\n3.Exit");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    Register();

                else if (choice == 2)
                {
                    string role = Login();

                    if (role == "admin")
                        AdminMenu();
                    else if (role == "user")
                        UserMenu();
                }
                else break;
            }
        }
        static void Register()
        {
            Console.Write("Username: ");
            string u = Console.ReadLine();

            Console.Write("Password: ");
            string p = Console.ReadLine();

            Console.Write("Role (admin/user): ");
            string r = Console.ReadLine();

            SqlConnection con = new SqlConnection(connStr);
            string q = "INSERT INTO Users VALUES(@u,@p,@r)";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@r", r);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Registered!");
            }
            catch
            {
                Console.WriteLine("Username exists!");
            }
            con.Close();
        }
        static string Login()
        {
            Console.Write("Username: ");
            string u = Console.ReadLine();

            Console.Write("Password: ");
            string p = Console.ReadLine();

            SqlConnection con = new SqlConnection(connStr);

            string q = "SELECT UserType FROM Users WHERE Username=@u AND Password=@p";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@p", p);

            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != null)
                return result.ToString();
            else
            {
                Console.WriteLine("Invalid login!");
                return null;
            }
        }
        static void AdminMenu()
        {
            Console.WriteLine("\n1.Add Train\n2.Delete Train\n3.Logout");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) AddTrain();
            else if (ch == 2) DeleteTrain();
        }

        static void UserMenu()
        {
            Console.WriteLine("\n1.Book\n2.Cancel\n3.Logout");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) BookTicket();
            else if (ch == 2) CancelTicket();
        }
        static void AddTrain()
        {
            SqlConnection con = new SqlConnection(connStr);
            Console.Write("Enter Train No: ");
            int trainNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string name = Console.ReadLine();
            Console.Write("From Station: ");
            string from = Console.ReadLine();
            Console.Write("To Station: ");
            string to = Console.ReadLine();
            Console.Write("Class (2AC / 3AC / Sleeper): ");
            string trainClass = Console.ReadLine();
            Console.Write("Available Seats: ");
            int avail = int.Parse(Console.ReadLine());
            Console.Write("Charges: ");
            decimal charges = decimal.Parse(Console.ReadLine());
            string query = "INSERT INTO Train VALUES(@no,@name,@from,@to,@class,@avail,@charges,0)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", trainNo);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            cmd.Parameters.AddWithValue("@class", trainClass);
            cmd.Parameters.AddWithValue("@avail", avail);
            cmd.Parameters.AddWithValue("@charges", charges);
            if(trainClass != "2AC" && trainClass != "3AC" && trainClass != "Sleeper")
            {
                Console.WriteLine("Invalid class!");
                return;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Train Added Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static void DeleteTrain()
        {
            SqlConnection con = new SqlConnection(connStr);
            Console.Write("Enter Train No to delete: ");
            int trainNo = int.Parse(Console.ReadLine());
            string checkQuery = "SELECT COUNT(*) FROM Booking WHERE TrainNo=@trainNo";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@trainNo", trainNo);

            con.Open();
            int bookings = (int)checkCmd.ExecuteScalar();

            if (bookings > 0)
            {
                Console.WriteLine("Cannot delete, bookings exist!");
            }
            else
            {
                string deleteQuery = "UPDATE Train SET IsDeleted = 1 WHERE TrainNo=@trainNo";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@trainNo", trainNo);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train Soft Deleted");
            }
            con.Close();
        }
        static void BookTicket()
        {
            SqlConnection con = new SqlConnection(connStr);
            Console.Write("Enter Train No: ");
            int trainNo = int.Parse(Console.ReadLine());
            Console.Write("Enter number of passengers: ");
            int passengers = int.Parse(Console.ReadLine());
            string getQuery = "SELECT Availability, Charges FROM Train WHERE TrainNo=@trainNo AND IsDeleted=0";
            SqlCommand cmd = new SqlCommand(getQuery, con);
            cmd.Parameters.AddWithValue("@trainNo", trainNo);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int avail = (int)dr["Availability"];
                decimal charges = (decimal)dr["Charges"];

                if (avail >= passengers)
                {
                    dr.Close();

                    decimal amount = passengers * charges;

                    string insertBooking = "INSERT INTO Booking (TravelDate,TrainNo,TravelClass,Passengers,Amount) VALUES(GETDATE(),@trainNo,'Sleeper',@pass,@amt)";
                    SqlCommand bookCmd = new SqlCommand(insertBooking, con);
                    bookCmd.Parameters.AddWithValue("@trainNo", trainNo);
                    bookCmd.Parameters.AddWithValue("@pass", passengers);
                    bookCmd.Parameters.AddWithValue("@amt", amount);
                    bookCmd.ExecuteNonQuery();

                    string updateTrain = "UPDATE Train SET Availability = Availability - @pass WHERE TrainNo=@trainNo";
                    SqlCommand updCmd = new SqlCommand(updateTrain, con);
                    updCmd.Parameters.AddWithValue("@pass", passengers);
                    updCmd.Parameters.AddWithValue("@trainNo", trainNo);
                    updCmd.ExecuteNonQuery();

                    Console.WriteLine("Booking Successful");
                }
                else
                {
                    Console.WriteLine("Seats not available!");
                }
            }
            con.Close();
        }
        static void CancelTicket()
        {
            SqlConnection con = new SqlConnection(connStr);
            Console.WriteLine("Enter Booking Id to cancel: "); 
            int bookingId = int.Parse(Console.ReadLine());
            string getBooking = "SELECT TrainNo, Passengers FROM Booking WHERE BookingId=@bid";
            SqlCommand cmd = new SqlCommand(getBooking, con);
            cmd.Parameters.AddWithValue("@bid", bookingId);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int trainNo = (int)dr["TrainNo"];
                int passengers = (int)dr["Passengers"];
                dr.Close();

                string cancelQuery = "INSERT INTO Cancellation (BookingId) VALUES(@bid)";
                SqlCommand cancelCmd = new SqlCommand(cancelQuery, con);
                cancelCmd.Parameters.AddWithValue("@bid", bookingId);
                cancelCmd.ExecuteNonQuery();

                string updateTrain = "UPDATE Train SET Availability = Availability + 1 WHERE TrainNo=@trainNo";
                SqlCommand updCmd = new SqlCommand(updateTrain, con);
                updCmd.Parameters.AddWithValue("@trainNo", trainNo);
                updCmd.ExecuteNonQuery();

                Console.WriteLine("Cancelled. Refund = 900");
            }
            con.Close();
        }

    }
}
