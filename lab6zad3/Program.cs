using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string nazwaPliku = "pesels.txt";
        List<string> listaPeseli = WczytajListePeseliZPliku(nazwaPliku);

        if (listaPeseli != null)
        {
            Console.WriteLine("Wczytano pesele z pliku:");
            foreach (string pesel in listaPeseli)
            {
                Console.WriteLine(pesel);
            }

            int liczbaZenskichPeseli = LiczbaZenskichPeseli(listaPeseli);
            Console.WriteLine($"\nLiczba żeńskich peseli: {liczbaZenskichPeseli}");
        }
        else
        {
            Console.WriteLine($"Nie udało się wczytać peseli z pliku {nazwaPliku}.");
        }
    }

    static List<string> WczytajListePeseliZPliku(string nazwaPliku)
    {
        try
        {
            if (File.Exists(nazwaPliku))
            {
                List<string> listaPeseli = new List<string>();
                using (StreamReader sr = new StreamReader(nazwaPliku))
                {
                    string linia;
                    while ((linia = sr.ReadLine()) != null)
                    {
                        listaPeseli.Add(linia);
                    }
                }
                return listaPeseli;
            }
            else
            {
                Console.WriteLine($"Plik o nazwie {nazwaPliku} nie istnieje.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania pliku: {ex.Message}");
            return null;
        }
    }

    static int LiczbaZenskichPeseli(List<string> listaPeseli)
    {
        int liczbaZenskich = 0;
        foreach (string pesel in listaPeseli)
        {
            if (CzyPeselJestZenski(pesel))
            {
                liczbaZenskich++;
            }
        }
        return liczbaZenskich;
    }

    static bool CzyPeselJestZenski(string pesel)
    {
        int cyfra = int.Parse(pesel.Substring(9, 1));
        return cyfra % 2 == 0;
    }
}

