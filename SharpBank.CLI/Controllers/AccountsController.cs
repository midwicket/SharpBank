﻿using SharpBank.Models;
using SharpBank.Services;
using SharpBank.Models.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models.Enums;

namespace SharpBank.CLI.Controllers
{
    class AccountsController
    {
        private readonly AccountServices accountService;
        private readonly Inputs inputs;

        public AccountsController(AccountServices accountService, Inputs inputs)
        {
            this.accountService = accountService;
            this.inputs = inputs;
        }
        public long CreateAccount(long bankId)
        {
            long id = 0;
            try
            {
                string name = inputs.GetName();
                string password = inputs.GetPassword();
                Gender gender = inputs.GetGender();

                id = accountService.AddAccount(name, bankId, gender);
            }
            catch (AccountIdException e)
            {

                Console.WriteLine("Account Number already exists.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return id;
        }
        public Account GetAccount(long bankId, long accountId)
        {

            try
            {
                Account acc = accountService.GetAccount(bankId, accountId);
                return acc;
            }
            catch (AccountIdException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
        public decimal GetBalance(long bankId, long accountId)
        {
            try
            {
                Account acc = accountService.GetAccount(bankId, accountId);
                if (acc == null)
                {
                    throw new AccountIdException();
                }
                return acc.Balance;
            }
            catch (AccountIdException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return -1m;
        }
        public List<Transaction> GetTransactionHistory(long bankId, long accountId)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                transactions = accountService.GetAccount(bankId, accountId).Transactions.ToList();
                return transactions;
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
    }
}