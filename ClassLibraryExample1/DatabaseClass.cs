using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClassLibraryExample1
{
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class DatabaseClass
    {
        private readonly List<DataStruct> dataStruct;
        //private readonly DatabaseClass _db = DatabaseClass.Instance; 

        public static DatabaseClass Instance { get; } = new DatabaseClass();

        //load the list with a bunch of entries however way u want to 
        private DatabaseClass()
        {
            dataStruct = new List<ClassLibraryExample1.DataStruct>();
            var gen = new DatabaseGenerator();
            for (int i = 0; i < 100000; i++)
            {
                var record = new DataStruct(); 
                gen.GetNextAccount(out record.pin, out record.acctNo, out record.firstname, out record.lastname, out record.balance);

                dataStruct.Add(record);
            } 
          
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
                    pinNo = dataStruct[i].pin;
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

        public String getlastname(String name)
        {
            String lastname = "null";
            for (int i = 0; i < dataStruct.Count; i++)
            {
                if(dataStruct[i].lastname == null)
                {
                    throw new NullReferenceException("Reference is null"); 
                }else { 
                    if (dataStruct[i].lastname == name)
                    {
                        lastname = dataStruct[i].lastname;
                    }
                }
            }

            return lastname;
        }
    }
}
