using System;
using System.Text;

namespace CSharpExercises
{
    public class SimpleWidget
    {
        public string Model { get; set; } = "Default Model";
    }

    public static class Exercise4_TypeInference
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 4: Type Inference with var and new() ===");

            // 1. var (Implicitly typed local variables)
            var count = 42;                    // System.Int32
            var message = "Hello Type Inference"; // System.String
            var builder = new StringBuilder(); // System.Text.StringBuilder

            // 2. target-typed new() (C# 9+)
            SimpleWidget widget = new();       // Instantiates SimpleWidget
            double[] prices = new[] { 19.99, 9.99, 4.99 }; // Array type inference

            // Print types and values
            Console.WriteLine($"Variable 'count': Type = {count.GetType()}, Value = {count}");
            Console.WriteLine($"Variable 'message': Type = {message.GetType()}, Value = {message}");
            Console.WriteLine($"Variable 'builder': Type = {builder.GetType()}, Value = '{builder}'");
            Console.WriteLine($"Variable 'widget': Type = {widget.GetType()}, Value.Model = '{widget.Model}'");
            Console.WriteLine($"Variable 'prices': Type = {prices.GetType()}, Elements = {string.Join(", ", prices)}");

            // Discussion
            Console.WriteLine("\n--- Discussion on Type Inference ---");
            Console.WriteLine("1. When beneficial:");
            Console.WriteLine("   - Reduces boilerplate and redundant code (e.g. var dictionary = new Dictionary<int, string>()).");
            Console.WriteLine("   - Improves maintainability when changing types that support the same operations.");
            Console.WriteLine("2. When it affects readability:");
            Console.WriteLine("   - When the type is not obvious from the initializer (e.g. var x = ExecuteServiceProcess()).");
            Console.WriteLine("   - Overuse with simple built-in types (e.g. using var for int/bool where the type is short anyway).");
            Console.WriteLine("=====================================================");
        }
    }
}
