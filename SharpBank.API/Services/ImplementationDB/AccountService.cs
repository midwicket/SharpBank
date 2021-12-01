using SharpBank.API.Services.Interfaces;
using SharpBank.Models;

namespace SharpBank.API.Services.ImplementationDB
{
    public class AccountService : IAccountService
    {
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
