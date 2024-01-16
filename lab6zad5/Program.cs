using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public interface IPersonRepository
{
    void AddPerson(Person person);
    Person GetPersonById(int id);
    List<Person> GetAllPersons();
}

public class FilePersonRepository : IPersonRepository
{
    private readonly string filePath;

    public FilePersonRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public void AddPerson(Person person)
    {
        try
        {
            var persons = GetAllPersons();
            persons.Add(person);

            string jsonData = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas dodawania osoby: {ex.Message}");
        }
    }

    public Person GetPersonById(int id)
    {
        var persons = GetAllPersons();
        return persons.Find(p => p.Id == id);
    }

    public List<Person> GetAllPersons()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Person>>(jsonData) ?? new List<Person>();
            }
            else
            {
                return new List<Person>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytywania danych z pliku: {ex.Message}");
            return new List<Person>();
        }
    }
}

public record Person(int Id, string FirstName, string LastName);

class Program
{
    static void Main()
    {
       
        IPersonRepository personRepository = new FilePersonRepository("persons.json");

       
        Person newPerson = new Person(1, "John", "Doe");
        personRepository.AddPerson(newPerson);

     
        int personIdToFind = 1;
        Person foundPerson = personRepository.GetPersonById(personIdToFind);

        if (foundPerson != null)
        {
            Console.WriteLine($"Znaleziono osobę o ID {personIdToFind}: {foundPerson.FirstName} {foundPerson.LastName}");
        }
        else
        {
            Console.WriteLine($"Osoba o ID {personIdToFind} nie została znaleziona.");
        }

   a
        List<Person> allPersons = personRepository.GetAllPersons();
        Console.WriteLine("\nWszystkie osoby w repozytorium:");
        foreach (var person in allPersons)
        {
            Console.WriteLine($"{person.Id}: {person.FirstName} {person.LastName}");
        }
    }
}
