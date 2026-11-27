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

            var loan1 = new loansByUserId
            {
                Book = new Book("1", "Tolkien", "Book One", 1, 1901),
                UserId = "User1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14)
            };

            var loan2 = new loansByUserId
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

        [Fact]
        public void Add_LoanToRepository_LoanIsSaved()
        {
            // Arrange
            var repository = new LoanRepository();

            var loan = new loansByUserId
            {
                Book = new Book("3", "George Orwell", "1984", 1, 1949),
                UserId = "User1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14)
            };

            // Act
            repository.Add("User1", loan);

            var result = repository.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Contains(loan, result);
        }

    }
}