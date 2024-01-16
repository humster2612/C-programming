using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Formats.Asn1;

class Program
{
    static List<Osoba> osoby = new List<Osoba>();
    static string filePath = "C:\\Users\\Lenovo\\Desktop\\project lab 7//lab7zad2"; 

    static void Main()
    {
        DanezPliku();

        while (true)
        {
            Console.WriteLine("Menu główne:");
            Console.WriteLine("1. Wyświetl dane");
            Console.WriteLine("2. Dodaj osobę");
            Console.WriteLine("3. Modyfikuj osobę");
            Console.WriteLine("4. Usuń osobę");
            Console.WriteLine("5. Wyjście z programu");

            Console.Write("Wybierz opcję (1-5): ");
            string wybierz = Console.ReadLine();

            switch (wybierz)
            {
                case "1":
                    WyswietlDane();
                    break;

                case "2":
                    DodajOsobe();
                    break;

                case "3":
                    ModyfikujOsobe();
                    break;

                case "4":
                    UsunOsobe();
                    break;

                case "5":
                    ZapiszDaneDoPliku();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Spróbuj ponownie, nieprawidłowy wybór ");
                    break;
            }
        }
    }

    static void WyswietlDane()
    {
        Console.WriteLine("Dane osób:");

        foreach (var osoba in osoby)
        {
            Console.WriteLine($"Imię: {osoba.Imie}, Nazwisko: {osoba.Nazwisko}, Pesel: {osoba.Pesel}, Email: {osoba.Email}, Adres: {osoba.Adres.Ulica}, {osoba.Adres.Miasto}");
        }

        Console.WriteLine();
    }

    static void DodajOsobe()
    {
        try
        {
            Osoba newOsoba = new Osoba();

            Console.Write("Podaj imię: ");

            newOsoba.Imie = Console.ReadLine();


            Console.Write("Podaj nazwisko: ");
            newOsoba.Nazwisko = Console.ReadLine();

            Console.Write("Podaj ulicę zamieszkania: ");
            newOsoba.Adres.Ulica = Console.ReadLine();

            Console.Write("Podaj miasto zamieszkania: ");

            newOsoba.Adres.Miasto = Console.ReadLine();

            Console.Write("Podaj Pesel (11 znaków): ");

            newOsoba.Pesel = Console.ReadLine();


            if (newOsoba.Pesel.Length != 11)
            {
                throw new Exception("Błędny Pesel. Pesel musi zawierać 11 znaków.");
            }

            Console.Write("Podaj adres email: ");
            newOsoba.Email = Console.ReadLine();

            if (!newOsoba.Email.Contains("@"))
            {
                throw new Exception("Błędny format adresu email. Brak znaku @.");
            }

            osoby.Add(newOsoba);
            Console.WriteLine("Osoba dodana do bazy.");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
            Console.WriteLine("Dodawanie osoby nie działa. Spróbuj ponownie.");
        }
    }

    static void ModyfikujOsobe()
    {
        Console.Write("Podaj Pesel osoby do modyfikacji: ");

        string pesel = Console.ReadLine();

        Osoba ModyfikacjaOsoby = osoby.FirstOrDefault(o => o.Pesel == pesel);

        if (ModyfikacjaOsoby != null)
        {
            Console.WriteLine($"Znaleziono osobę: {ModyfikacjaOsoby.Imie} {ModyfikacjaOsoby.Nazwisko}");

            Console.Write("Podaj nowe imię: ");

            ModyfikacjaOsoby.Imie = Console.ReadLine();

            Console.Write("Podaj nowe nazwisko: ");

            ModyfikacjaOsoby.Nazwisko = Console.ReadLine();

            Console.Write("Podaj nową ulicę zamieszkania: ");
            ModyfikacjaOsoby.Adres.Ulica = Console.ReadLine();

            Console.Write("Podaj nowe miasto zamieszkania: ");

            ModyfikacjaOsoby.Adres.Miasto = Console.ReadLine();

            Console.Write("Podaj nowy adres Pesel: ");
            ModyfikacjaOsoby.Pesel = Console.ReadLine();

            Console.Write("Podaj nowy adres email: ");
            ModyfikacjaOsoby.Email = Console.ReadLine();

            Console.WriteLine("Osoba została zaktualizowana.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Nie znaleziono osoby o podanym Pesel.");
            Console.WriteLine();
        }
    }

    static void UsunOsobe()
    {
        Console.Write("Podaj Pesel osoby do usunięcia: ");
        string pesel = Console.ReadLine();

        Osoba UsunietaOsoba = osoby.FirstOrDefault(o => o.Pesel == pesel);

        if (UsunietaOsoba != null)
        {
            osoby.Remove(UsunietaOsoba);

            Console.WriteLine("Osoba usunięta z bazy.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Nie znaleziono osoby o podanym Pesel.");
            Console.WriteLine();
        }
    }

    static void DanezPliku()
    {
        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))

                using (var csv = new CsvReader(reader, config))
                {
                    osoby = csv.GetRecords<Osoba>().ToList();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wynika błąd podczas wczytywania danych z pliku: {ex.Message}");
        }
    }

    static void ZapiszDaneDoPliku()
    {
        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(osoby);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wynika błąd podczas zapisywania danych do pliku: {ex.Message}");
        }
    }

    static void ZapiszDaneDoBazyDanych()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("YourConnectionString")) 
            {
                connection.Open();

       
                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Osoby", connection))
                {
                    deleteCommand.ExecuteNonQuery();
                }

              
                foreach (Osoba osoba in osoby)
                {
                    using (SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO Osoby (Imie, Nazwisko, Ulica, Miasto, Pesel, Email) " +
                        "VALUES (@Imie, @Nazwisko, @Ulica, @Miasto, @Pesel, @Email)", connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Imie", osoba.Imie);
                        insertCommand.Parameters.AddWithValue("@Nazwisko", osoba.Nazwisko);
                        insertCommand.Parameters.AddWithValue("@Ulica", osoba.Adres.Ulica);
                        insertCommand.Parameters.AddWithValue("@Miasto", osoba.Adres.Miasto);
                        insertCommand.Parameters.AddWithValue("@Pesel", osoba.Pesel);
                        insertCommand.Parameters.AddWithValue("@Email", osoba.Email);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas zapisywania danych do bazy danych: {ex.Message}");
        }
    }
}

public class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }

    public Adres Adres { get; set; } = new Adres();
    public string Pesel { get; set; }

    public string Email { get; set; }
}

public class Adres
{
    public string Ulica { get; set; }
    public string Miasto { get; set; }
}
