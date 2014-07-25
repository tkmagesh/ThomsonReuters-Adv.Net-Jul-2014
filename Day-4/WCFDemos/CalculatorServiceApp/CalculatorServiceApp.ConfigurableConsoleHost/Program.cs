using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using CalculatorServicesApp.Services;

namespace CalculatorServiceApp.ConfigurableConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (Calculator), new Uri[] {});
            host.Open();
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("{0},{1},{2}",endpoint.Address, endpoint.Binding.ToString(), endpoint.Contract.ContractType.FullName);
            }
            Console.WriteLine("Service [Configurable host] is running ....");
            Console.ReadLine();
        }
    }
}
