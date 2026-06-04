using System;

namespace CSharpExercises
{
    // C# 12 Primary Constructor syntax
    public class PrimaryPerson(string name, int age)
    {
        // Auto-implemented properties initialized by primary constructor parameters
        public string Name { get; } = name;
        public int Age { get; } = age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Person Full Info -> Name: {Name}, Age: {Age}");
        }
    }

    public static class Exercise3_PrimaryConstructors
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 3: Primary Constructors in C# 12 ===");

            // Instantiate class using primary constructor
            PrimaryPerson person = new PrimaryPerson("John Doe", 30);

            // Display using auto-implemented properties
            Console.WriteLine($"Displaying via properties: {person.Name} ({person.Age} years old)");

            // Call method to display full info
            person.DisplayInfo();

            Console.WriteLine("==================================================");
        }
    }
}
