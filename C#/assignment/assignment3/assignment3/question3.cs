using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    internal class SaleDetails
    {
        int salesNo;
        int productNo;
        double price;
        int qty;
        DateTime dateOfSale;
        double totalAmount;
        public SaleDetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
        }
        public void Sales()
        {
            totalAmount = qty * price;
        }
        public static void ShowData(SaleDetails s)
        {
            Console.WriteLine("\nSales Details:");
            Console.WriteLine("Sales No: " + s.salesNo);
            Console.WriteLine("Product No: " + s.productNo);
            Console.WriteLine("Price: " + s.price);
            Console.WriteLine("Quantity: " + s.qty);
            Console.WriteLine("Date of Sale: " + s.dateOfSale.ToShortDateString());
            Console.WriteLine("Total Amount: " + s.totalAmount);
        }

    }
}
