using System;

namespace CSharpExercises
{
    // Base class
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape.");
        }
    }

    // Derived class 1
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle (O).");
        }
    }

    // Derived class 2
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle [__].");
        }
    }

    public static class Exercise14_InheritanceOverriding
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 14: Demonstrate Inheritance and Method Overriding ===");

            // Create objects polymorphically
            Shape shape1 = new Circle();
            Shape shape2 = new Rectangle();
            Shape shape3 = new Shape();

            // Call Draw() on each
            Console.Write("shape1.Draw() -> ");
            shape1.Draw();

            Console.Write("shape2.Draw() -> ");
            shape2.Draw();

            Console.Write("shape3.Draw() -> ");
            shape3.Draw();

            Console.WriteLine("==================================================================");
        }
    }
}
