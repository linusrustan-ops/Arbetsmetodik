
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupparbete_Bibliotek
{
    public class UI(BookService bookService, ILoanRepository loanRepository)
    {
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine(
                    "Välkommen till bibliotekssystemet!\n" +
                    "[1]. Lägg till en bok i systemet\n" +
                    "[2]. Låna ut en bok\n" +
                    "[3]. Lämna in en bok\n" +
                    "[4]. Visa alla böcker\n" +
                    "[5]. Sök efter böcker\n" +
                    "[6]. Visa en användares lånade böcker\n" +
                    "[7]. Exit\n");

                string input = ReadString("Ditt val:");

                switch (input)
                {
                    case "1":
                        Book? book = RegisterNewBook();

                        if (bookService.CheckIfBookIsValidAndAdd(book))
                        {
                            Console.WriteLine("Boken har lagts till");
                        }
                        else
                        {
                            Console.WriteLine("Boken skapades inte");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Inte implementerat än");
                        break;

                    case "3":
                        Console.WriteLine("Inte implementerat än");
                        break;

                    case "4":
                        bookService.ShowAllBooks();
                        break;

                    case "5":
                        SearchBooks();
                        break;

                    case "6":
                        ShowUserLoans();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Ogiltigt svar försök igen");
                        break;
                }

                Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ShowUserLoans()
        {
            string userId = ReadString("Ange användarens ID:");

            List<Loan> loans = loanRepository.GetByUserId(userId);

            if (!loans.Any())
            {
                Console.WriteLine("Användaren har inga lånade böcker.");
                return;
            }

            Console.WriteLine($"Lånade böcker för användare {userId}:");

            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"{loan.Book.Isbn} | " +
                    $"{loan.Book.Author} | " +
                    $"{loan.Book.Title} | " +
                    $"Startdatum: {loan.StartDate:yyyy-MM-dd} | " +
                    $"Slutdatum: {loan.EndDate:yyyy-MM-dd}");
            }
        }

        public void SearchBooks()
        {
            string input = ReadString("Ange sökord:");

            var result = bookService.Search(input).ToList();

            if (!result.Any())
            {
                Console.WriteLine("Inga matchande böcker hittades.");
                return;
            }

            foreach (var book in result)
            {
                Console.WriteLine(
                    $"{book.Isbn} | {book.Author} | " +
                    $"{book.Title} | {book.Stock} | {book.Year} |");
            }
        }

        public static string ReadString(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else
                {
                    return input;
                }
            }
        }

        public static int ReadInteger(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else if (value <= 0)
                {
                    Console.WriteLine("Ett tal måste vara större än noll.");
                }
                else
                {
                    return value;
                }
            }
        }

        public static Book? RegisterNewBook()
        {
            int isbn = ReadInteger("Vilket ISBN ska boken ha? (minst 5 siffror)");

            string bookIsbn = isbn.ToString();
            string bookAuthor = ReadString("Vad heter författaren?");
            string bookTitle = ReadString("Vad heter boktiteln?");
            int bookStock = ReadInteger("Hur många böcker vill du lägga till?");
            int bookYear = ReadInteger("Vilket år släpptes boken?");

            Console.Clear();

            string input = ReadString(
                $"Det du vill lägga till:\n\n" +
                $"ISBN:{bookIsbn} | Författare:{bookAuthor} | " +
                $"Titel:{bookTitle} | Antal:{bookStock} | " +
                $"Utgivningsår:{bookYear}\n\n" +
                "Stämmer det? JA eller NEJ");

            if (input.ToUpper() == "JA")
            {
                return new Book(
                    bookIsbn,
                    bookAuthor,
                    bookTitle,
                    bookStock,
                    bookYear);
            }

            return null;
        }
    }
}
