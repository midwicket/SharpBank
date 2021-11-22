using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;
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
                Password = "".GetHashCode().ToString(),
                Balance = new Funds { Wallets=new List<Money<decimal>>() },
                Status = Status.Active,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank(0).Accounts.Add(acc);
        }
        public string GetHashedPassword(long bankId, long accountID) {

            Account acc = GetAccount(bankId, accountID);
            return acc.Password;

        }
        public void UpdateStatus(long bankId, long accountId, Status status) {
            Account acc = GetAccount(bankId, accountId);
            acc.Status = status;
        }
        public long AddAccount(string name, long bankId, Gender gender,string hashedPassword)
        {
            Account acc = new Account
            {
                Name = name,
                Gender = gender,
                AccountId = GenerateId(bankId),
                BankId = bankId,
                Balance = new Funds { Wallets = new List<Money<decimal>>() },
                Status = Status.Active,
                Password = hashedPassword,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank(bankId).Accounts.Add(acc);
            return acc.AccountId;
        }
        public long GenerateId(long bankId)
        {
            Random rand = new Random(321);
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
        public void UpdateBalance(long bankId,long accountId,Money<decimal> money)
        {
            Account acc = GetAccount(bankId, accountId);
            acc.Balance += money;
        }
        public void SetPassword(long bankId, long accountId, string password) {
            Account acc = GetAccount(bankId, accountId);
            acc.Password = password;
        }
        public void RemoveAccount(long bankId, long accountId)
        {
            bankService.GetBank(bankId).Accounts.Remove(GetAccount(bankId, accountId));
        }


    }
}
