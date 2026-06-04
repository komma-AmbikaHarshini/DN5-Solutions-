using System;

namespace CSharpExercises
{
    public static class Exercise22_TuplesDeconstruction
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 22: Create and Deconstruct Tuples ===");

            // 1. Call method and get the tuple
            var resultTuple = GetEmployeeInfo();
            Console.WriteLine($"Returned Tuple: ID = {resultTuple.Id}, Name = {resultTuple.Name}");

            // 2. Deconstruct the tuple in-place
            (int empId, string empName) = GetEmployeeInfo();
            Console.WriteLine($"Deconstructed (explicit types) -> ID: {empId}, Name: {empName}");

            // 3. Deconstruct with var (implicitly typed)
            var (id, name) = GetEmployeeInfo();
            Console.WriteLine($"Deconstructed (var keyword)    -> ID: {id}, Name: {name}");

            // 4. Deconstruct with discard (_) if we only care about the name
            var (_, justTheName) = GetEmployeeInfo();
            Console.WriteLine($"Deconstructed (with discard)   -> Name: {justTheName} (ID was discarded)");

            Console.WriteLine("==================================================");
        }

        // Method returning a tuple with named elements
        public static (int Id, string Name) GetEmployeeInfo()
        {
            int id = 5001;
            string name = "Johnathan";
            
            // Return tuple literal
            return (id, name);
        }
    }
}
