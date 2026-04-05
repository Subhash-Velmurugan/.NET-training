using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
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
    }
}
