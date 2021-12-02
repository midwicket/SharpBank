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
    public class AccountService : IAccountService
    {
        private readonly AppDbContext appDbContext;

        public AccountService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Account Authenticate(Guid accountId, string password)
        {
            throw new NotImplementedException();
        }

        public Account Create(Account account)
        {
            appDbContext.Accounts.Add(account);
            appDbContext.SaveChanges();
            return account;
        }

        public Account Delete(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(Guid accountId)
        {
            var res = appDbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            return res;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return appDbContext.Accounts
                .Include(a => a.Funds)
                .ThenInclude(f => f.Wallets)
                .Include(a => a.CreditTransactions)
                .Include(a => a.DebitTransactions)
                .ToList();
        }

        public Account Update(Account account)
        {
            appDbContext.Accounts.Attach(account);
            appDbContext.SaveChanges();
            return account;
        }
    }

}
