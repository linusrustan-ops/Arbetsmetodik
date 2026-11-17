using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class BookRepository : IBookRepository
    {
        public void Add(Book book)
        {

        }
        public void Remove(string isbn)
        {

        }
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>();
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
