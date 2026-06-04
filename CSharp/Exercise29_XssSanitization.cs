using System;
using System.Net;

namespace CSharpExercises
{
    public static class Exercise29_XssSanitization
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 29: Sanitize Input and Prevent XSS ===");

            // 1. Simulate a malicious XSS input payload
            Console.Write("Enter your comment [Press Enter for default payload]: ");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                userInput = "<script>alert('Stealing cookies: ' + document.cookie);</script>";
                Console.WriteLine($"Using default payload: {userInput}");
            }

            Console.WriteLine($"\n[Raw Input] (UNSAFE if rendered in browser directly):");
            Console.WriteLine($"  {userInput}");

            // 2. Sanitize the input using HTML encoding
            // WebUtility.HtmlEncode converts characters like <, >, &, and " into their HTML entity equivalents.
            string sanitizedInput = WebUtility.HtmlEncode(userInput);

            Console.WriteLine($"\n[Sanitized Input] (SAFE for rendering):");
            Console.WriteLine($"  {sanitizedInput}");

            Console.WriteLine("\n--- Explanation of Encoding ---");
            Console.WriteLine("  '<' becomes '&lt;'");
            Console.WriteLine("  '>' becomes '&gt;'");
            Console.WriteLine("  '\"' becomes '&quot;'");
            Console.WriteLine("  ''' becomes '&#39;'");
            Console.WriteLine("  Now, the browser will display the script text as text instead of executing it.");

            Console.WriteLine("====================================================");
        }
    }
}
