using System;

namespace assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Accounts acc = new Accounts(101, "John", "Savings", 1000);
            int choice=0;

            do
            {
                try
                {
                    Console.WriteLine("\n==== Banking Menu ====");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter amount to deposit: ");
                            double depAmt = Convert.ToDouble(Console.ReadLine());
                            acc.Credit(depAmt);
                            break;

                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            double witAmt = Convert.ToDouble(Console.ReadLine());
                            acc.Debit(witAmt);
                            break;

                        case 3:
                            acc.ShowData();
                            break;

                        case 4:
                            Console.WriteLine("Thank you! Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Custom Exception: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter correct data.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }

            } while (choice != 4);*/
            /* Scholarship obj = new Scholarship();

             try
             {
                 Console.Write("Enter Marks: ");
                 double marks = Convert.ToDouble(Console.ReadLine());

                 Console.Write("Enter Fees: ");
                 double fees = Convert.ToDouble(Console.ReadLine());

                 double amount = obj.Merit(marks, fees);

                 Console.WriteLine($"Scholarship Amount: {amount}");
             }
             catch (InvalidMarksException ex)
             {
                 Console.WriteLine("Custom Exception: " + ex.Message);
             }
             catch (FormatException)
             {
                 Console.WriteLine("Invalid input! Please enter numeric values.");
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error: " + ex.Message);
             }
         }*/
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("1984", "George Orwell");
            shelf[2] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[4] = new Books("The Hobbit", "J.R.R. Tolkien");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
        }
}