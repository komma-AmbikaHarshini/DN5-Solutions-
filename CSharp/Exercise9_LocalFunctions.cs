using System;

namespace CSharpExercises
{
    public static class Exercise9_LocalFunctions
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 9: Use Local Functions ===");

            int number = 5;
            long factorial = CalculateFactorial(number);
            Console.WriteLine($"Factorial of {number} is {factorial}");

            int numberZero = 0;
            Console.WriteLine($"Factorial of {numberZero} is {CalculateFactorial(numberZero)}");

            Console.WriteLine("========================================");
        }

        public static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            // Local function to perform the recursive factorial calculation
            long GetFactorial(int current)
            {
                if (current <= 1) return 1;
                return current * GetFactorial(current - 1);
            }

            // Call the local function and return the result
            return GetFactorial(n);
        }
    }
}
