using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingchallenge2
{
    public class product
    {
        public int prod_id { get; set; }
        public string prod_name { get; set; }
        public double prod_price { get; set; }
        public product(int id, string name, double price)
        {
            this.prod_id = id;
            this.prod_name = name;
            this.prod_price = price;
        }
        public static void run()
        {
            List<product> products = new List<product>();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\nEnter details for Product {i}:");

                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                products.Add(new product(id, name, price));
            }
            var sortedProducts = products.OrderBy(p => p.prod_price).ToList();
            Console.WriteLine("Products sorted by price:");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"ID: {product.prod_id}, Name: {product.prod_name}, Price: {product.prod_price}");
            }
        }
    }
}
