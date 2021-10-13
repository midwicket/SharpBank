using SharpBank.Models;
using SharpBank.Services;
using SharpBank.Models.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Controllers
{
    static class AccountsController
    {
        public static Account CreateAccount(string ifsc)
        {
            try
            {
                string name = Inputs.GetName();
                string password = Inputs.GetPassword();
                string accountNumber = AccountService.GenerateAccountNumber(ifsc);
                foreach (Account a in AccountService.GetAccounts()) 
                {
                    if (a.AccountNumber == accountNumber && a.IFSC == ifsc)
                    {
                        throw new AccountNumberException();
                    }
                }
                Account acc = new Account
                {
                    UserName = name,
                    Password = password,
                    AccountNumber = accountNumber,
                    IFSC = ifsc,
                    Balance=0m
                };
                AccountService.AddAccount(acc);
                return acc;
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account Number already exists.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
        public static Account GetAccount(string ifsc, string accountNumber)
        {

            try
            {
                Account acc=AccountService.GetAccount(ifsc, accountNumber);
                if(acc==null)
                {
                    throw new AccountNumberException();
                }
                return acc;
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
        public static decimal GetBalance(Account acc)
        {
            try
            {
                if (acc == null)
                {
                    throw new AccountNumberException();
                }
                return acc.Balance;
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return -1m;
        }
    }
}
