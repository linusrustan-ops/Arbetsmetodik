using System.Linq;
using System.IO;
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
                "9789129688313",
                "Astrid Lindgren",
                "Mio min Mio",
                 2,
                1954
                );
            repository.Add(book);

            Assert.Contains(repository.GetAll(),
                savedBook => savedBook.Isbn == book.Isbn);
        }

        [Fact]
        public void LoadFromFile_ExistingBook_BookExistsInRepository()
        {
            string filePath = Path.GetTempFileName();

            try
            {
                File.WriteAllText(filePath,
                    "9789129688313;Mio min Mio;Astrid Lindgren;2");

                var repository = new BookRepository();

                repository.LoadFromFile(filePath);

                Assert.Contains(repository.GetAll(),
                    book => book.Isbn == "9789129688313");
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}