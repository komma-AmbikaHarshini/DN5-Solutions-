using System;

namespace CSharpExercises
{
    public class PersonClass
    {
        public string Name { get; set; } = "";
    }

    public static class Exercise2_ValueRefTypes
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 2: Explore Value vs Reference Types ===");

            // 1. Value Type (int)
            int number = 10;
            Console.WriteLine($"[Value Type] Before Modify: number = {number}");
            ModifyValueType(number);
            Console.WriteLine($"[Value Type] After Modify: number = {number} (Unchanged)");

            // 2. Reference Type (Custom Class)
            PersonClass person = new PersonClass { Name = "Alice" };
            Console.WriteLine($"[Reference Type] Before Modify: person.Name = '{person.Name}'");
            ModifyReferenceType(person);
            Console.WriteLine($"[Reference Type] After Modify: person.Name = '{person.Name}' (Changed!)");

            // 3. Special Reference Type (string - immutable)
            string text = "Hello";
            Console.WriteLine($"[Reference Type: string] Before Modify: text = '{text}'");
            ModifyString(text);
            Console.WriteLine($"[Reference Type: string] After Modify: text = '{text}' (Unchanged because strings are immutable)");

            Console.WriteLine("====================================================");
        }

        private static void ModifyValueType(int val)
        {
            val = 99; // Modifies the local copy
        }

        private static void ModifyReferenceType(PersonClass obj)
        {
            obj.Name = "Bob"; // Modifies the object stored on the heap
        }

        private static void ModifyString(string str)
        {
            str = "World"; // Reassigning a new reference locally, doesn't affect caller
        }
    }
}
