﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Models.Exceptions;

namespace SharpBank.Services
{
    public class BankService
    {
        private readonly Datastore datastore;

        private List<string> banks = new List<string>();
        public BankService(Datastore datastore)
        {
            this.datastore = datastore;
            datastore.Banks.Add(new Bank { Id = 0, Name = "Reserve Bank", Accounts = new List<Account> { } });
        }
        public long GenerateId()
        {
            Random rand = new Random(123);

            long Id;
            do
            {
                Id = rand.Next();
            }

            while (datastore.Banks.SingleOrDefault(b => b.Id == Id) != null);
            return Id;
        }
        public long AddBank(string name)
        {
            Bank bank = new Bank
            {
                Id = GenerateId(),
                Name = name,
                CreatedOn = DateTime.Now,
                CreatedBy = "Admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "Admin",
                Accounts = new List<Account>()
            };
            datastore.Banks.Add(bank);
            string s = bank.Id.ToString("D10") + " | " + bank.Name;
            banks.Add(s);
            return bank.Id;
        }

        public Bank GetBank(long bankId)
        {

            return datastore.Banks.SingleOrDefault(b => b.Id == bankId);
        }
        public List<string> GetBanks()
        { 
            return banks;
        }

    }
}