using System;

namespace CSharpExercises
{
    public static class Exercise8_RefOutInParameters
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 8: Use ref, out, and in Parameters ===");

            // 1. ref parameter demo
            int refVal = 10;
            Console.WriteLine($"[ref] Before calling: refVal = {refVal}");
            ModifyWithRef(ref refVal);
            Console.WriteLine($"[ref] After calling: refVal = {refVal} (Modified by method)");

            // 2. out parameter demo
            int outVal; // Declared but uninitialized
            Console.WriteLine("[out] Variable declared but not initialized.");
            InitializeWithOut(out outVal);
            Console.WriteLine($"[out] After calling: outVal = {outVal} (Initialized by method)");

            // 3. in parameter demo
            int inVal = 100;
            Console.WriteLine($"[in] Before calling: inVal = {inVal}");
            ReadWithIn(in inVal);
            Console.WriteLine($"[in] After calling: inVal = {inVal} (Unchanged, read-only inside method)");

            Console.WriteLine("====================================================");
        }

        // ref requires the value to be initialized before passing. Can be read and modified.
        private static void ModifyWithRef(ref int value)
        {
            value += 5;
        }

        // out does not require initialization, but the method MUST assign a value before returning.
        private static void InitializeWithOut(out int value)
        {
            value = 42; // Must assign
        }

        // in passes the argument by reference, but makes it read-only (compiler error if modified).
        private static void ReadWithIn(in int value)
        {
            // value = 200; // COMPILER ERROR: Cannot assign to variable because it is a read-only variable
            Console.WriteLine($"      Inside ReadWithIn: value is {value}");
        }
    }
}
