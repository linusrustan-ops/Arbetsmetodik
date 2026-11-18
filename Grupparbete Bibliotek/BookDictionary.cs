using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Availeblecopies { get; set; }
    }

    public class BooksInStore
    {
        public static void Main()
        {
            Dictionary<string, Book> books = new();

            books.Add("001", new Book
            {
                ISBN = "001",
                Title = "test",
                Author = "test", 
                Availeblecopies = 999,
            });

            foreach (var book in books.Values)
            {
            Console.WriteLine($"{book.Title} - Availeble: {book.Availeblecopies}");
            }

            if (books.TryGetValue("001", out Book? selectedBook))
            {
                if (selectedBook.Availeblecopies > 0)
                {
                    selectedBook.Availeblecopies--;

                }
            }
        }
    }
}
