using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.Data;
using Server1;



namespace BusinessTier
{
    [ServiceContract]
    public interface BusinessServerInterface
    {
        [OperationContract]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        void GetvaluesForEntry(int index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName);


        //this is just a random function to test out operation contract 
        [OperationContract]
        int GetNumEntries();

        [OperationContract]
        String collectlastname(String name); 
    }
}
