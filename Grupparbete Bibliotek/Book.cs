using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace Grupparbete_Bibliotek
{
    public class Book(string author, string title, string isbn, int stock, int year)
    {
        public string Isbn { get; } = isbn;
       public string Author { get; set; } = author;
       public string Title { get; set; } = title;
       public int Stock { get; } = stock;
        public int Year { get; } = year;
    }
}
