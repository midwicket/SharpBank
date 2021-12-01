using SharpBank.Models;

namespace SharpBank.API.Services.Interfaces
{
    public interface IAccountService
    {
        public Account Authenticate(long accountId, string password);
        public IEnumerable<Account> GetAccounts();
        public Account GetAccountById(long accountId);

        public Account Create(Account account);
        public Account Update(Account account);
        public Account Delete(long accountId);


    }
}
