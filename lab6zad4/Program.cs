using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string sciezkaDoBazy = "db.json";

        // Wczytaj dane z pliku JSON
        List<PopulacjaKraju> danePopulacji = WczytajDanePopulacji(sciezkaDoBazy);

        if (danePopulacji != null)
        {
            // Przykładowe operacje
            Console.WriteLine("1. Różnica populacji Indii między rokiem 1970 a 2000: " + RoznicaPopulacji(1970, 2000, "India", danePopulacji));
            Console.WriteLine("2. Różnica populacji USA między rokiem 1965 a 2010: " + RoznicaPopulacji(1965, 2010, "USA", danePopulacji));
            Console.WriteLine("3. Różnica populacji Chin między rokiem 1980 a 2018: " + RoznicaPopulacji(1980, 2018, "China", danePopulacji));

            // Użytkownik wybiera rok i kraj
            Console.Write("4. Podaj rok: ");
            int wybranyRok = int.Parse(Console.ReadLine());

            Console.Write("   Podaj kraj (USA, India, China): ");
            string wybranyKraj = Console.ReadLine();

            WyswietlPopulacjeDlaKrajuIRoku(wybranyKraj, wybranyRok, danePopulacji);

            // Użytkownik sprawdza różnicę populacji dla wskazanego zakresu lat i kraju
            Console.WriteLine("5. Podaj zakres lat i kraj dla którego chcesz sprawdzić różnicę populacji:");
            Console.Write("   Początkowy rok: ");
            int poczatkowyRok = int.Parse(Console.ReadLine());

            Console.Write("   Końcowy rok: ");
            int koncowyRok = int.Parse(Console.ReadLine());

            Console.Write("   Podaj kraj (USA, India, China): ");
            string wybranyKraj2 = Console.ReadLine();

            WyswietlRoznicePopulacjiDlaKrajuIZakresuLat(wybranyKraj2, poczatkowyRok, koncowyRok, danePopulacji);

            // Użytkownik sprawdza procentowy wzrost populacji dla każdego kraju względem roku poprzedniego do wskazanego
            Console.WriteLine("6. Podaj rok początkowy i końcowy dla którego chcesz sprawdzić procentowy wzrost populacji:");
            Console.Write("   Rok początkowy: ");
            int rokPoczatkowy = int.Parse(Console.ReadLine());

            Console.Write("   Rok końcowy: ");
            int rokKoncowy = int.Parse(Console.ReadLine());

            WyswietlProcentowyWzrostPopulacji(rokPoczatkowy, rokKoncowy, danePopulacji);
        }
    }

    static List<PopulacjaKraju> WczytajDanePopulacji(string sciezka)
    {
        try
        {
            string json = File.ReadAllText(sciezka);
            List<PopulacjaKraju> danePopulacji = JsonConvert.DeserializeObject<List<PopulacjaKraju>>(json);
            return danePopulacji;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych z pliku: {ex.Message}");
            return null;
        }
    }

    static int RoznicaPopulacji(int rokPoczatkowy, int rokKoncowy, string kraj, List<PopulacjaKraju> danePopulacji)
    {
        var populacjaPoczatkowa = danePopulacji.Find(p => p.Rok == rokPoczatkowy && p.Kraj == kraj)?.Ludnosc ?? 0;
        var populacjaKoncowa = danePopulacji.Find(p => p.Rok == rokKoncowy && p.Kraj == kraj)?.Ludnosc ?? 0;

        return populacjaKoncowa - populacjaPoczatkowa;
    }

    static void WyswietlPopulacjeDlaKrajuIRoku(string kraj, int rok, List<PopulacjaKraju> danePopulacji)
    {
        var populacja = danePopulacji.Find(p => p.Rok == rok && p.Kraj == kraj)?.Ludnosc;
        if (populacja.HasValue)
        {
            Console.WriteLine($"Populacja kraju {kraj} w roku {rok}: {populacja.Value}");
        }
        else
        {
            Console.WriteLine($"Brak danych dla kraju {kraj} w roku {rok}.");
        }
    }

    static void WyswietlRoznicePopulacjiDlaKrajuIZakresuLat(string kraj, int rokPoczatkowy, int rokKoncowy, List<PopulacjaKraju> danePopulacji)
    {
        int roznicaPopulacji = RoznicaPopulacji(rokPoczatkowy, rokKoncowy, kraj, danePopulacji);
        Console.WriteLine($"Różnica populacji kraju {kraj} między rokiem {rokPoczatkowy} a {rokKoncowy}: {roznicaPopulacji}");
    }

    static void WyswietlProcentowyWzrostPopulacji(int rokPoczatkowy, int rokKoncowy, List<PopulacjaKraju> danePopulacji)
    {
        foreach (var kraj in new[] { "USA", "India", "China" })
        {
            var populacjaPoczatkowa = danePopulacji.Find(p => p.Rok == rokPoczatkowy && p.Kraj == kraj)?.Ludnosc ?? 0;
            var populacjaKoncowa = danePopulacji.Find(p => p.Rok == rokKoncowy && p.Kraj == kraj)?.Ludnosc ?? 0;

            double procentowyWzrost = (populacjaKoncowa - populacjaPoczatkowa) / (double)populacjaPoczatkowa * 100;

            Console.WriteLine($"Procentowy wzrost populacji dla kraju {kraj} od roku {rokPoczatkowy} do {rokKoncowy}: {procentowyWzrost:F2}%");
        }
    }
}

class PopulacjaKraju
{
    public int Rok { get; set; }
    public string Kraj { get; set; }
    public int Ludnosc { get; set; }
}

