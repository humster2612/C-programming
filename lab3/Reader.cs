using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿namespace Lab3
{
    internal class Reader : Person
    {

        public List<Book> BooksRead { get; set; }


        public Reader(string firstName, string lastName, int? wiek) : base(firstName, lastName, wiek)
        {

            BooksRead = new List<Book>();
        }

        public void ViewBook()
        {
            Console.WriteLine($"Ksiazki przeczytane uzytkownikiem {FirstName} {LastName}: ")



            foreach (var book in BooksRead)
            {

                Console.WriteLine(book.Title + ";");
            }
        }

        public override void View()
        {
            base.View();

            ViewBook();
        }
    }
}