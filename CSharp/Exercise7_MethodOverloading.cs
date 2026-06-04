using System;

namespace CSharpExercises
{
    public static class Exercise7_MethodOverloading
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 7: Implement Method Overloading ===");

            // Call two-integer overload
            int sumInts = CalculateTotal(15, 25);
            Console.WriteLine($"CalculateTotal(15, 25) [int, int] -> Result: {sumInts}");

            // Call three-double overload
            double sumDoubles = CalculateTotal(10.5, 20.2, 5.3);
            Console.WriteLine($"CalculateTotal(10.5, 20.2, 5.3) [double, double, double] -> Result: {sumDoubles}");

            // Call array overload
            int[] arr = { 1, 2, 3, 4, 5 };
            int sumArray = CalculateTotal(arr);
            Console.WriteLine($"CalculateTotal(new int[] {{ 1, 2, 3, 4, 5 }}) [int[]] -> Result: {sumArray}");

            Console.WriteLine("=================================================");
        }

        // Overload 1: Two integers
        public static int CalculateTotal(int a, int b)
        {
            return a + b;
        }

        // Overload 2: Three doubles
        public static double CalculateTotal(double a, double b, double c)
        {
            return a + b + c;
        }

        // Overload 3: Array of integers
        public static int CalculateTotal(int[] numbers)
        {
            int total = 0;
            foreach (var num in numbers)
            {
                total += num;
            }
            return total;
        }
    }
}
