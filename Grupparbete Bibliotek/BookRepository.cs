using System;
using System.Collections.Generic;
using System.IO;


namespace Grupparbete_Bibliotek
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<string, Book> bookdictionary = new();
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
                
                if (parts.Length !=4 )
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
                Book book = new Book(isbn, author, title, stock, 0);
                bookdictionary.Add(book.Isbn, book);
            }
        }
        public void Add(Book book)
        { 
            bookdictionary.Add(book.Isbn, book);
        }
        public void Remove(string isbn)
        {

        }
        public IEnumerable<Book> GetAll()
        {
            return bookdictionary.Values;
        }
        public void Update(Book book)
        {

        }

        public Book? GetByKey(string isbn)
        {
            return null;
        }
    }
}
