using System;

namespace CSharpExercises
{
    public static class Exercise5_GradeCalculator
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 5: Perform Conditional Logic for Grade Calculation ===");
            
            Console.Write("Enter a score (0-100) [Press Enter for default of 85]: ");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int score))
            {
                score = 85;
                Console.WriteLine($"Using default score: {score}");
            }

            if (score < 0 || score > 100)
            {
                Console.WriteLine("Error: Score must be between 0 and 100.");
                return;
            }

            // 1. Grade using if, else if, else
            string gradeIfElse;
            if (score >= 90)
            {
                gradeIfElse = "A";
            }
            else if (score >= 80)
            {
                gradeIfElse = "B";
            }
            else if (score >= 70)
            {
                gradeIfElse = "C";
            }
            else if (score >= 60)
            {
                gradeIfElse = "D";
            }
            else
            {
                gradeIfElse = "F";
            }

            // 2. Grade using switch with pattern matching (C# 9.0+)
            string gradeSwitch = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };

            Console.WriteLine($"[If-Else Result] Grade: {gradeIfElse}");
            Console.WriteLine($"[Switch Pattern Matching Result] Grade: {gradeSwitch}");
            Console.WriteLine("====================================================================");
        }
    }
}
