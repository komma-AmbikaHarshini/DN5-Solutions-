using System;

namespace CSharpExercises
{
    public static class Exercise6_LoopTypes
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 6: Loop Through an Array with Different Loop Types ===");

            int[] numbers = { 10, 20, 30, 40, 50, 60, 70 };
            Console.WriteLine($"Source array: [{string.Join(", ", numbers)}]");
            Console.WriteLine("Rule: Skip 30 (using continue), Stop loop if value is 60 (using break).\n");

            // 1. For Loop
            Console.Write("[for loop] Output: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 30) continue; // skip
                if (numbers[i] == 60) break;    // stop
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            // 2. Foreach Loop
            Console.Write("[foreach loop] Output: ");
            foreach (int num in numbers)
            {
                if (num == 30) continue;
                if (num == 60) break;
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            // 3. While Loop
            Console.Write("[while loop] Output: ");
            int index = 0;
            while (index < numbers.Length)
            {
                int val = numbers[index];
                index++; // Increment index immediately to avoid infinite loop when skipping
                if (val == 30) continue;
                if (val == 60) break;
                Console.Write($"{val} ");
            }
            Console.WriteLine();

            // 4. Do-While Loop
            Console.Write("[do-while loop] Output: ");
            int indexDo = 0;
            do
            {
                int val = numbers[indexDo];
                indexDo++;
                if (val == 30) continue;
                if (val == 60) break;
                Console.Write($"{val} ");
            } while (indexDo < numbers.Length);
            Console.WriteLine();

            Console.WriteLine("===================================================================");
        }
    }
}
