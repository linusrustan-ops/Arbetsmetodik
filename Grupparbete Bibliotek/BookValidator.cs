
namespace Grupparbete_Bibliotek
{
    public static class BookValidator
    {
        public static void Validate (Book book)
        {
            RequireText(book.Isbn, "ISBN");
            RequireText(book.Title, "Titel");
            RequireText(book.Author, "Författare");
        }
        private static void RequireText(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} får inte vara tomt.");
        }
    }
}
