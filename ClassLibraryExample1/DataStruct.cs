using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryExample1
{
    internal class DataStruct
    {
        public uint acctNo;
        public uint pin;
        public int balance;
        public string firstname; 
        public string lastname; 

        public DataStruct() 
        {
            acctNo = 0;
            pin = 0;
            balance = 0;
            firstname = null;
            lastname = null;
        }

    }
}
