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
        [Fact] //test task 15
        public void Remove_ExistingBook_BookNoLongerExists()
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

            repository.Remove(book.Isbn);

            Assert.DoesNotContain(repository.GetAll(),
                savedBook => savedBook.Isbn == book.Isbn);
        }
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
        [Fact]
        public void SaveToFile_ExistingBook_BookIsSavedToFile()
        {
            string filePath = Path.GetTempFileName();

            try
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
                repository.SaveToFile(filePath);

                string[] lines = File.ReadAllLines(filePath);

                Assert.Contains(
                    "9789129688313;Mio min Mio;Astrid Lindgren;2;1954",
                    lines);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        [Fact]
        public void SaveAndLoad_BookPreservesAllInformation()
        {
            string filePath = Path.GetTempFileName();

            try
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
                repository.SaveToFile(filePath);

                var newRepository = new BookRepository();
                newRepository.LoadFromFile(filePath);

                var loadedBook = Assert.Single(newRepository.GetAll());

                Assert.Equal(book.Isbn, loadedBook.Isbn);
                Assert.Equal(book.Author, loadedBook.Author);
                Assert.Equal(book.Title, loadedBook.Title);
                Assert.Equal(book.Stock, loadedBook.Stock);
                Assert.Equal(book.Year, loadedBook.Year);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}