using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using TR.Contracts;

namespace TR.Services
{
    [ServiceBehavior]
    public class OrderService : IOrderService
    {
        [OperationBehavior]
        public void Process(Order order)
        {
            var orderValue = order.OrderItems.Sum(orderItem => orderItem.Cost*orderItem.Units);
            Console.WriteLine("Order processed with {0} items for {1:c} value!!",order.OrderItems.Count(), orderValue);
            Thread.Sleep(5000);
        }
    }
}
