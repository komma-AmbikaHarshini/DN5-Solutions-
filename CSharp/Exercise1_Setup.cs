using System;

namespace CSharpExercises
{
    public static class Exercise1_Setup
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 1: Set Up the Development Environment ===");
            Console.WriteLine("Hello, World!");
            Console.WriteLine(".NET SDK environment is successfully set up and validated.");
            Console.WriteLine("Current .NET Version: " + Environment.Version);
            Console.WriteLine("OS Version: " + Environment.OSVersion);
            Console.WriteLine("======================================================");
        }
    }
}
