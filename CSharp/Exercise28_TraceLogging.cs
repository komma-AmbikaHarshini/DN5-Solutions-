using System;
using System.Diagnostics;
using System.IO;

namespace CSharpExercises
{
    public static class Exercise28_TraceLogging
    {
        private const string LogFilePath = "trace_log.txt";

        public static void Run()
        {
            Console.WriteLine("=== Exercise 28: Log with System.Diagnostics.Trace ===");
            
            // Clean any existing listeners to start fresh
            Trace.Listeners.Clear();

            // 1. Create trace listeners
            // Listener 1: Writes to a text file
            TextWriterTraceListener fileListener = new TextWriterTraceListener(LogFilePath);
            
            // Listener 2: Writes to Console Standard Output
            TextWriterTraceListener consoleListener = new TextWriterTraceListener(Console.Out);

            // Add listeners to Trace collection
            Trace.Listeners.Add(fileListener);
            Trace.Listeners.Add(consoleListener);

            // Configure Trace to automatically flush after write
            Trace.AutoFlush = true;

            Console.WriteLine("\n--- Writing Trace Logs (you should see these mirrored in console) ---");
            Trace.WriteLine($"[INFO] Log session started at {DateTime.Now}");
            Trace.TraceInformation("This is a standard informational trace message.");
            Trace.TraceWarning("This is a warning trace message (e.g. low resources).");
            Trace.TraceError("This is an error trace message (e.g. database failed).");
            Trace.WriteLine("[INFO] Log session ended.");

            // Flush and close the file listener specifically to release lock on file
            fileListener.Flush();
            fileListener.Close();
            Trace.Listeners.Remove(fileListener);
            Trace.Listeners.Remove(consoleListener);

            Console.WriteLine("\n--- Verifying Content Written to trace_log.txt ---");
            try
            {
                if (File.Exists(LogFilePath))
                {
                    string fileLogs = File.ReadAllText(LogFilePath);
                    Console.WriteLine("Logs read from trace_log.txt:");
                    Console.WriteLine(fileLogs);
                }
                else
                {
                    Console.WriteLine("Error: trace_log.txt not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
            }
            finally
            {
                // Clean up file
                if (File.Exists(LogFilePath))
                {
                    File.Delete(LogFilePath);
                    Console.WriteLine("Temporary log file 'trace_log.txt' deleted.");
                }
            }

            Console.WriteLine("======================================================");
        }
    }
}
