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
    public class BankService
    {
        private readonly Datastore datastore;

        public BankService(Datastore datastore)
        {
            this.datastore = datastore;
            datastore.Banks.Add(new Bank { BankId = 0, Name="Reserve Bank",
                RTGS = new TransactionCharge { IntraBank = 0m, InterBank = 2 },
                IMPS = new TransactionCharge { IntraBank = 5m, InterBank = 6 },
                NEFT = new TransactionCharge { IntraBank = 0.5m, InterBank = 1 },
                Accounts = new List<Account> { } } );
        }
        public long GenerateId()
        {
            Random rand = new Random(123);
            
            long Id;
            do
            {
                Id = rand.Next();
            }

            while (datastore.Banks.SingleOrDefault(b => b.BankId == Id) != null);
            return Id;
        }
        public long AddBank(string name)
        {
            Bank bank = new Bank
            {
                BankId = GenerateId(),
                Name = name,
                RTGS = new TransactionCharge { IntraBank = 0m, InterBank = 2 },
                IMPS = new TransactionCharge { IntraBank = 5m, InterBank = 6 },
                NEFT = new TransactionCharge { IntraBank = 0.5m, InterBank = 1 },
                CreatedOn = DateTime.Now,
                CreatedBy = "Admin",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "Admin",
                Accounts = new List<Account>()
            };
            datastore.Banks.Add(bank);
            return bank.BankId;
        }

        public Bank GetBank(long bankId) {

            return datastore.Banks.SingleOrDefault(b => b.BankId == bankId);
        }
        public Bank GetBankByName(string name) {
            return datastore.Banks.FirstOrDefault(b => b.Name == name);
        }
        public TransactionCharge GetTransactionCharge(long bankId, TransactionType transactionType) {
            return transactionType switch
            {
                TransactionType.IMPS => GetBank(bankId).IMPS,
                TransactionType.RTGS => GetBank(bankId).IMPS,
                TransactionType.NEFT => GetBank(bankId).NEFT,
                _ => new TransactionCharge { InterBank=0m,IntraBank=0m}

            };
        }
    }
}
