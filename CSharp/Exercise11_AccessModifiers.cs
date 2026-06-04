using System;

namespace CSharpExercises
{
    public class BaseClass
    {
        public string publicVar = "Public Member (Accessible everywhere)";
        private string privateVar = "Private Member (Accessible ONLY within BaseClass)";
        protected string protectedVar = "Protected Member (Accessible in BaseClass and subclasses)";

        public void TestAccessFromSelf()
        {
            Console.WriteLine("Accessing members from inside BaseClass:");
            Console.WriteLine($"   - {publicVar}");
            Console.WriteLine($"   - {privateVar}");
            Console.WriteLine($"   - {protectedVar}");
        }
    }

    public class DerivedClass : BaseClass
    {
        public void TestAccessFromDerived()
        {
            Console.WriteLine("Accessing members from DerivedClass:");
            Console.WriteLine($"   - {publicVar} (Success)");
            
            // Console.WriteLine($"   - {privateVar}"); 
            Console.WriteLine("   - [privateVar] is NOT accessible here (causes Compile Error CS0122)");
            
            Console.WriteLine($"   - {protectedVar} (Success)");
        }
    }

    public class NonDerivedClass
    {
        public void TestAccessFromOutside()
        {
            BaseClass baseObj = new BaseClass();
            Console.WriteLine("Accessing members of BaseClass from NonDerivedClass instance:");
            Console.WriteLine($"   - {baseObj.publicVar} (Success)");
            
            // Console.WriteLine($"   - {baseObj.privateVar}"); 
            Console.WriteLine("   - [privateVar] is NOT accessible here (causes Compile Error CS0122)");

            // Console.WriteLine($"   - {baseObj.protectedVar}");
            Console.WriteLine("   - [protectedVar] is NOT accessible here (causes Compile Error CS1540 / CS0122)");
        }
    }

    public static class Exercise11_AccessModifiers
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 11: Demonstrate Access Modifiers ===");

            BaseClass baseObj = new BaseClass();
            baseObj.TestAccessFromSelf();
            Console.WriteLine();

            DerivedClass derivedObj = new DerivedClass();
            derivedObj.TestAccessFromDerived();
            Console.WriteLine();

            NonDerivedClass nonDerivedObj = new NonDerivedClass();
            nonDerivedObj.TestAccessFromOutside();

            Console.WriteLine("=================================================");
        }
    }
}
