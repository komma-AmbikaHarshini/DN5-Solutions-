#nullable enable
using System;
using System.Collections.Generic;

namespace CSharpExercises
{
    public class Contact
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public static class Exercise17_NullChaining
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 17: Use Null-Conditional Chaining in a Contact App ===");

            // Create a list of contacts containing some null references or null property values
            List<Contact?> contacts = new List<Contact?>
            {
                new Contact { Name = "Alice", PhoneNumber = "123-456-7890" },
                null, // Entire contact is null
                new Contact { Name = null, PhoneNumber = "555-0199" }, // Name is null
                new Contact { Name = "Charlie", PhoneNumber = null } // PhoneNumber is null
            };

            Console.WriteLine("Iterating through contact list and safely printing non-null names:");
            
            for (int i = 0; i < contacts.Count; i++)
            {
                Contact? c = contacts[i];

                // Safely access name using null-conditional chaining
                // Display the contact's name ONLY if the contact object AND Name property are not null.
                if (c?.Name is not null)
                {
                    Console.WriteLine($"  [Index {i}] Contact Name: {c.Name} (Phone: {c.PhoneNumber ?? "No Phone"})");
                }
                else
                {
                    Console.WriteLine($"  [Index {i}] Skipped displaying (either contact or name was null).");
                }
            }

            Console.WriteLine("===================================================================");
        }
    }
}
