using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Podaj numer albumu: ");
        string numerAlbumu = Console.ReadLine();

        Console.Write("Podaj nazwę pliku do zapisu: ");
        string nazwaPliku = Console.ReadLine();

        ZapiszNumerAlbumuDoPliku(numerAlbumu, nazwaPliku);

        Console.WriteLine($"Numer albumu został zapisany do pliku {nazwaPliku}.");
    }

    static void ZapiszNumerAlbumuDoPliku(string numerAlbumu, string nazwaPliku)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                sw.WriteLine(numerAlbumu);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisu do pliku: {ex.Message}");
        }
    }
}

