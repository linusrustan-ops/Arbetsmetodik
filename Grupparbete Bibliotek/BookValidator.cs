
namespace Grupparbete_Bibliotek
{
    public static class BookValidator
    {
        public static void Validate (Book book)
        {            
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Titel får inte vara tom.");
           
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Författare får inte vara tom");

            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new ArgumentException("ISBN får inte vara tomt");
        }
    }
}
