using System;

namespace CSharpExercises
{
    public class Car
    {
        // Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Default Constructor
        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = 2000;
        }

        // Parameterized Constructor
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Method to display details
        public void DisplayDetails()
        {
            Console.WriteLine($"Car -> Make: {Make}, Model: {Model}, Year: {Year}");
        }
    }

    public static class Exercise10_OOPBasics
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 10: Demonstrate OOP Basics with Constructors ===");

            // 1. Instantiate using default constructor
            Car defaultCar = new Car();
            Console.Write("Default constructor: ");
            defaultCar.DisplayDetails();

            // 2. Instantiate using parameterized constructor
            Car customCar = new Car("Tesla", "Model S", 2023);
            Console.Write("Parameterized constructor: ");
            customCar.DisplayDetails();

            Console.WriteLine("=============================================================");
        }
    }
}
