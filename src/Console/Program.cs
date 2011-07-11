using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    using Model;
    using Model.DataAccess;
    using Model.Infrastructure;

    class Program
    {
        static void Main(string[] args)
        {
            using(var salesUnitOfWork = new SalesUnitOfWork("Sales"))
            {
                var customer = new Customer { FirstName = "John", LastName = "Smith" };

                var order = new Order {Date = DateTime.Now};
                order.OrderItems.Add(new OrderItem {Price = 101});

                customer.Orders.Add(order);

                salesUnitOfWork.Customers.Add(customer);

                salesUnitOfWork.Commit();

                var customers = salesUnitOfWork.Customers
                    .FindAll()
                    .Include("Orders.OrderItems")
                    .Where(c => c.Orders.Any(o => o.OrderItems.Any(oi => oi.Price > 100)))
                    .OrderBy(c => c.FirstName)
                    .Take(10)
                    .ToList();

                foreach (var c in customers)
                {
                    System.Console.WriteLine(c.FirstName);
                    foreach (var o in c.Orders)
                    {
                        System.Console.WriteLine(o.Date);
                    }
                }

            }
        }
    }
}
