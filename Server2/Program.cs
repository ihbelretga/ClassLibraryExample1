using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Server1;
using Server1.Services;

namespace Server2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the server");
            ServiceHost Host;

            NetTcpBinding binding = new NetTcpBinding();
            Host = new ServiceHost(typeof(DataServer));
            Host.AddServiceEndpoint(typeof(DataServerInterface), binding, "net.tcp://localhost:8000/DataServer");
            Host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            Host.Close();
            
        }
    }
}
