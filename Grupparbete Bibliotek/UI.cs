using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class UI(BookService bookService)
    {

        public void Menu()
        { 
            while (true)
            {
                Console.WriteLine("Välkommen till bibliotekssystemet!\n" +
                "[1]. Lägg till en bok i systemet\n" +
                "[2]. Låna ut en bok\n" +
                "[3]. Lämna in en bok\n" +
                "[4]. Visa alla böcker\n" +
                "[5]. Exit\n");

                string input = ReadString("\nDitt val:\n");

                switch (input)
                {
                    case "1":
                        Book? book = RegisterNewBook();
                        if (bookService.CheckIfBookIsValidAndAdd(book))
                        {
                            Console.WriteLine("Boken har lagts till");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Boken skapades inte");
                            break;
                        }
                        

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
                else return input;
            }
        }

        public static int ReadInteger(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                int value = 0;

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else if (value <= 0)
                {
                    Console.WriteLine("Ett tal får inte vara negativt.");
                }
                else
                {
                    return value;
                }
            }
        }
        public static Book? RegisterNewBook()
        {
            int Isbn = ReadInteger("Vilket ISBN ska boken ha? (minst 5 siffor)");
            string bookIsbn = Isbn.ToString();
            string bookAuthor = ReadString("Vad heter författaren?");
            string bookTitle = ReadString("Vad heter boktiteln?");
            int bookStock = ReadInteger("Hur många böcker vill du lägga till?");
            int bookYear = ReadInteger("Vilket år släpptes boken?");

            Console.Clear();

            string input = ReadString($"Det du vill lägga till: \n\n" +
                $"ISBN:{bookIsbn} | Författare:{bookAuthor} | Titel:{bookTitle} | Antal:{bookStock} | Utgivningsår:{bookYear}\n\n" +
                $"Stämmer det? JA eller NEJ");

            if (input.ToUpper() == "JA")
            {
                Book book = new(bookIsbn, bookAuthor, bookTitle, bookStock, bookYear);
                return book;
            }
            else
            {
                return null;
            }

        }
    }
}

