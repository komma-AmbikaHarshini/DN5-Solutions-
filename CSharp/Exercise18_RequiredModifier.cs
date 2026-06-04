using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharpExercises
{
    public class Student
    {
        // 'required' modifier enforces that these properties MUST be initialized during object creation
        public required string StudentId { get; set; }
        public required string FullName { get; set; }
        
        // Optional property
        public string Major { get; set; } = "Undeclared";

        public Student() { }

        // Sets required properties using SetsRequiredMembers attribute (in case constructors are used)
        [SetsRequiredMembers]
        public Student(string id, string name, string major)
        {
            StudentId = id;
            FullName = name;
            Major = major;
        }
    }

    public static class Exercise18_RequiredModifier
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 18: Use the required Modifier ===");

            // 1. Correct instantiation using object initializer
            Student student1 = new Student
            {
                StudentId = "S1001",
                FullName = "Alice Cooper",
                Major = "Computer Science"
            };
            Console.WriteLine($"Successfully instantiated student1: {student1.FullName} (ID: {student1.StudentId})");

            // 2. Correct instantiation using SetsRequiredMembers constructor
            Student student2 = new Student("S1002", "Bob Dylan", "Music");
            Console.WriteLine($"Successfully instantiated student2: {student2.FullName} (ID: {student2.StudentId})");

            // 3. Demonstrating Compiler Enforcement
            Console.WriteLine("\n--- Compiler Enforcement Note ---");
            Console.WriteLine("Attempting to instantiate a Student without specifying required fields:");
            Console.WriteLine("  e.g.: Student s = new Student { StudentId = \"S1003\" };");
            Console.WriteLine("Will result in a compile-time error:");
            Console.WriteLine("  \"Error CS9035: Required member 'Student.FullName' must be set in the object initializer or attribute constructor.\"");
            
            /*
            // Un-commenting the code below will prevent the project from building:
            Student invalidStudent = new Student
            {
                StudentId = "S1003"
                // Error: FullName is not initialized!
            };
            */

            Console.WriteLine("==============================================");
        }
    }
}
