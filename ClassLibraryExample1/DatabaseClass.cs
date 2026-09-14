using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryExample1
{
    public class DatabaseClass
    {
        List<DataStruct> dataStruct;
        DataStruct dataStruct1 = new DataStruct();
        DataStruct dataStruct2 = new DataStruct();
        DataStruct dataStruct3 = new DataStruct();
        DataStruct dataStruct4 = new DataStruct();
        DataStruct dataStruct5 = new DataStruct();
        DataStruct dataStruct6 = new DataStruct();
        DataStruct dataStruct7 = new DataStruct();
        DataStruct dataStruct8 = new DataStruct();
        DataStruct dataStruct9 = new DataStruct();
        DataStruct dataStruct10 = new DataStruct();

        //load the list with a bunch of entries however way u want to 
        public DatabaseClass()
        {
            dataStruct = new List<ClassLibraryExample1.DataStruct>();
            dataStruct.Add(dataStruct1);
            dataStruct.Add(dataStruct2);
            dataStruct.Add(dataStruct3);
            dataStruct.Add(dataStruct4);
            dataStruct.Add(dataStruct5);
            dataStruct.Add(dataStruct6);
            dataStruct.Add(dataStruct7);
            dataStruct.Add(dataStruct8);
            dataStruct.Add(dataStruct9);
            dataStruct.Add(dataStruct10);
        }

        //implement the following functions as well 
        public uint GetAccountNoByIndex(int index)
        {
            uint acctNo = 0;
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if (i == index)
                {
                    acctNo = dataStruct[i].acctNo;
                }
            }

            return acctNo; 
        }

        public uint GetPinByIndex(int index)
        {
            uint pinNo = 0;
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if (i == index)
                {
                    pinNo = dataStruct[i].acctNo;
                }
            }

            return pinNo;
        }

        public string GetFirstNameByIndex(int index)
        {
            String firstname= null; 
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if (i == index)
                {
                    firstname = dataStruct[i].firstname;
                }
            }

            return firstname;
        }

        public string GetLastNameByIndex(int index)
        {
            String lastName= null;
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if (i == index)
                {
                    lastName = dataStruct[i].lastname;
                }
            }
            return lastName;

        }

        public int GetBalanceByIndex(int index)
        {
            int balance = 0;
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if (i == index)
                {
                    balance = dataStruct[i].balance;
                }
            }
            return balance;

        }

        public int GetNumRecords()
        {
            int numRecords = 1;
            for (int i = 0; i < dataStruct.Count; i++)
            {
                numRecords = numRecords + 1;
            }

            return numRecords;
        }   
    }
}
