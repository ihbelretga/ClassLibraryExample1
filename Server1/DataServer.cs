using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using ClassLibraryExample1;
//using ClassLibraryExample1.DatabaseClass; 

namespace Server1
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : Services.DataServerInterface
    {
        int curretindex = 0;
        int currentbalance = 0;
        uint currentaccountnumber = 0;
        uint currentpin = 0;
        string currentfirstname = null;
        string currentlastname = null;
        public DataServer() { }
        public int GetNumEntries()
        {
            //heres the thing, is this supposed to be get num entries or get num records? i feel so confused? 
            int getNumEntries = 0;
            ClassLibraryExample1.DatabaseClass db = new ClassLibraryExample1.DatabaseClass();
            getNumEntries = db.GetNumRecords();
            return getNumEntries;
        }

        public void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName)
        {

            ClassLibraryExample1.DatabaseClass db = new ClassLibraryExample1.DatabaseClass();

            db.GetValuesForEntry(index, out acctNo, out pin, out balance, out fName, out lName);
            //acctNo = 0;
            //pin = 0;
            //balance = 0;
            //fName = null;
            //lName = null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the server");
            ServiceHost Host;

            NetTcpBinding binding = new NetTcpBinding();
            Host = new ServiceHost(typeof(DataServer));
            Host.AddServiceEndpoint(typeof(Services.DataServerInterface), binding, "net.tcp://localhost:8000/DataServer");
            Host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            Host.Close();
        }

    }
}
