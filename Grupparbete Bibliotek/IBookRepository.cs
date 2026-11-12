using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Remove(string isbn);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        Book? GetByKey(string isbn);
    }
}
