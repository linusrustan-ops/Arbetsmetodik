
namespace Grupparbete_Bibliotek
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            bookRepository.LoadFromFile();

            BookService bookService = new BookService(bookRepository);

            ILoanRepository loanRepository = new LoanRepository();
          

            UI ui = new UI(bookService, loanRepository);

            ui.Menu();

            bookRepository.SaveToFile();
        }
    }
}
