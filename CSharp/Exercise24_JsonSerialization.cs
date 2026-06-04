using System;
using System.IO;
using System.Text.Json;

namespace CSharpExercises
{
    public class User
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    }

    public static class Exercise24_JsonSerialization
    {
        private const string FilePath = "user.json";

        public static void Run()
        {
            Console.WriteLine("=== Exercise 24: Serialize and Deserialize JSON Files ===");

            // 1. Create a User object
            User originalUser = new User
            {
                Name = "Sarah Connor",
                Age = 29,
                Email = "sarah.connor@cyberdyne.com"
            };

            Console.WriteLine($"Original User: Name={originalUser.Name}, Age={originalUser.Age}, Email={originalUser.Email}");

            // 2. Serialize to JSON string
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(originalUser, options);
            Console.WriteLine("\nSerialized JSON String:");
            Console.WriteLine(jsonString);

            // 3. Save JSON string to a file
            try
            {
                File.WriteAllText(FilePath, jsonString);
                Console.WriteLine($"\nSuccessfully saved JSON to file: {Path.GetFullPath(FilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
                return;
            }

            // 4. Read JSON back from the file
            string fileContent = "";
            try
            {
                fileContent = File.ReadAllText(FilePath);
                Console.WriteLine("\nRead JSON from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return;
            }

            // 5. Deserialize JSON back into User object
            User? deserializedUser = JsonSerializer.Deserialize<User>(fileContent);

            if (deserializedUser != null)
            {
                Console.WriteLine("\nDeserialized User Object Properties:");
                Console.WriteLine($"  Name:  {deserializedUser.Name}");
                Console.WriteLine($"  Age:   {deserializedUser.Age}");
                Console.WriteLine($"  Email: {deserializedUser.Email}");
            }
            else
            {
                Console.WriteLine("Failed to deserialize JSON.");
            }

            // Clean up the temporary file
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    Console.WriteLine("\nTemporary file 'user.json' cleaned up.");
                }
            }
            catch { /* Ignore cleanup errors */ }

            Console.WriteLine("=========================================================");
        }
    }
}
