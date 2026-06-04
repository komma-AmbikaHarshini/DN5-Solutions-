using System;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public static class Exercise23_AsyncUpload
    {
        // Make the Run method async to demonstrate proper async/await flow
        public static async Task RunAsync()
        {
            Console.WriteLine("=== Exercise 23: Simulate Async File Upload ===");
            Console.WriteLine("Initiating file uploads...");

            // 1. Run a successful upload
            try
            {
                Console.WriteLine("\n[Upload 1] Starting upload of 'report.pdf' (Simulating success)...");
                string result = await UploadFileAsync("report.pdf", simulateError: false);
                Console.WriteLine($"[Upload 1] Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Upload 1] Unexpected Error: {ex.Message}");
            }

            // 2. Run a failed upload
            try
            {
                Console.WriteLine("\n[Upload 2] Starting upload of 'virus.exe' (Simulating network error)...");
                string result = await UploadFileAsync("virus.exe", simulateError: true);
                Console.WriteLine($"[Upload 2] Result: {result}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Upload 2] Caught Expected Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Upload 2] Caught Unexpected Error: {ex.Message}");
            }

            Console.WriteLine("===============================================");
        }

        // Asynchronous method simulating a file upload (waiting 3 seconds)
        private static async Task<string> UploadFileAsync(string fileName, bool simulateError)
        {
            // Simulate network latency / upload progress
            for (int i = 1; i <= 3; i++)
            {
                await Task.Delay(1000); // Wait 1 second for each tick
                Console.WriteLine($"  ...Uploading '{fileName}': {i * 33}% completed");
            }

            if (simulateError)
            {
                throw new InvalidOperationException($"Upload failed: connection reset while uploading '{fileName}'.");
            }

            return $"Successfully uploaded '{fileName}' (Size: 1024 KB)";
        }
    }
}
