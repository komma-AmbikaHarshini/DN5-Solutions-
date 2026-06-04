using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public static class Exercise27_DeadlockResolution
    {
        private static readonly object LockA = new object();
        private static readonly object LockB = new object();

        public static void Run()
        {
            Console.WriteLine("=== Exercise 27: Simulate and Resolve a Deadlock ===");
            
            Console.WriteLine("Choose action:");
            Console.WriteLine("  1. Run Deadlock Resolution (using Monitor.TryEnter - SAFE)");
            Console.WriteLine("  2. Simulate Actual Deadlock (will freeze, requiring termination - UNSAFE)");
            Console.Write("Enter choice (1 or 2) [Default 1]: ");
            string? choice = Console.ReadLine();

            if (choice == "2")
            {
                Console.WriteLine("\n[Simulating Deadlock] Both threads will block indefinitely. Watch the console...");
                SimulateDeadlock();
            }
            else
            {
                Console.WriteLine("\n[Running Deadlock Resolution] Using Monitor.TryEnter with timeouts to prevent deadlock...");
                ResolveDeadlockDemo();
            }

            Console.WriteLine("====================================================");
        }

        #region Unsafe Deadlock Simulation
        private static void SimulateDeadlock()
        {
            Task task1 = Task.Run(() =>
            {
                lock (LockA)
                {
                    Console.WriteLine("  [Thread 1] Acquired Lock A. Sleeping...");
                    Thread.Sleep(1000);
                    Console.WriteLine("  [Thread 1] Attempting to acquire Lock B...");
                    lock (LockB)
                    {
                        Console.WriteLine("  [Thread 1] Acquired Lock B.");
                    }
                }
            });

            Task task2 = Task.Run(() =>
            {
                lock (LockB)
                {
                    Console.WriteLine("  [Thread 2] Acquired Lock B. Sleeping...");
                    Thread.Sleep(1000);
                    Console.WriteLine("  [Thread 2] Attempting to acquire Lock A...");
                    lock (LockA)
                    {
                        Console.WriteLine("  [Thread 2] Acquired Lock A.");
                    }
                }
            });

            // Wait with a timeout to avoid hangs during automated runs
            bool completed = Task.WaitAll(new[] { task1, task2 }, 5000);
            if (!completed)
            {
                Console.WriteLine("\n  [SYSTEM NOTE] The threads are now deadlocked! Task.WaitAll timed out after 5 seconds.");
            }
        }
        #endregion

        #region Safe Deadlock Resolution
        private static void ResolveDeadlockDemo()
        {
            Task task1 = Task.Run(() =>
            {
                bool acquiredA = false;
                bool acquiredB = false;

                try
                {
                    // Attempt lock A
                    Monitor.Enter(LockA, ref acquiredA);
                    Console.WriteLine("  [Thread 1] Acquired Lock A.");
                    Thread.Sleep(1000); // Wait to let Thread 2 acquire B

                    Console.WriteLine("  [Thread 1] Attempting to acquire Lock B (with 1.5s timeout)...");
                    // Try to acquire B, timeout after 1500ms
                    acquiredB = Monitor.TryEnter(LockB, TimeSpan.FromMilliseconds(1500));

                    if (acquiredB)
                    {
                        Console.WriteLine("  [Thread 1] Success: Acquired Lock B.");
                    }
                    else
                    {
                        Console.WriteLine("  [Thread 1] Timeout: Failed to acquire Lock B. Releasing Lock A to prevent deadlock...");
                    }
                }
                finally
                {
                    if (acquiredB) Monitor.Exit(LockB);
                    if (acquiredA) Monitor.Exit(LockA);
                }
            });

            Task task2 = Task.Run(() =>
            {
                bool acquiredA = false;
                bool acquiredB = false;

                try
                {
                    // Attempt lock B
                    Monitor.Enter(LockB, ref acquiredB);
                    Console.WriteLine("  [Thread 2] Acquired Lock B.");
                    Thread.Sleep(1000); // Wait to let Thread 1 acquire A

                    Console.WriteLine("  [Thread 2] Attempting to acquire Lock A (with 1.5s timeout)...");
                    // Try to acquire A, timeout after 1500ms
                    acquiredA = Monitor.TryEnter(LockA, TimeSpan.FromMilliseconds(1500));

                    if (acquiredA)
                    {
                        Console.WriteLine("  [Thread 2] Success: Acquired Lock A.");
                    }
                    else
                    {
                        Console.WriteLine("  [Thread 2] Timeout: Failed to acquire Lock A. Releasing Lock B to prevent deadlock...");
                    }
                }
                finally
                {
                    if (acquiredA) Monitor.Exit(LockA);
                    if (acquiredB) Monitor.Exit(LockB);
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine("\nBoth threads finished execution safely without freezing.");
        }
        #endregion
    }
}
