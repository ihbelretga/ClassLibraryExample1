using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Security.Tokens;
using ClassLibraryExample1;
//using ClassLibraryExample1.DatabaseClass; 

namespace Server1
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : Services.DataServerInterface
    {
        
        private readonly ClassLibraryExample1.DatabaseClass db = new ClassLibraryExample1.DatabaseClass();
        private readonly DatabaseClass _db = DatabaseClass.Instance; 
        public DataServer() { }
        public int GetNumEntries()
        {
            //heres the thing, is this supposed to be get num entries or get num records? i feel so confused? 
            int getNumEntries = 0;
            getNumEntries = db.GetNumRecords();
            return getNumEntries;
        }

        public void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName)
        {

            if(index < 0 || index >= db.GetNumRecords())
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

        public string collectlastname(String name)
        {
            String lastname; 
            lastname = db.getlastname(name);

            return lastname;
        }
    }
}
