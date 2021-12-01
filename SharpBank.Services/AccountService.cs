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
        public AccountService(AppDbContext appDbContext)
        {

        }
        public Account Authenticate(long accountId, string password)
        {
            throw new NotImplementedException();
        }

        public Account Create(Account account)
        {
            throw new NotImplementedException();
        }

        public Account Delete(long accountId)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(long accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Account Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
