using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{

    public class BooksInStore
    {
        public static void Main()
        {
            Dictionary<string, Book> books = new();

            books.Add("001", new Book
            {
                Isbn = "001",
                title = "test",
                author = "test", 
                stock = 999,
                year = 1000,
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
