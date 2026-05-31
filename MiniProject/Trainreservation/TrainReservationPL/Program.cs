using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationBAL;
using TrainReservationEntities.Models;
using System.Data;

namespace TrainReservationPL
{
    internal class Program
    {
        static TrainBAL trainBAL = new TrainBAL();
        static UserBAL userBAL = new UserBAL();
        static BookingBAL bookingBAL = new BookingBAL();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== TRAIN RESERVATION =====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Enter Choice: ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Register();
                        break;

                    case 2:
                        Login();
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void Register()
        {
            try
            {
                User user = new User();

                Console.Write("Username : ");
                user.Username = Console.ReadLine();

                Console.Write("Password : ");
                user.Password = Console.ReadLine();

                Console.Write("Role (admin/user) : ");
                user.UserType = Console.ReadLine();

                bool result = userBAL.Register(user);

                if (result)
                    Console.WriteLine("Registration Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Login()
        {
            Console.Write("Username : ");
            string username = Console.ReadLine();

            Console.Write("Password : ");
            string password = Console.ReadLine();

            string role =
                userBAL.Login(username, password);

            if (role == null)
            {
                Console.WriteLine("Invalid Login");
                return;
            }

            Console.WriteLine($"Welcome {role}");

            if (role == "admin")
            {
                AdminMenu();
            }
            else
            {
                UserMenu();
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== ADMIN MENU =====");

                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Delete Train");
                Console.WriteLine("3. View Trains");
                Console.WriteLine("4. Logout");

                Console.Write("Choice : ");

                int choice =
                    Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;

                    case 2:
                        DeleteTrain();
                        break;

                    case 3:
                        ViewTrains();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        static void AddTrain()
        {
            try
            {
                Train train = new Train();

                Console.Write("Train No : ");
                train.TrainNo =
                    Convert.ToInt32(Console.ReadLine());

                Console.Write("Train Name : ");
                train.TrainName =
                    Console.ReadLine();

                Console.Write("From Station : ");
                train.FromStation =
                    Console.ReadLine();

                Console.Write("To Station : ");
                train.ToStation =
                    Console.ReadLine();

                Console.Write("Class : ");
                train.TrainClass =
                    Console.ReadLine();

                Console.Write("Availability : ");
                train.Availability =
                    Convert.ToInt32(Console.ReadLine());

                Console.Write("Charges : ");
                train.Charges =
                    Convert.ToDecimal(Console.ReadLine());

                bool result =
                    trainBAL.AddTrain(train);

                if (result)
                    Console.WriteLine("Train Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train Number : ");

                int trainNo =
                    Convert.ToInt32(Console.ReadLine());

                bool result =
                    trainBAL.DeleteTrain(trainNo);

                if (result)
                    Console.WriteLine("Train Deleted Successfully");
                else
                    Console.WriteLine("Train Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ViewTrains()
        {
            DataTable dt =
                trainBAL.GetAllTrains();

            Console.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(
                    $"{row["TrainNo"]} | " +
                    $"{row["TrainName"]} | " +
                    $"{row["FromStation"]} -> " +
                    $"{row["ToStation"]} | " +
                    $"{row["Class"]} | " +
                    $"Seats:{row["Availability"]} | " +
                    $"₹{row["Charges"]}");
            }
        }
        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== USER MENU =====");

                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Logout");

                int choice =
                    Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewTrains();
                        break;

                    case 2:
                        BookTicket();
                        break;

                    case 3:
                        CancelTicket();
                        break;

                    case 4:
                        return;
                }
            }
        }
        static void BookTicket()
        {
            try
            {
                Booking booking =
                    new Booking();

                Console.Write("Train No : ");
                booking.TrainNo =
                    Convert.ToInt32(
                        Console.ReadLine());

                Console.Write("Travel Date (yyyy-mm-dd): ");
                booking.TravelDate =
                    Convert.ToDateTime(
                        Console.ReadLine());

                Console.Write("Class : ");
                booking.TravelClass =
                    Console.ReadLine();

                Console.Write("Passengers : ");
                booking.Passengers =
                    Convert.ToInt32(
                        Console.ReadLine());

                bool result =
                    bookingBAL.BookTicket(
                        booking);

                if (result)
                {
                    Console.WriteLine(
                        $"Booking Successful");

                    Console.WriteLine(
                        $"Amount : ₹{booking.Amount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CancelTicket()
        {
            try
            {
                Console.Write(
                    "Enter Booking Id : ");

                int bookingId =
                    Convert.ToInt32(
                        Console.ReadLine());

                bool result =
                    bookingBAL.CancelTicket(
                        bookingId);

                if (result)
                {
                    Console.WriteLine(
                        "Ticket Cancelled Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}