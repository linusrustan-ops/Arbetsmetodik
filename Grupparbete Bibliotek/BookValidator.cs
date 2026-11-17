
namespace Grupparbete_Bibliotek
{
    public static class BookValidator
    {
        public static void Validate (Book book)
        {
            RequireText(book.Isbn, "ISBN");
            RequireText(book.Title, "Titel");
            RequireText(book.Author, "Författare");

            if (book.Stock < 1)
                throw new ArgumentException("Antal exemplar måste vara minst 1.");
           
            if (book.Year < 1 || book.Year > DateTime.Now.Year)
                throw new ArgumentException("Utgivningsåret är ogiltigt.");
        }
        private static void RequireText(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} får inte vara tomt.");
        }
    }
}
