using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostRun
{
    class Program
    {

        //Host the service
        //Run this main in order to start the service
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(AccountService.AccountService));
            host.Open();
            Console.WriteLine("Service Hosted Sucessfully");
            Console.Read();
        }
    }
}
