using System;
using System.Collections.Generic;
using System.IO;


namespace Grupparbete_Bibliotek
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<string, Book> bookdictionary = new(); //Skapa en dictionary som kan lagra böcker
        public void LoadFromFile(string filePath = "Booklist.txt")
        {
            
            if (!File.Exists(filePath))
            {
                return;
            }
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length != 4 && parts.Length != 5)
                {
                    continue;
                }
                string isbn = parts[0];
                string title = parts[1];
                string author = parts[2];

                if (!int.TryParse(parts[3], out int stock))
                {
                    continue;
                }
               
                int year = 0;

                if (parts.Length == 5)
                {
                    if (!int.TryParse(parts[4], out year))
                    {
                        continue;
                    }
                }

                Book book = new Book(isbn, author, title, stock, year);

                bookdictionary.Add(book.Isbn, book);
            }
        }
        public void SaveToFile(string filePath = "Booklist.txt")
        {
            List<string> lines = new List<string>();

            foreach (Book book in bookdictionary.Values)
            {
                string line = $"{book.Isbn};{book.Title};{book.Author};{book.Stock};{book.Year}";
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);
        }
        public void Add(Book book) // Add-metoden GREEN
        { 
            bookdictionary.Add(book.Isbn, book);
        }
        public void Remove(string isbn)
        {
            bookdictionary.Remove(isbn);
        }
        public IEnumerable<Book> GetAll() // Gett all metoden som returnerar alla böcker som finns i dictionary.
        {
            return bookdictionary.Values;
        }
        public void Update(Book book)
        {

        }

        public Book? GetByKey(string isbn)
        {
            if (bookdictionary.TryGetValue(isbn, out Book? book))
            {
                return book;
            }
            return null;
        }
    }
}
