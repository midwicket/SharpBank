using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Services;

namespace SharpBank.CLI
{
     class  Menu
    {
        public  void BankMenu(Datastore datastore)
        {
            Console.WriteLine("Choose Your Bank");
            Console.WriteLine("Id | Name");
            Console.WriteLine("------------------");
            int c = 1;
            foreach (Bank bank in datastore.Banks) {
                Console.WriteLine(bank.BankId + " | " + bank.Name);
            }
        }
        public  void LoginMenu()
        {
            Console.WriteLine("Option | Description");
            Console.WriteLine("-------------------------");
            Console.WriteLine("   1   | Create Account");
            Console.WriteLine("   2   | Login");
            Console.WriteLine("   3   | Back");
            Console.WriteLine("   4   | Exit");
        }
        public  void UserMenu()
        {
            Console.WriteLine("Option | Description");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("   1   | Deposit");
            Console.WriteLine("   2   | Withdraw");
            Console.WriteLine("   3   | Transfer");
            Console.WriteLine("   4   | Show Balance");
            Console.WriteLine("   5   | Show Transaction History");
        }
    }
}
