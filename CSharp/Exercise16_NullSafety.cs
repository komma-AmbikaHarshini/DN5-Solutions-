#nullable enable
using System;

namespace CSharpExercises
{
    public class NullableAddress
    {
        public string City { get; set; } = "Unknown City";
    }

    public class NullablePerson
    {
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; } // Nullable string
        public string LastName { get; set; } = "";
        public NullableAddress? Address { get; set; } // Nullable custom reference type
    }

    public static class Exercise16_NullSafety
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 16: Handle Null References Safely ===");

            // 1. Create a person with some null values
            NullablePerson person1 = new NullablePerson
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = null // Explicitly null
            };

            // 2. Create a person with complete values
            NullablePerson person2 = new NullablePerson
            {
                FirstName = "John",
                MiddleName = "Robert",
                LastName = "Smith",
                Address = new NullableAddress { City = "Seattle" }
            };

            // 3. Demonstrate Null-conditional operator (?.)
            Console.WriteLine($"[Null-Conditional] person1.Address?.City: {person1.Address?.City ?? "(Address was null)"}");
            Console.WriteLine($"[Null-Conditional] person2.Address?.City: {person2.Address?.City}");

            // 4. Demonstrate Null-coalescing operator (??)
            string middle1 = person1.MiddleName ?? "N/A";
            string middle2 = person2.MiddleName ?? "N/A";
            Console.WriteLine($"[Null-Coalescing] person1.MiddleName (fallback): {middle1}");
            Console.WriteLine($"[Null-Coalescing] person2.MiddleName (fallback): {middle2}");

            // 5. Demonstrate Null checking pattern matching (is / is not)
            PrintPersonStatus(person1);
            PrintPersonStatus(null);

            Console.WriteLine("==================================================");
        }

        private static void PrintPersonStatus(NullablePerson? person)
        {
            if (person is null)
            {
                Console.WriteLine("[Null Check] The person object is null.");
                return;
            }

            Console.WriteLine($"[Null Check] Person {person.FirstName} {person.LastName} is NOT null.");
        }
    }
}
