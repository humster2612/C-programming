using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectOOP_3_0
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int AssignedUserId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public abstract class FileManager<T>
    {
        protected string FilePath;

        public FileManager(string filePath)
        {
            FilePath = filePath;
        }

        protected abstract string Serialize(T entity);
        protected abstract T Deserialize(string line);

        public List<T> ReadFromFile()
        {
            if (File.Exists(FilePath))
            {
                return File.ReadAllLines(FilePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(Deserialize)
                    .ToList();
            }
            return new List<T>();
        }

        public void WriteToFile(List<T> entities)
        {
            var lines = entities.Select(Serialize);
            File.WriteAllLines(FilePath, lines);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
