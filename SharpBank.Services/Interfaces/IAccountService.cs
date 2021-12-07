using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    public interface IAccountService
    {
        public Account Authenticate(Guid accountId, string password);
        public IEnumerable<Account> GetAccounts();
        public Account GetAccountById(Guid accountId);
        public Account Create(Account account);

        public Funds CreateFunds (Funds funds);

        public Account Update(Account account);
        public Account Delete(Guid accountId);


    }
}
