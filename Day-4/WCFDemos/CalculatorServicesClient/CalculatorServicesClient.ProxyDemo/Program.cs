using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorServicesClient.ProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorClient = new ServiceProxies.CalculatorServices.CalculatorClient();
            var advancedCalculatorClient = new ServiceProxies.CalculatorServices.AdvancedCalculatorClient();
            
            Console.ReadLine();
        }
    }
}
