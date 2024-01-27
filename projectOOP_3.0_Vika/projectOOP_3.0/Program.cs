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

        // Абстрактные методы для сериализации и десериализации
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

    public class TaskFileManager : FileManager<Task>
    {
        public TaskFileManager(string filePath) : base(filePath) { }

        protected override string Serialize(Task task)
        {
            return $"{task.Id},{task.Title},{task.Description},{task.CategoryId},{task.AssignedUserId}";
        }

        protected override Task Deserialize(string line)
        {
            var taskDetails = line.Split(',');
            if (taskDetails.Length == 5 &&
                int.TryParse(taskDetails[0], out int id) &&
                int.TryParse(taskDetails[3], out int categoryId) &&
                int.TryParse(taskDetails[4], out int assignedUserId))
            {
                return new Task
                {
                    Id = id,
                    Title = taskDetails[1],
                    Description = taskDetails[2],
                    CategoryId = categoryId,
                    AssignedUserId = assignedUserId
                };
            }
            return null;
        }
    }

    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private List<Category> categories = new List<Category>();
        private List<User> users = new List<User>();
        private TaskFileManager taskFileManager;

        public TaskManager(string filePath)
        {
            taskFileManager = new TaskFileManager(filePath);
        }

        public void LoadData()
        {
            tasks = taskFileManager.ReadFromFile();
        }

        public void SaveData()
        {
            taskFileManager.WriteToFile(tasks);
        }

        public void CreateTask(Task task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            SaveData();
        }

        public Task ReadTask(int id)
        {
            return tasks.Find(t => t.Id == id);
        }

        public void UpdateTask(Task updatedTask)
        {
            var existingTask = tasks.Find(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.CategoryId = updatedTask.CategoryId;
                existingTask.AssignedUserId = updatedTask.AssignedUserId;
                SaveData();
            }
        }

        public void DeleteTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
            SaveData();
        }

        public void CreateCategory(Category category)
        {
            category.Id = categories.Count + 1;
            categories.Add(category);
        }

        public void CreateUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }
    }

    internal class Program
    {
        static TaskManager taskManager;

        static void Main(string[] args)
        {
            taskManager = new TaskManager("D:\\Programming\\ProgrammingBasics\\ProjectsC#\\projectOOP_3.0_Vika\\data.txt");
            taskManager.LoadData();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Read Task");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Create Category");
                Console.WriteLine("6. Create User");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateTask();
                        break;

                    case "2":
                        ReadTask();
                        break;

                    case "3":
                        UpdateTask();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        CreateCategory();
                        break;

                    case "6":
                        CreateUser();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void CreateTask()
        {
            Console.WriteLine("Enter task title:");
            var title = Console.ReadLine();

            Console.WriteLine("Enter task description:");
            var description = Console.ReadLine();

            Console.WriteLine("Enter category ID:");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Enter assigned user ID:");
                if (int.TryParse(Console.ReadLine(), out var userId))
                {
                    var newTask = new Task
                    {
                        Title = title,
                        Description = description,
                        CategoryId = categoryId,
                        AssignedUserId = userId
                    };

                    taskManager.CreateTask(newTask);
                    Console.WriteLine("Task created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid user ID. Task creation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid category ID. Task creation failed.");
            }
        }

        static void ReadTask()
        {
            Console.WriteLine("Enter task ID:");
            if (int.TryParse(Console.ReadLine(), out var taskId))
            {
                var retrievedTask = taskManager.ReadTask(taskId);
                if (retrievedTask != null)
                {
                    Console.WriteLine($"Retrieved Task: {retrievedTask.Title}, Assigned to: {retrievedTask.AssignedUserId}");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void UpdateTask()
        {
            Console.WriteLine("Enter task ID to update:");
            if (int.TryParse(Console.ReadLine(), out var taskId))
            {
                var existingTask = taskManager.ReadTask(taskId);
                if (existingTask != null)
                {
                    Console.WriteLine("Enter updated task title:");
                    var updatedTitle = Console.ReadLine();

                    Console.WriteLine("Enter updated task description:");
                    var updatedDescription = Console.ReadLine();

                    Console.WriteLine("Enter updated category ID:");
                    if (int.TryParse(Console.ReadLine(), out var updatedCategoryId))
                    {
                        Console.WriteLine("Enter updated assigned user ID:");
                        if (int.TryParse(Console.ReadLine(), out var updatedUserId))
                        {
                            var updatedTask = new Task
                            {
                                Id = taskId,
                                Title = updatedTitle,
                                Description = updatedDescription,
                                CategoryId = updatedCategoryId,
                                AssignedUserId = updatedUserId
                            };

                            taskManager.UpdateTask(updatedTask);
                            Console.WriteLine("Task updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid user ID. Task update failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid category ID. Task update failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void DeleteTask()
        {
            Console.WriteLine("Enter task ID to delete:");
            if (int.TryParse(Console.ReadLine(), out var taskId))
            {
                taskManager.DeleteTask(taskId);
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void CreateCategory()
        {
            Console.WriteLine("Enter category name:");
            var categoryName = Console.ReadLine();

            var newCategory = new Category { Name = categoryName };
            taskManager.CreateCategory(newCategory);
            Console.WriteLine("Category created successfully.");
        }

        static void CreateUser()
        {
            Console.WriteLine("Enter user name:");
            var userName = Console.ReadLine();

            var newUser = new User { Name = userName };
            taskManager.CreateUser(newUser);
            Console.WriteLine("User created successfully.");
        }
    }
}
