using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryExample1
{
    public class DatabaseGenerator
    {
        int currentpin, currentaccountnumber, currentbalance;
        String currentrandomfirstName, currentrandomlastName;
        Random rnd = new Random();
        private static readonly string[] firstname = { };
        public static readonly string[] firstNames = { "Harry", "Ron", "Clark ", "Horld", "Clark", "Clyde", "Cullen", "Dante", "Dax", "Desmond", "Draco", "Edmund", "Elloit", "Ender", "Fletcher", "Ford", "Gale", "Gray", "Heath" };
        public static string[] lastNames = { "Hermoine", "Lara", "Michelle", "Vesna", "Cynthia", "Julie", "Amanda", "Lele", "Tiana", "Kiera", "Charlotte", "Lucy", "Daphne", "Eleanor", "Evelyn", "Amira", "Adele", "Tia", "Barbie" };

        private string GetFirstname()
        {
            currentrandomfirstName = firstNames[rnd.Next(firstNames.Length)];
            return currentrandomfirstName;
        }

        private string GetLastname()
        {
            currentrandomlastName = lastNames[rnd.Next(lastNames.Length)];
            return currentrandomlastName;
        }

        private uint GetPIN()
        {
            currentpin = rnd.Next(0, 32);
            return (uint)currentpin;
        }

        private uint GetAcctNo()
        {
            currentaccountnumber = rnd.Next(0, 1000000);
            return (uint)currentaccountnumber;
        }

        private int GetBalance()
        {
            currentbalance = rnd.Next(0, 100);
            return currentbalance;
        }

        public void GetNextAccount(out uint pin, out uint accountnumber, out string randomfirstname, out string randomlastname, out int balance)
        {
            pin = (uint)currentpin;
            accountnumber = (uint)currentaccountnumber;
            randomfirstname = currentrandomfirstName;
            randomlastname = currentrandomlastName;
            balance = currentbalance;
        }
    }
}
