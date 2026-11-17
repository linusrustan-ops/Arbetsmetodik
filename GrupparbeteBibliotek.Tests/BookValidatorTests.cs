using Grupparbete_Bibliotek;

namespace GrupparbeteBibliotek.Tests
{
    public class BookValidatorTests
    {
        //Hjälpmetod: en bok där allt är giltigt
        private static Book ValidBook() =>
            new Book("Astrid Lindgren", "Mio min Mio", "9789129688313", 2, 1954);
        [Fact] //Normalfall - Acceptanskriterium 1
        public void Validate_ValidBook_DoesNotThrow()
        {
            var ex = Record.Exception(() => BookValidator.Validate(ValidBook()));
            Assert.Null(ex);
        }
        [Fact] // Gränsfall - Acceptanskriterium 2
        public void Validate_EmptyTitle_Throw()
        {
            var book = ValidBook();
            book.Title = "";
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
        [Fact] //Gränsfall - mellanslag räknas som tomt
        public void Validate_WhitespaceTitle_Throws()
        {
            var book = ValidBook();
            book.Title = " ";
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
        [Fact] // Gränsfall - Acceptanskriterium 2 
        public void Validate_EmptyAuthor_Throws()
        {
            var book = ValidBook();
            book.Author = " ";
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
        [Fact] // Gränsfall - Acceptanskriterium 2
        public void Validate_EmptyIsbn_Throws()
        {
            var book = new Book("Astrid Lindgren", "Mio min Mio", "", 2, 1954);
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
        [Fact] //Gränsfall - 0 exemplar
        public void Validate_ZeroStock_Throws()
        {
            var book = new Book("Astrid Lindgren", "Mio min Mio", "9789129688313", 0, 1954);
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
        [Fact] // Gränsfall - år i framtiden (eget antagande)
        public void Validate_FutureYear_Throws()
        {
            var book = new Book("Astrid Lindgren", "Mio min Mio", "9789129688313", 2, DateTime.Now.Year + 1);
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }

        [Fact] // Gränsfall - år 0, inget år angivet (eget antagande)
        public void Validate_ZeroYear_Throws()
        {
            var book = new Book("Astrid Lindgren", "Mio min Mio", "9789129688313", 2, 0);
            Assert.Throws<ArgumentException>(() => BookValidator.Validate(book));
        }
    }
}