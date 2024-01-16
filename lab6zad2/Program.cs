using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku do wczytania: ");
        string nazwaPliku = Console.ReadLine();

        WczytajZawartoscPliku(nazwaPliku);
    }

    static void WczytajZawartoscPliku(string nazwaPliku)
    {
        try
        {
            if (File.Exists(nazwaPliku))
            {
                using (StreamReader sr = new StreamReader(nazwaPliku))
                {
                    string zawartosc = sr.ReadToEnd();
                    Console.WriteLine($"Zawartość pliku {nazwaPliku}:\n{zawartosc}");
                }
            }
            else
            {
                Console.WriteLine($"Plik o nazwie {nazwaPliku} nie istnieje.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania pliku: {ex.Message}");
        }
    }
}

