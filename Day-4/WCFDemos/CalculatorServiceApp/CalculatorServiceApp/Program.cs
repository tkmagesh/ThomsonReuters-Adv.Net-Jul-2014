using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using CalculatorServicesApp.Contracts;
using CalculatorServicesApp.Services;


namespace CalculatorServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (Calculator), new Uri[] {});
            Console.WriteLine();
            host.AddServiceEndpoint(typeof(ICalculator),new BasicHttpBinding(),"http://localhost:8080/Calculator" );
            host.Open();
            Console.WriteLine("Service running...");
            Console.ReadLine();
        }
    }
}
