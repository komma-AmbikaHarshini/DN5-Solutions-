using System;
using System.Threading.Tasks;

namespace CSharpExercises
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("             C# MODULE 3 EXERCISES RUNNER                 ");
                Console.WriteLine("==========================================================");
                Console.WriteLine(" 1. Setup Development Env       16. Handle Nulls Safely");
                Console.WriteLine(" 2. Value vs Reference Types    17. Null-Conditional Chaining");
                Console.WriteLine(" 3. Primary Constructors        18. Required Modifier");
                Console.WriteLine(" 4. Type Inference (var/new)    19. Lists and Dictionaries");
                Console.WriteLine(" 5. Grade Calculator            20. LINQ Filter & Projection");
                Console.WriteLine(" 6. Loop Types (Arrays)         21. Pattern Matching (is/switch)");
                Console.WriteLine(" 7. Method Overloading          22. Tuples Deconstruction");
                Console.WriteLine(" 8. ref, out, in Parameters     23. Async Upload Simulation");
                Console.WriteLine(" 9. Local Functions             24. JSON Serialization");
                Console.WriteLine("10. OOP Basics with Constructors25. FileStream & MemoryStream");
                Console.WriteLine("11. Access Modifiers            26. Race Conditions");
                Console.WriteLine("12. Auto-Properties & Backing   27. Deadlock Simulation/Resolve");
                Console.WriteLine("13. Records with init           28. Trace Logging");
                Console.WriteLine("14. Inheritance & Overriding    29. XSS Input Sanitization");
                Console.WriteLine("15. Abstract vs Interface");
                Console.WriteLine("==========================================================");
                Console.WriteLine("Enter exercise number (1-29) to run, or '0' to exit.");
                Console.Write("Choice: ");

                string? input = Console.ReadLine();

                if (input == "0" || input?.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting. Have a great day!");
                    break;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 29)
                {
                    Console.Clear();
                    try
                    {
                        await RunExerciseAsync(choice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred running the exercise: {ex.Message}");
                    }
                    
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey(true);
                }
            }
        }

        private static async Task RunExerciseAsync(int choice)
        {
            switch (choice)
            {
                case 1:
                    Exercise1_Setup.Run();
                    break;
                case 2:
                    Exercise2_ValueRefTypes.Run();
                    break;
                case 3:
                    Exercise3_PrimaryConstructors.Run();
                    break;
                case 4:
                    Exercise4_TypeInference.Run();
                    break;
                case 5:
                    Exercise5_GradeCalculator.Run();
                    break;
                case 6:
                    Exercise6_LoopTypes.Run();
                    break;
                case 7:
                    Exercise7_MethodOverloading.Run();
                    break;
                case 8:
                    Exercise8_RefOutInParameters.Run();
                    break;
                case 9:
                    Exercise9_LocalFunctions.Run();
                    break;
                case 10:
                    Exercise10_OOPBasics.Run();
                    break;
                case 11:
                    Exercise11_AccessModifiers.Run();
                    break;
                case 12:
                    Exercise12_AutoProperties.Run();
                    break;
                case 13:
                    Exercise13_RecordsInit.Run();
                    break;
                case 14:
                    Exercise14_InheritanceOverriding.Run();
                    break;
                case 15:
                    Exercise15_AbstractInterface.Run();
                    break;
                case 16:
                    Exercise16_NullSafety.Run();
                    break;
                case 17:
                    Exercise17_NullChaining.Run();
                    break;
                case 18:
                    Exercise18_RequiredModifier.Run();
                    break;
                case 19:
                    Exercise19_ListDictionary.Run();
                    break;
                case 20:
                    Exercise20_LinqQuery.Run();
                    break;
                case 21:
                    Exercise21_PatternMatching.Run();
                    break;
                case 22:
                    Exercise22_TuplesDeconstruction.Run();
                    break;
                case 23:
                    // Async exercise
                    await Exercise23_AsyncUpload.RunAsync();
                    break;
                case 24:
                    Exercise24_JsonSerialization.Run();
                    break;
                case 25:
                    Exercise25_FileMemoryStream.Run();
                    break;
                case 26:
                    Exercise26_RaceConditions.Run();
                    break;
                case 27:
                    Exercise27_DeadlockResolution.Run();
                    break;
                case 28:
                    Exercise28_TraceLogging.Run();
                    break;
                case 29:
                    Exercise29_XssSanitization.Run();
                    break;
                default:
                    Console.WriteLine("Exercise not implemented yet.");
                    break;
            }
        }
    }
}
