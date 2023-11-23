using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
       
            Person person1 = new(firstName: "Ala", lastName: "Buba", wiek: 23);

            Person person2 = new(firstName: "Oleg", lastName: "Kon", wiek: 18);

            Person person3 = new(firstName: "Ola", lastName: "Kot", wiek: 21);

            person1.View();
            person2.View();
            person3.View();


            Book book1 = new(title: "Harry Potter", author: person1, dataStw: new(1997, 9, 16));


            Book book2 = new(title: "The picture of Dorian Gray", author: person2, dataStw: new(1890, 5, 14));

            Book book3 = new(title: "To kill a mockingbird", author: person3, dataStw: new(1960, 11, 2));

            book1.View();
            book2.View();
            book3.View();

            Reader reader1 = new(firstName: "Maja", lastName: "Kvitka", wiek: 18);
            Reader reader2 = new(firstName: "Alex", lastName: "Martynov", wiek: 26);


            Reader reader3 = new(firstName: "Milosz", lastName: "Kolbasa",wiek: 31);

            reader1.BooksRead.Add(book1);

            reader2.BooksRead.Add(book2);

            reader3.BooksRead.Add(book3);

            reader1.ViewBook();
            reader2.ViewBook();
            reader3.ViewBook();


            reader1.View();
            reader2.View();
        }
    }
}
