using Server1;
using Server1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface
    {

        private readonly ClassLibraryExample1.DatabaseClass db = new ClassLibraryExample1.DatabaseClass();
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

    }
}
