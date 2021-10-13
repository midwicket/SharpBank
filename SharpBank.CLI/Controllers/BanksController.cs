using SharpBank.Models;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models.Exceptions;



namespace SharpBank.CLI.Controllers
{
    static class BanksController
    {
        // public Bank CreateBank()
        //{
        //    try
        //    {
        //        string name = Inputs.GetName();
        //        string password = Inputs.GetPassword();
        //        string accountNumber = BankServices.GenerateIFSC(ifsc);
        //        foreach (Bank a in BankServices.GetBanks()) 
        //        {
        //            if (a.IFSC == accountNumber && a.IFSC == ifsc)
        //            {
        //                throw new IFSCException();
        //            }
        //        }
        //        Bank acc = new Bank
        //        {
        //            UserName = name,
        //            Password = password,
        //            IFSC = accountNumber,
        //            IFSC = ifsc,
        //            Balance=0m
        //        };
        //        BankServices.AddBank(acc);
        //        return acc;
        //    }
        //    catch (IFSCException e)
        //    {

        //        Console.WriteLine("Bank Number already exists.");
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine("Internal Error");
        //    }
        //    return null;
        //}
        public static List<Bank> GetBanks()
        {
            try
            {
                List<Bank> banks = BankService.GetBanks();
                if (banks == null)
                {
                    throw new Exception("Internal error");
                }
                return banks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }



        public static Bank GetBank(string ifsc)
        {

            try
            {
                Bank b=BankService.GetBank(ifsc);
                if(b==null)
                {
                    throw new IFSCException();
                }
                return b;
            }
            catch (IFSCException e)
            {

                Console.WriteLine("Bank  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
    }
}
