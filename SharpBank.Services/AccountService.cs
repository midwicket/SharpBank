using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Models.Enums;
using SharpBank.Models.Exceptions;

namespace SharpBank.Services
{
    public class AccountService
    {
        private readonly BankService bankService;

        public AccountService( BankService bankService)
        {
            this.bankService = bankService;
            Account acc = new Account
            {
                Name = "Outflow",
                Gender = Gender.Other,
                AccountId = 0,
                BankId = 0,
                Balance = 0m,
                Status = Status.Active,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank(0).Accounts.Add(acc);
        }

        public long AddAccount(string name, long bankId, Gender gender)
        {
            Account acc = new Account
            {
                Name = name,
                Gender = gender,
                AccountId = GenerateId(bankId),
                BankId = bankId,
                Balance = 0m,
                Status = Status.Active,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank(bankId).Accounts.Add(acc);
            return acc.AccountId;
        }
        public long GenerateId(long bankId)
        {
            Random rand = new Random();
            Bank bank = bankService.GetBank(bankId);
            long Id;
            do
            {
                Id = rand.Next();
            }

            while (bank.Accounts.SingleOrDefault(a => a.AccountId == Id)!=null);
            return Id;
        }

        public Account GetAccount(long bankId, long accountId)
        {
            return bankService.GetBank(bankId).Accounts.SingleOrDefault(a=>a.AccountId == accountId); 
        }
        public void UpdateBalance(long bankId,long accountId,decimal balance)
        {
            Account acc = GetAccount(bankId, accountId);
            acc.Balance = balance;
        }
        public void RemoveAccount(long bankId, long accountId)
        {
            bankService.GetBank(bankId).Accounts.Remove(GetAccount(bankId, accountId));
        }

    }
}
