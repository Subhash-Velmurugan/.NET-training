using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }
        public void Display()
        {
            Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
        }
    }
    class BookShelf
    {
        private Books[] books = new Books[5];
        public Books this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }
        public static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("The Great Gatsby", "F. Scott Fitzgerald");
            shelf[1] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[2] = new Books("1984", "George Orwell");
            shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[4] = new Books("Moby Dick", "Herman Melville");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
    }
}
