using SharpBank.Models;

namespace SharpBank.API.Services.Interfaces
{
    public interface IAccountService
    {
        public Account Authenticate(Guid accountId, string password);
        public IEnumerable<Account> GetAccounts();
        public Account GetAccountById(Guid accountId);

        public Account Create(Account account);
        public Account Update(Account account);
        public Account Delete(Guid accountId);


    }
}
