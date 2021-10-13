using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharpBank.CLI
{
    public   class Inputs
    {
        public long GetAccountId()
        {
            Console.WriteLine("Please Enter Your ID :");
            return Convert.ToInt64(Console.ReadLine());
        }
        public string GetPassword()
        {
            Console.WriteLine("Please Enter Your Password :");
            return Console.ReadLine();
        }
        public   string GetName()
        {
            Console.WriteLine("Please Enter The Name :");
            return Console.ReadLine();
        }
        public   Gender GetGender()
        {
            Console.WriteLine("Please Enter Your Gender (Male/Female/Other) :");
            Enum.TryParse(Console.ReadLine(),out Gender gender);
            return gender;
        }
        public   int GetSelection()
        {
            try
            {
                Console.WriteLine("Please Enter Your Selection :");

                return Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid Selection");
            }
            //Goback
            return -1;
        }
        public decimal GetAmount()
        {
            Console.WriteLine("Please Enter The Amount :");
            return Convert.ToDecimal(Console.ReadLine());
        }
        public   List<long> GetRecipient()
        {
            List<long> res = new List<long>();
            Console.WriteLine("Please Enter Recipient BankId");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            Console.WriteLine("Please Enter Recipient Account number");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            return res;
        }
    }
}
