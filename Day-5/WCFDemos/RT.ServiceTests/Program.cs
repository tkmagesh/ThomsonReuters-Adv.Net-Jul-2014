using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TR.Contracts;
using TR.Services;

namespace RT.ServiceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.OrderItems = new []
                {
                    new OrderItem() {ProductId = 101, Cost = 10, Units = 10},
                    new OrderItem() {ProductId = 102, Cost = 40, Units = 50},
                    new OrderItem() {ProductId = 109, Cost = 90, Units = 20},
                    new OrderItem() {ProductId = 105, Cost = 20, Units = 60}
                };
            var orderService = new OrderService();
            orderService.Process(order);
            Console.ReadLine();
        }
    }
}
