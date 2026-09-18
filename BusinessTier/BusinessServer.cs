using ClassLibraryExample1;
using Server1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace BusinessTier
{
    public delegate String getlastname(String name);
    public delegate int getNumRecords();
    public delegate uint GetAccountNoByIndex(int index);
    public delegate uint GetPinByIndex(int index);
    public delegate String GetFirstNameByIndex(int index);
    public delegate String GetLastNameByIndex(int index); 
    public delegate int GetBalanceByIndex(int index);
    internal class BusinessServer : BusinessServerInterface
    {
        getlastname getlastname;
        getNumRecords GetNumRecords;
        GetAccountNoByIndex GetAccountNoByIndex;
        GetPinByIndex GetPinByIndex; 
        GetFirstNameByIndex GetFirstNameByIndex;
        GetLastNameByIndex GetLastNameByIndex;
        GetBalanceByIndex GetBalanceByIndex;

        private readonly ClassLibraryExample1.DatabaseClass db = new DatabaseClass();
        private readonly Server1.Services.DataServerInterface servers;

        BusinessServer()
        {
            var tcp = new NetTcpBinding();
            var factory = new ChannelFactory<Server1.Services.DataServerInterface>(tcp, new EndpointAddress("net.tcp://localhost:8100/DataServer"));
            servers = factory.CreateChannel(); 
        }

        public String collectlastname(String name) 
        {
            //the delegate actually works 
            getlastname = db.getlastname;
            String localname = name;
            localname = getlastname(localname);
            return localname;
        }

        public void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName)
        {
            //six delegate references need to be here 
            GetAccountNoByIndex = db.GetAccountNoByIndex;
            GetPinByIndex = db.GetPinByIndex; 
            GetFirstNameByIndex = db.GetFirstNameByIndex;
            GetLastNameByIndex = db.GetLastNameByIndex;
            GetBalanceByIndex= db.GetBalanceByIndex;
            if (index < 0 || index >= GetNumRecords())
            {
                throw new FaultException<IndexOutOfRangeFault>(
                    new IndexOutOfRangeFault { Issue = $"Index {index} is out of range." });
            }
            GetNumRecords = db.GetNumRecords;
            acctNo = GetAccountNoByIndex(index);
            pin = GetPinByIndex(index);
            balance = GetBalanceByIndex(index);
            fName = GetFirstNameByIndex(index);
            lName = GetLastNameByIndex(index);
        }
        
        public int GetNumEntries()
        {
            GetNumRecords = db.GetNumRecords;
            int getNumEntries = 0;
            getNumEntries = GetNumRecords();
            return getNumEntries;
        }
    }
}
