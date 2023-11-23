using Lab3zad2;

namespace Lab3zad2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SamochodOsobowy samochodOsobowy1 = new(marka: "Porsche", model: "911", kolor: "Black",
                rokProdukcji: 2018, przebieg: 192.000, waga: 1.782, pojemnoscSilnika: 3, iloscOsob: 2);

            Samochod samochod1 = new(marka: "Mercedes", model: "Benz",
                nadwozie: "coupé", kolor: "Grey", rokProdukcji: 2021, przebieg: 100.000);

            Samochod samochod2 = new(marka: "Lamborhini", model: "Aventador",
                nadwozie: "coupé", kolor: "Green", rokProdukcji:2020 , przebieg: 174.000);

            samochodOsobowy1.ShowInfo();
            Console.WriteLine();

            samochod1.ShowInfo();
            Console.WriteLine();

            samochod2.ShowInfo();
        }
    }
}
