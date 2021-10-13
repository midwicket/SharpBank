using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Services;

namespace SharpBank.CLI
{
    static class  Menu
    {
        public static void BankMenu()
        {
            Console.WriteLine("Choose Your Bank");
            int c = 1;
            foreach (var x in BankService.GetBanks()) 
            {
                Console.WriteLine(c + " -> " + x.BankName);
                c += 1;
            }
        }
        public static void LoginMenu()
        {
            Console.WriteLine("1-> Create Account");
            Console.WriteLine("2-> Login");
            Console.WriteLine("3-> Back");
            Console.WriteLine("4-> Exit");
        }
        public static void UserMenu()
        {
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Transfer");
            Console.WriteLine("4.Show Balance");
            Console.WriteLine("5.Show Transaction History");
        }
    }
}
