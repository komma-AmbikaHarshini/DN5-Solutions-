using System;
using System.Collections.Generic;

namespace CSharpExercises
{
    public static class Exercise19_ListDictionary
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 19: Work with Lists and Dictionaries ===");

            // ==================== LIST<T> DEMO ====================
            Console.WriteLine("--- List<string> Operations ---");
            List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
            
            // Add items
            fruits.Add("Date");
            fruits.Insert(1, "Blueberry"); // Insert at specific index

            Console.WriteLine("Fruits after additions:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine($"  - {fruit}");
            }

            // Remove items
            fruits.Remove("Banana");
            fruits.RemoveAt(0); // Removes "Apple"

            Console.WriteLine("\nFruits after removing 'Banana' and index 0:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine($"  - {fruit}");
            }


            // ==================== DICTIONARY<K, V> DEMO ====================
            Console.WriteLine("\n--- Dictionary<int, string> Operations ---");
            Dictionary<int, string> employees = new Dictionary<int, string>
            {
                { 101, "Alice" },
                { 102, "Bob" },
                { 103, "Charlie" }
            };

            // Add items
            employees.Add(104, "David");
            employees[105] = "Eve"; // Indexer syntax

            Console.WriteLine("Employees in dictionary:");
            foreach (KeyValuePair<int, string> emp in employees)
            {
                Console.WriteLine($"  ID: {emp.Key}, Name: {emp.Value}");
            }

            // Remove items
            employees.Remove(102); // Remove Bob

            Console.WriteLine("\nEmployees after removing ID 102:");
            foreach (var (id, name) in employees) // Deconstruction syntax
            {
                Console.WriteLine($"  ID: {id}, Name: {name}");
            }

            // Check if key exists
            int searchId = 103;
            if (employees.TryGetValue(searchId, out string? empName))
            {
                Console.WriteLine($"\nFound Employee with ID {searchId}: {empName}");
            }

            Console.WriteLine("=====================================================");
        }
    }
}
