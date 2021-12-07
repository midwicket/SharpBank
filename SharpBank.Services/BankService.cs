using Microsoft.EntityFrameworkCore;
using SharpBank.Data;
using SharpBank.Models;
using SharpBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services
{
    public class BankService : IBankService
    {
        private readonly AppDbContext appDbContext;

        public BankService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Bank Create(Bank bank)
        {
            appDbContext.Banks.Add(bank);
            appDbContext.SaveChanges();
            return bank;
        }

        public TransactionCharge CreateTransactionCharge(Bank bank,decimal rtgs, decimal imps, decimal neft, string name)
        {
            TransactionCharge transactionCharge = new TransactionCharge
            {
                Id = Guid.NewGuid(),
                Name = name,
                RTGS = rtgs,
                NEFT = neft,
                IMPS = imps,
                BankId = bank.BankId

            };
            appDbContext.Charges.Add(transactionCharge);
            return transactionCharge;
        }

        public Bank Delete(Guid Id)
        {
            Bank bank = appDbContext.Banks.SingleOrDefault(b => (b.BankId == Id));
            appDbContext.Banks.Remove(bank);
            appDbContext.SaveChanges();
            return bank;
        }

        public Bank GetBankById(Guid Id)
        {
            Bank bank = appDbContext.Banks.SingleOrDefault(b => (b.BankId == Id));
            return bank;
        }

        public Bank GetBankByName(string bankName)
        {
            Bank bank = appDbContext.Banks.FirstOrDefault(b => (b.Name == bankName));
            return bank;
        }

        public IEnumerable<Bank> GetBanks()
        {
            return appDbContext.Banks.Include(b => b.Accounts).ToList();
        }

        public TransactionCharge GetTransactionChargeByName(Guid bankId, string Name)
        {
            TransactionCharge transactionCharge = appDbContext.Charges.SingleOrDefault(tc => ((tc.Name==Name)&&(tc.BankId==bankId)));
            return transactionCharge;
        }

        public Bank Update(Bank bank)
        {
            appDbContext.Banks.Attach(bank);
            appDbContext.SaveChanges();
            return bank;
        }

        public TransactionCharge UpdateTransactionCharge(Bank bank, decimal rtgs, decimal imps, decimal neft, string name)
        {
            TransactionCharge transactionCharge = appDbContext.Charges.SingleOrDefault(tc => ((tc.Name == name) && (tc.BankId == bank.BankId)));
            transactionCharge.RTGS = rtgs;
            transactionCharge.NEFT = neft;
            transactionCharge.IMPS = imps;
            appDbContext.Charges.Attach(transactionCharge);
            appDbContext.SaveChanges();
            return transactionCharge;
        }
    }

}
