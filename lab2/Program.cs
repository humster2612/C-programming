using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_1
{
    public class Licz
    {
        private int value;

        public Licz(int initialValue)
        {
            this.value = initialValue;
        }

        public void dodaj(int number)
        {
            this.value += number;
        }

        public void odejmij(int number)
        {
            this.value -= number;
        }

        public void printValue()
        {
            Console.WriteLine(this.value);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
           Licz counter = new Licz(25);

            counter.printValue();

            counter.dodaj(5);
            counter.printValue();

            counter.odejmij(4);
            counter.printValue();
        }
    }
}

