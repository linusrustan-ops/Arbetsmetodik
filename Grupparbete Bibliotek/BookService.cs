using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

            var books = _bookRepository.GetAll();

            var searchResults = books.Where(book =>
                book.Author.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                book.Title.Contains(input, StringComparison.OrdinalIgnoreCase));

            return searchResults;
        }

        public bool CheckIfBookIsValidAndAdd(Book? book)
        {
            var bookDictionary = _bookRepository.GetAll();
            if (book == null)
            {
                return false;
            }
            else if (_bookRepository.GetByKey(book.Isbn) != null)
            {
                return false;
            }
            else
            {
                _bookRepository.Add(book);
                return true;
            }
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("Nuvarande Böcker i systemet:\n\n");
            foreach (var book in _bookRepository.GetAll())
            {
                Console.WriteLine($"{book.Isbn} | {book.Author} | {book.Title} | {book.Stock} | {book.Year} |");
            }
        }
            
    }
}
