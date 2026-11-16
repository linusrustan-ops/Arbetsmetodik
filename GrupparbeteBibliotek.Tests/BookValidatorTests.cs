using Grupparbete_Bibliotek;

namespace GrupparbeteBibliotek.Tests
{
    public class BookValidatorTests
    {
        //Hjälpmedtod: en bok där allt är giltigt
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
    }
}