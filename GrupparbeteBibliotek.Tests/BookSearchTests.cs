using Grupparbete_Bibliotek;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupparbeteBibliotek.Tests
{
    public class BookSearchTests
    {
        private static BookService CreateService()
        {
            var repo = new BookRepository();
            repo.Add(new Book("1", "Tolkien", "Lord of the rings 1", 1, 1901));
            repo.Add(new Book("2", "Tolkien", "Lord of the rings 2", 2, 1902));
            repo.Add(new Book("3", "Tolkien", "Lord of the rings 3", 3, 1903));
            repo.Add(new Book("4", "George", "A Song of ice and fire", 4, 1904));
            return new BookService(repo);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void NullOrWhiteSpace_ReturnsEmptyList(string? input)
        {
            var service = CreateService();

            var result = service.Search(input);

            Assert.NotNull(result);
            Assert.Empty(result);

        }

        [Fact]

        public void SearchByAuthor_ReturnsAllBookByThatAuthor()
        {
            var service = CreateService();

            var result = service.Search("Tolkien");

            Assert.Equal(3, result.Count());
            Assert.All(result, book => Assert.Equal("Tolkien", book.Author));
        }

        [Fact]
        public void Search_HarryPotter_IgnoresCase()
        {
            var repo = new BookRepository();
            repo.Add(new Book("5", "J.K. Rowling", "Harry Potter", 1, 1997));

            var service = new BookService(repo);

            var result = service.Search("harry potter");

            Assert.Single(result);
            Assert.Equal("Harry Potter", result.First().Title);
        }
    }
}
