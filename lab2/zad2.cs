﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class Sumator
    {
        public int[] liczby;

        public Sumator (int[] liczby)
        {
            this.liczby = liczby;
        }

        public int sum()
        {
            int sum = 0;

            foreach (int number in liczby)
            {
                sum += number;
            }
            return sum;
        }

        public int sumDivide2()
        {
            int sum = 0;

            foreach (int liczba in liczby)
            {
                if (liczba % 2 == 0)
                {
                    sum += liczba;
                }
            }
            return sum;
        }

        public int IleElem()
        {
            return liczby.Length;
        }

        public void WypiszWszElem()
        {
            foreach (int liczba in liczby)
            {
                Console.WriteLine(liczba);
            }
        }

        public void PrintElementInRange(int lowIndex, int highIndex)
        {
            if (lowIndex < 0)
                lowIndex = 0;

            if (highIndex >= liczby.Length)
                highIndex = liczby.Length - 1;

            for (int i = lowIndex; i < highIndex; i++)
            {
                Console.WriteLine(liczby[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sumator Sumator = new Sumator(liczby);

            Console.WriteLine($"Suma wszystkich elem: {Sumator.sum()}" );
            Console.WriteLine($"Suma liczb podzielonych przez 2: {Sumator.sumDivide2()} ");
            Console.WriteLine($"Liczby w tabele : {Sumator.IleElem()} ");

        }
    }
}