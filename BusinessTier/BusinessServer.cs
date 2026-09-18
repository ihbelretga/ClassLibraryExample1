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
    internal class BusinessServer : BusinessServerInterface
    {
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
            String localname = name;
            localname = db.getlastname(localname);
            return localname;
        }

        public void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName)
        {
            if (index < 0 || index >= db.GetNumRecords())
            {
                throw new FaultException<IndexOutOfRangeFault>(
                    new IndexOutOfRangeFault { Issue = $"Index {index} is out of range." });
            }

            acctNo = db.GetAccountNoByIndex(index);
            pin = db.GetPinByIndex(index);
            balance = db.GetBalanceByIndex(index);
            fName = db.GetFirstNameByIndex(index);
            lName = db.GetLastNameByIndex(index);
        }
        
        public int GetNumEntries()
        {
            int getNumEntries = 0;
            getNumEntries = db.GetNumRecords();
            return getNumEntries;
        }
    }
}
