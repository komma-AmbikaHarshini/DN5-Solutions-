using System;
using System.IO;
using System.Text;

namespace CSharpExercises
{
    public static class Exercise25_FileMemoryStream
    {
        private const string TestFilePath = "stream_test.txt";

        public static void Run()
        {
            Console.WriteLine("=== Exercise 25: Use FileStream and MemoryStream ===");

            // --- 1. Preparation: Write a test file ---
            string testData = "This is a test message read via FileStream in C#.";
            File.WriteAllText(TestFilePath, testData);

            // --- 2. Read text from a file using FileStream ---
            Console.WriteLine($"Reading from '{TestFilePath}' using FileStream:");
            try
            {
                using (FileStream fs = new FileStream(TestFilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    int bytesRead = fs.Read(buffer, 0, buffer.Length);
                    
                    string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"  Bytes Read: {bytesRead}");
                    Console.WriteLine($"  Content Read: \"{content}\"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  FileStream read error: {ex.Message}");
            }
            finally
            {
                // Clean up test file
                if (File.Exists(TestFilePath))
                {
                    File.Delete(TestFilePath);
                }
            }

            // --- 3. Write data to MemoryStream ---
            Console.WriteLine("\nWriting data to MemoryStream:");
            string memData = "Hello, MemoryStream! This exists entirely in RAM.";
            byte[] memBytes = Encoding.UTF8.GetBytes(memData);

            using (MemoryStream ms = new MemoryStream())
            {
                // Write bytes to MemoryStream
                ms.Write(memBytes, 0, memBytes.Length);
                
                Console.WriteLine($"  Bytes Written to MemoryStream: {ms.Length}");
                Console.WriteLine($"  Stream Capacity: {ms.Capacity} bytes");
                
                // Read it back
                ms.Position = 0; // Reset position to read from beginning
                byte[] readBuffer = new byte[ms.Length];
                int memBytesRead = ms.Read(readBuffer, 0, readBuffer.Length);
                string memContent = Encoding.UTF8.GetString(readBuffer, 0, memBytesRead);

                Console.WriteLine($"  Content read back from MemoryStream: \"{memContent}\"");
            }

            Console.WriteLine("====================================================");
        }
    }
}
