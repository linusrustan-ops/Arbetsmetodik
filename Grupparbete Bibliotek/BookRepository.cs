using System;
using System.Collections.Generic;


namespace Grupparbete_Bibliotek
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<string, Book> bookdictionary = new();
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
