using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public static class Exercise26_RaceConditions
    {
        private static int _unsafeCounter = 0;
        private static int _safeCounter = 0;
        private static readonly object _lockObject = new object();
        
        private const int ThreadCount = 10;
        private const int IncrementsPerThread = 100000;

        public static void Run()
        {
            Console.WriteLine("=== Exercise 26: Demonstrate Race Conditions ===");
            Console.WriteLine($"Running {ThreadCount} threads, each incrementing the counter {IncrementsPerThread:N0} times.");
            int expectedTotal = ThreadCount * IncrementsPerThread;
            Console.WriteLine($"Expected Final Counter: {expectedTotal:N0}\n");

            // --- 1. Unsafe Multi-threaded Access (Race Condition) ---
            _unsafeCounter = 0;
            List<Task> unsafeTasks = new List<Task>();
            for (int i = 0; i < ThreadCount; i++)
            {
                unsafeTasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < IncrementsPerThread; j++)
                    {
                        _unsafeCounter++; // Non-atomic operation (read-modify-write)
                    }
                }));
            }
            Task.WaitAll(unsafeTasks.ToArray());
            Console.WriteLine($"[Unsafe Counter] Result: {_unsafeCounter:N0}");
            Console.WriteLine($"                 Difference: {expectedTotal - _unsafeCounter:N0} lost increments due to race conditions.");

            // --- 2. Safe Multi-threaded Access using 'lock' ---
            _safeCounter = 0;
            List<Task> safeTasks = new List<Task>();
            for (int i = 0; i < ThreadCount; i++)
            {
                safeTasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < IncrementsPerThread; j++)
                    {
                        lock (_lockObject)
                        {
                            _safeCounter++; // Synchronized access
                        }
                    }
                }));
            }
            Task.WaitAll(safeTasks.ToArray());
            Console.WriteLine($"\n[Safe Counter]   Result: {_safeCounter:N0}");
            Console.WriteLine($"                 Difference: {expectedTotal - _safeCounter} (Perfect match!)");

            Console.WriteLine("================================================");
        }
    }
}
