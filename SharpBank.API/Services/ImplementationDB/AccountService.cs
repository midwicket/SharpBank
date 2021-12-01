using SharpBank.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharpBank.Models;

namespace SharpBank.API.Services.ImplementationDB
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
            return appDbContext.Accounts.Include(a=>a.Funds).ToList();
        }

        public Account Update(Account account)
        {
            appDbContext.Accounts.Attach(account);
            appDbContext.SaveChanges();
            return account;
        }
    }
}
