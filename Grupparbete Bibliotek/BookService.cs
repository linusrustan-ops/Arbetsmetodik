using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> Search(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<Book>();
            }
            throw new NotImplementedException();
        }
    }
}
