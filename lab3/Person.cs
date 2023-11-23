using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Wiek { get; set; }

        public Person(string firstName, string lastName, int? wiek)
        {
            FirstName = firstName;

            LastName = lastName;
            Wiek = wiek;
        }

        public virtual void View()
        {
            Console.WriteLine($"Imie: {FirstName};\nNazwisko: {LastName};\nWiek: {Wiek}.");
        }
    }
}