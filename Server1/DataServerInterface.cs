using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryExample1.DatabaseGenerator;

namespace Server1.Services
{
    [ServiceContract]
    public interface DataServerInterface
    {
        [OperationContract]
        int GetNumEntries(); 

        [OperationContract]
        void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName);
    }
}
