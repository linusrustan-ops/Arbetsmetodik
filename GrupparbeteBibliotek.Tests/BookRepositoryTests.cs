using System.Linq;
using Grupparbete_Bibliotek;
using Xunit;

namespace GrupparbeteBibliotek.Tests
{
    public class BookRepositoryTests
    {
        [Fact]
        public void Add_ValidBook_BookExistsInRepository()
        {

            var repository = new BookRepository();
            var book = new Book(
                "Astrid Lindgren",
                "Mio min Mio",
                "9789129688313",
                2,
                1954
                );
            repository.Add(book);

            Assert.Contains(repository.GetAll(),
                savedBook => savedBook.Isbn == book.Isbn);
        } 
    }
}