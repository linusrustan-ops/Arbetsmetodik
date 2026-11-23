using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_Bibliotek
{
    internal class UI
    {

        public void Menu()
        {
            Console.WriteLine("Välkommen till bibliotekssystemet!\n" +
                "[1]. Lägg till en bok i systemet" +
                "[2]. Låna ut en bok" +
                "[3]. Lämna in en bok" +
                "[4]. Visa alla böcker" +
                "[5]. Exit" );

            string input = ReadString("\nDitt val:\n\n");

            switch (input)
            {
                case "1":
                    return;

                case "2":
                    return;

                case "3":
                    return;

                case "4":
                    return;

                case "5":
                    return;

                default:
                    Console.WriteLine("Ogiltigt svar försök igen");
                    return;
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

    }
}
