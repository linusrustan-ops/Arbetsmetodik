using Grupparbete_Bibliotek;
using System;

namespace GrupparbeteBibliotek.Tests
{
    public class LoanRepositoryTests
    {
        [Fact]
        public void Add_TwoBooksForSameUser_ReturnsBothLoans()
        {
            // Arrange
            var repository = new LoanRepository();

            var loan1 = new Loan
            {
                Book = new Book("1", "Tolkien", "Book One", 1, 1901),
                UserId = "User1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14)
            };

            var loan2 = new Loan
            {
                Book = new Book("2", "Rowling", "Book Two", 1, 2000),
                UserId = "User1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14)
            };

            // Act
            repository.Add("User1", loan1);
            repository.Add("User1", loan2);

            var result = repository.GetByUserId("User1");

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetByUserId_UserHasNoLoans_ReturnsEmptyList()
        {
            // Arrange
            var repository = new LoanRepository();

            // Act
            var result = repository.GetByUserId("User2");

            // Assert
            Assert.Empty(result);
        }
    }
}