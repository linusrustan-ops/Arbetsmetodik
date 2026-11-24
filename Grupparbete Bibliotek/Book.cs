using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class Book(string isbn, string author, string title, int stock, int year)
    {
        public string Isbn { get; set; } = isbn;
        public string Author { get; set; } = author;
        public string Title { get; set; } = title;
        public int Stock { get; set; } = stock;
        public int Year { get; set; } = year;
    }
}
