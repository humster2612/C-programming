using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Book
    {
        public string Title { get; set; }

        public Person Author { get; set; }

        public DateOnly DataStw { get; set; }

        public Book(string title, Person author, DateOnly dataStw)
        {
            Title = title;

            Author = author;

            DataStw = dataStw;
        }

        public virtual void View()
        {

            Console.WriteLine($"Tytul: {Title};\nAutor: {Author.FirstName} {Author.LastName};\nData stworzenia: {DataStw}.");
        }
    }
}