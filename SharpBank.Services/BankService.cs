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

        public void Delete(Guid Id)
        {
            Bank bank = appDbContext.Banks.SingleOrDefault(b => (b.BankId == Id));
            appDbContext.Banks.Remove(bank);
            appDbContext.SaveChanges();
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

        public Bank Update(Bank bank)
        {
            appDbContext.Banks.Attach(bank);
            appDbContext.SaveChanges();
            return bank;
        }
    }

}
