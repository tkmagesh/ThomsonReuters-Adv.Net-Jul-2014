using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using CalculatorServicesApp.Contracts;

namespace CalculatorServicesClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endPointAddress = new EndpointAddress("http://localhost:8080/calculator");
            var channelFactory = new ChannelFactory<ICalculator>(binding, endPointAddress);
            var calculator = channelFactory.CreateChannel();
            Console.WriteLine(calculator.Add(100,200));
            Console.WriteLine(calculator.Subtract(100,200));
            Console.WriteLine(calculator.Multiply(100,200));
            Console.ReadLine();
        }
    }
}
