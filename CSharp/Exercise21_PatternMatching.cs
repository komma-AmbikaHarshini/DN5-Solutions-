using System;

namespace CSharpExercises
{
    public class PatternVehicle
    {
        public string Model { get; set; } = "Generic Vehicle";
    }

    public static class Exercise21_PatternMatching
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 21: Use Pattern Matching with is and switch ===");

            object[] testObjects = {
                42,
                "Hello C# Pattern Matching",
                new PatternVehicle { Model = "Ford Mustang" },
                -5.5,
                null!
            };

            Console.WriteLine("--- Method 1: Using 'is' Pattern Matching ---");
            foreach (var obj in testObjects)
            {
                DescribeObjectWithIs(obj);
            }

            Console.WriteLine("\n--- Method 2: Using Enhanced Switch (Type Patterns) ---");
            foreach (var obj in testObjects)
            {
                string description = GetDescriptionWithSwitch(obj);
                Console.WriteLine($"Input: {(obj == null ? "null" : obj.ToString())} -> Switch Result: {description}");
            }

            Console.WriteLine("=============================================================");
        }

        // 1. Pattern matching with 'is' (declaration pattern)
        private static void DescribeObjectWithIs(object obj)
        {
            if (obj is null)
            {
                Console.WriteLine("  The object is null.");
            }
            else if (obj is int integerVal)
            {
                Console.WriteLine($"  The object is an Integer: {integerVal} (Double value: {integerVal * 2})");
            }
            else if (obj is string stringVal)
            {
                Console.WriteLine($"  The object is a String: \"{stringVal}\" (Length: {stringVal.Length})");
            }
            else if (obj is PatternVehicle vehicleVal)
            {
                Console.WriteLine($"  The object is a PatternVehicle: Model = '{vehicleVal.Model}'");
            }
            else
            {
                Console.WriteLine($"  The object is of type {obj.GetType().Name} and is not specifically matched.");
            }
        }

        // 2. Enhanced switch statement with type pattern matching and relational/logical filters
        private static string GetDescriptionWithSwitch(object obj) => obj switch
        {
            null => "Null object",
            int i when i > 0 => $"Positive Integer: {i}",
            int i => $"Non-positive Integer: {i}",
            string s => $"String of length {s.Length} containing '{s}'",
            PatternVehicle v => $"PatternVehicle object with model '{v.Model}'",
            double d => $"Double float value: {d}",
            _ => $"Unsupported type: {obj.GetType().Name}"
        };
    }
}
