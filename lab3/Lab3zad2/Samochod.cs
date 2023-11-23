using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3zad2
{

    internal class Samochod
    {
        private double przebieg = 0;

        public string Marka { get; set; }

        public string Model { get; set; }

        public string Nadwozie { get; set; }
        public string Kolor { get; set; }

        public uint RokProdukcji { get; set; }

        public double Przebieg
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Przebieg nie moze byc ujemny !");

                    Console.ReadKey();

                    Environment.Exit(0);
                }
                else
                    przebieg = value;
            }

            get { return przebieg; }
        }

        public Samochod(string marka, string model, string nadwozie, string kolor, uint rokProdukcji, double przebieg)
        {
            Marka = marka;
            Model = model;
            Nadwozie = nadwozie;
            Kolor = kolor;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Marka: {Marka};" +$"\nModel: {Model};" + $"\nNadwozie: {Nadwozie};" + $"\nKolor: {Kolor};" +$"\nRok produkcji: {RokProdukcji};" +$"\nPrzebieg: {Przebieg} tys. km.;");
        }
    }
}

