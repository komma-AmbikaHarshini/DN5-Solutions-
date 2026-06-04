using System;

namespace CSharpExercises
{
    // Abstract Class
    public abstract class Vehicle
    {
        // Abstract method (no body, must be overridden by derived classes)
        public abstract void Drive();

        // Abstract classes can have non-abstract methods with implementation
        public void Honk()
        {
            Console.WriteLine("Vehicle is honking: Beep Beep!");
        }
    }

    // Interface
    public interface IDrivable
    {
        // Interface method (contracts, no implementation by default in traditional interfaces)
        void Start();
    }

    // Class implementing both Abstract Class and Interface
    public class DrivableCar : Vehicle, IDrivable
    {
        // Overriding the abstract method from Vehicle
        public override void Drive()
        {
            Console.WriteLine("Car is driving smoothly down the street.");
        }

        // Implementing the interface method from IDrivable
        public void Start()
        {
            Console.WriteLine("Car engine started: Vroom!");
        }
    }

    public static class Exercise15_AbstractInterface
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 15: Differentiate Abstract Classes and Interfaces ===");

            // Create instance of DrivableCar
            DrivableCar car = new DrivableCar();

            // 1. Demonstrate access via Concrete class reference
            Console.WriteLine("[Concrete Class Reference]");
            car.Start();
            car.Drive();
            car.Honk();
            Console.WriteLine();

            // 2. Demonstrate polymorphism using Abstract Class reference
            Console.WriteLine("[Abstract Class Reference (Vehicle)]");
            Vehicle vehicleRef = car;
            vehicleRef.Drive();
            vehicleRef.Honk();
            // vehicleRef.Start(); // Compiler Error: Vehicle does not define Start()
            Console.WriteLine();

            // 3. Demonstrate polymorphism using Interface reference
            Console.WriteLine("[Interface Reference (IDrivable)]");
            IDrivable drivableRef = car;
            drivableRef.Start();
            // drivableRef.Drive(); // Compiler Error: IDrivable does not define Drive()
            // drivableRef.Honk(); // Compiler Error: IDrivable does not define Honk()

            Console.WriteLine("==================================================================");
        }
    }
}
