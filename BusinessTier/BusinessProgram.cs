using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    internal class BusinessProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the server");
            ServiceHost BusinessHost;

            NetTcpBinding binding = new NetTcpBinding();
            BusinessHost = new ServiceHost(typeof(BusinessServer));
            BusinessHost.AddServiceEndpoint(typeof(BusinessServerInterface), binding, "net.tcp://localhost:8200/BusinessServer");
            BusinessHost.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            BusinessHost.Close();
        }
    }
}
