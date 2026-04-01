using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    using System;
    class Accounts
    {
        private int accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private double amount;
        private double balance;
        public Accounts(int accNo, string custName, string accType, double initialBalance)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            balance = initialBalance;
        }
        public void Credit(double amt)
        {
            balance += amt;
            Console.WriteLine($"Deposited: {amt}");
        }
        public void Debit(double amt)
        {
            if (amt > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                balance -= amt;
                Console.WriteLine($"Withdrawn: {amt}");
            }
        }
        public void ProcessTransaction(char transType, double amt)
        {
            transactionType = Char.ToUpper(transType);
            amount = amt;

            if (transactionType == 'D')
            {
                Credit(amount);
            }
            else if (transactionType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type!");
            }
        }
        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Transaction Type: {transactionType}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Balance: {balance}");
        }
    }

    
}
