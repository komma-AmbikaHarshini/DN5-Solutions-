using System;

namespace CSharpExercises
{
    // Define an immutable Employee record using init properties
    public record Employee
    {
        public string Name { get; init; } = "";
        public string Position { get; init; } = "";
        public decimal Salary { get; init; }
    }

    public static class Exercise13_RecordsInit
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 13: Create and Use Records with init Properties ===");

            // 1. Instantiate the record
            Employee emp1 = new Employee
            {
                Name = "Alice Smith",
                Position = "Software Engineer",
                Salary = 85000m
            };

            Console.WriteLine($"Original Employee: Name={emp1.Name}, Position={emp1.Position}, Salary=${emp1.Salary}");

            // Trying to modify directly would cause a compiler error:
            // emp1.Name = "Bob"; // CS8852: Init-only property can only be assigned in an object initializer

            // 2. Use 'with' expression to create a modified copy
            Employee emp2 = emp1 with { Position = "Lead Engineer", Salary = 95000m };

            Console.WriteLine($"Modified Copy:     Name={emp2.Name}, Position={emp2.Position}, Salary=${emp2.Salary}");
            
            // 3. Print the original record to verify it is unchanged
            Console.WriteLine($"Original Employee (Verification): Name={emp1.Name}, Position={emp1.Position}, Salary=${emp1.Salary}");
            
            // 4. Value-based equality check (inherent in records)
            Employee empCopy = emp1 with { };
            Console.WriteLine($"emp1 == empCopy (value equality): {emp1 == empCopy}");

            Console.WriteLine("=================================================================");
        }
    }
}
