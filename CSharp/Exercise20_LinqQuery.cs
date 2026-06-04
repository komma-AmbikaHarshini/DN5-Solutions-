using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpExercises
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = "";
        public double TotalAmount { get; set; }
    }

    public static class Exercise20_LinqQuery
    {
        public static void Run()
        {
            Console.WriteLine("=== Exercise 20: Use LINQ for Filtering and Projection ===");

            // 1. Populate a list of Order objects
            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 1, CustomerName = "Alice", TotalAmount = 150.50 },
                new Order { OrderId = 2, CustomerName = "Bob", TotalAmount = 45.00 },
                new Order { OrderId = 3, CustomerName = "Charlie", TotalAmount = 250.00 },
                new Order { OrderId = 4, CustomerName = "David", TotalAmount = 95.99 },
                new Order { OrderId = 5, CustomerName = "Eve", TotalAmount = 120.00 }
            };

            Console.WriteLine("All Orders:");
            foreach (var o in orders)
            {
                Console.WriteLine($"  Order #{o.OrderId} - Customer: {o.CustomerName}, Amount: ${o.TotalAmount}");
            }

            Console.WriteLine("\nFiltering orders with TotalAmount > $100 and projecting using LINQ:");

            // 2. LINQ Query Syntax (Filtering by price and projecting to an anonymous type)
            var querySyntaxResult = from o in orders
                                    where o.TotalAmount > 100.0
                                    select new
                                    {
                                        Id = o.OrderId,
                                        Client = o.CustomerName,
                                        AmountPaid = o.TotalAmount
                                    };

            Console.WriteLine("\n[LINQ Query Syntax Results] (Total > 100):");
            foreach (var item in querySyntaxResult)
            {
                Console.WriteLine($"  Projected Order -> Id: {item.Id}, Client: {item.Client}, Amount: ${item.AmountPaid}");
            }

            // 3. LINQ Method Syntax (equivalent)
            var methodSyntaxResult = orders
                .Where(o => o.TotalAmount > 100.0)
                .Select(o => new
                {
                    Id = o.OrderId,
                    Client = o.CustomerName,
                    AmountPaid = o.TotalAmount
                });

            Console.WriteLine("\n[LINQ Method Syntax Results] (Total > 100):");
            foreach (var item in methodSyntaxResult)
            {
                Console.WriteLine($"  Projected Order -> Id: {item.Id}, Client: {item.Client}, Amount: ${item.AmountPaid}");
            }

            Console.WriteLine("==========================================================");
        }
    }
}
