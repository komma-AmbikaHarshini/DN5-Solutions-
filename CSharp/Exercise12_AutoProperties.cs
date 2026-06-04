using System;

namespace CSharpExercises
{
    public class Product
    {
        // Auto-implemented property
        public string Name { get; set; } = "Generic Product";

        // Backing field for Price
        private decimal _price;

        // Property with backing field and validation
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"[Validation Warning] Attempted to set negative price: {value}. Resetting to 0.");
                    _price = 0;
                }
                else
                {
                    _price = value;
                }
            }
        }
    }

    public static class Exercise12_AutoProperties
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 12: Use Auto-Properties and Backing Fields ===");

            Product prod = new Product();
            prod.Name = "Wireless Mouse";
            
            // Set valid price
            prod.Price = 29.99m;
            Console.WriteLine($"Product Name: {prod.Name}, Price: ${prod.Price} (Successfully set)");

            // Try to set negative price
            prod.Price = -5.50m;
            Console.WriteLine($"Product Name: {prod.Name}, Price: ${prod.Price} (After validation)");

            Console.WriteLine("=============================================================");
        }
    }
}
