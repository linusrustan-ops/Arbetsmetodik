namespace Grupparbete_Bibliotek
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            bookRepository.LoadFromFile();
            BookService bookService = new BookService(bookRepository);
            UI Ui = new UI(bookService);
            Ui.Menu();
            bookRepository.SaveToFile();
        }
    }
}
