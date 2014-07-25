using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using TR.Services;

namespace TRServicesHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (OrderService), new Uri[] {});
            host.Open();
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("{0},{1},{2}", endpoint.Address, endpoint.Binding.Name, endpoint.Contract.ContractType.FullName);
            }
            Console.WriteLine("Service running... press ENTER to shutdown");
            Console.ReadLine();
        }
    }
}
