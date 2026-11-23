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
    }
}
