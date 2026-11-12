using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class Book(string author, string title, string isbn, int stock, int year)
    {
        string Isbn { get; } = isbn;
        string Author { get; set; } = author;
        string Title { get; set; } = title;
        int Stock { get; } = stock;
        int Year { get; } = year;
    }
}
